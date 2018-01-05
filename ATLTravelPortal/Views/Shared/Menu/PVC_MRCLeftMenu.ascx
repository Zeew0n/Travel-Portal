<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<dynamic>" %>
<%@ Import Namespace="ATLTravelPortal.Helpers" %>
<%TravelSession obj = (TravelSession)Session["TravelPortalSessionInfo"]; %>
<div class="applemenu">
    <%if (Page.User.Identity.IsAuthenticated)
      {%>
    <div class="silverheader">
        <a href="#">Setup</a></div>
    <div class="submenu">
        <ul>
            <li>
                <%= Html.ActionLink("Deal Setup", "Index", new {controller =  "DealSetup", area = "MobileRechargeCard" })%></li>
            <li>
                <%:Html.ActionLink("Card Value ", "Index", new {controller = "CardValue", area = "MobileRechargeCard" })%></li>
        </ul>
    </div>
    <div class="silverheader">
        <a href="#">Reports</a></div>
    <div class="submenu">
        <ul>
            <li>
                <%:Html.ActionLink("Mobile Topup", "Index", new { controller = "MobileTopup", area = "MobileRechargeCard" })%></li>
            <li>
                <%:Html.ActionLink("Topup Detail", "Index", new { controller = "TopUp", area = "MobileRechargeCard" })%></li>
            <li>
                <%:Html.ActionLink("Agent Transactions", "TranReport", new { controller = "TopUp", area = "MobileRechargeCard" })%></li>
        </ul>
    </div>
    <%} %>
</div>
