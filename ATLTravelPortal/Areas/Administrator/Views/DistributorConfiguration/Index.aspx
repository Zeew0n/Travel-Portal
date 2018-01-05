<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/DistributorMain.Master"
    Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Administrator.Models.DistributorConfigurationModel>" %>

<%@ Import Namespace="ATLTravelPortal.Helpers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Index
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <%Html.RenderPartial("Utility/VUC_MessagePanel"); %>
    <div>
        <div class="pageTitle">
            <div class="float-right">
                <ul>
                    <li>
                        <%:Html.ActionLink("New", "Create", new { controller = "DistributorConfiguration" }, new { @class = "linkButton" })%>
                    </li>
                </ul>
            </div>
            <h3>
                <a href="#" class="icon_plane">System Setup</a> <span>&nbsp;</span><strong>Configuration</strong>
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

               foreach (var item in Model.DistributorConfigurationList)
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
                        <%:item.IsPublished?"Published":"Unpublished" %>
                    </td>
                    <td>
                        <%: item.CreatedName %>
                    </td>
                    <td>
                        <%: TimeFormat.DateFormat( item.CreatedDate.ToString()) %>
                    </td>
                    <td>
                        <a href="/Administrator/DistributorConfiguration/Edit/<%:item.LayoutSettingId %>"
                            class="edit" title="Edit"></a><a href="/Administrator/DistributorConfiguration/Delete/<%:item.LayoutSettingId %>"
                                class="delete" title="Delete" onclick="return confirm('Are you sure you want to delete?')">
                            </a>
                    </td>
                </tr>
            </tbody>
            <%}
                } %>
        </table>
       
    </div>
      <div class="Adminpager">
       <%= Html.Pager(ViewData.Model.DistributorConfigurationList.PageSize, ViewData.Model.DistributorConfigurationList.PageNumber, ViewData.Model.DistributorConfigurationList.TotalItemCount)%>
       </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CssContent" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
</asp:Content>
