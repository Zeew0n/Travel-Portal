<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/AdministratorMain.Master"
    Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Administrator.Models.AgentNewsScrollModel>" %>

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
                        <%:Html.ActionLink("New", "Create", new { controller = "AgentNewsScroll" }, new { @class = "linkButton" })%>
                    </li>
                </ul>
            </div>
          
            <h3>
             <a href="#">System Setup</a> <span>&nbsp;</span><strong>News Scroll</strong>
             </h3>
        </div>
    </div>
    <div class="contentGrid">
        <table cellspacing="0" cellpadding="0" border="0" style="border-collapse: collapse;"
            class="GridView" width="100%">
            <thead>
                <th>
                    SN
                </th>
                <th>
                    News Text
                </th>
                <th>
                    IsActive
                </th>
                <th>
                    Action
                </th>
            </thead>
            <%
                if (Model != null)
                {
            %>
            <% var sno = 0;

               foreach (var item in Model.NewsScrollList)
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
                        <%:item.NewsText%>
                    </td>
                    <td>
                        <%:item.IsActive%>
                    </td>
                    <td>
                        <a href="/Administrator/AgentNewsScroll/Detail/<%:item.ScrollNewsId %>" class="details"
                            title="Details"></a><a href="/Administrator/AgentNewsScroll/Edit/<%:item.ScrollNewsId %>"
                                class="edit" title="Edit"></a><a href="/Administrator/AgentNewsScroll/Delete/<%:item.ScrollNewsId %>"
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
