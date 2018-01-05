<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/AdministratorMain.Master"
    Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Administrator.Models.BranchOfficeManagementModel>" %>

<%@ Import Namespace="ATLTravelPortal.Areas.Administrator.Models" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    ArihantHolidays.com | Edit Agent Info
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <%Html.RenderPartial("Utility/VUC_MessagePanel"); %>
    <% Html.EnableClientValidation(); %>
    <% using (Html.BeginForm("Edit", "BranchOfficeManagement", FormMethod.Post, new { @autocomplete = "off" }))
       {%>
    <%: Html.ValidationSummary(true)%>
    <div class="pageTitle">
        <div class="float-right">
            <ul>
                <li>
                    <input type="submit" value="Update" />
                    <input type="button" value="Cancel" onclick="document.location.href='/Administrator/BranchOfficeManagement'" /></li>
            </ul>
        </div>
        <h3>
            <a href="#">System Setup</a> <span>&nbsp;</span><strong>Branch Office Management</strong><span>&nbsp;</span><strong>Edit
                Basic Info</strong>
        </h3>
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
                                    <%: Html.TextBoxFor(model=>model.BranchOffice) %>
                                    <span class="redtxt">*</span>
                                    <%: Html.ValidationMessageFor(model => model.BranchOffice)%>
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
                    <div class="form-box1-row">
                        <div class="form-box1-row-content float-left">
                            <div>
                                <label>
                                    <%:Html.LabelFor(model=>model.MobileNo) %></label>
                                <%: Html.TextBoxFor(model => model.MobileNo)%>
                                <span class="redtxt">*</span>
                                <%: Html.ValidationMessageFor(model=>model.MobileNo) %>
                            </div>
                        </div>
                        <div class="form-box1-row-content float-right">
                            <div>
                                <label>
                                    <%:Html.LabelFor(model=>model.UserPhone) %></label>
                                <%: Html.TextBoxFor(model => model.UserPhone)%>
                            </div>
                        </div>
                    </div>
                    <div class="row-1">
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
                                    <%: Html.TextBoxFor(model => model.UserName, new { id = "UserName", @readonly = "readonly" })%>
                                    <span class="redtxt">*</span>
                                    <%: Html.ValidationMessageFor(model => model.UserName)%>
                                </div>
                            </div>
                        </div>
                        <div class="form-box1-row">
                            <div class="form-box1-row-content float-left">
                                <div>
                                    <label>
                                        <%:Html.LabelFor(model => model.Password)%></label>
                                    <%: Html.PasswordFor(model => model.Password, new { @value = "indirasapkota", @readonly = "readonly" })%><span
                                        class="redtxt">*</span>
                                    <%: Html.ValidationMessageFor(model => model.Password)%>
                                </div>
                            </div>
                            <div class="form-box1-row-content float-right">
                                <div>
                                    <label>
                                        <%:Html.LabelFor(model => model.ConfirmPassword)%></label>
                                    <%:  Html.PasswordFor(model => model.ConfirmPassword, new { @value = "indirasapkota", @readonly = "readonly" })%><span
                                        class="redtxt">*</span>
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
                                        <%:Html.LabelFor(model=>model.UserAddress )%></label>
                                    <%: Html.TextBoxFor(model => model.UserAddress)%>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <%--  <div class="wiz-nav">
                        <input type="submit" value="Update" />
                    </div>--%>
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
        $(document).ready(function () {
            $("#Zone").attr("disabled", false);
        });
        ///////////////////////////////////////////////////////////////////////////////


        /////////////////////// Disable dropdownllist if parent Country dropdownlist is not Nepal////////////
        $("#NativeCountry").bind("change", function () {
            if (this.value !== "1") {
                $("#Zone").attr("disabled", true);
                $("#District").attr("disabled", true);
                return true;
            }
            $("#Zone").attr("disabled", false);
            $("#District").attr("disabled", false);
        });
        ///////////////////////////////////////////////////////////////////////////////////////////////

        /////// Get Districts name with respect to Zones Name////////////////////////////////////
        $("#Zone").live("change", function () {
            id = $("#Zone").val();
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
                    $('#District').removeAttr('disabled');
                    $("#District").empty();

                    //Foreach Model in the list, add a model option from the data returned
                    $.each(data, function (index, optionData) {

                        $("#District").append("<option value='" + optionData.Value + "'>" + optionData.Text + "</option>");
                    });
                    $("#loadingIndicator").html('');
                });
            }
        }).change();
        ///////////////////////////////////////////////////////////////////////////////////////////////////


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
</asp:Content>
