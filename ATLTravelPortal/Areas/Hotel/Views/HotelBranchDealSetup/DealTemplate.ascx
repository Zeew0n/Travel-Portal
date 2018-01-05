<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<ATLTravelPortal.Areas.Airline.Models.BranchDealViewModel>" %>
<tr class="optional">
    <table width="100%" cellpadding="0" cellspacing="0" class="GridView">
        <thead>
            <th style="width: 75px;">
                <%:Html.LabelFor(model => model.HotelName)%>
            </th>
            <%-- <th style="width: 150px;">
                Sector Info
            </th>--%>
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
                    <%:Html.TextBoxFor(model => model.HotelName, new { @style ="width:150px;", @class = "airAutoComplete"}) %>
                    <%: Html.HiddenFor(model => model.HotelId) %>
                    <%:Html.ValidationMessageFor(model => model.HotelName)%>
                </td>
                <%-- <td>
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
                </td>--%>
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
