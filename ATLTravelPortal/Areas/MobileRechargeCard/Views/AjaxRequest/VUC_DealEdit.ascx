<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<ATLTravelPortal.Areas.Airline.Models.DealViewModel>" %>
<%int counterIndex = Model.DealId; %>
<% using (Html.BeginForm("Index", "DealSetup", FormMethod.Post, new { @id = "myUpdateForm" + counterIndex, @name = "myUpdateForm" + counterIndex }))
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
                <%:Html.HiddenFor(model=>model.DealMasterId) %>
                <%:Html.DropDownListFor(model => Model.DealIdentifierId, Model.DealIdentifierList, new { @id = "editDealIdentifierId", @style="width:90px;" })%>
                <%:Html.HiddenFor(model => model.DealIdentifierText, new { @id = "editDealIdentifierText" })%>
                <%:Html.HiddenFor(model => model.DealId, new { @id ="editDealId" })%>
            </td>
            <td style="width: 50px;">
                <%:Html.TextBoxFor(model => model.AdultBFCommission, new { @style = "width:200px;" })%>
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
