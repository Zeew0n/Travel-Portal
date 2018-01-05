<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<ATLTravelPortal.Areas.Train.Models.TrainBookingRequestModel>" %>
<%@ Import Namespace="ATLTravelPortal.Helpers" %>

<% Html.EnableClientValidation(); %><% using (Html.BeginForm())
       {%>
    <%: Html.ValidationSummary(true) %>
    <div class="row-1">
        <div class="form-box1 round-corner">
            <div class="form-box1-row" id="DateFilter">
                <div class="form-box1-row-content float-left">
                    <div>
                        <label>
                            <%: Html.LabelFor(model => model.FromDate)%></label>
                        <%: Html.TextBox("FromDate", (Model != null && Model.FromDate != null && Model.FromDate != DateTime.MinValue) ?
                            (TimeFormat.DateFormat(Model.FromDate.ToString())) :
                            (TimeFormat.DateFormat(TimeFormat.DateFormat(DateTime.Today.ToString()))))%>
                        <%: Html.ValidationMessageFor(model => model.FromDate, "*")%>
                    </div>
                </div>
                <div class="form-box1-row-content float-right">
                    <div>
                        <label>
                            <%: Html.LabelFor(model => model.ToDate)%></label>
                        <%: Html.TextBox("ToDate", (Model != null && Model.ToDate != null && Model.ToDate != DateTime.MinValue) ?
                            (TimeFormat.DateFormat(Model.ToDate.ToString())) :
                            (TimeFormat.DateFormat(TimeFormat.DateFormat(DateTime.Today.ToString()))))%>
                        <%: Html.ValidationMessageFor(model => model.ToDate, "*")%>
                    </div>
                </div>
            </div>
        </div>
        <div class="form-box1 round-corner">
            <div class="form-box1-row">
                <div class="form-box1-row-content float-left">
                    <div>
                        <label>
                            <%: Html.LabelFor(model => model.DistrubutorId)%></label>
                        <%:Html.DropDownListFor(model => model.DistrubutorId, (SelectList)ViewData["DisList"], "---ALL---")%>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="buttonBar  reportLeftDiv commonWidth">
        <% if (Model != null)
           {
               if (Model.PagedList != null)
               {
                   if (Model.PagedList != null && Model.PagedList.Count() > 0)
                   { %>
       <% Html.RenderPartial("~/Views/Shared/ExportData.ascx"); %>
        <%}
               }
           }%>
        <input class="float-right" type="submit" value="Search" />
    </div>
    <%} %>
   <script language="javascript" type="text/javascript">

       $(function () {
           var dates = $("#FromDate, #ToDate").datepicker({
               defaultDate: "+1d",
               changeMonth: true,
               changeYear: true,
               constrainInput: true,
               numberOfMonths: 2,
               dateFormat: 'dd M yy',
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