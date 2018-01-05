<%@ Page Language="C#" MasterPageFile="~/Views/Shared/TravelPortalLogin.Master" Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Models.ChangePasswordModel>" %>

<asp:Content ID="changePasswordTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Change Password
</asp:Content>

<asp:Content ID="changePasswordContent" ContentPlaceHolderID="MainContent" runat="server">
      <h1><strong>Arihant Holidays</strong></h1>
<div class="loginbox">
	<div class="hd">
    <h2>Change Password</h2>
     
    </div> 
    <p>
        Use the form below to change your password. 
    </p>
     New passwords are required to be a minimum of <%: ViewData["PasswordLength"] %> characters in length.
                 
                        </div>
          <% Html.EnableClientValidation(); %>
     <% using (Html.BeginForm()) { %>
        <%: Html.ValidationSummary(true, "Password change was unsuccessful. Please correct the errors and try again.") %>
  
      <div class="form-box1">
                       <div class="form-box1-row-content">                           
                             <div><label><%: Html.LabelFor(m => m.OldPassword)%></label> 
                                         <%: Html.TextBoxFor(m => m.OldPassword)%>
                                         <%: Html.ValidationMessageFor(m => m.OldPassword)%> 
                            </div>                           
                        </div>
                    
                        <div class="form-box1-row-content">                           
                                <div><label><%: Html.LabelFor(m => m.NewPassword)%></label>  
                                            <%: Html.PasswordFor(m => m.NewPassword)%>
                                            <%: Html.ValidationMessageFor(m => m.NewPassword)%>
                                </div>                           
                        </div>
                         <div class="form-box1-row-content">                           
                                <div><label><%: Html.LabelFor(m => m.ConfirmPassword)%></label>  
                                            <%: Html.PasswordFor(m => m.ConfirmPassword)%>
                                            <%: Html.ValidationMessageFor(m => m.ConfirmPassword)%>
                                </div>                           
                        </div>
                       
                             
                    <div class="form-box1-row">
                        <p> <input type="submit" value="Login" class="btn1" /> </p>                        
                    </div>
                 <% } %>

    <div class="login-copyright">
    <p>Copyright &copy; 2010 Arihant Holidays. All rights reserved.<br />Powered by Arihant Technologies Ltd.</p>
    </div> 
    
</div>

</asp:Content>
