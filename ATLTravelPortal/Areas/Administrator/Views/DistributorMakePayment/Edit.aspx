<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/DistributorMain.Master" Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Administrator.Models.MakePaymentModel>" %>

<%@ Import Namespace="ATLTravelPortal.Helpers" %>



<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Edit
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<%Html.RenderPartial("Utility/VUC_MessagePanel"); %>

    <%
        if (TempData["success"] != null)
        { %>
    <%: TempData["success"]%>
    <%
    
        }
    %>
    <% Html.EnableClientValidation();%>
    <% using (Html.BeginForm("Edit", "DistributorMakePayment", FormMethod.Post, new { @id = "ATForm", enctype = "multipart/form-data" }))
       {%>
    <%: Html.ValidationSummary(true) %>
   <div class="tbl_Data">
        <ul class="buttons-panel float-right">
            <li>
                <input type="submit" value="Save" class="btn1" /></li>
            <li>
                <input type="button" onclick="document.location.href='/Administrator/DistributorMakePayment/Index'"
                    value="Cancel" /></li>
        </ul>
        <div class="tbl_Data_Tlt">
            <h3>
                <a href="#" class="icon_plane">Make Payment</a> <span>&nbsp;</span><strong> Edit</strong>
            </h3>
        </div>
        <div>

                <div class="form-box1-row">
                <% if (Model.PaymentModeId == 2)
                   { %>
                    <div class="form-box1-row-content float-left">
                        <div>
                            <%:Html.RadioButton("rdbPaymentMode", "Cheque", true, new { id = "Cheque", name = "Cheque", title = "Cheque" })%>&nbsp;Cheque
                        </div>
                        </div>
                        <%} %>
                   
                   <% if (Model.PaymentModeId == 3)
                      { %>
                    <div class="form-box1-row-content float-left">
                        <div>
                            <%:Html.RadioButton("rdbPaymentMode", "Draft", true, new { id = "Draft", name = "Draft", title = "Draft" })%>&nbsp;Draft
                        </div>
                    </div>
                <%} %>
                
                <% if (Model.PaymentModeId ==1){ %>
                    <div class="form-box1-row-content float-left">
                        <div>
                         
                             <%:Html.RadioButton("rdbPaymentMode", "Cash", true, new { id = "Cash", name = "Cash", title = "Cash" })%>&nbsp;Cash
                            
                        </div>
                    </div>
                    <%} %>
               
             <%if(Model.PaymentModeId == 4){ %>
                    <div class="form-box1-row-content float-left">
                        <div>
                           
                             <%:Html.RadioButton("rdbPaymentMode", "BankTransfer", true, new { id = "BankTransfer", name = "BankTransfer", title = "BankTransfer" })%>&nbsp;Bank Transfer
                        </div>
                    </div>
                    <%} %>
                
               <%if(Model.PaymentModeId == 5){ %>
                    <div class="form-box1-row-content float-left">
                        <div>
                           
                                <%:Html.RadioButton("rdbPaymentMode", "RTGS", true, new { id = "RTGS", name = "RTGS", title = "RTGS" })%>&nbsp;RTGS
                           
                        </div>
                    </div>
              <%} %>
               
               <% if(Model.PaymentModeId == 6){ %>
                    <div class="form-box1-row-content float-left">
                        <div>
                           
                             <%:Html.RadioButton("rdbPaymentMode", "CashGivenTo", true, new { id = "CashGivenTo", name = "CashGivenTo", title = "RTGS" })%>&nbsp; Cash Given To
                        </div>
                    </div>
                    <%} %>

                </div>
                 </div>
              <% if (Model.PaymentModeId == 2)
                 { %>
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
                        <%: Html.TextBoxFor(model => model.ChequeDate)%>
                        <%: Html.ValidationMessageFor(model => model.ChequeDate, "*")%>
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
                        <%: Html.TextAreaFor(model => model.ChequeRemakrs, new { @Style = " width:190px; margin-left:1px; padding:5px;" })%>
                    </div>
                </div>
                <%} %>
                <% if (Model.PaymentModeId == 3)
                   { %>
                <div id="trDraft" >
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
                        <%: Html.TextBoxFor(model => model.DraftDate)%>
                        <%: Html.ValidationMessageFor(model => model.DraftDate, "*")%>
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
                <%} %>
                <% if (Model.PaymentModeId == 1)
                   { %>
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
                        <%: Html.TextBoxFor(model => model.CashDate)%>
                        <%: Html.ValidationMessageFor(model => model.CashDate, "*")%>
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
                <%} %>
                <%if (Model.PaymentModeId == 4)
                  { %>
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
                        <%: Html.TextBoxFor(model => model.BankTransferDate)%>
                        <%: Html.ValidationMessageFor(model => model.BankTransferDate, "*")%>
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
                <%} %>
                <%if (Model.PaymentModeId == 5)
                  { %>
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
                        <%: Html.TextBoxFor(model => model.RTGSDate)%>
                        <%: Html.ValidationMessageFor(model => model.RTGSDate, "*")%>
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
                        <%: Html.TextAreaFor(model => model.RTGSRemakrs,new { @Style = " width:190px; margin-left:1px; padding:5px;" })%>
                    </div>
                </div>
                <%} %>
                <%if (Model.PaymentModeId == 6)
                  { %>
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
                       <%: Html.DropDownListFor(model => model.SalesAgent, Model.SalesAgentList)%>
                        <%: Html.ValidationMessageFor(model => model.SalesAgent, "*")%>
                    </div>
                    <div class="divLeft">
                        <%: Html.LabelFor(model => model.CashGivenToDepositDate)%>
                        <%: Html.TextBoxFor(model => model.CashGivenToDate)%>
                        <%: Html.ValidationMessageFor(model => model.CashGivenToDate, "*")%>
                    </div>
                    <div class="divLeft">
                        <%:Html.LabelFor(model => model.CashGivenToRemakrs)%>
                        <%: Html.TextAreaFor(model => model.CashGivenToRemakrs,  new { @Style = " width:190px; margin-left:1px; padding:5px;" })%>
                    </div>
                </div>
 <%} %>

            </div>
           
       
   <%} %>
   
   
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CssContent" runat="server">
    <link href="../../../../Content/themes/redmond/jquery.ui.all.css" rel="stylesheet"
        type="text/css" />
    <link href="../../../../Content/themes/redmond/jquery.ui.base.css" rel="stylesheet"
        type="text/css" />
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
  <script src="../../../../Scripts/DynamicValidation.js" type="text/javascript"></script>
   
    <script language="javascript" type="text/javascript">

        $(document).ready(function () {

            $("input[name$='rdbPaymentMode']").click(function () {

                var radio_value = $(this).val();

                if (radio_value == 'Cheque') {
                    $("#trCheque").children().show();
                    $("#ChequeAmount").removeAttr('disabled');
                    $("#ChequeMobileNumber").removeAttr('disabled');
                    $("#ChequeTransactionId").removeAttr('disabled');
                    $("#ChequeDrawnonBank").removeAttr('disabled');
                    $("#ChequeDate").removeAttr('disabled');
                    $("#ChequeNumber").removeAttr('disabled');
                    $("#ChequeBankId").removeAttr('disabled');
                    $("#ChequeBankBranchId").removeAttr('disabled');
                    $("#ChequeRemakrs").removeAttr('disabled');

                    $("#trDraft").children().hide();
                    $('#DraftAmount').attr('disabled', true);
                    $('#DraftNumber').attr('disabled', true);
                    $('#DraftDate').attr('disabled', true);
                    $('#DraftBankId').attr('disabled', true);
                    $('#DraftBankBranchId').attr('disabled', true);
                    $('#DraftRemakrs').attr('disabled', true);

                    $("#trCash").children().hide();
                    $('#CashAmount').attr('disabled', true);
                    $('#CashDate').attr('disabled', true);
                    $('#CashTransactionId').attr('disabled', true);
                    $('#CashBankId').attr('disabled', true);
                    $('#CashBankBranchId').attr('disabled', true);
                    $('#CashRemakrs').attr('disabled', true);

                    $("#trBankTransfer").children().hide();
                    $('#BankTransferAmount').attr('disabled', true);
                    $('#BankTransferDate').attr('disabled', true);
                    $('#BankTransferMobileNumber').attr('disabled', true);
                    $('#BankTransferTransactionId').attr('disabled', true);
                    $('#BankTransferBankId').attr('disabled', true);
                    $('#BankTransferBankBranchId').attr('disabled', true);
                    $('#BankTransferRemakrs').attr('disabled', true);

                    $("#trRTGS").children().hide();
                    $('#RTGSAmount').attr('disabled', true);
                    $('#RTGSUTRNumber').attr('disabled', true);
                    $('#RTGSDate').attr('disabled', true);
                    $('#RTGSBankId').attr('disabled', true);
                    $('#RTGSBankBranchId').attr('disabled', true);
                    $('#RTGSRemakrs').attr('disabled', true);

                    $("#trCashGivenTo").children().hide();
                    $('#CashGivenToAmount').attr('disabled', true);
                    $('#SalesAgent').attr('disabled', true);
                    $('#CashGivenToDate').attr('disabled', true);
                    $('#CashGivenToRemakrs').attr('disabled', true);
                }
                else if (radio_value == 'Draft') {

                    $("#trDraft").children().show();
                    $('#DraftAmount').removeAttr('disabled');
                    $('#DraftNumber').removeAttr('disabled');
                    $('#DraftDate').removeAttr('disabled');
                    $('#DraftBankId').removeAttr('disabled');
                    $('#DraftBankBranchId').removeAttr('disabled');
                    $('#DraftRemakrs').removeAttr('disabled');


                    $("#trCheque").children().hide();
                    $("#ChequeAmount").attr('disabled', true);
                    $("#ChequeMobileNumber").attr('disabled', true);
                    $("#ChequeTransactionId").attr('disabled', true);
                    $("#ChequeDrawnonBank").attr('disabled', true);
                    $("#ChequeDate").attr('disabled', true);
                    $("#ChequeNumber").attr('disabled', true);
                    $("#ChequeBankId").attr('disabled', true);
                    $("#ChequeBankBranchId").attr('disabled', true);
                    $("#ChequeRemakrs").attr('disabled', true);

                    $("#trCash").children().hide();
                    $('#CashAmount').attr('disabled', true);
                    $('#CashDate').attr('disabled', true);
                    $('#CashTransactionId').attr('disabled', true);
                    $('#CashBankId').attr('disabled', true);
                    $('#CashBankBranchId').attr('disabled', true);
                    $('#CashRemakrs').attr('disabled', true);

                    $("#trBankTransfer").children().hide();
                    $('#BankTransferAmount').attr('disabled', true);
                    $('#BankTransferDate').attr('disabled', true);
                    $('#BankTransferMobileNumber').attr('disabled', true);
                    $('#BankTransferTransactionId').attr('disabled', true);
                    $('#BankTransferBankId').attr('disabled', true);
                    $('#BankTransferBankBranchId').attr('disabled', true);
                    $('#BankTransferRemakrs').attr('disabled', true);

                    $("#trRTGS").children().hide();
                    $('#RTGSAmount').attr('disabled', true);
                    $('#RTGSUTRNumber').attr('disabled', true);
                    $('#RTGSDate').attr('disabled', true);
                    $('#RTGSBankId').attr('disabled', true);
                    $('#RTGSBankBranchId').attr('disabled', true);
                    $('#RTGSRemakrs').attr('disabled', true);

                    $("#trCashGivenTo").children().hide();
                    $('#CashGivenToAmount').attr('disabled', true);
                    $('#SalesAgent').attr('disabled', true);
                    $('#CashGivenToDate').attr('disabled', true);
                    $('#CashGivenToRemakrs').attr('disabled', true);
                }
                else if (radio_value == 'Cash') {
                    $("#trCash").children().show();
                    $('#CashAmount').removeAttr('disabled');
                    $('#CashDate').removeAttr('disabled');
                    $('#CashTransactionId').removeAttr('disabled');
                    $('#CashBankId').removeAttr('disabled');
                    $('#CashBankBranchId').removeAttr('disabled');
                    $('#CashRemakrs').removeAttr('disabled');

                    $("#trDraft").children().hide();
                    $('#DraftAmount').attr('disabled', true);
                    $('#DraftNumber').attr('disabled', true);
                    $('#DraftDate').attr('disabled', true);
                    $('#DraftBankId').attr('disabled', true);
                    $('#DraftBankBranchId').attr('disabled', true);
                    $('#DraftRemakrs').attr('disabled', true);

                    $("#trCheque").children().hide();
                    $("#ChequeAmount").attr('disabled', true);
                    $("#ChequeMobileNumber").attr('disabled', true);
                    $("#ChequeTransactionId").attr('disabled', true);
                    $("#ChequeDrawnonBank").attr('disabled', true);
                    $("#ChequeDate").attr('disabled', true);
                    $("#ChequeNumber").attr('disabled', true);
                    $("#ChequeBankId").attr('disabled', true);
                    $("#ChequeBankBranchId").attr('disabled', true);
                    $("#ChequeRemakrs").attr('disabled', true);

                    $("#trBankTransfer").children().hide();
                    $('#BankTransferAmount').attr('disabled', true);
                    $('#BankTransferDate').attr('disabled', true);
                    $('#BankTransferMobileNumber').attr('disabled', true);
                    $('#BankTransferTransactionId').attr('disabled', true);
                    $('#BankTransferBankId').attr('disabled', true);
                    $('#BankTransferBankBranchId').attr('disabled', true);
                    $('#BankTransferRemakrs').attr('disabled', true);

                    $("#trRTGS").children().hide();
                    $('#RTGSAmount').attr('disabled', true);
                    $('#RTGSUTRNumber').attr('disabled', true);
                    $('#RTGSDate').attr('disabled', true);
                    $('#RTGSBankId').attr('disabled', true);
                    $('#RTGSBankBranchId').attr('disabled', true);
                    $('#RTGSRemakrs').attr('disabled', true);

                    $("#trCashGivenTo").children().hide();
                    $('#CashGivenToAmount').attr('disabled', true);
                    $('#SalesAgent').attr('disabled', true);
                    $('#CashGivenToDate').attr('disabled', true);
                    $('#CashGivenToRemakrs').attr('disabled', true);
                }
                else if (radio_value == 'BankTransfer') {
                    $("#trBankTransfer").children().show();
                    $('#BankTransferAmount').removeAttr('disabled');
                    $('#BankTransferDate').removeAttr('disabled');
                    $('#BankTransferMobileNumber').removeAttr('disabled');
                    $('#BankTransferTransactionId').removeAttr('disabled');
                    $('#BankTransferBankId').removeAttr('disabled');
                    $('#BankTransferBankBranchId').removeAttr('disabled');
                    $('#BankTransferRemakrs').removeAttr('disabled');

                    $("#trDraft").children().hide();
                    $('#DraftAmount').attr('disabled', true);
                    $('#DraftNumber').attr('disabled', true);
                    $('#DraftDate').attr('disabled', true);
                    $('#DraftBankId').attr('disabled', true);
                    $('#DraftBankBranchId').attr('disabled', true);
                    $('#DraftRemakrs').attr('disabled', true);

                    $("#trCheque").children().hide();
                    $("#ChequeAmount").attr('disabled', true);
                    $("#ChequeMobileNumber").attr('disabled', true);
                    $("#ChequeTransactionId").attr('disabled', true);
                    $("#ChequeDrawnonBank").attr('disabled', true);
                    $("#ChequeDate").attr('disabled', true);
                    $("#ChequeNumber").attr('disabled', true);
                    $("#ChequeBankId").attr('disabled', true);
                    $("#ChequeBankBranchId").attr('disabled', true);
                    $("#ChequeRemakrs").attr('disabled', true);

                    $("#trCash").children().hide();
                    $('#CashAmount').attr('disabled', true);
                    $('#CashDate').attr('disabled', true);
                    $('#CashTransactionId').attr('disabled', true);
                    $('#CashBankId').attr('disabled', true);
                    $('#CashBankBranchId').attr('disabled', true);
                    $('#CashRemakrs').attr('disabled', true);

                    $("#trRTGS").children().hide();
                    $('#RTGSAmount').attr('disabled', true);
                    $('#RTGSUTRNumber').attr('disabled', true);
                    $('#RTGSDate').attr('disabled', true);
                    $('#RTGSBankId').attr('disabled', true);
                    $('#RTGSBankBranchId').attr('disabled', true);
                    $('#RTGSRemakrs').attr('disabled', true);

                    $("#trCashGivenTo").children().hide();
                    $('#CashGivenToAmount').attr('disabled', true);
                    $('#SalesAgent').attr('disabled', true);
                    $('#CashGivenToDate').attr('disabled', true);
                    $('#CashGivenToRemakrs').attr('disabled', true);
                }
                else if (radio_value == 'RTGS') {
                    $("#trRTGS").children().show();
                    $('#RTGSAmount').removeAttr('disabled');
                    $('#RTGSUTRNumber').removeAttr('disabled');
                    $('#RTGSDate').removeAttr('disabled');
                    $('#RTGSBankId').removeAttr('disabled');
                    $('#RTGSBankBranchId').removeAttr('disabled');
                    $('#RTGSRemakrs').removeAttr('disabled');

                    $("#trDraft").children().hide();
                    $('#DraftAmount').attr('disabled', true);
                    $('#DraftNumber').attr('disabled', true);
                    $('#DraftDate').attr('disabled', true);
                    $('#DraftBankId').attr('disabled', true);
                    $('#DraftBankBranchId').attr('disabled', true);
                    $('#DraftRemakrs').attr('disabled', true);

                    $("#trCheque").children().hide();
                    $("#ChequeAmount").attr('disabled', true);
                    $("#ChequeMobileNumber").attr('disabled', true);
                    $("#ChequeTransactionId").attr('disabled', true);
                    $("#ChequeDrawnonBank").attr('disabled', true);
                    $("#ChequeDate").attr('disabled', true);
                    $("#ChequeNumber").attr('disabled', true);
                    $("#ChequeBankId").attr('disabled', true);
                    $("#ChequeBankBranchId").attr('disabled', true);
                    $("#ChequeRemakrs").attr('disabled', true);

                    $("#trCash").children().hide();
                    $('#CashAmount').attr('disabled', true);
                    $('#CashDate').attr('disabled', true);
                    $('#CashTransactionId').attr('disabled', true);
                    $('#CashBankId').attr('disabled', true);
                    $('#CashBankBranchId').attr('disabled', true);
                    $('#CashRemakrs').attr('disabled', true);

                    $("#trBankTransfer").children().hide();
                    $('#BankTransferAmount').attr('disabled', true);
                    $('#BankTransferDate').attr('disabled', true);
                    $('#BankTransferMobileNumber').attr('disabled', true);
                    $('#BankTransferTransactionId').attr('disabled', true);
                    $('#BankTransferBankId').attr('disabled', true);
                    $('#BankTransferBankBranchId').attr('disabled', true);
                    $('#BankTransferRemakrs').attr('disabled', true);

                    $("#trCashGivenTo").children().hide();
                    $('#CashGivenToAmount').attr('disabled', true);
                    $('#SalesAgent').attr('disabled', true);
                    $('#CashGivenToDate').attr('disabled', true);
                    $('#CashGivenToRemakrs').attr('disabled', true);
                }
                else if (radio_value == 'CashGivenTo') {
                    $("#trCashGivenTo").children().show();
                    $('#CashGivenToAmount').removeAttr('disabled');
                    $('#SalesAgent').removeAttr('disabled');
                    $('#CashGivenToDate').removeAttr('disabled');
                    $('#CashGivenToRemakrs').removeAttr('disabled');

                    $("#trDraft").children().hide();
                    $('#DraftAmount').attr('disabled', true);
                    $('#DraftNumber').attr('disabled', true);
                    $('#DraftDate').attr('disabled', true);
                    $('#DraftBankId').attr('disabled', true);
                    $('#DraftBankBranchId').attr('disabled', true);
                    $('#DraftRemakrs').attr('disabled', true);

                    $("#trCheque").children().hide();
                    $("#ChequeAmount").attr('disabled', true);
                    $("#ChequeMobileNumber").attr('disabled', true);
                    $("#ChequeTransactionId").attr('disabled', true);
                    $("#ChequeDrawnonBank").attr('disabled', true);
                    $("#ChequeDate").attr('disabled', true);
                    $("#ChequeNumber").attr('disabled', true);
                    $("#ChequeBankId").attr('disabled', true);
                    $("#ChequeBankBranchId").attr('disabled', true);
                    $("#ChequeRemakrs").attr('disabled', true);

                    $("#trCash").children().hide();
                    $('#CashAmount').attr('disabled', true);
                    $('#CashDate').attr('disabled', true);
                    $('#CashTransactionId').attr('disabled', true);
                    $('#CashBankId').attr('disabled', true);
                    $('#CashBankBranchId').attr('disabled', true);
                    $('#CashRemakrs').attr('disabled', true);

                    $("#trBankTransfer").children().hide();
                    $('#BankTransferAmount').attr('disabled', true);
                    $('#BankTransferDate').attr('disabled', true);
                    $('#BankTransferMobileNumber').attr('disabled', true);
                    $('#BankTransferTransactionId').attr('disabled', true);
                    $('#BankTransferBankId').attr('disabled', true);
                    $('#BankTransferBankBranchId').attr('disabled', true);
                    $('#BankTransferRemakrs').attr('disabled', true);

                    $("#trRTGS").children().hide();
                    $('#RTGSAmount').attr('disabled', true);
                    $('#RTGSUTRNumber').attr('disabled', true);
                    $('#RTGSDate').attr('disabled', true);
                    $('#RTGSBankId').attr('disabled', true);
                    $('#RTGSBankBranchId').attr('disabled', true);
                    $('#RTGSRemakrs').attr('disabled', true);

                }
            });

        });

        $(function () {
            var dates = $("#CashGivenToDate").datepicker({
                defaultDate: "+1d",
                changeMonth: true,
                changeYear: true,
                constrainInput: true,
                numberOfMonths: 2,
                dateFormat: 'dd M yy',
                //minDate: Date(),
                onSelect: function (selectedDate) {
                    var option = this.id == "CashGivenToDate" ? "minDate" : "maxDate",
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
            var dates = $("#ChequeDate").datepicker({
                defaultDate: "+1d",
                changeMonth: true,
                changeYear: true,
                constrainInput: true,
                numberOfMonths: 2,
                dateFormat: 'dd M yy',
                //minDate: Date(),
                onSelect: function (selectedDate) {
                    var option = this.id == "ChequeDate" ? "minDate" : "maxDate",
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
            var dates = $("#DraftDate").datepicker({
                defaultDate: "+1d",
                changeMonth: true,
                changeYear: true,
                constrainInput: true,
                numberOfMonths: 2,
                dateFormat: 'dd M yy',
                //minDate: Date(),
                onSelect: function (selectedDate) {
                    var option = this.id == "DraftDate" ? "minDate" : "maxDate",
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
            var dates = $("#CashDate").datepicker({
                defaultDate: "+1d",
                changeMonth: true,
                changeYear: true,
                constrainInput: true,
                numberOfMonths: 2,
                dateFormat: 'dd M yy',
                //minDate: Date(),
                onSelect: function (selectedDate) {
                    var option = this.id == "CashDate" ? "minDate" : "maxDate",
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
            var dates = $("#DraftDate").datepicker({
                defaultDate: "+1d",
                changeMonth: true,
                changeYear: true,
                constrainInput: true,
                numberOfMonths: 2,
                dateFormat: 'dd M yy',
                //minDate: Date(),
                onSelect: function (selectedDate) {
                    var option = this.id == "DraftDate" ? "minDate" : "maxDate",
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
            var dates = $("#BankTransferDate").datepicker({
                defaultDate: "+1d",
                changeMonth: true,
                changeYear: true,
                constrainInput: true,
                numberOfMonths: 2,
                dateFormat: 'dd M yy',
                //minDate: Date(),
                onSelect: function (selectedDate) {
                    var option = this.id == "BankTransferDate" ? "minDate" : "maxDate",
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
            var dates = $("#RTGSDate").datepicker({
                defaultDate: "+1d",
                changeMonth: true,
                changeYear: true,
                constrainInput: true,
                numberOfMonths: 2,
                dateFormat: 'dd M yy',
                //minDate: Date(),
                onSelect: function (selectedDate) {
                    var option = this.id == "RTGSDate" ? "minDate" : "maxDate",
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
                    var url = "/Administrator/AjaxRequest/GetBankBranchBasedonBankId";
                    //fire off the request, passing it the id which is the MakeID's selected item value
                    $.getJSON(url, { id: id }, function (data) {
                        //Clear the Model list
                        //                        $("#RTGSBankBranchId").empty();
                        //                        $("#RTGSBankBranchId").append("<option value=''>" + "-- Select--" + "</option>");
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
                    var url = "/Administrator/AjaxRequest/GetBankBranchBasedonBankId";
                    //fire off the request, passing it the id which is the MakeID's selected item value
                    $.getJSON(url, { id: id }, function (data) {
                        //Clear the Model list
                        //                        $("#BankTransferBankBranchId").empty();
                        //                        $("#BankTransferBankBranchId").append("<option value=''>" + "-- Select--" + "</option>");
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
                    var url = "/Administrator/AjaxRequest/GetBankBranchBasedonBankId";
                    //fire off the request, passing it the id which is the MakeID's selected item value
                    $.getJSON(url, { id: id }, function (data) {
                        //Clear the Model list
                        //                        $("#CashBankBranchId").empty();
                        //                        $("#CashBankBranchId").append("<option value=''>" + "-- Select--" + "</option>");
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
                    var url = "/Administrator/AjaxRequest/GetBankBranchBasedonBankId";
                    //fire off the request, passing it the id which is the MakeID's selected item value
                    $.getJSON(url, { id: id }, function (data) {
                        //Clear the Model list
                        //                        $("#DraftBankBranchId").empty();
                        //                        $("#DraftBankBranchId").append("<option value=''>" + "-- Select--" + "</option>");
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
                    var url = "/Administrator/AjaxRequest/GetBankBranchBasedonBankId";
                    //fire off the request, passing it the id which is the MakeID's selected item value
                    $.getJSON(url, { id: id }, function (data) {
                        //Clear the Model list
                        //                        $("#ChequeBankBranchId").empty();
                        //                        $("#ChequeBankBranchId").append("<option value=''>" + "-- Select--" + "</option>");
                        //Foreach Model in the list, add a model option from the data returned
                        $.each(data, function (index, optionData) {

                            $("#ChequeBankBranchId").append("<option value='" + optionData.Value + "'>" + optionData.Text + "</option>");
                        });
                    });
                }
            }).change();

        });
        ////////////////////////////////////////////////////////////////////////


    </script>
</asp:Content>