<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/AirlineMain.Master" Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Airline.Models.OfflineIssueSourceModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Manage Offline Booking Source
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div class="ledger_subtable create_tbl" style="margin: 1px 0">
        <div class="pageTitle">
            <ul class="buttons-panel">
                <li>
                    <div id="loadingIndicator">
                    </div>
                </li>
                <li><a href="/Airline/OfflineIssueSource/Create" class="new linkButton" title="New">New </a>
                </li>
                <li></li>
            </ul>
            <h3>
                <a href="#" class="icon_plane">Indian LCC</a> <span>&nbsp;</span><strong>Manage Offline Issue Source</strong>
            </h3>
        </div>
    </div>
    <table cellspacing="0" cellpadding="0" border="0" style="border-collapse: collapse;"
        class="GridView" width="100%">
        <thead>
            <th>
                S.No.
            </th>
            <th>
                Title
            </th>
            <th>
                Action
            </th>
        </thead>
        <% var sno = 0;

           foreach (var item in Model.SourceList)
           {
               sno++;
               var classTblRow = (sno % 2 == 0) ? "GridAlter" : "GridItem";
        %>
        <tbody>
            <tr id="tr_<%=sno %>" class="<%: classTblRow %>" onmouseover="this.className='GridRowOver'"
                onmouseout="this.className='<%= classTblRow %>'">
                <td>
                    <%:sno%>
                </td>
                <td>
                    <%: item.ServiceProvider%>
                </td>
                <td>
                    <p>
                        <a href="OfflineIssueSource/Edit/<%: item.OfflineBookingServiceProviderId %>" class="edit" title="Edit"></a><a
                            href="/Airline/OfflineIssueSource/Delete/<%: item.OfflineBookingServiceProviderId %>" class="delete" title="Delete"
                            onclick="return confirm('Are you sure you want to delete?')"></a>
                    </p>
                </td>
            </tr>
        </tbody>
        <%}
        %>
    </table>
      <div class="Adminpager">
       <%= Html.Pager(ViewData.Model.SourceList.PageSize, ViewData.Model.SourceList.PageNumber, ViewData.Model.SourceList.TotalItemCount)%>
       </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CssContent" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
</asp:Content>
