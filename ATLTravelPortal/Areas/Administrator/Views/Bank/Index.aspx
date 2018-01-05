<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/AdministratorMain.Master"
    Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Administrator.Models.BankModel>" %>

<%@ Import Namespace="ATLTravelPortal.Helpers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Index
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <div class="pageTitle">
            <div class="float-right">
                <ul>
                    <li>
                        <%:Html.ActionLink("New", "Create", new { controller = "Bank" }, new { @class = "linkButton" })%>
                    </li>
                </ul>
            </div>
                        <h3>
            <a href="#">Account Management</a> <span>&nbsp;</span><strong>Bank Management</strong>
        </h3>
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
                    Phone No.
                </th>
                <th>
                    Contact Person
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

               foreach (var item in Model.BankList)
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
                        <%:item.PhoneNo%>
                    </td>
                    <td>
                        <%:item.ContactPerson%>
                    </td>
                    <td>
                        <a href="/Administrator/Bank/Detail/<%:item.BankId %>" class="details" title="Details">
                        </a><a href="/Administrator/Bank/Edit/<%:item.BankId %>" class="edit" title="Edit">
                        </a><a href="/Administrator/Bank/Delete/<%:item.BankId %>" class="delete" title="Delete"
                            onclick="return confirm('Are you sure you want to delete?')"></a>
                    </td>
                </tr>
            </tbody>
            <%}
                } %>
        </table>
    </div>
</asp:Content>
