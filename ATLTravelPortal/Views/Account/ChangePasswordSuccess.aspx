<%@ Page Language="C#" MasterPageFile="~/Views/Shared/TravelPortalLogin.Master" Inherits="System.Web.Mvc.ViewPage" %>
<%@ Import Namespace="ATLTravelPortal.Helpers" %>
<asp:Content ID="changePasswordTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Change Password
</asp:Content>

<asp:Content ID="changePasswordContent" ContentPlaceHolderID="MainContent" runat="server">
      <h1><strong>Arihant Holidays</strong></h1>
<div class="loginbox">
	<div class="hd">
     <h2>Change Password</h2>
    </div> 
   </div>
   <%TravelSession obj = (TravelSession)Session["TravelPortalSessionInfo"]; %>
      <div class="form-box1">
                    <p>
        Your password has been changed successfully.</br>
       <%if ((obj.UserTypeId == (int)ATLTravelPortal.Helpers.UserTypes.SuperUser) || (obj.UserTypeId == (int)ATLTravelPortal.Helpers.UserTypes.User))
         { %> 
        Return To DashBoard:<%=Html.ActionLink("Dashboard", "Dashboard", "Dashboard", null, new { @class = "active" })%>
        <%}
         else
         { %>
          Return To DashBoard:<%=Html.ActionLink("Dashboard", "Index", "Dashboard", null, new { @class = "active" })%>
        <%} %>
    </p>   
            
    <div class="login-copyright">
    <p>Copyright &copy; 2010 Arihant Holidays. All rights reserved.<br />Powered by Arihant Technologies Ltd.</p>
    </div> 
    
</div>
</asp:Content>
