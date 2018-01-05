<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/AdministratorMain.Master"
    Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Administrator.Models.BankManagementsModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Bank Management
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <%-- <% Html.EnableClientValidation();%>--%>
                 <%--<%: Html.ValidationSummary(true) %>--%>
                 <% using (Html.BeginForm())
                  {%>
    
    <div class="pageTitle">
         
        <h3>
            <a href="#">Account Management</a> <span>&nbsp;</span><strong>Bank Management</strong><span>&nbsp;</span><strong>Create</strong>
        </h3>
    </div>

    <% if (ViewData["responseMessage"] != null)
       { %>
    <div>
        <%:ViewData["responseMessage"]%></div>
    <% } %>
    <div class="row-1">
                <div class="form-box1-row">
                    <div class="form-box1-row-content float-left">
                        <div>
                            <label>
                                <%: Html.Label("Bank") %>
                            </label>
                            <%: Html.TextBoxFor(model => model.BankName, new {id="BankName" })%><span class="redtxt">*</span>
                            <%: Html.ValidationMessageFor(model => model.BankName)%>
                            <div id="check_agentname" style="display: block;">
                            </div>
                        </div>
                    </div>
                </div>
                <div class="form-box1-row">
                    <div class="form-box1-row-content float-left">
                        <div>
                            <label>
                                <%: Html.Label("Address") %></label>
                            <%: Html.TextAreaFor(model => model.BankAddress)%><span class="redtxt">*</span>
                            <%: Html.ValidationMessageFor(model => model.BankAddress)%></div>
                    </div>
                </div>
                <div class="form-box1-row">
                    <div class="form-box1-row-content float-left">
                        <div>
                            <label>
                                <%: Html.Label("Country") %></label>
                            <%: Html.DropDownListFor(model => model.CountryId, Model.ddlCountriesList)%>
                            <%: Html.ValidationMessageFor(model => model.BankName)%>
                        </div>
                    </div>
                </div>
                <div class="form-box1-row">
                    <div class="form-box1-row-content float-left">
                        <div>
                            <label>
                                <%: Html.Label("Phone No") %></label>
                            <%: Html.TextBoxFor(model => model.PhoneNo)%><span class="redtxt">*</span>
                            <%: Html.ValidationMessageFor(model => model.PhoneNo)%>
                        </div>
                    </div>
                </div>
                <div class="form-box1-row">
                    <div class="form-box1-row-content float-left">
                        <div>
                            <label>
                                <%: Html.Label("Contact Person") %></label>
                            <%: Html.TextBoxFor(model => model.ContactPerson)%><span class="redtxt">*</span>
                            <%: Html.ValidationMessageFor(model => model.ContactPerson)%></div>
                    </div>
                </div>
                <div class="form-box1-row">
                    <div class="form-box1-row-content float-left">
                        <div>
                            <label>
                                <%: Html.Label("Contact Phone No") %></label>
                            <%: Html.TextBoxFor(model => model.ContactPersonPhoneNo) %>
                            <%: Html.ValidationMessageFor(model => model.ContactPersonPhoneNo)%></div>
                    </div>
                </div>
                <div class="form-box1-row">
                    <div class="form-box1-row-content float-left">
                        <div>
                            <label>
                                <%: Html.Label("Contact Mobile No") %></label>
                            <%: Html.TextBoxFor(model => model.ContactPersonMobileNo) %>
                            <%: Html.ValidationMessageFor(model => model.ContactPersonMobileNo)%></div>
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
                <div class="buttonBar">
                <input type="button" value="Branch-->" id="Button2" class="save" style="visibility:hidden;"/>
                <%Html.RenderPartial("Utility/PVC_MessagePanel"); %> 
               <%-- <input type="button" value="Save" class="save" id="Button1" />--%>
                <input type="submit" value="Save" class="btn1" /></li>
                 <%:Html.ActionLink("Cancel", "Index", new { controller = "BankManagement" }, new { @class = "linkButton float-right" })%>
            </div>
            
           
               
        </div>
         <%:Html.HiddenFor(model => model.hfCheckBankOrBranch)%>
        <%:Html.HiddenFor(model=>model.hfCount) %>
      
    <%} %>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CssContent" runat="server">
 <link href="../../../../Content/themes/redmond/jquery.ui.all.css" rel="stylesheet" type="text/css" />
    <link href="../../../../Content/themes/redmond/jquery.ui.base.css" rel="stylesheet" type="text/css" />

    <style type="text/css">
        label.error
        {
            color: red;
            margin-right: 21px;
            text-align: center;
            width: 10px !important;
            float: right !important;
        }
    </style>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
    <script src="../../../../Scripts/ATL.core.function.js" type="text/javascript"></script>
    <script src="../../../../Scripts/jquery.validate.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            var selectedTab = 0;
            $("#tabs").tabs({
                select: function (event, ui) {
                    selectedTab = ui.index;

                    //$("#hfCheckBankOrBranch").val(selectedTab);
                }
            });
            resetId(tableId);

            $("#next").click(function () {
                var $tabs = $('#tabs').tabs();
                $tabs.tabs('option', 'disabled', []); //To make no tab is disabled
                $tabs.tabs('select', 1); // switch to third tab
                return false;

            });

            //     NumericValidation("PhoneNo");
            //   NumericValidation("ContactPersonPhoneNo");
            //     NumericValidation("ContactPersonMobileNo");
            //    NumericValidation("BranchPhoneNumber");
            //     NumericValidation("BranchContactPhoneNo");

            ///////////////////////For submitting///////////////////////////////////////////
            $("#sabmit").live("click", function () {
                $("#hfCount").val(tblRowIncrease);
                if (selectedTab == 1) {
                    $("#hfCheckBankOrBranch").val('1');
                    SaveBranch();
                }
                else {
                   
                    
                    $("#hfCheckBankOrBranch").val('0');
                    var BankName = $("#BankName").val();
                    var BankAddress = $("#BankAddress").val();
                    var CountryId = $("#CountryId").val();
                    var BankPhoneNo = $("#PhoneNo").val();
                    var ContactPerson = $("#ContactPerson").val();
                    var ContactPersonPhoneNo = $("#ContactPersonPhoneNo").val();
                    var ContactPersonMobileNo = $("#ContactPersonMobileNo").val();
                    var ContactPersonEmail = $("#ContactPersonEmail").val();
                    $.post(
		"/Administrator/AjaxRequest/AddBank",
		{ CountryId: CountryId, BankName: BankName, BankPhoneNo: BankPhoneNo, BankAddress: BankAddress, ContactPersonPhoneNo: ContactPersonPhoneNo, ContactPersonMobileNo: ContactPersonMobileNo, ContactPerson: ContactPerson, ContactPersonEmail: ContactPersonEmail },
		function (data) {
		    //enable tab here
		    if (data != null) {
		        $('#tabs').tabs('enable', 1);
		        $("#next").css('visibility', 'visible');
		    }
		},
        "json"
		);
                }
            });
            ////For Disabling Enter Button to submit///////////////////
            $(window).keydown(function (event) {
                if (event.keyCode == 13) {
                    event.preventDefault();
                    return false;
                }
            });
            $('#tabs').tabs('disable', 1);
        });

        //////////////////////For Saving Branch//////////////////////////////
        function SaveBranch() {
            var data = "";
            data = $("#form0").serialize();
            
            $.ajax({
                async: false,
                type: "POST",
                url: "/BankManagement/Create",
                //dataType : 'html',
                data: data,
                //contentType : "text/json",
                //data: ({ id: this.getAttribute('id') }),
                //completed: $.unblockUI(),
                success: function (result) {
                    //$(this).addClass("done");
                    // var domElement = $(result); // create element from html
                    // $("#DivFormContent").append(domElement); // append to end of list    
                   
                }
            });
        }

       
           
         
    </script>
</asp:Content>
