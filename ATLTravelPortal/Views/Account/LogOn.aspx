<%@ Page Language="C#" MasterPageFile="~/Views/Shared/TravelPortalLogin.Master" Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Models.LogOnModel>" %>

<asp:Content ID="loginTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Log On
</asp:Content>

<asp:Content ID="loginContent" ContentPlaceHolderID="MainContent" runat="server">

          <% Html.EnableClientValidation(); %>

       <% using (Html.BeginForm("LogOn", "Account", new { @returnUrl = Request.QueryString["ReturnUrl"] }, FormMethod.Post, new { id = "ATForm" }))
          { %>
  
      <p><%: Html.LabelFor(m => m.UserName)%>
                                         <%: Html.TextBoxFor(m => m.UserName)%>
                                         <%: Html.ValidationMessageFor(m => m.UserName)%> </p>
                        <p><%: Html.LabelFor(m => m.Password)%>  
                                            <%: Html.PasswordFor(m => m.Password)%>
                                            <%: Html.ValidationMessageFor(m => m.Password)%></p>
                                <p>                      
                        	 <%: Html.CheckBoxFor(m => m.RememberMe)%> Remember me |             
                        	<span> <%=Html.ActionLink("Forgot Password", "ForgotPassword", new { Controller = "Account" }, new { @class = "link_ForgotPassword ml" })%>   
                           </span></p> <p><input type="submit" value="Log On" /></p>
                      
                    <% if (ViewData["message"] != null)
                       { %>
                    <div class="validation-summary-errors">
						<p><%: ViewData["message"]%></p>
                    </div>
                    <%} %>
               
                 <% } %>

    
    

</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
    <script src="../../Scripts/MicrosoftAjax.js" type="text/javascript"></script>
<script src="../../Scripts/MicrosoftMvcAjax.js" type="text/javascript"></script>
<script src="../../Scripts/MicrosoftMvcValidation.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery-1.4.1.js" type="text/javascript"></script>
 <script type="text/javascript">
     $(document).ready(function () {
         $('.link_ForgotPassword').bind('click', function (e) {
             e.preventDefault();
             $('.div_ForgotPassword').attr('style', 'visibility:visible');
             $('.div_ForgotPassword').dialog({ width: 505, modal: true, resizable: true, autoOpen: false, show: "slide" });
             $('.div_ForgotPassword').dialog('open');


         });

         $('.btn3').click(function (e) {
             e.preventDefault();
             if (($('#UserorEmail').val() == "")) {
                 $("#check_Field").hide();
                 $("#Div_validate").show();
                 $("#Div_validate").attr({ color: "Red" });
                 $("#Div_validate").html("<span style = 'color:red'>Required Email Or Username </span>")
                 $('#submit_postcode').attr('disabled', 'disabled');

             }
             else {
                 var url = $(this).parents('form:first').attr('action');
                 var postData = $(this).parents('form:first').serializeArray();
                 $.post(url, postData, function (data) {
                     alert(data.message);
                     $('.div_ForgotPassword').dialog('close');
                 }, 'json');
             }
         });
     });

    </script>

</asp:Content>


