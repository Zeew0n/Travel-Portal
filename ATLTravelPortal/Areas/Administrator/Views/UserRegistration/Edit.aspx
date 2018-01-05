<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/AdministratorMain.Master"
    Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Administrator.Models.AdminUserManagementModel+CreateAdminAspUser>" %>

<%@ Import Namespace="ATLTravelPortal.Areas.Administrator.Models" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Edit
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
 <% using (Html.BeginForm())
       {%>

    <div class="pageTitle">
     <div class="float-right">
        <input type="submit" value="Update" class="save" />
        <input type="button" value="Cancel" onclick="document.location.href='/Administrator/UserRegistration'" />
    </div>
        <h3>
            <a class="icon_plane" href="#">User Management</a> <span>&nbsp;</span><strong>User Registration</strong>
        </h3>
    </div>
   
    <%: Html.ValidationSummary(true) %>
    <div class="row-1">
        <div class="form-box1 round-corner">
            <div class="form-box1-row">
                <div id="MyDiv">
                    <h5>
                        Choose Product</h5>
                    <div>
                        <ul class="productselection-box ">
                            <% foreach (var userAssociatedProduct in Model.AdminProductList)
                               { %>
                            <%if ((ModelUserProductExtension.IsActiveUserProduct(userAssociatedProduct.ProductId, Model.ProductBaseRoleList)) == true)
                              { %>
                            <li>
                                <img src="../../../../Content/images/productimage/<%=userAssociatedProduct.ProductId%>.jpg"
                                    alt="" id='img1' />
                                <input type="checkbox" name="ChkProductId" value="<%=userAssociatedProduct.ProductId%>"
                                    checked="checked" id="ProductId<%=userAssociatedProduct.ProductId%>" />
                                <%=userAssociatedProduct.ProductName%><br />
                                <label>
                                    Role:</label><br />
                                <%=Html.DropDownList("RoleId" + userAssociatedProduct.ProductId, (IEnumerable<SelectListItem>)ViewData[userAssociatedProduct.ProductName], new { @id = "RoleId" + userAssociatedProduct.ProductId })%>
                            </li>
                            <%}
                              else
                              { %>
                            <li>
                                <img src="../../../../Content/images/productimage/<%=userAssociatedProduct.ProductId%>.jpg"
                                    alt="" id='img2' />
                                <input type="checkbox" name="ChkProductId" value="<%=userAssociatedProduct.ProductId%>"
                                    id="ProductId<%:userAssociatedProduct.ProductId%>" />
                                <%=userAssociatedProduct.ProductName%>
                                <br />
                                <label>
                                    Role:</label><br />
                                <select id="RoleId<%= userAssociatedProduct.ProductId %>" name="RoleId<%= userAssociatedProduct.ProductId %>">
                                    <option value="">---Not Selected---</option>
                                </select>
                            </li>
                            <%} %>
                            <%}%>
                        </ul>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <br />
    <fieldset class="style1">
        <legend>Edit User Details</legend>
        <div class="form-box1-row">
            <div class="form-box1-row-content float-left">
                <div>
                    <label>
                        <%:Html.Label("User Name") %>
                        <%--<%: Html.LabelFor(model => model.UserName) %>--%></label>
                    <%: Html.TextBoxFor(model => model.GetUserName.UserName, new { @readonly = "readonly" })%>
                    <%: Html.ValidationMessageFor(model => model.GetUserName.UserName, "*")%>
                    <div id="check_username" style="display: block;">
                    </div>
                </div>
            </div>
            <div class="form-box1-row-content float-right">
                <div>
                    <label>
                        <%: Html.LabelFor(model => model.GetEmail.Email)%></label>
                    <%: Html.TextBoxFor(model => model.GetEmail.Email)%>
                    <%: Html.ValidationMessageFor(model => model.GetEmail.Email, "*")%>
                </div>
            </div>
        </div>
        <div class="form-box1-row">
            <div class="form-box1-row-content float-left">
                <div>
                    <label>
                        <%: Html.LabelFor(model => model.Password) %></label>
                    <%: Html.PasswordFor(model => model.Password, new { @value = "abctest", @readonly = "readonly" })%><span
                        class="redtxt">*</span>
                    <%: Html.ValidationMessageFor(model => model.Password, "*")%>
                </div>
            </div>
            <div class="form-box1-row-content float-right">
                <div>
                    <label>
                        <%:Html.Label("Confirm Password") %>
                        <%-- <%: Html.LabelFor(model => model.ConfirmPassword) %>--%></label>
                    <%: Html.PasswordFor(model => model.ConfirmPassword, new { @value = "abctest", @readonly = "readonly" })%><span
                        class="redtxt">*</span>
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
                    <%: Html.TextBoxFor(model => model.UserInfo.FullName)%>
                    <%: Html.ValidationMessageFor(model => model.UserInfo.FullName, "*")%>
                </div>
            </div>
            <div class="form-box1-row-content float-right">
                <div>
                    <label>
                        <%: Html.LabelFor(model => model.UserInfo.UserAddress)%></label>
                    <%: Html.TextBoxFor(model => model.UserInfo.UserAddress)%>
                    <%: Html.ValidationMessageFor(model => model.UserInfo.UserAddress, "*")%>
                </div>
            </div>
        </div>
        <div class="form-box1-row">
            <div class="form-box1-row-content float-left">
                <div>
                    <label>
                        <%:Html.Label("Mobile No") %>
                        <%--<%: Html.LabelFor(model => model.MobileNo) %>--%></label>
                    <%: Html.TextBoxFor(model => model.UserInfo.MobileNumber)%>
                    <%: Html.ValidationMessageFor(model => model.UserInfo.MobileNumber, "*")%>
                </div>
            </div>
            <div class="form-box1-row-content float-right">
                <div>
                    <label>
                        <%:Html.Label("Phone No") %>
                        <%--<%: Html.LabelFor(model => model.PhoneNo) %>--%></label>
                    <%: Html.TextBoxFor(model => model.UserInfo.PhoneNumber)%>
                    <%: Html.ValidationMessageFor(model => model.UserInfo.PhoneNumber, "*")%>
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
  <%--  <div class="buttonBar">
        <input type="submit" value="Save" class="save" />
    </div>--%>
    <% } %>
    <div>
        <%: Html.ActionLink("Back to List", "Index") %>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CssContent" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
    <script src="../../../../Scripts/jquery.validate.min.js" type="text/javascript"></script>
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
                $.post("/AjaxRequest/CheckDuplicateUserName", { loginName: loginName }, function (data) {
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
                    $("#check_username").show();
                    $("#check_username").attr({ color: "Red" });
                    $("#check_username").html("<span style = 'color:red'>Please Choose Atleast one Product.</span>")
                }
                else {
                    document.getElementById("check_username").innerHTML = "";
                }
            });

            /////// Get UserType on selecting Product////////////////////////////////////
            $('[id^="ProductId"]').click(function () {
                var id = this.id.match(/\d/);
                var val = id[0];

                if (($("#ProductId" + val).is(':checked')) == false) {
                    $("#RoleId" + val).removeAttr('class');
                    $("#RoleId" + val).empty();
                    $("#RoleId" + val).append("<option value='" + "" + "'>" + "--- Not selected ---" + "</option>");
                }
                else {
                    $("#RoleId" + val).empty();
                    //build the request url
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
                    });
                }
            }).change();

        });

    </script>
</asp:Content>
