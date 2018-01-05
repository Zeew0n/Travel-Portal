<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<ATLTravelPortal.Areas.Administrator.Models.ApplicationSettingViewModel>" %>
<%if (Model.Flag == true) %>
<% {%>
<% Html.EnableClientValidation(); %>

<%: Html.ValidationSummary(true)%>
<%Html.RenderPartial("Utility/PVC_MessagePanel"); %>
<div class="row-1  mrg-top-20">
    <h3>
    </h3>
    <div class="form-box1-row">
        <div class="form-box1-row-content float-left">
            <div>
                <label>
                    <%: Html.LabelFor(model => model.EnablePasswordRetrieval)%></label>
                <%: Html.RadioButtonFor(model => model.EnablePasswordRetrieval, true)%>
                Yes
                <%: Html.RadioButtonFor(model => model.EnablePasswordRetrieval, false)%>
                No
                <%: Html.ValidationMessageFor(model => model.EnablePasswordRetrieval)%>
            </div>
        </div>
        <div class="form-box1-row-content float-right">
            <div>
                <label>
                    <%: Html.LabelFor(model => model.EnablePasswordReset)%></label>
                <%: Html.RadioButtonFor(model => model.EnablePasswordReset, true)%>
                Yes
                <%: Html.RadioButtonFor(model => model.EnablePasswordReset, false)%>
                No
                <%: Html.ValidationMessageFor(model => model.EnablePasswordReset)%>
            </div>
        </div>
    </div>
    <div class="form-box1-row">
        <div class="form-box1-row-content float-left">
            <div>
                <label>
                    <%: Html.LabelFor(model => model.RequiresQuestionAndAnswer)%></label>
                <%: Html.RadioButtonFor(model => model.RequiresQuestionAndAnswer, true)%>
                Yes
                <%: Html.RadioButtonFor(model => model.RequiresQuestionAndAnswer, false)%>
                No
                <%: Html.ValidationMessageFor(model => model.RequiresQuestionAndAnswer)%>
            </div>
        </div>
        <div class="form-box1-row-content float-right">
            <div>
                <label>
                    <%: Html.LabelFor(model => model.RequiresUniqueEmail)%></label>
                <%: Html.RadioButtonFor(model => model.RequiresUniqueEmail, true)%>
                Yes
                <%: Html.RadioButtonFor(model => model.RequiresUniqueEmail, false)%>
                No
                <%: Html.ValidationMessageFor(model => model.RequiresUniqueEmail)%>
            </div>
        </div>
    </div>
    <div class="form-box1-row">
        <div class="form-box1-row-content float-left">
            <div>
                <label>
                    <%: Html.LabelFor(model => model.MaxInvalidPasswordAttempts)%></label>
                <%: Html.TextBoxFor(model => model.MaxInvalidPasswordAttempts)%>
                <%: Html.ValidationMessageFor(model => model.MaxInvalidPasswordAttempts)%>
            </div>
        </div>
        <div class="form-box1-row-content float-right">
            <div>
                <label>
                    <%: Html.LabelFor(model => model.MinRequiredPasswordLength)%></label>
                <%: Html.TextBoxFor(model => model.MinRequiredPasswordLength)%>
                <%: Html.ValidationMessageFor(model => model.MinRequiredPasswordLength)%>
            </div>
        </div>
    </div>
    <div class="form-box1-row">
        <div class="form-box1-row-content float-left">
            <div>
                <label>
                    <%: Html.LabelFor(model => model.MinRequiredNonalphanumericCharacters)%></label>
                <%: Html.TextBoxFor(model => model.MinRequiredNonalphanumericCharacters)%>
                <%: Html.ValidationMessageFor(model => model.MinRequiredNonalphanumericCharacters)%>
            </div>
        </div>
        <div class="form-box1-row-content float-right">
            <div>
                <label>
                    <%: Html.LabelFor(model => model.PasswordAttemptWindow)%></label>
                <%: Html.TextBoxFor(model => model.PasswordAttemptWindow)%>
                <%: Html.ValidationMessageFor(model => model.PasswordAttemptWindow)%>
            </div>
        </div>
    </div>
    <div class="form-box1-row">
        <div class="form-box1-row-content float-left">
            <div>
                <label>
                    <%: Html.LabelFor(model => model.AppDateFormat)%></label>
                <%: Html.TextBoxFor(model => model.AppDateFormat)%>
                <%: Html.ValidationMessageFor(model => model.AppDateFormat)%>
            </div>
        </div>
        <div class="form-box1-row-content float-right">
            <div>
                <label>
                    <%: Html.LabelFor(model => model.SMTPServer)%></label>
                <%: Html.TextBoxFor(model => model.SMTPServer)%>
                <%: Html.ValidationMessageFor(model => model.SMTPServer)%>
            </div>
        </div>
    </div>
    <div class="form-box1-row">
        <div class="form-box1-row-content float-left">
            <div>
                <label>
                    <%: Html.LabelFor(model => model.SMTPPort)%></label>
                <%: Html.TextBoxFor(model => model.SMTPPort)%>
                <%: Html.ValidationMessageFor(model => model.SMTPPort)%>
            </div>
        </div>
        <div class="form-box1-row-content float-right">
            <div>
                <label>
                    <%: Html.LabelFor(model => model.SMTPUsername)%></label>
                <%: Html.TextBoxFor(model => model.SMTPUsername)%>
                <%: Html.ValidationMessageFor(model => model.SMTPUsername)%>
            </div>
        </div>
    </div>
    <div class="form-box1-row">
        <div class="form-box1-row-content float-left">
            <div>
                <label>
                    <%: Html.LabelFor(model => model.SMTPPassword)%></label>
                <%: Html.TextBoxFor(model => model.SMTPPassword)%>
                <%: Html.ValidationMessageFor(model => model.SMTPPassword)%>
            </div>
        </div>
        <div class="form-box1-row-content float-right">
            <div>
                <label>
                    <%: Html.LabelFor(model => model.EnableExpirePasswordWhenUserNotLoginFromDays)%></label>
                <%: Html.TextBoxFor(model => model.EnableExpirePasswordWhenUserNotLoginFromDays)%>
                <%: Html.ValidationMessageFor(model => model.EnableExpirePasswordWhenUserNotLoginFromDays)%>
            </div>
        </div>
    </div>
    <div class="form-box1-row">
        <div class="form-box1-row-content float-left">
            <div>
                <label>
                    <%: Html.LabelFor(model => model.EnableAutoExpirePassword)%></label>
                <%: Html.RadioButtonFor(model => model.EnableAutoExpirePassword, true)%>Yes
                <%: Html.RadioButtonFor(model => model.EnableAutoExpirePassword, false)%>No
                <%: Html.ValidationMessageFor(model => model.EnableAutoExpirePassword)%>
            </div>
        </div>
        <div class="form-box1-row-content float-right">
            <div>
                <label>
                    <%: Html.LabelFor(model => model.AutoPasswordExpiryInDays)%></label>
                <%: Html.TextBoxFor(model => model.AutoPasswordExpiryInDays)%>
                <%: Html.ValidationMessageFor(model => model.AutoPasswordExpiryInDays)%>
            </div>
        </div>
    </div>
    <div class="form-box1-row">
        <div class="form-box1-row-content float-left">
            <div>
                <label>
                    <%: Html.LabelFor(model => model.ShowPassowrdExpireNotificationBeforeDays)%></label>
                <%: Html.TextBoxFor(model => model.ShowPassowrdExpireNotificationBeforeDays)%>
                <%: Html.ValidationMessageFor(model => model.ShowPassowrdExpireNotificationBeforeDays)%>
            </div>
        </div>
        <div class="form-box1-row-content float-right">
            <div>
                <label>
                    <%: Html.LabelFor(model => model.Paggination)%></label>
                <%: Html.TextBoxFor(model => model.Paggination)%>
                <%: Html.ValidationMessageFor(model => model.Paggination)%>
            </div>
        </div>
    </div>
   
</div>

    <% }%>

