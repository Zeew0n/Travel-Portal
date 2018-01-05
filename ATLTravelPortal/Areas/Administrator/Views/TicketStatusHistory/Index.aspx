<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/AdministratorMain.Master" Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Administrator.Models.TicketStatusHistoryModel>" %>

<%@ Import Namespace="ATLTravelPortal.Helpers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

   
      <% Html.EnableClientValidation();%>
    <% using (Html.BeginForm())
       {%>
    <div>
        <div class="pageTitle">
            <h3>
                <a href="#" class="icon_plane">Reports</a> <span>&nbsp;</span><strong>Ticket Status History</strong>
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
        </div><br />

         <div class="form-box1-row">
        <p class="mrg-lft-130">
            <input type="submit" value="Search" class="btn3" />
        </p>
    </div>
<%} %>
<div class="contentGrid">
        <% if (Model != null)
           { %>
        <%if (Model.TicketStatusHistoryList != null && Model.TicketStatusHistoryList.Count() > 0)
          { %>
        <table cellspacing="0" cellpadding="0" border="0" style="border-collapse: collapse;"
            class="GridView" width="100%">
            <thead>
                <tr>
                    <th>
                        SN
                    </th>
                   
                    <th>
                        Branch
                    </th>
                    <th>
                        Distributor
                    </th>
                    <th>
                        Agent
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
                    <th></th>
                </tr>
            </thead>
            <%var sno = 0;
              foreach (var item in Model.TicketStatusHistoryList)
              {
                  sno++;
                  var classTblRow = (sno % 2 == 0) ? "GridAlter" : "GridItem";
            %>
            <tr class="<%=classTblRow %>">
                <td>
                    <%:sno%>.
                </td>
               
                <td>
                    <%:item.Branch%>
                </td>
                <td>
                    <%:item.Distributor%>
                </td>
                <td>
                    <%:item.Agent%>
                </td>
                 <td>
                    <%:item.Airline%>
                 </td>
                 <td>
                    <%:item.Sector%>
                 </td>
                 <td>
                    <%:item.Status%>
                 </td>
                  <td>
                    <%:item.ServiceProviderName%>
                 </td>
                </tr>
                <%} %>
                </table>
                <%}%>
                 <% 
           else
           {
               Html.RenderPartial("NoRecordsFound");
           } 
        %>
         <%  } %>
           
       
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
