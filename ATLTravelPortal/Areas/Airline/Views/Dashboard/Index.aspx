<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/AirlineMain.Master" Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Airline.Models.DashboardModel>" %>
<%@ Import Namespace="ATLTravelPortal.Helpers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Airline Dashboard
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<div>
<% Html.EnableClientValidation(); %>

<%-- <form id="form1" runat="server">--%>
    <% using (Html.BeginForm())
       { %>
    <%: Html.ValidationSummary(true)%>
    <label>
        <%: Html.LabelFor(model => model.FromDate)%></label>
    <%: Html.TextBoxFor(model => model.FromDate, String.Format("{0:d}", Model.FromDate))%>
    <%: Html.ValidationMessageFor(model=>model.FromDate) %>
    <label>
        <%: Html.LabelFor(model => model.ToDate)%></label>
    <%: Html.TextBoxFor(model => model.ToDate, String.Format("{0:M/d/yyyy}", Model.ToDate))%>
    <%: Html.ValidationMessageFor(model => model.ToDate)%>
    <input class="float-right" type="submit" value="Set" />
    <%} %>
<%--</form>--%>

</div>
<div class="float-right"> <%=Html.FChart("SalesChart", ViewData["SalesChart"], 800, 200)%>
<div class="float-right"><%=Html.FChart("TicketStatusChart", ViewData["TicketStatusChart"], 380, 300)%> </div>
<div class="float-right"> <%=Html.FChart("TTLChart", ViewData["TTLChart"], 380, 300)%></div>
<div class="float-right"> <%=Html.FChart("CappingChart", ViewData["CappingChart"],800, 200)%></div>
<div> <%=Html.FChart("SegmentChart", ViewData["SegmentChart"], 800, 250)%></div>

</div>
<div>
</div>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="CssContent" runat="server">
<link href="../../Content/css/adminDashboard.css" rel="stylesheet" type="text/css" />
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
  <script src="../../Scripts/FusionCharts.js" type="text/javascript"></script>
   <script language="javascript" type="text/javascript">
       $(function () {
           var dates = $("#FromDate, #ToDate").datepicker({
               defaultDate: "+1d",
               changeMonth: true,
               changeYear: true,
               constrainInput: true,
               numberOfMonths: 2,
               //  dateFormat: 'dd/mm/yy',
               //minDate: Date(),
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
