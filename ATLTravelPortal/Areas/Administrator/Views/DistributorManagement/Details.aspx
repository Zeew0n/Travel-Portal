<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/AdministratorMain.Master"
    Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Administrator.Models.DistributorManagementModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Create
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="pageTitle">
        <div class="float-right">
            <ul>
                <li>
                    <%Html.RenderPartial("Utility/VUC_MessagePanel"); %>
                </li>
                <li>
                    <label id="Label1">
                    </label>
                </li>
                <li>
                    <input type="button" value="Cancel" class="cancel" onclick="document.location.href='/Administrator/DistributorManagement/'" /></li>
            </ul>
        </div>
        <h3>
            <a href="#">Distributor Management</a> <span>&nbsp;</span><strong>Details</strong>
        </h3>
    </div>
    <div class="wiz-container">
        <ul>
            <li><a href="javascript: void(0)" class="wiz-anc-done wiz-anc-default">
                <h2>
                    1. Distributor Basic Info</h2>
            </a></li>
        </ul>
        <div class="wiz-body">
            <div>
                <div class="wiz-content">
                    <div class="row-1">
                        <div class="form-box1 round-corner">
                            <div class="form-box1-row">
                                <div class="form-box1-row-content float-left">
                                    <div>
                                        <label>
                                            <%: Html.LabelFor(model=>model.DistributorName) %></label>
                                        <%:Model.DistributorName %>
                                    </div>
                                </div>
                                <div class="form-box1-row-content float-right">
                                    <div>
                                        <label>
                                            <%: Html.LabelFor(model=>model.BranchOfficeId) %></label>
                                        <%:Model.BranchOfficeName %>
                                    </div>
                                </div>
                            </div>
                            <div class="form-box1-row">
                                <div class="form-box1-row-content float-left">
                                    <div>
                                        <label>
                                            <%: Html.LabelFor(model => model.TimeZoneId)%></label>
                                        <%:Model.TimeZoneName %>
                                    </div>
                                </div>
                                <div class="form-box1-row-content float-right">
                                    <div>
                                        <label>
                                            <%: Html.LabelFor(model=>model.NativeCountryId) %></label>
                                        <%:Model.NativeCountryName %>
                                    </div>
                                </div>
                            </div>
                            <div class="form-box1-row">
                                <div class="form-box1-row-content float-left">
                                    <div>
                                        <label>
                                            <%: Html.LabelFor(model => model.ZoneId)%></label>
                                        <%:Model.ZoneName %>
                                    </div>
                                </div>
                                <div class="form-box1-row-content float-right">
                                    <div>
                                        <label>
                                            <%: Html.LabelFor(model => model.DistrictId)%></label>
                                        <%:Model.DistrictName %>
                                    </div>
                                </div>
                            </div>
                            <div class="form-box1-row">
                                <div class="form-box1-row-content float-left">
                                    <div>
                                        <label>
                                            <%: Html.LabelFor(model => model.Address)%></label>
                                        <%:Model.Address %>
                                    </div>
                                </div>
                                <div class="form-box1-row-content float-right">
                                    <div>
                                        <label>
                                            <%: Html.LabelFor(model => model.Phone)%></label>
                                        <%:Model.Phone %>
                                    </div>
                                </div>
                            </div>
                            <div class="form-box1-row">
                                <div class="form-box1-row-content float-left">
                                    <div>
                                        <label>
                                            <%: Html.LabelFor(model => model.Email)%></label>
                                        <%:Model.Email %>
                                    </div>
                                </div>
                                <div class="form-box1-row-content float-right">
                                    <div>
                                        <label>
                                            <%: Html.LabelFor(model => model.FaxNo)%></label>
                                        <%:Model.FaxNo %>
                                    </div>
                                </div>
                            </div>
                            <div class="form-box1-row">
                                <div class="form-box1-row-content float-left">
                                    <div>
                                        <label>
                                            <%: Html.LabelFor(model => model.PanNo)%></label>
                                        <%:Model.PanNo %>
                                    </div>
                                </div>
                                <div class="form-box1-row-content float-right">
                                    <div>
                                        <label>
                                            <%: Html.LabelFor(model => model.Web)%></label>
                                        <%:Model.Web %>
                                    </div>
                                </div>
                            </div>
                            <div class="form-box1-row">
                                <div class="form-box1-row-content float-left">
                                    <div>
                                        <label>
                                            <%: Html.LabelFor(model => model.Status)%></label>
                                        <%:Model.Status==0?"DeActivate":"Active" %>
                                    </div>
                                </div>
                                <div class="form-box1-row-content float-right">
                                    <div>
                                        <label>
                                        </label>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <ul>
            <li><a href="javascript: void(0)" class="wiz-anc-done wiz-anc-default">
                <h2>
                    2. Authorize User</h2>
            </a></li>
        </ul>
        <div class="wiz-body">
            <div>
                <div class="wiz-content">
                    <div class="row-1">
                        <div class="form-box1 round-corner">
                            <div class="form-box1-row">
                                <div class="form-box1-row-content float-left">
                                    <div>
                                        <label>
                                            <%: Html.LabelFor(model=>model.FullName) %></label>
                                        <%:Model.FullName %>
                                    </div>
                                </div>
                                <div class="form-box1-row-content float-right">
                                    <div>
                                        <label>
                                            <%: Html.LabelFor(model=>model.UserName) %></label>
                                        <%:Model.UserName %>
                                    </div>
                                </div>
                            </div>
                            <div class="form-box1-row">
                                <div class="form-box1-row-content float-left">
                                    <div>
                                        <label>
                                            <%: Html.LabelFor(model=>model.UserEmail) %></label>
                                        <%:Model.UserEmail %>
                                    </div>
                                </div>
                                <div class="form-box1-row-content float-right">
                                    <div>
                                        <label>
                                            <%: Html.LabelFor(model=>model.UserAddress) %></label>
                                        <%:Model.UserAddress %>
                                    </div>
                                </div>
                            </div>
                            <div class="form-box1-row">
                                <div class="form-box1-row-content float-left">
                                    <div>
                                        <label>
                                            <%: Html.LabelFor(model=>model.UserMobileNo) %></label>
                                        <%:Model.UserMobileNo %>
                                    </div>
                                </div>
                                <div class="form-box1-row-content float-right">
                                    <div>
                                        <label>
                                            <%: Html.LabelFor(model=>model.UserPhoneNo) %></label>
                                        <%:Model.UserPhoneNo %>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CssContent" runat="server">
    <link href="../../../../Content/style_wizard.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
</asp:Content>
