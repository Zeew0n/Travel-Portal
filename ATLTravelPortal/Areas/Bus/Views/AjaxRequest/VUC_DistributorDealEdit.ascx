<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<ATLTravelPortal.Areas.Airline.Models.BranchDealViewModel>" %>
<%int counterIndex = Model.DealId; %>
<% using (Html.BeginForm("Index", "DistributorDealSetup", FormMethod.Post, new { @id = "myUpdateForm" + counterIndex, @name = "myUpdateForm" + counterIndex }))
   { %>
<table width="100%" cellpadding="0" cellspacing="0" class="GridView">
    <thead>
        <th style="width: 75px;">
            Operator
        </th>
        <th>
            Category
        </th>
        <th style="width: 200px;">
            Sector Type
        </th>
        <th style="width: 100px;">
            Currency
        </th>
        <th style="width: 270px;">
            Sector Info
        </th>
        <th style="width: 70px;">
            Amount
        </th>
        <th style="width: 15px;">
            Is%
        </th>
    </thead>
    <tbody>
        <tr class="optional">
            <td>
                <%:
    
        Html.HiddenFor(model => model.DealId, new { @id ="editDealId" })
               
                %>
                <%:Html.HiddenFor(model=>model.DealMasterId) %>
                <%: Html.Label("Operator")%>
                <%: Html.DropDownListFor(model => model.BusOperatorId, Model.BusOperatorList,"--All--", new { @style="width:150px;"})%>
                <%: Html.ValidationMessageFor(model => model.BusOperatorId)%>
            </td>
            <td>
                <%: Html.Label("Category")%>
                <%: Html.DropDownListFor(model => model.BusCategoryId, Model.BusCategoryList,"--All--", new { @style="width:150px;"})%>
                <%: Html.ValidationMessageFor(model => model.BusCategoryId)%>
            </td>
            <td>
                <% List<SelectListItem> sectorTypeList = new List<SelectListItem>{
                        new SelectListItem { Text = "Domestic", Value = "D"},
                         new SelectListItem { Text = "International", Value = "I"},
                        };%>
                <%:Html.DropDownListFor(model => model.SectorType, sectorTypeList, new  {@id="editSectorType" })%>
            </td>
            <td>
                <%:Html.DropDownListFor(model=>model.CurrencyId,Model.CurrencyList) %>
            </td>
            <td>
                On Sector
                <p style="width: 110px;">
                    <span style="float: left; width: 35px;">From:</span>
                    <%: Html.TextBoxFor(model => model.FromCity, new { @id = "editFromCity_"+counterIndex, @class = "fromCityAutoComplete", @style = "width:100px;" })%>
                    <%: Html.HiddenFor(model => model.FromCityId, new {@id="editFromCityId_"+counterIndex})%>
                    <%: Html.ValidationMessageFor(model => model.FromCity, "*")%>
                </p>
                <p style="width: 110px;">
                    <span style="float: left; width: 35px;">To:</span>
                    <%: Html.TextBoxFor(model => model.ToCity, new { @id = "editToCity_"+counterIndex, @class = "toCityAutoComplete", @style = "width:100px;" })%>
                    <%: Html.HiddenFor(model => model.ToCityId, new  {@id="editToCityId_"+counterIndex })%>
                    <%: Html.ValidationMessageFor(model => model.ToCity, "*")%>
                </p>
            </td>
            <td>
                <%: Html.TextBoxFor(model=>model.Amount, new { id="editAmount_"+counterIndex,@style ="width:75px;", 
                         @name = "editAmount_" + counterIndex, @onkeypress = "return CheckFareNumericValue(event)"}) %>
            </td>
            <td>
                <label>
                    <%:Html.CheckBoxFor(model=>model.isPercentage) %></label>
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
    function CheckFareNumericValue(e) {

        var key = e.which ? e.which : e.keyCode;
        //enter key  //backspace //tabkey      //escape key  //dot  //minus             
        if ((key >= 48 && key <= 57) || key == 13 || key == 8 || key == 9 || key == 27 || key == 46 || key == 45) {
            return true;
        }
        else {

            return false;
        }
    }
</script>
<script type="text/javascript" language="javascript">
    $(".airAutoComplete").live("change", function () {
        var text = $(this).val();
        var idCtrl = $(this).attr("id");
        var idCounter = idCtrl.substring(idCtrl.lastIndexOf('_') + 1);

        if (text == '')
            $("#editAirlineId_" + idCounter).val('');
    });

    $("#editFromCity_" + '<%=Model.DealId %>').live("change", function () {
        $("#editFromCityId_" + '<%=Model.DealId %>').val('');
    });


    $("#editToCity_" + '<%=Model.DealId %>').live("change", function () {
        $("#editToCityId_" + '<%=Model.DealId %>').val('');
    });

  
</script>
<script type="text/javascript">
    $(document).ready(function () {
        $(function () {
            $(".airAutoComplete").autocomplete({
                minlength: 2,
                source: function (request, response) {
                    $.ajax({
                        url: "/Airline/AjaxRequest/FindAirlines", type: "POST", dataType: "json",
                        data: { searchText: request.term, maxResult: 5 },

                        success: function (data) {
                            response($.map(data, function (item) {
                                return { label: item.AirlineName + " (" + item.AirlineCode + ")", value: item.AirlineName, id: item.AirlineId }
                            }))
                        }
                    });
                },
                width: 150,
                select: function (event, ui) {
                    var idCtrl = $(this).attr("id");
                    var idCounter = idCtrl.substring(idCtrl.lastIndexOf('_') + 1);

                    $("#editAirlineId_" + idCounter).val(ui.item.id);
                }
            });
        });

        $(function () {
            $(".fromCityAutoComplete").autocomplete({
                minlength: 2,
                source: function (request, response) {
                    $.ajax({
                        url: "/Airline/AjaxRequest/FindAirlineCity", type: "POST", dataType: "json",
                        data: { searchText: request.term, maxResult: 5 },

                        success: function (data) {
                            response($.map(data, function (item) {
                                return { label: item.CityName + " (" + item.CityCode + ")", value: item.CityName, id: item.CityID }
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
                        url: "/Airline/AjaxRequest/FindAirlineCity", type: "POST", dataType: "json",
                        data: { searchText: request.term, maxResult: 5 },
                        success: function (data) {
                            response($.map(data, function (item) {
                                return { label: item.CityName + " (" + item.CityCode + ")", value: item.CityName, id: item.CityID }
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

