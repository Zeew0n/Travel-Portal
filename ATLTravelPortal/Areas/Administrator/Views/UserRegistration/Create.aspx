<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/AdministratorMain.Master"
    Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Administrator.Models.AdminUserManagementModel+CreateAdminAspUser>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Create
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <% Html.EnableClientValidation(); %>
    <div class="msgbox" style="border: 0px; display: none;">
        <% = TempData["ErrorMessage"]%></div>
    <% using (Html.BeginForm("Create", "UserRegistration", FormMethod.Post, new { @class = "validate", @autocomplete = "off", enctype = "multipart/form-data" }))
       {%>
    <%: Html.ValidationSummary(true) %>
    <div class="pageTitle">
        <div class="float-right">
            	 <input type="submit" value="Save"  />
                 <input type="button" value="Cancel" onclick="document.location.href='/Administrator/UserRegistration'" />
         </div>
          <h3>
           <a class="icon_plane" href="#">User Management</a> <span>&nbsp;</span><strong>User Registration</strong>
        </h3>
       </div>  
  

    <%Html.RenderPartial("ProductBasedRole"); %>
    <br />
    <fieldset class="style1">
        <legend>Add User Details</legend>
        <div class="form-box1-row">
            <div class="form-box1-row-content float-left">
                <div>
                    <label>
                        <%:Html.Label("User Name") %>
                        <%--<%: Html.LabelFor(model => model.UserName) %>--%></label>
                    <%: Html.TextBoxFor(model => model.UserName, new { id = "login_name", @onkeypress = "return CheckUserName(event)" })%>
                    <%: Html.ValidationMessageFor(model => model.UserName,"*") %>
                    <div id="check_username" class="checkIfExsit">
                    </div>
                </div>
            </div>
            <div class="form-box1-row-content float-right">
                <div>
                    <label>
                        <%: Html.LabelFor(model => model.Email) %></label>
                    <%: Html.TextBoxFor(model => model.Email) %>
                    <%: Html.ValidationMessageFor(model => model.Email, "*")%>
                </div>
            </div>
        </div>
        <div class="form-box1-row">
            <div class="form-box1-row-content float-left">
                <div>
                    <label>
                        <%: Html.LabelFor(model => model.Password) %></label>
                    <%: Html.PasswordFor(model => model.Password)%>
                    <%: Html.ValidationMessageFor(model => model.Password, "*")%>
                </div>
            </div>
            <div class="form-box1-row-content float-right">
                <div>
                    <label>
                        <%:Html.Label("Confirm Password") %>
                        <%-- <%: Html.LabelFor(model => model.ConfirmPassword) %>--%></label>
                    <%: Html.PasswordFor(model => model.ConfirmPassword) %>
                    <%: Html.ValidationMessageFor(model => model.ConfirmPassword, "*")%>
                </div>
            </div>
        </div>
        <div class="form-box1-row">
            <div class="form-box1-row-content float-left">
                <div>
                    <label>
                        <%:Html.Label("Full Name") %>
                    </label>
                    <%: Html.TextBoxFor(model => model.FullName, new { @onkeypress = "return CheckAlbhabet(event)" })%>
                    <%: Html.ValidationMessageFor(model => model.FullName, "*")%>
                </div>
            </div>
            <div class="form-box1-row-content float-right">
                <div>
                    <label>
                        <%: Html.LabelFor(model => model.Address) %></label>
                    <%: Html.TextBoxFor(model => model.Address) %>
                    <%: Html.ValidationMessageFor(model => model.Address, "*")%>
                </div>
            </div>
        </div>
        <div class="form-box1-row">
            <div class="form-box1-row-content float-left">
                <div>
                    <label>
                        <%:Html.Label("Mobile No") %>
                        <%--<%: Html.LabelFor(model => model.MobileNo) %>--%></label>
                    <%: Html.TextBoxFor(model => model.MobileNo, new { @onkeypress = "return CheckNumericValue(event)" })%>
                    <%: Html.ValidationMessageFor(model => model.MobileNo, "*")%>
                </div>
            </div>
            <div class="form-box1-row-content float-right">
                <div>
                    <label>
                        <%:Html.Label("Phone No") %>
                        <%--<%: Html.LabelFor(model => model.PhoneNo) %>--%></label>
                    <%: Html.TextBoxFor(model => model.PhoneNo, new { @onkeypress = "return CheckNumericValue(event)" })%>
                    <%: Html.ValidationMessageFor(model => model.PhoneNo, "*")%>
                </div>
            </div>
        </div>
        <div class="form-box1-row">
            <div class="form-box1-row-content float-left">
                <div>
                    <label>
                        <%:Html.Label("Is Sales/Marketing User")%>
                    </label>
                    <%: Html.CheckBoxFor(model => model.IsSalesMarketingUser)%>
                </div>
            </div>
            <div class="form-box1-row-content float-right">
                <div>
                    <label>
                    </label>
                </div>
            </div>
        </div>
    </fieldset>
    <%--<div class="buttonBar">
        <input type="submit" value="Save" id="save" />
        <input type="button" value="Cancel" onclick="document.location.href='/Administrator/UserRegistration/'" />
    </div--%>
    <% } %>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CssContent" runat="server">
    <link href="../../../../Content/css/buttons.css" rel="stylesheet" type="text/css" />
    <link href="../../../../Content/css/import.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        label.error
        {
            font-weight: bold;
            color: #b80000;
        }
    </style>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
    <script src="../../../../Scripts/jquery.validate.min.js" type="text/javascript"></script>
    <script type = "text/javascript">
  
    function CheckAlbhabet(e) {
        var key = e.which ? e.which : e.keyCode;
        //A-Z a-z and space key//              
        if ((key > 64 && key < 91) || (key > 96 && key < 123) || key == 8 || key == 32) {
            return true;
        }
        else {

            return false;
        }
    }


    function CheckNumericValue(e) {

        var key = e.which ? e.which : e.keyCode;
        //enter key  //backspace //tabkey      //escape key     
        if ((key >= 48 && key <= 57) || key == 13 || key == 8 || key == 9 || key == 27) {
            return true;
        }
        else {

            return false;
        }
    }


    function CheckUserName(e) {

        var key = e.which ? e.which : e.keyCode;
        if ((key > 64 && key < 91) || (key > 96 && key < 123) || key == 8 || (key >= 48 && key <= 57) || key == 13 || key == 8 || key == 9 || key == 27 || key == 46 || key == 64) {
            return true;
        }
        else {

            return false;
        }
    }
    </script>
  


    <script type="text/javascript">
        $(document).ready(function () {
            $('.validate').validate();
            ////////////////////////////////////////////////////////////
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
            ///////////////////// Validate checkbox to choose atleast one ////////////////
            $("#save").click(function () {
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


            /////// Get UserTypeRole on selecting Product////////////////////////////////////
            $('[id^="ProductId"]').click(function () {
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
                    var url = "/Administrator/AjaxRequest/GetAdminRolesonSubProductId";
                    //fire off the request, passing it the id which is the MakeID's selected item value
                    $.getJSON(url, { id: val }, function (data) {
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
    </script>
</asp:Content>
