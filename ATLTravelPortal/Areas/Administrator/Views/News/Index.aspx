<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/AdministratorMain.Master" 
Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Administrator.Models.NewsModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">News List</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
 <%
        if (TempData["success"] != null){ %>
    <%: TempData["success"]%>
    <% }%>
    
        <div class="ledger_subtable create_tbl" style="margin: 1px 0">
        <div class="pageTitle">
            <ul class="buttons-panel">
                <li>
                    <div id="loadingIndicator">
                    </div>
                </li>
                <li><a href="/Administrator/News/Add" class="new linkButton" title="New">New</a>
                </li>
                <li></li>
            </ul>
            <h3>
                <a href="#" class="icon_plane">News</a> <span>&nbsp;</span><strong>News</strong>
            </h3>
        </div>
    </div>
    <div class="contentGrid">
     <table cellspacing="0" cellpadding="0" border="0" style="border-collapse: collapse;" class="GridView" width="100%">
 <thead>
        <tr>
            <th>Title</th>
            <th>Summary</th>
            <th>IsPublish</th>    
            <th>Action</th>           
        </tr>
</thead>
    <% if (Model != null)
    { %>

        <% if (Model.TablularRecordList != null && Model.TablularRecordList.Count() > 0)
        { %>  
           
    <% var sno = 0;
        foreach (var item in Model.TablularRecordExportList)
        {

            sno++;
            var classTblRow = (sno % 2 == 0) ? "GridAlter" : "GridItem";
            %>
        <tr>                 
            <td><%: item.Title %></td>
            <td><%: item.Summary %></td>    
             <td><%: item.Summary %></td>            
            <td>
            <a href="/Administrator/News/Edit/<%:item.PId %>" class="edit" title="Edit"></a>
           <%-- <a href="/Administrator/News/Detail/<%:item.PId %>" class="details" title="Detail"></a>--%>
            <a href="/Administrator/News/Delete/<%:item.PId %>" class="delete" title="Delete" onclick="return confirm('Are you sure you want to delete?')">
            </a>
            </td>
        </tr>    
          <%}

              }
           } %>


    </table>
        <%           
            if (Model.TablularRecordList != null && Model.TablularRecordList.Count() > 0)
            { 
         %>   
         <div class="paging">
         <%=MvcHtmlString.Create(Html.Pager(ATLTravelPortal.App_Class.AppGeneral.DefaultPageSize, Model.TablularRecordList.PageNumber, Model.TablularRecordList.TotalItemCount))%>
         </div>
        <% }
           else
           {
               Html.RenderPartial("NoRecordsFound");
           } 
        %>
      


    </div>
   <%-- <div class="buttonBar">
        <a href="/Administrator/News/Add" class="new linkButton" title="New">New News</a>
    </div> --%>
</asp:Content>

