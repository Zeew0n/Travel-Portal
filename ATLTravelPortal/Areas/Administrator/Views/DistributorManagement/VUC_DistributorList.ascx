﻿<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<ATLTravelPortal.Areas.Administrator.Models.DistributorManagementModel>>" %>
<%@ Import Namespace="ATLTravelPortal.Helpers" %>
<%@ Import Namespace="ATLTravelPortal.Helpers.PortalHtmlHelper" %>
<div class="contentGrid">
    <table cellspacing="0" cellpadding="0" border="0" style="border-collapse: collapse;"
        class="GridView" width="100%">
        <thead>
            <th>
                S.No.
            </th>
            <th>
                Branch(Code)
            </th>
            <th>
                Distributor(Code)
            </th>
            <th>
                Email
            </th>
            <th>
                Action
            </th>
        </thead>
        <%if (Model != null && Model.Count() > 0)
          { %>
        <% var sno = 0;
           foreach (var item in Model)
           {
               sno++;
               var classTblRow = (sno % 2 == 0) ? "GridAlter" : "GridItem";
               var myDistributor = item.BranchOfficeId == 1 ? "greenBg" : "";
        %>
        <tbody>
            <tr id="tr1" class="<%: classTblRow %> <%:myDistributor %>" onmouseover="this.className='GridRowOver'"
                onmouseout="this.className='<%= classTblRow  %> <%=myDistributor %>'">
                <td>
                    <%:sno%>
                </td>
                <td>
                    <%: item.BranchOfficeName%>
                </td>
                <td>
                    <%: item.DistributorName + "(" + item.DistributorCode + ")"%>
                </td>
                <td>
                    <%: item.Email%>
                </td>
                <td>
                    <p>
                        <a href="/Administrator/DistributorManagement/Details/<%: item.DistributorId %>"
                            class="details" title="Details"></a>
                            <a href="/Administrator/DistributorManagement/Edit/<%: item.DistributorId %>"
                                class="edit" title="Edit"></a>
                                <a href="/Administrator/DistributorManagement/Delete/<%:item.DistributorId %>"
                                    class="delete" title="Delete" onclick="return confirm('Are you sure you want to delete?')">
                                </a>
                                  <a href="/Administrator/DistributorAgentUserManagement/Index/<%:item.DistributorId %>" title="Distributor User">
                                        Distributors's User</a>
                                <a href="/Administrator/DistributorManagement/AgentList/<%:item.DistributorId %>"
                                    rel="<%=  item.DistributorId%>" title="Agents List">Agents</a>
                    </p>
                </td>
            </tr>
        </tbody>
        <%} %>
        <%}
         
        %>
    </table>
</div>

<%--<div class="Adminpager">
    <%: Ajax.GenerateAlphabeticalActionLink("Index", "DistributorManagement", "Administrator", new AjaxOptions { UpdateTargetId = "AgentPartialDiv", OnBegin = "beginAgentList", OnSuccess = "successAgentList", OnFailure = "failureAgentList", HttpMethod = "Get" })%>
</div>
--%>