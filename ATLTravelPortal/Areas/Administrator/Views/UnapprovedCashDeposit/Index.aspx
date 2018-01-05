<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/AdministratorMain.Master"
    Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Administrator.Models.UnapprovedCashDepositModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Index
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <div class="pageTitle">
            <h3>
                <a href="#">Account Management</a> <span>&nbsp;</span><strong>Unapprove Cash Deposit</strong>
            </h3>
        </div>
    </div>
    <table cellspacing="0" cellpadding="0" border="0" style="border-collapse: collapse;"
        class="GridView" width="100%">
        <thead>
            <tr>
                <th>
                    Agent
                </th>
                <th>
                    Date
                </th>
                <th>
                    Bank
                </th>
                <th>
                    Branch
                </th>
                <th>
                    Acc. Number
                </th>
                <th>
                    Amount
                </th>
                <th>
                    Currency
                </th>
                <th>
                    Created By
                </th>
                <th>
                    Action
                </th>
            </tr>
        </thead>
        <% foreach (var item in Model.unapprovedCashDepositList)
           { %>
        <tr>
            <td>
                <%: item.AgentName %>
            </td>
            <td>
                <%: String.Format("{0:g}", item.DepositDate) %>
            </td>
            <td>
                <%: item.BankName %>
            </td>
            <td>
                <%: item.BranchName %>
            </td>
            <td>
                <%: item.AccountNumber %>
            </td>
            <td>
                <%: String.Format("{0:F}", item.Amount) %>
            </td>
            <td>
                <%: item.Currency %>
            </td>
            <td>
                <%: item.CreatdBy %>
            </td>
            <td>
                <%: Html.ActionLink("Details", "Details", new { id = item.DepositId })%>
            </td>
        </tr>
        <% } %>
    </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CssContent" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
</asp:Content>
