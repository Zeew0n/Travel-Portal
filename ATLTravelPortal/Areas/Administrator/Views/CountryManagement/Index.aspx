<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/AdministratorMain.Master" Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Administrator.Models.CountryManagementModel>" %>

<%@ Import Namespace="ATLTravelPortal.Helpers" %>
    <%@ Import Namespace="ATLTravelPortal.Helpers.Pagination"%>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Index
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <%
        if (TempData["success"] != null)
        { %>
    <%: TempData["success"]%>
    <%
    
        }
    %>

    <div>
        <div class="pageTitle">
            <div class="float-right">
                <ul>
                    <li>
                        <%:Html.ActionLink("New", "Create", new { controller = "CountryManagement" }, new { @class = "linkButton" })%>
                    </li>
                </ul>
            </div>
            <h3>
                <a href="#" class="icon_plane">System Setup</a> <span>&nbsp;</span><strong>Country Management</strong>
            </h3>
        </div>
    </div>

   

    <div class="contentGrid">
        <% if (Model != null)
           { %>
        <%if (Model.CountryManagementList != null && Model.CountryManagementList.Count() > 0)
          { %>
        <table cellspacing="0" cellpadding="0" border="0" style="border-collapse: collapse;"
            class="GridView tablesorter" width="100%">
            <thead>
                <tr>
                    <th>
                        SNo
                    </th>
                    <th>
                        Code
                    </th>
                    <th>
                        Name
                    </th>
                    <th>
                        Nationality
                    </th>
                    <th>
                        Action
                    </th>
                    
                </tr>
            </thead>
            <tbody>
                <%  var sno = 0;

                    foreach (var item in Model.CountryManagementList)
                    {
                        sno++;
                        var classTblRow = (sno % 2 == 0) ? "GridAlter" : "GridItem";
                %>
                <tr class="<%:classTblRow %>" onmouseout="this.className='GridAlter'" onmouseover="this.className='GridRowOver'">
                    <td>
                        <%:sno%>
                    </td>
                    <td>
                        <%: item.CountryCode %>
                    </td>
                    <td>
                        <%: item.CountryName %>
                    </td>
                    <td>
                        <%: item.Nationality %>
                    </td>
                    <td>
                         <%-- <a href="/Administrator/CountryManagement/Detail/<%:item.CountryId %>" class="details" title="Details"> </a>--%>
                       
                        <a href="/Administrator/CountryManagement/Edit/<%:item.CountryId %>" class="edit" title="Edit"></a>
                        <a href="/Administrator/CountryManagement/Delete/<%:item.CountryId %>" class="delete" title="Delete"
                            onclick="return confirm('Are you sure you want to delete?')"></a>
                    </td>
                    
                </tr>
                <% } %>
                <%}
                %>
            </tbody>
            <tfoot>
               
            </tfoot>
        </table>
        <div class="Adminpager">
       <%= Html.Pager(ViewData.Model.CountryManagementList.PageSize, ViewData.Model.CountryManagementList.PageNumber, ViewData.Model.CountryManagementList.TotalItemCount)%>
       </div>
        <%} %>
      
    </div>

  
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CssContent" runat="server">
    <style type="text/css">
        table.tablesorter thead tr .header
        {
            background-image: url(../../../../Content/images/bg.png);
            background-repeat: no-repeat;
            background-position: center right;
            cursor: pointer;
            height: 20px;
            line-height: 20px;
            padding: 0 0 0 4px;
            text-align: left;
            font-weight: bold;
        }
        
        table.tablesorter thead tr .headerSortUp
        {
            background-image: url(../../../../Content/images/asc.png);
        }
        table.tablesorter thead tr .headerSortDown
        {
            background-image: url(../../../../Content/images/desc.png);
        }
        
        table thead th:hover
        {
            background-color: Yellow;
            color: Black;
        }
    </style>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
    <script src="../../../../Scripts/jquery.tablesorter.js" type="text/javascript"></script>
    <script src="../../../../Scripts/jquery.tablesorter.pager.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            // $("table.tablesorter").tablesorter({ widthFixed: true, sortList: [[0, 0]] });

            //not sorting first and last column
            $("table.tablesorter").tablesorter({ widthFixed: true, headers: {0:{sorter: false}, 4:{sorter:false}}} );
           
        });
    </script>
   
</asp:Content>
