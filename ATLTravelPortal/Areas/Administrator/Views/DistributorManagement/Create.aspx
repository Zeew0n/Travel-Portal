<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/AdministratorMain.Master"
    Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Administrator.Models.DistributorManagementModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Create
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <% Html.EnableClientValidation(); %>
    <% using (Html.BeginForm("Create", "DistributorManagement", FormMethod.Post))
       {%>
    <div class="pageTitle">
        <div class="float-right">
            <ul>
                <li>
                    <%Html.RenderPartial("Utility/VUC_MessagePanel"); %>
                </li>
                <li>
                    <input type="submit" value="Create" class="save" id="CreateNew" />
                    <input type="button" value="Cancel" onclick="document.location.href='/Administrator/DistributorManagement/'" /></li>
            </ul>
        </div>
        <h3>
            <a href="#">Distributor Management</a> <span>&nbsp;</span><strong>Create Distributor</strong>
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
                                        <%:  Html.TextBoxFor(model => model.DistributorName)%><span class="redtxt">*</span>
                                        <%: Html.ValidationMessageFor(model => model.DistributorName)%>
                                    </div>
                                </div>
                                <div class="form-box1-row-content float-right">
                                    <div>
                                        <label>
                                            <%: Html.LabelFor(model=>model.BranchOfficeId) %></label>
                                        <%: Html.DropDownListFor(model => model.BranchOfficeId,Model.BranchOffices)%><span
                                            class="redtxt">*</span>
                                        <%: Html.ValidationMessageFor(model=>model.BranchOfficeId)%>
                                    </div>
                                </div>
                            </div>
                            <div class="form-box1-row">
                                <div class="form-box1-row-content float-left">
                                    <div>
                                        <label>
                                            <%: Html.LabelFor(model => model.TimeZoneId)%></label>
                                        <%:  Html.DropDownListFor(model => model.TimeZoneId, Model.TimeZones)%>
                                        <%: Html.ValidationMessageFor(model => model.TimeZoneId)%>
                                    </div>
                                </div>
                                <div class="form-box1-row-content float-right">
                                    <div>
                                        <label>
                                            <%: Html.LabelFor(model=>model.NativeCountryId) %></label>
                                        <%:  Html.DropDownListFor(model => model.NativeCountryId,Model.Countries)%><span
                                            class="redtxt">*</span>
                                        <%: Html.ValidationMessageFor(model => model.NativeCountryId)%>
                                    </div>
                                </div>
                            </div>
                            <div class="form-box1-row">
                                <div class="form-box1-row-content float-left">
                                    <div>
                                        <label>
                                            <%: Html.LabelFor(model => model.ZoneId)%></label>
                                        <%:  Html.DropDownListFor(model => model.ZoneId, Model.Zones, "--Select--")%>
                                        <%: Html.ValidationMessageFor(model =>model.ZoneId)%>
                                    </div>
                                </div>
                                <div class="form-box1-row-content float-right">
                                    <div>
                                        <label>
                                            <%: Html.LabelFor(model => model.DistrictId)%></label>
                                        <%:  Html.DropDownListFor(model => model.DistrictId, Model.Districts, "--Select--")%>
                                        <%: Html.ValidationMessageFor(model => model.DistrictId)%>
                                    </div>
                                </div>
                            </div>
                            <div class="form-box1-row">
                                <div class="form-box1-row-content float-left">
                                    <div>
                                        <label>
                                            <%: Html.LabelFor(model => model.Address)%></label>
                                        <%:  Html.TextBoxFor(model => model.Address)%><span class="redtxt">*</span>
                                        <%: Html.ValidationMessageFor(model => model.Address)%>
                                    </div>
                                </div>
                                <div class="form-box1-row-content float-right">
                                    <div>
                                        <label>
                                            <%: Html.LabelFor(model => model.Phone)%></label>
                                        <%:  Html.TextBoxFor(model => model.Phone)%><span class="redtxt">*</span>
                                        <%: Html.ValidationMessageFor(model => model.Phone)%>
                                    </div>
                                </div>
                            </div>
                            <div class="form-box1-row">
                                <div class="form-box1-row-content float-left">
                                    <div>
                                        <label>
                                            <%: Html.LabelFor(model => model.Email)%></label>
                                        <%:  Html.TextBoxFor(model => model.Email)%><span class="redtxt">*</span>
                                        <%: Html.ValidationMessageFor(model => model.Email)%>
                                    </div>
                                </div>
                                <div class="form-box1-row-content float-right">
                                    <div>
                                        <label>
                                            <%: Html.LabelFor(model => model.FaxNo)%></label>
                                        <%:  Html.TextBoxFor(model => model.FaxNo)%>
                                        <%: Html.ValidationMessageFor(model => model.FaxNo)%>
                                    </div>
                                </div>
                            </div>
                            <div class="form-box1-row">
                                <div class="form-box1-row-content float-left">
                                    <div>
                                        <label>
                                            <%: Html.LabelFor(model => model.PanNo)%></label>
                                        <%:  Html.TextBoxFor(model => model.PanNo)%><span class="redtxt">*</span>
                                        <%: Html.ValidationMessageFor(model => model.PanNo)%>
                                    </div>
                                </div>
                                <div class="form-box1-row-content float-right">
                                    <div>
                                        <label>
                                            <%: Html.LabelFor(model => model.Web)%></label>
                                        <%:  Html.TextBoxFor(model => model.Web)%>
                                        <%: Html.ValidationMessageFor(model => model.Web)%>
                                    </div>
                                </div>
                            </div>
                            <div class="form-box1-row">
                                <div class="form-box1-row-content float-left">
                                    <div>
                                        <label>
                                            <%: Html.LabelFor(model => model.Status)%></label>
                                        <%:  Html.DropDownListFor(model => model.Status,Model.StatusOption)%><span class="redtxt">*</span>
                                        <%: Html.ValidationMessageFor(model => model.Status)%>
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
                                            <%: Html.LabelFor(model=>model.UserPhoneNo) %></label>
                                        <%:  Html.TextBoxFor(model => model.UserPhoneNo)%>
                                        <%: Html.ValidationMessageFor(model=>model.UserPhoneNo)%>
                                    </div>
                                </div>
                                <div class="form-box1-row-content float-right">
                                    <div>
                                        <label>
                                            <%: Html.LabelFor(model=>model.UserMobileNo) %></label>
                                        <%:  Html.TextBoxFor(model => model.UserMobileNo)%>
                                        <span class="redtxt">*</span>
                                        <div id="check_mobileNumber" class="checkIfExsit">
                                        </div>
                                        <%: Html.ValidationMessageFor(model=>model.UserMobileNo)%>
                                    </div>
                                </div>
                            </div>
                            <div class="form-box1-row">
                                <div class="form-box1-row-content float-left">
                                    <div>
                                        <label>
                                            <%: Html.LabelFor(model=>model.FullName) %></label>
                                        <%: Html.TextBoxFor(model => model.FullName)%><span class="redtxt">*</span>
                                        <%: Html.ValidationMessageFor(model=>model.FullName)%>
                                    </div>
                                </div>
                                <div class="form-box1-row-content float-right">
                                    <div>
                                        <label>
                                            <%: Html.LabelFor(model=>model.UserName) %></label>
                                        <%: Html.TextBoxFor(model => model.UserName, new { id = "login_name" })%><span class="redtxt">*</span>
                                        <div id="check_username" style="display: block;">
                                        </div>
                                        <%: Html.ValidationMessageFor(model=>model.UserName)%>
                                    </div>
                                </div>
                            </div>
                            <div class="form-box1-row">
                                <div class="form-box1-row-content float-left">
                                    <div>
                                        <label>
                                            <%: Html.LabelFor(model=>model.Password) %></label>
                                        <%: Html.PasswordFor(model=>model.Password)%><span class="redtxt">*</span>
                                        <%: Html.ValidationMessageFor(model=>model.Password)%>
                                    </div>
                                </div>
                                <div class="form-box1-row-content float-right">
                                    <div>
                                        <label>
                                            <%: Html.LabelFor(model=>model.ConfirmPassword) %></label>
                                        <%:  Html.PasswordFor(model => model.ConfirmPassword) %><span class="redtxt">*</span>
                                        <%: Html.ValidationMessageFor(model=>model.ConfirmPassword)%>
                                        <div id="checkpassword">
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="form-box1-row">
                                <div class="form-box1-row-content float-left">
                                    <div>
                                        <label>
                                            <%: Html.LabelFor(model=>model.UserEmail) %></label>
                                        <%:  Html.TextBoxFor(model => model.UserEmail)%><span class="redtxt">*</span>
                                        <%: Html.ValidationMessageFor(model => model.UserEmail)%>
                                    </div>
                                </div>
                                <div class="form-box1-row-content float-right">
                                    <div>
                                        <label>
                                            <%: Html.LabelFor(model=>model.UserAddress) %></label>
                                        <%:  Html.TextBoxFor(model => model.UserAddress)%>
                                        <%: Html.ValidationMessageFor(model => model.UserAddress)%>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <% } %>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CssContent" runat="server">
    <link href="../../../../Content/style_wizard.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
    <script type="text/javascript">
        /////// Get Districts name with respect to Zones Name////////////////////////////////////
        $("#ZoneId").live("change", function () {
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


        $(document).ready(function () {
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
        });

        $(document).ready(function () {
            $("#login_name").blur(function () {
                var loginName = $("#login_name").val();
                if (loginName == "") {
                    return false;
                }
                $("#imageLoaderDiv").show();
                $.post("/Administrator/AjaxRequest/CheckDuplicateBranchUserUserName", { loginName: loginName }, function (data) {
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
                        $('#login_name').val(loginName);
                    }
                }, "json");
            });
        });


        //        ////////////////////////////////////////////////////////////////////////////////////////////
        //        $(document).ready(function () {
        //            $("#Email").blur(function () {
        //                var email = $("#Email").val();
        //                if (email == "") {
        //                    return false;
        //                }
        //                $("#imageLoaderDiv").show();

        //                $.post("/Administrator/AjaxRequest/CheckDuplicateBranchOfficeEmail", { Email: email }, function (data) {
        //                    if (data) {
        //                        $("#imageLoaderDiv").hide();
        //                        $("#check_Email").show();
        //                        $("#check_Email").attr({ color: "Green" });
        //                        $("#check_Email").html("<span style='color:green'><b>Email Address available.</b></span>");
        //                    }
        //                    else {
        //                        $("#imageLoaderDiv").hide();
        //                        $("#check_Email").show();
        //                        $("#check_Email").attr({ color: "Red" });
        //                        $("#check_Email").html("<span style = 'color:red'>Email already exists!")
        //                        $('#check_Email').val(email);
        //                    }
        //                }, "json");
        //            });
        //        });
        //        ////////////////////////////////////////////////////////////////////////////////////////////


        $(document).ready(function () {

            $("#UserMobileNo").blur(function () {
                var mobileNumber = $("#UserMobileNo").val();
                var re = /\d{10}/;
                if (re.test(mobileNumber) == false) {
                    $("#check_mobileNumber").hide();
                    return false;
                }
                else {
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
                }
            });
        });

        ////////////////////////////////////////////////////////////////////////////////////////////

        ////////////////////////////////////////////////////////////////////////////////////////////


    </script>
    <script type="text/javascript">
        $(function () {
            $('input[id$=Email]').keyup(function () {
                var txtClone = $(this).val();
                var finaltext = txtClone;
                $('input[id$=UserEmail]').val(finaltext);
                $('input[id$=login_name]').val(finaltext);
            });
        });

    </script>
    <script type="text/javascript">
        $(function () {
            $('input[id$=Address]').keyup(function () {
                var txtClone = $(this).val();
                var finaltext = txtClone;
                $('input[id$=UserAddress]').val(finaltext);
            });
        });

    </script>
    <script type="text/javascript">
        $(function () {
            $('input[id$=Phone]').keyup(function () {
                var txtClone = $(this).val();
                var finaltext = txtClone;
                $('input[id$=UserPhoneNo]').val(finaltext);
            });
        });

    </script>
</asp:Content>
