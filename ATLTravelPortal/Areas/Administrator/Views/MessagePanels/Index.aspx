<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/AdministratorMain.Master"
    Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Administrator.Models.MessagePanelsModel>" %>

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
                        <%:Html.ActionLink("New", "Create", new { controller = "MessagePanels" }, new { @class = "linkButton" })%>
                    </li>
                </ul>
            </div>
            <h3>
                <a href="#">System Setup</a> <span>&nbsp;</span><strong>Message Panel</strong>
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
                    Message
                </th>
                <th>
                    Panel Name
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

               foreach (var item in Model.MessagePanelList)
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
                    <%--  <td>
                        <%= System.Web.HttpUtility.HtmlDecode(item.MessageText)%>
                    </td>--%>
                    <td>
                        <% string messagetext = StringExtensionMethods.StripTagsRegexCompiled(item.MessageText); %>
                        <%=((messagetext.Trim().Count()> 100 ? messagetext.Trim().Substring(0, 100) : messagetext.Trim())) %>...............
                    </td>
                    <%
                   if (item.PanNoId == 1)
                   { %>
                    <td>
                        Advance Search Panel
                    </td>
                    <%} %>
                    <%else if (item.PanNoId == 2)
                        { %>
                    <td>
                        Basic Search Panel
                    </td>
                    <%} %>
                    <% else if (item.PanNoId == 3)
                        { %>
                    <td>
                        Indian LCC Panel
                    </td>
                    <%} %>
                    <td>
                        <a href="/Administrator/MessagePanels/Detail/<%:item.MessagePanelId %>" class="details"
                            title="Details"></a><a href="/Administrator/MessagePanels/Edit/<%:item.MessagePanelId %>"
                                class="edit" title="Edit"></a><a href="/Administrator/MessagePanels/Delete/<%:item.MessagePanelId %>"
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
