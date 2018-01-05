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
            <%=Html.ActionLink("Home", "Index", "CRMDashboard", new { area = "" }, null)%>
            <span>|</span>
            <%--<%=Html.ActionLink("Manage Profile", "UserDetails", new { Controller = "ProfileManagement", area = "Administrator", id = obj.Id })%>
           <span>|</span>--%>
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

    <div id="smoothmenu1" class="top-nav ddsmoothmenu">
        <ul>
            <li><a href="#">System Setup</a>
                <ul>
                    <li>
                       <%=Html.ActionLink("Customers", "Index", "Customers", new { area = "Administrator" }, null)%>
                    </li>
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