<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<List<ATLTravelPortal.Areas.Administrator.Models.UserManagementModel.LockApprovedUserModel>>" %>

 <% if (Model.Count() > 0)
       { %>


       <div class="contentGrid">
            <table cellspacing="0" cellpadding="0" border="0" style="border-collapse:collapse;" class="GridView" width="100%" >
                <thead>
                    <th>S.N.</th>
                    <th>Agency Name</th>
                    <th>UserName</th>
                    <th>Email</th>           
                    <%--<th><%= TempData["messageHead"]%></th>--%>
                    <th>Action</th>
                </thead>
     <tbody>
                <%
            var sno=0;
            foreach (var item in Model)
            {
                sno++;
                var classTblRow = (sno % 2 == 0) ? "GridAlter" : "GridItem";
                      
                       %>
                  
                 <tr id="tr_<%=sno %>" class="<%:classTblRow %>" onmouseover="this.className='GridRowOver'" onmouseout="this.className='<%=classTblRow %>'">
                <td><%:sno%></td>
                <%if (item.AgentName == null)
                  {%>
                <td> ---- </td>
                <%}else { %>
                <td> <%: item.AgentName%></td>
                <%} %>
            <td>
                <%: item.UserName%>
            </td>
            <td>
                <%: item.Email%>
            </td>
         <%--   ------------ Begin Lockedout Logic --------------------------------------------------%>

            <%if (item.IsLockedOut ==true)
              { %>
              <td>
               <%:Html.ActionLink("UnLock Now", "UnLockUsernow", new { controller = "Usermanagement", @id = item.UserId }, new { @onclick = "return confirm('Do you really want to Unlock This user  ?')" })%>
           </td>
           <%}else { %>
            <%--   ------------ End Lockedout Logic --------------------------------------------------%>

             <%--  -------------------- ------------ Begin Approved Logic ---------------------------------------%>
             
           <td>
                 <%:Html.ActionLink("Approve Now", "ApproveUsernow", new { controller = "Usermanagement", @id = item.UserId }, new { @onclick = "return confirm('Do you really want to Unlock This user  ?')" })%>
            </td>
             <%} %>
              <%--   ------------------------------------ End Approved Logic --------------------------------%>

                        </tr>
                        <%} %>
                       </tbody>
            </table>
           
      <%--    <div class="Adminpager">
    <%= Ajax.Pager(new AjaxOptions { UpdateTargetId = "SearchResult", OnBegin = "beginAgentList", OnSuccess = "successAgentList", OnFailure = "failureAgentList", HttpMethod = "Post" },
                                                                    ViewData.Model.PageSize, ViewData.Model.PageNumber, ViewData.Model.TotalItemCount, new { controller = "UserManagement", action = "ManageUser" })%>
        </div>--%>
            

      <% 
       }
       else
       {%>
            <div class="msgbox">No <%= TempData["messageflag"]%> Exists.</div>                             
       <%} %>

     </div>

   