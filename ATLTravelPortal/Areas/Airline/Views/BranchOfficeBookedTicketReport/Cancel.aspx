<%@ Page Title="" Language="C#" MasterPageFile="../../../../Views/Shared/TicketPrint.Master"
    Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Airline.Models.PNRsDetailsModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div style="width: 1004px; margin: 20px auto 0px;">
        <% Html.RenderPartial("VUC_PNR", Model);%>
        
        <% Html.EnableClientValidation(); %>
        <% using (Html.BeginForm())
           {%>
        <input class="float-right" type="submit" value="Cancel" />
        <%} %>
        
    </div>
</asp:Content>
