<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<List<ATLTravelPortal.Areas.Administrator.Models.RoleBasedRoleModel>>" %>
<%@ Import Namespace="ATLTravelPortal.Areas.Administrator.Models" %> 
<%@ Import Namespace="ATLTravelPortal.Helpers" %>
         <%------------------------  Data for paging ------------------------%>
         <% int numberOfPage =Int32.Parse(ViewData["TotalPages"].ToString());
                       int currentPage = Int32.Parse(ViewData["CurrentPage"].ToString());%> 
          <%------------------------End  Data for paging ------------------------%>
         
    <div class="contentGrid">
        <table cellspacing="0" cellpadding="0" border="0" style="border-collapse: collapse;"
            class="GridView" width="100%" id="RoleTable">
            <thead>
                <th>
                    S.N.
                </th>
                <th>
                    Role Name
                </th>
                <th>
                    Role Created For Product
                </th>
                 <th>
                   Product Module
                </th>
                <th>
                   Action
                </th>
                <th>
                   Options
                </th>
            </thead>
           <% var sno = ((currentPage - 1)*((int)PageSize.JePageSize));
              foreach (RoleBasedRoleModel r in Model)
              {
                  sno++;
                  var classTblRow = (sno % 2 == 0) ? "GridAlter" : "GridItem";
            %>
            <tbody>
                <tr id="add-method-<%= r.RoleName%>" class="<%: classTblRow %>" onmouseover="this.className='GridRowOver'"
                    onmouseout="this.className='<%= classTblRow %>'">
                    <td>
                        <%:sno %>
                    </td>
                    <td>
                        <%= Html.Encode(r.RoleName)%>
                        </td>
                    <td>
                       <%:r.ProductName %>
                    </td>
                  <td>
                       <%:r.SubProductName %>
                    </td>
                    <td>
                        <%: Html.ActionLink("Manage Role Privilege", "Index", new { controller = "UserRolePrevilage" })%>
                    </td>
                     <td>
                 
                     <%using (Html.BeginForm("DeleteRole", "RoleManagement", new { id = r.RoleName }, FormMethod.Post, new { onclick = "return confirm('Do you really want to perform this Operation?')" }))
                  {%>
                    <input type="submit" value="" class="delete" />
                   <%} %>
                   
                    </td>
                </tr>
            </tbody>
            <%} %>
        </table>
    </div>

    <div class="paging">
     <table class="grid_tbl" border="0" width="100%">
        <tr>
            <td>
                <div class="left">
                        <%=Ajax.ActionLink("<<First", "ManageRole", new { controller = "RoleManagement", action = "ManageRole", pageNo = 1 },
        new AjaxOptions() { UpdateTargetId = "RoleDiv",OnBegin = "beginAgentList", OnSuccess = "successAgentList" ,InsertionMode = InsertionMode.Replace, HttpMethod = "Get" }, new { @class = "btn1" })%>                                                  
 
                     <%=Ajax.ActionLink("Previous", "ManageRole", new { controller = "RoleManagement", action = "ManageRole", pageNo = currentPage, flag = 1 },
        new AjaxOptions() { UpdateTargetId = "RoleDiv",OnBegin = "beginAgentList", OnSuccess = "successAgentList", InsertionMode = InsertionMode.Replace, HttpMethod = "Get" }, new { @class = "btn1" })%>                                                  
 
                        &nbsp;&nbsp;Page&nbsp;&nbsp;<%=currentPage%>&nbsp;of &nbsp;<%=numberOfPage%>&nbsp;&nbsp;
                        <%=Ajax.ActionLink("Next", "ManageRole", new { controller = "RoleManagement", action = "ManageRole", pageNo = currentPage, flag = 2 },
        new AjaxOptions() { UpdateTargetId = "RoleDiv",OnBegin = "beginAgentList", OnSuccess = "successAgentList", InsertionMode = InsertionMode.Replace, HttpMethod = "Get" }, new { @class = "btn1" })%>                                                  
                      
                    <%=Ajax.ActionLink("Last>>", "ManageRole", new { controller = "RoleManagement", action = "ManageRole", pageNo = numberOfPage },
        new AjaxOptions() { UpdateTargetId = "RoleDiv",OnBegin = "beginAgentList", OnSuccess = "successAgentList", InsertionMode = InsertionMode.Replace, HttpMethod = "Get" }, new { @class = "btn1" })%>                                                  
                      
                         
                </div>
            </td>
        </tr>
     </table>
</div>
  <div class="msgbox" id="loadingIndicator" style="border:0px"><%:TempData["delmessage"]%></div>
