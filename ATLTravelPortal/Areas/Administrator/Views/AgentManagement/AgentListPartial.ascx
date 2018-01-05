﻿<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<List<TravelPortalEntity.Agents>>" %>
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
                Agency Name
            </th>
            <th>
                Agency Code
            </th>
            <th>
                Email
            </th>
            <th>
                Phone
            </th>
            <th>
                Mobile
            </th>
            <th>
                Created On
            </th>
            <th style="text-align: center">
                Action
            </th>
        </thead>
        <%if (Model != null && Model.Count() > 0)
          { %>
        <% var sno = 0;
           foreach (TravelPortalEntity.Agents item in Model)
           {
               sno++;
               var classTblRow = (sno % 2 == 0) ? "GridAlter" : "GridItem";
        %>
        <tbody>
            <tr id="tr1" class="<%: classTblRow %>" onmouseover="this.className='GridRowOver'"
                onmouseout="this.className='<%= classTblRow %>'">
                <td>
                    <%:sno%>
                </td>
                <td>
                    <%:item.BranchOffices != null?item.BranchOffices.BranchOfficeName+"("+item.BranchOffices.BranchOfficeCode+")":string.Empty%>
                </td>
                <td>
                    <%:item.Distributors!=null?item.Distributors.DistributorName +"("+item.Distributors.DistributorCode+")":string.Empty  %>
                </td>
                <td>
                    <%: item.AgentName%>
                </td>
                <td>
                    <%: item.AgentCode%>
                </td>
                <td>
                    <%: item.Email%>
                </td>
                <td>
                    <%: item.Phone%>
                </td>
                <%
ATLTravelPortal.Areas.Administrator.Repository.AgentManagementRepository ser = new ATLTravelPortal.Areas.Administrator.Repository.AgentManagementRepository();
var mobilenumber = ser.AgentMobileNumber(item.AgentId);
                %>
                <td>
                    <%: mobilenumber %>
                </td>
                <td>
                    <%: item.CreatedDate.ToString("dd MMM yyyy")%>
                </td>
                <td>
                    <p>
                        <a href="/Administrator/AgentManagement/Details/<%: item.AgentId %>" class="details"
                            title="Details"></a><a href="/Administrator/AgentManagement/Edit/<%: item.AgentId %>"
                                class="edit" title="Edit"></a><a href="/Administrator/AgentManagement/Delete/<%:item.AgentId %>"
                                    class="delete" title="Delete" onclick="return confirm('Are you sure you want to delete?')">
                                </a><a href="/Administrator/AgentUserManagement/Index/<%:item.AgentId %>" title="Agent User">
                                    Agent's User</a> <a href="/Administrator/AgentSetting/Index/<%:item.AgentId %>" title="Agent User">
                                        (Settings)</a>
                    </p>
                </td>
            </tr>
        </tbody>
        <%} %>
        <%}
        %>
    </table>
</div>
<div class="Adminpager">
    <%: Ajax.GenerateAlphabeticalActionLink("Index", "AgentManagement", "Administrator", new AjaxOptions { UpdateTargetId = "AgentPartialDiv", OnBegin = "beginAgentList", OnSuccess = "successAgentList", OnFailure = "failureAgentList", HttpMethod = "Get" })%>
</div>
