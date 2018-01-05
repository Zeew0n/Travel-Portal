<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/AdministratorMain.Master"
    Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Administrator.Models.AgentCallLogModel>" %>

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
                        <%:Html.ActionLink("New", "Create", new { controller = "AgentCallLog" }, new { @class = "linkButton" })%>
                    </li>
                </ul>
            </div>
             <h3>
                <a href="#" class="icon_plane">Agent Management</a> <span>&nbsp;</span><strong>Call Logs</strong>
            </h3>
        </div>
    </div>
    <div class="contentGrid">
        <% if (Model != null)
           { %>
        <%if (Model.AgentFollowUpCallLogList != null && Model.AgentFollowUpCallLogList.Count() > 0)
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
                        For
                    </th>
                    <th>
                        Agent
                    </th>
                    <th>
                        Purpose
                    </th>
                    <th>
                        Action
                    </th>
                </tr>
            </thead>
            <tbody>
                <%  var sno = 0;

                    foreach (var item in Model.AgentFollowUpCallLogList)
                    {
                        sno++;
                        var classTblRow = (sno % 2 == 0) ? "GridAlter" : "GridItem";
                %>
                <tr class="<%:classTblRow %>" onmouseout="this.className='GridAlter'" onmouseover="this.className='GridRowOver'">
                    <td>
                        <%:item.SNO%>
                    </td>
                    <td>
                        <%:  item.LoggedDate.ToString("dd-MMM-yy hh:mm")%>
                    </td>
                    <td>
                        <%: item.LoggedByName %>
                    </td>
                    <td>
                        <%: item.CategoryName.Trim() + " ("+ item.SubCategoryName.Trim()+")" %>
                    </td>
                    <td>
                        <%: item.AgentName %>
                    </td>
                    <td>
                        <%: item.Purpose %>
                    </td>
                    <td>
                        <a href="/Administrator/AgentCallLog/Detail/<%:item.PhoneCallLogId %>" class="details"
                            title="Details"></a><a href="/Administrator/AgentCallLog/Edit/<%:item.PhoneCallLogId %>"
                                class="edit" title="Edit"></a><a href="/Administrator/AgentCallLog/Delete/<%:item.PhoneCallLogId %>"
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
       <%= Html.Pager(ViewData.Model.AgentFollowUpCallLogList.PageSize, ViewData.Model.AgentFollowUpCallLogList.PageNumber, ViewData.Model.AgentFollowUpCallLogList.TotalItemCount, new { FromDate = TimeFormat.DateFormat(Model.FromDate.ToString()), ToDate = TimeFormat.DateFormat(Model.ToDate.ToString()) })%>
       </div>
        <%} %>
    </div>

    <br />
    <br />



     <% using (Html.BeginForm("Index", "AgentCallLog", FormMethod.Post, new { @class = "validate", @autocomplete = "off" }))
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
        <%if (Model.AgentCallLogList != null && Model.AgentCallLogList.Count() > 0)
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
                        For
                    </th>
                    <th>
                        Agent
                    </th>
                    <th>
                        Purpose
                    </th>
                    <th>
                        Action
                    </th>
                </tr>
            </thead>
            <tbody>
                <%  var sno = 0;

                    foreach (var item in Model.AgentCallLogList)
                    {
                        sno++;
                        var classTblRow = (sno % 2 == 0) ? "GridAlter" : "GridItem";
                %>
                <tr class="<%:classTblRow %>" onmouseout="this.className='GridAlter'" onmouseover="this.className='GridRowOver'">
                    <td>
                        <%:sno%>
                    </td>
                    <td>
                        <%:  item.LoggedDate.ToString("dd-MMM-yy hh:mm")%>
                    </td>
                    <td>
                        <%: item.LoggedByName%>
                    </td>
                    <td>
                        <%: item.CategoryName.Trim() + " ("+ item.SubCategoryName.Trim()+")" %>
                    </td>
                    <td>
                        <%: item.AgentName%>
                    </td>
                    <td>
                        <%: item.Purpose%>
                    </td>
                    <td>
                        <a href="/Administrator/AgentCallLog/Detail/<%:item.PhoneCallLogId %>" class="details"
                            title="Details"></a><a href="/Administrator/AgentCallLog/Edit/<%:item.PhoneCallLogId %>"
                                class="edit" title="Edit"></a><a href="/Administrator/AgentCallLog/Delete/<%:item.PhoneCallLogId %>"
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
