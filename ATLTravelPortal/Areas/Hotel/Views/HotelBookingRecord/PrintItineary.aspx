<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/TicketPrint.Master" Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Hotel.Models.HotelItinearyModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	PrintItineary
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

  <%if (Model.Message.MsgNumber == 1)
       { %>
    <div class="printOption printButton">
       <a href="javascript:window.print()">PRINT</a>
    </div>
    <div class="print">
        <%:Html.Partial("Common/VUC_Itinerary")%>
    </div>
    <div class="printOption printButton">
        <a href="javascript:window.print()">PRINT</a>
    </div>
          
    <%}
      else
      { %>
    <%:Html.Partial("Utility/VUC_Message",Model.Message) %>
    <%} %>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="CssContent" runat="server">
  <style type="text/css">
        @media screen
        {
            .print
            {
                width: 800px;
            }
            .printOption
            {
                display: block;
            }
             .printButton
            {
                border: 1px solid #000000;
                font-size: 20px;
                font-weight: bold;
                height: 30px;
                line-height: 30px;
                margin-top: 10px;
                margin-bottom:10px;
                text-align: center;
                width: 800px;
            }
        }
        @media print
        {
            .print
            {
            }
            .printOption
            {
                display: none;
            }
             
        }
    </style>
</asp:Content>
