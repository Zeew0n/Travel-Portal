<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/AdministratorMain.Master"
    Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Administrator.Models.SalesReportModel>" %>

<%@ Import Namespace="ATLTravelPortal.Helpers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Ledger
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript">
        var siteRelativePath = "";
    </script>
    <script src="../../../../Scripts/jquery-1.4.1.min.js" type="text/javascript"></script>
    <script src="../../../../Scripts/ATL.function.js" type="text/javascript"></script>
    <link href="../../../../Content/css/buttons.css" rel="stylesheet" type="text/css" />
    <% using (Html.BeginForm())
       {%>
    <% Html.RenderPartial("~/Views/Shared/ExportData.ascx"); %>
    <h2>
         Name:<u>
         <%:Model.ReportHeading
             %></u></h2>
    <h2>
        Currency:<u>
        <%:Model.Currency%></u></h2>
    <h2>
        From Date:<u>
           <%:TimeFormat.DateFormat(Model.FromDate.ToString())%></u>
           To Date:<u>
        <%:TimeFormat.DateFormat(Model.ToDate.ToString())%></u></h2>
   
    <div class="contentGrid">
    <%if (Model.ReportType == 1)
      { %>
    <table cellspacing="0" cellpadding="0" border="0" style="border-collapse: collapse;"
            class="GridView" width="100%">
    <thead>
        <tr>
            <th>
                SN
            </th>
            <th>
                Airline
            </th>
            <th>
                MPNRID
            </th>
            <th>
                ServiceProvider Name
            </th>
            <th>
                Sector
            </th>
            <th>
                Issued Date
            </th>
            <th>
                Issued From
            </th>
            <th>
                Ticket Number
            </th>
            <th>
                Amount
            </th>

        </tr>
        <tr></tr>
</thead>
<tbody>
        <% var SN = 0;
           double? Total=0;
           foreach (var item in Model.InformationList)
           {
               SN++; %>
        <tr>
            <td>
                <%:SN%>
            </td>
            <td>
                <%:item.AirlineName%>
            </td>
            <td>
                <%:item.MpnrId%>
            </td>
            <td>
                <%:item.ServiceProviderName%>
            </td>
            <td>
                <%:item.Sector%>
            </td>
            <td>
                <%: TimeFormat.DateFormat(item.IssuedDate.ToString())%>
            </td>
            <td>
                <%:item.IssuedFrom%>
            </td>
            <td>
                <%:item.TicketNumber%>
            </td>
            <td>
                <%:item.Amount%>
                <% Total = item.Amount + Total;%>
           </td>
        </tr>
      
        <%} %>
        <tr>
        <td><b>Total Amount</b></td>
        <td></td>
        <td></td>
        <td></td>
        <td></td>
        <td></td>
        <td></td>
        <td></td>
        <td><b>
        <%: Total %></b></td>
        </tr>
  </tbody>
       
    </table>
    <%} %>
       
    
    <%if (Model.ReportType == 2)
      { %>
   <table cellspacing="0" cellpadding="0" border="0" style="border-collapse: collapse;"
            class="GridView" width="100%">
<thead>
        <tr>
            <th>
                SN
            </th>
            <th>
                Hotel Name
            </th>
            <th>
                Country Name
            </th>
            <th>
                City Name
            </th>
            <th>
                ServiceProvider Name
            </th>
            <th>
                Issued Date
            </th>
            <th>
                No Of Night
            </th>
            <th>
                No Of Room
            </th>
            <th>
                Amount
            </th>
        </tr>
        <tr></tr>
</thead>
        <% var SN = 0;
           double? Total = 0;
           foreach (var item in Model.InformationList)
           {
               SN++; %>
        <tr>
            <td>
                <%:SN%>
            </td>
            <td>
                <%:item.HotelName%>
            </td>
            <td>
                <%:item.CountryName%>
            </td>
            <td>
                <%:item.CityName%>
            </td>
            <td>
                <%:item.ServiceProviderName%>
            </td>
            <td>
                <%: TimeFormat.DateFormat(item.IssuedDate.ToString())%>
            </td>
            <td>
                <%:item.NOofNight%>
            </td>
            <td>
                <%:item.NoofRoom%>
            </td>
            <td>
                <%:item.Amount%>
                <% Total = item.Amount + Total;%>
            </td>
        </tr>
        <%} %>
         <tr>
        <td><b>Total Amount</b></td>
        <td></td>
        <td></td>
        <td></td>
        <td></td>
        <td></td>
        <td></td>
        <td></td>
        <td><b>
        <%: Total %></b></td>
        </tr>
    </table>
    <%} %>
       
   
    <%if (Model.ReportType == 3)
      { %>
  <table cellspacing="0" cellpadding="0" border="0" style="border-collapse: collapse;"
            class="GridView" width="100%">
<thead>
        <tr>
            <th>
                SN
            </th>
            <th>
                SalesTranId
            </th>
            <th>
                Service Type
            </th>
            <th>
                CustomerMobile No
            </th>
            <th>
                ServiceProvider Name
            </th>
            <th>
                Created Date
            </th>
            <th>
                Amount
            </th>
        </tr>
        <tr></tr>
</thead>
        <% var SN = 0;
           double? Total = 0;
           foreach (var item in Model.InformationList)
           {
               SN++; %>
        <tr>
            <td>
                <%:SN%>
            </td>
            <td>
                <%:item.SalesTranId%>
            </td>
            <td>
                <%:item.ServiceType%>
            </td>
            <td>
                <%:item.CustomerMobileNo%>
            </td>
            <td>
                <%:item.ServiceProviderName%>
            </td>
            <td>
                <%: TimeFormat.DateFormat(item.CreatedDate.ToString())%>
            </td>
            <td>
                <%:item.Amount%>
                <% Total = item.Amount + Total;%>
            </td>
        </tr>
        <%} %>
         <tr>
        <td><b>Total Amount</b></td>
        <td></td>
        <td></td>
        <td></td>
        <td></td>
        <td></td>
       
        <td><b>
        <%: Total %></b></td>
        </tr>
    </table>
    <%} %>
       
     <%if (Model.ReportType == 4)
      { %>
    <table cellspacing="0" cellpadding="0" border="0" style="border-collapse: collapse;"
            class="GridView" width="100%">
    <thead>
        <tr>
            <th>
                SN
            </th>
            <th>
                BusMaster Name 
            </th>
            <th>
                BusPNRID
            </th>
            <th>
                ServiceProvider Name
            </th>
            <th>
                Passenger Name
            </th>
            <th>
                Sector
            </th>
            <th>
                Issued Date
            </th>
            <th>
                Amount
            </th>

        </tr>
        <tr></tr>
</thead>
<tbody>
        <% var SN = 0;
           double? Total=0;
           foreach (var item in Model.InformationList)
           {
               SN++; %>
        <tr>
            <td>
                <%:SN%>
            </td>
            <td>
                <%:item.BusMasterName%>
            </td>
            <td>
                <%:item.BusPNRId%>
            </td>
            <td>
                <%:item.ServiceProviderName%>
            </td>
            <td>
                <%: item.PassengerName %>
            </td>
            <td>
                <%:item.Sector%>
            </td>
            <td>
                <%: TimeFormat.DateFormat(item.IssuedDate.ToString())%>
            </td>
            
            <td>
                <%:item.Amount%>
                <% Total = item.Amount + Total;%>
           </td>
        </tr>
      
        <%} %>
        <tr>
        <td><b>Total Amount</b></td>
        <td></td>
        <td></td>
        <td></td>
        <td></td>
        <td></td>
        <td></td>
        <td><b>
        <%: Total %></b></td>
        </tr>
  </tbody>
       
    </table>
    <%} %>
    <% if (Model.ReportType == 5)
       {%>
 <table cellspacing="0" cellpadding="0" border="0" style="border-collapse: collapse;"
            class="GridView" width="100%">
<thead>
        <tr>
            <th>
                SN
            </th>
            <th>
                Passenger Name
            </th>
            <th>
                Train Name
            </th>
            <th>
                Train No
            </th>
            <th>
                Sector
            </th>
            <th>
                Issued Date
            </th>
            <th>
                TrainpnrId
            </th>
            <th>
                Amount
            </th>
        </tr>
        <tr></tr>
</thead>
        <% var SN = 0;
           double? Total = 0;
           foreach (var item in Model.InformationList)
           {
               SN++; %>
        <tr>
            <td>
                <%:SN%>
            </td>
            <td>
                <%:item.PassengerName%>
            </td>
            <td>
                <%:item.TrainName%>
            </td>
            <td>
                <%:item.TrainNo%>
            </td>
            <td>
                <%:item.Sector%>
            </td>
            <td>
                <%: TimeFormat.DateFormat(item.IssuedDate.ToString())%>
            </td>
            <td>
                <%:item.TrainPNRId%>
            </td>
            <td>
                <%:item.Amount%>
                <% Total = item.Amount + Total;%>
            </td>
           
            
        </tr>
        <%} %>
         <tr>
        <td><b>Total Amount</b></td>
        <td></td>
        <td></td>
        <td></td>
        <td></td>
        <td></td>
        <td></td>
       
        <td><b>
        <%: Total %></b></td>
        </tr>
    </table>
    <%} %>
    <%} %>
    </div>
    
    
</asp:Content>
