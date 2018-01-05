<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/AdministratorMain.Master" Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Administrator.Models.UnapprovedCashDepositModel>" %>

<%@ Import Namespace="ATLTravelPortal.Helpers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Details
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

 <%--<%
     if (TempData["error"] != null)
        { %>
    <%: TempData["error"]%>
    <%
    
        }
    %>--%>

    <div id="Error" style="color: Red">
        <%:TempData["Error"] %>
    </div>


   <%-- <h2>Details</h2>

    <fieldset>
        <legend>Fields</legend>
        
        <div class="display-label">AgentName</div>
        <div class="display-field"><%: Model.AgentName %></div>
        <div class="display-label">Deposit Date</div>
        <div class="display-field"><%: String.Format("{0:g}", Model.DepositDate) %></div>
        <div class="display-label">Bank</div>
        <div class="display-field"><%: Model.BankName %></div>
        <div class="display-label">Branch</div>
        <div class="display-field"><%: Model.BranchName %></div>
        <div class="display-label">Account Number</div>
        <div class="display-field"><%: Model.AccountNumber %></div>
        <div class="display-label">Amount</div>
        <div class="display-field"><%: String.Format("{0:F}", Model.Amount) %></div>
        <div class="display-label">Currency</div>
        <div class="display-field"><%: Model.Currency %></div>
        <div class="display-label">Payment Mode</div>
        <div class="display-field"><%: Model.PaymentModes %></div>
        <div class="display-label">Instrument No</div>
        <div class="display-field"><%: Model.InstrumentNo %></div>
        <div class="display-label">Creatd By</div>
        <div class="display-field"><%: Model.CreatdBy %></div>
        <div class="display-label">Created Date</div>
        <div class="display-field"><%: String.Format("{0:g}", Model.CreatedDate) %></div>
        
    </fieldset>--%>

    <div class="box3">
        <div class="userinfo">
            <h3>
               Unapproved Cash Deposit</h3>
        </div>
        <div class="buttons-panel">
            <ul>
                
                <li>
                    <%:Html.ActionLink("Cancel", "Index", new { controller = "UnapprovedCashDeposit" }, new { @class = "cancel" })%>
                </li>
            </ul>
        </div>
    </div>
    <div class="row-1">
        <div class="form-box1 round-corner">
            <div class="form-box1-row">
                <div class="form-box1-row-content float-left">
                    <div>
                        <label>
                            AgentName:</label>
                        <%:  Model.AgentName%>
                    </div>
                </div>
                <div class="form-box1-row-content float-right">
                    <div>
                        <label>
                            Deposit Date:</label>
                        <%:Model.DepositDate%>
                    </div>
                </div>
            </div>
        </div>
    </div>

   

    <div class="row-1">
        <div class="form-box1 round-corner">
            <div class="form-box1-row">
                <div class="form-box1-row-content float-left">
                    <div>
                        <label>
                            Bank:</label>
                        <%:Model.BankName%>
                    </div>
                </div>
                <div class="form-box1-row-content float-right">
                    <div>
                        <label>
                            Branch:</label>
                        <%:Model.BranchName%>
                    </div>
                </div>
            </div>
        </div>
    </div>


     <div class="row-1">
        <div class="form-box1 round-corner">
            <div class="form-box1-row">
                <div class="form-box1-row-content float-left">
                    <div>
                        <label>
                            Account Number:</label>
                        <%:Model.AccountNumber%>
                    </div>
                </div>
                <div class="form-box1-row-content float-right">
                    <div>
                        <label>
                            Amount:</label>
                        <%:Model.Amount%>
                    </div>
                </div>
            </div>
        </div>
    </div>


    <div class="row-1">
        <div class="form-box1 round-corner">
            <div class="form-box1-row">
                <div class="form-box1-row-content float-left">
                    <div>
                        <label>
                           Currency:</label>
                        <%:Model.Currency%>
                    </div>
                </div>
                <div class="form-box1-row-content float-right">
                    <div>
                        <label>
                            Payment Mode:</label>
                        <%:Model.PaymentModes%>
                    </div>
                </div>
            </div>
        </div>
    </div>


    <div class="row-1">
        <div class="form-box1 round-corner">
            <div class="form-box1-row">
                <div class="form-box1-row-content float-left">
                    <div>
                        <label>
                            Instrument No:</label>
                        <%:Model.InstrumentNo%>
                    </div>
                </div>
                <div class="form-box1-row-content float-right">
                    <div>
                        <label>
                            Creatd By:</label>
                        <%:Model.CreatdBy%>
                    </div>
                </div>
            </div>
        </div>
    </div>

     <div class="row-1">
        <div class="form-box1 round-corner">
            <div class="form-box1-row">
                <div class="form-box1-row-content float-left">
                    <div>
                        <label>
                            Created Date:</label>
                        <%:Model.CreatedDate%>
                    </div>
                </div>
            </div>
        </div>
    </div>

   
 

            <% using (Html.BeginForm()) { %>
        <p>
		    <input type="submit" value="Approve" /> 
		   <%-- <%: Html.ActionLink("Back to List", "Index") %>--%>
        </p>
    <% } %>


</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="CssContent" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
</asp:Content>

