<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/AirlineMain.Master" Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Airline.Models.OffLineBookViewModel.OfflineBookViewModel>" %>


<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Offline Booking
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
        <div class="ledger_subtable create_tbl" style="margin: 1px 0">
        <div class="pageTitle">
            <ul class="buttons-panel">
                <li> <%:Html.ActionLink("New", "Create", "IndianLccAirOfflineBook",null, new { @class = "createDeal linkButton", @title = "New Offline Booking" })%>
                </li>
                <li></li>
            </ul>
            <h3>
                <a href="#" class="icon_plane">Indian LCC</a> <span>&nbsp;</span><strong>Offline Booking Process</strong>
            </h3>
        </div>
    </div>
<% Html.RenderPartial("BookSearchPartial", Model.input); %>
    
      <% Html.EnableClientValidation(); %>
    <% using (Html.BeginForm("Index", "IndianLccAirOfflineBook", FormMethod.Post, new { @class = "validate" }))%>
    <% { %>
    <%: Html.ValidationSummary(true)%>
    <% Html.RenderPartial("ListPartial",Model);%>
    <%} %>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="CssContent" runat="server">
    <link href="../../../../Content/css/atsfltsearch.css" rel="stylesheet" type="text/css" />
   
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
<script type="text/javascript">
//    $(function () {
//        var dates = $("#FromDate, #ToDate").datepicker({
//            defaultDate: "+1d",
//            changeMonth: true,
//            changeYear: true,
//            constrainInput: true,
//            numberOfMonths: 2,
//            dateFormat: 'dd M yy',
//            onSelect: function (selectedDate) {
//                var option = this.id == "FromDate" ? "minDate" : "maxDate",
//				instance = $(this).data("datepicker");
//                date = $.datepicker.parseDate(
//					instance.settings.dateFormat ||
//					$.datepicker._defaults.dateFormat,
//					selectedDate, instance.settings);
//                dates.not(this).datepicker("option", option, date);
//            }
//        });

    //    });

  $(function () {
            $(function () {
                var dates = $("#FromDate,#ToDate").datepicker({
                    defaultDate: "+1d",
                    changeMonth: true,
                    changeYear: true,
                    minDate: new Date(),
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
</asp:Content>
