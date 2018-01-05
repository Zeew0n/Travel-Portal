<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<ATLTravelPortal.Areas.Airline.Models.BranchDealViewModel>" %>
<tr class="optional">
    <table width="100%" cellpadding="0" cellspacing="0" class="GridView">
        <thead>
            <th style="width: 100px;">
                <%:Html.LabelFor(model => model.AirlineName)%>
            </th>
            <th style=" width:100px;">
                Sector Type
            </th>
            <th style="width:50px;">
                Currency
            </th>
            <th style="width: 100px;">
                Sector Info
            </th>
            <th style="width: 100px;">
                Amount
            </th>
            <th style="width: 30px;">
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
                    <%:Html.TextBoxFor(model => model.AirlineName, new { @style ="width:150px;", @class = "airAutoComplete"}) %>
                    <%: Html.HiddenFor(model => model.AirlineId) %>
                    <%:Html.ValidationMessageFor(model => model.AirlineName)%>
                    <br />
                     Class:
                    <%:Html.TextBoxFor(model=>model.AirlineClass, new  {@style="width:75px;" }) %>
                    <%:Html.ValidationMessageFor(model => model.AirlineClass)%>
                    <br />
                    
                </td>
                <td>
                    <% List<SelectListItem> sectorTypeList = new List<SelectListItem>{
                        new SelectListItem { Text = "International", Value = "I"},
                         new SelectListItem { Text = "Domestic", Value = "D"},
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
                    <br />
                    On Roundtrip:
                    <%:Html.CheckBoxFor(model=>model.isRoundTrip) %>
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
</script>
