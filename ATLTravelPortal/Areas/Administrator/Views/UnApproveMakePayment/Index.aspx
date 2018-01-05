<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/AdministratorMain.Master" Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Administrator.Models.UnApproveMakePaymentModel>" %>
<%@ Import Namespace="ATLTravelPortal.Helpers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Unapproved Cash Deposit
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
        <div class="pageTitle">
            <div class="float-right">
                <ul>
                    <li>
                        <%:Html.ActionLink("Cancel", "Index", new { controller = "MakeAgentPayment" }, new { @class = "linkButton" })%>
                    </li>
                </ul>
            </div>
            <h3>
               
                
            <a href="#">Account</a> <span>&nbsp;</span><strong>Unapprove Payment</strong>
        </h3>
           
        </div>
      <table cellspacing="0" cellpadding="0" border="0" style="border-collapse: collapse;"
            class="GridView" width="100%">
             <thead>
        <tr>
            <th>
                Agent
            </th>
            <th>
            Agent Code
            </th>
            <th>
                Payment Mode
            </th>
            <th>
                Deposit Amount
            </th>
            <th>
                Deposit Date
            </th>
            <th>
            Action
            </th>
        </tr>
        </thead>


    <% foreach (var item in Model.UnAppoveMakePaymentList)
       { %>
    
        <tr>
           
            <td>
                <%: item.AgentName %> 
            </td>
            <td>
            <%: item.AgentCode %>
            </td>

           <% if (item.PaymentModeId == 1)
              { %>
            <td>
              <label> Cheque</label> 
            </td>
            <%} %>
            <% else if (item.PaymentModeId == 2)
              { %>
              <td><label>Draft</label></td>
            <%} %>
            <% else if (item.PaymentModeId == 3)
              {%>
              <td><label>Cash</label></td>
            <%} %>
             <% else if (item.PaymentModeId == 4)
              {%>
              <td><label>Bank Transfer</label></td>
            <%} %>
             <% else if (item.PaymentModeId == 5)
              {%>
              <td><label>RTGS</label></td>
            <%} %>
             <% else if (item.PaymentModeId == 6)
              {%>
              <td><label>Cash Given To</label></td>
            <%} %>

            <%if (item.PaymentModeId == 1)
              { %>
              <td><%:item.ChequeAmount%></td>
            
            <%} %>
            <%else if (item.PaymentModeId == 2)
              { %>
              <td>
                <%:item.DraftAmount%>
            </td>
             
            <%} %>
             <%else if (item.PaymentModeId == 3)
              { %>
              <td> <%:item.CashAmount%></td>
            <%} %>
             <%else if (item.PaymentModeId == 4)
              { %>
              <td> <%:item.BankTransferAmount%></td>
            <%} %>
             <%else if (item.PaymentModeId == 5)
              { %>
              <td> <%:item.RTGSAmount%></td>
            <%} %>
             <%else if (item.PaymentModeId == 6)
              { %>
              <td><%:item.CashGivenToAmount%></td>
            <%} %>

            <% if (item.PaymentModeId == 1)
               { %>
               <td> <%:TimeFormat.DateFormat(item.ChequeIssueDate.ToString())%></td>
           
            <%} %>
            <%else if (item.PaymentModeId == 2)
              { %>
               <td>
                <%: TimeFormat.DateFormat( item.DraftDepositDate.ToString())%>
            </td>
            <%} %>
            <%else if (item.PaymentModeId == 3)
              { %>
              <td> <%: TimeFormat.DateFormat(item.CashDepositDate.ToString())%></td>
            <%} %>
             <%else if (item.PaymentModeId == 4)
              { %>
              <td>  <%:TimeFormat.DateFormat(item.BankTransferDepositDate.ToString())%></td>
            <%} %>
             <%else if (item.PaymentModeId == 5)
              { %>
              <td><%:TimeFormat.DateFormat(item.RTGSDepositDate.ToString())%></td>
            <%} %>
             <%else if (item.PaymentModeId == 6)
              { %>
              <td>  <%: TimeFormat.DateFormat(item.CashGivenToDepositDate.ToString())%></td>
            <%} %>


           
             <td>
                <%: Html.ActionLink("Details", "Details", new { id = item.DepositId })%>
            </td>
          
        </tr>
    
    <% } %>

    </table>
    <br />
    
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="CssContent" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
</asp:Content>