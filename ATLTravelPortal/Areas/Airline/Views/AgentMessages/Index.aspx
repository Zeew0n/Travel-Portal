<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/AirlineMain.Master" Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Airline.Models.AgentMessagesModel>" %>

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
                        <%:Html.ActionLink("Create New", "Create", new { controller = "AgentMessages" }, new { @class = "linkButton" })%>
                    </li>
                </ul>
            </div>
            <h3>
                <a class="icon_plane" href="#"></a><span>&nbsp;</span><strong>Agent Message</strong>
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
                    Agent
                </th>
                <th>
                    Product
                </th>
                <th>Message</th>
               
                <th>
                    Action
                </th>
            </thead>
            <%
                if (Model != null)
                {
            %>
            <% var sno = 0;

               foreach (var item in Model.AgentMessageList)
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
                        <%:item.AgentName%>
                    </td>
                    <td>
                        <%:item.ProductName%>
                    </td>
                    <td>
                        <%:item.MessageText%>
                    </td>
                    
                    <td>
                        <a href="/Airline/AgentMessages/Detail/<%:item.AgentMessageId %>" class="details"
                            title="Details"></a><a href="/Airline/AgentMessages/Edit/<%:item.AgentMessageId %>"
                                class="edit" title="Edit"></a><a href="/Airline/AgentMessages/Delete/<%:item.AgentMessageId %>"
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
