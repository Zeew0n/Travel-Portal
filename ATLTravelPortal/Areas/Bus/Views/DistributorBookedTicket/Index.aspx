<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/DistributorMain.Master"
    Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Bus.Models.BusPNRModel>" %>

<%@ Import Namespace="ATLTravelPortal.Helpers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Index
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <%Html.RenderPartial("~/Views/Shared/Utility/VUC_MessagePanel.ascx"); %>
    <% Html.EnableClientValidation(); %>
    <% using (Html.BeginForm())
       {%>
    <%: Html.ValidationSummary(true) %>
    <div>
        <div class="pageTitle">
            <h3>
                <a href="#" class="icon_plane">Bus Reports</a> <span>&nbsp;</span><strong>Booked Ticket</strong>
            </h3>
        </div>
    </div>
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
            <div class="buttonBar">
                <ul class="buttons-panel">
                    <li>
                        <input type="submit" value="Search" class="btn3" /></li>
                    <%if (Model.TabularList.Count > 0)
                      { %>
                    <li>
                        <% Html.RenderPartial("~/Views/Shared/ExportData.ascx"); %>
                    </li>
                    <%} %>
                </ul>
            </div>
        </div>
    </div>
    <div class="contentGrid">
        <% if (Model != null && Model.TabularList.Count > 0)
           { %>
        <table cellspacing="0" cellpadding="0" border="0" style="border-collapse: collapse;"
            class="GridView" width="100%">
            <thead>
                <tr>
                    <th>
                        SNo
                    </th>
                    <th>
                        Passenger Name
                    </th>
                    <th>
                        Operator Name
                    </th>
                    <th>
                        From - To
                    </th>
                    <th>
                        Departure Date
                    </th>
                    <th>
                        Departure Time
                    </th>
                    <th>
                        Issued Date
                    </th>
                    <th>
                        Category
                    </th>
                    <th>
                        Type
                    </th>
               
                </tr>
            </thead>
            <%  var sno = 0;
                foreach (var item in Model.TabularList)
                {
                    var classTblRow = (sno % 2 == 0) ? "GridAlter" : "GridItem";
            %>
            <tr>
                <td>
                    <%:item.Sno%>
                </td>
                <td>
                    <%:item.FullName %>
                </td>
                <td>
                    <%: item.BusMasterName%>
                </td>
                <td>
                    [<%:item.FromCityName%>-<%:item.ToCityName %>]
                </td>
                <td>
                    <%:TimeFormat.DateFormat( item.DepartureDate.ToString())%>
                </td>
                <td>
                    <%:TimeFormat.GetAMPMTimeFormat( item.DepartureTime.ToString())%>
                </td>
                <td>
                    <%:TimeFormat.DateFormat( item.IssuedDate.ToString()) %>
                </td>
                <td>
                    <%:item.BusCategoryName %>
                </td>
                <td>
                    <%:item.Type %>
                </td>
    
            </tr>
            <% } %>
        </table>
        <div class="pager">
            <%:MvcHtmlString.Create(ATLTravelPortal.Areas.Bus.Pagination.PagingExtensions.Pager(Html, ATLTravelPortal.Areas.Bus.Repository.BusGeneralRepository.DefaultPageSize, Model.TabularList.PageNumber, Model.TabularList.TotalItemCount, true, true, "", Url.Content("~/Bus/DistributorBookedTicket/Index")))%>
        </div>
        <%}
      
        %>
        <% } %>
        <% if (Model.TabularList.Count == 0)
           { %>
        <%Html.RenderPartial("NoRecordsFound"); %>
        <% }%>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CssContent" runat="server">
    <link type="text/css" href="<%=Url.Content("~/Content/css/hotelAdmin.css") %>" rel="Stylesheet" />
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
    <script src="../../../../Scripts/ATL.function.js" type="text/javascript"></script>
    <script type="text/javascript">
        function RedirectPath(url) {
            var rowPageValue = $('#recordDisplayCount').val();
            document.location.href = url + "&pageRow=" + rowPageValue;
        }


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
</asp:Content>
