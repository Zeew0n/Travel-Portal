<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<ATLTravelPortal.Areas.Airline.Models.DealViewModel>" %>
<%--<tr class="optional">--%>
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
                <%:Html.DropDownListFor(model => Model.DealIdentifierId, Model.DealIdentifierList, new {  @style="width:90px;" })%>
                <%:Html.HiddenFor(model => model.DealIdentifierText)%>
            </td>
            <td>
                <%:Html.DropDownListFor(model => Model.BusOperatorId, Model.BusOperatorList,"--All--", new {@style="width:100px;" })%>
              
            </td>
            <td>
                <%:Html.DropDownListFor(model => Model.BusCategoryId, Model.BusCategoryList, new {@style= "width:100px;"})%>
            </td>
            <td>
                <% List<SelectListItem> sectorTypeList = new List<SelectListItem>{
                        new SelectListItem { Text = "Domestic", Value = "D"},
                         new SelectListItem { Text = "International", Value = "I"},
                        };%>
                <%:Html.DropDownListFor(model => model.SectorType, sectorTypeList)%>
            </td>
            <td>
                <p style="width: 138px;">
                    <span style="float: left; width: 35px;">From:</span>
                    <%: Html.TextBoxFor(model => model.FromCity, new { @class = "fromCityAutoComplete", @style = "width:100px;" })%>
                    <%: Html.HiddenFor(model => model.FromCityId)%>
                    <%: Html.ValidationMessageFor(model => model.FromCity, "*")%>
                </p>
                <p style="width: 138px;">
                    <span style="float: left; width: 35px;">To:</span>
                    <%: Html.TextBoxFor(model => model.ToCity, new {  @class = "toCityAutoComplete", @style = "width:100px;" })%>
                    <%: Html.HiddenFor(model => model.ToCityId)%>
                    <%: Html.ValidationMessageFor(model => model.ToCity, "*")%>
                </p>
            </td>
            <td>
                <%:Html.DropDownListFor(model => model.CurrencyId, Model.CurrencyList)%>
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
    </tbody>
</table>
<%--</tr>--%>
<script type="text/javascript">
    $("#AdultYQCommission").live("keyup", function () {
        var ChildYQCommission = $("#AdultYQCommission").val();
        var InfantYQCommission = $("#AdultYQCommission").val();
        $('#ChildYQCommission').val(ChildYQCommission);
        $('#InfantYQCommission').val(InfantYQCommission);
    });
    $("#AdultBFCommission").live("keyup", function () {
        var ChildYQCommission = $("#AdultBFCommission").val();
        var InfantYQCommission = $("#AdultBFCommission").val();
        $('#ChildBFCommission').val(ChildYQCommission);
        $('#InfantBFCommission').val(InfantYQCommission);
    });

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

        $("#FromCityId").ready(function () {
            fromcityid = $("#FromCityId").val();
            tocityid = $("ToCityId").val();
            if (fromcityid == tocityid) {
                alert("Enter Different sector");
            }



        }).change();


    });
    

</script>
