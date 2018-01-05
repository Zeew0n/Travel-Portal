<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/DistributorMain.Master" Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Administrator.Models.MakePaymentModel>" %>

<%@ Import Namespace="ATLTravelPortal.Helpers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Detail
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <%
        if (TempData["success"] != null)
        { %>
    <%: TempData["success"]%>
    <%
    
        }
    %>
   
   <div class="tbl_Data">
        <ul class="buttons-panel float-right">
          
                <input type="button" onclick="document.location.href='/Administrator/BranchDistributorPayment/Index'"
                    value="Cancel" /></li>
        </ul>
        <div class="tbl_Data_Tlt">
            <h3>
                <a href="#" class="icon_plane">Make Payment</a> <span>&nbsp;</span><strong> Detail</strong>
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
                           
                             <%:Html.RadioButton("rdbPaymentMode", "BankTransfer", true, new { id = "BankTransfer", name = "BankTransfer", title = "BankTransfer" })%>&nbsp;BankTransfer
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
                        <%: Html.LabelFor(model => model.ChequeAmount)%>:
                        <%:string.Format("{0:#,#,#}",Model.ChequeAmount) %>
                    </div>
                    <div class="divLeft">
                        <%: Html.LabelFor(model => model.ChequeMobileNumber)%>:
                         <%:Model.ChequeMobileNumber%>
                    </div>
                    <div class="divLeft">
                        <%: Html.LabelFor(model => model.ChequeTransactionId)%>:
                         <%:Model.ChequeTransactionId%>
                    </div>
                    <div class="divLeft">
                        <%: Html.LabelFor(model => model.ChequeDrawnonBank)%>:
                          <%:Model.ChequeDrawnonBankName%>
                    </div>
                    <div class="divLeft">
                        <%: Html.LabelFor(model => model.ChequeIssueDate)%>:
                        <%:TimeFormat.DateFormat( Model.ChequeIssueDate.ToString())%>
                    </div>
                    <div class="divLeft">
                        <%: Html.LabelFor(model => model.ChequeNumber)%>:
                       <%:Model.ChequeNumber%>
                    </div>
                    <div class="divLeft">
                        <%: Html.LabelFor(model => model.ChequeBankId)%>:
                        <%:Model.ChequeBankName%>
                    </div>
                    <div class="divLeft">
                        <%:Html.LabelFor(model => model.ChequeBankBranchId)%>:
                        <%:Model.ChequeBranchName%>
                    </div>
                    <div class="divLeft">
                        <%:Html.LabelFor(model => model.ChequeRemakrs)%>:
                      <%:Model.ChequeRemakrs%>
                    </div>
                </div>
                <%} %>
                <% if (Model.PaymentModeId == 3)
                   { %>
                <div id="trDraft" >
                    <div class="divLeft">
                        <%: Html.LabelFor(model => model.DraftAmount)%>:
                         <%:string.Format("{0:#,#,#}",Model.DraftAmount)%>
                    </div>
                    <div class="divLeft">
                        <%: Html.LabelFor(model => model.DraftNumber)%>:
                          <%:Model.DraftNumber%>
                      
                    </div>
                    <div class="divLeft">
                        <%: Html.LabelFor(model => model.DraftDepositDate)%>:
                        <%:TimeFormat.DateFormat( Model.DraftDepositDate.ToString())%>
                    </div>
                    <div class="divLeft">
                        <%: Html.LabelFor(model => model.DraftBankId)%>:
                         <%:Model.DraftBankName%>
                    </div>
                    <div class="divLeft">
                        <%:Html.LabelFor(model => model.DraftBankBranchId)%>:
                         <%:Model.DraftBranchName%>
                    </div>
                    <div class="divLeft">
                        <%:Html.LabelFor(model => model.DraftRemakrs)%>:
                         <%:Model.DraftRemakrs%>
                    </div>
                </div>
                <%} %>
                <% if (Model.PaymentModeId == 1)
                   { %>
                <div id="trCash">
                    <div class="divLeft">
                        <%: Html.LabelFor(model => model.CashAmount)%>:
                        <%:string.Format("{0:#,#,#}",Model.CashAmount)%>
                    </div>
                    <div class="divLeft">
                        <%: Html.LabelFor(model => model.CashDepositDate)%>:
                         <%:TimeFormat.DateFormat( Model.CashDepositDate.ToString())%>
                    </div>
                    <div class="divLeft">
                        <%: Html.LabelFor(model => model.CashTransactionId)%>:
                         <%:Model.CashTransactionId%>
                    </div>
                    <div class="divLeft">
                        <%: Html.LabelFor(model => model.CashBankId)%>:
                         <%:Model.CashBankName%>
                    </div>
                    <div class="divLeft">
                        <%:Html.LabelFor(model => model.CashBankBranchId)%>:
                       <%:Model.CashBranchName%>
                    </div>
                    <div class="divLeft">
                        <%:Html.LabelFor(model => model.CashRemakrs)%>:
                        <%:Model.CashRemakrs%>
                    </div>
                </div>
                <%} %>
                <%if (Model.PaymentModeId == 4)
                  { %>
                <div id="trBankTransfer">
                    <div class="divLeft">
                        <%: Html.LabelFor(model => model.BankTransferAmount)%>:
                         <%:string.Format("{0:#,#,#}",Model.BankTransferAmount)%>
                    </div>
                    <div class="divLeft">
                        <%: Html.LabelFor(model => model.BankTransferDepositDate)%>:
                        <%: TimeFormat.DateFormat( Model.BankTransferDepositDate.ToString())%>
                    </div>
                    <div class="divLeft">
                        <%: Html.LabelFor(model => model.BankTransferMobileNumber)%>:
                        <%:Model.BankTransferMobileNumber%>
                    </div>
                    <div class="divLeft">
                        <%: Html.LabelFor(model => model.BankTransferTransactionId)%>:
                         <%:Model.BankTransferTransactionId%>
                    </div>
                    <div class="divLeft">
                        <%: Html.LabelFor(model => model.BankTransferBankId)%>:
                        <%:Model.BankTransferBankName%>
                    </div>
                    <div class="divLeft">
                        <%:Html.LabelFor(model => model.BankTransferBankBranchId)%>:
                        <%:Model.BankTransferBranchName%>
                    </div>
                    <div class="divLeft">
                        <%:Html.LabelFor(model => model.BankTransferRemakrs)%>:
                         <%:Model.BankTransferRemakrs%>
                    </div>
                </div>
                <%} %>
                <%if (Model.PaymentModeId == 5)
                  { %>
                <div id="trRTGS">
                    <div class="divLeft">
                        <%: Html.LabelFor(model => model.RTGSAmount)%>:
                       <%:string.Format("{0:#,#,#}",Model.RTGSAmount)%>
                    </div>
                    <div class="divLeft">
                        <%: Html.LabelFor(model => model.RTGSUTRNumber)%>:
                         <%:Model.RTGSUTRNumber%>
                    </div>
                    <div class="divLeft">
                        <%: Html.LabelFor(model => model.RTGSDepositDate)%>:
                        <%:TimeFormat.DateFormat( Model.RTGSDepositDate.ToString())%>
                    </div>
                    <div class="divLeft">
                        <%: Html.LabelFor(model => model.RTGSBankId)%>:
                        <%:Model.RTSSBankName%>
                    </div>
                    <div class="divLeft">
                        <%:Html.LabelFor(model => model.RTGSBankBranchId)%>:
                        <%:Model.RTGSBranchName%>
                    </div>
                    <div class="divLeft">
                        <%:Html.LabelFor(model => model.RTGSRemakrs)%>:
                        <%:Model.RTGSRemakrs%>
                    </div>
                </div>
                <%} %>
                <%if (Model.PaymentModeId == 6)
                  { %>
                <div id="trCashGivenTo">
                    <div class="divLeft">
                        <%: Html.LabelFor(model => model.CashGivenToAmount)%>:
                         <%:string.Format("{0:#,#,#}",Model.CashGivenToAmount)%>
                    </div>
                    <div class="divLeft">
                        <%: Html.Label("Sales Agent")%>:
                        <%:Model.SalesAgentName%>
                    </div>
                    <div class="divLeft">
                        <%: Html.LabelFor(model => model.CashGivenToDepositDate)%>:
                        <%:TimeFormat.DateFormat( Model.CashGivenToDepositDate.ToString())%>
                    </div>
                    <div class="divLeft">
                        <%:Html.LabelFor(model => model.CashGivenToRemakrs)%>:
                        <%:Model.CashGivenToRemakrs%>
                    </div>
                </div>
 <%} %>
            </div>
           
       
  
   
   
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CssContent" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
</asp:Content>
