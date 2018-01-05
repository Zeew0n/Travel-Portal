<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<ATLTravelPortal.Areas.Hotel.Models.HotelDealViewModel>" %>
<table>
    <tbody>
        <tr>
            <td>
                Deal Name<br />
                <%: Html.DropDownListFor(model => model.DealMasterId, Model.DealMasterList, "--- Select---", new { @id = "filterDealMasterId", @style = "width:100px;" })%>
                <%: Html.ValidationMessageFor(model => model.DealMasterId, "*")%>
            </td>
            <td>
                Deal Identifier<br />
                <%: Html.DropDownListFor(model => model.DealIdentifier, Model.DealIdentifierList, "--- Select ---", new { @id = "filterDealIdentifier", @style = "width:100px;" })%>
                <%:Html.ValidationMessageFor(model => model.DealIdentifier, "*")%>
            </td>
            <td>
                Hotel<br />
                <%: Html.DropDownListFor(model => model.HotelId, Model.HotelList, "--- Select---", new { @id = "filterHotelId", @style = "width:100px;" })%>
                <%: Html.ValidationMessageFor(model => model.HotelId, "*")%>
            </td>
            <td>
                Currency<br />
                <%: Html.DropDownListFor(model => model.CurrencyId, Model.CurrencyList, "--- Select---", new { @id = "filterCurrencyId", @style = "width:75px;" })%>
                <%: Html.ValidationMessageFor(model => model.CurrencyId, "*")%>
            </td>
            <td>
                <br />
                <%:Html.ActionLink("New","Create",null,new {@class="create linkButton", @title="New Item"}) %>
            </td>
        </tr>
    </tbody>
</table>
<br />
