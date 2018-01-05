<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/DistributorMain.Master"
    Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Administrator.Models.DistributorConfigurationModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Create
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <%Html.RenderPartial("Utility/VUC_MessagePanel"); %>
    <%Html.EnableClientValidation(); %>
    <% using (Html.BeginForm("Create", "DistributorConfiguration", FormMethod.Post, new { @class = "validate", @autocomplete = "off", enctype = "multipart/form-data" }))
       { %>
    <div class="pageTitle">
        <div class="float-right">
            <input type="submit" value="Save" />
            <input type="button" onclick="document.location.href='/Administrator/DistributorConfiguration/Index'"
                value="Cancel" />
        </div>
        <h3>
            <a href="#" class="icon_plane">System Setup</a> <span>&nbsp;</span><strong>Configuration</strong>
        </h3>
    </div>
    <div class="form-box1 round-corner">
        <div class="form-box1-row">
            <div class="form-box1-row-content float-left" style="width: 450px;">
                <label>
                    <%: Html.LabelFor(model=>model.Title) %>
                </label>
                <div>
                    <%:Html.TextBoxFor(model => model.Title, new { @style = "width:400px;"})%>
                    <span class="redtxt">*</span>
                    <%: Html.ValidationMessageFor(model => model.Title)%>
                </div>
            </div>
        </div>
       
       
        <div class="form-box1-row">
            <div class="form-box1-row-content float-left" style="width: 450px;">
                <label>
                    <%: Html.LabelFor(model=>model.Logo) %>
                </label>
                <div>
                    <input type="file" name="Logo" id="Logo" style="width: 400px;" />
                    <%: Html.ValidationMessageFor(model => model.Logo)%>
                    
                </div>
            </div>
        </div>
        <div class="form-box1-row">
            <div class="form-box1-row-content float-left" style="width: 400px;">
                <div>
                    <label>
                        <%: Html.LabelFor(model => model.IsPublished)%>
                    </label>
                    <%: Html.CheckBoxFor(model => model.IsPublished)%>
                </div>
            </div>
        </div>
    </div>
    <div class="form-box1-row">
        <div class="form-box1-row-content float-left" style="width: 450px;">
            <label>
                <%: Html.LabelFor(model=>model.HeaderContact) %>
            </label>
            <div>
                <%:Html.TextBoxFor(model => model.HeaderContact, new { @style = "width:400px;"})%>
               
                <%: Html.ValidationMessageFor(model => model.HeaderContact)%>
            </div>
            <div style="float: right;">
                <%:Html.CheckBoxFor(model=>model.IsHeaderContactActive) %>
                Is Active
            </div>
        </div>
    </div>
    <div class="form-box1-row">
        <div class="form-box1-row-content float-left" style="width: 450px;">
            <label>
                <%: Html.LabelFor(model=>model.ScrollNews) %>
            </label>
            <div>
                <%:Html.TextAreaFor(model => model.ScrollNews, new { @style = "width:400px;"})%>
               
                <%: Html.ValidationMessageFor(model => model.ScrollNews)%>
            </div>
            <div style="float: right;">
                <%:Html.CheckBoxFor(model=>model.IsScrollNewsActive) %>
                Is Active
            </div>
        </div>
    </div>
     <div class="form-box1-row">
            <div class="form-box1-row-content float-left" style="width: 450px;">
                <label>
                    <%: Html.LabelFor(model=>model.ContactUs) %>
                </label>
                <div>
                    <div style="padding-left: 10px; padding-top: 10px; width: 805px; float: left">
                        <%= Html.TextArea("ContactUs", Model.ContactUs, new { @class = "ckeditor" })%>
                        <%: Html.ValidationMessageFor(model => model.ContactUs)%>
                        <div style="float: right;">
                            <%:Html.CheckBoxFor(model=>model.IsContactUsActive) %>
                            Is Active</div>
                    </div>
                </div>
            </div>
        </div>
    <div class="form-box1-row">
            <div class="form-box1-row-content float-left" style="width: 450px;">
                <label>
                    <%: Html.LabelFor(model=>model.DashboardContent) %>
                </label>
                <div>
                    <div style="padding-left: 10px; padding-top: 10px; width: 805px; float: left">
                        <%= Html.TextArea("DashboardContent", Model.DashboardContent, new { @class = "ckeditor" })%>
                        <%: Html.ValidationMessageFor(model => model.DashboardContent)%>
                        <div style="float: right;">
                            <%:Html.CheckBoxFor(model=>model.IsDashboardContentActive) %>
                            Is Active</div>
                    </div>
                </div>
            </div>
        </div>
    <div class="form-box1-row">
        <div class="form-box1-row-content float-left" style="width: 450px;">
            <label>
                <%: Html.LabelFor(model=>model.BankInfo) %>
            </label>
            <div>
                <div style="padding-left: 10px; padding-top: 10px; width: 805px; float: left">
                    <%= Html.TextArea("BankInfo", Model.BankInfo, new { @class = "ckeditor" })%>
                    <%: Html.ValidationMessageFor(model => model.BankInfo)%>
                    <div style="float: right;">
                        <%:Html.CheckBoxFor(model=>model.IsBankInfoActive) %>
                        Is Active
                    </div>
                </div>
            </div>
        </div>
    </div>
    <%} %>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CssContent" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
    <script src="../../../../Content/ckeditor/ckeditor.js" type="text/javascript"></script>
</asp:Content>
