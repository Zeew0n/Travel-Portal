<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/AdministratorMain.Master"
    Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Administrator.Models.MEsCreditLimitModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <%Html.RenderPartial("~/Views/Shared/Utility/VUC_MessagePanel.ascx"); %>
    <%Html.EnableClientValidation(); %>
    <% using (Html.BeginForm())
       {%>
    <%: Html.ValidationSummary(true) %>
    <div class="pageTitle">
        <ul class="buttons-panel">
            <li>
                <div id="loadingIndicator">
                </div>
                <label id="lblSuccess" style="display: none; color: Green; font-weight: bold;">
                </label>
            </li>
        </ul>
        <h3>
            MEs CreditLimit <span>&nbsp;</span><strong>Create</strong>
           
        </h3>
    </div>
    <% Html.RenderPartial("VUC_Add"); %>
    <div>
        <input type="submit" value="Save" />
       <input type="button" onclick="document.location.href='/Administrator/MEsCreditLimit/Index'"
            value="Back To List" class="float-right" />
    </div>
    <% } %>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CssContent" runat="server">
    <script src="../../../../Scripts/timepicker.js" type="text/javascript"></script>
    <script src="/Scripts/jquery.maskedinput-1.3.js" type="text/javascript"></script>
    <script type="text/javascript">

        $(function () {
            $(function () {
                var dates = $("#EffictiveFrom,#ExpireOn").datepicker({
                    defaultDate: "+1d",
                    changeMonth: true,
                    changeYear: true,
                    minDate: new Date(),
                    constrainInput: true,
                    numberOfMonths: 1,
                    disable: true,
                    showAnim: 'fold',
                    dateFormat: 'dd M yy',
                    buttonImage: '../../Content/images/calendar.gif',
                    buttonImageOnly: true,
                    showOn: 'both',
                    buttonText: 'Choose Date',
                    onSelect: function (selectedDate) {
                        var option = this.id == "EffictiveFrom" ? "minDate" : "maxDate",
                instance = $(this).data("datepicker");
                        date = $.datepicker.parseDate(
                instance.settings.dateFormat ||
                $.datepicker._defaults.dateFormat,
                selectedDate, instance.settings);
                        dates.not(this).datepicker("option", option, date);
                    }
                });
            });

        });      
    </script>
</asp:Content>
