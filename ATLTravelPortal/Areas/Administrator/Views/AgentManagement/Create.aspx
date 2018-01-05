<%@ Page Title="" Language="C#"  MasterPageFile="~/Views/Shared/AdministratorMain.Master" Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Administrator.Models.AgentModel>" %>
<%@ Import Namespace="TravelPortalEntity" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Create Agent | ArihantHolidays.com
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <%Html.RenderPartial("Utility/VUC_MessagePanel"); %>
    <div class="pageTitle">
        <div class="float-right">
            <ul>
                <li>
                    <%Html.RenderPartial("Utility/PVC_MessagePanel"); %>
                </li>
                <li>
                    <label id="Label1">
                    </label>
                </li>
                <li>
                    <input type="button" value="Cancel" class="cancel" onclick="document.location.href='/Administrator/AgentManagement/'" /></li>
            </ul>
        </div>
        <h3>
            <a href="#">Agent Management</a> <span>&nbsp;</span><strong>Agents</strong><span>&nbsp;</span><strong>New
                Agent</strong>
        </h3>
    </div>
    <%if (TempData["ErrorMessage"] != null)
      { %>
    <div style="padding: 0 .7em;" class="ui-state-error ui-corner-all">
        <p>
            <span style="float: left; margin-right: .3em;" class="ui-icon ui-icon-info"></span>
            <strong>
                <% = TempData["ErrorMessage"]%></strong></p>
    </div>
    <%} %>
    <% Html.EnableClientValidation(); %>
    <% using (Html.BeginForm("Create", "AgentManagement", FormMethod.Post, new { @class = "validate", @autocomplete = "off", enctype = "multipart/form-data" }))
       {%>
    <%: Html.ValidationSummary(true) %>
    <%-- -----------------Wizard --- Defining Tab wizard Heading steps contents -----------------------------------%>
    <div class="wiz-container">
        <ul>
            <li><a href="javascript: void(0)" class="wiz-anc-done wiz-anc-default">
                <h2>
                    1. Choose Product</h2>
            </a></li>
        </ul>
        <%-- ----------------- End of Define Tab wizard Heading and steps contents -----------------------------%>
        <%-- ----------------- Begin of Tab wizard body contents ----------------------------------------------%>
        <div class="wiz-body">
            <%-- ----------------------------------Begin Tab wizard No.1 -----------------------------------------------%>
            <div>
                <div class="wiz-content">
                    <div class="row-1">
                        <div class="form-box1 round-corner">
                            <div class="form-box1-row">
                                <h5>
                                    Choose Product</h5>
                                <div>
                                    <ul class="productselection-box ">
                                        <% foreach (var Products in Model.ProductBaseRoleList)
                                           { %>
                                        <li>
                                            <img src="../../../../Content/images/productimage/<%=Products.ProductId%>.jpg" alt=""
                                                id='img1' />
                                            <input type="checkbox" name="ChkProductId" value="<%=Products.ProductId%>" id="ProductId<%=Products.ProductId%>"
                                                class="ProductId" />
                                            <% =Products.ProductName%><br />
                                            <label>
                                                Role:</label><br />
                                            <%=Html.DropDownList("RoleId" + Products.ProductId, (SelectList)ViewData["RoleAssign"],"--- Not Selected ---", new { @id = "RoleId" + Products.ProductId })%>
                                            <%}%>
                                        </li>
                                    </ul>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div id="check_IfChecked" class="checkIfExsit">
                    </div>
                    <%-- -------------End of Body for Tab wizard No.1 --------------%>
                    <%-- -----------Next and Back button--------------%>
                    <div class="wiz-nav">
                        <ul>
                            <li><a href="javascript: void(0)" class="wiz-anc-done wiz-anc-default">
                                <h2>
                                    2. Agent Basic Info</h2>
                            </a></li>
                        </ul>
                    </div>
                </div>
                <%-- ----------------------------------End of Tab wizard No.1 --------------------------------------------%>
                <%-- ----------------------------------Begin Tab wizard No.2 -----------------------------------------------%>
                <div id="wizard-2">
                    <div class="wiz-content">
                        <div class="row-1">
                            <div class="form-box1 round-corner">
                                <div class="form-box1-row">
                                    <div class="form-box1-row-content float-left">
                                        <div>
                                            <label>
                                                <%: Html.Label("Agent Name") %></label>
                                            <%: Html.TextBoxFor(model => model.AgentName, new { id = "agent_name" })%><span class="redtxt">*</span>
                                            <%: Html.ValidationMessageFor(model => model.AgentName,"*") %>
                                            <div id="check_agentname" class="checkIfExsit">
                                            </div>
                                        </div>
                                    </div>
                                    <div class="form-box1-row-content float-right">
                                        <div>
                                            <label>
                                                <%: Html.Label("Address") %></label>
                                            <%: Html.TextBoxFor(model => model.Address)%><span class="redtxt">*</span>
                                            <%: Html.ValidationMessageFor(model => model.Address,"*") %>
                                        </div>
                                    </div>
                                </div>
                                <div class="form-box1-row">
                                    <div class="form-box1-row-content float-left">
                                        <div>
                                            <label>
                                                <%: Html.Label("Phone Number") %></label>
                                            <%: Html.TextBoxFor(model => model.Phone)%>
                                            <span class="redtxt">*</span>
                                            <%: Html.ValidationMessageFor(model => model.Phone,"*")%>
                                        </div>
                                    </div>
                                    <div class="form-box1-row-content float-right">
                                        <div>
                                            <label>
                                                <%: Html.Label("Email Address") %></label>
                                            <%: Html.TextBoxFor(model => model.Email)%><span class="redtxt">*</span>
                                            <%: Html.ValidationMessageFor(model => model.Email,"*")%>
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
                                                <%: Html.Label("Agent Countries") %></label>
                                            <%: Html.DropDownListFor(model => model.NativeCountryId, (SelectList)ViewData["Countrylist"], "---Select Country---", new { @class = "required" })%><span
                                                class="redtxt">*</span>
                                            <%: Html.ValidationMessageFor(model => model.NativeCountryId)%>
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
                                            <%: Html.DropDownListFor(model => model.DistrictId, (SelectList)ViewData["AgentDistrict"], "---Select district---", new { disabled = "disabled" })%>
                                        </div>
                                    </div>
                                </div>
                                <div class="form-box1-row">
                                    <div class="form-box1-row-content float-left">
                                        <div id="AgentTypeDiv">
                                            <label>
                                                <%: Html.Label("Agent Type") %></label>
                                            <%: Html.DropDownListFor(model => model.AgentTypeId, (SelectList)ViewData["AgentTypes"], "---Select Type---", new { @class = "required" })%><span
                                                class="redtxt">*</span>
                                        </div>
                                    </div>
                                    <div class="form-box1-row-content float-right">
                                       <div>
                                            <label>
                                                <%: Html.Label("Referred By")%></label>
                                             <%: Html.DropDownListFor(model => model.RefferedBy, Model.ReferredByList, "---Select---")%>
                                        </div>
                                    </div>
                                    
                                     
                                </div>

                                <div class="form-box1-row-content float-right">
                                       <div>
                                            <label>
                                                <%: Html.Label("ME's")%></label>
                                             <%: Html.DropDownListFor(model => model.MEsId, Model.MEsNameList, "---Select---")%>
                                        </div>
                                    </div>
                            </div>
                        </div>
                    </div>
                    <%-- -------------End of Body for Tab wizard No.2 -----------------------------------%>
                    <%-- -----------Next and Back button----------------------------------------------------%>
                    <div class="wiz-nav">
                        <ul>
                            <li><a href="javascript: void(0)" class="wiz-anc-done wiz-anc-default">
                                <h2>
                                    3. Agent Setting</h2>
                            </a></li>
                        </ul>
                    </div>
                    <%-- ----------------------------------End of Tab wizard No.2 --------------------------------------------%>
                </div>
                <%-- ----------------------------------Begin Tab wizard No.3 --------------------------------------------------%>
                <div id="wizard-3">
                    <div class="wiz-content">
                        <div class="row-1">
                            <div class="form-box1 round-corner">
                                <div class="form-box1-row">
                                    <div class="form-box1-row-content float-left">
                                        <div>
                                            <label>
                                                <%: Html.Label("Unlimited User") %></label>
                                            <%: Html.CheckBox("Unlimiteduser",false, new { @id="cbunlimiteduser" })%>
                                        </div>
                                    </div>
                                    <div class="form-box1-row-content float-right">
                                        <div id="limiteduser">
                                            <label>
                                                <%: Html.Label("Max Number of User") %></label>
                                            <%: Html.TextBoxFor(model => model.MaxNumberOfAgentUser, new { @class = "required" })%><span
                                                class="redtxt">*</span>
                                            <%: Html.ValidationMessageFor(model => model.MaxNumberOfAgentUser,"*")%>
                                        </div>
                                    </div>
                                </div>
                                <div class="form-box1-row">
                                    <div class="form-box1-row-content float-left">
                                        <div>
                                            <label>
                                                <%: Html.Label("Airline Group List") %></label>
                                            <%: Html.DropDownListFor(model => model.AirlineGroupId, (SelectList)ViewData["AirlineGroup"])%>
                                        </div>
                                    </div>
                                    <%--   added newly for time zone--%>
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
                    <%-- --------Next and Back button in tab wizard-------%>
                    <div class="wiz-nav">
                        <ul>
                            <li><a href="javascript: void(0)" class="wiz-anc-done wiz-anc-default">
                                <h2>
                                    4. Agent Authorize User</h2>
                            </a></li>
                        </ul>
                    </div>
                </div>
                <%-- ----------------------------------End of Tab wizard No.3 -------------------------------------------%>
                <%-- ----------------------------------Begin Tab wizard No.4 --------------------------------------------%>
                <div id="wizard-4">
                    <div class="wiz-content">
                        <div class="form-box1 round-corner">
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
                                        <%: Html.TextBoxFor(model => model.UserName, new { id = "login_name" })%><span class="redtxt">*</span>
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
                                        <%: Html.PasswordFor(model => model.Password)%><span class="redtxt">*</span>
                                        <%: Html.ValidationMessage("Password")%>
                                    </div>
                                </div>
                                <div class="form-box1-row-content float-right">
                                    <div>
                                        <label>
                                            <%: Html.Label("Confirm Password ") %></label>
                                        <%:  Html.PasswordFor(model => model.ConfirmPassword) %><span class="redtxt">*</span>
                                        <%: Html.ValidationMessage("ConfirmPassword")%>
                                        <div id="checkpassword">
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="form-box1-row">
                                <div class="form-box1-row-content float-left">
                                    <div>
                                        <label>
                                            <%: Html.Label("Email Address") %></label>
                                        <%:  Html.TextBoxFor(model => model.EmailId)%><span class="redtxt">*</span>
                                        <%: Html.ValidationMessageFor(model => model.EmailId)%>
                                    </div>
                                </div>
                                <div class="form-box1-row-content float-right">
                                    <div>
                                        <label>
                                            <%: Html.Label("Address") %></label>
                                        <%:  Html.TextBoxFor(model => model.Address1)%>
                                    </div>
                                </div>
                            </div>
                            <div class="form-box1-row">
                                <div class="form-box1-row-content float-left">
                                    <div>
                                        <label>
                                            <%: Html.Label("Mobile Number") %></label>
                                        <%:  Html.TextBoxFor(model => model.MobileNo)%>
                                        <div id="check_mobileNumber" class="checkIfExsit">
                                        </div>
                                        <%: Html.ValidationMessage("MobileNo")%>
                                    </div>
                                </div>
                                <div class="form-box1-row-content float-right">
                                    <div>
                                        <label>
                                            <%: Html.Label("Phone Number") %></label>
                                        <%:  Html.TextBoxFor(model => model.PhoneNo)%>
                                        <%: Html.ValidationMessage("PhoneNo")%>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <%-- --------Next and Back button in tab wizard-------%>
                    <div class="wiz-nav">
                        <input type="submit" value="Create" class="save" id="CreateNew" />
                    </div>
                </div>
                <%-- ----------------------------------End of Tab wizard No.4 ---------------------------------------%>
                <div id="errMsg" class="error">
                </div>
            </div>
        </div>
        <%-- ----------------------------------End of Tab wizard here  ----------------------------------------%>
        <% } %>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CssContent" runat="server">
    <link href="../../../../Content/style_wizard.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .form-box1-row-content div span.field-validation-error
        {
            display: none;
        }
    </style>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
    <script src="../../../../Scripts/jquery.validate.js" type="text/javascript"></script>
    <script type="text/javascript">
        ///////////////////////////////////////////////////////////////////////////////////////////////////////
        $(document).ready(function () {
            $('.validate').validate();
            $(".showDatePicker").datepicker();
            $('.ChkBoxParent').click(function () {
                $('.ChkBoxChild').attr('checked', $(this).attr('checked'));
            });

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

            ///////////////////////////////////////////////////////////////////////////////////////////////////////////

            ///////////////////////////////////////////////////////////////////////////////////////////
            $(function () {
                var cb2 = $("#cbunlimiteduser");
                cb2.change(toggle_cb2);
                toggle_cb2.call(cb2[0]);
            });
            function toggle_cb2() {
                if ($(this).is(":checked")) {
                    $("#limiteduser").hide();
                    $('#MaxNumberOfAgentUser').val(50);
                    $('#MaxNumberOfAgentUser').removeAttr('class');
                } else {
                    $("#limiteduser").show();
                    $('#MaxNumberOfAgentUser').attr('class', 'required');
                    $('#MaxNumberOfAgentUser').val('');
                }
            }
            ///////////////////////////////////handling checkbox on image click event and label click event//////////////////////
            //            var cbox1 = $('#ProductId1')[0];
            //            var cbox2 = $('#ProductId2')[0];
            //            $('#imgproduct1').click(function () {
            //                cbox1.checked = !cbox1.checked;
            //            });
            //            $('#imgproduct2').click(function () {
            //                cbox2.checked = !cbox2.checked;
            //            });
            ////////////////////////////////// Show/hide div on product ///////////////////////////////////
            $(document).ready(function () {
                function updateTextArea() {
                    var allVals = [];
                    $('#MyDiv :checked').each(function () {
                        allVals.push($(this).val());
                        var coolVar = allVals;
                        var partsArray = String(coolVar).split(',');
                        //                        alert(partsArray[0]);
                        //                        alert(partsArray[1]);
                    });

                }
                $(function () {
                    $('#MyDiv input').click(updateTextArea);
                    updateTextArea();
                });

            });
            ///////////////////// Validate checkbox to choose atleast one ////////////////
            $("#CreateNew").click(function () {

                var fields = $("input[name='ChkProductId']").serializeArray();
                if (fields.length == 0) {
                    $("#check_IfChecked").show();
                    $("#check_IfChecked").attr({ color: "Red" });
                    $("#check_IfChecked").html("<span style = 'color:red'>Please Choose Atleast one Product.</span>")
                    return false;
                }
                else {
                    document.getElementById("check_IfChecked").innerHTML = "";
                }
            });
            //////////////////////////////////////////////////////////////////////////////////////////////
            /////////// /////////////////////////////////////////////////////////////////////////////////////
            $('#MaxNumberOfAgentUser').keyup(function () {
                var d = $(this).attr('numeric');
                var value = $(this).val();
                var orignalValue = value;
                value = value.replace(/[0-9]*/g, "");
                var msg = "Only Integer Values allowed.";
                if (d == 'decimal') {
                    value = value.replace(/\./, "");
                    msg = "Only Numeric Values allowed.";
                }
                if (value != '') {
                    orignalValue = orignalValue.replace(/([^0-9].*)/g, "")
                    $(this).val(orignalValue);
                    //alert(msg);
                    //$(this).after('<span style="margin-left:5px;color:red;position:absolute;">' + msg + '</span>');
                }
                else {
                    //$(this).next('span').remove();
                }
            });


            ////////////////////////////////////////////////////////////////////////////////////////////
            $("#NativeCountryId").bind("change", function () {
                if (this.value !== "1") {
                    $("#ZoneId").attr("disabled", true);
                    $("#DistrictId").attr("disabled", true);
                    return true;
                }
                $("#ZoneId").attr("disabled", false);
            });
            ////////////////////////////////////////////////////////////////////////////////////////////
            /////// Get Districts name with respect to Zones Name////////////////////////////////////
            $("#ZoneId").live("change", function () {
                // $(".redtxt").attr("style", "visibility: hidden")
                id = $("#ZoneId").val();
                if (id == "") {
                    return false;
                }
                else {
                    $("#loadingIndicator").html('<center><img src="<%=Url.Content("~/Content/images/indicator.gif") %>" alt="" width="16px" height="16px" /></center>');
                    //build the request url
                    var url = "/Administrator/AjaxRequest/GetDistrictOptionsByZoneId";
                    //fire off the request, passing it the id which is the MakeID's selected item value
                    $.getJSON(url, { id: id }, function (data) {
                        //Clear the Model list
                        $('#DistrictId').removeAttr('disabled');
                        $("#DistrictId").empty();
                        // $(".redtxt").attr("style", "visibility: visible").fadeIn("slow");

                        //Foreach Model in the list, add a model option from the data returned
                        $.each(data, function (index, optionData) {

                            $("#DistrictId").append("<option value='" + optionData.Value + "'>" + optionData.Text + "</option>");
                        });
                        $("#loadingIndicator").html('');
                    });
                }

            }).change();
            ////////////////////////////////////////////////////////////////////////////////////////////
            //////////// Get Branch name with respect to bank name
            $('[id^="BankId"]').change(function () {
                id = this.id.match(/\d+$/);
                var selected = $("#BankId" + id).val();
                if (selected == "") {
                    return false;
                }
                else {
                    var val = id;

                    $("#loadingIndicator").html('<center><img src="<%=Url.Content("~/Content/images/indicator.gif") %>" alt="" width="16px" height="16px" /></center>');
                    //build the request url
                    // var id = $(this).val(); // Find its value to use as an ID
                    var url = "/Administrator/AjaxRequest/GetBranchListbyBankId";
                    //fire off the request, passing it the id which is the MakeID's selected item value
                    $.getJSON(url, { id: selected }, function (data) {
                        //Clear the Model list
                        $('#BankBranchId' + val).removeAttr('disabled');
                        $("#BankBranchId" + val).empty();

                        //Foreach Model in the list, add a model option from the data returned
                        $.each(data, function (index, optionData) {

                            $("#BankBranchId" + val).append("<option value='" + optionData.Value + "'>" + optionData.Text + "</option>");
                        });
                        $("#loadingIndicator").html('');
                    });
                }
            }).change();
            ////////////////////////////////////////////////////////////////////////////////////////////
            ////////////////////////////////////////////////////////////////////////////////////////////
            $("#AgentName").live("keyup", function () {
                AddAgentName();
            });

            $("#Email").live("keyup", function () {
                AddAgentEmail();
            });

            $("#Address").live("keyup", function () {
                AddAgentAddress();
            });

            $("#Phone").live("keyup", function () {
                AddAgentPhone();
            });

            function AddAgentName() {
                var agentname = $("#AgentName").val();
                $('#FullName').val(agentname);
            }

            function AddAgentEmail() {
                var agentEmail = $("#Email").val();
                $('#EmailId').val(agentEmail);
            }

            function AddAgentAddress() {
                var agentAddress = $("#Address").val();
                $('#Address1').val(agentAddress);
            }

            function AddAgentPhone() {
                var agentPhone = $("#Phone").val();
                $('#PhoneNo').val(agentPhone);
            }
            ////////////////////////////////////////////////////////////////////////////////////////////
            $("#ConfirmPassword").blur(function () {
                $("#checkpassword").show();
                if ($("#Password").val() != $("#ConfirmPassword").val()) {
                    $("#ConfirmPassword").val('');
                    $("#checkpassword").attr({ color: "Red" });
                    $("#checkpassword").html("<span style = 'color:red'>New Password and confirm password doesn't match </span>")
                }
                else {
                    $("#checkpassword").hide();
                }


            });

            ////////////////////////////////////////////////////////////////////////////////////////////
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
            ////////////////////////////////////////////////////////////////////////////////////////////

            ////////////////////////////////////////////////////////////////////////////////////////////
            $("#agent_name").blur(function () {
                var AgentName = $("#agent_name").val();
                if (AgentName == "") {
                    return false;
                }
                $("#imageLoaderDiv").show();
                $.post("/Administrator/AjaxRequest/CheckDuplicateAgentName", { AgentName: AgentName }, function (data) {
                    if (data) {
                        $("#imageLoaderDiv").hide();
                        $("#check_agentname").show();
                        $("#check_agentname").attr({ color: "Green" });
                        $("#check_agentname").html("<span style='color:green'><b>Agent name available.</b></span>");
                    }
                    else {
                        $("#imageLoaderDiv").hide();
                        $("#check_agentname").show();
                        $("#check_agentname").attr({ color: "Red" });
                        $("#check_agentname").html("<span style = 'color:red'>Please choose a different Agent name")
                        $('#agent_name').val('');
                    }
                }, "json");
            });
            ////////////////////////////////////////////////////////////////////////////////////////////
            $("#login_name").blur(function () {
                var loginName = $("#login_name").val();
                if (loginName == "") {
                    return false;
                }
                $("#imageLoaderDiv").show();
                $.post("/Administrator/AjaxRequest/CheckDuplicateUserName", { loginName: loginName }, function (data) {
                    if (data) {
                        $("#imageLoaderDiv").hide();
                        $("#check_username").show();
                        $("#check_username").attr({ color: "Green" });
                        $("#check_username").html("<span style='color:green'><b>Login name available.</b></span>");
                    }
                    else {
                        $("#imageLoaderDiv").hide();
                        $("#check_username").show();
                        $("#check_username").attr({ color: "Red" });
                        $("#check_username").html("<span style = 'color:red'>Please choose a different login name.</span>")
                        $('#login_name').val('');
                    }
                }, "json");
            });
            ///// checking agent code//////////////////////////////
            $("#AgentCode").blur(function () {
                var AgentCode = $("#AgentCode").val();
                if (AgentCode == "") {
                    return false;
                }
                $("#imageLoaderDiv").show();
                $.post("/Administrator/AjaxRequest/CheckDuplicateAgentCode", { AgentCode: AgentCode }, function (data) {
                    if (data) {
                        $("#imageLoaderDiv").hide();
                        $("#chk_agentcode").show();
                        $("#chk_agentcode").attr({ color: "Green" });
                        $("#chk_agentcode").html("<span style='color:green'><b>Agent Code available.</b></span>");
                    }
                    else {
                        $("#imageLoaderDiv").hide();
                        $("#chk_agentcode").show();
                        $("#chk_agentcode").attr({ color: "Red" });
                        $("#chk_agentcode").html("<span style = 'color:red'>Agent Code Duplicate (Format AH-000X).</span>")
                        $('#AgentCode').val('');
                    }
                }, "json");
            });
            ////////////////////////////////////////////////////////////////////////////////////////////
            /////// Get UserTypeRole on selecting Product////////////////////////////////////
            $('[id^="ProductId"]').live("change", function () {
                var id = this.id.match(/\d+$/);
                var val = id[0];
                if (($("#ProductId" + val).is(':checked')) == false) {
                    $("#RoleId" + val).removeAttr('class');
                    $("#RoleId" + val).empty();
                    $("#RoleId" + val).append("<option value='" + "" + "'>" + "--- Not selected ---" + "</option>");
                }
                else {
                    //build the request url
                    $("#loadingIndicator").html('<center><img src="<%=Url.Content("~/Content/images/indicator.gif") %>" alt="" width="16px" height="16px" /></center>');
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


        });
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////




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
                        $("#check_Email").html("<span style='color:green'><b>Email Address available.</b></span>");
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
</asp:Content>
