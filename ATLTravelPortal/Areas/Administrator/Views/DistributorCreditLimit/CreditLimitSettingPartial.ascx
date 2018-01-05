<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<ATLTravelPortal.Areas.Administrator.Models.CreditLimitModel>" %>
<%--<%if (Model.CreditLimit != null) %>
<% {%>--%>
<% Html.EnableClientValidation(); %>
<% using (Html.BeginForm("Create", "DistributorCreditLimit", FormMethod.Post))
   {%>
<%: Html.ValidationSummary(true)%>
<div class="row-1  mrg-top-20">
    <h3>
    </h3>
    <%if (Model.hdBank)
      { %>
    <div class="form-box1-row">
        <div class="form-box1-row-content float-left">
            <div>
                <label>
                    Bank:</label>
                <%:Html.DropDownListFor(model => model.ddlBankId, Model.BankList, "-----Select-----")%>
                <%: Html.ValidationMessageFor(model => model.ddlBankId, "*")%>
                <%: Html.HiddenFor(model =>model.hdfbank) %>
            </div>
        </div>
    </div>
    <%} %>
    <%if (Model.hdAmount)
      { %>
    <div class="form-box1-row">
        <div class="form-box1-row-content float-left">
            <div>
                <label>
                    Currency:</label>
                <%:Html.DropDownListFor(model => model.CurrencyId, Model.Currencies)%>
                <%: Html.ValidationMessageFor(model => model.CurrencyId, "*")%>
            </div>
        </div>
    </div>
    <div class="form-box1-row">
        <div class="form-box1-row-content float-left">
            <div>
                <label>
                    Amount:</label>
                <%: Html.TextBoxFor(model => model.txtAmount)%>
                <%: Html.ValidationMessageFor(model => model.txtAmount, "*")%>
            </div>
        </div>
    </div>
    <%} %>
    <div class="form-box1-row">
        <div class="form-box1-row-content float-left">
            <div>
                <label>
                    <%:Html.LabelFor(model => model.Comments)%></label>
                <%: Html.TextAreaFor(model => model.Comments,new { @Style = " width:168px; height:60px; font:11px Tahoma; padding:5px;" })%>
                <%:Html.ValidationMessageFor(model => model.Comments, "*")%>
            </div>
        </div>
    </div>
    <div class="form-box1-row">
        <div class="form-box1-row-content float-left">
            <div>
                <label>
                    <%: Html.LabelFor(model => model.FromDate)%></label>
                <%: Html.TextBoxFor(model => model.FromDate)%>
                <%: Html.ValidationMessageFor(model => model.FromDate, "*")%>
                <%: Html.HiddenFor(model=>model.hdfEffectiveFrom) %>
            </div>
        </div>
    </div>
    <div class="form-box1-row">
        <div class="form-box1-row-content float-left">
            <div>
                <label>
                    <%: Html.LabelFor(model => model.ToDate)%></label>
                <%: Html.TextBoxFor(model => model.ToDate)%>
                <%: Html.ValidationMessageFor(model => model.ToDate, "*")%>
                <%: Html.HiddenFor(model=>model.hdfExpireOn) %>
            </div>
        </div>
    </div>
    <%if (Model.showbutton)
      { %>
    <div class="form-box1-row">
        <p class="mrg-lft-130">
            <input type="submit" value="Save" class="btn3" />
            <%: Html.HiddenFor( model=>model.hdfagentid) %>
            <%: Html.HiddenFor(model=>model.hdfTypeid) %>
        </p>
    </div>
</div>
<%} %>
<%} %>

<script type="text/javascript">

    $(function () {
        var minDate = new Date('<%: Model.hdfEffectiveFrom %>');
        var maxDate = new Date('<%: Model.hdfExpireOn %>');

        var dates = $("#FromDate,#ToDate").datepicker({
            defaultDate: "+1d",
            changeMonth: true,
            changeYear: true,
            minDate: minDate,
            maxDate: maxDate,
            constrainInput: true,
            numberOfMonths: 2,
            disable: true,
            showAnim: 'fold',
            dateFormat: 'dd M yy',
            buttonImage: '../../Content/images/calendar.gif',
            buttonImageOnly: true,
            showOn: 'both',
            buttonText: 'Choose Date',
            onSelect: function (selectedDate) {
                var option = this.id == "FromDate" ? "minDate" : "maxDate",
                instance = $(this).data("datepicker");
                date = $.datepicker.parseDate(
                instance.settings.dateFormat ||
                $.datepicker._defaults.dateFormat,
                selectedDate, instance.settings);
                dates.not(this).datepicker("option", option, date);
            }
        });
    });
  
</script>
<%-- <script type="text/javascript">
     $(function () {
         $("#FromDate, #ToDate").live('click', function () {
             $(this).datepicker({ showOn: 'focus' }).focus();
         });
     });
</script>--%>
<script language="javascript" type="text/javascript">

    //     $(document).ready(function () {

    //         $(function () {
    //             var dates = $("#FromDate, #ToDate").datepicker({
    //                 defaultDate: "+1d",
    //                 changeMonth: true,
    //                 changeYear: true,
    //                 constrainInput: true,
    //                 numberOfMonths: 2,
    //                 //minDate: Date(),
    //                 onSelect: function (selectedDate) {
    //                     var option = this.id == "FromDate" ? "minDate" : "maxDate",
    //				instance = $(this).data("datepicker");
    //                     date = $.datepicker.parseDate(
    //					instance.settings.dateFormat ||
    //					$.datepicker._defaults.dateFormat,
    //					selectedDate, instance.settings);
    //                     dates.not(this).datepicker("option", option, date);
    //                     alert(dates);
    //                 }
    //             });
    //         });
    //     });

    //////////////////////////////End of Date Picker /////////////////////////////////////////////////
</script>
