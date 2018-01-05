<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/TicketPrint.Master"
 Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Train.Models.TrainPNRModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
Request Form
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
    
    <%Html.RenderPartial("VUC_RequestForm",Model); %>
  
    
       <input type="button" value="Print" id="btnPrintTicket" onclick="window.print()" />
       <div style="margin-right" >
                  <input type="button" onclick="document.location.href='/Train/BookingRequest/Process'" value="Back to List" />
               
           </div>

         
</asp:Content>

