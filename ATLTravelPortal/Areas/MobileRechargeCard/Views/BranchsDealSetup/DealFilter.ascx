<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<ATLTravelPortal.Areas.Airline.Models.BranchDealViewModel>" %>
<table>
    <tbody>
        <tr>
            <td>
                Deal Name<br />
                <%: Html.DropDownListFor(model => model.DealMasterId, Model.DealMasterList, "--- Select---")%>
                <%: Html.ValidationMessageFor(model => model.DealMasterId, "*")%>
            </td>
            <td>
                Deal Identifier<br />
                <%: Html.DropDownListFor(model => model.DealIdentifierId, Model.DealIdentifierList, "--- Select---", new { id = "FilterDealIdentifierId", @Style = "width:150px;" })%>
                <%: Html.ValidationMessageFor(model => model.DealIdentifierId, "*")%>
            </td>
            <td>
                <br />
                <%:Html.ActionLink("New", "Create", "BranchsDealSetup",null, new { @class = "create linkButton", @title = "New Item" })%>
            </td>
        </tr>
    </tbody>
</table>
<br />
