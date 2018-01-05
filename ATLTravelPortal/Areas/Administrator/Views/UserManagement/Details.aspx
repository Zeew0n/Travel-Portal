<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/AdministratorMain.Master" Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Administrator.Models.UserManagementModel.MembershipUserAndRolesViewData>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
 User Details
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
   <div class="row-1">

    <div class="pageTitle">
           <div class="float-right">
            <ul>
                <li>
                    <%:Html.ActionLink("Cancel", "Index", new { controller = "UserRegistration" }, new { @class = "linkButton" })%></li>
            </ul>
        </div>
        <h3>
            <a class="icon_plane" href="#">User Management</a> <span>&nbsp;</span><strong>User Registration</strong>
        </h3>
    </div>
    <br />
    <fieldset class="style1">
           		<legend><%=ViewData["Title"] %> </legend> 
            	<div class="form-box1 round-corner">
                	<div class="form-box1-row">
                        <div class="form-box1-row-content float-left">                            
                                <div>
                                    <label><strong> User Name :</strong><% =Html.Hidden("UserName", Model.User.UserName)%></label>
                                    <% =Model.User.UserName%>                                    
                                 </div>                            
                        </div>  
                         <div class="form-box1-row-content float-right">                            
                                <div>
                                    <label><strong>Email Address :</strong></label>
                                    <% =Model.User.Email%>                                    
                                </div>                            
                        </div>                         
                    </div>
                    
                	<div class="form-box1-row">
                        <div class="form-box1-row-content float-left">                            
                                <div><label><strong>Full Name :</strong></label><% =Model.UserDetails.FullName%></div>                            
                        </div>    
                         <div class="form-box1-row">
                        <div class="form-box1-row-content float-right">                            
                                <div><label><strong>Mobile Number :</strong></label><% =Model.UserDetails.MobileNumber%></div>                            
                        </div>                        
                    </div>                    
                    </div>
                   
                    <div class="form-box1-row">
                        <div class="form-box1-row-content float-left">                            
                                <div><label><strong>Phone Number :</strong></label><% =Model.UserDetails.PhoneNumber%></div>                            
                        </div>  
                         <div class="form-box1-row">
                        <div class="form-box1-row-content float-right">                            
                                <div><label><strong>Address :</strong></label><% =Model.UserDetails.UserAddress%></div>                            
                        </div>                      
                    </div>                      
                    </div>
                 
                    <div class="form-box1-row">
                        <div class="form-box1-row-content float-left">                            
                                <div><label><strong>Is Approved :</strong></label><input type="checkbox" id="IsApproved" name="IsApproved" <% =Model.User.IsApproved ? "checked=\"checked\"" : "" %> disabled="disabled" /></div>                            
                        </div>                      
                
                        <div class="form-box1-row-content float-right">                            
                                <div><label><strong>Created :</strong></label><% =Model.User.CreationDate.ToString("M/d/yyyy h:mm:ss tt")%></div>                            
                        </div>                        
                                            
                    </div>
                    <div class="form-box1-row">
                     <div class="form-box1-row-content float-left">                            
                                <div><label><strong>Last Login :</strong></label><% =Model.User.CreationDate != Model.User.LastLoginDate ? Model.User.LastLoginDate.ToString("M/d/yyyy h:mm:ss tt") : "Never Logged In"%></div>                            
                        </div>   
                        <div class="form-box1-row-content float-right">                            
                                <div><label><strong>Last Activity :</strong></label><% =Model.User.CreationDate != Model.User.LastActivityDate ? Model.User.LastActivityDate.ToString("M/d/yyyy h:mm:ss tt") : "Never Active"%> (<% =Model.User.IsOnline ? "Online" : "Offline"%>)</div>                            
                        </div>                        
                     </div>
                    <div class="form-box1-row">
                        <div class="form-box1-row-content float-left">                            
                                <div><label><strong>Last Lockout :</strong></label><% =(Model.User.LastLockoutDate == DateTime.MinValue ? Model.User.LastLockoutDate.ToString("M/d/yyyy h:mm:ss tt") : "Never Locked Out")%></div>                            
                        </div>                        
                    </div>
                                                   
                </div>
                </fieldset>
            </div>
                 
            	
                   
                   
                                               
           
          
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="CssContent" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
</asp:Content>
