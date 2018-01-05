<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/BusMain.Master" Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Bus.Models.BusPNRModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Detail
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
 <div class="pageTitle">
        <h3>
            Setup <span>&nbsp;</span> Bus Itineary Detail
        </h3>
    </div>
    <div id="messageBox">
        <%:Html.Partial("Utility/VUC_Message",Model.Message) %></div>
   <%:Html.Partial("Common/VUC_Itinerary")%>
   <div class="buttonBar">
   <%if (Model.TicketStatusId == 4 || Model.TicketStatusId == 16 || Model.TicketStatusId == 19)
     { %>
            <ul class="buttons-panel">
                <li>
                    <%:Html.ActionLink("Print", "Print", new { @id = Model.BusPNRId, controller = "Itinerary", area = "Bus" }, new { @class = "linkButton" })%>
                </li>
                
            </ul><%} %>
        </div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="CssContent" runat="server">
    <link type="text/css" href="<%=Url.Content("~/Content/css/hotelAdmin.css") %>" rel="Stylesheet" />

</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
</asp:Content>
