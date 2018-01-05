<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<ATLTravelPortal.Areas.Administrator.Models.DistributorManagementModel>>" %>
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
        </thead>
        <%if (Model != null && Model.Count() > 0)
          { %>
        <% var sno = 0;
           foreach (var item in Model)
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
                    <%: item.BranchOfficeName%>
                </td>
                <td>
                    <%: item.DistributorName + "(" + item.DistributorCode + ")"%>
                </td>
                <td>
                    <%: item.Email%>
                </td>
            </tr>
        </tbody>
        <%} %>
        <%}
         
        %>
    </table>
</div>
