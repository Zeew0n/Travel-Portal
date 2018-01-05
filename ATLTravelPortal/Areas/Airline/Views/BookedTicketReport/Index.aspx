<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/AirlineMain.Master"
    Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Airline.Models.BookedTicketModels>" %>

<%@ Import Namespace="ATLTravelPortal.Helpers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Booked Ticket Report
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
                <a href="#" class="icon_plane">Reports</a> <span>&nbsp;</span><strong>Booked Ticket</strong>
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
  
   
    <div class="contentGrid"> <p class="float-right">
        <span style="background:#666; 
    display: inline-block;
    height:10px;
    margin: 0 3px;
    width: 8px;" ><em style="background:#E8EFBD; border-radius: 100px 100px 100px 100px; -webkit-border-radius: 100px 100px 100px 100px; -moz-border-radius: 100px 100px 100px 100px;
    display: inline-block;
    height: 6px;
    margin: 2px;
    width: 4px; float:left;" ></em></span>:Arihant Holidays&nbsp;&nbsp;</p>
        <% if (Model != null)
           { %>
        <%if (Model.BookedTicketList != null && Model.BookedTicketList.Count() > 0)
          { %>
        <table cellspacing="0" cellpadding="0" border="0" style="border-collapse: collapse;"
            class="GridView" width="100%">
            <thead>
                <tr>
                    <th>
                        SNo
                    </th>
                    <th>
                        Agent Name
                    </th>
                    <th>
                        GDS Ref#
                    </th>
                    <th>
                        Passenger Name
                    </th>
                    <th>
                        Sector
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
                    <th>
                    </th>
                </tr>
            </thead>
            <%  var sno = 0;
                foreach (var item in Model.BookedTicketList)
                {

                    sno++;
                    var classTblRow = (sno % 2 == 0) ? "GridAlter" : "GridItem";
                    var myDistributor = item.BranchOfficeId == 1 ? "greenBg" : "";
            %>
            <tr class='<%=myDistributor %>'>
                <td>
                    <%:sno%>
                </td>
                <td>
                    <%--  ---- details region in popup---------------------%>
                    <a href="javascript: void(0);" class="detailsPopup">
                        <%: item.AgentName %>(<%:item.AgentCode %>) <span>Brach Office :
                            <%:item.BranchOfficeName %><br />
                            Distributor :
                            <%:item.DistributorName %><br />
                        </span></a>
                    <%--  ---- details region in popup---------------------%>
                </td>
                <td>
                    <%:item.GDSRefrenceNumber%>
                </td>
                <td>
                    <%: item.PassengerName%>
                </td>
                <td>
                    <%: item.Sector%>
                </td>
                <td>
                    <%: TimeFormat.DateFormat( item.FlightDate.ToString()) %>
                </td>
                <td>
                    <%: TimeFormat.DateFormat(  item.BookedOn.ToString())%>
                </td>
                <td>
                    <%:  item.BookedBy%>
                </td>
              
                <td>
                   
                    <%: Html.ActionLink("Cancel", "Cancel", new { id = item.PNRId, PNR= item.GDSRefrenceNumber, 
                                                                  PassName= item.PassengerName, AgentName = item.AgentName,
                                                                  City= item.Sector, BookedDate= item.BookedOn, FromDate=Model.FromDate, ToDate=Model.ToDate, AgentId = item.AgentId })%>
                </td>
            </tr>
            <% } %>
            <%------------------------  Data for paging ------------------------%>
            <%--<% int numberOfPage =Int32.Parse(ViewData["TotalPages"].ToString());
                       int currentPage = Int32.Parse(ViewData["CurrentPage"].ToString());%> --%>
            <%------------------------End  Data for paging ------------------------%>
            <%--   <%if (Model.BookedTicketList != null && Model.BookedTicketList.Count() > 0)
             { %>
         <table class="grid_tbl paging" border="0" width="100%">
        <tr>
            <td>
                
                 <%=Ajax.ActionLink("<<First", "Index", new { controller = "BookedTicketReport", action = "Index", pageNo = 1 },
                  new AjaxOptions() { UpdateTargetId = "AjaxResultPlaceHolder", OnBegin = "beginList", OnSuccess = "successList", InsertionMode = InsertionMode.Replace, HttpMethod = "Get" }, new { @class = "btn1" })%>                                                  
 

                 <%=Ajax.ActionLink("Previous", "Index", new { controller = "BookedTicketReport", action = "Index", pageNo = currentPage, flag = 1 },
                 new AjaxOptions() { UpdateTargetId = "AjaxResultPlaceHolder", OnBegin = "beginList", OnSuccess = "successList", InsertionMode = InsertionMode.Replace, HttpMethod = "Get" }, new { @class = "btn1" })%>                                                  
 
                        &nbsp;&nbsp;Page&nbsp;&nbsp;<%=currentPage%>&nbsp;of &nbsp;<%=numberOfPage%>&nbsp;&nbsp;
                  <%=Ajax.ActionLink("Next", "Index", new { controller = "BookedTicketReport", action = "Index", pageNo = currentPage, flag = 2 },
                    new AjaxOptions() { UpdateTargetId = "AjaxResultPlaceHolder", OnBegin = "beginList", OnSuccess = "successList", InsertionMode = InsertionMode.Replace, HttpMethod = "Get" }, new { @class = "btn1" })%>                                                  
                     
                 <%=Ajax.ActionLink("Last>>", "Index", new { controller = "BookedTicketReport", action = "Index", pageNo = numberOfPage },
                  new AjaxOptions() { UpdateTargetId = "AjaxResultPlaceHolder", OnBegin = "beginList", OnSuccess = "successList", InsertionMode = InsertionMode.Replace, HttpMethod = "Get" }, new { @class = "btn1" })%>                                                  
                      
                         
                
            </td>
        </tr>
     </table>
     <%} %>--%>
            <%-- end of if loop--%>
            <%}
            %>
        </table>
        <%--new code--%>
        <% if (Model.BookedTicketList != null && Model.BookedTicketList.Count() > 0)
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
      <% } %>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CssContent" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
    <script src="../../../../Scripts/ATL.function.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript">

        $(document).ready(function () {
            //            $("#AgentId").change(function () {
            //                if ($("#AgentId").val() == 0) {
            //                    return false;

            //                }
            //                var url = "/AjaxRequest/GetProductByAgent";

            //                $.getJSON(url, { AgentId: $("#AgentId").val() }, function (data) {

            //                    $('#ProductId').removeAttr('disabled');
            //                    $("#ProductId").empty();
            //                    $("#ProductId").append("<option value='" + 0 + "'>" + 'Select' + "</option>");
            //                    $.each(data, function (index, optionData) {
            //                        $("#ProductId").append("<option value='" + optionData.Value + "'>" + optionData.Text + "</option>");
            //                    });
            //                });
            //            }).change();
            /////////////////End of loading product according to Agents///////////////////////////////////
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
