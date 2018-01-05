<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<ATLTravelPortal.Areas.Administrator.Models.BranchOfficeManagementModel>" %>
<%@ Import Namespace="ATLTravelPortal.Helpers" %>
<%@ Import Namespace="ATLTravelPortal.Helpers.PortalHtmlHelper" %>


<div class="contentGrid">
    <table cellspacing="0" cellpadding="0" border="0" style="border-collapse: collapse;"
        class="GridView" width="100%">
        <thead>
            <tr>
                <th>
                    Sn
                </th>
                <th>
                    Name(Code)
                </th>
                <th>
                    Country/Zone/District/Address
                </th>
                <th>
                    Email
                </th>
                <th style="text-align:center">
                    Action
                </th>
            </tr>
        </thead>
        <%
            if (Model != null)
            {
        %>
        <% var sno = 0;

           foreach (var item in Model.ListBranchOffice)
           {
               sno++;
               var classTblRow = (sno % 2 == 0) ? "GridAlter" : "GridItem";
        %>
        <tbody>
            <tr id="tr_<%=sno %>" class="<%: classTblRow %>" onmouseover="this.className='GridRowOver'"
                onmouseout="this.className='<%= classTblRow %>'">
                <td>
                    <%:sno%>
                </td>
                <td>
                    <%:item.BranchOffice%>(<%:item.BranchOfficeCode%>)
                </td>
                <td>
                    <%:item.NativeCountryName%>/&nbsp;
                    <%:item.ZoneName%>/&nbsp;
                    <%:item.DistrictName%>/&nbsp;
                    <%:item.Address%>
                </td>
                <td>
                    <%:item.Email%>
                </td>
                <td>
                    <a href="/Administrator/BranchOfficeManagement/Details/<%:item.BranchOfficeId %>"
                        class="details" title="Details"></a>
                        <a href="/Administrator/BranchOfficeManagement/Edit/<%:item.BranchOfficeId %>"
                            class="edit" title="Edit"></a>
                            <a href="/Administrator/BranchOfficeManagement/Delete/<%:item.BranchOfficeId %>"
                                class="delete" title="Delete" onclick="return confirm('Are you sure you want to delete?')">
                            </a>

                            <a href="/Administrator/BranchUserManagement/Index/<%:item.BranchOfficeId %>" title="Branch User">
                                        Branch's User</a>

                            <a href="/Administrator/BranchOfficeManagement/DistributorList/<%:item.BranchOfficeId %>"
                                rel="<%:item.BranchOfficeId %>"  title="Distributors">Distributors</a>
                 
                    <a href="/Administrator/BranchOfficeManagement/AgentList/<%:item.BranchOfficeId %>"
                        rel="<%:item.BranchOfficeId %>"  title="Agents">Agents</a>

                </td>
            </tr>
        </tbody>
        <%}
            } %>
    </table>
</div>

<%--class="distributorList"
class ="agentList"--%>


<%--
<div class="Adminpager">
    <%: Ajax.GenerateAlphabeticalActionLink("Index", "BranchOfficeManagement", "Administrator", new AjaxOptions { UpdateTargetId = "AgentPartialDiv", OnBegin = "beginAgentList", OnSuccess = "successAgentList", OnFailure = "failureAgentList", HttpMethod = "Get" })%>
</div>--%>
