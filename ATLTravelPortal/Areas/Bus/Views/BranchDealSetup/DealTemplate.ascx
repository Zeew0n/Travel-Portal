<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<ATLTravelPortal.Areas.Airline.Models.BranchDealViewModel>" %>
<tr class="optional">
    <table width="100%" cellpadding="0" cellspacing="0" class="GridView">
        <thead>
            <th style="width: 75px;">
                Operator
            </th>
            <th>
                Category
            </th>
            <th style="width: 120px;">
                Sector Type
            </th>
            <th style="width:100px;">
                Currency
            </th>
            <th style="width: 270px;">
                Sector Info
            </th>
            <th style="width: 150px;">
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
    
        Html.HiddenFor(model => model.DealId)
               
                    %>
                    <%:Html.HiddenFor(model=>model.DealMasterId) %>
                    <%: Html.Label("Operator")%>
                    <%: Html.DropDownListFor(model => model.BusOperatorId, Model.BusOperatorList,"--All--", new { @style="width:150px;"})%>
                    <%: Html.ValidationMessageFor(model => model.BusOperatorId)%>
                </td>
                <td>
                    <%: Html.Label("Category")%>
                    <%: Html.DropDownListFor(model => model.BusCategoryId, Model.BusCategoryList, new { @style="width:150px;"})%>
                    <%: Html.ValidationMessageFor(model => model.BusCategoryId)%>
                </td>
                <td>
                    <% List<SelectListItem> sectorTypeList = new List<SelectListItem>{
                        new SelectListItem { Text = "Domestic", Value = "D"},
                         new SelectListItem { Text = "International", Value = "I"},
                        };%>
                    <%:Html.DropDownListFor(model => model.SectorType, sectorTypeList)%>
                </td>
                <td>
                    <%:Html.DropDownListFor(model=>model.CurrencyId,Model.CurrencyList) %>
                </td>
                <td>
                    <p style="width: 138px;">
                        <span style="float: left; width: 35px;">From:</span>
                        <%: Html.TextBoxFor(model => model.FromCity, new { @class = "fromCityAutoComplete", @style = "width:150px;" })%>
                        <%: Html.HiddenFor(model => model.FromCityId)%>
                        <%: Html.ValidationMessageFor(model => model.FromCity, "*")%>
                    </p>
                    <p style="width: 138px;">
                        <span style="float: left; width: 35px;">To:</span>
                        <%: Html.TextBoxFor(model => model.ToCity, new {  @class = "toCityAutoComplete", @style = "width:150px;" })%>
                        <%: Html.HiddenFor(model => model.ToCityId)%>
                        <%: Html.ValidationMessageFor(model => model.ToCity, "*")%>
                    </p>
                </td>
                <td>
                    <%: Html.TextBoxFor(model => model.Amount, new { @style = "width:150px;", @onkeypress = "return CheckFareNumericValue(event)"})%>
                    <%: Html.ValidationMessageFor(model => model.Amount, "*")%>
                </td>
                <td>
                    <label>
                        <%:Html.CheckBoxFor(model=>model.isPercentage) %></label>
                </td>
            </tr>
        </tbody>
    </table>
</tr>
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
    $(document).ready(function () {
        $("#BusOperatorId").change(function () {
            $("#loadingIndicator").html('<center><img src="<%=Url.Content("~/Content/images/indicator.gif") %>" alt="" width="16px" height="16px" /></center>');
            id = $("#BusOperatorId").val();

            if (id == "") {
                $("#BusCategoryId").empty();
                $("#BusCategoryId").append("<option value=''>" + "-- ALL--" + "</option>");
                $("#loadingIndicator").html('');
                return false;


            }
            else {
                var url = "/Bus/AjaxRequest/GetCategoryByMasterId/";
                $.getJSON(url, { id: id }, function (data) {
                    $("#BusCategoryId").empty().append("<option value=''>" + "-- ALL--" + "</option>");

                    $.each(data, function (index, optionData) {
                        $("#BusCategoryId").append("<option value='" + optionData.Value + "'>" + optionData.Text + "</option>");
                    });
                    $("#loadingIndicator").html('');
                });
            }
        }).change();
    });
</script>
