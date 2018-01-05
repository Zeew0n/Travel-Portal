<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<dynamic>" %>
<%@ Import Namespace="ATLTravelPortal.Helpers" %>
<%TravelSession obj = (TravelSession)Session["TravelPortalSessionInfo"]; %>
<div class="hd">
    <div class="wrap">
        <div class="tpLink">
            <font class="blueTxt">Welcome, Distributor!&nbsp;Hello
                <%if ((Request.IsAuthenticated) && (obj != null))
                  { %>
                <strong>
                    <%= Html.Encode(Page.User.Identity.Name)%>
                </strong></font>
            <br />
            <%=Html.ActionLink("Home", "Index", "DistributorDashboard", new { area = "" }, null)%>
            <span>|</span>
            <%=Html.ActionLink("Manage Profile", "UserDetails", new { Controller = "ProfileManagement", area = "Administrator", id = obj.Id })%>
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
            <%Html.RenderAction("AvailableBalanceHeaderDistributor", "Page", new { Controller = "Page", area = (string)null });%>
        </div>
    </div>
    <div id="smoothmenu1" class="top-nav ddsmoothmenu">
        <ul>
            <li><a href="#">System Setup</a>
                <ul>
                    <li>
                        <%=Html.ActionLink("Agents", "Index", "DistributorAgentManagement", new  { area="Administrator"},null)%>
                    </li>
                    <li>
                        <%=Html.ActionLink("Settings", "Index", "DistributorSettings", new  { area="Administrator"},null)%>
                    </li>
                    <li>
                        <%=Html.ActionLink("Agent Class Deal", "Index", "DistributorClassDeal", new  { area="Administrator"},null)%>
                    </li>
                    <li>
                        <%=Html.ActionLink("Configuration", "Index", "DistributorConfiguration", new  { area="Administrator"},null)%>
                    </li>
                </ul>
            </li>
            <li><a href="#">Account Management</a>
                <ul>
                    <li>
                        <%=Html.ActionLink("Credit Limit", "Index", "DistributorCreditLimit", new  { area="Administrator"},null)%>
                    </li>
                    <li>
                        <%=Html.ActionLink("Make Payment", "Index", "DistributorMakePayment", new { area = "Administrator" }, null)%>
                    </li>
                    <li>
                        <%=Html.ActionLink("Deposit Update", "Index", "DistributorAgentPayment", new { area = "Administrator" }, null)%>
                    </li>
                    <li>
                        <%=Html.ActionLink("My Transaction", "Index", "DistributorLedger", new { area = "Administrator" }, null)%></li>
                    <li>
                        <%=Html.ActionLink("Agent Transaction", "Index", "DistributorAgentLedger", new { area = "Administrator" }, null)%></li>
                </ul>
            </li>
            <li><a href="javascript:void(0);">Airline</a>
                <ul>
                    <li>
                        <%=Html.ActionLink("Deal Setup", "Index", "DistributorDealSetup", new { area = "Airline" }, null)%>
                    </li>
                    <li>
                        <%=Html.ActionLink("Sales", "Index", "DistributorSalesReport", new  {area="Airline" },null)%></li>
                    <li>
                        <%=Html.ActionLink("Booked Tickets", "Index", "DistributorBookedTicketReport", new { area = "Airline" },null)%></li>
                    <li>
                        <%=Html.ActionLink("Issued Tickets", "Index", "DistributorIssuedTicket", new { area = "Airline" },null)%></li>
                    <li>
                        <%=Html.ActionLink("Pending-Booking", "Index", "DistributorPendingBooking", new { area = "Airline" },null)%></li>
                    <li>
                        <%=Html.ActionLink("Cancelled/Void Tickets", "Index", "DistributorCancelledVoidTicket", new { area = "Airline" },null)%></li>
                    <li>
                        <%=Html.ActionLink("Agent Credit Limit Approval", "Index", "AgentCLApprove", new { area="Administrator"},null)%></li>
                </ul>
            </li>
            <li><a href="javascript:void(0);">Hotel</a>
                <ul>
                    <li>
                        <%=Html.ActionLink("Deal Setup", "Index", "HotelDistributorDealSetup", new { area = "Hotel" }, null)%></li>
                    <li>
                        <%=Html.ActionLink("Booking Records", "Index", "DistributorHotelBookingRecord", new { area = "Hotel" }, null)%></li>
                    <li>
                        <%=Html.ActionLink("Booking Process", "Index", "DistributorHotelBookingProcess", new { area = "Hotel" }, null)%></li>
                    <li>
                        <%=Html.ActionLink("Pending Cancellation", "PendingCancellationList", "DistributorHotelBookingProcess", new { area = "Hotel" }, null)%></li>
                    <li>
                        <%=Html.ActionLink("Cancelled", "CancellationList", "DistributorHotelBookingRecord", new { area = "Hotel" }, null)%></li>
                </ul>
            </li>
            <li><a href="javascript:void(0);">Bus</a>
                <ul>
                    <li>
                        <%=Html.ActionLink("Deal Setup", "Index", "DistributorDealSetup", new { area = "Bus" }, null)%></li>
                    <li>
                        <%=Html.ActionLink("Pending Bookings", "Index", "DistributorBookedTicket", new { area = "Bus" }, null)%></li>
                    <li>
                        <%=Html.ActionLink("Issued Tickets", "Index", "DistributorIssuedTicket", new { area = "Bus" }, null)%></li>
                </ul>
            </li>
            <li><a href="javascript:void(0);">Train</a>
                <ul>
                    <li>
                        <%=Html.ActionLink("Pending Bookings", "Index", "DistributorBookingRequest", new { area = "Train" }, null)%></li>
                    <li>
                        <%=Html.ActionLink("Booking in Progress", "Process", "DistributorBookingRequest", new { area = "Train" }, null)%></li>
                    <li>
                        <%=Html.ActionLink("Issued Tickets", "Issued", "DistributorBookingRequest", new { area = "Train" }, null)%></li>
                    <li>
                        <%=Html.ActionLink("Cancelled Request", "Canceled", "DistributorBookingRequest", new { area = "Train" }, null)%></li>
                </ul>
            </li>
            <li><a href="javascript:void(0);">Mobile</a>
                <ul>
                    <li>
                        <%=Html.ActionLink("Deal Setup", "Index", "DistributorsDealSetup", new { area = "MobileRechargeCard" }, null)%></li>
                    <li>
                        <%=Html.ActionLink("Topup Details", "Index", "DistributorTopUp", new { area = "MobileRechargeCard" }, null)%></li>
                </ul>
            </li>
        </ul>
        <br style="clear: left" />
    </div>
</div>
<%if (ViewContext.RouteData.DataTokens["area"] != null)
  {   %>
<script type="text/javascript">
	    $(function () {
        var title="<%:ViewContext.RouteData.DataTokens["area"].ToString() %>";
	        $("a[title=" + title + "]").attr('style', 'background-color: #0089cb');
	    });          
</script>
<%} %>
