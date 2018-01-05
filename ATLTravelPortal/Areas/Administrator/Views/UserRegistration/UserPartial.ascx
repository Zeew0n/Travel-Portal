<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IPagedList<TravelPortalEntity.vw_BackofficeUsers>>" %>
<%@ Import Namespace="ATLTravelPortal.Helpers" %>
<%@ Import Namespace="ATLTravelPortal.Helpers.Pagination" %>
<div class="contentGrid">
    <table cellspacing="0" cellpadding="0" border="0" style="border-collapse: collapse;"
        class="GridView" width="100%">
        <thead>
            <th>
                SN
            </th>
            <th>
                User Name
            </th>
            <th>
                Full Name
            </th>
            <th>
                Email
            </th>
            <th>
                Created By
            </th>
            <th>
                Created Date
            </th>
            <th colspan="2">
                Role Information/Action
            </th>
        </thead>
        <%
            if (Model != null)
            {
        %>
        <% var sno = ((Model.PageNumber - 1) * 25);

           foreach (var item in Model)
           {
               sno++;
               var classTblRow = (sno % 2 == 0) ? "GridAlter" : "GridItem";
        %>
        <tbody id="tr_<%=sno %>" class="<%: classTblRow %>" onmouseover="this.className='GridRowOver'"
            onmouseout="this.className='<%= classTblRow %>'">
            <tr>
                <td>
                    <%:sno%>
                </td>
                <td>
                    <%: item.UserName %>
                </td>
                <td>
                    <%: item.FullName %>
                </td>
                <td>
                    <%: item.Email %>
                </td>
                <td>
                    <%ATLTravelPortal.Areas.Administrator.Repository.AdminUserManagementRepository user = new ATLTravelPortal.Areas.Administrator.Repository.AdminUserManagementRepository(); %>
                    <%string CreatedBy = user.GetCreatedBy(item.UserId); %>
                    <%: CreatedBy%>
                </td>
                <td>
                    <%: TimeFormat.DateFormat( item.CreateDate.ToString()) %>
                </td>
                <% 
ATLTravelPortal.Areas.Administrator.Repository.AdminUserManagementRepository pro = new ATLTravelPortal.Areas.Administrator.Repository.AdminUserManagementRepository();
ATLTravelPortal.Areas.Administrator.Models.AdminUserManagementModel.CreateAdminAspUser m = new ATLTravelPortal.Areas.Administrator.Models.AdminUserManagementModel.CreateAdminAspUser();
                %>
                <% 
             
            m.GetUserRolesList.AddRange(pro.ListGetUserRoles(item.UserId)); %>
                <td>
                    <table width="100%" cellpadding="0" cellspacing="0">
                        <% foreach (var roles in m.GetUserRolesList)
                           {%>
                        <tr>
                            <td>
                                <%:roles.RolesName %>
                            </td>
                            <td>
                                <%: roles.RolesOn %>
                            </td>
                        </tr>
                        <% } %>
                    </table>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td colspan="8" style="text-align: right; padding: 0px;">
                    <p style="background: #ebebeb; width: 240px; float: right; -moz-border-radius-topleft: 0px;
                        -moz-border-radius-topright: 0px; -moz-border-radius-bottomright: 0px; -moz-border-radius-bottomleft: 25px;
                        -webkit-border-radius: 0px 0px 0px 25px; border-radius: 0px 0px 0px 25px; padding: 0px 5px;">
                        <a href="UserManagement/Details/<%: item.UserId %>" class="details" title="Details">
                        </a><a href="UserRegistration/Edit/<%: item.UserId %>" class="edit" title="Edit">
                        </a><a>
                            <%:Html.ActionLink(" ", "Delete", new { controller = "UserRegistration", @id = item.UserId }, new {@title="Delete", @onclick = "return confirm('Do you really want to delete ?')", @class="delete"})%></a>
                        <%string LockUnlock = "";
                          if (item.IsLockedOut == false) { LockUnlock = "Lock User"; } else { LockUnlock = "UnLock User"; }%>
                        <%:Html.ActionLink(LockUnlock+"", "LockUnlockUser", new { controller = "UserRegistration", @id = item.UserName }, new { @onclick = "return confirm('Do you really want to " + LockUnlock + " ?')" })%>
                        <a href="/Administrator/UserRegistration/ResetPassword/<%:item.UserName%>" title="|Reset Password"
                            onclick="return confirm('Are you sure you want to reset password for <%: item.UserName%>?')">
                            Reset Password</a>
                    </p>
                </td>
            </tr>
        </tbody>
        <%}
             } %>
    </table>
</div>
<div class="Adminpager">
    <%= Ajax.Pager(new AjaxOptions { UpdateTargetId = "UserPartial", OnBegin = "beginAgentList", OnSuccess = "successAgentList",OnFailure="failureAgentList", HttpMethod = "Get" },
                                              ViewData.Model.PageSize, ViewData.Model.PageNumber, ViewData.Model.TotalItemCount, new { controller = "UserRegistration", action = "Index" })%>
</div>
<div id="loadingIndicator">
</div>
<script type="text/javascript">
    function beginAgentList(args) {
        // Animate
        $("#loadingIndicator").html('<center><img src="<%=Url.Content("~/Content/images/indicator.gif") %>" alt="" width="16px" height="16px" />   </center>');
    }
    function successAgentList() {
        // Animate loadingAnimation
        $("#loadingIndicator").html('');
    }
    function failureAgentList() {
        alert("Could not retrieve List.");
    }
</script>
