<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<dynamic>" %>
<div id="session-expire-dialog" style="display:none">
	<h3>Your Session has been expire.</h3>
	<p>You have been logged out of the system due to inactivity.  
	Please  <%= Html.ActionLink("Log In", "LogOn", "Account") %> again.</p>
</div>