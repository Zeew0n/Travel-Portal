<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/AdministratorMain.Master" Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Administrator.Models.DistributorManagementModel>" %>
<%@ Import Namespace="ATLTravelPortal.Helpers" %>
<%@ Import Namespace="ATLTravelPortal.Helpers.PortalHtmlHelper" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Distributor List
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
 <div class="pageTitle">
        <div class="float-right">
            <ul>
                <li>
                    <input type="button" value="Back to List" class="cancel" onclick="document.location.href='/Administrator/BranchOfficeManagement'" /></li>
            </ul>
        </div>

         <h3>
            <a href="#">Branch Office Management</a> <span>&nbsp;</span><strong>Distributors</strong>
        </h3>
     
    </div>

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
            <th></th>
        </thead>
        <%if (Model.DistributorsList != null && Model.DistributorsList.Count() > 0)
          { %>
        <% var sno = 0;
           foreach (var item in Model.DistributorsList)
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
               
                <td>
                <%-- <a href="/Administrator/BranchOfficeManagement/AgentList/<%:item.DistributorId %>?name=Distributor&&BOId=<%:item.BranchOfficeId %>"
                        rel="<%:item.DistributorId %>"  title="Agents">Agents</a>--%>
                         <a href="/Administrator/BranchOfficeManagement/DistributorAgentList/<%:item.DistributorId %>?name=Distributor&&BOId=<%:item.BranchOfficeId %>"
                        rel="<%:item.DistributorId %>"  title="Agents">Agents</a>
                        </td>
            </tr>
        </tbody>
        <%} %>
        <%}
         
        %>
    </table>
</div>
<% if (Model.DistributorsList != null && Model.DistributorsList.Count > 0)
   { %>
    <div class="pager">
        <%= Html.Pager(ViewData.Model.DistributorsList.PageSize, ViewData.Model.DistributorsList.PageNumber, ViewData.Model.DistributorsList.TotalItemCount)%>
    </div>
    <%} %>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="CssContent" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
</asp:Content>
