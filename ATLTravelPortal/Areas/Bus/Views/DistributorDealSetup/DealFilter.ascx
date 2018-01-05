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
                Operator<br />
                <%: Html.DropDownListFor(model => model.BusOperatorId, Model.BusOperatorList, "--- Select---", new {id="FilterBusOperatorId" ,@Style="width:150px;"})%>
                <%: Html.ValidationMessageFor(model => model.BusOperatorId, "*")%>
            </td>
            <td>
                Category<br />
                <%: Html.DropDownListFor(model => model.BusCategoryId, Model.BusCategoryList, "--- Select---", new {id="FilterBusCategoryId",@Style="width:150px;"})%>
                <%: Html.ValidationMessageFor(model => model.BusCategoryId, "*")%>
            </td>
            <td>
                <br />
                <%:Html.ActionLink("New", "Create", null, new { @class = "create linkButton", @title = "New Item" })%>
            </td>
        </tr>
    </tbody>
</table>
<br />
