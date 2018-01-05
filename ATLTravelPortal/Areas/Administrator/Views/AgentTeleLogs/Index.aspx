<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/AdministratorMain.Master" Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Administrator.Models.AgentTeleLogsModel>" %>

<%@ Import Namespace="ATLTravelPortal.Helpers" %>
<%@ Import Namespace="ATLTravelPortal.Helpers.Pagination" %>
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
    <div>
        <div class="pageTitle">
            <div class="float-right">
                <ul>
                    <li>
                        <%:Html.ActionLink("New", "Create", new { controller = "AgentTeleLogs" }, new { @class = "linkButton" })%>
                    </li>
                </ul>
            </div>
             <h3>
                <a href="#" class="icon_plane">Agent Management</a> <span>&nbsp;</span><strong>Tele Logs</strong>
            </h3>
        </div>
    </div>
    <div class="contentGrid">
        <% if (Model != null)
           { %>
        <%if (Model.AgentTeleLogsFollowupList != null && Model.AgentTeleLogsFollowupList.Count() > 0)
          { %>
           <h2><b>Follow Up List</b></h2>
        <table cellspacing="0" cellpadding="0" border="0" style="border-collapse: collapse;"
            class="GridView" width="100%">
            <thead>
                <tr>
                    <th>
                        SNo
                    </th>
                    <th>
                    Date Time
                    </th>
                    <th>
                    Logged By
                    </th>
                    <th>
                       Agent Name
                    </th>
                    <th>Title</th>
                    <th>
                       Contact Person
                    </th>
                    <th>
                       Remarks
                    </th>
                   
                    <th>
                        Action
                    </th>
                </tr>
            </thead>
            <tbody>
                <%  var sno = 0;

                    foreach (var item in Model.AgentTeleLogsFollowupList)
                    {
                        sno++;
                        var classTblRow = (sno % 2 == 0) ? "GridAlter" : "GridItem";
                %>
                <tr class="<%:classTblRow %>" onmouseout="this.className='GridAlter'" onmouseover="this.className='GridRowOver'">
                    <td>
                        <%:item.SNO%>
                    </td>
                    <td>
                        <%:  item.CreatedDate.ToString("dd-MMM-yy hh:mm")%>
                    </td>
                    <td>
                        <%: item.CreatedName %>
                    </td>
                   <td><%: item.AgentName %></td>
                   <td><%:item.Title %></td>
                   <td><%: item.ContactPerson %></td>
                   <td><%: item.Remarks %></td>
                    <td>
                        <a href="/Administrator/AgentTeleLogs/Detail/<%:item.AgentTeleLogId %>" class="details"
                            title="Details"></a><a href="/Administrator/AgentTeleLogs/Edit/<%:item.AgentTeleLogId %>"
                                class="edit" title="Edit"></a><a href="/Administrator/AgentTeleLogs/Delete/<%:item.AgentTeleLogId %>"
                                    class="delete" title="Delete" onclick="return confirm('Are you sure you want to delete?')">
                                </a>
                    </td>
                </tr>
                <% } %>
                <%}
                %>
            </tbody>
        </table>
          <div class="Adminpager">
       <%= Html.Pager(ViewData.Model.AgentTeleLogsFollowupList.PageSize, ViewData.Model.AgentTeleLogsFollowupList.PageNumber, ViewData.Model.AgentTeleLogsFollowupList.TotalItemCount, new { FromDate = TimeFormat.DateFormat(Model.FromDate.ToString()), ToDate = TimeFormat.DateFormat(Model.ToDate.ToString()) })%>
       </div>
        <%} %>
    </div>

    <br />
    <br />



     <% using (Html.BeginForm("Index", "AgentTeleLogs", FormMethod.Post, new { @class = "validate", @autocomplete = "off" }))
       {%>
     <div class="contentGrid">

      <div class="reportFilter">

        <div class="reportLeftDiv">
            <div class="divLeft">
                <%: Html.LabelFor(model => model.FromDate)%>
                <%: Html.TextBox("FromDate", (Model != null && Model.FromDate != null && Model.FromDate != DateTime.MinValue) ?
                            (TimeFormat.DateFormat(Model.FromDate.ToString())) :
                            (TimeFormat.DateFormat(TimeFormat.DateFormat(DateTime.Now.AddDays(-15).ToString()))))%>
                <%: Html.ValidationMessageFor(model => model.FromDate, "*")%>
            </div>
            <div class="divRight">
                <%: Html.LabelFor(model => model.ToDate)%>
                <%: Html.TextBox("ToDate", (Model != null && Model.ToDate != null && Model.ToDate != DateTime.MinValue) ?
                            (TimeFormat.DateFormat(Model.ToDate.ToString())) :
                            (TimeFormat.DateFormat(TimeFormat.DateFormat(DateTime.Today.ToString()))))%>
                <%: Html.ValidationMessageFor(model => model.ToDate, "*")%>
            </div>
        </div>

         <input class="float-right" type="submit" value="Search" />
       
    </div>


        <% if (Model != null)
           { %>
        <%if (Model.AgentTeleLogsList != null && Model.AgentTeleLogsList.Count() > 0)
          { %>
           <h2><b>Normal List</b></h2>
        <table cellspacing="0" cellpadding="0" border="0" style="border-collapse: collapse;"
            class="GridView" width="100%">
            <thead>
               <tr>
                    <th>
                        SNo
                    </th>
                      <th>
                    Date Time
                    </th>
                    <th>
                    Logged By
                    </th>
                    <th>
                       Agent Name
                    </th>
                    <th>Title</th>
                    <th>
                       Contact Person
                    </th>
                    <th>
                       Remarks
                    </th>
                   
                    <th>
                        Action
                    </th>
                </tr>
                </thead>
            <tbody>
                <%  var sno = 0;

                    foreach (var item in Model.AgentTeleLogsList)
                    {
                        sno++;
                        var classTblRow = (sno % 2 == 0) ? "GridAlter" : "GridItem";
                %>
               <tr class="<%:classTblRow %>" onmouseout="this.className='GridAlter'" onmouseover="this.className='GridRowOver'">
                    <td>
                        <%:sno%>
                    </td>
                      </td>
                    <td>
                        <%:  item.CreatedDate.ToString("dd-MMM-yy hh:mm")%>
                    </td>
                    <td>
                        <%: item.CreatedName %>
                    </td>
                   <td><%: item.AgentName %></td>
                   <td><%:item.Title %></td>
                   <td><%: item.ContactPerson %></td>
                   <td><%: item.Remarks %></td>
                    <td>
                        <a href="/Administrator/AgentTeleLogs/Detail/<%:item.AgentTeleLogId %>" class="details"
                            title="Details"></a><a href="/Administrator/AgentTeleLogs/Edit/<%:item.AgentTeleLogId %>"
                                class="edit" title="Edit"></a><a href="/Administrator/AgentTeleLogs/Delete/<%:item.AgentTeleLogId %>"
                                    class="delete" title="Delete" onclick="return confirm('Are you sure you want to delete?')">
                                </a>
                    </td>
                </tr>
                <% } %>
                <%}
                %>
            </tbody>
        </table>
        <%} %>
    </div>

    <%} %>



</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CssContent" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
 <script language="javascript" type="text/javascript">

     $(document).ready(function () {
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

     });

        </script>

</asp:Content>