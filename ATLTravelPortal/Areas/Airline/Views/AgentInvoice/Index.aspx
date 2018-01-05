<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/TicketPrint.Master"
    Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Airline.Models.InvoiceViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Invoice
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <%ATLTravelPortal.Areas.Airline.Repository.InvoiceDetailProvider ser = new ATLTravelPortal.Areas.Airline.Repository.InvoiceDetailProvider(); %>
    <%if (ViewData["isEmailSent"] != null)
      {%>
    <div>
        <%:ViewData["isEmailSent"]%>
    </div>
    <% } %>
    <% using (Html.BeginForm())
       { %>
    <%
           long MPNRId = ser.GetMPNRIdFromPNRId(Model.PNRDetails.FirstOrDefault().PNRId);
           if (Model != null)
               foreach (var pnrdetail in Model.PNRDetails)
               {
                
             
    %>
    <% Html.RenderPartial("InvoicePartial", pnrdetail); %>
    <% } %>
    <div id="emailTextBox" style="width: 720px; margin: 0px auto 20px;" class="printdivhideshow">
        <%: Html.LabelFor(model => model.Email)%>
        <%: Html.TextBoxFor(model => model.Email, new { @style = "width:200px;" })%>
        <%: Html.ValidationMessageFor(model => model.Email)%>
        <input id="btnSendEmail" type="submit" value="Send Email" />
        <input type="button" value="Print" id="btnPrintTicket" onclick="window.print()" style="float: right;" />
    </div>
    <% }
           
    %>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CssContent" runat="server">
    <style type="text/css">
        @media screen
        {
            .printdivhideshow
            {
                display: block;
            }
        }
        @media print
        {
            .printdivhideshow
            {
                display: none;
            }
        }
    </style>
</asp:Content>
