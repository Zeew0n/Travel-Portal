<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/AdministratorMain.Master" Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Administrator.Models.AvailableBalanceModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">



     <div class="pageTitle">
       
        <h3>
            <a href="#">Reports</a> <span>&nbsp;</span><strong>Available Balance</strong>
        </h3>
    </div>

    <div class="contentGrid">
    <table cellspacing="0" cellpadding="0" border="0" style="border-collapse: collapse;"
            class="GridView" width="100%">
            <thead>
                <th>Agent</th>
                <th colspan="7" style="text-align:center;">Currency</th>
                
            </thead>
            <tbody>
                <tr>
                    <td></td>
                    <td colspan="3" style="text-align:center; background:#ebeced; border-right:1px solid #59676a; border-left:1px solid #59676a; text-indent:-20px;"><strong>NPR</strong></td>
                    <td colspan="3" style="text-align:center; background:#ebeced; border-right:1px solid #59676a;"><strong>USD</strong></td>
                  <%--  <td colspan="2" style="text-align:center; background:#ebeced; border-right:1px solid #59676a;"><strong>INR</strong></td>--%>
                </tr>
                <tr>
                    <td></td>
                    <td style="background:#ebeced; border-right:1px solid #59676a; border-left:1px solid #59676a;">CreditLimit</td>
                    <td style="background:#ebeced; border-right:1px solid #59676a;">Balance</td>
                    <td style="background:#ebeced; border-right:1px solid #59676a;">Ledger</td>

                    <td style="background:#ebeced; border-right:1px solid #59676a;">CreditLimit</td>
                    <td style="background:#ebeced; border-right:1px solid #59676a;">Balance</td>
                     <td style="background:#ebeced; border-right:1px solid #59676a;">Ledger</td>

                    <%--<td style="background:#ebeced; border-right:1px solid #59676a;">CreditLimit</td>
                    <td style="background:#ebeced; border-right:1px solid #59676a;">Balance</td>--%>
                </tr>
            </tbody>





             <% if (Model.AvailableBalanceList != null)
       { %>

       <% foreach (var item in Model.AvailableBalanceList)
          {
           %>
           <tr>
           <td > <strong> <%: String.Format("{0:F}", item.AgentName)%></strong></td>
          

           <% foreach (var currency in item.CurrencyList)
              {%>

         <% if (currency.CurrenyCode != "INR")
            { %>
            <td style="border-left:1px solid #59676a;">
            <%: currency.CreditLimit%>
            </td>
              <td style="border-right:1px solid #59676a;">
                <%: currency.Amount%>
            </td>
            <td style="border-right:1px solid #59676a;">
            <%:currency.LedgerAmount%>
            </td>
            <%} %>

           
            <%} %>
           </tr>

           <%} %>

       <%} %>


</table>
    </div>
            


   
  
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="CssContent" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
</asp:Content>

