<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/DistributorMain.Master"
    Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Airline.Models.PendingBookingModel>" %>

<%@ Import Namespace="ATLTravelPortal.Helpers" %>
<%@ Import Namespace="ATLTravelPortal.Helpers.Pagination" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Pending-Booking Report
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <%
        if (TempData["success"] != null)
        { %>
    <%: TempData["success"]%>
    <%
    
        }
    %>
    <% Html.EnableClientValidation(); %>
    <% using (Html.BeginForm())
       {%>
    <%: Html.ValidationSummary(true) %>
    <div class="pageTitle">
        <ul class="buttons-panel">
            <li>
                <div id="loadingIndicator">
                </div>
            </li>
            <li></li>
            <li></li>
        </ul>
        <h3>
            Reports<span>&nbsp;</span><strong> Pending-Booking Report</strong>
        </h3>
    </div>
    <% Html.RenderPartial("~/Views/Shared/ExportData.ascx"); %>
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
                    </div>
                </div>
                <div class="form-box1-row-content float-right">
                    <div>
                        <label>
                            <%: Html.LabelFor(model => model.ToDate)%></label>
                        <%: Html.TextBox("ToDate", (Model != null && Model.ToDate != null && Model.ToDate != DateTime.MinValue) ?
                            (TimeFormat.DateFormat(Model.ToDate.ToString())) :
                            (TimeFormat.DateFormat(TimeFormat.DateFormat(DateTime.Today.ToString()))))%>
                    </div>
                </div>
            </div>
        </div>
        <div class="form-box1 round-corner">
            <div class="form-box1-row">
                <div class="form-box1-row-content float-left">
                    <div>
                        <label>
                            Agents</label>
                        <%:Html.DropDownListFor(model => model.AgentId, (SelectList)ViewData["Agents"], "--- ALL---")%>
                        <%: Html.ValidationMessageFor(model => model.AgentId, "*")%>
                    </div>
                </div>
            </div>
        </div>
        <div class="buttonBar  reportLeftDiv ">
            <input class="float-right" type="submit" value="Search" />
        </div>
    </div>
    <% } %>
    <div class="contentGrid">
        <% if (Model != null)
           { %>
        <%if (Model.PendingBookingList != null && Model.PendingBookingList.Count() > 0)
          { %>
        <table cellspacing="0" cellpadding="0" border="0" style="border-collapse: collapse;"
            class="GridView" width="100%">
            <thead>
                <tr>
                    <th>
                        SNo.
                    </th>
                    <% if (Model.AgentId == null)
                       { %>
                    <th>
                        Agent(Code)
                    </th>
                    <%} %>
                    <th>
                        Passenger Name
                    </th>
                    <th>
                        Sector
                    </th>
                    <th>
                        GDS PNR
                    </th>
                    <th>
                        Flight Date
                    </th>
                    <th>
                        Booked On
                    </th>
                    <th>
                        Booked By
                    </th>
                </tr>
            </thead>
            <%  var sno = 0;
                foreach (var item in Model.PendingBookingList)
                {

                    sno++;
                    var classTblRow = (sno % 2 == 0) ? "GridAlter" : "GridItem";
            %>
            <tr>
                <td>
                    <%: sno %>.
                </td>
                <% if (Model.AgentId == null)
                   { %>
                <td>
                    <%: item.AgentName%>(<%: item.AgentCode %>)
                </td>
                <%} %>
                <td>
                    <%: item.PassegerName%>
                </td>
                <td>
                    <%:  item.Sector%>
                </td>
                <td>
                    <%: item.GDSReferenceNumber %>
                </td>
                <td>
                    <%: TimeFormat.DateFormat( item.FlightDate.ToString()) %>
                </td>
                <td>
                    <%:  item.BookedOn%>
                </td>
                <td>
                    <%:  item.BookedBy%>
                </td>
                <% } %>
                <%}
                %>
            </tr>
        </table>
        <% if (Model.PendingBookingList != null && Model.PendingBookingList.Count() > 0)
           { %>
        <% }
           else
           {
               Html.RenderPartial("NoRecordsFound");
           } 
        %>
        <%--..............................................................--%>
        <%} %>
    </div>
    <div class="pager">
        <%= Html.Pager(ViewData.Model.PendingBookingList.PageSize, ViewData.Model.PendingBookingList.PageNumber, ViewData.Model.PendingBookingList.TotalItemCount, new { FromDate = TimeFormat.DateFormat(Model.FromDate.ToString()), ToDate = TimeFormat.DateFormat(Model.ToDate.ToString()) })%>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CssContent" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
    <script src="../../../../Scripts/ATL.function.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript">

        $(function () {
            var dates = $("#FromDate, #ToDate").datepicker({
                defaultDate: "+1d",
                changeMonth: true,
                changeYear: true,
                constrainInput: true,
                numberOfMonths: 2,
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
