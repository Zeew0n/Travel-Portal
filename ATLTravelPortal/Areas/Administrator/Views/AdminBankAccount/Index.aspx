<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/AdministratorMain.Master" Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Administrator.Models.AdminBankAccountModel>" %>



<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Index
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
     <%Html.RenderPartial("Utility/PVC_MessagePanel"); %>  
    <div>
        <div class="pageTitle">
          
           <div class="float-right">
            <%:Html.ActionLink(" New", "Create", new { controller = "AdminBankAccount" }, new { @class = "linkButton" })%>
           </div>
            <h3>
            <a href="#">Account Management</a> <span>&nbsp;</span><strong>Bank Account</strong>
        </h3>
        </div>
        <div class="buttonBar">
            <ul><li>
             <%Html.RenderPartial("Utility/PVC_MessagePanel"); %> 
            </li>
                <li>
                   <%-- <%:Html.ActionLink(" New", "Create", new { controller = "AdminBankAccount" }, new { @class = "linkButton" })%>--%>
                </li>
            </ul>
        </div>
    </div>
    
    <div class="contentGrid">
        <table cellspacing="0" cellpadding="0" border="0" style="border-collapse: collapse;"
            class="GridView" width="100%">
            <thead>
                <th>
                    SN
                </th>
                <th>
                    Bank
                </th>
                <th>
                    Bank Branch
                </th>
                <th>
                    Bank Account Type
                </th>
                <th>
                    Account Name
                </th>
                <th>
                    Account Number
                </th>
                <th>
                    Action
                </th>
            </thead>
            <%
                if (Model != null)
                {
            %>
            <% var sno = 0;

               foreach (var item in Model.AdminBankAccountList)
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
                        <%:item.BankName%>
                    </td>
                    
                    <td>
                        <%:item.BankBranchName%>
                    </td>
                    <td>
                        <%:item.BankAccountTypeName%>
                    </td>
                    <td>
                        <%:item.AccountName%>
                    </td>
                    <td>
                        <%:item.AccountNumber%>
                    </td>
                   
                     

                    <td>
                        <a href="/Administrator/AdminBankAccount/Detail/<%:item.AdminBankId %>" class="details" title="Details"></a>
                        <a href="/Administrator/AdminBankAccount/Edit/<%:item.AdminBankId %>" class="edit" title="Edit"></a>
                        <a href="/Administrator/AdminBankAccount/Delete/<%:item.AdminBankId %>" class="delete" title="Delete"
                            onclick="return confirm('Are you sure you want to delete?')"></a>
                    </td>
                </tr>
            </tbody>
            <%}
                } %>
        </table>
    </div>
</asp:Content>
