<%@ Page Language="C#" MasterPageFile="~/Views/Shared/TravelPortalLogin.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="changePasswordTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Change Password
</asp:Content>

<asp:Content ID="changePasswordContent" ContentPlaceHolderID="MainContent" runat="server">
      <h1><strong>Arihant Holidays</strong></h1>
<div class="loginbox">
	<div class="hd">
     <h2>Reset Password</h2>
    </div> 
   </div>
      <div class="form-box1">
                  
        Your password has been Reset successfully.<br />
        Please remind your Password:<h4><%=TempData["Password"]%></h4>
          <p>Click here to Login to access the portal:<%=Html.ActionLink("Logon", "Logon", "Account", null, new { @class = "active" })%>
    </p>   
            
    <div class="login-copyright">
    <p>Copyright &copy; 2010 Arihant Holidays. All rights reserved.<br />Powered by Arihant Technologies Ltd.</p>
    </div> 
    
</div>
</asp:Content>
