<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/AdministratorMain.Master"
    Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Administrator.Models.SalesReportModel>" %>

<%@ Import Namespace="ATLTravelPortal.Helpers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Index
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
    <div>
        <div class="pageTitle">
            <h3>
                <a href="#" class="icon_plane">Reports</a> <span>&nbsp;</span><strong>Sales Reports</strong>
            </h3>
        </div>
    </div>
    <% Html.RenderPartial("~/Views/Shared/ExportData.ascx");%>
    <div class="row-1">
        <div class="form-box1 round-corner">
            <div class="form-box1-row" id="DateFilter">
                <div class="form-box1-row-content float-left">
                    <div>
                        <label>
                            From Date</label>
                        <%: Html.TextBox("FromDate", (Model != null && Model.FromDate != null && Model.FromDate != DateTime.MinValue) ?
                                                        (TimeFormat.DateFormat(Model.FromDate.ToString())) :
                            (TimeFormat.DateFormat(TimeFormat.DateFormat(DateTime.Today.ToString()))))%>
                        <%: Html.ValidationMessageFor(model => model.FromDate, "*")%>
                    </div>
                </div>
                <div class="form-box1-row-content float-right">
                    <div>
                        <label>
                            To Date</label>
                        <%: Html.TextBox("ToDate", (Model != null && Model.ToDate != null && Model.ToDate != DateTime.MinValue) ?
                                                        (TimeFormat.DateFormat(Model.ToDate.ToString())) :
                            (TimeFormat.DateFormat(TimeFormat.DateFormat(DateTime.Today.ToString()))))%>
                        <%: Html.ValidationMessageFor(model => model.ToDate, "*")%>
                    </div>
                </div>
            </div>
        </div>
        <div class="form-box1-row" id="Div2">
            <div class="form-box1-row-content float-left">
                <div>
                    <label>
                        Report Of</label>
                    <%: Html.DropDownListFor(model=>model.ReportOf, Model.ReportsOfOption,"--Select--")%></div>
                <%: Html.ValidationMessageFor(model=>model.ReportOf) %>
            </div>
            <div class="form-box1-row-content float-right">
                <div>
                    <label>
                        Currency</label>
                    <%:Html.DropDownListFor(model=>model.CurrencyId,Model.CurrencyOption) %></div>
                <%: Html.ValidationMessageFor(model=>model.CurrencyId) %>
            </div>
        </div>
    </div>
    <div class="form-box1-row">
        <p class="mrg-lft-130">
            <input type="submit" value="Search" class="btn3" />
        </p>
    </div>
    <% } %>
    <div class="contentGrid">
        <% if (Model != null)
           { %>
        <%if (Model.InformationList != null && Model.InformationList.Count() > 0)
          { %>
        <table cellspacing="0" cellpadding="0" border="0" style="border-collapse: collapse;"
            class="GridView" width="100%">
            <thead>
                <tr>
                    <th>
                        SN
                    </th>
                    <th>
                        Name
                    </th>
                    <th>
                        Airline
                    </th>
                    <th>
                        Hotel
                    </th>
                    <th>
                        Mobile
                    </th>
                    <th>
                        Bus
                    </th>
                    <th>
                        Train
                    </th>
                    <th>
                        Total
                    </th>
                </tr>
            </thead>
            <%var sno = 0;
              foreach (var item in Model.InformationList)
              {
                  sno++;
                  var classTblRow = (sno % 2 == 0) ? "GridAlter" : "GridItem";
            %>
            <tr class="<%=classTblRow %>">
                <td>
                    <%:sno%>.
                </td>
                <td>
                 <%: item.Name%>
                </td>
                <td>
                    <%if (item.Airline == 0)
                      { %>
                    <%:item.Airline%>
                    <%} %>
                    <%else
            { %>
                    
                    <a href="/Administrator/SalesReports/Details/<%:item.Airline%>?currencyid=<%:item.CurrencyId %>&ledgerid=<%:item.LedgerId %>&fromdate=<%:item.FromDate%>&todate=<%:item.ToDate%>&reportof=<%:item.ReportOf%>&name=<%: item.Name%>&reportType=1"
                        class="Details" target="_blank">
                        <%:item.Airline%></a>
                    <%} %>
                </td>
                <td>
                <%if (item.Hotel == 0)
                  { %>
                    <%:item.Hotel%>
                    <%} %>
                    <%else
            { %>
                    
                    <a href="/Administrator/SalesReports/Details/<%:item.Hotel%>?currencyid=<%:item.CurrencyId %>&ledgerid=<%:item.LedgerId %>&fromdate=<%:item.FromDate%>&todate=<%:item.ToDate%>&reportof=<%:item.ReportOf%>&name=<%: item.Name%>&reportType=2"
                        class="Details" target="_blank">
                        <%:item.Hotel%></a>
                    <%} %>
                   
                </td>
                <td>
                <%if (item.Mobile == 0)
                  { %>
                    <%:item.Mobile%>
                    <%} %>
                    <%else
            { %>
                    
                    <a href="/Administrator/SalesReports/Details/<%:item.Mobile%>?currencyid=<%:item.CurrencyId %>&ledgerid=<%:item.LedgerId %>&fromdate=<%:item.FromDate%>&todate=<%:item.ToDate%>&reportof=<%:item.ReportOf%>&name=<%: item.Name%>&reportType=3"
                        class="Details" target="_blank">
                        <%:item.Mobile%></a>
                    <%} %>
                    
                </td>
                <td> <%if (item.Bus == 0)
                       { %>
                    <%:item.Bus%>
                    <%} %>
                    <%else
            { %>
                    
                    <a href="/Administrator/SalesReports/Details/<%:item.Bus%>?currencyid=<%:item.CurrencyId %>&ledgerid=<%:item.LedgerId %>&fromdate=<%:item.FromDate%>&todate=<%:item.ToDate%>&reportof=<%:item.ReportOf%>&name=<%: item.Name%>&reportType=4"
                        class="Details" target="_blank">
                        <%:item.Bus%></a>
                    <%} %>

                    
                </td>
                <td>
                 <%if (item.Train == 0)
                   { %>
                    <%:item.Train%>
                    <%} %>
                    <%else
            { %>
                    
                    <a href="/Administrator/SalesReports/Details/<%:item.Train%>?currencyid=<%:item.CurrencyId %>&ledgerid=<%:item.LedgerId %>&fromdate=<%:item.FromDate%>&todate=<%:item.ToDate%>&reportof=<%:item.ReportOf%>&name=<%: item.Name%>&reportType=5"
                        class="Details" target="_blank">
                        <%:item.Train%></a>
                    <%} %>
                    
                </td>
                <td>
                    <%: item.Total%>
                </td>
            </tr>
            <% }%>
         
        
         
          
        </table>
        <%} %>
            <% 
            else
            {
                Html.RenderPartial("NoRecordsFound");
            } 
        %>
      <%} %> 
    </div>
   
       
    
   
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
    <script src="../../../../Scripts/ATL.function.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript">

        $(document).ready(function () {
            $(function () {
                var dates = $("#FromDate, #ToDate").datepicker({
                    defaultDate: "+1d",
                    changeMonth: true,
                    changeYear: true,
                    constrainInput: true,
                    numberOfMonths: 2,
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
        });

    </script>
</asp:Content>
