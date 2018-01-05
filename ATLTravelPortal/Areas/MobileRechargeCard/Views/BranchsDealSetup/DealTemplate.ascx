<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<ATLTravelPortal.Areas.Airline.Models.BranchDealViewModel>" %>
<tr class="optional">
    <table width="100%" cellpadding="0" cellspacing="0" class="GridView">
        <thead>
            <th style="width: 200px;">
                Deal Identifier
            </th>
            <th style="width: 200px;">
                Commission
            </th>
            <th style="width: 200px;">
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
                    <%: Html.DropDownListFor(model => model.DealIdentifierId, Model.DealIdentifierList,"--Select--", new { @style="width:180px;"})%>
                    <%: Html.ValidationMessageFor(model => model.DealIdentifierId)%>
                </td>
                <td>
                    <%: Html.TextBoxFor(model => model.Amount, new { @style = "width:180px;", @onkeypress = "return CheckFareNumericValue(event)"})%>
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
