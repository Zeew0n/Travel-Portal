<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/AdministratorMain.Master" Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Administrator.Models.AgentReportModel>" %>

<%@ Import Namespace="ATLTravelPortal.Helpers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Index
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<% Html.EnableClientValidation(); %>
     <% using (Html.BeginForm())
        { %>

         <div class="pageTitle">
       
        <h3>
            <a href="#">Reports</a> <span>&nbsp;</span><strong>Agent Information</strong>
        </h3>
    </div>
   
   <% Html.RenderPartial("~/Views/Shared/ExportData.ascx"); %>
   
   <%} %>

      <div class="contentGrid" style="width:100%; overflow:auto;">
        <table cellspacing="0" cellpadding="0" border="0" style="border-collapse: collapse;"
            class="GridView" width="100%">
            <thead>
            <tr>
                <th>
                    SN
                </th>
                <th>
                Branch Office
                </th>
                <th>
                Distributor
                </th>
                <th>
                   Agent Name
                </th>
                <th>
                  Agent Code
                </th>
                <th>
                MEs Name
                </th>
                <th>
                    Address
                </th>
                <th>
                    Email
                </th>
                <th>
                Phone
                </th>
              <th>
              Mobile No
              </th>
              <th>
              Zone Name
              </th>
              <th>
              District Name
              </th>
              <th>
              Signup By
              </th>
              <th>
              Signup Date
              </th>
              <th>
                    Reg By
                </th>
                </tr>
            </thead>
            <%
         if (Model != null)
         {
            %>
            <% var sno = 0;

               foreach (var item in Model.AgentDetailList)
               {
                   //sno++;
                   var classTblRow = (sno % 2 == 0) ? "GridAlter" : "GridItem";
            %>
            <tbody>
                <tr id="tr_<%=sno %>" class="<%: classTblRow %>" onmouseover="this.className='GridRowOver'"
                    onmouseout="this.className='<%= classTblRow %>'">
                    <td>
                        <%:item.SNO%>
                    </td>
                    <td>
                    <%: item.BranchName %>
                    </td>
                    <td>
                    <%: item.DistributorName %>
                    </td>
                    <td>
                        <%:item.AgentName%>
                    </td>
                     <td>
                        <%:item.AgentCode%>
                    </td>
                    <td>
                    <%: item.MEsName %>
                    </td>
                    <td>
                        <%:item.Address%>
                    </td>
                    <td>
                     <%:item.Email%>
                    </td>
                    <td>
                     <%:item.Phone%>
                    </td>
                    <td>
                    <%: item.mobile %>
                    </td>
                    <td>
                    <%: item.zonename %>
                    </td>
                    <td>
                    <%: item.districtname %>
                    </td>
                    <td>
                    <%: item.signupby %>
                    </td>
                    <td>
                    <%: TimeFormat.DateFormat( item.SignupDate.ToString()) %>
                    </td>
                    <td>
                    <% if (item.Type == -1)
                       { %> Admin <%}
                       else
                       {%>
                       Self
                       <%} %>
                    </td>
                </tr>
            </tbody>
            <%}
         } %>
        </table>
        <div class="Adminpager">
       <%= Html.Pager(ViewData.Model.AgentDetailList.PageSize, ViewData.Model.AgentDetailList.PageNumber, ViewData.Model.AgentDetailList.TotalItemCount)%>
       </div>
    </div>
    
</asp:Content>


<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
    <script src="../../../../Scripts/ATL.function.js" type="text/javascript"></script>
</asp:Content>