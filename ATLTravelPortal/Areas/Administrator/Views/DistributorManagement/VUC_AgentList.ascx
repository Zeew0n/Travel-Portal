<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<List<TravelPortalEntity.Agents>>" %>
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
                Agency Name
            </th>
            <th>
                Agency Code
            </th>
            <th>
                Agency Email
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
            <th></th>
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
                 <%if (Model[0].AgentStatus == true)
                   { %>
                    <p>
                     
                                    <a href="/Administrator/DistributorAgentSetting/Index/<%:item.AgentId %>" title="Agent User" target="_blank">
                                        (Settings)</a>
                    </p>
                    <%} %>
                </td>


            </tr>
        </tbody>
        <%} %>
        <%}
        %>
    </table>
</div>
