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
                Airline Filter<br />
             <%--   <%: Html.DropDownListFor(model => model.AirlineId, Model.AirlineNameList, "--- Select---", new {id="FilterAirlineId" })%>
                <%: Html.ValidationMessageFor(model => model.AirlineId, "*")%>--%>
                       
        <%: Html.TextBoxFor(model => model.AirlineName, new { @class = "ui-autocomplete-input requiredField", @id = "FilterAirlineName" })%>
        <%: Html.ValidationMessageFor(model => model.AirlineName, "*")%>      
        <%:Html.HiddenFor(model => model.AirlineId, new { @id = "FilterAirlineId" })%>  

            </td>
          
            <td><br /><%:Html.ActionLink("New", "Create", null, new { @class = "create linkButton", @title = "New Item" })%></td>
        </tr>
    </tbody>
</table>
<br />

