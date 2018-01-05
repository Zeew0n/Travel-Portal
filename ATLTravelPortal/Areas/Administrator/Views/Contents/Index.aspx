<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/AdministratorMain.Master" Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Administrator.Models.ContentsModel>" %>
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
                        <%:Html.ActionLink("New", "Create", new { controller = "Contents" }, new { @class = "linkButton" })%>
                    </li>
                </ul>
            </div>
            <h3>
                <a href="#" class="icon_plane">CMS</a> <span>&nbsp;</span><strong>Page</strong>
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
                    Url
                </th>
                <th>Is Publish</th>
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

               foreach (var item in Model.ListContents)
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
                        <%:item.Title%>
                    </td>
                    <td>
                        <%: item.URL %>
                    </td>
                    <td>
                        <% if (item.isPublish == true)
                           { %> Published<%}
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
                        <a href="/Administrator/Contents/Edit/<%:item.ContentId %>" class="edit" title="Edit"></a>
                        <a href="/Administrator/Contents/Preview/<%:item.ContentId %>" class="details"
                            title="Preview" target="_blank"></a>
                            <a href="/Administrator/Contents/Delete/<%:item.ContentId %>"
                                class="delete" title="Delete" onclick="return confirm('Are you sure you want to delete?')">
                            </a>
                    </td>
                </tr>
            </tbody>
            <%}
                } %>
        </table>
       <div class="Adminpager">
       <%= Html.Pager(ViewData.Model.ListContents.PageSize, ViewData.Model.ListContents.PageNumber, ViewData.Model.ListContents.TotalItemCount)%>
       </div>
    </div>
</asp:Content>
