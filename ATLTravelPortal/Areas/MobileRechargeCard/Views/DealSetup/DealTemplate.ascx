<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<ATLTravelPortal.Areas.Airline.Models.DealViewModel>" %>
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
                <%:Html.DropDownListFor(model => Model.DealIdentifierId, Model.DealIdentifierList, new {  @style="width:200px;" })%>
                <%:Html.HiddenFor(model => model.DealIdentifierText)%>
            </td>
            <td style="width: 50px;">
                <%:Html.TextBoxFor(model => model.AdultBFCommission, new { @style = "width:200px;" })%>
            </td>
            <td>
                <%:Html.CheckBoxFor(model=>model.isBFCommissionPercentage) %><br />
            </td>
        </tr>
    </tbody>
</table>
