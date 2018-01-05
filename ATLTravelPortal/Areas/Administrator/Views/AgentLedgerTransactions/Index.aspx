<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/AdministratorMain.Master"
    Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Administrator.Models.AgentLedgerTransactionsModel>" %>

<%@ Import Namespace="ATLTravelPortal.Helpers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Index
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <% Html.EnableClientValidation(); %>
    <% using (Html.BeginForm())
       {%>
    <%: Html.ValidationSummary(true) %>
    <div class="pageTitle">
        <h3>
            <a href="#">Reports</a> <span>&nbsp;</span><strong>Transaction Report</strong>
        </h3>
    </div>
    <div class="row-1">
        <div class="form-box1-row">
            <div class="form-box1-row-content float-left">
                <div>
                    <%: Html.LabelFor(model => model.FromDate) %>
                    <%: Html.TextBox("FromDate", (Model != null && Model.FromDate != null && Model.FromDate != DateTime.MinValue) ?
                            (TimeFormat.DateFormat(Model.FromDate.ToString())) :
                            (TimeFormat.DateFormat(TimeFormat.DateFormat(DateTime.Today.ToString()))))%>
                    <%: Html.ValidationMessageFor(model => model.FromDate) %>
                </div>
            </div>
            <div class="form-box1-row-content float-right">
                <div>
                    <%: Html.LabelFor(model => model.ToDate) %>
                    <%: Html.TextBox("ToDate", (Model != null && Model.ToDate != null && Model.ToDate != DateTime.MinValue) ?
                            (TimeFormat.DateFormat(Model.ToDate.ToString())) :
                            (TimeFormat.DateFormat(TimeFormat.DateFormat(DateTime.Today.ToString()))))%>
                    <%: Html.ValidationMessageFor(model => model.ToDate) %>
                </div>
            </div>
        </div>
        <div class="form-box1-row">
            <div class="form-box1-row-content float-left">
                <div>
                    <%: Html.LabelFor(model => model.AgentName) %>
                    <%:Html.DropDownListFor(model => model.AgentId, Model.AgentList,"----All---")%>
                    <%: Html.ValidationMessageFor(model => model.AgentId, "*")%>
                </div>
            </div>
        </div>
        <div class="form-box1-row">
            <div class="form-box1-row-content float-left">
                <div>
                    <%: Html.LabelFor(model => model.CurrencyId)%>
                    <%:Html.DropDownListFor(model => model.CurrencyId, (SelectList)ViewData["Currency"])%>
                    <%: Html.ValidationMessageFor(model => model.CurrencyId, "*")%>
                </div>
            </div>
        </div>
        <div class="buttonBar">
            <input type="submit" value="Submit" />
        </div>
    </div>
    <br />
    <% } %>
    <table cellspacing="0" cellpadding="0" border="0" style="border-collapse: collapse; border:1px solid #ccc;"
        class="GridView" width="100%">
        <thead>
            <tr>
                <th>
                    Sno
                </th>
                <th>
                    Date
                </th>
                <th>
                    Voucher
                </th>
                <th>
                    Narration
                </th>
                <th>
                    Dr
                </th>
                <th>
                    Cr
                </th>
                <th>
                    Balance
                </th>
                <th>
                </th>
            </tr>
        </thead>
        <% if (Model.LedgerList != null)
           { %>
        <% var sno = 0;
           foreach (var item in Model.LedgerList)
           {
               sno++;%>
        <tr>
            <td>
                <%:sno%>
            </td>
            <td>
                <%: ATLTravelPortal.Helpers.TimeFormat.DateFormat(item.TranDate.ToString())%>
            </td>
            <td>
                <%:item.VoucherNumber.ToString().PadLeft(4,'0') %>
            </td>
            <td>
                <%: item.Narration1 %>
            </td>
            <td>
                <%: String.Format("{0:F}", item.DrAmount) %>
            </td>
            <td>
                <%: String.Format("{0:F}", item.CrAmount) %>
            </td>
            <td>
                <%: String.Format("{0:F}", item.Balance) %>
            </td>
            <td>
                <%: item.DrCr %>
            </td>
        </tr>
        <% } %>
        <% } %>
        

        <tr>
        <td colspan="8"><br /><br />
        <%if (Model.AgentId != null && Model.AvailableBalance != null)
      { %>
    <table cellspacing="0" cellpadding="0" border="0" style="border-collapse: collapse; border:1px solid #ccc;"
        class="GridView" width="100%">
        <tr>
            <td colspan="3">
                Actual Balance
            </td>
            <td colspan="4" style="text-align:right;">
                <%:(Model.CurrencyId==1? Model.AvailableBalance.CurrentBalanceNPR:(Model.CurrencyId==2?Model.AvailableBalance.CurrentBalanceUSD:(Model.CurrencyId==3?Model.AvailableBalance.CurrentBalanceINR:0))) %>
            </td>
            <td style="width:15px;">
                Dr
            </td>
        </tr>
        <tr>
            <td colspan="3">
                Credit Limit
            </td>
          
            <td colspan="4" style="text-align:right;">
                <%:(Model.CurrencyId == 1 ? Model.AvailableBalance.CreditLimitNPR : (Model.CurrencyId == 2 ? Model.AvailableBalance.CreditLimitUSD : (Model.CurrencyId == 3 ? Model.AvailableBalance.CreditLimitINR : 0)))%>
            </td>
            <td style="width:15px;">
                Cr
            </td>
        </tr>
        <tr>
            <td colspan="3">
                Available Balance
            </td>
           
            <td colspan="4" style="text-align:right;">
                <%:(Model.CurrencyId == 1 ? Model.AvailableBalance.LeadgerBalanceNPR : (Model.CurrencyId == 2 ? Model.AvailableBalance.LeadgerBalanceUSD : 0))%>
            </td>
            <td style="width:15px;">
                Cr
            </td>
        </tr>
    </table>
    <%} %>
    </td>
        </tr>

        <tr>
            <td colspan="8">
            <br /><br />
    <%if (Model.AgentId != null && Model.CreditLimitList.Count() > 0)
      { %>
    <table cellspacing="0" cellpadding="0" border="0" style="border-collapse: collapse; border:1px solid #ccc;"
        class="GridView" width="100%">
        <thead>
            <tr>
                <th>
                    Date
                </th>
                <th>
                    Type
                </th>
                <th>
                    Expired On
                </th>
                <th colspan="2">
                    Day Left
                </th>
               
                <th colspan="2" style="text-align:right;">
                    Amount
                </th>
                
                 <th style="width:15px;">
                </th>
            </tr>
        </thead>
        <%foreach (var item in Model.CreditLimitList)
          { %>
        <tr>
            <td>
                <%:item.hdfEffectiveFrom %>
            </td>
            <td>
                <%:item.CreditLimitTypeName %>
            </td>
            <td>
                <%:item.hdfExpireOn %>
            </td>
            <td colspan="2">
               <%:item.DaysLeft%>
            </td>
            
            <td colspan="2" style="text-align:right;">
                <%:item.txtAmount %>
            </td>
            <td>
                Cr
            </td>
        </tr>
        <%} %>
    </table>
    <%} %>
            </td>
        </tr>

    </table>
    
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CssContent" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
    <script type="text/javascript" language="javascript">
        $(document).ready(function () {
            $("#FromDate").datepicker({
                defaultDate: new Date($(this).val()),
                numberOfMonths: 2,
                disable: true,
                buttonImage: '../../Content/images/calendar.gif'
               
            });
        });
        $(document).ready(function () {
            $("#ToDate").datepicker({
                defaultDate: new Date($(this).val()),
                numberOfMonths: 2,
                disable: true,
                buttonImage: '../../Content/images/calendar.gif'               
            });
        });
    </script>
</asp:Content>
