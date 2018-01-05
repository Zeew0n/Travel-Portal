<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/AdministratorMain.Master"
    Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Administrator.Models.BranchOfficeManagementModel>" %>

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
    <% using (Html.BeginForm("Create", "BranchOfficeManagement", FormMethod.Post, new { @autocomplete = "off" }))
       {%>
    <div class="tbl_Data">
        <ul class="buttons-panel float-right">
            <li>
                <%Html.RenderPartial("Utility/VUC_MessagePanel"); %>
            </li>
            <li>
                <input type="submit" value="Save" class="btn1" /></li>
            <li>
                <input type="button" onclick="document.location.href='/Administrator/BranchOfficeManagement/Index'"
                    value="Cancel" /></li>
        </ul>
        <div class="tbl_Data_Tlt">
            <h3>
                <a href="#" class="icon_plane">Branch Office Management</a> <span>&nbsp;</span><strong>
                    Create</strong>
            </h3>
        </div>
    </div>
    <div class="wiz-container">
        <ul>
            <li><a href="javascript: void(0)" class="wiz-anc-done wiz-anc-default">
                <h2>
                    1. Branch Office Basic Info</h2>
            </a></li>
        </ul>
        <div class="wiz-body">
            <div>
                <div class="wiz-content">
                    <div class="row-1">
                        <div class="form-box1-row">
                            <div class="form-box1-row-content float-left">
                                <div>
                                    <label>
                                        <%:Html.LabelFor(model=>model.BranchOffice) %></label>
                                    <%: Html.TextBoxFor(model=>model.BranchOffice, new { id = "branch_name" })%>
                                    <span class="redtxt">*</span>
                                    <%: Html.ValidationMessageFor(model => model.BranchOffice)%>
                                    <div id="check_branchname" class="checkIfExsit">
                                    </div>
                                </div>
                            </div>
                            <div class="form-box1-row-content float-right">
                                <div>
                                    <label>
                                        <%:Html.LabelFor(model=>model.NativeCountry) %></label>
                                    <%: Html.DropDownListFor(model => model.NativeCountry, Model.NativeCountryList, "---Select Country---")%>
                                    <span class="redtxt">*</span>
                                    <%: Html.ValidationMessageFor(model => model.NativeCountry)%>
                                </div>
                            </div>
                        </div>
                        <div class="form-box1-row">
                            <div class="form-box1-row-content float-left">
                                <div>
                                    <label>
                                        <%:Html.LabelFor(model=>model.Zone) %></label>
                                    <%: Html.DropDownListFor(model => model.Zone, Model.ZoneList,"---Select---")%>
                                    <span class="redtxt">*</span>
                                    <%: Html.ValidationMessageFor(model => model.Zone)%>
                                </div>
                            </div>
                            <div class="form-box1-row-content float-right">
                                <div>
                                    <label>
                                        <%:Html.LabelFor(model=>model.District) %></label>
                                    <%: Html.DropDownListFor(model => model.District, Model.DistrictList, "---Select---")%>
                                    <span class="redtxt">*</span>
                                    <%: Html.ValidationMessageFor(model => model.District)%>
                                </div>
                            </div>
                        </div>
                        <div class="form-box1-row">
                            <div class="form-box1-row-content float-left">
                                <div>
                                    <label>
                                        <%:Html.LabelFor(model=>model.Address )%></label>
                                    <%: Html.TextBoxFor(model => model.Address)%><span class="redtxt">*</span>
                                    <%: Html.ValidationMessageFor(model => model.Address)%></div>
                            </div>
                            <div class="form-box1-row-content float-right">
                                <div>
                                    <label>
                                        <%:Html.LabelFor(model=>model.Phone) %></label>
                                    <%: Html.TextBoxFor(model => model.Phone) %><span class="redtxt">*</span>
                                    <%: Html.ValidationMessageFor(model => model.Phone)%></div>
                            </div>
                        </div>
                        <div class="form-box1-row">
                            <div class="form-box1-row-content float-left">
                                <div>
                                    <label>
                                        <%:Html.LabelFor(model=>model.Email )%></label>
                                    <%: Html.TextBoxFor(model => model.Email) %>
                                    <span class="redtxt">*</span>
                                    <%: Html.ValidationMessageFor(model => model.Email)%></div>
                                <div id="check_Email" class="checkIfExsit">
                                </div>
                            </div>
                            <div class="form-box1-row-content float-right">
                                <div>
                                    <label>
                                        <%:Html.LabelFor(model=>model.Fax )%></label>
                                    <%: Html.TextBoxFor(model => model.Fax) %>
                                    <%: Html.ValidationMessageFor(model => model.Fax)%>
                                </div>
                            </div>
                        </div>
                        <div class="form-box1-row">
                            <div class="form-box1-row-content float-left">
                                <div>
                                    <label>
                                        <%:Html.LabelFor(model=>model.PanNo) %></label>
                                    <%: Html.TextBoxFor(model => model.PanNo) %>
                                    <%: Html.ValidationMessageFor(model => model.PanNo)%>
                                    <span class="redtxt">*</span>
                                </div>
                            </div>
                            <div class="form-box1-row-content float-right">
                                <div>
                                    <label>
                                        <%:Html.LabelFor(model=>model.Web) %></label>
                                    <%: Html.TextBoxFor(model => model.Web) %>
                                </div>
                            </div>
                        </div>
                        <div class="form-box1-row">
                            <div class="form-box1-row-content float-left">
                                <div>
                                    <label>
                                        <%:Html.LabelFor(model=>model.status )%></label>
                                    <%: Html.DropDownListFor(model => model.status, Model.StatusList)%>
                                </div>
                            </div>
                            <div class="form-box1-row-content float-right">
                                <div>
                                    <label>
                                        <%:Html.LabelFor(model=>model.TimeZone) %></label>
                                    <%: Html.DropDownListFor(model => model.TimeZone, Model.TimeZoneList)%>
                                </div>
                            </div>
                        </div>
                        <div class="form-box1-row">
                            <div class="form-box1-row-content float-left">
                                <div>
                                    <label>
                                        <%:Html.LabelFor(model=>model.BranchClassId )%></label>
                                    <%: Html.DropDownListFor(model => model.BranchClassId, (SelectList)ViewData["branchClass"], "---Select Type---", new { @class = "required" })%>
                                </div>
                            </div>
                            <div class="form-box1-row-content float-right">
                                <div>
                                    <label>
                                        <%:Html.LabelFor(model=>model.MasterDealIdOfAirlines) %></label>
                                    <%: Html.DropDownListFor(model => model.MasterDealIdOfAirlines, Model.MasterDealNameListOfAirlines, "--- Select ------")%>
                                </div>
                            </div>
                        </div>
                        <div class="form-box1-row">
                            <div class="form-box1-row-content float-left">
                                <div>
                                    <label>
                                        <%:Html.LabelFor(model=>model.MasterDealIdOfHotel )%></label>
                                    <%: Html.DropDownListFor(model => model.MasterDealIdOfHotel, Model.MasterDealNameListOfHotels, "--- Select ------")%>
                                </div>
                            </div>
                            <div class="form-box1-row-content float-right">
                                <div>
                                    <label>
                                        <%:Html.LabelFor(model=>model.MasterDealIdOfBus) %></label>
                                    <%: Html.DropDownListFor(model => model.MasterDealIdOfBus, Model.MasterDealNameListOfBus, "--- Select ------")%>
                                </div>
                            </div>
                        </div>
                        <div class="form-box1-row">
                            <div class="form-box1-row-content float-left">
                                <div>
                                    <label>
                                        <%:Html.LabelFor(model=>model.MasterDealIdOfMobile )%></label>
                                    <%: Html.DropDownListFor(model => model.MasterDealIdOfMobile, Model.MasterDealNameListOfMobile, "--- Select ------")%>
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
    <div class="wiz-container">
        <ul>
            <li><a href="javascript: void(0)" class="wiz-anc-done wiz-anc-default">
                <h2>
                    1. Branch Authorize User</h2>
            </a></li>
        </ul>
        <div class="wiz-body">
            <div>
                <div class="wiz-content">
                    <div class="row-1">
                        <div class="form-box1-row">
                            <div class="form-box1-row-content float-left">
                                <div>
                                    <label>
                                        <%:Html.LabelFor(model=>model.MobileNo) %></label>
                                    <%: Html.TextBoxFor(model => model.MobileNo)%>
                                    <%: Html.ValidationMessageFor(model=>model.MobileNo) %>
                                    <span class="redtxt">*</span>
                                    <div id="check_mobileNumber" class="checkIfExsit">
                                    </div>
                                </div>
                            </div>
                            <div class="form-box1-row-content float-right">
                                <div>
                                    <label>
                                        <%:Html.LabelFor(model => model.UserPhone)%></label>
                                    <%: Html.TextBoxFor(model => model.UserPhone)%>
                                    <%: Html.ValidationMessageFor(model => model.UserPhone)%>
                                </div>
                            </div>
                        </div>
                        <div class="form-box1-row">
                            <div class="form-box1-row-content float-left">
                                <div>
                                    <label>
                                        <%:Html.LabelFor(model=>model.FullName) %></label>
                                    <%: Html.TextBoxFor(model => model.FullName)%>
                                    <span class="redtxt">*</span>
                                    <%: Html.ValidationMessageFor(model => model.FullName)%>
                                </div>
                            </div>
                            <div class="form-box1-row-content float-right">
                                <div>
                                    <label>
                                        <%:Html.LabelFor(model=>model.UserName) %></label>
                                    <%: Html.TextBoxFor(model => model.UserName, new { id = "User_Name" })%>
                                    <span class="redtxt">*</span>
                                    <div id="check_username" style="display: block;">
                                    </div>
                                    <%: Html.ValidationMessageFor(model => model.UserName)%>
                                </div>
                            </div>
                        </div>
                        <div class="form-box1-row">
                            <div class="form-box1-row-content float-left">
                                <div>
                                    <label>
                                        <%:Html.LabelFor(model => model.Password)%></label>
                                    <%: Html.PasswordFor(model => model.Password)%><span class="redtxt">*</span>
                                    <%: Html.ValidationMessageFor(model => model.Password)%>
                                </div>
                            </div>
                            <div class="form-box1-row-content float-right">
                                <div>
                                    <label>
                                        <%:Html.LabelFor(model => model.ConfirmPassword)%></label>
                                    <%:  Html.PasswordFor(model => model.ConfirmPassword) %><span class="redtxt">*</span>
                                    <%: Html.ValidationMessageFor(model => model.Password)%>
                                    <div id="checkpassword">
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="form-box1-row">
                            <div class="form-box1-row-content float-left">
                                <div>
                                    <label>
                                        <%:Html.LabelFor(model=>model.UserEmail )%></label>
                                    <%: Html.TextBoxFor(model => model.UserEmail)%>
                                    <span class="redtxt">*</span>
                                    <%: Html.ValidationMessageFor(model => model.UserEmail)%></div>
                            </div>
                            <div class="form-box1-row-content float-right">
                                <div>
                                    <label>
                                        <%:Html.LabelFor(model => model.UserAddress)%></label>
                                    <%: Html.TextBoxFor(model => model.UserAddress)%>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <%--<div class="wiz-nav">
                   <input type="submit" value="Create" class="btn1" />
                </div>--%>
    <% } %>
    <br />
    <br />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CssContent" runat="server">
    <link href="../../../../Content/style_wizard.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
    <script type="text/javascript" language="javascript">


        ////////////////////////////////////////////////////////////////////////////////////////////
        $(document).ready(function () {
            $("#branch_name").blur(function () {
                var BranchName = $("#branch_name").val();
                if (BranchName == "") {
                    return false;
                }
                $("#imageLoaderDiv").show();
                $.post("/Administrator/BranchOfficeManagement/CheckDuplicateBranchName", { BranchName: BranchName }, function (data) {
                    if (data) {
                        $("#imageLoaderDiv").hide();
                        $("#check_branchname").show();
                        $("#check_branchname").attr({ color: "Green" });
                        $("#check_branchname").html("<span style='color:green'><b>Branch name available.</b></span>");
                    }
                    else {
                        $("#imageLoaderDiv").hide();
                        $("#check_branchname").show();
                        $("#check_branchname").attr({ color: "Red" });
                        $("#check_branchname").html("<span style = 'color:red'>Please choose a different Branch name")
                        $('#branch_name').val(BranchName);
                    }
                }, "json");
            });
        });
        ////////////////////////////////////////////////////////////////////////////////////////////



        ////////////////////////////////////////////////////////////////////////////////////////////
        $("#NativeCountry").bind("change", function () {
            if (this.value !== "1") {
                $("#Zone").attr("disabled", true);
                $("#District").attr("disabled", true);
                return true;
            }
            $("#Zone").attr("disabled", false);
        });
        ////////////////////////////////////////////////////////////////////////////////////////////


        /////// Get Districts name with respect to Zones Name////////////////////////////////////
        $("#Zone").live("change", function () {
            // $(".redtxt").attr("style", "visibility: hidden")
            id = $("#Zone").val();
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
                    $('#District').removeAttr('disabled');
                    $("#District").empty();
                    // $(".redtxt").attr("style", "visibility: visible").fadeIn("slow");

                    //Foreach Model in the list, add a model option from the data returned
                    $.each(data, function (index, optionData) {

                        $("#District").append("<option value='" + optionData.Value + "'>" + optionData.Text + "</option>");
                    });
                    $("#loadingIndicator").html('');
                });
            }

        }).change();


    </script>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#User_Name").blur(function () {
                var loginName = $("#User_Name").val();
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
                        $('#User_Name').val(loginName);
                    }
                }, "json");
            });
        });



        ////////////////////////////////////////////////////////////////////////////////////////////
        $(document).ready(function () {
            $("#Email").blur(function () {
                var email = $("#Email").val();
                if (email == "") {
                    return false;
                }
                $("#imageLoaderDiv").show();

                $.post("/Administrator/AjaxRequest/CheckDuplicateBranchOfficeEmail", { Email: email }, function (data) {
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

        ////////////////////////////////////////////////////////////////////////////////////////////


    </script>
    <script type="text/javascript">
        $(function () {
            $('input[id$=Email]').keyup(function () {
                var txtClone = $(this).val();
                var finaltext = txtClone;
                $('input[id$=UserEmail]').val(finaltext);
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
                $('input[id$=UserPhone]').val(finaltext);
            });
        });

    </script>
    <script type="text/javascript">
        $(function () {
            $('input[id$=Email]').keyup(function () {
                var txtClone = $(this).val();
                var finaltext = txtClone;
                $('input[id$=User_Name]').val(finaltext);
            });
        });

    </script>
</asp:Content>
