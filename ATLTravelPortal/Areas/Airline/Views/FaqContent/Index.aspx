<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/AirlineMain.Master"
    Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Airline.Models.FAQContentModel>" %>

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
                <li><a href="FaqContent/Create" class="new linkButton" title="New">New</a>
                </li>
                <li></li>
            </ul>
            <h3>
                <a href="#" class="icon_plane">Settings</a> <span>&nbsp;</span><strong>FAQ Content</strong>
            </h3>
        </div>
    </div>
    <table cellspacing="0" cellpadding="0" border="0" style="border-collapse: collapse;"
        class="GridView" width="100%">
        <thead>
            <tr>
                <th>
                SNo.
                </th>
                <th>
                    Title
                </th>
                <th>
                    Question
                </th>
                <th>
                    Action
                </th>
            </tr>
        </thead>
        <% var sno = 0;

           foreach (var item in Model.FAQContentList)
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
                    <%:item.HeadingTitle %>
                </td>
                <td>
                    <%: item.Question%>
                </td>
                <td>
                    <p>
                        <a href="/Airline/FaqContent/Details/<%:item.FaqId %>" class="details" title="Detail"></a>
                        <a href="/Airline/FaqContent/Edit/<%: item.FaqId %>" class="edit" title="Edit"></a>
                        <a href="/Airline/FaqContent/Delete/<%: item.FaqId %>"
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
       <%= Html.Pager(ViewData.Model.FAQContentList.PageSize, ViewData.Model.FAQContentList.PageNumber, ViewData.Model.FAQContentList.TotalItemCount)%>
       </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CssContent" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
</asp:Content>
