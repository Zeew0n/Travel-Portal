<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/BranchOfficeMain.Master"
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
                    <input type="button" value="Cancel" class="cancel" onclick="document.location.href='/Administrator/BranchDistributorManagement/'" /></li>
            </ul>
        </div>
        <h3>
            <a href="#">Distributor Management</a> <span>&nbsp;</span><strong>Edit Distributor</strong>
        </h3>
    </div>
    <% Html.EnableClientValidation(); %>
    <% using (Html.BeginForm("Edit", "BranchDistributorManagement", FormMethod.Post, new { @autocomplete = "off" }))
       {%>
    <%: Html.ValidationSummary(true) %>
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
                                <%-- <div class="form-box1-row-content float-right">
                                    <div>
                                        <label>
                                            <%: Html.LabelFor(model=>model.BranchOfficeId) %></label>
                                        <%: Html.DropDownListFor(model => model.BranchOfficeId,Model.BranchOffices)%><span
                                            class="redtxt">*</span>
                                        <%: Html.ValidationMessageFor(model=>model.BranchOfficeId)%>
                                    </div>
                                </div>--%>
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
                                            <%:Html.LabelFor(model=>model.DistributorClassId )%></label>
                                        <%: Html.DropDownListFor(model => model.DistributorClassId, (SelectList)ViewData["distributorClass"], "---Select Type---", new { @class = "required" })%>
                                    </div>
                                </div>
                            </div>
                            <div class="form-box1-row">
                                <div class="form-box1-row-content float-left">
                                    <div>
                                        <label>
                                            <%:Html.LabelFor(model=>model.MasterDealIdOfAirlines) %></label>
                                        <%: Html.DropDownListFor(model => model.MasterDealIdOfAirlines, Model.MasterDealNameListOfAirlines, "--- Select ------")%>
                                    </div>
                                </div>
                                <div class="form-box1-row-content float-right">
                                    <div>
                                        <label>
                                            <%:Html.LabelFor(model=>model.MasterDealIdOfHotel )%></label>
                                        <%: Html.DropDownListFor(model => model.MasterDealIdOfHotel, Model.MasterDealNameListOfHotels, "--- Select ------")%>
                                    </div>
                                </div>
                            </div>
                            <div class="form-box1-row">
                                <div class="form-box1-row-content float-left">
                                    <div>
                                        <label>
                                            <%:Html.LabelFor(model=>model.MasterDealIdOfBus) %></label>
                                        <%: Html.DropDownListFor(model => model.MasterDealIdOfBus, Model.MasterDealNameListOfBus, "--- Select ------")%>
                                    </div>
                                </div>
                                <div class="form-box1-row-content float-right">
                                    <div>
                                        <label>
                                            <%:Html.LabelFor(model=>model.MasterDealIdOfMobile) %>
                                        </label>
                                        <%: Html.DropDownListFor(model => model.MasterDealIdOfMobile, Model.MasterDealNameListOfMobile, "--- Select ------")%>
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
                                            <%: Html.LabelFor(model=>model.UserMobileNo) %></label>
                                        <%:  Html.TextBoxFor(model => model.UserMobileNo)%>
                                        <span class="redtxt">*</span>
                                        <div id="check_mobileNumber" class="checkIfExsit">
                                        </div>
                                        <%: Html.ValidationMessageFor(model=>model.UserMobileNo)%>
                                    </div>
                                </div>
                                <div class="form-box1-row-content float-right">
                                    <div>
                                        <label>
                                            <%: Html.LabelFor(model=>model.UserPhoneNo) %></label>
                                        <%:  Html.TextBoxFor(model => model.UserPhoneNo)%>
                                        <%: Html.ValidationMessageFor(model=>model.UserPhoneNo)%>
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
                                        <%: Html.TextBoxFor(model => model.UserName, new { id = "login_name", @readonly=true })%><span
                                            class="redtxt">*</span>
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
                                        <%: Html.PasswordFor(model => model.Password, new  {@value="dp bhatt", @readonly=true })%><span
                                            class="redtxt">*</span>
                                        <%: Html.ValidationMessageFor(model=>model.Password)%>
                                    </div>
                                </div>
                                <div class="form-box1-row-content float-right">
                                    <div>
                                        <label>
                                            <%: Html.LabelFor(model=>model.ConfirmPassword) %></label>
                                        <%:  Html.PasswordFor(model => model.ConfirmPassword, new { @value = "dp bhatt", @readonly = true })%><span
                                            class="redtxt">*</span>
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
                <div class="wiz-nav">
                    <input type="submit" value="update" class="save" id="CreateNew" />
                </div>
            </div>
        </div>
    </div>
    </div>
    <% } %>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CssContent" runat="server">
    <link href="../../../../Content/style_wizard.css" rel="stylesheet" type="text/css" />
    <link href="../../../../Content/css/slidedeck.skin.css" rel="stylesheet" type="text/css" />
    <link href="../../../../Content/css/slidedeck.skin.ie.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
    <script src="../../../../Scripts/slidedeck.jquery.lite.js" type="text/javascript"></script>
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
