<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/BranchOfficeMain.Master" Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Administrator.Models.MakePaymentModel>" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Create
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <%
        if (TempData["success"] != null)
        { %>
    <%: TempData["success"]%>
    <%
    
        }
    %>
    <% Html.EnableClientValidation(); %>
    <% using (Html.BeginForm("Create", "BranchDistributorPayment", FormMethod.Post))
       {%>
    <%: Html.ValidationSummary(true)%>
    <div class="tbl_Data">
        <ul class="buttons-panel float-right">
             <li>
                <input type="submit" value="Save" class="btn1" />
                </li>
             <li>
                <input type="button" onclick="document.location.href='/Administrator/BranchDistributorPayment/Index'"
                    value="Cancel" />
                    </li>
        </ul>
        <div class="tbl_Data_Tlt">
            <h3>
                <a href="#" class="icon_plane">Make Payment</a> <span>&nbsp;</span><strong> Create</strong>
            </h3>
        </div>
        <div class="radioWithoutWidth">
            <%:Html.RadioButton("rdbPaymentMode", "Cheque", true, new { id = "Cheque", name = "Cheque", title = "Cheque" })%>Cheque&nbsp&nbsp;
            <%:Html.RadioButton("rdbPaymentMode", "Draft", false, new { id = "Draft", name = "Draft", title = "Draft" })%>Draft&nbsp&nbsp;
            <%:Html.RadioButton("rdbPaymentMode", "Cash", false, new { id = "Cash", name = "Cash", title = "Cash" })%>Cash&nbsp&nbsp;
            <%:Html.RadioButton("rdbPaymentMode", "BankTransfer", false, new { id = "BankTransfer", name = "BankTransfer", title = "BankTransfer" })%>Bank
            Transfer&nbsp&nbsp;
            <%:Html.RadioButton("rdbPaymentMode", "RTGS", false, new { id = "RTGS", name = "RTGS", title = "RTGS" })%>RTGS&nbsp&nbsp;
            <%:Html.RadioButton("rdbPaymentMode", "CashGivenTo", false, new { id = "CashGivenTo", name = "CashGivenTo", title = "RTGS" })%>
            Cash Given To
          
        </div>

          <div>
         <br />
        <label> Payment By </label>
        <%:Html.DropDownListFor(model => model.AgentId, Model.AgentList, "-----Select Distributor-----")%>
        <%: Html.ValidationMessageFor(model => model.AgentId, "*")%>
        </div>
       
        <br />
        <br />
        <div id="trCheque">
         <div class="divLeft">
                <%: Html.LabelFor(model => model.ChequeCurrencyId)%>
               <%: Html.DropDownListFor(model => model.ChequeCurrencyId, Model.ChequeCurrencyList)%>
                <%: Html.ValidationMessageFor(model => model.ChequeCurrencyId, "*")%>
            </div>
            <div class="divLeft">
                <%: Html.LabelFor(model => model.ChequeAmount)%>
                <%: Html.TextBoxFor(model => model.ChequeAmount)%>
                <%: Html.ValidationMessageFor(model => model.ChequeAmount, "*")%>
            </div>
            <div class="divLeft">
                <%: Html.LabelFor(model => model.ChequeMobileNumber)%>
                <%: Html.TextBoxFor(model => model.ChequeMobileNumber)%>
                <%: Html.ValidationMessageFor(model => model.ChequeMobileNumber, "*")%>
            </div>
            <div class="divLeft">
                <%: Html.LabelFor(model => model.ChequeTransactionId)%>
                <%: Html.TextBoxFor(model => model.ChequeTransactionId)%>
                <%: Html.ValidationMessageFor(model => model.ChequeTransactionId, "*")%>
            </div>
            <div class="divLeft">
                <%: Html.LabelFor(model => model.ChequeDrawnonBank)%>
                <%:Html.DropDownListFor(model => model.ChequeDrawnonBank, (SelectList)ViewData["ChequeDrawnOnBank"])%>
                <%: Html.ValidationMessageFor(model => model.ChequeDrawnonBank, "*")%>
            </div>
            <div class="divLeft">
                <%: Html.LabelFor(model => model.ChequeIssueDate)%>
                <%: Html.TextBoxFor(model => model.ChequeIssueDate)%>
                <%: Html.ValidationMessageFor(model => model.ChequeIssueDate, "*")%>
            </div>
            <div class="divLeft">
                <%: Html.LabelFor(model => model.ChequeNumber)%>
                <%: Html.TextBoxFor(model => model.ChequeNumber)%>
                <%: Html.ValidationMessageFor(model => model.ChequeNumber, "*")%>
            </div>
            <div class="divLeft">
                <%: Html.LabelFor(model => model.ChequeBankId)%>
                <%:Html.DropDownListFor(model => model.ChequeBankId, (SelectList)ViewData["Bank"])%>
                <%: Html.ValidationMessageFor(model => model.ChequeBankId, "*")%>
            </div>
            <div class="divLeft">
                <%:Html.LabelFor(model => model.ChequeBankBranchId)%>
                <%:Html.DropDownListFor(model => model.ChequeBankBranchId, (SelectList)ViewData["BankBranch"])%>
                <%:Html.ValidationMessageFor(model => model.ChequeBankBranchId, "*")%>
            </div>
            <div class="divLeft">
                <%:Html.LabelFor(model => model.ChequeRemakrs)%>
                <%: Html.TextAreaFor(model => model.ChequeRemakrs,  new { @Style = " width:190px; margin-left:1px; padding:5px;" })%>
            </div>
        </div>
        <div id="trDraft">
         <div class="divLeft">
                <%: Html.LabelFor(model => model.DraftCurrencyId)%>
               <%: Html.DropDownListFor(model => model.DraftCurrencyId, Model.DraftCurrencyList)%>
                <%: Html.ValidationMessageFor(model => model.DraftCurrencyId, "*")%>
            </div>
            <div class="divLeft">
                <%: Html.LabelFor(model => model.DraftAmount)%>
                <%: Html.TextBoxFor(model => model.DraftAmount)%>
                <%: Html.ValidationMessageFor(model => model.DraftAmount, "*")%>
            </div>
            <div class="divLeft">
                <%: Html.LabelFor(model => model.DraftNumber)%>
                <%: Html.TextBoxFor(model => model.DraftNumber)%>
                <%: Html.ValidationMessageFor(model => model.DraftNumber, "*")%>
            </div>
            <div class="divLeft">
                <%: Html.LabelFor(model => model.DraftDepositDate)%>
                <%: Html.TextBoxFor(model => model.DraftDepositDate)%>
                <%: Html.ValidationMessageFor(model => model.DraftDepositDate, "*")%>
            </div>
            <div class="divLeft">
                <%: Html.LabelFor(model => model.DraftBankId)%>
                <%:Html.DropDownListFor(model => model.DraftBankId, (SelectList)ViewData["Bank"])%>
                <%: Html.ValidationMessageFor(model => model.DraftBankId, "*")%>
            </div>
            <div class="divLeft">
                <%:Html.LabelFor(model => model.DraftBankBranchId)%>
                <%:Html.DropDownListFor(model => model.DraftBankBranchId, (SelectList)ViewData["BankBranch"])%>
                <%:Html.ValidationMessageFor(model => model.DraftBankBranchId, "*")%>
            </div>
            <div class="divLeft">
                <%:Html.LabelFor(model => model.DraftRemakrs)%>
                <%: Html.TextAreaFor(model => model.DraftRemakrs, new { @Style = " width:190px; margin-left:1px; padding:5px;" })%>
            </div>
        </div>
        <div id="trCash">
         <div class="divLeft">
                <%: Html.LabelFor(model => model.CashCurrencyId)%>
               <%: Html.DropDownListFor(model => model.CashCurrencyId, Model.CashCurrencyList)%>
                <%: Html.ValidationMessageFor(model => model.CashCurrencyId, "*")%>
            </div>
            <div class="divLeft">
                <%: Html.LabelFor(model => model.CashAmount)%>
                <%: Html.TextBoxFor(model => model.CashAmount)%>
                <%: Html.ValidationMessageFor(model => model.CashAmount, "*")%>
            </div>
            <div class="divLeft">
                <%: Html.LabelFor(model => model.CashDepositDate)%>
                <%: Html.TextBoxFor(model => model.CashDepositDate)%>
                <%: Html.ValidationMessageFor(model => model.CashDepositDate, "*")%>
            </div>
            <div class="divLeft">
                <%: Html.LabelFor(model => model.CashTransactionId)%>
                <%: Html.TextBoxFor(model => model.CashTransactionId)%>
                <%: Html.ValidationMessageFor(model => model.CashTransactionId, "*")%>
            </div>
            <div class="divLeft">
                <%: Html.LabelFor(model => model.CashBankId)%>
                <%:Html.DropDownListFor(model => model.CashBankId, (SelectList)ViewData["Bank"])%>
                <%: Html.ValidationMessageFor(model => model.CashBankId, "*")%>
            </div>
            <div class="divLeft">
                <%:Html.LabelFor(model => model.CashBankBranchId)%>
                <%:Html.DropDownListFor(model => model.CashBankBranchId, (SelectList)ViewData["BankBranch"])%>
                <%:Html.ValidationMessageFor(model => model.CashBankBranchId, "*")%>
            </div>
            <div class="divLeft">
                <%:Html.LabelFor(model => model.CashRemakrs)%>
                <%: Html.TextAreaFor(model => model.CashRemakrs, new { @Style = " width:190px; margin-left:1px; padding:5px;" })%>
            </div>
        </div>
        <div id="trBankTransfer">
         <div class="divLeft">
                <%: Html.LabelFor(model => model.BankTransferCurrencyId)%>
               <%: Html.DropDownListFor(model => model.BankTransferCurrencyId, Model.BankTransferCurrencyList)%>
                <%: Html.ValidationMessageFor(model => model.BankTransferCurrencyId, "*")%>
            </div>
            <div class="divLeft">
                <%: Html.LabelFor(model => model.BankTransferAmount)%>
                <%: Html.TextBoxFor(model => model.BankTransferAmount)%>
                <%: Html.ValidationMessageFor(model => model.BankTransferAmount, "*")%>
            </div>
            <div class="divLeft">
                <%: Html.LabelFor(model => model.BankTransferDepositDate)%>
                <%: Html.TextBoxFor(model => model.BankTransferDepositDate)%>
                <%: Html.ValidationMessageFor(model => model.BankTransferDepositDate, "*")%>
            </div>
            <div class="divLeft">
                <%: Html.LabelFor(model => model.BankTransferMobileNumber)%>
                <%: Html.TextBoxFor(model => model.BankTransferMobileNumber)%>
                <%: Html.ValidationMessageFor(model => model.BankTransferMobileNumber, "*")%>
            </div>
            <div class="divLeft">
                <%: Html.LabelFor(model => model.BankTransferTransactionId)%>
                <%: Html.TextBoxFor(model => model.BankTransferTransactionId)%>
                <%: Html.ValidationMessageFor(model => model.BankTransferTransactionId, "*")%>
            </div>
            <div class="divLeft">
                <%: Html.LabelFor(model => model.BankTransferBankId)%>
                <%:Html.DropDownListFor(model => model.BankTransferBankId, (SelectList)ViewData["Bank"])%>
                <%: Html.ValidationMessageFor(model => model.BankTransferBankId, "*")%>
            </div>
            <div class="divLeft">
                <%:Html.LabelFor(model => model.BankTransferBankBranchId)%>
                <%:Html.DropDownListFor(model => model.BankTransferBankBranchId, (SelectList)ViewData["BankBranch"])%>
                <%:Html.ValidationMessageFor(model => model.BankTransferBankBranchId, "*")%>
            </div>
            <div class="divLeft">
                <%:Html.LabelFor(model => model.BankTransferRemakrs)%>
                <%: Html.TextAreaFor(model => model.BankTransferRemakrs, new { @Style = " width:190px; margin-left:1px; padding:5px;" })%>
            </div>
        </div>
        <div id="trRTGS">
         <div class="divLeft">
                <%: Html.LabelFor(model => model.RTGSCurrencyId)%>
               <%: Html.DropDownListFor(model => model.RTGSCurrencyId, Model.RTGSCurrencyList)%>
                <%: Html.ValidationMessageFor(model => model.RTGSCurrencyId, "*")%>
            </div>
            <div class="divLeft">
                <%: Html.LabelFor(model => model.RTGSAmount)%>
                <%: Html.TextBoxFor(model => model.RTGSAmount)%>
                <%: Html.ValidationMessageFor(model => model.RTGSAmount, "*")%>
            </div>
            <div class="divLeft">
                <%: Html.LabelFor(model => model.RTGSUTRNumber)%>
                <%: Html.TextBoxFor(model => model.RTGSUTRNumber)%>
                <%: Html.ValidationMessageFor(model => model.RTGSUTRNumber, "*")%>
            </div>
            <div class="divLeft">
                <%: Html.LabelFor(model => model.RTGSDepositDate)%>
                <%: Html.TextBoxFor(model => model.RTGSDepositDate)%>
                <%: Html.ValidationMessageFor(model => model.RTGSDepositDate, "*")%>
            </div>
            <div class="divLeft">
                <%: Html.LabelFor(model => model.RTGSBankId)%>
                <%:Html.DropDownListFor(model => model.RTGSBankId, (SelectList)ViewData["Bank"])%>
                <%: Html.ValidationMessageFor(model => model.RTGSBankId, "*")%>
            </div>
            <div class="divLeft">
                <%:Html.LabelFor(model => model.RTGSBankBranchId)%>
                <%:Html.DropDownListFor(model => model.RTGSBankBranchId, (SelectList)ViewData["BankBranch"])%>
                <%:Html.ValidationMessageFor(model => model.RTGSBankBranchId, "*")%>
            </div>
            <div class="divLeft">
                <%:Html.LabelFor(model => model.RTGSRemakrs)%>
                <%: Html.TextAreaFor(model => model.RTGSRemakrs, new { @Style = " width:190px; margin-left:1px; padding:5px;" })%>
            </div>
        </div>
        <div id="trCashGivenTo">
         <div class="divLeft">
                <%: Html.LabelFor(model => model.CashGivenToCurrencyId)%>
               <%: Html.DropDownListFor(model => model.CashGivenToCurrencyId, Model.CashGivenToCurrencyList)%>
                <%: Html.ValidationMessageFor(model => model.CashGivenToCurrencyId, "*")%>
            </div>
            <div class="divLeft">
                <%: Html.LabelFor(model => model.CashGivenToAmount)%>
                <%: Html.TextBoxFor(model => model.CashGivenToAmount)%>
                <%: Html.ValidationMessageFor(model => model.CashGivenToAmount, "*")%>
            </div>
            <div class="divLeft">
                <%: Html.Label("Sales Agent")%>
                <%: Html.DropDownListFor(model => model.SalesAgent, Model.SalesAgentList, "---Select---")%>
                <%: Html.ValidationMessageFor(model => model.SalesAgent, "*")%>
            </div>
            <div class="divLeft">
                <%: Html.LabelFor(model => model.CashGivenToDepositDate)%>
                <%: Html.TextBoxFor(model => model.CashGivenToDepositDate)%>
                <%: Html.ValidationMessageFor(model => model.CashGivenToDepositDate, "*")%>
            </div>
            <div class="divLeft">
                <%:Html.LabelFor(model => model.CashGivenToRemakrs)%>
                <%: Html.TextAreaFor(model => model.CashGivenToRemakrs, new { @Style = " width:190px; margin-left:1px; padding:5px;" })%>
            </div>
        </div>
     
    </div>
    <%} %>
    <br />
    <br />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CssContent" runat="server">
    <link href="../../../../Content/themes/redmond/jquery.ui.all.css" rel="stylesheet"
        type="text/css" />
    <link href="../../../../Content/themes/redmond/jquery.ui.base.css" rel="stylesheet"
        type="text/css" />
        <style type="text/css">
        div.radioWithoutWidth input[type="radio"] { width:auto !important; vertical-align:middle; margin-right:3px;}
        </style>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
    <script src="../../../../Scripts/DynamicValidation.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript">

        $(document).ready(function () {

            maintainControlState();

            // $("input[name$='rdbPaymentMode']").live("click", function () {
            $("input[name$='rdbPaymentMode']").click(function () {

                var radio_value = $(this).val();
                if (radio_value == 'Cheque') {
                    $("#trCheque").children().show();
                    $("#ChequeCurrencyId").removeAttr('disabled');
                    $("#ChequeAmount").removeAttr('disabled');
                    $("#ChequeMobileNumber").removeAttr('disabled');
                    $("#ChequeTransactionId").removeAttr('disabled');
                    $("#ChequeDrawnonBank").removeAttr('disabled');
                    $("#ChequeIssueDate").removeAttr('disabled');
                    $("#ChequeNumber").removeAttr('disabled');
                    $("#ChequeBankId").removeAttr('disabled');
                    $("#ChequeBankBranchId").removeAttr('disabled');
                    $("#ChequeRemakrs").removeAttr('disabled');

                    $("#trDraft").children().hide();
                    $('#DraftCurrencyId').attr('disabled', true);
                    $('#DraftAmount').attr('disabled', true);
                    $('#DraftNumber').attr('disabled', true);
                    $('#DraftDepositDate').attr('disabled', true);
                    $('#DraftBankId').attr('disabled', true);
                    $('#DraftBankBranchId').attr('disabled', true);
                    $('#DraftRemakrs').attr('disabled', true);

                    $("#trCash").children().hide();
                    $('#CashCurrencyId').attr('disabled', true);
                    $('#CashAmount').attr('disabled', true);
                    $('#CashDepositDate').attr('disabled', true);
                    $('#CashTransactionId').attr('disabled', true);
                    $('#CashBankId').attr('disabled', true);
                    $('#CashBankBranchId').attr('disabled', true);
                    $('#CashRemakrs').attr('disabled', true);

                    $("#trBankTransfer").children().hide();
                    $('#BankTransferCurrencyId').attr('disabled', true);
                    $('#BankTransferAmount').attr('disabled', true);
                    $('#BankTransferDepositDate').attr('disabled', true);
                    $('#BankTransferMobileNumber').attr('disabled', true);
                    $('#BankTransferTransactionId').attr('disabled', true);
                    $('#BankTransferBankId').attr('disabled', true);
                    $('#BankTransferBankBranchId').attr('disabled', true);
                    $('#BankTransferRemakrs').attr('disabled', true);

                    $("#trRTGS").children().hide();
                    $('#RTGSCurrencyId').attr('disabled', true);
                    $('#RTGSAmount').attr('disabled', true);
                    $('#RTGSUTRNumber').attr('disabled', true);
                    $('#RTGSDepositDate').attr('disabled', true);
                    $('#RTGSBankId').attr('disabled', true);
                    $('#RTGSBankBranchId').attr('disabled', true);
                    $('#RTGSRemakrs').attr('disabled', true);

                    $("#trCashGivenTo").children().hide();
                    $('#CashGivenToCurrencyId').attr('disabled', true);
                    $('#CashGivenToAmount').attr('disabled', true);
                    $('#SalesAgent').attr('disabled', true);
                    $('#CashGivenToDepositDate').attr('disabled', true);
                    $('#CashGivenToRemakrs').attr('disabled', true);

                    $("#trCreditRequest").children().hide();
                    $('#CreditRequestCurrencyId').attr('disabled', true);
                    $('#CreditAmount').attr('disabled', true);
                    $('#CreditRequestRemakrs').attr('disabled', true);
                }
                else if (radio_value == 'Draft') {

                    $("#trDraft").children().show();
                    $('#DraftCurrencyId').removeAttr('disabled');
                    $('#DraftAmount').removeAttr('disabled');
                    $('#DraftNumber').removeAttr('disabled');
                    $('#DraftDepositDate').removeAttr('disabled');
                    $('#DraftBankId').removeAttr('disabled');
                    $('#DraftBankBranchId').removeAttr('disabled');
                    $('#DraftRemakrs').removeAttr('disabled');


                    $("#trCheque").children().hide();
                    $("#ChequeCurrencyId").attr('disabled', true);
                    $("#ChequeAmount").attr('disabled', true);
                    $("#ChequeMobileNumber").attr('disabled', true);
                    $("#ChequeTransactionId").attr('disabled', true);
                    $("#ChequeDrawnonBank").attr('disabled', true);
                    $("#ChequeIssueDate").attr('disabled', true);
                    $("#ChequeNumber").attr('disabled', true);
                    $("#ChequeBankId").attr('disabled', true);
                    $("#ChequeBankBranchId").attr('disabled', true);
                    $("#ChequeRemakrs").attr('disabled', true);

                    $("#trCash").children().hide();
                    $('#CashCurrencyId').attr('disabled', true);
                    $('#CashAmount').attr('disabled', true);
                    $('#CashDepositDate').attr('disabled', true);
                    $('#CashTransactionId').attr('disabled', true);
                    $('#CashBankId').attr('disabled', true);
                    $('#CashBankBranchId').attr('disabled', true);
                    $('#CashRemakrs').attr('disabled', true);

                    $("#trBankTransfer").children().hide();
                    $('#BankTransferCurrencyId').attr('disabled', true);
                    $('#BankTransferAmount').attr('disabled', true);
                    $('#BankTransferDepositDate').attr('disabled', true);
                    $('#BankTransferMobileNumber').attr('disabled', true);
                    $('#BankTransferTransactionId').attr('disabled', true);
                    $('#BankTransferBankId').attr('disabled', true);
                    $('#BankTransferBankBranchId').attr('disabled', true);
                    $('#BankTransferRemakrs').attr('disabled', true);

                    $("#trRTGS").children().hide();
                    $('#RTGSCurrencyId').attr('disabled', true);
                    $('#RTGSAmount').attr('disabled', true);
                    $('#RTGSUTRNumber').attr('disabled', true);
                    $('#RTGSDepositDate').attr('disabled', true);
                    $('#RTGSBankId').attr('disabled', true);
                    $('#RTGSBankBranchId').attr('disabled', true);
                    $('#RTGSRemakrs').attr('disabled', true);

                    $("#trCashGivenTo").children().hide();
                    $('#CashGivenToCurrencyId').attr('disabled', true);
                    $('#CashGivenToAmount').attr('disabled', true);
                    $('#SalesAgent').attr('disabled', true);
                    $('#CashGivenToDepositDate').attr('disabled', true);
                    $('#CashGivenToRemakrs').attr('disabled', true);

                    $("#trCreditRequest").children().hide();
                    $('#CreditRequestCurrencyId').attr('disabled', true);
                    $('#CreditAmount').attr('disabled', true);
                    $('#CreditRequestRemakrs').attr('disabled', true);
                }
                else if (radio_value == 'Cash') {
                    $("#trCash").children().show();
                    $('#CashCurrencyId').removeAttr('disabled');
                    $('#CashAmount').removeAttr('disabled');
                    $('#CashDepositDate').removeAttr('disabled');
                    $('#CashTransactionId').removeAttr('disabled');
                    $('#CashBankId').removeAttr('disabled');
                    $('#CashBankBranchId').removeAttr('disabled');
                    $('#CashRemakrs').removeAttr('disabled');

                    $("#trDraft").children().hide();
                    $('#DraftCurrencyId').attr('disabled', true);
                    $('#DraftAmount').attr('disabled', true);
                    $('#DraftNumber').attr('disabled', true);
                    $('#DraftDepositDate').attr('disabled', true);
                    $('#DraftBankId').attr('disabled', true);
                    $('#DraftBankBranchId').attr('disabled', true);
                    $('#DraftRemakrs').attr('disabled', true);

                    $("#trCheque").children().hide();
                    $("#ChequeCurrencyId").attr('disabled', true);
                    $("#ChequeAmount").attr('disabled', true);
                    $("#ChequeMobileNumber").attr('disabled', true);
                    $("#ChequeTransactionId").attr('disabled', true);
                    $("#ChequeDrawnonBank").attr('disabled', true);
                    $("#ChequeIssueDate").attr('disabled', true);
                    $("#ChequeNumber").attr('disabled', true);
                    $("#ChequeBankId").attr('disabled', true);
                    $("#ChequeBankBranchId").attr('disabled', true);
                    $("#ChequeRemakrs").attr('disabled', true);

                    $("#trBankTransfer").children().hide();
                    $('#BankTransferCurrencyId').attr('disabled', true);
                    $('#BankTransferAmount').attr('disabled', true);
                    $('#BankTransferDepositDate').attr('disabled', true);
                    $('#BankTransferMobileNumber').attr('disabled', true);
                    $('#BankTransferTransactionId').attr('disabled', true);
                    $('#BankTransferBankId').attr('disabled', true);
                    $('#BankTransferBankBranchId').attr('disabled', true);
                    $('#BankTransferRemakrs').attr('disabled', true);

                    $("#trRTGS").children().hide();
                    $('#RTGSCurrencyId').attr('disabled', true);
                    $('#RTGSAmount').attr('disabled', true);
                    $('#RTGSUTRNumber').attr('disabled', true);
                    $('#RTGSDepositDate').attr('disabled', true);
                    $('#RTGSBankId').attr('disabled', true);
                    $('#RTGSBankBranchId').attr('disabled', true);
                    $('#RTGSRemakrs').attr('disabled', true);

                    $("#trCashGivenTo").children().hide();
                    $('#CashGivenToCurrencyId').attr('disabled', true);
                    $('#CashGivenToAmount').attr('disabled', true);
                    $('#SalesAgent').attr('disabled', true);
                    $('#CashGivenToDepositDate').attr('disabled', true);
                    $('#CashGivenToRemakrs').attr('disabled', true);

                    $("#trCreditRequest").children().hide();
                    $('#CreditRequestCurrencyId').attr('disabled', true);
                    $('#CreditAmount').attr('disabled', true);
                    $('#CreditRequestRemakrs').attr('disabled', true);
                }
                else if (radio_value == 'BankTransfer') {
                    $("#trBankTransfer").children().show();
                    $('#BankTransferCurrencyId').removeAttr('disabled');
                    $('#BankTransferAmount').removeAttr('disabled');
                    $('#BankTransferDepositDate').removeAttr('disabled');
                    $('#BankTransferMobileNumber').removeAttr('disabled');
                    $('#BankTransferTransactionId').removeAttr('disabled');
                    $('#BankTransferBankId').removeAttr('disabled');
                    $('#BankTransferBankBranchId').removeAttr('disabled');
                    $('#BankTransferRemakrs').removeAttr('disabled');

                    $("#trDraft").children().hide();
                    $('#DraftCurrencyId').attr('disabled', true);
                    $('#DraftAmount').attr('disabled', true);
                    $('#DraftNumber').attr('disabled', true);
                    $('#DraftDepositDate').attr('disabled', true);
                    $('#DraftBankId').attr('disabled', true);
                    $('#DraftBankBranchId').attr('disabled', true);
                    $('#DraftRemakrs').attr('disabled', true);

                    $("#trCheque").children().hide();
                    $("#ChequeCurrencyId").attr('disabled', true);
                    $("#ChequeAmount").attr('disabled', true);
                    $("#ChequeMobileNumber").attr('disabled', true);
                    $("#ChequeTransactionId").attr('disabled', true);
                    $("#ChequeDrawnonBank").attr('disabled', true);
                    $("#ChequeIssueDate").attr('disabled', true);
                    $("#ChequeNumber").attr('disabled', true);
                    $("#ChequeBankId").attr('disabled', true);
                    $("#ChequeBankBranchId").attr('disabled', true);
                    $("#ChequeRemakrs").attr('disabled', true);

                    $("#trCash").children().hide();
                    $('#CashCurrencyId').attr('disabled', true);
                    $('#CashAmount').attr('disabled', true);
                    $('#CashDepositDate').attr('disabled', true);
                    $('#CashTransactionId').attr('disabled', true);
                    $('#CashBankId').attr('disabled', true);
                    $('#CashBankBranchId').attr('disabled', true);
                    $('#CashRemakrs').attr('disabled', true);

                    $("#trRTGS").children().hide();
                    $('#RTGSCurrencyId').attr('disabled', true);
                    $('#RTGSAmount').attr('disabled', true);
                    $('#RTGSUTRNumber').attr('disabled', true);
                    $('#RTGSDepositDate').attr('disabled', true);
                    $('#RTGSBankId').attr('disabled', true);
                    $('#RTGSBankBranchId').attr('disabled', true);
                    $('#RTGSRemakrs').attr('disabled', true);

                    $("#trCashGivenTo").children().hide();
                    $('#CashGivenToCurrencyId').attr('disabled', true);
                    $('#CashGivenToAmount').attr('disabled', true);
                    $('#SalesAgent').attr('disabled', true);
                    $('#CashGivenToDepositDate').attr('disabled', true);
                    $('#CashGivenToRemakrs').attr('disabled', true);

                    $("#trCreditRequest").children().hide();
                    $('#CreditRequestCurrencyId').attr('disabled', true);
                    $('#CreditAmount').attr('disabled', true);
                    $('#CreditRequestRemakrs').attr('disabled', true);
                }
                else if (radio_value == 'RTGS') {
                    $("#trRTGS").children().show();
                    $('#RTGSCurrencyId').removeAttr('disabled');
                    $('#RTGSAmount').removeAttr('disabled');
                    $('#RTGSUTRNumber').removeAttr('disabled');
                    $('#RTGSDepositDate').removeAttr('disabled');
                    $('#RTGSBankId').removeAttr('disabled');
                    $('#RTGSBankBranchId').removeAttr('disabled');
                    $('#RTGSRemakrs').removeAttr('disabled');

                    $("#trDraft").children().hide();
                    $('#DraftCurrencyId').attr('disabled', true);
                    $('#DraftAmount').attr('disabled', true);
                    $('#DraftNumber').attr('disabled', true);
                    $('#DraftDepositDate').attr('disabled', true);
                    $('#DraftBankId').attr('disabled', true);
                    $('#DraftBankBranchId').attr('disabled', true);
                    $('#DraftRemakrs').attr('disabled', true);

                    $("#trCheque").children().hide();
                    $("#ChequeCurrencyId").attr('disabled', true);
                    $("#ChequeAmount").attr('disabled', true);
                    $("#ChequeMobileNumber").attr('disabled', true);
                    $("#ChequeTransactionId").attr('disabled', true);
                    $("#ChequeDrawnonBank").attr('disabled', true);
                    $("#ChequeIssueDate").attr('disabled', true);
                    $("#ChequeNumber").attr('disabled', true);
                    $("#ChequeBankId").attr('disabled', true);
                    $("#ChequeBankBranchId").attr('disabled', true);
                    $("#ChequeRemakrs").attr('disabled', true);

                    $("#trCash").children().hide();
                    $('#CashCurrrencyId').attr('disabled', true);
                    $('#CashAmount').attr('disabled', true);
                    $('#CashDepositDate').attr('disabled', true);
                    $('#CashTransactionId').attr('disabled', true);
                    $('#CashBankId').attr('disabled', true);
                    $('#CashBankBranchId').attr('disabled', true);
                    $('#CashRemakrs').attr('disabled', true);

                    $("#trBankTransfer").children().hide();
                    $('#BankTransferCurrencyId').attr('disabled', true);
                    $('#BankTransferAmount').attr('disabled', true);
                    $('#BankTransferDepositDate').attr('disabled', true);
                    $('#BankTransferMobileNumber').attr('disabled', true);
                    $('#BankTransferTransactionId').attr('disabled', true);
                    $('#BankTransferBankId').attr('disabled', true);
                    $('#BankTransferBankBranchId').attr('disabled', true);
                    $('#BankTransferRemakrs').attr('disabled', true);

                    $("#trCashGivenTo").children().hide();
                    $('#CashGivenToCurrencyId').attr('disabled', true);
                    $('#CashGivenToAmount').attr('disabled', true);
                    $('#SalesAgent').attr('disabled', true);
                    $('#CashGivenToDepositDate').attr('disabled', true);
                    $('#CashGivenToRemakrs').attr('disabled', true);

                    $("#trCreditRequest").children().hide();
                    $('#CreditRequestCurrencyId').attr('disabled', true);
                    $('#CreditAmount').attr('disabled', true);
                    $('#CreditRequestRemakrs').attr('disabled', true);
                }
                else if (radio_value == 'CashGivenTo') {
                    $("#trCashGivenTo").children().show();
                    $('#CashGivenToCurrencyId').removeAttr('disabled');
                    $('#CashGivenToAmount').removeAttr('disabled');
                    $('#SalesAgent').removeAttr('disabled');
                    $('#CashGivenToDepositDate').removeAttr('disabled');
                    $('#CashGivenToRemakrs').removeAttr('disabled');

                    $("#trDraft").children().hide();
                    $('#DraftCurrencyId').attr('disabled', true);
                    $('#DraftAmount').attr('disabled', true);
                    $('#DraftNumber').attr('disabled', true);
                    $('#DraftDepositDate').attr('disabled', true);
                    $('#DraftBankId').attr('disabled', true);
                    $('#DraftBankBranchId').attr('disabled', true);
                    $('#DraftRemakrs').attr('disabled', true);

                    $("#trCheque").children().hide();
                    $("#ChequeCurrencyId").attr('disabled', true);
                    $("#ChequeAmount").attr('disabled', true);
                    $("#ChequeMobileNumber").attr('disabled', true);
                    $("#ChequeTransactionId").attr('disabled', true);
                    $("#ChequeDrawnonBank").attr('disabled', true);
                    $("#ChequeIssueDate").attr('disabled', true);
                    $("#ChequeNumber").attr('disabled', true);
                    $("#ChequeBankId").attr('disabled', true);
                    $("#ChequeBankBranchId").attr('disabled', true);
                    $("#ChequeRemakrs").attr('disabled', true);

                    $("#trCash").children().hide();
                    $('#CashCurrencyId').attr('disabled', true);
                    $('#CashAmount').attr('disabled', true);
                    $('#CashDepositDate').attr('disabled', true);
                    $('#CashTransactionId').attr('disabled', true);
                    $('#CashBankId').attr('disabled', true);
                    $('#CashBankBranchId').attr('disabled', true);
                    $('#CashRemakrs').attr('disabled', true);

                    $("#trBankTransfer").children().hide();
                    $('#BankTransferCurrencyId').attr('disabled', true);
                    $('#BankTransferAmount').attr('disabled', true);
                    $('#BankTransferDepositDate').attr('disabled', true);
                    $('#BankTransferMobileNumber').attr('disabled', true);
                    $('#BankTransferTransactionId').attr('disabled', true);
                    $('#BankTransferBankId').attr('disabled', true);
                    $('#BankTransferBankBranchId').attr('disabled', true);
                    $('#BankTransferRemakrs').attr('disabled', true);

                    $("#trRTGS").children().hide();
                    $('#RTGSCurrrencyId').attr('disabled', true);
                    $('#RTGSAmount').attr('disabled', true);
                    $('#RTGSUTRNumber').attr('disabled', true);
                    $('#RTGSDepositDate').attr('disabled', true);
                    $('#RTGSBankId').attr('disabled', true);
                    $('#RTGSBankBranchId').attr('disabled', true);
                    $('#RTGSRemakrs').attr('disabled', true);

                    $("#trCreditRequest").children().hide();
                    $('#CreditRequestCurrencyId').attr('disabled', true);
                    $('#CreditAmount').attr('disabled', true);
                    $('#CreditRequestRemakrs').attr('disabled', true);

                }



                else if (radio_value == 'CreditRequest') {
                    $("#trCreditRequest").children().show();
                    $('#CreditRequestCurrencyId').removeAttr('disabled');
                    $('#CreditAmount').removeAttr('disabled');
                    $('#CreditRequestRemakrs').removeAttr('disabled');


                    $("#trDraft").children().hide();
                    $('#DraftCurrencyId').attr('disabled', true);
                    $('#DraftAmount').attr('disabled', true);
                    $('#DraftNumber').attr('disabled', true);
                    $('#DraftDepositDate').attr('disabled', true);
                    $('#DraftBankId').attr('disabled', true);
                    $('#DraftBankBranchId').attr('disabled', true);
                    $('#DraftRemakrs').attr('disabled', true);

                    $("#trCheque").children().hide();
                    $("#ChequeCurrencyId").attr('disabled', true);
                    $("#ChequeAmount").attr('disabled', true);
                    $("#ChequeMobileNumber").attr('disabled', true);
                    $("#ChequeTransactionId").attr('disabled', true);
                    $("#ChequeDrawnonBank").attr('disabled', true);
                    $("#ChequeIssueDate").attr('disabled', true);
                    $("#ChequeNumber").attr('disabled', true);
                    $("#ChequeBankId").attr('disabled', true);
                    $("#ChequeBankBranchId").attr('disabled', true);
                    $("#ChequeRemakrs").attr('disabled', true);

                    $("#trCash").children().hide();
                    $('#CashCurrencyId').attr('disabled', true);
                    $('#CashAmount').attr('disabled', true);
                    $('#CashDepositDate').attr('disabled', true);
                    $('#CashTransactionId').attr('disabled', true);
                    $('#CashBankId').attr('disabled', true);
                    $('#CashBankBranchId').attr('disabled', true);
                    $('#CashRemakrs').attr('disabled', true);

                    $("#trBankTransfer").children().hide();
                    $('#BankTransferCurrencyId').attr('disabled', true);
                    $('#BankTransferAmount').attr('disabled', true);
                    $('#BankTransferDepositDate').attr('disabled', true);
                    $('#BankTransferMobileNumber').attr('disabled', true);
                    $('#BankTransferTransactionId').attr('disabled', true);
                    $('#BankTransferBankId').attr('disabled', true);
                    $('#BankTransferBankBranchId').attr('disabled', true);
                    $('#BankTransferRemakrs').attr('disabled', true);

                    $("#trCashGivenTo").children().hide();
                    $('#CashGivenToCurrencyId').attr('disabled', true);
                    $('#CashGivenToAmount').attr('disabled', true);
                    $('#SalesAgent').attr('disabled', true);
                    $('#CashGivenToDepositDate').attr('disabled', true);
                    $('#CashGivenToRemakrs').attr('disabled', true);
                }






            });

        });


        $(function () {
            var dates = $("#ChequeIssueDate").datepicker({
                defaultDate: "+1d",
                changeMonth: true,
                changeYear: true,
                constrainInput: true,
                numberOfMonths: 2,
                dateFormat: 'dd M yy',
                //minDate: Date(),
                onSelect: function (selectedDate) {
                    var option = this.id == "ChequeIssueDate" ? "minDate" : "maxDate",
				instance = $(this).data("datepicker");
                    date = $.datepicker.parseDate(
					instance.settings.dateFormat ||
					$.datepicker._defaults.dateFormat,
					selectedDate, instance.settings);
                    dates.not(this).datepicker("option", option, date);
                }
            });

        });


        $(function () {
            var dates = $("#DraftDepositDate").datepicker({
                defaultDate: "+1d",
                changeMonth: true,
                changeYear: true,
                constrainInput: true,
                numberOfMonths: 2,
                dateFormat: 'dd M yy',
                //minDate: Date(),
                onSelect: function (selectedDate) {
                    var option = this.id == "DraftDepositDate" ? "minDate" : "maxDate",
				instance = $(this).data("datepicker");
                    date = $.datepicker.parseDate(
					instance.settings.dateFormat ||
					$.datepicker._defaults.dateFormat,
					selectedDate, instance.settings);
                    dates.not(this).datepicker("option", option, date);
                }
            });

        });

        $(function () {
            var dates = $("#CashDepositDate").datepicker({
                defaultDate: "+1d",
                changeMonth: true,
                changeYear: true,
                constrainInput: true,
                numberOfMonths: 2,
                dateFormat: 'dd M yy',
                //minDate: Date(),
                onSelect: function (selectedDate) {
                    var option = this.id == "CashDepositDate" ? "minDate" : "maxDate",
				instance = $(this).data("datepicker");
                    date = $.datepicker.parseDate(
					instance.settings.dateFormat ||
					$.datepicker._defaults.dateFormat,
					selectedDate, instance.settings);
                    dates.not(this).datepicker("option", option, date);
                }
            });

        });

        $(function () {
            var dates = $("#DraftDepositDate").datepicker({
                defaultDate: "+1d",
                changeMonth: true,
                changeYear: true,
                constrainInput: true,
                numberOfMonths: 2,
                dateFormat: 'dd M yy',
                //minDate: Date(),
                onSelect: function (selectedDate) {
                    var option = this.id == "DraftDepositDate" ? "minDate" : "maxDate",
				instance = $(this).data("datepicker");
                    date = $.datepicker.parseDate(
					instance.settings.dateFormat ||
					$.datepicker._defaults.dateFormat,
					selectedDate, instance.settings);
                    dates.not(this).datepicker("option", option, date);
                }
            });

        });

        $(function () {
            var dates = $("#BankTransferDepositDate").datepicker({
                defaultDate: "+1d",
                changeMonth: true,
                changeYear: true,
                constrainInput: true,
                numberOfMonths: 2,
                dateFormat: 'dd M yy',
                //minDate: Date(),
                onSelect: function (selectedDate) {
                    var option = this.id == "BankTransferDepositDate" ? "minDate" : "maxDate",
				instance = $(this).data("datepicker");
                    date = $.datepicker.parseDate(
					instance.settings.dateFormat ||
					$.datepicker._defaults.dateFormat,
					selectedDate, instance.settings);
                    dates.not(this).datepicker("option", option, date);
                }
            });

        });

        $(function () {
            var dates = $("#RTGSDepositDate").datepicker({
                defaultDate: "+1d",
                changeMonth: true,
                changeYear: true,
                constrainInput: true,
                numberOfMonths: 2,
                dateFormat: 'dd M yy',
                //minDate: Date(),
                onSelect: function (selectedDate) {
                    var option = this.id == "RTGSDepositDate" ? "minDate" : "maxDate",
				instance = $(this).data("datepicker");
                    date = $.datepicker.parseDate(
					instance.settings.dateFormat ||
					$.datepicker._defaults.dateFormat,
					selectedDate, instance.settings);
                    dates.not(this).datepicker("option", option, date);
                }
            });

        });

        $(function () {
            var dates = $("#CashGivenToDepositDate").datepicker({
                defaultDate: "+1d",
                changeMonth: true,
                changeYear: true,
                constrainInput: true,
                numberOfMonths: 2,
                dateFormat: 'dd M yy',
                //minDate: Date(),
                onSelect: function (selectedDate) {
                    var option = this.id == "CashGivenToDepositDate" ? "minDate" : "maxDate",
				instance = $(this).data("datepicker");
                    date = $.datepicker.parseDate(
					instance.settings.dateFormat ||
					$.datepicker._defaults.dateFormat,
					selectedDate, instance.settings);
                    dates.not(this).datepicker("option", option, date);
                }
            });

        });
        /////// Get BankBranch on selecting Bank////////////////////////////////////
        $(document).ready(function () {

            $("#RTGSBankId").change(function () {
                id = $("#RTGSBankId").val();
                if (id == "") {
                    return false;
                }
                else {
                    //build the request url
                    var url = "/Administrator/AjaxRequest/GetBranchListbyBankId";
                    //fire off the request, passing it the id which is the MakeID's selected item value
                    $.getJSON(url, { id: id }, function (data) {
                        //Clear the Model list
                        $("#RTGSBankBranchId").empty();
                        $("#RTGSBankBranchId").append("<option value=''>" + "-- Select--" + "</option>");
                        //Foreach Model in the list, add a model option from the data returned
                        $.each(data, function (index, optionData) {

                            $("#RTGSBankBranchId").append("<option value='" + optionData.Value + "'>" + optionData.Text + "</option>");
                        });
                    });
                }
            }).change();

        });
        ////////////////////////////////////////////////////////////////////////

        /////// Get BankBranch on selecting Bank////////////////////////////////////
        $(document).ready(function () {

            $("#BankTransferBankId").change(function () {
                id = $("#BankTransferBankId").val();
                if (id == "") {
                    return false;
                }
                else {
                    //build the request url
                    var url = "/Administrator/AjaxRequest/GetBranchListbyBankId";
                    //fire off the request, passing it the id which is the MakeID's selected item value
                    $.getJSON(url, { id: id }, function (data) {
                        //Clear the Model list
                        $("#BankTransferBankBranchId").empty();
                        $("#BankTransferBankBranchId").append("<option value=''>" + "-- Select--" + "</option>");
                        //Foreach Model in the list, add a model option from the data returned
                        $.each(data, function (index, optionData) {

                            $("#BankTransferBankBranchId").append("<option value='" + optionData.Value + "'>" + optionData.Text + "</option>");
                        });
                    });
                }
            }).change();

        });
        ////////////////////////////////////////////////////////////////////////

        /////// Get BankBranch on selecting Bank////////////////////////////////////
        $(document).ready(function () {

            $("#CashBankId").change(function () {
                id = $("#CashBankId").val();
                if (id == "") {
                    return false;
                }
                else {
                    //build the request url
                    var url = "/Administrator/AjaxRequest/GetBranchListbyBankId";
                    //fire off the request, passing it the id which is the MakeID's selected item value
                    $.getJSON(url, { id: id }, function (data) {
                        //Clear the Model list
                        $("#CashBankBranchId").empty();
                        $("#CashBankBranchId").append("<option value=''>" + "-- Select--" + "</option>");
                        //Foreach Model in the list, add a model option from the data returned
                        $.each(data, function (index, optionData) {

                            $("#CashBankBranchId").append("<option value='" + optionData.Value + "'>" + optionData.Text + "</option>");
                        });
                    });
                }
            }).change();

        });
        ////////////////////////////////////////////////////////////////////////

        /////// Get BankBranch on selecting Bank////////////////////////////////////
        $(document).ready(function () {

            $("#DraftBankId").change(function () {
                id = $("#DraftBankId").val();
                if (id == "") {
                    return false;
                }
                else {
                    //build the request url
                    var url = "/Administrator/AjaxRequest/GetBranchListbyBankId";
                    //fire off the request, passing it the id which is the MakeID's selected item value
                    $.getJSON(url, { id: id }, function (data) {
                        //Clear the Model list
                        $("#DraftBankBranchId").empty();
                        $("#DraftBankBranchId").append("<option value=''>" + "-- Select--" + "</option>");
                        //Foreach Model in the list, add a model option from the data returned
                        $.each(data, function (index, optionData) {

                            $("#DraftBankBranchId").append("<option value='" + optionData.Value + "'>" + optionData.Text + "</option>");
                        });
                    });
                }
            }).change();

        });
        ////////////////////////////////////////////////////////////////////////



        /////// Get BankBranch on selecting Bank////////////////////////////////////
        $(document).ready(function () {

            $("#ChequeBankId").change(function () {
                id = $("#ChequeBankId").val();
                if (id == "") {
                    return false;
                }
                else {
                    //build the request url
                    var url = "/Administrator/AjaxRequest/GetBranchListbyBankId";
                    //fire off the request, passing it the id which is the MakeID's selected item value
                    $.getJSON(url, { id: id }, function (data) {
                        //Clear the Model list
                        $("#ChequeBankBranchId").empty();
                        $("#ChequeBankBranchId").append("<option value=''>" + "-- Select--" + "</option>");
                        //Foreach Model in the list, add a model option from the data returned
                        $.each(data, function (index, optionData) {

                            $("#ChequeBankBranchId").append("<option value='" + optionData.Value + "'>" + optionData.Text + "</option>");
                        });
                    });
                }
            }).change();

        });
        ////////////////////////////////////////////////////////////////////////

        function maintainControlState() {
            $("#trCheque").children().show();
            $("#ChequeCurrencyId").removeAttr('disabled');
            $("#ChequeAmount").removeAttr('disabled');
            $("#ChequeMobileNumber").removeAttr('disabled');
            $("#ChequeTransactionId").removeAttr('disabled');
            $("#ChequeDrawnonBank").removeAttr('disabled');
            $("#ChequeIssueDate").removeAttr('disabled');
            $("#ChequeNumber").removeAttr('disabled');
            $("#ChequeBankId").removeAttr('disabled');
            $("#ChequeBankBranchId").removeAttr('disabled');
            $("#ChequeRemakrs").removeAttr('disabled');

            $("#trDraft").children().hide();
            $('#DraftCurrencyId').attr('disabled', true);
            $('#DraftAmount').attr('disabled', true);
            $('#DraftNumber').attr('disabled', true);
            $('#DraftDepositDate').attr('disabled', true);
            $('#DraftBankId').attr('disabled', true);
            $('#DraftBankBranchId').attr('disabled', true);
            $('#DraftRemakrs').attr('disabled', true);

            $("#trCash").children().hide();
            $('#CashCurrencyId').attr('disabled', true);
            $('#CashAmount').attr('disabled', true);
            $('#CashDepositDate').attr('disabled', true);
            $('#CashTransactionId').attr('disabled', true);
            $('#CashBankId').attr('disabled', true);
            $('#CashBankBranchId').attr('disabled', true);
            $('#CashRemakrs').attr('disabled', true);

            $("#trBankTransfer").children().hide();
            $('#BankTransferCurrencyId').attr('disabled', true);
            $('#BankTransferAmount').attr('disabled', true);
            $('#BankTransferDepositDate').attr('disabled', true);
            $('#BankTransferMobileNumber').attr('disabled', true);
            $('#BankTransferTransactionId').attr('disabled', true);
            $('#BankTransferBankId').attr('disabled', true);
            $('#BankTransferBankBranchId').attr('disabled', true);
            $('#BankTransferRemakrs').attr('disabled', true);

            $("#trRTGS").children().hide();
            $('#RTGSCurrencyId').attr('disabled', true);
            $('#RTGSAmount').attr('disabled', true);
            $('#RTGSUTRNumber').attr('disabled', true);
            $('#RTGSDepositDate').attr('disabled', true);
            $('#RTGSBankId').attr('disabled', true);
            $('#RTGSBankBranchId').attr('disabled', true);
            $('#RTGSRemakrs').attr('disabled', true);

            $("#trCashGivenTo").children().hide();
            $('#CashGivenToCurrencyId').attr('disabled', true);
            $('#CashGivenToAmount').attr('disabled', true);
            $('#SalesAgent').attr('disabled', true);
            $('#CashGivenToDepositDate').attr('disabled', true);
            $('#CashGivenToRemakrs').attr('disabled', true);

            $("#trCreditRequest").children().hide();
            $('#CreditRequestCurrencyId').attr('disabled', true);
            $('#CreditAmount').attr('disabled', true);
            $('#CreditRequestRemakrs').attr('disabled', true);
        }
    </script>
</asp:Content>