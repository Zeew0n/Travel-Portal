<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<dynamic>" %>
<%@ Import Namespace="ATLTravelPortal.Helpers" %>
<%TravelSession obj = (TravelSession)Session["TravelPortalSessionInfo"]; %>
<div class="hd">
    <div class="wrap">
        <div class="tpLink">
            <font class="blueTxt">Hello
                <%if ((Request.IsAuthenticated) && (obj != null))
                  { %>
                <strong>
                    <%= Html.Encode(Page.User.Identity.Name)%>
                </strong></font>
            <br />
            <%=Html.ActionLink("Home", "Index", "Home", new { area=""},null)%>
            <span>|</span>
            <%=Html.ActionLink("Manage Profile", "UserDetails", new { Controller = "ProfileManagement", area = "Administrator", id = obj.Id })%>
            <span>|</span>
            <%: Html.ActionLink("Log Out", "LogOut", "Account", new { Controller = "Account", area = (string)null }, null )%>
            <%}
                  else
                  { %>
            <%= Html.ActionLink("Log In", "LogOn", "Account") %>
            <%} %><span>&nbsp;</span> Your IP:<%:HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"]%>
            <div class="tplinkSideImg">
                &nbsp;</div>
        </div>
        <div class="logo">
            <h1>
                Arihant Travel</h1>
            <a href="#" title="Arihant Travel">Arihant Travel</a>
        </div>
    </div>
    <div class="top-nav">
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
    </div>
</div>
<%--added by madan--%>
<%if (ViewContext.RouteData.DataTokens["area"] != null)
  {   %>
<script type="text/javascript">
	    $(function () {
        var title="<%:ViewContext.RouteData.DataTokens["area"].ToString() %>";
	        $("a[title=" + title + "]").attr('style', 'background-color: #0095da');
	    });          
</script>
<%} %>
