<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/AdministratorMain.Master"
    Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Administrator.Models.DashboardContentsModel>" %>

<%@ Import Namespace="ATLTravelPortal.Helpers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Index
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <div class="pageTitle">
            <div class="float-right">
                <ul>
                    <li>
                        <%:Html.ActionLink("New", "Create", new { controller = "DashboardContents" }, new { @class = "linkButton" })%>
                    </li>
                </ul>
            </div>
            <h3>
                <a href="#" class="icon_plane">CMS</a> <span>&nbsp;</span><strong>Dashboard Content (B2B)</strong>
            </h3>
        </div>
    </div>
    <div class="contentGrid">
        <table cellspacing="0" cellpadding="0" border="0" style="border-collapse: collapse;"
            class="GridView" width="100%">
            <thead>
            <tr>
                <th>
                    SN
                </th>
                <th>
                    Title
                </th>
                <th>
                  Is Published
                </th>
                <th>
                    Created By
                </th>
                <th>
                    Created Date
                </th>
                <th>
                    Action
                </th>
                </tr>
            </thead>
            <%
                if (Model != null)
                {
            %>
            <% var sno = 0;

               foreach (var item in Model.ListDashboardContents)
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
                        <%: item.Title %>
                    </td>
                    <td>
                        <% if (item.IsPublished)
                           { %> Published <%}
                           else
                           { %> Not-Published<%} %>
                    </td>
                    <td>
                        <%: item.CreatedName %>
                    </td>
                    <td>
                        <%: TimeFormat.DateFormat( item.CreatedDate.ToString()) %>
                    </td>
                    <td>
                        <a href="/Administrator/DashboardContents/Edit/<%:item.DasbBoardContentId %>" class="edit"
                            title="Edit"></a>
                            <a href="/Administrator/DashboardContents/Detail/<%:item.DasbBoardContentId %>"
                                class="details" title="Detail" target="_blank"></a>
                                <a href="/Administrator/DashboardContents/Delete/<%:item.DasbBoardContentId %>"
                                    class="delete" title="Delete" onclick="return confirm('Are you sure you want to delete?')">
                                </a>
                    </td>
                </tr>
            </tbody>
            <%}
                } %>
        </table>
    </div>
</asp:Content>
