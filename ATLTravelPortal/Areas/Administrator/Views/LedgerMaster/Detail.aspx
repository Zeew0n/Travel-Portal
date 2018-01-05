<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/AdministratorMain.Master"
    Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Administrator.Models.LedgerMasterModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Details
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

     <div class="pageTitle">
        <div class="float-right">
            	   <%:Html.ActionLink("Cancel", "Index", new { controller = "LedgerMaster" }, new { @class = "linkButton float-right" })%>
                   <%--<a href="/LedgerMaster/Edit/<%:Model.LedgerId %>" class="linkButton float-right" title ="Edit">Edit</a>--%>
            </div>
        <h3>
            <a href="#">Account Management</a> <span>&nbsp;</span><strong>Ledger Master</strong><span>&nbsp;</span><strong>Details</strong>
        </h3>
    </div>


    <div class="row-1">
        <div class="form-box1 round-corner">
            <div class="form-box1-row">
                <div class="form-box1-row-content float-left">
                    <div>
                        <label>
                           <strong>Product :</strong> </label>
                        <%:Model.ProductName%>
                    </div>
                </div>
            </div>
            <div class="form-box1-row">
                <div class="form-box1-row-content float-left">
                    <div>
                        <label>
                            <strong>Account Group :</strong></label>
                        <%: Model.AccGroupName%>
                    </div>
                </div>
            </div>
            <div class="form-box1-row">
                <div class="form-box1-row-content float-left">
                    <div>
                        <label>
                            <strong>Account Sub Group :</strong></label>
                        <%: Model.AccSubGroupName%>
                    </div>
                </div>
            </div>
            <div class="form-box1-row">
                <div class="form-box1-row-content float-left">
                    <div>
                        <label>
                           <strong> Account Type :</strong></label>
                        <%: Model.AccTypeName%>
                    </div>
                </div>
            </div>
            <div class="form-box1-row">
                <div class="form-box1-row-content float-left">
                    <div>
                        <label>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        </label>
                        <%:  ViewData["Type Name"]%>
                      <%-- <%: Model.DisplayMember%>--%>
                    </div>
                </div>
            </div>
            <div class="form-box1-row">
                <div class="form-box1-row-content float-left">
                    <div>
                        <label>
                           <strong> Ledger :</strong>
                        </label>
                        <%: Model.LedgerName%>
                    </div>
                </div>
            </div>
        </div>
        
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CssContent" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
</asp:Content>
