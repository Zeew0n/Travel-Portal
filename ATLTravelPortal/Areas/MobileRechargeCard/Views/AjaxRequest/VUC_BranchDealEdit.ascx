<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<ATLTravelPortal.Areas.Airline.Models.BranchDealViewModel>" %>
<%int counterIndex = Model.DealId; %>
<% using (Html.BeginForm("Index", "BranchDealSetup", FormMethod.Post, new { @id = "myUpdateForm" + counterIndex, @name = "myUpdateForm" + counterIndex }))
   { %>
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
        Html.HiddenFor(model => model.DealId, new { @id ="editDealId" })               
                %>
                <%:Html.HiddenFor(model=>model.DealMasterId) %>
                <%: Html.DropDownListFor(model => model.DealIdentifierId, Model.DealIdentifierList, new { @style="width:200px;"})%>
                <%: Html.ValidationMessageFor(model => model.BusOperatorId)%>
            </td>
            <td>
                <%: Html.TextBoxFor(model=>model.Amount, new { id="editAmount_"+counterIndex,@style ="width:200px;", 
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
