<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<dynamic>" %>

<div id="access-denied-dialog" style="display:none">
<h3>You are not authorized to View this page.</h3>
<p align="center"><img src="<%=Url.Content("~/Content/images/Accessdenied.jpg")%>" width="280px" height="280px"/></p>
</div>