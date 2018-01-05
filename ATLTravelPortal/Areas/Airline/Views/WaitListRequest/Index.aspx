<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/AirlineMain.Master"
    Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Airline.Models.WaitListRequestModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Wait List Request
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <%
        if (TempData["success"] != null)
        { %>
    <%: TempData["success"]%>
    <%
    
        }
    %>
    <%--<% Html.RenderPartial("~/Views/Shared/ExportData.ascx"); %>--%>
    <div>
        <div class="pageTitle">
            <h3>
                <a href="#" class="icon_plane">Ticket Management</a> <span>&nbsp;</span><strong>Wait
                    List Request</strong>
            </h3>
        </div>
    </div>
    <div class="contentGrid">
        <% if (Model != null)
           { %>
        <%if (Model.WaitListRequestList != null && Model.WaitListRequestList.Count() > 0)
          { %>
        <table cellspacing="0" cellpadding="0" border="0" style="border-collapse: collapse;"
            class="GridView" width="100%">
            <thead>
                <tr>
                    <th>
                        SNo.
                    </th>
                    <th>
                        Agent
                    </th>
                    <th>
                        GDS Ref#
                    </th>
                    <th>
                        Type
                    </th>
                    <th>
                        Passenger
                    </th>
                    <th>
                        Sector
                    </th>
                    <th>
                        Status
                    </th>
                    <th>
                        Booked On
                    </th>
                    <th>
                        Booked By
                    </th>
                    <th>
                    </th>
                    <th>
                    </th>
                    <th>
                    </th>
                </tr>
            </thead>
            <%--  <%if (Model.WaitListRequestList != null)
              { %>--%>
            <%  var sno = 0;
                foreach (var item in Model.WaitListRequestList)
                {

                    sno++;
                    var classTblRow = (sno % 2 == 0) ? "GridAlter" : "GridItem";
            %>
            <tr>
                <td>
                    <%:sno%>
                </td>
                <td>
                    <%: item.AgentName %>
                </td>
                <td>
                    <%: item.GDSRefrenceNumber%>
                </td>
                <td>
                    <%: item.AirlineTypeName%>
                </td>
                <td>
                    <%: item.PassengerName%>
                </td>
                <td>
                    <%: item.Sector%>
                </td>
                <td>
                    <%: item.TicketStatusName%>
                </td>
                <td>
                    <%:  item.BookedOn%>
                </td>
                <td>
                    <%:  item.BookedBy%>
                </td>
                <%-- <td>
                          <%: Html.ActionLink("Open", "Confirm", new { Id = item.PNRId, AgentId = Model.AgentId, FromDate = Model.FromDate, Todate = Model.ToDate, AType = Model.AirlineTypeId }, new { @onclick = "return confirm('Are you sure you want to Confirm?')" })%> 
                       
                        </td>
                        <td>
                        <%: Html.ActionLink("Cancel", "Cancel", new { Id = item.PNRId, AgentId = Model.AgentId, FromDate = Model.FromDate, Todate = Model.ToDate, AType = Model.AirlineTypeId }, new { @onclick = "return confirm('Are you sure you want to Cancel?')" })%>
                       
                        </td>
                         <td>
                        <%: Html.ActionLink("Close", "Close", new { Id = item.PNRId, AgentId = Model.AgentId, FromDate = Model.FromDate, Todate = Model.ToDate, AType = Model.AirlineTypeId }, new { @onclick = "return confirm('Are you sure you want to Close?')" })%>
                       
                        <% if (item.TicketStatusID == 10)
                           {  %>
                        <td>
                            <%: Html.ActionLink("Issue", "Issue", new { Id = item.PNRId, FromDate = Model.FromDate, Todate = Model.ToDate, AType = Model.AirlineTypeId }, new { @onclick = "return confirm('Are you sure you want to Issue?')" })%>
                        </td>
                        <%} %>

                        </td>--%>
                <%if (item.TicketStatusName == "Waitlist-Open")
                  { %>
                <td>
                </td>
                <td>
                    <%: Html.ActionLink("Cancel", "Cancel", new { Id = item.PNRId}, new { @onclick = "return confirm('Are you sure you want to Cancel?')" })%>
                </td>
                <td>
                    <%: Html.ActionLink("Close", "Close", new { Id = item.PNRId }, new { @onclick = "return confirm('Are you sure you want to Close?')" })%>
                </td>
                <%} %>
                <%if (item.TicketStatusName == "Waitlist")
                  { %>
                <td>
                    <%: Html.ActionLink("Open", "Confirm", new { Id = item.PNRId }, new { @onclick = "return confirm('Are you sure you want to Open?')" })%>
                </td>
                <td>
                    <%: Html.ActionLink("Cancel", "Cancel", new { Id = item.PNRId}, new { @onclick = "return confirm('Are you sure you want to Cancel?')" })%>
                </td>
                <td>
                </td>
                <%} %>
                <%if (item.TicketStatusName == "Waitlist-Cancelled")
                  { %>
                <td>
                    <%: Html.ActionLink("Open", "Confirm", new { Id = item.PNRId }, new { @onclick = "return confirm('Are you sure you want to Confirm?')" })%>
                </td>
                <td>
                    <%: Html.ActionLink("Cancel", "Cancel", new { Id = item.PNRId }, new { @onclick = "return confirm('Are you sure you want to Cancel?')" })%>
                </td>
                <td>
                    <%: Html.ActionLink("Close", "Close", new { Id = item.PNRId}, new { @onclick = "return confirm('Are you sure you want to Close?')" })%>
                </td>
                <%} %>
            </tr>
            <% } %>
            <%--  end of if loop--%>
            <%}
            %>
            <%------------------------  Data for paging ------------------------%>
            <% int numberOfPage = Int32.Parse(ViewData["TotalPages"].ToString());
               int currentPage = Int32.Parse(ViewData["CurrentPage"].ToString());%>
            <%------------------------End  Data for paging ------------------------%>
        </table>
        <%if (Model.WaitListRequestList != null && Model.WaitListRequestList.Count() > 0)
          { %>
        <table class="grid_tbl paging" border="0" width="100%">
            <tr>
                <td>
                    <%=Ajax.ActionLink("<<First", "Index", new { controller = "WaitListRequest", action = "Index", pageNo = 1 },
                  new AjaxOptions() { UpdateTargetId = "AjaxResultPlaceHolder", OnBegin = "beginList", OnSuccess = "successList", InsertionMode = InsertionMode.Replace, HttpMethod = "Get" }, new { @class = "btn1" })%>
                    <%=Ajax.ActionLink("Previous", "Index", new { controller = "WaitListRequest", action = "Index", pageNo = currentPage, flag = 1 },
                 new AjaxOptions() { UpdateTargetId = "AjaxResultPlaceHolder", OnBegin = "beginList", OnSuccess = "successList", InsertionMode = InsertionMode.Replace, HttpMethod = "Get" }, new { @class = "btn1" })%>
                    &nbsp;&nbsp;Page&nbsp;&nbsp;<%=currentPage%>&nbsp;of &nbsp;<%=numberOfPage%>&nbsp;&nbsp;
                    <%=Ajax.ActionLink("Next", "Index", new { controller = "WaitListRequest", action = "Index", pageNo = currentPage, flag = 2 },
                    new AjaxOptions() { UpdateTargetId = "AjaxResultPlaceHolder", OnBegin = "beginList", OnSuccess = "successList", InsertionMode = InsertionMode.Replace, HttpMethod = "Get" }, new { @class = "btn1" })%>
                    <%=Ajax.ActionLink("Last>>", "Index", new { controller = "WaitListRequest", action = "Index", pageNo = numberOfPage },
                  new AjaxOptions() { UpdateTargetId = "AjaxResultPlaceHolder", OnBegin = "beginList", OnSuccess = "successList", InsertionMode = InsertionMode.Replace, HttpMethod = "Get" }, new { @class = "btn1" })%>
                </td>
            </tr>
        </table>
        <%} %>
        <%--new code--%>
        <% if (Model.WaitListRequestList != null && Model.WaitListRequestList.Count() > 0)
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
                //var IsApproved = $("#UnApproved").val();UnApproved
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




        ///////////////////////////////////////// Autocomplete ////////////////////////////////////////////////
        $(document).ready(function () {

            $(function () {
                $("#AirlinesName").autocomplete({
                    source: function (request, response) {
                        $.ajax({
                            url: "/Airline/SectorSales/FindAirline", type: "POST", dataType: "json",
                            data: { searchText: request.term, maxResult: 5 },

                            success: function (data) {
                                response($.map(data, function (item) {
                                    return { label: item.AirlineName + " (" + item.AirlineCode + ")", value: item.AirlineName, id: item.AirlineId }
                                }))
                            }
                        });
                    },
                    width: 150,
                    select: function (event, ui) {
                        $("#AirlinesName").val(ui.item.id);


                    }

                });
            });

        });


        /////////////////////////////////////////End  Autocomplete ////////////////////////////////////////////////
         
        

    </script>
</asp:Content>
