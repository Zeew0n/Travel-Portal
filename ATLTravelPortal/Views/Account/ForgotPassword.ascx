<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<dynamic>" %>
<div class="loginbox">
	<div class="hd">
    <h2> Forgotten password</h2>
    </div>
  
     <div class="form-box1">
           <h5> If you have forgotten your username or password, you can request to have your username emailed to you and to reset your password. When you fill in your registered email address, you will be sent instructions on how to reset your password.
</h5>       
     <% using (Html.BeginForm("ForgotPassword", "Account", FormMethod.Post))
        {%>
         
      <div class="form-box1-row-content">                           
                             <div><label>User Name or Email</label> 
                                         <%: Html.TextBox("UserorEmail")%><p><a href="#" class="details" title="Check">Check</a></p>
                                       <%--  <%: Html.ValidationMessageFor(m => m.UserName)%> --%>
                            </div>                           
                        </div>
                          <div class="form-box1-row">
                        <p> <input type="submit" value="Submit" class="btn3" /> </p>                        
                    </div>
     <%} %>

</div>
</div>
<div id="check_Field" style="display: block;"></div>
<div id="Div_validate" style="display: block;"></div>
               <script type="text/javascript">
                   $("#UserorEmail").blur(function () {
                       var loginName = $("#UserorEmail").val();
                       if (loginName == "") {
                           $('input[type="submit"]').attr('disabled', 'disabled');
                           return false;
                       }
                       // $("#imageLoaderDiv").show();
                       $.post("/Account/CheckDuplicateUsernameOrEmail", { loginName: loginName }, function (data) {
                           if (data) {
                               //$("#imageLoaderDiv").hide();
                               $('#btn3').attr('disabled', 'disabled');
                               $("#check_Field").show();
                               $("#check_Field").attr({ color: "Red" });
                               $("#check_Field").html("<span style='color:red'>User name/Email doesn't Exist...</span>");
                               $('#UserorEmail').val('');
                           }
                           else {
                               // $("#imageLoaderDiv").hide();
                               $("#check_Field").show();
                               $("#check_username").attr({ color: "Green" });
                               $("#check_Field").html("<span style = 'color:green'>User name/Email Exist...</span>")
                               $('input[type="submit"]').removeAttr('disabled');
                           }
                       }, "json");
                   });

    </script>