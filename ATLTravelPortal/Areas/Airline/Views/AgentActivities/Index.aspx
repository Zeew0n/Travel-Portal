<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/AirlineMain.Master"
    Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Airline.Models.AgentActivitiesModel>" %>

<%@ Import Namespace="ATLTravelPortal.Helpers" %>
    <%@ Import Namespace="ATLTravelPortal.Helpers.Pagination"%>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Agent Activities Report
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
                <a href="#" class="icon_plane">Reports</a> <span>&nbsp;</span><strong>Agent Activities</strong>
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
                        <%: Html.TextBoxFor(model => model.FromDate)%>
                    </div>
                </div>
                <div class="form-box1-row-content float-right">
                    <div>
                        <label>
                            <%: Html.LabelFor(model => model.ToDate)%></label>
                        <%: Html.TextBoxFor(model => model.ToDate)%>
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
                        <%:Html.DropDownListFor(model => model.AgentId, (SelectList)ViewData["AgentList"], "----Select----")%>
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
        <%if (Model.AgentActivitesList != null && Model.AgentActivitesList.Count() > 0)
          { %>
        <table cellspacing="0" cellpadding="0" border="0" style="border-collapse: collapse;"
            class="GridView tablesorter" width="100%">
            <thead>
                <tr>
                    <th>
                        SNo
                    </th>
                    <th>
                        Agent Name
                    </th>
                    <th>
                        Booked
                    </th>
                    <th>
                        Cancelled
                    </th>
                    <th>
                        Issued
                    </th>
                    <th>
                        Void
                    </th>
                    <th>
                    GDS Hits
                    </th>
                    <th>
                        Total Login
                    </th>
                    <th>
                        Last Login
                    </th>
                </tr>
            </thead>
            <tbody>
                <%  var sno = 0;
                    int count = Model.AgentActivitesList.Count();
                    if (count > 0)
                    {
                        Model.SumBooked = Model.AgentActivitesList.ElementAt(count - 1).SumBooked;
                        Model.SumCancelled = Model.AgentActivitesList.ElementAt(count - 1).SumCancelled;
                        Model.SumIssued = Model.AgentActivitesList.ElementAt(count - 1).SumIssued;
                        Model.SumVoid = Model.AgentActivitesList.ElementAt(count - 1).SumVoid;
                        Model.SumTotalLogin = Model.AgentActivitesList.ElementAt(count - 1).SumTotalLogin;
                        Model.SumTotalGDSHits = Model.AgentActivitesList.ElementAt(count - 1).SumTotalGDSHits;
                    }

                    foreach (var item in Model.AgentActivitesList)
                    {
                        sno++;
                        var classTblRow = (sno % 2 == 0) ? "GridAlter" : "GridItem";
                %>
                <tr class="<%:classTblRow %>" onmouseout="this.className='GridAlter'" onmouseover="this.className='GridRowOver'">
                    <td>
                        <%:sno%>
                    </td>
                    <td>
                        <%: item.AgentName %>
                    </td>
                    <td>
                        <%: item.Booked %>
                    </td>
                    <td>
                        <%: item.Cancelled %>
                    </td>
                    <td>
                        <%: item.Issued %>
                    </td>
                    <td>
                        <%: item.Void %>
                    </td>
                    <td>
                    <%: item.GDSHits %>
                    </td>
                    <td>
                        <%: item.TotalLogin %>
                    </td>
                    <td>
                        <%: item.LastLogin %>
                    </td>
                </tr>
                <% } %>
                <%}
                %>
            </tbody>
            <tfoot>
                <tr>
                    <td>
                    </td>
                    <td>
                    </td>
                    <td>
                        <b>Total Booked: &nbsp;
                            <%:Model.SumBooked == null ? "" : (Model.SumBooked).ToString()%>
                        </b>
                    </td>
                    <td>
                        <b>Total Cancelled: &nbsp;
                            <%:Model.SumCancelled == null ? "" : (Model.SumCancelled).ToString()%>
                        </b>
                    </td>
                    <td>
                        <b>Total Issued: &nbsp;
                            <%:Model.SumIssued == null ? "" : (Model.SumIssued).ToString()%>
                        </b>
                    </td>
                    <td>
                        <b>Total Void: &nbsp;
                            <%:Model.SumVoid == null ? "" : (Model.SumVoid).ToString()%>
                        </b>
                    </td>
                    <td>
                    <b>
                    Total GDS Hits: &nbsp;
                    <%:Model.SumTotalGDSHits == null ? "" : (Model.SumTotalGDSHits).ToString() %>
                    </b>
                    </td>
                    <td>
                        <b>Total Login: &nbsp;
                            <%:Model.SumTotalLogin == null ? "" : (Model.SumTotalLogin).ToString()%>
                        </b>
                    </td>
                </tr>
            </tfoot>
        </table>
        <%} %>
        <%-- <div id="pager" style="position: none;">
            <form>
            <img src="../../../../Content/images/first.png" class="first" />
            <img src="../../../../Content/images/prev.png" class="prev" />
            <input type="text" class="pagedisplay" />
            <img src="../../../../Content/images/next.png" class="next" />
            <img src="../../../../Content/images/last.png" class="last" />
            <select class="pagesize">
                <option selected="selected" value="5">5</option>
                <option value="10">10</option>
                <option value="20">20</option>
                <option value="30">30</option>
                <option value="40">40</option>
            </select>
            </form>
        </div>--%>
    </div>

       <div class="pager">
    <%= Html.Pager(ViewData.Model.AgentActivitesList.PageSize, ViewData.Model.AgentActivitesList.PageNumber, ViewData.Model.AgentActivitesList.TotalItemCount)%>
   </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CssContent" runat="server">
    <style type="text/css">
        table.tablesorter thead tr .header
        {
            background-image: url(../../../../Content/images/bg.png);
            background-repeat: no-repeat;
            background-position: center right;
            cursor: pointer;
            height: 20px;
            line-height: 20px;
            padding: 0 0 0 4px;
            text-align: left;
            font-weight: bold;
        }
        
        table.tablesorter thead tr .headerSortUp
        {
            background-image: url(../../../../Content/images/asc.png);
        }
        table.tablesorter thead tr .headerSortDown
        {
            background-image: url(../../../../Content/images/desc.png);
        }
        
        table thead th:hover
        {
            background-color: Yellow;
            color: Black;
        }
    </style>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
    <script src="../../../../Scripts/ATL.function.js" type="text/javascript"></script>
    <script src="../../../../Scripts/jquery.tablesorter.js" type="text/javascript"></script>
    <script src="../../../../Scripts/jquery.tablesorter.pager.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            $("table.tablesorter").tablesorter({ widthFixed: true, sortList: [[0, 0]] });
            //            .tablesorterPager({ container: $("#pager"), size: $(".pagesize option:selected").val() });
        });
    </script>
    <script language="javascript" type="text/javascript">

        $(document).ready(function () {

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

    </script>
</asp:Content>
