<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/AdministratorMain.Master"
    Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Administrator.Models.DistributorAgentManagementModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    AgentList
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
 <div class="pageTitle">
        <div class="float-right">
            <ul>
             <li>
                    <%Html.RenderPartial("Utility/VUC_MessagePanel"); %>
                </li>
                <li>
               
                    <input type="button" value="Back to List" class="cancel" onclick="document.location.href='/Administrator/BranchOfficeManagement'" />
                   
                        
                        
                    </li>
            </ul>
        </div>
         <% if (Model.RedirectedFrom == "BranchOfficeManagement")
            { %>
         <h3>
            <a href="#">Branch Office Management</a> <span>&nbsp;</span><strong>Agents</strong>
        </h3>
        <%} %>
         <% if (Model.RedirectedFrom == "DistributorManagement")
            { %>
         <h3>
            <a href="#">Distributor Management</a> <span>&nbsp;</span><strong>Distributors</strong>
        </h3>
        <%} %>
         <% if (Model.RedirectedFrom == "BranchDistributorManagement")
            { %>
         <h3>
            <a href="#">Distributor Management</a> <span>&nbsp;</span><strong>Distributors</strong>
        </h3>
        <%} %>
     
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
                <th style="text-align:center">Action</th>
            </thead>
            <%if (Model.AgentsList != null && Model.AgentsList.Count() > 0)
              { %>
            <% var sno = 0;
               foreach (var item in Model.AgentsList)
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
                    <td><%: item.BranchOfficeName %></td>
                    <td><%: item.DistributorName %></td>
                    <td>
                        <%: item.AgentName%>
                    </td>
                    <td>
                        <%: item.AgencyCode%>
                    </td>
                    <td>
                        <%: item.AgencyEmail%>
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
                        <%: item.CreatedOn.ToString("dd MMM yyyy")%>
                    </td>
                    <td>
                        <%if (Model.AgentStatus == true)
                          { %>
                       
                        <p>
                         <a href="/Administrator/BranchDistributorAgent/Edit/<%:item.AgentId %>?BOId=<%:Model.BranchOfficeId %>" title="Edit">Edit</a>&nbsp;|&nbsp;
                            <a href="/Administrator/BranchDistributorAgentSetting/Index/<%:item.AgentId %>?BOId=<%:Model.BranchOfficeId %>" title="Agent User">(Settings)</a>
                             
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
    <%if (Model.AgentsList != null && Model.AgentsList.Count > 0)
      { %>
    <div class="pager">
        <%= Html.Pager(ViewData.Model.AgentsList.PageSize, ViewData.Model.AgentsList.PageNumber, ViewData.Model.AgentsList.TotalItemCount)%>
    </div>
    <%} %>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CssContent" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
</asp:Content>
