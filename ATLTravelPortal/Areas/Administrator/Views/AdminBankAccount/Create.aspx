<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/AdministratorMain.Master"
    Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Administrator.Models.AdminBankAccountModel>" %>

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
    <% using (Html.BeginForm())
       {%>
    <%: Html.ValidationSummary(true) %>
    <div class="tbl_Data">
        <ul class="buttons-panel float-right"><li>
            <%Html.RenderPartial("Utility/PVC_MessagePanel"); %> 
            </li>
            <li>
                <input type="submit" value="Save" class="btn1" /></li>
            <li>
                <input type="button" onclick="document.location.href='/Administrator/AdminBankAccount/Index'"
                    value="Cancel" /></li>
        </ul>
        <div class="tbl_Data_Tlt">
              <h3>
            <a href="#">Account Management</a> <span>&nbsp;</span><strong>My Bank Account</strong><span>&nbsp;</span><strong>Create</strong>
        </h3>

        </div>
    </div>
    <div class="row-1">
        <div class="form-box1 round-corner">
            <div class="form-box1-row">
                <div class="form-box1-row-content float-left">
                    <div>
                        <%:Html.LabelFor(model => model.BankId)%>
                        <%:Html.DropDownListFor(model => model.BankId, Model.ddlBankList)%>
                        <%:Html.ValidationMessageFor(model => model.BankId, "*")%>
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
                        <%:Html.LabelFor(model => model.BankBranchId)%>
                        <%:Html.DropDownListFor(model => model.BankBranchId, Model.ddlBankBranchList)%>
                        <%:Html.ValidationMessageFor(model => model.BankBranchId, "*")%>
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
                        <%:Html.LabelFor(model => model.BankAccountTypeId)%>
                        <%:Html.DropDownListFor(model => model.BankAccountTypeId, Model.ddlAccountTypeList)%>
                        <%:Html.ValidationMessageFor(model => model.BankAccountTypeId, "*")%>
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
                        <%:Html.LabelFor(model => model.AccountName)%>
                        <%: Html.TextBoxFor(model => model.AccountName) %>
                        <%: Html.ValidationMessageFor(model=>model.AccountName, "*") %>
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
                        <%:Html.LabelFor(model => model.AccountNumber)%>
                        <%: Html.TextBoxFor(model => model.AccountNumber)%>
                        <%: Html.ValidationMessageFor(model => model.AccountNumber, "*")%>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <% } %>
    <br />
    <br />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CssContent" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
    <script language="javascript" type="text/javascript">

        /////// Get BankBranch on selecting Bank////////////////////////////////////
        $(document).ready(function () {

            $("#BankId").change(function () {
                id = $("#BankId").val();
                if (id == "") {
                    return false;
                }
                else {
                    //build the request url
                    var url = "/Administrator/AjaxRequest/GetBankBranchBasedonBankId";
                    //fire off the request, passing it the id which is the MakeID's selected item value
                    $.getJSON(url, { id: id }, function (data) {
                        //Clear the Model list
                        $("#BankBranchId").empty();
                        $("#BankBranchId").append("<option value=''>" + "-- Select--" + "</option>");
                        //Foreach Model in the list, add a model option from the data returned
                        $.each(data, function (index, optionData) {

                            $("#BankBranchId").append("<option value='" + optionData.Value + "'>" + optionData.Text + "</option>");
                        });
                    });
                }
            }).change();

        });
        ////////////////////////////////////////////////////////////////////////




    </script>
</asp:Content>
