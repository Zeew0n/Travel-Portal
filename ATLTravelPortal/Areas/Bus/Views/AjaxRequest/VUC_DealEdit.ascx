<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<ATLTravelPortal.Areas.Airline.Models.DealViewModel>" %>
<%int counterIndex = Model.DealId; %>
<% using (Html.BeginForm("Index", "DealSetup", FormMethod.Post, new { @id = "myUpdateForm" + counterIndex, @name = "myUpdateForm" + counterIndex }))
   { %>
<table width="100%" cellpadding="0" cellspacing="0" class="GridView">
    <thead>
        <th style="width: 100px;">
            Deal Identifier
        </th>
        <th style="width: 100px;">
            Operator
        </th>
        <th style="width: 100px;">
            Category
        </th>
        <th style="width: 100px;">
            Sector Type
        </th>
        <th style="width: 150px;">
            Sector Info
        </th>
        <th style="width: 35px;">
            Currency
        </th>
        <th style="width: 50px;">
            Markup
        </th>
        <th style="width: 15px;">
            Is%
        </th>
        <th style="width: 50px;">
            Commission
        </th>
        <th style="width: 15px;">
            Is%
        </th>
    </thead>
    <tbody>
        <tr class="optional">
            <td>
                <%:Html.HiddenFor(model=>model.DealMasterId) %>
                <%:Html.DropDownListFor(model => Model.DealIdentifierId, Model.DealIdentifierList, new { @id = "editDealIdentifierId", @style="width:90px;" })%>
                <%:Html.HiddenFor(model => model.DealIdentifierText, new { @id = "editDealIdentifierText" })%>
                <%:Html.HiddenFor(model => model.DealId, new { @id ="editDealId" })%>
            </td>
            <td>
                <%:Html.DropDownListFor(model => Model.BusOperatorId, Model.BusOperatorList,"--All--", new {@style="width:100px;"})%>
            </td>
            <td>
                <%:Html.DropDownListFor(model => Model.BusCategoryId, Model.BusCategoryList,"--All--", new { @style = "width:100px;" })%>
            </td>
            <td>
                <% List<SelectListItem> sectorTypeList = new List<SelectListItem>{
                        new SelectListItem { Text = "Domestic", Value = "D"},
                         new SelectListItem { Text = "International", Value = "I"},
                        };%>
                <%:Html.DropDownListFor(model => model.SectorType, sectorTypeList, new  {@id="editSectorType" })%>
            </td>
            <td>
                <p style="width: 138px;">
                    <span style="float: left; width: 35px;">From:</span>
                    <%: Html.TextBoxFor(model => model.FromCity, new { @id = "editFromCity_"+counterIndex, @class = "fromCityAutoComplete", @style = "width:100px;" })%>
                    <%: Html.HiddenFor(model => model.FromCityId, new {@id="editFromCityId_"+counterIndex})%>
                    <%: Html.ValidationMessageFor(model => model.FromCity, "*")%>
                </p>
                <p style="width: 138px;">
                    <span style="float: left; width: 35px;">To:</span>
                    <%: Html.TextBoxFor(model => model.ToCity, new { @id = "editToCity_"+counterIndex, @class = "toCityAutoComplete", @style = "width:100px;" })%>
                    <%: Html.HiddenFor(model => model.ToCityId, new  {@id="editToCityId_"+counterIndex })%>
                    <%: Html.ValidationMessageFor(model => model.ToCity, "*")%>
                </p>
            </td>
            <td>
                <%:Html.DropDownListFor(model => model.CurrencyId, Model.CurrencyList, new { @id = "editCurrencyId" })%>
            </td>
            <td style="width: 50px;">
                <%:Html.TextBoxFor(model => model.AdultMarkup, new {@style="width:50px;"})%>
            </td>
            <td>
                <%:Html.CheckBoxFor(model=>model.isMarkupPercentage) %>
            </td>
            <td style="width: 50px;">
                <%:Html.TextBoxFor(model => model.AdultBFCommission, new { @style = "width:50px;" })%>
            </td>
            <td>
                <%:Html.CheckBoxFor(model=>model.isBFCommissionPercentage) %><br />
            </td>
        </tr>
        <tr>
            <td colspan="13" style="text-align: right; height: 30px; vertical-align: middle;">
                <label id="DealDetail_<%=Model.DealId %>_loading" style="width: 20px; float: left;">
                </label>
                <input type="button" value="Update" id="UpdateUpdate_<%=counterIndex %>" onclick="UpdateDeal('DealDetail_<%=Model.DealId %>','myUpdateForm<%=Model.DealId %>')"
                    class="update" />
                <input type="button" value="Cancel" onclick="CancelDeal('DealDetail_<%=Model.DealId %>','<%=Model.DealId %>')"
                    id="Cancel_<%=counterIndex %>" class="Canc" />
            </td>
        </tr>
    </tbody>
</table>
<%} %>
<script type="text/javascript">
    $(document).ready(function () {


        $(function () {
            $(".fromCityAutoComplete").autocomplete({
                minlength: 2,
                source: function (request, response) {
                    $.ajax({
                        url: "/Airline/AjaxRequest/FindBusCity", type: "POST", dataType: "json",
                        data: { searchText: request.term, maxResult: 5 },

                        success: function (data) {
                            response($.map(data, function (item) {
                                return { label: item.BusCityName + " (" + item.BusCityCode + ")", value: item.BusCityName, id: item.BusCityId }
                            }))
                        }
                    });
                },
                width: 150,
                select: function (event, ui) {
                    var idCtrl = $(this).attr("id");
                    var idCounter = idCtrl.substring(idCtrl.lastIndexOf('_') + 1);
                    $("#editFromCityId_" + idCounter).val(ui.item.id);
                }
            });
        });

        $(function () {
            $(".toCityAutoComplete").autocomplete({
                minlength: 2,
                source: function (request, response) {
                    $.ajax({
                        url: "/Airline/AjaxRequest/FindBusCity", type: "POST", dataType: "json",
                        data: { searchText: request.term, maxResult: 5 },
                        success: function (data) {
                            response($.map(data, function (item) {
                                return { label: item.BusCityName + " (" + item.BusCityCode + ")", value: item.BusCityName, id: item.BusCityId }
                            }))
                        }
                    });
                },
                width: 150,
                select: function (event, ui) {
                    var idCtrl = $(this).attr("id");
                    var idCounter = idCtrl.substring(idCtrl.lastIndexOf('_') + 1);
                    $("#editToCityId_" + idCounter).val(ui.item.id);
                }
            });
        });
    });
   
</script>
<script type="text/javascript">
    $(document).ready(function () {
        $("#BusOperatorId").change(function () {

            id = $("#BusOperatorId").val();
            if (id == "") {

                $("#BusCategoryId").empty();
                $("#BusCategoryId").append("<option value=''>" + "-- Select--" + "</option>");
                $("#loadingIndicator").html('');
                return false;
            }
            else {
                var url = "/Bus/AjaxRequest/GetCategoryByOperatorId";

                $.getJSON(url, { id: id }, function (data) {
                    $("#BusCategoryId").empty();
                    $("#BusCategoryId").append("<option value=''>" + "-- Select--" + "</option>");
                    $.each(data, function (index, optionData) {
                        $("#BusCategoryId").append("<option value='" + optionData.Value + "'>" + optionData.Text + "</option>");
                    });
                });
            }
        }).change();

    });
</script>
