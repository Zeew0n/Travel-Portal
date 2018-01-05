<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/AdministratorMain.Master" Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Administrator.Models.B2CUserManagementModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Edit
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
   <% Html.EnableClientValidation(); %>
    <% using (Html.BeginForm())
       {%>
    <%: Html.ValidationSummary(true) %>
    <div class="pageTitle">
      <div class="float-right">
        <input type="submit" value="Update" class="save" />
         <input type="button" onclick="document.location.href='/Administrator/B2CUserManagement'"
                    value="Cancel" />
    </div>
    
        <h3>
            <a class="icon_plane" href="#">B2C User Management</a> <span>&nbsp;</span><strong>User Management</strong>
        </h3>
    </div>
    
  
    <fieldset class="style1">
        <legend> User Details</legend>
        <div class="form-box1-row">
            <div class="form-box1-row-content float-left">
                <div>
                    <label>
                        <%:Html.Label("User Name") %></label>
                    <%: Html.TextBoxFor(model => model.GetUserName.UserName, new { @readonly = "readonly" })%>
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
                    <%: Html.PasswordFor(model => model.Password, new { @value = "indira123", @readonly = "readonly" })%>
                </div>
            </div>
            <div class="form-box1-row-content float-right">
                <div>
                    <label>
                        <%:Html.Label("Confirm Password") %></label>
                    <%: Html.PasswordFor(model => model.ConfirmPassword, new { @value = "indira123", @readonly = "readonly" })%>
                </div>
            </div>
        </div>
        <div class="form-box1-row">
            <div class="form-box1-row-content float-left">
                <div>
                    <label>
                        <%:Html.Label("Full Name") %>
                    </label>
                    <%: Html.TextBoxFor(model => model.FullName)%>
                    <%: Html.ValidationMessageFor(model => model.FullName, "*")%>
                </div>
            </div>
            <div class="form-box1-row-content float-right">
                <div>
                    <label>
                        <%: Html.LabelFor(model => model.UserInfo.UserAddress)%></label>
                    <%: Html.TextBoxFor(model => model.Address)%>
                    <%: Html.ValidationMessageFor(model => model.Address, "*")%>
                </div>
            </div>
        </div>
        <div class="form-box1-row">
            <div class="form-box1-row-content float-left">
                <div>
                    <label>
                        <%:Html.Label("Mobile No") %>
                      </label>
                    <%: Html.TextBoxFor(model => model.Mobile)%>
                    <%: Html.ValidationMessageFor(model => model.Mobile, "*")%>
                </div>
                 
            </div>
            <div class="form-box1-row-content float-right">
                <div>
                    <label>
                        <%:Html.Label("Phone No") %>
                       </label>
                    <%: Html.TextBoxFor(model => model.Phone)%>
                    <%: Html.ValidationMessageFor(model => model.Phone, "*")%>
                </div>
            </div>
        </div>
       
    </fieldset>
   <%-- <div class="buttonBar">
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
 
</asp:Content>
