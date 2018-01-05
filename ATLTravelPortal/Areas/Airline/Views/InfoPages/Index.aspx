<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/AirlineMain.Master"
 Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Airline.Models.InfoPagesModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div class="ledger_subtable create_tbl" style="margin: 1px 0">
        <div class="pageTitle">
            <ul class="buttons-panel">
                <li>
                    <div id="loadingIndicator">
                    </div>
                </li>
                <li><a href="/Airline/InfoPages/Create/" class="new linkButton" title="New">New</a>
                </li>
                <li></li>
            </ul>
            <h3>
                <a href="#" class="icon_plane">Settings</a> <span>&nbsp;</span><strong>Info Pages</strong>
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
                Name
            </th>
            <th>
                Title
            </th>
            <th>
                Action
            </th>
        </thead>
        <% var sno = 0;

           foreach (var item in Model.InfoPagesList)
           {
               sno++;
               var classTblRow = (sno % 2 == 0) ? "GridAlter" : "GridItem";
        %>
        <tbody>
            <tr id="tr_<%=sno %>" class="<%: classTblRow %>" onmouseover="this.className='GridRowOver'"
                onmouseout="this.className='<%= classTblRow %>'">
                <td>
                <%:item.SNO %>
                </td>
                <td>
                    <%:item.Name %>
                </td>
                <td>
                    <%: item.Title%>
                </td>
                <td>
                    <p>
                        <a href="/Airline/InfoPages/Details/<%:item.InfoId %>" class="details" title="Detail"></a>
                        <a href="/Airline/InfoPages/Edit/<%: item.InfoId %>" class="edit" title="Edit"></a>
                        <a href="/Airline/InfoPages/Delete/<%: item.InfoId %>"
                            class="delete" title="Delete" onclick="return confirm('Are you sure you want to delete?')">
                        </a>
                    </p>
                </td>
            </tr>
        </tbody>
        <%}
        %>
    </table>
     <div class="Adminpager">
       <%= Html.Pager(ViewData.Model.InfoPagesList.PageSize, ViewData.Model.InfoPagesList.PageNumber, ViewData.Model.InfoPagesList.TotalItemCount)%>
       </div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="CssContent" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
</asp:Content>
