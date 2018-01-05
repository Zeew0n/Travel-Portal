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
                Hotel Filter<br />
                <%: Html.TextBoxFor(model => model.HotelName, new { @class = "ui-autocomplete-input requiredField", @id = "FilterHotelName" })%>
                <%: Html.ValidationMessageFor(model => model.HotelName, "*")%>
                <%:Html.HiddenFor(model => model.HotelId, new { @id = "FilterHotelId" })%>
            </td>
            <td>
                <br />
                <%:Html.ActionLink("New", "Create", null, new { @class = "create linkButton", @title = "New Item" })%>
            </td>
        </tr>
    </tbody>
</table>
<br />