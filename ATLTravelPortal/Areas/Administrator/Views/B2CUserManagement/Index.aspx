<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/AdministratorMain.Master" Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Administrator.Models.B2CUserManagementModel>" %>

<%@ Import Namespace="ATLTravelPortal.Helpers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    User Management
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<%Html.RenderPartial("Utility/VUC_MessagePanel"); %>

 <%if (TempData["TemoResetPassword"] != null)
      { %>
    <div class="ui-widget">
        <div style="padding: 0 .7em;" class="ui-state-error ui-corner-all">
            <p>
                <span style="float: left; margin-right: .3em;" class="ui-icon ui-icon-info"></span>
                Password Successfully Changed.Here is new password.<strong>
                    <%string Resetpass = (string)TempData["TemoResetPassword"];%></strong>
                <%:Html.TextBox("PassReset", Resetpass)%>
            </p>
        </div>
    </div>
    <%}%>


    <% Html.EnableClientValidation(); %>
    <% using (Html.BeginForm())
       {%>
    <%: Html.ValidationSummary(true) %>
    <div>
        <div class="pageTitle">
            <h3>
                <a href="#" class="icon_plane">B2C</a> <span>&nbsp;</span><strong>User Management</strong>
            </h3>
        </div>
    </div>
    <% Html.RenderPartial("~/Views/Shared/ExportData.ascx"); %>
    <div class="contentGrid">
        <% if (Model != null)
           { %>
        <%if (Model.ListB2CUsers != null && Model.ListB2CUsers.Count() > 0)
          { %>
        <div class="contentGrid">
            <table cellspacing="0" cellpadding="0" border="0" style="border-collapse: collapse;"
                class="GridView" width="100%">
                <thead>
                    <tr>
                        <th>
                            SNo
                        </th>
                        <th>
                            Name
                        </th>
                          <th>
                           User Name / Email
                        </th>
                        <th>
                            Address
                        </th>
                        <th>
                            Mobile
                        </th>
                        <th>Phone</th>
                        <th>Created Date</th>
                      <th style="text-align:center">Action</th>
                       
                    </tr>
                </thead>
                <%  var sno = 0;
                    foreach (var item in Model.ListB2CUsers)
                    {

                        sno++;
                        var classTblRow = (sno % 2 == 0) ? "GridAlter" : "GridItem";
                %>
                <tr id="tr_<%= sno %>" class="<%: classTblRow %>" onmouseover="this.className='GridRowOver'"
                    onmouseout="this.className='<%= classTblRow %>'">
                    <td>
                        <%:sno%>.
                    </td>
                    <td>
                        <%: item.FullName %>
                    </td>
                      <td>
                        <%: item.UserName %>
                    </td>
                    <td>
                        <%: item.Address %>
                    </td>
                    <td>
                        <%: item.Mobile %>
                    </td>
                    <td><%: item.Phone %></td>
                    <td><%: TimeFormat.DateFormat(item.CreatedDate.ToString()) %></td>
                    <td>
                    <a href="B2CUserManagement/Details/<%: item.UserId %>" class="details" title="Detail">
                        </a>
                    <a href="B2CUserManagement/Edit/<%: item.UserId %>" class="edit" title="Edit">
                        </a>
                    <a>
                            <%:Html.ActionLink(" ", "Delete", new { controller = "B2CUserManagement", @id = item.UserId }, new { @title = "Delete", @onclick = "return confirm('Do you really want to delete ?')", @class = "delete" })%></a>
                      <%string LockUnlock = "";
                          if (item.IsLockedOut == false) { LockUnlock = "Lock User"; } else { LockUnlock = "UnLock User"; }%>
                        <%:Html.ActionLink(LockUnlock + "", "LockUnlockUser", new { controller = "B2CUserManagement", @id = item.UserName }, new { @onclick = "return confirm('Do you really want to " + LockUnlock + " ?')" })%>

                          <a href="/Administrator/B2CUserManagement/ResetPassword/<%:item.UserName%>" title="|Reset Password"
                            onclick="return confirm('Are you sure you want to reset password for <%: item.UserName%>?')">
                            Reset Password</a>

                    </td>
                  
                </tr>
                <% } %>
            </table>
               <div class="Adminpager">
       <%= Html.Pager(ViewData.Model.ListB2CUsers.PageSize, ViewData.Model.ListB2CUsers.PageNumber, ViewData.Model.ListB2CUsers.TotalItemCount)%>
       </div>
        </div>
        <%}  %>
        <%} %>
    </div>
    <% } %>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CssContent" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
  
     <script src="../../../../Scripts/ATL.function.js" type="text/javascript"></script>
</asp:Content>