<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/AirlineMain.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<ATLTravelPortal.Areas.Airline.Models.TicketCappingModel>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div>
        <div class="pageTitle">
          
            <h3>
                <a href="#" class="icon_plane">Reports</a> <span>&nbsp;</span><strong>Airline Capping Info</strong>
            </h3>
        </div>
    </div>

   <table  cellspacing="0" cellpadding="0" border="0" style="border-collapse: collapse;"
            class="GridView" width="100%">
             <thead>
        <tr>
        <th></th>
            <th>
                Airline
            </th>
            <th>
                Maximum Limit
            </th>
            <th>
                Minimum Limit
            </th>
            <th>
                Remaining
            </th>
        </tr>
        </thead>
          <%  var sno = 0; %>
          <% if(Model!=null)
             { %>
    <% foreach (var item in Model) { %>
    <%  sno++;
        var classTblRow = (sno % 2 == 0) ? "GridAlter" : "GridItem"; %>
    
        <tr>
        <td>  <%:sno%></td>
            <td>
                <%: item.AirlineCode %>
            </td>
            <td>
                <%: item.MaxValue %>
            </td>
            <td>
                <%: item.MinValue %>
            </td>
            <td>
                <%: item.RemainValue %>
            </td>
        </tr>
    
    <% } %>
    <% } %>

    </table>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="CssContent" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
</asp:Content>

