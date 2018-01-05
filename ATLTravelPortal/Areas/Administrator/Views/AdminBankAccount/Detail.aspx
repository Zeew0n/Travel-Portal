<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/AdministratorMain.Master"
    Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Administrator.Models.AdminBankAccountModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Details
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div>
       <div class="pageTitle">   
       <div class="float-right">
        <input type="button" onclick="document.location.href='/Administrator/AdminBankAccount/'" value="Cancel" />
     </div>       
            <h3>
            <a href="#">Account Management</a> <span>&nbsp;</span><strong>My Bank Account</strong><span>&nbsp;</span><strong>Detail</strong>
        </h3>
        </div>
    </div> 
    <div class="row-1">
        <div class="form-box1 round-corner">
            <div class="form-box1-row">
                <div class="form-box1-row-content float-left">
                    <div>
                        <label>
                            Bank:</label>
                        <%:  Model.BankName%>
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
                            Bank Account Type:</label>
                        <%:Model.BankAccountTypeName%>
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
                            Account:</label>
                        <%:Model.AccountName%>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="row-1">
        <div class="form-box1 round-corner">
            <div class="form-box1-row">
                <div class="form-box1-row">
                    <div class="form-box1-row-content float-left">
                        <div>
                            <label>
                                Account Number:</label>
                            <%:Model.AccountNumber%>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <%--<div class="buttonBar">
        <input type="button" onclick="document.location.href='/Administrator/AdminBankAccount/'" value="Cancel" />
     </div>--%>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CssContent" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
</asp:Content>
