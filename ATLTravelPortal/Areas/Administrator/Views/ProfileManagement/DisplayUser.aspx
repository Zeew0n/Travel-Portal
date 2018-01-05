<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/AdministratorMain.Master" Inherits="System.Web.Mvc.ViewPage" %>
<%@ Import Namespace="ATLTravelPortal.Helpers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Display User Profile : <%=ViewData["Title"] %> 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <% TravelSession obj = (TravelSession)Session["TravelPortalSessionInfo"];%>
<% var user = ViewData["User"] as ATLTravelPortal.Areas.Administrator.Models.UserManagementModel.MembershipUserAndRolesViewData; %>
 <div class="field-validation-valid">Your changed password is  <%=TempData["Password"] %></div>
 <div class="validation-summary-errors"><%=TempData["Errormessage"] %></div>
<%   using (Html.BeginForm("SaveExistingUser", "ProfileManagement", FormMethod.Post))
     { %>



 <div class="row-1">
           		<h3>User's Login Details</h3>
            	<div class="form-box1 round-corner">
                	<div class="form-box1-row">
                        <div class="form-box1-row-content float-left">                            
                                <div>
                                    <label>User Name:<% =Html.Hidden("UserName", user.User.UserName)%></label>
                                    <% =user.User.UserName%>                                    
                                 </div>                            
                        </div>                        
                    </div>
                    <div class="form-box1-row">
                        <div class="form-box1-row-content float-left">                            
                                <div>
                                    <label>Email Address:</label>
                                    <% =Html.TextBox("Email", user.User.Email, new { size = 32, maxlength = 256 })%>                                  
                                </div>                            
                        </div>                        
                    </div>
                    <div class="form-box1-row">
                        <div class="form-box1-row-content float-left">                            
                                <div><label>Comment:</label><% =Html.TextBox("Comment", user.User.Comment, new { size = 32, maxlength = 256 })%></div>                            
                        </div>                        
                    </div>
                    <div class="form-box1-row">
                        <div class="form-box1-row-content float-left">                            
                                <div><label>Is Approved:</label><input type="checkbox" id="IsApproved" name="IsApproved" <% =user.User.IsApproved ? "checked=\"checked\"" : "" %> disabled="disabled" /></div>                            
                        </div>                      
                    </div>
                    <div class="form-box1-row">
                        <div class="form-box1-row-content float-left">                            
                                <div><label>Created:</label><% =user.User.CreationDate.ToString("M/d/yyyy h:mm:ss tt")%></div>                            
                        </div>                        
                    </div>
                    <div class="form-box1-row">
                        <div class="form-box1-row-content float-left">                            
                                <div><label>Last Login:</label><% =user.User.CreationDate != user.User.LastLoginDate ? user.User.LastLoginDate.ToString("M/d/yyyy h:mm:ss tt") : "Never Logged In"%></div>                            
                        </div>                        
                    </div>
                    <div class="form-box1-row">
                        <div class="form-box1-row-content float-left">                            
                                <div><label>Last Activity:</label><% =user.User.CreationDate != user.User.LastActivityDate ? user.User.LastActivityDate.ToString("M/d/yyyy h:mm:ss tt") : "Never Active"%> (<% =user.User.IsOnline ? "Online" : "Offline"%>)</div>                            
                        </div>                        
                    </div>
                    <div class="form-box1-row">
                        <div class="form-box1-row-content float-left">                            
                                <div><label>Last Lockout:</label><% =(user.User.LastLockoutDate == DateTime.MinValue ? user.User.LastLockoutDate.ToString("M/d/yyyy h:mm:ss tt") : "Never Locked Out")%></div>                            
                        </div>                        
                    </div>
                   <%-- <div class="form-box1-row">
                        <div class="form-box1-row-content float-left">                            
                                <div><label></label>                                 
                                 <% if (user.User.IsLockedOut)
                                    { %>
                                    <%= Html.ActionLink("Unlock User", "UnlockUser", ((Guid)user.User.ProviderUserKey))%>
                                    <%= Html.ActionLink("Unlock user", "UnlockUser", ((Guid)user.User.ProviderUserKey))%></p>
                                 <% } %>
                                 </div>                            
                        </div>                        
                    </div>--%>
                    <div class="form-box1-row">
                        <p class="mrg-lft-130">
                            <input type="submit" value="Save User" class="btn1" , onclick  = "return confirm('Do you really want to perform this Operation?')"/> 
                        </p>                        
                    </div>                                     
                </div>
            </div>


<% } %>


<%--////////////////////////// Role View //////////////////
<% if ((obj != null && obj.UserTypeId == (int)UserTypes.SuperAdmin) || (obj != null && obj.UserTypeId == (int)UserTypes.SuperAgent))
   {%>
<% if (user.RolesEnabled)
   { %>
<fieldset>
	<legend>User's Roles</legend>
    <table class="data-table">
    	
	<% if (user.AllRoles.Count > 0)
    { %>
	<% foreach (string role in user.AllRoles)
    { %>
	<tr>
		<% if (user.UsersRoles.Contains(role))
     { %>
        <%if (role == "SuperAdmin")
          { %>
        <%}
          else
          { %>
		<td><% =role%> </td><td> (<% = Html.ActionLink("Remove", "RemoveUserFromRole", new { user.User.ProviderUserKey, role })%>)</td>
		<%}
     }
     else
     { %>
     <%if (role == "SuperAdmin")
       { %><%}
       else
       { %>
		<td><% =role%> </td><td> (<%= Html.ActionLink("Add", "AddUserToRole", new { user.User.ProviderUserKey, role }, "+")%>)</td>
		<% }
     }%>
       
  
   </tr>
	<% } %>
	<% }
    else
    { %>
	No roles have been added to the system yet.
	<% } %>
      </table>
</fieldset>
<% } %>
<%} %>
///////////////Role view end here //////////////////--%>



<%if (user.UserDetails != null)
  { %>
<%   using (Html.BeginForm("UpdateDetails", "ProfileManagement", new { user.User.ProviderUserKey }))
     { %>

     
 <div class="row-1  mrg-top-20">
           		<h3>User's Details</h3>
            	<div class="form-box1 round-corner">
                	<div class="form-box1-row">
                        <div class="form-box1-row-content float-left">                            
                                <div><label>Full Name:</label><% =Html.TextBox("FullName", user.UserDetails.FullName, new { size = 32, maxlength = 256 })%></div>                            
                        </div>                        
                    </div>
                    <div class="form-box1-row">
                        <div class="form-box1-row-content float-left">                            
                                <div><label>Mobile Number:</label><% =Html.TextBox("MobileNo", user.UserDetails.MobileNumber, new { size = 32, maxlength = 256 })%></div>                            
                        </div>                        
                    </div>
                    <div class="form-box1-row">
                        <div class="form-box1-row-content float-left">                            
                                <div><label>Phone Number:</label><% =Html.TextBox("PhoneNo", user.UserDetails.PhoneNumber, new { size = 32, maxlength = 256 })%></div>                            
                        </div>                        
                    </div>
                    <div class="form-box1-row">
                        <div class="form-box1-row-content float-left">                            
                                <div><label>Address:</label><% =Html.TextBox("Address", user.UserDetails.UserAddress, new { size = 32, maxlength = 256 })%></div>                            
                        </div>                      
                    </div>
                   
                    <div class="form-box1-row">
                        <p class="mrg-lft-130">
                            <input type="submit" value="Updates Details" class="btn1" , new { onclick  = "return confirm('Do you really want to perform this Operation?')" } />                            
                                                   
                        </p>                        
                    </div>                                     
                </div>
            </div>

<% }
  } %>

  


<%--///////////////////////////--%>
<%  using (Html.BeginForm("ResetPassword", "ProfileManagement"))
    {  %>
   
     
 <div class="row-1  mrg-top-20">
           		<h3>Reset User's Password</h3>
            	<div class="form-box1 round-corner">
                	<div class="form-box1-row">
                        <div class="form-box1-row-content float-left">                            
                                <div><label><% =Html.Hidden( "UserName", user.User.UserName ) %>Password Changed?</label><% =user.User.CreationDate != user.User.LastPasswordChangedDate ? user.User.LastPasswordChangedDate.ToString( "M/d/yyyy h:mm:ss tt" ) : "Never Changed Password" %></div>                            
                        </div>                        
                    </div>
                    <div class="form-box1-row">
                        <div class="form-box1-row-content float-left">                            
                                <div><label>Password Question:</label>
                                    <% if( !string.IsNullOrEmpty( user.User.PasswordQuestion) ){ %>
	                                    <% =user.User.PasswordQuestion %>
	                                <% }else{ %>
	                                <b><em>No password question set.</em></b>
	                                <% } %>
                                 </div>                            
                        </div>                        
                    </div>
                    <div class="form-box1-row">
                        <div class="form-box1-row-content float-left">                            
                                <div><label>Password Answer:</label><% =Html.TextBox("PasswordAnswer", "" ,  new { size = 32, maxlength = 128 })%></div>                            
                        </div>                        
                    </div>
                  
                   
                    <div class="form-box1-row">
                        <p class="mrg-lft-130">
                            <input type="submit" value="Reset Password" class="btn1"/>                                                    
                        </p>                        
                    </div>                                     
                </div>
            </div>



<% } %>

<%   using (Html.BeginForm("ChangePassword", "ProfileManagement", FormMethod.Post, new { @class = "validate", @autocomplete = "off", enctype = "multipart/form-data" }))
     { %>

     
     
 <div class="row-1  mrg-top-20">
           		<h3>Change User's Password</h3>
            	<div class="form-box1 round-corner">
                	<div class="form-box1-row">
                        <div class="form-box1-row-content float-left">                            
                                <div><label><% =Html.Hidden( "UserName", user.User.UserName ) %> Last Changed:</label><% =user.User.CreationDate != user.User.LastPasswordChangedDate ? user.User.LastPasswordChangedDate.ToString( "M/d/yyyy h:mm:ss tt" ) : "Never Changed Password" %></div>                            
                        </div>                        
                    </div>
                    <div class="form-box1-row">
                        <div class="form-box1-row-content float-left">                            
                                <div><label>Old Password:</label>
                                   <% =Html.Password("OldPassword", "", new { size = 32, @class = "required" })%>
                                 </div>                            
                        </div>                        
                    </div>
                    <div class="form-box1-row">
                        <div class="form-box1-row-content float-left">                            
                                <div><label>New Password:</label><% =Html.Password("NewPassword", "", new { size = 32, @class = "required" })%></div> 
                                <div id= "checkpassword"></div>                        
                        </div>                        
                    </div>
                  
                   <div class="form-box1-row">
                        <div class="form-box1-row-content float-left">                            
                                <div><label>Confirm Password:</label><% =Html.Password("NewPasswordConfirm", "", new { size = 32, @class = "required" })%></div>                            
                        </div>                        
                    </div>
                   
                    <div class="form-box1-row">
                        <p class="mrg-lft-130">
                            <input type="submit" value="Change Password"  class="btn1" />
                        </p>                        
                    </div>                                     
                </div>
            </div>


<% } %>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CssContent" runat="server">
   <style type="text/css"> 
	   label.error {
  font-weight: bold;
  color: #b80000;
}
	  </style> 
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
    <script src="../../../../Scripts/jquery-1.5.1.min.js" type="text/javascript"></script>
    <script src="../../../../Scripts/jquery-ui-1.8.13.custom.min.js" type="text/javascript"></script>
    <script src="../../../../Scripts/jquery.validate.js" type="text/javascript"></script>
   <script type="text/javascript">
       $(document).ready(function () {
           $('.validate').validate();
           $("#NewPassword").blur(function () {
               if (this.value.length <= 6) {
                   $("#NewPassword").val('');
                   $("#checkpassword").attr({ color: "Red" });
                   $("#checkpassword").html("<span style = 'color:red'>Must be equal or greater than six character </span>")
               }
               else {
                   $("#checkpassword").hide();
               }

           });
           $("#NewPasswordConfirm").blur(function () {
               $("#checkpassword").show();
               if ($("#NewPassword").val() != $("#NewPasswordConfirm").val()) {
                   $("#NewPasswordConfirm").val('');
                   $("#checkpassword").attr({ color: "Red" });
                   $("#checkpassword").html("<span style = 'color:red'>New Password and confirm password doesn't match </span>")
               }
               else {
                   $("#checkpassword").hide();
               }


           });

       });

    </script>
      

</asp:Content>
