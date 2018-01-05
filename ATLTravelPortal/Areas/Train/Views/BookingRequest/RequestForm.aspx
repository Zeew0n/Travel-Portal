<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/TicketPrint.Master"
 Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Train.Models.TrainPNRModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
Request Form
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
      <%if (ViewData["isEmailSent"] != null)
      {%>
    <div style="color:Green;">
        <%:ViewData["isEmailSent"]%></div>
    <% } %>
    <%Html.RenderPartial("VUC_RequestForm",Model); %>
  
     <% using (Html.BeginForm())
        {%>
    <div id="emailTextBox" style="width: 720px; margin: 0px auto 20px;" class="printdivhideshow">
        <%: Html.LabelFor(model => model.txtEmailTo)%>
        <%: Html.TextBoxFor(model => model.txtEmailTo)%>
        <%: Html.ValidationMessageFor(model => model.txtEmailTo)%>
        <input id="btnSendEmail" type="submit" value="Send Email" onclick="Process(<%=Model.TrainPNRId %>)" />
    </div>
     <%} %>
     <input type="button" value="Print" id="btnPrintTicket" onclick="window.print()" />
       <div style="margin-right" >
                  <input type="button" onclick="document.location.href='/Train/BookingRequest/'" value="Back to List" />
               
           </div>
</asp:Content>

