<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/AdministratorMain.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<TravelPortalEntity.View_AgentDetails>>" %>
<%@ Import Namespace="TravelPortalEntity" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
AgentUser:<%:ViewData["AgentName"]%>  
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

  <%-- @@@@@@@@@@@@@@@@@@@@@@@@@@End of Succes/Error displaying region@@@@@@@@@@@@@@@@@@@@@@@--%>
    <%if (TempData["TemoResetPassword"] != null){ %>
          <div class="ui-widget">
			<div style="padding: 0 .7em;" class="ui-state-error ui-corner-all"> 
		    <p><span style="float: left; margin-right: .3em;" class="ui-icon ui-icon-info"></span>
            Password Successfully Changed.Here is new password.<strong>
            <%string Resetpass=(string) TempData["TemoResetPassword"];%></strong>
            <%:Html.TextBox("PassReset", Resetpass)%>
            </p>
			</div>
		</div>
          <%}%>
   <%if (TempData["ResponseMsg"] != null){ %>
   <div class="ui-widget">
			<div style="padding: 0 .7em;" class="ui-state-error ui-corner-all"> 
				<p><span style="float: left; margin-right: .3em;" class="ui-icon ui-icon-alert"></span> 
				<strong>Alert:</strong> <%:TempData["ResponseMsg"] %></p>
			</div>
		</div>
  <%}%>
  <%-- @@@@@@@@@@@@@@@@@@@@@@@@@@End of Succes/Error displaying region@@@@@@@@@@@@@@@@@@@@@@@--%>
  <div class="pageTitle">
        <div class="float-right">
            	<ul>
               
                       <li><%Html.RenderPartial("Utility/PVC_MessagePanel"); %> </li>
                	
                     <li><input type="button" value="Back To Agent List" class="cancel" onclick="document.location.href='/Administrator/AgentManagement/'" /></li>
                    
                </ul>
            </div>
        <h3>
            <a href="#">Agent's User Management</a> <span>&nbsp;</span><strong>Listing All <%:ViewData["AgentName"]%></strong>
        </h3>
    </div>
              <div class="contentGrid">    	
   <table cellspacing="0" cellpadding="0" border="0" style="border-collapse: collapse;" class="GridView" width="100%">
        <thead>
            <th>S.No.</th>
            <th>Full Name</th>
            <th>User Name</th>
            <th>Phone</th>
            <th>Mobile</th>
            <th>E-Mail</th>
            <th>Is Approved</th>
            <th>&nbsp;</th>
        </thead>

       
     <% var sno =0;

        foreach (View_AgentDetails item in Model)
        {
            sno++;
            var classTblRow = (sno % 2 == 0) ? "GridAlter" : "GridItem";
            %>

       <tbody >
         <tr id="tr_<%=sno %>"  class="<%: classTblRow %>" onmouseover="this.className='GridRowOver'" onmouseout="this.className='<%= classTblRow %>'">           
            <td>
                <%:sno%>
            </td>
            <td>
               <%: item.FullName%>
            </td>      
            <td>
                <%: item.UserName%>
            </td>
            <td>
                <%: item.Phone%>
            </td>
            <%
              ATLTravelPortal.Areas.Administrator.Repository.AgentManagementRepository ser = new ATLTravelPortal.Areas.Administrator.Repository.AgentManagementRepository();
                  var mobilenumber= ser.AgentMobileNumber(item.AgentId);
                         %>
                         
                    <td>
                    <%: mobilenumber %>
                    </td>
            <td>
                <%: item.Email%>
            </td>
             <td>
                <%: item.IsApproved%>
            </td>
            <%-- <td>
            <table width="100%" cellpadding="0" cellspacing="0">
                            <tr>
                                <td>Accounting</td>
                                <td>BackOffice (Administrator)</td>
                            </tr>
                            <tr>
                                <td>Hotel Agent Role</td>
                                <td>Hotel (Administrator)</td>
                            </tr>
                            <tr>
                                <td style="border-bottom:none;">Ticketing Admin</td>
                                <td style="border-bottom:none;">Ticketing (Administrator)</td>
                            </tr>
                        </table>
            </td>--%>

              <% 
             ATLTravelPortal.Areas.Administrator.Repository.AdminUserManagementRepository pro = new ATLTravelPortal.Areas.Administrator.Repository.AdminUserManagementRepository();
             ATLTravelPortal.Areas.Administrator.Models.AdminUserManagementModel.CreateAdminAspUser m = new ATLTravelPortal.Areas.Administrator.Models.AdminUserManagementModel.CreateAdminAspUser();
             %>

         <% 
             
          m.GetUserRolesList.AddRange(pro.ListGetUserRoles(item.UserId)); %>
  
            <td>
            <table width="100%" cellpadding="0" cellspacing="0">
                      
 <% foreach (var roles in m.GetUserRolesList )
             {%>
                            <tr>
                                <td><%:roles.RolesName %></td>
                                <td><%: roles.RolesOn %></td>
                            </tr>
                         
                            <% } %>
                        </table>
            </td>
        </tr> 
        <tr>
            
            <td colspan="8" style="text-align:right; padding:0px;">
            <p style="background:#ebebeb; width:240px; float:right;-moz-border-radius-topleft: 0px;-moz-border-radius-topright: 0px;-moz-border-radius-bottomright: 0px;-moz-border-radius-bottomleft: 25px;
-webkit-border-radius: 0px 0px 0px 25px;border-radius: 0px 0px 0px 25px; padding:0px 5px;  ">
                      
                                      <%string LockUnlock="";
                      if (item.IsLockedOut == false) { LockUnlock = "Lock User"; } else { LockUnlock = "UnLock User"; }%>
                     <%:Html.ActionLink(LockUnlock, "LockUnlockAgentUser", new { controller = "AgentUserManagement", @id = item.UserName }, new { @onclick = "return confirm('Do you really want to " + LockUnlock + " ?')" })%>

                      <a href="/Administrator/AgentUserManagement/ResetPassword/<%:item.UserName%>" title="Reset Password"  onclick="return confirm('Are you sure you want to reset password for <%: item.UserName%>?')">Reset Password</a>
                        </p></td>
        </tr>

        </tbody>
        <%}
             %>
    </table>

  </div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="CssContent" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
</asp:Content>
