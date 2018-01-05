<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/DistributorMain.Master" Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Administrator.Models.MakePaymentModel>" %>

<%@ Import Namespace="ATLTravelPortal.Helpers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Make Payment
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <div class="pageTitle">
            <div class="float-right">
                <ul>
                    <li>
                        <%:Html.ActionLink("Create New", "Create", new { controller = "DistributorMakePayment" }, new { @class = "linkButton" })%>
                        <%-- <%:Html.ActionLink("Online Bank Payment", "StartPayment", new { controller = "PaymentGateway" }, new { @class = "linkButton" })%>--%>
                    </li>
                </ul>
            </div>
            <h3>
                <a class="icon_plane" href="#">Account</a> <span>&nbsp;</span><strong> Make Payment</strong>
            </h3>
        </div>
    </div>
    		
		<div id="tabs-left">
	<ul>
		<li><a href="#tabs-left-1">Cheque</a></li>
		<li><a href="#tabs-left-2">Draft</a></li>
		<li><a href="#tabs-left-3">Cash</a></li>
        <li><a href="#tabs-left-4">Bank Transfer</a></li>
        <li><a href="#tabs-left-5">RTGS</a></li>
        <li><a href="#tabs-left-6">Cash Given To</a></li>
         <li><a href="#tabs-left-7">Credit Request</a></li>
	</ul>
	<div id="tabs-left-1">
         <% if (Model.ChequeList != null && Model.ChequeList.Count() > 0)
       { %>
    <div class="contentGrid">
      
        <table cellspacing="0" cellpadding="0" border="0" style="border-collapse: collapse;"
            class="GridView" width="100%">
            <colgroup>
                <col width="10%" />
                <col width="22.5%" />
                <col width="22.5%" />
                <col width="22.5%" />
                <col width="22.5%" />
            </colgroup>
            <thead>
                <th>
                    SN
                </th>
                <th>
                    Deposit Amount
                </th>
                <th>
                Currency
                </th>
                <th>
                    Deposit Date
                </th>
                <th>
                    Status
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

               foreach (var item in Model.ChequeList)
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
                        <%:string.Format("{0:#,#,#}",item.ChequeAmount)%>
                    </td>
                    <td>
                    <%: item.ChequeCurrencyName %>
                    </td>
                    <td>
                        <%: TimeFormat.DateFormat( item.ChequeIssueDate.ToString())%>
                    </td>
                   
                    <% if (item.status == 1)
                       { %>
                    <td>
                        Approved
                    </td>
                    <%} %>
                    <% else if (item.status == 2)
                       { %>
                    <td>
                        Processing
                    </td>
                    <%} %>
                    <% else if (item.status == 3)
                       { %>
                    <td>
                        Rejected
                    </td>
                    <%} %>
                   
                    <td>
                        <a href="/Administrator/DistributorMakePayment/Detail/<%:item.DepositId %>" class="details" title="Details">
                        </a>
                        <%if (item.status != 1 && item.status != 3)
                          { %>
                        <a href="/Administrator/DistributorMakePayment/Edit/<%:item.DepositId %>" class="edit" title="Edit">
                        </a>
                        <%} %>
                        <% if (item.status != 1)
                           { %>
                        <a href="/Administrator/DistributorMakePayment/Delete/<%:item.DepositId %>" class="delete" title="Delete"
                            onclick="return confirm('Are you sure you want to delete?')"></a>
                            <%} %>
                    </td>
                </tr>
            </tbody>
            <%}
                } %>
        </table>
    </div>
    <%} %>
	</div>
	<div id="tabs-left-2">
		    <%if (Model.DraftList != null && Model.DraftList.Count() > 0)
      { %>
    <div class="contentGrid">
    
        <table cellspacing="0" cellpadding="0" border="0" style="border-collapse: collapse;"
            class="GridView" width="100%">
            <colgroup>
                <col width="10%" />
                <col width="22.5%" />
                <col width="22.5%" />
                <col width="22.5%" />
                <col width="22.5%" />
            </colgroup>
            <thead>
                <th>
                    SN
                </th>
                <th>
                    Deposit Amount
                </th>
                <th>Currency</th>
                <th>
                    Deposit Date
                </th>
                <th>
                    Status
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

               foreach (var item in Model.DraftList)
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
                        <%:string.Format("{0:#,#,#}",item.DraftAmount)%>
                    </td>
                    <td><%: item.DraftCurrencyName %></td>
                    <td>
                        <%: TimeFormat.DateFormat(item.DraftDepositDate.ToString())%>
                    </td>
                   
                    <% if (item.status == 1)
                       { %>
                    <td>
                        Approved
                    </td>
                    <%} %>
                    <% else if (item.status == 2)
                       { %>
                    <td>
                        Processing
                    </td>
                    <%} %>
                    <% else if (item.status == 3)
                       { %>
                    <td>
                        Rejected
                    </td>
                    <%} %>
                   
                    <td>
                        <a href="/Administrator/DistributorMakePayment/Detail/<%:item.DepositId %>" class="details" title="Details">
                        </a>
                        <%if (item.status != 1 && item.status != 3)
                          { %>
                        <a href="/Administrator/DistributorMakePayment/Edit/<%:item.DepositId %>" class="edit" title="Edit">
                        </a>
                        <%} %>
                         <% if (item.status != 1)
                            { %>
                        <a href="/Administrator/DistributorMakePayment/Delete/<%:item.DepositId %>" class="delete" title="Delete"
                            onclick="return confirm('Are you sure you want to delete?')"></a>
                            <%} %>
                    </td>
                </tr>
            </tbody>
            <%}
          } %>
        </table>
    </div>
    <%} %>
	</div>
	<div id="tabs-left-3">
		
    <%if (Model.CashList != null && Model.CashList.Count() > 0)
      { %>
    <div class="contentGrid">
      
        <table cellspacing="0" cellpadding="0" border="0" style="border-collapse: collapse;"
            class="GridView" width="100%">
            <colgroup>
                <col width="10%" />
                <col width="22.5%" />
                <col width="22.5%" />
                <col width="22.5%" />
                <col width="22.5%" />
            </colgroup>
            <thead>
                <th>
                    SN
                </th>
                <th>
                    Deposit Amount
                </th>
                <th>Currency</th>
                <th>
                    Deposit Date
                </th>

                <th>
                    Status
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

               foreach (var item in Model.CashList)
               {
                   sno++;
                   var classTblRow = (sno % 2 == 0) ? "GridAlter" : "GridItem";
            %>
            <tbody>
                <tr id="tr2" class="<%: classTblRow %>" onmouseover="this.className='GridRowOver'"
                    onmouseout="this.className='<%= classTblRow %>'">
                    <td>
                        <%:sno%>
                    </td>
                    <td>
                        <%:string.Format("{0:#,#,#}",item.CashAmount)%>
                    </td>
                    <td><%:item.CashCurrencyName %></td>
                    <td>
                        <%:TimeFormat.DateFormat(item.CashDepositDate.ToString())%>
                    </td>
                   
                    <% if (item.status == 1)
                       { %>
                    <td>
                        Approved
                    </td>
                    <%} %>
                    <% else if (item.status == 2)
                       { %>
                    <td>
                        Processing
                    </td>
                    <%} %>
                    <% else if (item.status == 3)
                       { %>
                    <td>
                        Rejected
                    </td>
                    <%} %>

                  
                    <td>
                        <a href="/Administrator/DistributorMakePayment/Detail/<%:item.DepositId %>" class="details" title="Details">
                        </a>
                        <%if (item.status != 1 && item.status != 3)
                          { %>
                        <a href="/Administrator/DistributorMakePayment/Edit/<%:item.DepositId %>" class="edit" title="Edit">
                        </a>
                        <%} %>
                         <% if (item.status != 1)
                            { %>
                        <a href="/Administrator/DistributorMakePayment/Delete/<%:item.DepositId %>" class="delete" title="Delete"
                            onclick="return confirm('Are you sure you want to delete?')"></a>
                            <%} %>
                    </td>
                </tr>
            </tbody>
            <%}
          } %>
        </table>
    </div>
    <%} %>
	</div>
    <div id="tabs-left-4">
        <% if (Model.BankTransferList != null && Model.BankTransferList.Count() > 0)
       { %>
    <div class="contentGrid">
    
        <table cellspacing="0" cellpadding="0" border="0" style="border-collapse: collapse;"
            class="GridView" width="100%">
            <colgroup>
                <col width="10%" />
                <col width="22.5%" />
                <col width="22.5%" />
                <col width="22.5%" />
                <col width="22.5%" />
            </colgroup>
            <thead>
                <th>
                    SN
                </th>
                <th>
                    Deposit Amount
                </th>
                <th>Currency</th>
                <th>
                    Deposit Date
                </th>
                <th>
                    Status
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

               foreach (var item in Model.BankTransferList)
               {
                   sno++;
                   var classTblRow = (sno % 2 == 0) ? "GridAlter" : "GridItem";
            %>
            <tbody>
                <tr id="tr3" class="<%: classTblRow %>" onmouseover="this.className='GridRowOver'"
                    onmouseout="this.className='<%= classTblRow %>'">
                    <td>
                        <%:sno%>
                    </td>
                    <td>
                        <%:string.Format("{0:#,#,#}",item.BankTransferAmount)%>
                    </td>
                    <td><%: item.BankTransferCurrencyName %></td>
                    <td>
                        <%:TimeFormat.DateFormat(item.BankTransferDepositDate.ToString())%>
                    </td>
                   
                    <% if (item.status == 1)
                       { %>
                    <td>
                        Approved
                    </td>
                    <%} %>
                    <% else if (item.status == 2)
                       { %>
                    <td>
                        Processing
                    </td>
                    <%} %>
                    <% else if (item.status == 3)
                       { %>
                    <td>
                        Rejected
                    </td>
                    <%} %>
                  
                    <td>
                        <a href="/Administrator/DistributorMakePayment/Detail/<%:item.DepositId %>" class="details" title="Details">
                        </a>
                        <%if (item.status != 1 && item.status != 3)
                          { %>
                        <a href="/Administrator/DistributorMakePayment/Edit/<%:item.DepositId %>" class="edit" title="Edit">
                        </a>
                        <%} %>
                         <% if (item.status != 1)
                            { %>
                        <a href="/Administrator/DistributorMakePayment/Delete/<%:item.DepositId %>" class="delete" title="Delete"
                            onclick="return confirm('Are you sure you want to delete?')"></a>
                            <%} %>
                    </td>
                </tr>
            </tbody>
            <%}
           } %>
        </table>
    </div>
    <%} %>
    </div>
     <div id="tabs-left-5">
     
    <%if (Model.RTGSList != null && Model.RTGSList.Count() > 0)
      { %>
    <div class="contentGrid">
  
        <table cellspacing="0" cellpadding="0" border="0" style="border-collapse: collapse;"
            class="GridView" width="100%">
            <colgroup>
                <col width="10%" />
                <col width="22.5%" />
                <col width="22.5%" />
                <col width="22.5%" />
                <col width="22.5%" />
            </colgroup>
            <thead>
                <th>
                    SN
                </th>
                <th>
                    Deposit Amount
                </th>
                <th>Currency</th>
                <th>
                    Deposit Date
                </th>
                <th>
                    Status
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

               foreach (var item in Model.RTGSList)
               {
                   sno++;
                   var classTblRow = (sno % 2 == 0) ? "GridAlter" : "GridItem";
            %>
            <tbody>
                <tr id="tr4" class="<%: classTblRow %>" onmouseover="this.className='GridRowOver'"
                    onmouseout="this.className='<%= classTblRow %>'">
                    <td>
                        <%:sno%>
                    </td>
                    <td>
                        <%:string.Format("{0:#,#,#}",item.RTGSAmount)%>
                    </td>
                    <td><%: item.RTGSCurrencyName %></td>
                    <td>
                        <%:TimeFormat.DateFormat(item.RTGSDepositDate.ToString())%>
                    </td>
                    
                    <% if (item.status == 1)
                       { %>
                    <td>
                        Approved
                    </td>
                    <%} %>
                    <% else if (item.status == 2)
                       { %>
                    <td>
                        Processing
                    </td>
                    <%} %>
                    <% else if (item.status == 3)
                       { %>
                    <td>
                        Rejected
                    </td>
                    <%} %>
                  
                    <td>
                        <a href="/Administrator/DistributorMakePayment/Detail/<%:item.DepositId %>" class="details" title="Details">
                        </a>
                        <%if (item.status != 1 && item.status != 3)
                          { %>
                        <a href="/Administrator/DistributorMakePayment/Edit/<%:item.DepositId %>" class="edit" title="Edit">
                        </a>
                        <%} %>
                         <% if (item.status != 1)
                            { %>
                        <a href="/Administrator/DistributorMakePayment/Delete/<%:item.DepositId %>" class="delete" title="Delete"
                            onclick="return confirm('Are you sure you want to delete?')"></a>
                            <%} %>
                    </td>
                </tr>
            </tbody>
            <%}
          } %>
        </table>
    </div>
    <%} %>
    </div>
     <div id="tabs-left-6">
         <%if (Model.CashGivenToList != null && Model.CashGivenToList.Count() > 0)
      { %>
    <div class="contentGrid">
        <table cellspacing="0" cellpadding="0" border="0" style="border-collapse: collapse;"
            class="GridView" width="100%">
            <colgroup>
                <col width="10%" />
                <col width="22.5%" />
                <col width="22.5%" />
                <col width="22.5%" />
                <col width="22.5%" />
            </colgroup>
            <thead>
                <th>
                    SN
                </th>
                <th>
                    Deposit Amount
                </th>
                <th>Currency</th>
                <th>
                    Deposit Date
                </th>
                <th>
                    Status
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

               foreach (var item in Model.CashGivenToList)
               {
                   sno++;
                   var classTblRow = (sno % 2 == 0) ? "GridAlter" : "GridItem";
            %>
            <tbody>
                <tr id="tr5" class="<%: classTblRow %>" onmouseover="this.className='GridRowOver'"
                    onmouseout="this.className='<%= classTblRow %>'">
                    <td>
                        <%:sno%>
                    </td>
                    <td>
                        <%:string.Format("{0:#,#,#}",item.CashGivenToAmount)%>
                    </td>
                    <td><%: item.CashGivenToCurrencyName %></td>
                    <td>
                        <%: TimeFormat.DateFormat(item.CashGivenToDepositDate.ToString())%>
                    </td>
                   
                    <% if (item.status == 1)
                       { %>
                    <td>
                        Approved
                    </td>
                    <%} %>
                    <% else if (item.status == 2)
                       { %>
                    <td>
                        Processing
                    </td>
                    <%} %>
                    <% else if (item.status == 3)
                       { %>
                    <td>
                        Rejected
                    </td>
                    <%} %>
                    
                    <td>
                        <a href="/Administrator/DistributorMakePayment/Detail/<%:item.DepositId %>" class="details" title="Details">
                        </a>
                        <%if (item.status != 1 && item.status != 3)
                          { %>
                        <a href="/Administrator/DistributorMakePayment/Edit/<%:item.DepositId %>" class="edit" title="Edit">
                        </a>
                        <%} %>
                         <% if (item.status != 1)
                            { %>
                        <a href="/Administrator/DistributorMakePayment/Delete/<%:item.DepositId %>" class="delete" title="Delete"
                            onclick="return confirm('Are you sure you want to delete?')"></a>
                            <%} %>
                    </td>
                </tr>
            </tbody>
            <%}
          } %>
        </table>
    </div>
    <%} %>
    </div>
     <div id="tabs-left-7">

    <%if (Model.CreditList != null && Model.CreditList.Count() > 0)
      { %>
    <div class="contentGrid">
      
        <table cellspacing="0" cellpadding="0" border="0" style="border-collapse: collapse;"
            class="GridView" width="100%">
            <colgroup>
                <col width="10%" />
                <col width="22.5%" />
                <col width="22.5%" />
                <col width="22.5%" />
                <col width="22.5%" />
            </colgroup>
            <thead>
                <th>
                    SN
                </th>
                <th>
                    Credit Amount
                </th>
                <th>Currency</th>
                <th>
                    Status
                </th>
                <th>
                     Date
                </th>
                <th>Remarks</th>
                 <th>
                    
                </th>
            </thead>
            <%
          if (Model != null)
          {
            %>
            <% var sno = 0;

               foreach (var item in Model.CreditList)
               {
                   sno++;
                   var classTblRow = (sno % 2 == 0) ? "GridAlter" : "GridItem";
            %>
            <tbody>
                <tr id="tr6" class="<%: classTblRow %>" onmouseover="this.className='GridRowOver'"
                    onmouseout="this.className='<%= classTblRow %>'">
                    <td>
                        <%:sno%>
                    </td>
                    <td>
                        <%:string.Format("{0:#,#,#}",item.CreditAmount)%>
                    </td>
                    <td><%: item.CreditRequestCurrencyName %></td>
                   
                  <td><%:item.CreditRequestStatus %></td>
                   <td>
                        <%: TimeFormat.DateFormat(item.CreditRequestDate.ToString())%>
                    </td>
                    <td><%:item.CreditRequestRemakrs %></td>
                  
                    <td></td>
                </tr>
            </tbody>
            <%
               }
          } %>
        </table>
    </div>
    <%} %>
    </div>
</div>


</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CssContent" runat="server">
  <link href="../../../../Content/themes/redmond/jquery.ui.all.css" rel="stylesheet"
        type="text/css" />
    <link href="../../../../Content/themes/redmond/jquery.ui.base.css" rel="stylesheet"
        type="text/css" />
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
<script type="text/javascript">
    $(function () {
        $("#tabs-left").tabs({
            collapsible: false
        });
    });
</script>
 </asp:Content>