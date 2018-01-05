﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/DistributorMain.Master"
    Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Administrator.Models.AgentModel>" %>

<%@ Import Namespace="TravelPortalEntity" %>
<%@ Import Namespace="ATLTravelPortal.Areas.Administrator.Models" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    ArihantHolidays.com | Edit Agent Info
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <%Html.RenderPartial("Utility/VUC_MessagePanel"); %>
    <% Html.EnableClientValidation(); %>
    <% using (Html.BeginForm("Edit", "DistributorAgentManagement", FormMethod.Post, new { @autocomplete = "off", enctype = "multipart/form-data" }))
       {%>
    <%: Html.ValidationSummary(true)%>
    <%: Html.HiddenFor(model=>model.RedirectedFrom) %>
    <div class="pageTitle">
        <div class="float-right">
            <ul>
                <li>
                    <%Html.RenderPartial("Utility/PVC_MessagePanel"); %>
                </li>
                <li>
                <% if (Model.RedirectedFrom == "BranchOfficeManagement")
                   { %>
                    <input type="button" value="Cancel" class="cancel" onclick="document.location.href='/Administrator/BranchOfficeManagement/AgentList/<%:Model.BranchOfficeId %>'" />
                <%} %>
                <% else if (Model.RedirectedFrom == "DistributorManagement")
                   { %>
                    <input type="button" value="Cancel" class="cancel" onclick="document.location.href='/Administrator/DistributorManagement/AgentList/<%:Model.DistributorId %>'" />
                <%} %>
                <% else if (Model.RedirectedFrom == "BranchDistributorManagement")
                   { %>
                    <input type="button" value="Cancel" class="cancel" onclick="document.location.href='/Administrator/BranchDistributorManagement/AgentList/<%:Model.DistributorId %>'" />
                <%} %>

                <% else
                   { %>
                    <input type="button" value="Cancel" class="cancel" onclick="document.location.href='/Administrator/DistributorAgentManagement'" />
                    <%} %>
                    </li>
            </ul>
        </div>
     
        <h3>
            <a href="#">Agent Management</a> <span>&nbsp;</span><strong>Agents</strong><span>&nbsp;</span><strong>Edit
                Basic Info</strong>
        </h3>
    </div>
   
    <div class="wiz-container">
       <%-- <ul>
            <li><a href="javascript: void(0)" class="wiz-anc-done wiz-anc-default">
                <h2>
                    1. Choose Product</h2>
            </a></li>
        </ul>--%>
      
        <div class="wiz-body">
          
            <div id="wizard-1">
                <div class="wiz-content">
                    <div class="row-1">
                      <%--  <div class="form-box1 round-corner">
                            <h5>
                                Choose Product</h5>
                            <div>
                                <ul class="productselection-box ">
                                    <% foreach (var agentAssociatedProduct in Model.ProductBaseRoleList)
                                       { %>
                                    <%if ((ModelAgentProductExtension.IsActiveAgentProduct(agentAssociatedProduct.ProductId, Model.AgentProductList)) == true)
                                      { %>
                                    <li>
                                        <img src="../../../../Content/images/productimage/<%=agentAssociatedProduct.ProductId%>.jpg"
                                            alt="" id='img1' />
                                        <input type="checkbox" name="ChkProductId" value="<%=agentAssociatedProduct.ProductId%>"
                                            checked="checked" id="ProductId<%=agentAssociatedProduct.ProductId%>" />
                                        <%=agentAssociatedProduct.ProductName%><br />
                                        <label>
                                            Role:</label><br />
                                        <%=Html.DropDownList("RoleId" + agentAssociatedProduct.ProductId, (SelectList)ViewData[agentAssociatedProduct.ProductName], new { @id = "RoleId" + agentAssociatedProduct.ProductId })%>
                                    </li>
                                    <%}
                                      else
                                      { %>
                                    <li>
                                        <img src="../../../../Content/images/productimage/<%=agentAssociatedProduct.ProductId%>.jpg"
                                            alt="" id='img2' />
                                        <input type="checkbox" name="ChkProductId" value="<%=agentAssociatedProduct.ProductId%>"
                                            id="ProductId<%:agentAssociatedProduct.ProductId%>" />
                                        <%=agentAssociatedProduct.ProductName%>
                                        <br />
                                        <label>
                                            Role:</label><br />
                                        <select id="RoleId<%= agentAssociatedProduct.ProductId %>" name="RoleId<%= agentAssociatedProduct.ProductId %>">
                                            <option value="">---Not Selected---</option>
                                        </select>
                                    </li>
                                    <%} %>
                                    <%}%>
                                </ul>
                            </div>
                        </div>--%>
                        <div id="check_IfChecked" class="checkIfExsit">
                        </div>
                    </div>
                  
                    <div class="wiz-nav">
                        <ul>
                            <li><a href="javascript: void(0)" class="wiz-anc-done wiz-anc-default">
                                <h2>
                                    1. Agent Basic Info</h2>
                            </a></li>
                        </ul>
                    </div>
                </div>
             
                <div id="wizard-2">
                    <div class="wiz-content">
                        <div class="row-1">
                            <div class="form-box1 round-corner">
                                <div class="form-box1-row">
                                    <div class="form-box1-row-content float-left">
                                        <div>
                                            <label>
                                                <%: Html.Label("Agent Name") %></label>
                                            <%: Html.TextBoxFor(model => model.AgentName, new { id = "agent_name" })%>
                                            <%: Html.ValidationMessageFor(model => model.AgentName,"*") %>
                                            <span class="redtxt">*</span>
                                            <div id="check_agentname" class="checkIfExsit">
                                            </div>
                                        </div>
                                    </div>
                                    <div class="form-box1-row-content float-right">
                                        <div>
                                            <label>
                                                <%: Html.Label("Address") %></label>
                                            <%: Html.TextBoxFor(model => model.Address)%>
                                            <%: Html.ValidationMessageFor(model => model.Address,"*") %><span class="redtxt">*</span>
                                        </div>
                                    </div>
                                </div>
                                <div class="form-box1-row">
                                    <div class="form-box1-row-content float-left">
                                        <div>
                                            <label>
                                                <%: Html.Label("Phone Number") %></label>
                                            <%: Html.TextBoxFor(model => model.Phone)%>
                                            <%: Html.ValidationMessageFor(model => model.Phone,"*")%>
                                            <span class="redtxt">*</span>
                                        </div>
                                    </div>
                                    <div class="form-box1-row-content float-right">
                                        <div>
                                            <label>
                                                <%: Html.Label("Email Address") %></label>
                                            <%: Html.TextBoxFor(model => model.Email)%>
                                            <%: Html.ValidationMessageFor(model => model.Email,"*")%><span class="redtxt">*</span>
                                            <div id="check_Email" class="checkIfExsit">
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="form-box1-row">
                                    <div class="form-box1-row-content float-left">
                                        <div>
                                            <label>
                                                <%: Html.Label("Fax Number") %></label>
                                            <%: Html.TextBoxFor(model => model.FaxNo) %>
                                            <%: Html.ValidationMessageFor(model => model.FaxNo,"*")%>
                                        </div>
                                    </div>
                                    <div class="form-box1-row-content float-right">
                                        <div>
                                            <label>
                                                <%: Html.Label("PAN Number") %></label>
                                            <%: Html.TextBoxFor(model => model.PanNo) %>
                                            <%: Html.ValidationMessageFor(model => model.PanNo,"*")%>
                                        </div>
                                    </div>
                                </div>
                                <div class="form-box1-row">
                                    <div class="form-box1-row-content float-left">
                                        <div>
                                            <label>
                                                <%: Html.Label("URL") %></label>
                                            <%: Html.TextBoxFor(model => model.Web) %>
                                            <%: Html.ValidationMessageFor(model => model.Web,"*")%>
                                        </div>
                                    </div>
                                    <div class="form-box1-row-content float-right">
                                    </div>
                                </div>
                                <div class="form-box1-row">
                                    <div class="form-box1-row-content float-left">
                                        <div>
                                            <label>
                                                <%: Html.Label("Agent Country") %></label>
                                            <%: Html.DropDownListFor(model => model.NativeCountryId, (SelectList)ViewData["Countrylist"], "---Select Country---", new { @class = "required" })%>
                                            <%: Html.ValidationMessageFor(model => model.NativeCountryId)%><span class="redtxt">*</span>
                                        </div>
                                    </div>
                                    <div class="form-box1-row-content float-right">
                                        <div>
                                            <label>
                                                <%: Html.Label("Status") %></label>
                                            <%: Html.DropDownListFor(model => model.AgentStatusid, (SelectList)ViewData["Status"])%>
                                            <%: Html.ValidationMessageFor(model => model.AgentStatusid)%>
                                        </div>
                                    </div>
                                </div>
                                <div class="form-box1-row">
                                    <div class="form-box1-row-content float-left">
                                        <div>
                                            <label>
                                                <%: Html.Label("Agent Zone")%></label>
                                            <%: Html.DropDownListFor(model => model.ZoneId, (SelectList)ViewData["AgentZone"], "---Select zone---", new { disabled = "disabled" })%>
                                        </div>
                                    </div>
                                    <div class="form-box1-row-content float-right">
                                        <div>
                                            <label>
                                                <%: Html.Label("Agent District")%></label>
                                            <%: Html.DropDownListFor(model => model.DistrictId, (SelectList)ViewData["AgentDistrict"], "---Select district---")%>
                                        </div>
                                    </div>
                                </div>
                                <div class="form-box1-row">
                                    <div class="form-box1-row-content float-left">
                                        <div>
                                            <label>
                                                <%: Html.Label("Agent Type") %></label>
                                            <%: Html.DropDownListFor(model => model.AgentTypeId, (SelectList)ViewData["AgentTypes"], "---Select Type---", new { @class = "required" })%><span
                                                class="redtxt">*</span>
                                        </div>
                                    </div>
                                    <div class="form-box1-row-content float-right">
                                        <div>
                                            <label>
                                                <%: Html.Label("Agent Code") %></label>
                                            <%: Html.TextBoxFor(model => model.AgentCode, new {@readonly="readonly" })%>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                 
                    <div class="wiz-nav">
                        <ul>
                            <li><a href="javascript: void(0)" class="wiz-anc-done wiz-anc-default">
                                <h2>
                                    2. Agent Setting</h2>
                            </a></li>
                        </ul>
                    </div>
                </div>
             
                <div>
                   
                    <div class="wiz-content">
                        <div class="row-1">
                            <div class="form-box1 round-corner">
                                <div class="form-box1-row">
                                 
                                    <%if (Model.MaxNumberOfAgentUser == -1)
                                      { %>
                                    <div class="form-box1-row-content float-left">
                                        <div>
                                            <label>
                                                <%: Html.Label("Unlimited User") %></label>
                                            <%: Html.CheckBox("Unlimiteduser",true, new { @id="cbunlimiteduser" })%>
                                        </div>
                                    </div>
                                    <%}
                                      else
                                      {%>
                                  
                                    <div class="form-box1-row-content float-left">
                                        <div>
                                            <label>
                                                <%: Html.Label("Unlimited User") %></label>
                                            <%: Html.CheckBox("Unlimiteduser",false, new { @id="cbunlimiteduser" })%>
                                        </div>
                                    </div>
                                    <%} %>
                                 
                                    <div class="form-box1-row-content float-right">
                                        <div id="limiteduser">
                                            <label>
                                                <%: Html.Label("Max Number of User") %></label>
                                            <%: Html.TextBoxFor(model => model.MaxNumberOfAgentUser, new { @class = "required" })%>
                                            <%: Html.ValidationMessageFor(model => model.MaxNumberOfAgentUser,"*")%>
                                        </div>
                                    </div>
                                </div>
                                <div class="form-box1-row">
                                    <div class="form-box1-row-content float-left">
                                        <div>
                                            <label>
                                                <%: Html.Label("Airline Group List") %></label>
                                            <%: Html.DropDownListFor(model => model.AirlineGroupId, Model.AirlineGroupList )%>
                                        </div>
                                    </div>
                                   
                                </div>
                                <div class="form-box1-row">
                                    <div class="form-box1-row-content float-right">
                                        <div>
                                            <label>
                                                <%: Html.Label("Time Zone") %></label>
                                            <%: Html.DropDownListFor(model => model.TimeZoneId, (SelectList)ViewData["TimeZones"])%>
                                        </div>
                                    </div>
                                    <%--....................................--%>
                                </div>
                            </div>
                            <div id="check_Field" class="checkIfExsit">
                            </div>
                        </div>
                   
                    </div>
                    <div class="wiz-nav">
                        <ul>
                            <li><a href="javascript: void(0)" class="wiz-anc-done wiz-anc-default">
                                <h2>
                                    3. Agent Authorize User</h2>
                            </a></li>
                        </ul>
                    </div>
                    <div id="check_Field" style="display: block;">
                    </div>
                </div>
              
                <div>
                    <div class="wiz-content">
                        <div class="form-box1 round-corner">

                         <div class="form-box1-row">
                                 <div class="form-box1-row-content float-left">
                                    <div>
                                        <label>
                                            <%: Html.Label("Mobile Number") %>
                                        </label>
                                        <%:  Html.TextBoxFor(model => model.MobileNo)%><span
                                            class="redtxt">*</span>
                                        <%: Html.ValidationMessage("MobileNo")%>
                                        <div id="check_mobileNumber" class="checkIfExsit">
                                        </div>
                                    </div>
                                </div>
                               <div class="form-box1-row-content float-right">
                                    <div>
                                        <label>
                                            <%: Html.Label("Phone Number") %>
                                        </label>
                                        <%:  Html.TextBoxFor(model => model.PhoneNo)%>
                                        <%: Html.ValidationMessage("PhoneNo")%>
                                    </div>
                                </div>
                            </div>


                            <div class="form-box1-row">
                                <div class="form-box1-row-content float-left">
                                    <div>
                                        <label>
                                            <%: Html.Label("Full Name") %></label>
                                        <%: Html.TextBoxFor(model => model.FullName)%><span class="redtxt">*</span>
                                        <%: Html.ValidationMessage("FullName")%>
                                    </div>
                                </div>
                                <div class="form-box1-row-content float-right">
                                    <div>
                                        <label>
                                            <%: Html.Label("User Name") %></label>
                                        <%: Html.TextBoxFor(model => model.UserName, new { id = "login_name", @readonly = "readonly" })%>
                                        <div id="check_username" style="display: block;">
                                        </div>
                                        <%: Html.ValidationMessage("UserName")%>
                                    </div>
                                </div>
                            </div>
                            <div class="form-box1-row">
                                <div class="form-box1-row-content float-left">
                                    <div>
                                        <label>
                                            <%: Html.Label("Password") %></label>
                                        <%: Html.PasswordFor(model => model.Password, new { @value = "passabcdtest1234", @readonly = "readonly" })%><span
                                            class="redtxt">*</span>
                                        <%: Html.ValidationMessage("Password")%>
                                    </div>
                                </div>
                                <div class="form-box1-row-content float-right">
                                    <div>
                                        <label>
                                            <%: Html.Label("Confirm Password ") %></label>
                                        <%:  Html.PasswordFor(model => model.ConfirmPassword, new { @value = "passabcdtest1234", @readonly = "readonly" })%><span
                                            class="redtxt">*</span>
                                        <%: Html.ValidationMessage("ConfirmPassword")%>
                                    </div>
                                </div>
                            </div>
                            <div class="form-box1-row" id="freeEmailArea">
                                <div class="form-box1-row-content float-left">
                                    <div>
                                        <label>
                                            <%:Html.Label("Email Address")%></label>
                                        <%:Html.TextBoxFor(model => model.EmailId)%><span class="redtxt">*</span>
                                        <%: Html.ValidationMessageFor(model => model.EmailId)%>
                                    </div>
                                </div>
                                <div class="form-box1-row-content float-right">
                                    <div>
                                        <label>
                                            <%: Html.Label("Address") %>
                                        </label>
                                        <%:Html.TextBoxFor(model => model.Address1)%>
                                    </div>
                                </div>
                            </div>
                            
                           
                        </div>
                    </div>
                    <div class="wiz-nav">
                    <input type="submit" value="update" class="save" id="CreateNew" />
                </div>
                </div>
              
               
               
            </div>
        </div>
       
        <div id="check_Field" class="checkIfExsit">
        </div>
        <div id="check_IfChecked" class="checkIfExsit">
        </div>
        <%} %>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CssContent" runat="server">
    <link href="../../../../Content/style_wizard.css" rel="stylesheet" type="text/css" />
    <link href="../../../../Content/css/slidedeck.skin.css" rel="stylesheet" type="text/css" />
    <link href="../../../../Content/css/slidedeck.skin.ie.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .form-box1-row-content div span.field-validation-error
        {
            display: none;
        }
    </style>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
    <script src="../../../../Scripts/jquery-1.5.1.min.js" type="text/javascript"></script>
    <script src="../../../../Scripts/jquery-ui-1.8.13.custom.min.js" type="text/javascript"></script>
    <script src="../../../../Scripts/jquery.validate.js" type="text/javascript"></script>
    <script src="../../../../Scripts/slidedeck.jquery.lite.js" type="text/javascript"></script>
 <script type="text/javascript">
     $('.extendBtn').live("click", function (event) {
         event.preventDefault();
         if ($('.balanceContent').css("display") == "none") {
             $('.balanceContent').css('display', 'block');
             $(this).addClass('expanded').removeClass('collapsed');
         }
         else {
             $('.balanceContent').css('display', 'none');
             $(this).addClass('collapsed').removeClass('expanded');
         }
     });
</script>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#ZoneId").attr("disabled", false);
            $('.validate').validate();
            $(".showDatePicker").datepicker();
            $('.ChkBoxParent').click(function () {
                $('.ChkBoxChild').attr('checked', $(this).attr('checked'));
            });
            ///////////////////////////////////////////////////////////////////////////////
            ////////////////////////////////////////////////////////////////////////////////
            $('.ChkBoxChild').click(function () {
                var childCheckBox = $('.ChkBoxChild');
                var checkedAllStatus = true;
                for (var i = 0; i < childCheckBox.length; i++) {
                    if (!$(childCheckBox[i]).is(':checked')) {
                        checkedAllStatus = false;
                    }
                }
                $('.ChkBoxParent').attr('checked', checkedAllStatus);
            });
            ////////////////////////////////////////////////////////////////////////////////////////////////////////
            ///////////////////////////////////handling checkbox on image click event and label click event//////////////////////
            var cbox1 = $('#ProductId1')[0];
            var cbox2 = $('#ProductId2')[0];
            $('#imgproduct1').click(function () {
                cbox1.checked = !cbox1.checked;
            });
            $('#imgproduct2').click(function () {
                cbox2.checked = !cbox2.checked;
            });
            ////////////////////////////////////////////////////////////////////////////////////////////
            /////////////////// Toggle check box for IATA info //////////////
            $(function () {
                var cb1 = $("#cb1");
                cb1.change(toggle_cb1);

                toggle_cb1.call(cb1[0]);
            });

            function toggle_cb1() {
                if ($(this).is(":checked")) {
                    $("#IATA").show();
                } else {
                    $("#IATA").hide();
                    $('#IATA').val('');
                }
            }

            ///////////////////////////////////////////////////////////////////////////////////////
            /////////////////// Toggle check box for max user or unlimited user field /////////
            $(function () {
                var cb2 = $("#cbunlimiteduser");
                cb2.change(toggle_cb2);
                toggle_cb2.call(cb2[0]);
            });

            function toggle_cb2() {
                if ($(this).is(":checked")) {
                    $("#limiteduser").hide(50);
                } else {
                    $("#limiteduser").show();
                    // $("#MaxNumberOfAgentUser").val('');

                }
            }
            ///////////////////////////////////////////////////////////////////////////////////////////
            ///////////////////// Validate checkbox to choose atleast one ////////////////
//            $("#save").click(function () {

//                var fields = $("input[name='ChkProductId']").serializeArray();
//                if (fields.length == 0) {
//                    $("#check_IfChecked").show();
//                    $("#check_IfChecked").attr({ color: "Red" });
//                    $("#check_IfChecked").html("<span style = 'color:red'>Please Choose Atleast one Product.</span>")
//                    return false;
//                }
//                else {
//                    document.getElementById("check_IfChecked").innerHTML = "";
//                }
//            });
            //////////////////////////////////////////////////////////////////////////////////////////////
            //            ////////////// Validate credit limit field allowing only integer /////////////////////// 
            //            $('#CreditLimit').keyup(function () {
            //                var d = $(this).attr('numeric');
            //                var value = $(this).val();
            //                var orignalValue = value;
            //                value = value.replace(/[0-9]*/g, "");
            //                var msg = "Only Integer Values allowed.";
            //                if (d == 'decimal') {
            //                    value = value.replace(/\./, "");
            //                    msg = "Only Numeric Values allowed.";
            //                }
            //                if (value != '') {
            //                    orignalValue = orignalValue.replace(/([^0-9].*)/g, "")
            //                    $(this).val(orignalValue);
            //                    //alert(msg);
            //                    //$(this).after('<span style="margin-left:5px;color:red;position:absolute;">' + msg + '</span>');
            //                }
            //                else {
            //                    //$(this).next('span').remove();
            //                }
            //            });
            //////////////////////////////////////////////////////////////////////////////////////////////////////
            /////////////////////// Disable dropdownllist if parent Country dropdownlist is not Nepal////////////
            $("#NativeCountryId").bind("change", function () {
                if (this.value !== "1") {
                    $("#ZoneId").attr("disabled", true);
                    $("#DistrictId").attr("disabled", true);
                    return true;
                }
                $("#ZoneId").attr("disabled", false);
                $("#DistrictId").attr("disabled", false);
            });
            ///////////////////////////////////////////////////////////////////////////////////////////////

            ////////////////////////////////////////////////////////////////////////////////////////////
            //////////// Get Branch name with respect to bank name
            $("#BankId").live("change", function () {
                id = $("#BankId").val();
                if (id == "") {
                    return false;
                }
                else {
                    $("#loadingIndicator").html('<center><img src="<%=Url.Content("~/Content/images/indicator.gif") %>" alt="" width="16px" height="16px" />   </center>');

                    //build the request url
                    var url = "/Administrator/AjaxRequest/GetBranchListbyBankId";
                    //fire off the request, passing it the id which is the MakeID's selected item value
                    $.getJSON(url, { id: id }, function (data) {
                        //Clear the Model list
                        $("#BankBranchId").empty();
                        //Foreach Model in the list, add a model option from the data returned
                        $.each(data, function (index, optionData) {

                            $("#BankBranchId").append("<option value='" + optionData.Value + "'>" + optionData.Text + "</option>");
                        });
                        $("#loadingIndicator").html('');
                    });
                }
            }).change();
            //// ////// /////////////////// Adding Agent Bank ///////////////////////////////////////////////////////

            $("#add-AgentBank-button").click(function () {
                var agentId = $("#hfAId").val();
                var bankId = $("#BankId").val();
                var branchId = $("#BankBranchId").val();
                var accountTypeId = $("#BankAccountTypeId").val();
                var accountname = $("#AccountName").val();
                var accountnumber = $("#AccountNumber").val();
                var id = 0;
                var banktype = $("#BankTypeId").val();
                $.post(
		"/Administrator/AjaxRequest/AddUpdateAgentBank",
		{ id: id, agentId: agentId, bankId: bankId, branchId: branchId, accountTypeId: accountTypeId, accountname: accountname, accountnumber: accountnumber, banktype: banktype },
		function (data) {
		    var html = '<tr id="AgentBank-method-' + data.AgentBankId + '">';
		    html += '<td>' + data.BankName + '</td>';
		    html += '<td>' + data.BankBranchName + '</td>';
		    html += '<td>' + data.BankAccountTypeName + '</td>';
		    html += '<td>' + data.AccountName + '</td>';
		    html += '<td>' + data.AccountNumber + '</td>';

		    html += '<td>' + data.BankType + '</td>';

		    //		    alert(data.BankType);

		    html += '<td><a href="#" class="edit-AgentBank-method-button" meta:id="' + data.AgentBankId + '"><img border="0" class="edit" src="" title="Edit"/></a><a href="#" class="delete-AgentBank-method-button" meta:id="' + data.AgentBankId + '"><img border="0" class="delete" src="" title="Delete"/></a></td>';
		    html += '<td style = "display: none;">' + data.BankId + '</td>';
		    html += '<td style = "display: none;">' + data.BankBranchId + '</td>';
		    html += '<td style = "display: none;">' + data.BankAccountTypeId + '</td>';

		    //		    html += '<td style = "display: none;">' + data.BankTypeId + '</td>';

		    html += '</tr>';

		    $("#AgentBank-table tbody").append(html);
		    $("#AccountName").val("");
		    $("#AccountNumber").val("");
		    $("#BankId").val("");
		    $("#BankBranchId").val("");
		    $("#BankAccountTypeId").val("");

		    $("#BankType").val("");
		    //		    $("#BankTypeId").val("");
		    // $("#hfAId").val(data.AgentId);
		},
		"json"
	);

                return false;
            });
            ///////////////////////////////////////////////////////////////////////////////////////
            /////////////////// Deleting AgentBank /////////////////////////////////////////////////

            $(".delete-AgentBank-method-button").live("click", function () {
                var AgentBankId = $(this).attr("meta:id");
                if (confirm("Do you want to delete this record?")) {
                    $.post(
		"/Administrator/AjaxRequest/DeleteAgentBank",
		{ id: AgentBankId },
		function (data) {
		    $("#AgentBank-method-" + data).css("background-color", "lightgreen");
		    $("#AgentBank-method-" + data).fadeOut("slow", function () { $(this).remove() });
		},
		"json"
	);
                }
                return false;
            });


            ////////////////////////////////////////////////////////////////////////////////////////////
            /////////////////////  Editing Agent Bank  ////////////////////////////////////////////////
            $(".edit-AgentBank-method-button").click(function () {
                var id = $(this).attr("meta:id");
                var BankName = $(this).closest('tr').find('td').eq(0).text();
                var BranchName = $(this).closest('tr').find('td').eq(1).text();
                var AccountType = $(this).closest('tr').find('td').eq(2).text();
                var accountname = $(this).closest('tr').find('td').eq(3).text();
                var accountnumber = $(this).closest('tr').find('td').eq(4).text();
                var bankId = $(this).closest('tr').find('td').eq(5).text();
                var branchId = $(this).closest('tr').find('td').eq(6).text();
                var accountTypeId = $(this).closest('tr').find('td').eq(7).text();
                var banktypeId = $(this).closest('tr').find('td').eq(8).text();


                $('#BankId').val(bankId);
                $('#BankBranchId').val(branchId);
                $('#BankAccountTypeId').val(accountTypeId);
                $('#AccountName').val(accountname)
                $('#AccountNumber').val(accountnumber)


                $('#BankTypeId').val(banktypeId)

                // $("#hfAId").val(0);
            });


        });
        /////////////////////////////////// Changing Dropdownlist on selecting parent list /////////////
        /////// Get Districts name with respect to Zones Name////////////////////////////////////
        $("#ZoneId").live("change", function () {
            id = $("#ZoneId").val();
            if (id == "") {
                return false;
            }
            else {
                $("#loadingIndicator").html('<center><img src="<%=Url.Content("~/Content/images/indicator.gif") %>" alt="" width="16px" height="16px" />   </center>');

                //build the request url
                var url = "/Administrator/AjaxRequest/GetDistrictOptionsByZoneId";
                //fire off the request, passing it the id which is the MakeID's selected item value
                $.getJSON(url, { id: id }, function (data) {
                    //Clear the Model list
                    $('#DistrictId').removeAttr('disabled');
                    $("#DistrictId").empty();

                    //Foreach Model in the list, add a model option from the data returned
                    $.each(data, function (index, optionData) {

                        $("#DistrictId").append("<option value='" + optionData.Value + "'>" + optionData.Text + "</option>");
                    });
                    $("#loadingIndicator").html('');
                });
            }
        }).change();
        ///////////////////////////////////////////////////////////////////////////////////////////////////

        /////// Get UserTypeRole on selecting Product////////////////////////////////////
        $('[id^="ProductId"]').live("change", function () {
            var id = this.id.match(/\d/);
            var val = id[0];
            if (($("#ProductId" + val).is(':checked')) == false) {
                $("#RoleId" + val).removeAttr('class');
                $("#RoleId" + val).empty();
                $("#RoleId").append("<option value=''>" + "-- Select--" + "</option>");
            }
            else {
                $("#loadingIndicator").html('<center><img src="<%=Url.Content("~/Content/themes/base/images/ui-anim_basic_16x16.gif") %>" alt="" width="16px" height="16px" /></center>');
                //build the request url
                var url = "/Administrator/AjaxRequest/GetRolesonSubProductId";
                //fire off the request, passing it the id which is the MakeID's selected item value
                $.getJSON(url, { ProductId: val, SubProductId: 2 }, function (data) {
                    //Clear the Model list
                    $("#RoleId" + val).empty();
                    $("#RoleId" + val).attr('class', 'required');
                    //  $("#RoleId").append("<option value=''>" + "-- Select--" + "</option>");
                    //Foreach Model in the list, add a model option from the data returned
                    $.each(data, function (index, optionData) {

                        $("#RoleId" + id).append("<option value='" + optionData.Value + "'>" + optionData.Text + "</option>");
                    });
                    $("#loadingIndicator").html('');
                });
            }
        }).change();
        ////////////////////////////////////////////////////////////////////////////////////////////


        ////////////////////////////////////////////////////////////////////////////////////////////
        $(document).ready(function () {
            $("#Email").blur(function () {
                var email = $("#Email").val();
                if (email == "") {
                    return false;
                }
                $("#imageLoaderDiv").show();

                $.post("/Administrator/AjaxRequest/CheckDuplicateEmail", { Email: email }, function (data) {
                    if (data) {
                        $("#imageLoaderDiv").hide();
                        $("#check_Email").show();
                        $("#check_Email").attr({ color: "Green" });
                        $("#check_Email").html("<span style='color:green'><b>Mobile Number available.</b></span>");
                    }
                    else {
                        $("#imageLoaderDiv").hide();
                        $("#check_Email").show();
                        $("#check_Email").attr({ color: "Red" });
                        $("#check_Email").html("<span style = 'color:red'>Email already exists!")
                        $('#check_Email').val(email);
                    }
                }, "json");
            });
        });
        ////////////////////////////////////////////////////////////////////////////////////////////

        ////////////////////////////////////////////////////////////////////////////////////////////
        $(document).ready(function () {
            $("#MobileNo").blur(function () {
                var mobileNumber = $("#MobileNo").val();
                if (mobileNumber == "") {
                    return false;
                }
                $("#imageLoaderDiv").show();

                $.post("/Administrator/AjaxRequest/CheckDuplicateMobileNumber", { MobileNumber: mobileNumber }, function (data) {
                    if (data) {
                        $("#imageLoaderDiv").hide();
                        $("#check_mobileNumber").show();
                        $("#check_mobileNumber").attr({ color: "Green" });
                        $("#check_mobileNumber").html("<span style='color:green'><b>Mobile Number available.</b></span>");
                    }
                    else {
                        $("#imageLoaderDiv").hide();
                        $("#check_mobileNumber").show();
                        $("#check_mobileNumber").attr({ color: "Red" });
                        $("#check_mobileNumber").html("<span style = 'color:red'>Mobile Number already exists!")
                        $('#check_mobileNumber').val(mobileNumber);
                    }
                }, "json");
            });
        });
        ////////////////////////////////////////////////////////////////////////////////////////////
        
    </script>

     <script type="text/javascript">
         $(function () {
             $('input[id$=Email]').keyup(function () {
                 var txtClone = $(this).val();
                 var finaltext = txtClone;
                 $('input[id$=login_name]').val(finaltext);
             });
         });


    </script>
</asp:Content>
