<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/DistributorMain.Master"
    Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Airline.Models.IssuedTicketModel>" %>

<%@ Import Namespace="ATLTravelPortal.Helpers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Issued Ticket Report
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
    <div>
        <div class="pageTitle">
            <h3>
                <a href="#" class="icon_plane">Reports</a> <span>&nbsp;</span><strong>Issued Ticket</strong>
            </h3>
        </div>
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
    </div>
    <div class="row-1">
        <div class="form-box1 round-corner">
            <div class="form-box1-row">
                <div class="form-box1-row-content float-left">
                    <div>
                        <label>
                            <%: Html.LabelFor(model => model.AgentId)%></label>
                        <%:Html.DropDownListFor(model => model.AgentId, (SelectList)ViewData["AgentList"], "---ALL---")%>
                    </div>
                </div>
            </div>
        </div>
        <div class="form-box1-row">
            <p class="mrg-lft-130">
                <input type="submit" value="Search" class="btn3" />
            </p>
        </div>
    </div>
    <% } %>
    <div class="contentGrid">
        <% if (Model != null)
           { %>
        <%if (Model.IssuedTicketList != null && Model.IssuedTicketList.Count() > 0)
          { %>
        <table cellspacing="0" cellpadding="0" border="0" style="border-collapse: collapse;"
            class="GridView" width="100%">
            <thead>
                <tr>
                    <th>
                        SNo
                    </th>
                    <th width="150px">
                        Agent Name(Code)
                    </th>
                    <th>
                        Passenger Name
                    </th>
                    <th>
                        No of Pax
                    </th>
                    <th>
                        Airline Code
                    </th>
                    <th width="100px">
                        Sector
                    </th>
                    <th>
                        Status
                    </th>
                    <th width="80px">
                        GDS PNR
                    </th>
                    <th>
                        Flight Date
                    </th>
                    <th width="65px">
                        Issued On
                    </th>
                    <th>
                        Issued By
                    </th>
                    <th>
                        Service Provider
                    </th>
                    <th width="90px">
                        Created By
                    </th>
                    <th>
                    </th>
                </tr>
            </thead>
            <%var sno = 0;
              foreach (var item in Model.IssuedTicketList)
              {
                  sno++;
                  var classTblRow = (sno % 2 == 0) ? "GridAlter" : "GridItem";
            %>
            <tr>
                <td>
                    <%:sno%>.
                </td>
                <td>
                    <%: item.AgentName %>(<%: item.AgentCode %>)
                </td>
                <td>
                    <%: item.PassengerName%>
                </td>
                <td>
                    <%: item.NoOfPax %>
                </td>
                <td>
                    <%: item.AirlineCode %>
                </td>
                <td>
                    <%: item.Sector%>
                </td>
                <% if (item.isTicketUploaded == false)
                   { %>
                <td width="55">
                    <a href="<%:item.ServiceProviderETicketUrl%>/ViewETicket/<%:item.PNRId %>" class="Details"
                        target="_blank">
                        <img src="../../../../Content/Icons/view.png" style="margin-top: 3px;" /></a>
                    <a href="<%:item.ServiceProviderETicketUrl%>/ETicket/<%:item.PNRId %>" class="Details"
                        target="_blank">
                        <img src="../../../../Content/Icons/pdf.png" style="margin-top: 3px;" /></a>
                </td>
                <%} %>
                <% else
                   { %>
                <td>
                    <a href="/Airline/AirOfflineBook/DownloadETicket/<%:item.PNRId %>" class="Details"
                        title="Download Eticket">
                        <br />
                        <img src="../../../../Content/Icons/Download.png" alt="Download Eticket" />
                    </a>
                </td>
                <%} %>
                <td>
                    <%:  item.GDSReferenceNumber%>
                </td>
                <td>
                    <%:TimeFormat.DateFormat( item.FlightDate.ToString()) %>
                </td>
                <td>
                    <%: TimeFormat.DateFormat(item.IssuedOn.ToString())%>
                </td>
                <td>
                    <%: item.IssuedBy %>
                </td>
                <td>
                    <%: item.ServiceProviderName %>
                </td>
                <td>
                    <%:  item.CreatedBy%>
                </td>
                <td>
                    <a href="/Airline/DistributorInvoice/Index/<%:item.PNRId %>" class="Details" target="_blank">
                        Distributor Invoice</a>|| <a href="/Airline/AgentInvoice/Index/<%:item.PNRId %>"
                            class="Details" target="_blank">Agent Invoice</a>
                </td>
            </tr>
            <% } %>
            <%}
            %>
        </table>
        <% if (Model.IssuedTicketList != null && Model.IssuedTicketList.Count() > 0)
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
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CssContent" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
    <script src="../../../../Scripts/ATL.function.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript">

        $(document).ready(function () {

            $("#showall").click(function () {
                var productId = $("#ProductId").val();
                var AgentId = $("#AgentId").val();
                var FDate = $("#FromDate").val();
                var TDate = $("#ToDate").val();

                var IsApproved = false;
                if ($("#UnApproved").attr('checked')) {
                    IsApproved = true;
                }

                $.ajax(

             {

                 type: "GET",

                 url: "/LedgerVoucher/Index",

                 data: "productId=" + productId + "&AgentId=" + AgentId + "&FDate=" + FDate + "&TDate=" + TDate + "&IsApproved=" + IsApproved,

                 success: function (result) {
                     $("#ListPartial").empty().append(result);

                 },

                 error: function (req, status, error) {

                     //        alert("Sorry! We could not receive your feedback at this time.");

                 }

             });

            });
        });
        ///////////////////////////End of document ready function ////////////////////////////////////


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
        //////////////////////////////End of Date Picker /////////////////////////////////////////////////
        function EnableDisableElementBySelectionAppliedDate(thisElm, targetElm) {
            if (thisElm == "checked") {
                $("#" + targetElm).attr('disabled', 'disabled');
                $("#" + targetElm).val("")
            }
            else {
                $("#" + targetElm).removeAttr('disabled', 'disabled');
            }
        }
    </script>
</asp:Content>
