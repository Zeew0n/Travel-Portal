<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<dynamic>" %>
<%@ Import Namespace="ATLTravelPortal.Helpers" %>
<%TravelSession obj = (TravelSession)Session["TravelPortalSessionInfo"]; %>
<div class="hd">
    <div class="wrap">
        <div class="tpLink">
            <p class="blueTxt">
                Welcome, Branch Office Management!&nbsp; <span style="color: #fff; font-weight: bold;">
                    Hello
                    <%if ((Request.IsAuthenticated) && (obj != null))
                      { %>
                    <strong>
                        <%= Html.Encode(Page.User.Identity.Name)%>
                    </strong></span>
            </p>
            <%=Html.ActionLink("Home", "Index", "DistributorDashboard", new { area = "" }, null)%>
            <span>|</span>
            <%=Html.ActionLink("Manage Profile", "UserDetails", new { Controller = "ProfileManagement", area = "Administrator", id = obj.Id })%>
            <%-- <a href="#">Manage Profile</a>--%>
            <span>|</span>
            <%: Html.ActionLink("Log Out", "LogOut", "Account", new { Controller = "Account", area = (string)null }, null )%>
            <%}
                      else
                      { %>
            <%= Html.ActionLink("Log In", "LogOn", "Account") %>
            <%} %><span>&nbsp;</span> Your IP:<%:HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"]%>
        </div>
        <div class="logo">
            <h1>
                Arihant Travel</h1>
            <a href="#" title="Arihant Travel">Arihant Travel</a>
        </div>
        <div class="balanceWrap">
            <%Html.RenderAction("AvailableBalanceHeader", "Page", new { Controller = "Page", area = (string)null });%>
        </div>
    </div>
    <%--<div class="top-nav">
        <ul>
            <li>
                <%=Html.ActionLink("Administrators", "Index", new { Controller = "Dashboard", area = "Administrator" }, new { @title = "Administrator", @class = "active" })%></li>
            <li>
                <%=Html.ActionLink("Airline", "Index", new { Controller = "Dashboard", area = "Airline" }, new { @title = "Airline", @class = "active" })%></li>
            <li>
                <%=Html.ActionLink("Bus", "Index", new { Controller = "Dashboard", area = "Bus" }, new { @title = "Bus", @class = "active" })%></li>
            <li>
                <%=Html.ActionLink("Train", "Index", new { Controller = "Dashboard", area = "Train" }, new { @title = "Train", @class = "active" })%></li>
            <li>
                <%=Html.ActionLink("Hotel", "Index", new { Controller = "Dashboard", area = "Hotel" }, new { @title = "Hotel", @class = "active" })%></li>
            <li>
                <%=Html.ActionLink("Mobile Recharge", "Index", new { Controller = "Dashboard", area = "MobileRechargeCard" }, new { @title = "MobileRechargeCard", @class = "active" })%></li>
        </ul>
    </div>--%>
    <%--/**********************************************************************************/--%>
    <div id="smoothmenu1" class="ddsmoothmenu">
        <ul>
            <li><a href="#">System Setup</a>
                <ul>
                    <li>
                        <%=Html.ActionLink("Distributor Management", "Index", "BranchDistributorManagement", new { area = "Administrator" }, null)%>
                    </li>
                    <li>
                        <%=Html.ActionLink("Settings", "Index", "BranchSettings", new  { area="Administrator"},null)%>
                    </li>
                </ul>
            </li>
            <li><a href="#">Account Management</a>
                <ul>
                    <li>
                        <%=Html.ActionLink("Credit Limit Management", "Index", "BranchOfficeCreditLimit", new { area = "Administrator" }, null)%>
                    </li>
                    <li>
                        <%=Html.ActionLink("Deposit Update", "Index", "BranchDistributorPayment", new { area = "Administrator" }, null)%>
                    </li>
                    <li>
                        <%=Html.ActionLink("My Transaction", "Index", "BranchOfficeLedger", new { area = "Administrator" }, null)%></li>
                    <li>
                        <%=Html.ActionLink("Distributor Transaction", "Index", "BranchOfficeDistLedger", new { area = "Administrator" }, null)%></li>
                </ul>
            </li>
            <li><a href="#">Airline</a>
                <ul>
                    <li>
                        <%=Html.ActionLink("Deal Setup", "Index", "BranchDealSetup", new { area = "Airline" }, null)%>
                    </li>
                    <li>
                        <%=Html.ActionLink("Sales", "Index", "BranchOfficeSalesReport", new {area="Airline" }, null)%></li>
                    <li>
                        <%=Html.ActionLink("Booked Tickets", "Index", "BranchOfficeBookedTicketReport", new {area="Airline" }, null)%></li>
                    <li>
                        <%=Html.ActionLink("Issued Tickets", "Index", "BranchOfficeIssuedTicket", new {area="Airline" }, null)%></li>
                    <li>
                        <%=Html.ActionLink("Pending-Booking", "Index", "BranchOfficePendingBooking", new {area="Airline" }, null)%></li>
                    <li>
                        <%=Html.ActionLink("Cancelled/Void Tickets", "Index", "BranchOfficeCancelledVoidTicket", new {area="Airline" }, null)%></li>
                </ul>
            </li>
            <li><a href="javascript:void(0);">Hotel</a>
                <ul>
                    <li>
                        <%=Html.ActionLink("Deal Setup", "Index", "HotelBranchDealSetup", new { area = "Hotel" }, null)%></li>
                    <li>
                        <%=Html.ActionLink("Booking Records", "Index", "BranchHotelBookingRecord", new { area = "Hotel" }, null)%></li>
                    <li>
                        <%=Html.ActionLink("Booking Process", "Index", "BranchOfficeHotelBookingProcess", new { area = "Hotel" }, null)%></li>
                    <li>
                        <%=Html.ActionLink("Pending Cancellation", "PendingCancellationList", "BranchOfficeHotelBookingProcess", new { area = "Hotel" }, null)%></li>
                    <li>
                        <%=Html.ActionLink("Cancelled", "CancellationList", "BranchHotelBookingRecord", new { area = "Hotel" }, null)%></li>
                </ul>
            </li>
            <li><a href="javascript:void(0);">Bus</a>
                <ul>
                    <li>
                        <%=Html.ActionLink("Deal Setup", "Index", "BranchDealSetup", new { area = "Bus" }, null)%></li>
                    <li>
                        <%=Html.ActionLink("Pending Bookings", "Index", "BranchBookedTicket", new { area = "Bus" }, null)%></li>
                    <li>
                        <%=Html.ActionLink("Issued Tickets", "Index", "BranchIssuedTicket", new { area = "Bus" }, null)%></li>
                </ul>
            </li>
            <li><a href="javascript:void(0);">Train</a>
                <ul>
                    <li>
                        <%=Html.ActionLink("Pending Bookings", "Index", "BranchBookingRequest", new { area = "Train" }, null)%></li>
                    <li>
                        <%=Html.ActionLink("Booking in Progress", "Process", "BranchBookingRequest", new { area = "Train" }, null)%></li>
                    <li>
                        <%=Html.ActionLink("Issued Tickets", "Issued", "BranchBookingRequest", new { area = "Train" }, null)%></li>
                    <li>
                        <%=Html.ActionLink("Cancelled Request", "Canceled", "BranchBookingRequest", new { area = "Train" }, null)%></li>
                </ul>
            </li>
            <li><a href="javascript:void(0);">Mobile</a>
                <ul>
                    <li>
                        <%=Html.ActionLink("Deal Setup", "Index", "BranchsDealSetup", new { area = "MobileRechargeCard" }, null)%></li>
                    <li>
                        <%=Html.ActionLink("Topup Details", "Index", "BranchTopUp", new { area = "MobileRechargeCard" }, null)%></li>
                </ul>
            </li>
            <%--            <li><a href="#">Reports</a>
                <ul class="report">
                    <li>
                        <%=Html.ActionLink("Sales", "Index", new { Controller = "AgentSalesReport", area = "Airline" })%></li>
                    <li>
                        <%=Html.ActionLink("Segment Count", "Index", new { Controller = "AgentSectorSalesReport", area = "Airline" })%></li>
                    <li><a href="#">Account Statement<img style="border: 0;" class="rightarrowclass"
                        src="../../../Content/icons/right.gif" alt="" /></a>
                        <ul class="inner-menu">
                            <li>
                                <%=Html.ActionLink("Agency Statement", "Index", new { Controller = "InvoiceReport", area = "Airline" })%></li>
                            <li>
                                <%=Html.ActionLink("Passenger Statement", "Index", new { Controller = "PassengerInvoiceReport", area = "Airline" })%></li>
                        </ul>
                    </li>
                </ul>
            </li>--%>
        </ul>
    </div>
</div>
