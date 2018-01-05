<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/AdministratorMain.Master"
    Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Administrator.Models.BankBranchModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Edit
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <% Html.EnableClientValidation();%>
    <% using (Html.BeginForm("Edit", "BankBranch", FormMethod.Post, new { id = "AtForm" }))
       {%>
    <%: Html.ValidationSummary(true)%>
    <div class="tbl_Data">
        <ul class="buttons-panel float-right">
            <li>
                <%Html.RenderPartial("Utility/PVC_MessagePanel"); %>
            </li>
            <li>
                <input type="submit" value="Update" class="btn1" /></li>
            <li>
                <input type="button" onclick="document.location.href='/Administrator/BankBranch/Index'"
                    value="Cancel" /></li>
        </ul>
        <div class="tbl_Data_Tlt">
             <h3>
            <a href="#">Account Management</a> <span>&nbsp;</span><strong>Bank Branch</strong><span>&nbsp;</span><strong>Edit</strong>
        </h3>
        </div>
    </div>
    <div class="row-1">
        <div class="form-box1-row">
            <div class="form-box1-row-content float-left">
                <div>
                    <label>
                        <%: Html.Label("Bank") %></label>
                    <%: Html.DropDownListFor(model => model.BankId, Model.ddlBankList, "----Select----")%><span class="redtxt">*</span>
                    <%: Html.ValidationMessageFor(model => model.BankName)%>
                </div>
            </div>
        </div>
        <div class="form-box1-row">
            <div class="form-box1-row-content float-left">
                <div>
                    <label>
                        <%: Html.Label("Country") %></label>
                    <%: Html.DropDownListFor(model => model.CountryId, Model.ddlCountriesList, "----Select----")%><span class="redtxt">*</span>
                    <%: Html.ValidationMessageFor(model => model.BankName)%>
                </div>
            </div>
        </div>
        <div class="form-box1-row">
            <div class="form-box1-row-content float-left">
                <div>
                    <label>
                        <%: Html.Label("Branch") %></label>
                    <%: Html.TextBoxFor(model => model.BranchName)%><span class="redtxt">*</span>
                    <%: Html.ValidationMessageFor(model => model.BranchName)%></div>
            </div>
        </div>
        <div class="form-box1-row">
            <div class="form-box1-row-content float-left">
                <div>
                    <label>
                        <%: Html.Label("Branch Address") %></label>
                    <%: Html.TextBoxFor(model => model.BranchAddress)%><span class="redtxt">*</span>
                    <%: Html.ValidationMessageFor(model => model.BranchAddress)%>
                </div>
            </div>
        </div>
        <div class="form-box1-row">
            <div class="form-box1-row-content float-left">
                <div>
                    <label>
                        <%: Html.Label("Phone No") %></label>
                    <%: Html.TextBoxFor(model => model.PhoneNo)%><span class="redtxt">*</span>
                    <%: Html.ValidationMessageFor(model => model.PhoneNo)%></div>
            </div>
        </div>
        <div class="form-box1-row">
            <div class="form-box1-row-content float-left">
                <div>
                    <label>
                        <%: Html.Label("Contact Person") %></label>
                    <%: Html.TextBoxFor(model => model.ContactPerson) %><span class="redtxt">*</span>
                    <%: Html.ValidationMessageFor(model => model.ContactPerson)%></div>
            </div>
        </div>
        <div class="form-box1-row">
            <div class="form-box1-row-content float-left">
                <div>
                    <label>
                        <%: Html.Label("Contact Person Phone No") %></label>
                    <%: Html.TextBoxFor(model => model.ContactPersonPhoneNo) %>
                    <%: Html.ValidationMessageFor(model => model.ContactPersonPhoneNo)%></div>
            </div>
        </div>
        <div class="form-box1-row">
            <div class="form-box1-row-content float-left">
                <div>
                    <label>
                        <%: Html.Label("Contact Person Email") %></label>
                    <%: Html.TextBoxFor(model => model.ContactPersonEmail) %>
                    <%: Html.ValidationMessageFor(model => model.ContactPersonEmail)%></div>
            </div>
        </div>
    </div>
    <% }
    %>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CssContent" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
</asp:Content>
