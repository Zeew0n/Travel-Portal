<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/DistributorMain.Master"
    Inherits="System.Web.Mvc.ViewPage<List<TravelPortalEntity.Agents>>" %>

<%@ Import Namespace="TravelPortalEntity" %>
<%@ Import Namespace="ATLTravelPortal.Helpers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Arihant Holidays:Agent Search List
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <% using (Html.BeginForm("AgentSearch", "DistributorAgentManagement", FormMethod.Post, new { @id = "ATForm", enctype = "multipart/form-data" }))
       {%>
    <%ATLTravelPortal.Areas.Administrator.Models.AgentModel model = new ATLTravelPortal.Areas.Administrator.Models.AgentModel(); %>
    <div>
        <label>
            <%: Html.Label("Agent Name/Agent Code") %>
            <%: Html.TextBoxFor(x=>model.AgentSearch)%>
            <input type="submit" value="Search" class="btn1" />
        </label>
    </div>
    <%} %>
    <div class="contentGrid">
        <table cellspacing="0" cellpadding="0" border="0" style="border-collapse: collapse;"
            class="GridView" width="100%">
            <thead>
                <th>
                    S.No.
                </th>
                <th>
                    Agency Name
                </th>
                <th>
                    Agency Code
                </th>
                <th>
                    Agency Email
                </th>
                <th>
                    Phone
                </th>
                <th>
                    Created On
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

               foreach (Agents item in Model)
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
                        <%: item.AgentName%>
                    </td>
                    <td>
                        <%: item.AgentCode %>
                    </td>
                    <td>
                        <%: item.Email%>
                    </td>
                    <td>
                        <%: item.Phone%>
                    </td>
                    <td>
                        <%: item.CreatedDate.ToString("dd MMM yyyy")%>
                    </td>
                    <td>
                        <p>
                            <a href="/Administrator/DistributorAgentManagement/Details/<%: item.AgentId %>" class="details"
                                title="Details"></a><a href="/Administrator/DistributorAgentManagement/Edit/<%: item.AgentId %>"
                                    class="edit" title="Edit"></a><a href="/Administrator/DistributorAgentManagement/Delete/<%:item.AgentId %>"
                                        class="delete" title="Delete" onclick="return confirm('Are you sure you want to delete?')">
                                    </a>
                                    <%--<a href="/Administrator/DistributorAgentUserManagement/Index/<%:item.AgentId %>" title="Agent User">
                                        Agent's User</a>--%>
                                         <a href="/Administrator/DistributorAgentSetting/Index/<%:item.AgentId %>" title="Agent User">
                                            Setting</a>
                        </p>
                    </td>
                </tr>
            </tbody>
            <%}
                } %>
        </table>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CssContent" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
</asp:Content>
