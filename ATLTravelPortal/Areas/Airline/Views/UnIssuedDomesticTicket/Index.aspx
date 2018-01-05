<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/AirlineMain.Master"
 Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Airline.Models.UnIssuedDomesticTicketModel>" %>

  <%@ Import Namespace="ATLTravelPortal.Helpers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    UnIssued Domestic Ticket
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <%
        if (TempData["Error"] != null)
        { %>
    <%: TempData["Error"]%>
    <%
    
        }
    %>
     <div>
        <div class="pageTitle">
          
            <h3>
                <a href="#" class="icon_plane">Ticket Management</a> <span>&nbsp;</span><strong>UnIssued Domestic Ticket</strong>
            </h3>
        </div>
    </div>
    <div class="contentGrid">
        <% if (Model != null)
           { %>
        <table cellspacing="0" cellpadding="0" border="0" style="border-collapse: collapse;"
            class="GridView" width="100%">
            <thead>
                <tr>
                    <th>
                        SNo
                    </th>
                    <th>
                        Agent
                    </th>
                   
                    <th>
                        Passenger
                    </th>
                    <th>
                        Airline
                    </th>
                    <th>
                      Sector
                    </th>
                    <th>
                        Status 
                    </th>
                    <th>
                    Booked By
                    </th>
                    <th>
                    Booked on
                    </th>
                    <th></th>
                </tr>
            </thead>
            <%if (Model.UsIssuedDomesticTicketList != null)
              { %>
            <%  var sno = 0;
                foreach (var item in Model.UsIssuedDomesticTicketList)
                {

                    sno++;
                    var classTblRow = (sno % 2 == 0) ? "GridAlter" : "GridItem";
            %>
            <tr>
                <td>
                    <%:sno%>
                </td>
                 <td>
                    <%:item.AgentName%>
                </td>
                 <td>
                    <%:item.Passenger%>
                </td>
                <td>
                    <%: item.AirlineCode%>
                </td>
                <td>
                    <%: item.Sector%>
                </td>
                <td>
                    <%:  item.TicketStatusName%>
                </td>
                <td>
                    <%:  item.BookedBy%>
                </td>
                <td>
                    <%: TimeFormat.DateFormat( item.BookedDate.ToString())%>
                </td>
                <td>
                 <%: Html.ActionLink("Details", "Index", new { Controller = "IssueDomesticTickets", Id = item.PNRID, doOnlyUploadETicket =false})%> 
                </td>
               
            </tr>
            <% } %>
            <%-- end of if loop--%>

            <%------------------------  Data for paging ------------------------%>
         <% int numberOfPage =Int32.Parse(ViewData["TotalPages"].ToString());
                       int currentPage = Int32.Parse(ViewData["CurrentPage"].ToString());%> 
          <%------------------------End  Data for paging ------------------------%>




           <%if (Model.UsIssuedDomesticTicketList != null && Model.UsIssuedDomesticTicketList.Count() > 0)
             { %>
         <table class="grid_tbl paging" border="0" width="100%">
        <tr>
            <td>
                
                 <%=Ajax.ActionLink("<<First", "Index", new { controller = "UnIssuedDomesticTicket", action = "Index", pageNo = 1 },
                  new AjaxOptions() { UpdateTargetId = "AjaxResultPlaceHolder", OnBegin = "beginList", OnSuccess = "successList", InsertionMode = InsertionMode.Replace, HttpMethod = "Get" }, new { @class = "btn1" })%>                                                  
 

                 <%=Ajax.ActionLink("Previous", "Index", new { controller = "UnIssuedDomesticTicket", action = "Index", pageNo = currentPage, flag = 1 },
                 new AjaxOptions() { UpdateTargetId = "AjaxResultPlaceHolder", OnBegin = "beginList", OnSuccess = "successList", InsertionMode = InsertionMode.Replace, HttpMethod = "Get" }, new { @class = "btn1" })%>                                                  
 
                        &nbsp;&nbsp;Page&nbsp;&nbsp;<%=currentPage%>&nbsp;of &nbsp;<%=numberOfPage%>&nbsp;&nbsp;
                  <%=Ajax.ActionLink("Next", "Index", new { controller = "UnIssuedDomesticTicket", action = "Index", pageNo = currentPage, flag = 2 },
                    new AjaxOptions() { UpdateTargetId = "AjaxResultPlaceHolder", OnBegin = "beginList", OnSuccess = "successList", InsertionMode = InsertionMode.Replace, HttpMethod = "Get" }, new { @class = "btn1" })%>                                                  
                     
                 <%=Ajax.ActionLink("Last>>", "Index", new { controller = "UnIssuedDomesticTicket", action = "Index", pageNo = numberOfPage },
                  new AjaxOptions() { UpdateTargetId = "AjaxResultPlaceHolder", OnBegin = "beginList", OnSuccess = "successList", InsertionMode = InsertionMode.Replace, HttpMethod = "Get" }, new { @class = "btn1" })%>                                                  
                  
            </td>
        </tr>
     </table>
     <%} %>

          
            <%}
            %>
        </table>


        

        <%--new code--%>
        <% if (Model.UsIssuedDomesticTicketList != null && Model.UsIssuedDomesticTicketList.Count() > 0)
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

         
        

    </script>
</asp:Content>
