<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<%@ Import Namespace="ATLTravelPortal.Helpers" %>
<%TravelSession obj = (TravelSession)Session["TravelPortalSessionInfo"]; %>
<%  ATLTravelPortal.Areas.Airline.Repository.IndianLccAirOfflineBookProvider ser = new ATLTravelPortal.Areas.Airline.Repository.IndianLccAirOfflineBookProvider(); %>
<div class="applemenu">
    <%if (Page.User.Identity.IsAuthenticated)
      {%>
    <div class="silverheader">
        <a href="#">Setup</a></div>
    <div class="submenu">
        <ul>
            <%--<li><%=Html.ActionLink("Deal Setup", "Index", "MasterDealSetUp")%></li>--%>
            <li>
                <%=Html.ActionLink("Deal Setup", "Index", "DealSetup", new  {Source=1 },null)%></li>
            <li>
                <%=Html.ActionLink("Upload Paper Fare", "Index", "PaperFareUpload")%></li>
            <%--<li><%=Html.ActionLink("Capping Management", "Index", "AirlineCapping")%></li>--%>
            <li>
                <%=Html.ActionLink("Agent Class Definition", "Index", "AgentClasses")%></li>
            <li>
                <%= Html.ActionLink("Airline Information", "Index", "AirLine")%></li>
            <li>
                <%=Html.ActionLink("Airport Information", "Index", "AirLineCity")%></li>
            <%--<li><%= Html.ActionLink("Airline Order", "Index", "AirlineOrder")%></li>--%>
            <li>
                <%= Html.ActionLink("Online Airlines", "Index", "OnLineAirlineSettings")%></li>
            <%-- <li>
                        <%=Html.ActionLink("Special Fare", "Index", "SpecialFares")%></li>--%>
            <%--<li><%= Html.ActionLink("Domestic Flight Class", "Index", "DomesticFlightClass")%></li>--%>
            <%-- <li>
                        <%= Html.ActionLink("Airline Group", "Index", "AirlineGroup")%></li>--%>
            <%--<li> <%=Html.ActionLink("Domestic Airline Schedule", "Index", "AirLineSchedule")%></li>--%>
            <%--<li><%=Html.ActionLink("Domestic Fare Settings", "Index", "TravelFare")%></li>--%>
            <%-- <li><%:Html.ActionLink("Promotional Fare Setup","Index","PromotionalFareSetup") %></li>--%>
            <li>
                <%=Html.ActionLink("Promotional Fare","Index","PromotionalFare") %></li>
            <li>
                <%:Html.ActionLink("AirArabia Fare Notification", "Create", "FlightFareInformation")%></li>
        </ul>
    </div>
    <div class="silverheader">
        <a href="#">Reports</a></div>
    <div class="submenu">
        <ul>
            <li>
                <%=Html.ActionLink("GDS Hits", "Index", "GDSHits")%></li>
            <li>
                <%=Html.ActionLink("Sales", "Index", "SalesReport")%></li>
            <li>
                <%=Html.ActionLink("Segment Sales", "Index", "SectorSalesReport")%></li>
            <li>
                <%=Html.ActionLink("Booked Tickets", "Index", "BookedTicketReport")%></li>
            <li>
                <%=Html.ActionLink("Pending-Booking", "Index", "PendingBooking")%></li>
            <li>
                <%=Html.ActionLink("Cancelled/Void Tickets", "Index", "CancelledVoidTicket")%></li>
            <li>
                <%=Html.ActionLink("Issued Tickets", "Index", "IssuedTicket")%></li>
            <li>
                <%=Html.ActionLink("Sector Sales", "Index", "SectorSales")%></li>
            <li>
                <%=Html.ActionLink("Agent Activity", "Index", "AgentActivities")%></li>
            <li>
                <%=Html.ActionLink("Retrieve PNR", "Index", "ReportAirRetrievePNRInfo")%></li>
            <li>
                <%=Html.ActionLink("Capping Info (Abacus)", "Index", "TicketCapping")%></li>
            <li>
                <%=Html.ActionLink("Segment Count", "Index", "SegmentCountReport")%></li>
            <li>
                <%=Html.ActionLink("Purchase Sales Report", "Index", "PurchaseSalesReport")%></li>
            <li>
                <%=Html.ActionLink("Purchase Sales Report Of ME's", "Index", "PurchaseSalesReportOfME")%></li>
        </ul>
    </div>
    <div class="silverheader">
        <a href="#">Settings</a></div>
    <div class="submenu">
        <ul>
            <li>
                <%=Html.ActionLink("Configuration", "Create", "AdminConfiguration")%></li>
            <li>
                <%=Html.ActionLink("FAQ Heading", "Index", "FaqHeading")%></li>
            <li>
                <%=Html.ActionLink("FAQ Content", "Index", "FaqContent")%></li>
            <li>
                <%=Html.ActionLink("Info Pages", "Index", "InfoPages")%></li>
        </ul>
    </div>
    <% int counts = ser.GetRowCount(); %>
    <div class="silverheader">
        <a href="#">Ticket Management</a></div>
    <div class="submenu">
        <ul>
            <li>
                <%=Html.ActionLink("Wait List Request", "Index", "WaitListRequest")%></li>
            <li>
                <%=Html.ActionLink("Void PNR Request", "Index", "VoidRequest")%></li>
            <li>
                <%=Html.ActionLink("Cancel PNR Request", "Index", "CancelRequest")%></li>
            <li>
                <%=Html.ActionLink("Group Booking Report", "Index", "GroupBookingReport")%></li>
            <li>
                <%=Html.ActionLink("Retrieve PNR", "Index", "PNRs")%></li>
            <li>
                <%=Html.ActionLink("Agency PNR Transfer", "Index", "AgencyPNRTransfer")%></li>
            <%-- <li><%=Html.ActionLink("Promotional Fare","Index","PromotionalFare") %></li>--%>
            <li>
                <%=Html.ActionLink("Offline Booking Process" + "(" + counts + ")", "Index", "AirOfflineBook")%></li>
        </ul>
    </div>
    <div class="silverheader">
        <a href="#">Package Management</a></div>
    <div class="submenu">
        <ul>
            <li>
                <%=Html.ActionLink("Package Group", "Index", "AirPackageGroup")%></li>
            <li>
                <%=Html.ActionLink("Package", "Index", "AirPackage")%></li>
            <li>
                <%=Html.ActionLink("Package Inquiry", "Index", "AirPackageInquiry")%></li>
            <li>
                <%=Html.ActionLink("Custom Package Inquiry", "Index", "AirPackageCustomizeInquiry")%></li>
            <%--<li><%=Html.ActionLink("Tags", "Index", "Tags")%></li>  --%>
        </ul>
    </div>
    <div class="silverheader">
        <a href="#">Flight Inquiry Mgmt</a></div>
    <div class="submenu">
        <ul>
            <li>
                <%=Html.ActionLink("Flight Inquiry", "Index", "FlightInquiry")%></li>
        </ul>
    </div>
    <%
         
                          int count = ser.GetIndianLccRowCount();
    %>
    <div class="silverheader">
        <a href="#">IndianLcc</a></div>
    <div class="submenu">
        <ul>
            <li>
                <%=Html.ActionLink(" Deal Setup", "Index", "DealSetup", new  {Source=5 },null)%></li>
            <li>
                <%=Html.ActionLink(" Offline Airlines", "Index", "AirOfflineSetting")%></li>
            <li>
                <%=Html.ActionLink("Manage Offline Issue Source", "Index", "OfflineIssueSource")%></li>
            <li>
                <%=Html.ActionLink(" Offline Booking Process" +  "(" + count +")", "Index", "IndianLccAirOfflineBook")%></li>
            <li>
                <div class="silverheader" style="padding: 0px 0px 0px 10px;">
                    <a href="#" style="background: none; color: #000; padding: 0px;">Reports</a></div>
                <div class="submenu" style="padding: 0px 0px 0px 10px;">
                    <ul>
                        <li>
                            <%=Html.ActionLink("Issued Tickets", "Index", "IndianLccIssuedTicket")%></li>
                        <li>
                            <%=Html.ActionLink("Sales", "Index", "IndianLccSalesReport")%></li>
                    </ul>
                </div>
            </li>
        </ul>
    </div>
    <%} %>
</div>
