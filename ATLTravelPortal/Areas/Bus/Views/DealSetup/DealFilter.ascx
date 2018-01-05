<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<ATLTravelPortal.Areas.Airline.Models.DealViewModel>" %>
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
                <%: Html.DropDownListFor(model => model.DealIdentifierId, Model.DealIdentifierList, "--- Select ---", new { @id = "FilterDealIdentifierId",@Style="width:180px;"})%>
                <%:Html.ValidationMessageFor(model=>model.DealIdentifierId,"*") %>
            </td>
            <td>
                Operator<br />
                <%: Html.DropDownListFor(model => model.BusOperatorId, Model.BusOperatorList, "--- Select---", new {id="FilterBusOperatorId",@Style="width:200px;" })%>
                <%: Html.ValidationMessageFor(model => model.BusOperatorId, "*")%>
            </td>
            <td>
                Category<br />
                <%: Html.DropDownListFor(model => model.BusCategoryId, Model.BusCategoryList, "--- Select---", new {id="FilterBusCategoryId",@Style="width:120px;" })%>
                <%: Html.ValidationMessageFor(model => model.BusCategoryId, "*")%>
            </td>
            <td>
                Currency<br />
                <%: Html.DropDownListFor(model => model.CurrencyId, Model.CurrencyList, "--- Select---", new  {@id="FilterCurrencyId",@Style="Width:100px;" })%>
                <%: Html.ValidationMessageFor(model => model.CurrencyId, "*")%>
                <%:Html.Hidden("source1",Model.Source) %>
            </td>
            <td>
                <br />
                <%:Html.ActionLink("New", "Create", null, new { @class = "create linkButton", @title = "New Item" })%>
            </td>
        </tr>
    </tbody>
</table>
<br />
