<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/AirlineMain.Master" Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Airline.Models.VoidRequestModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
 <%Html.RenderPartial("Utility/VUC_MessagePanel"); %>
 <div>
        <div class="pageTitle">
          
            <h3>
                <a href="#" class="icon_plane">Ticket Management</a> <span>&nbsp;</span><strong>Void Request</strong>
            </h3>
        </div>
    </div>
    <div class="contentGrid"> 
     <% if (Model != null)
           { %>

             <%if (Model.VoidRequestList != null && Model.VoidRequestList.Count() >0)
              { %>  
 

    <table cellspacing="0" cellpadding="0" border="0" style="border-collapse: collapse;"
            class="GridView" width="100%">
             <thead>
        <tr>
         <th>SNo.</th>
            <th>
                AgentName
            </th>
            <th>
                Type
            </th>
            <th>
                GDS Ref#
            </th>
            <th>
                Passenger
            </th>
            <th>
                Sector
            </th>
            <th>
                Booked On
            </th>
            <th>
                Booked By
            </th>
            <th>
                Status
            </th>
        </tr>
        </thead>
    <%  var sno = 0; 
        foreach (var item in Model.VoidRequestList)
        {
            sno++;
            var classTblRow = (sno % 2 == 0) ? "GridAlter" : "GridItem";
            %>
    
        <tr>
            <td> <%: sno %></td>
            <td>
                <%: item.AgentName %>
            </td>
            <td>
                <%: item.AirlineTypeName %>
            </td>
            <td>
                <%: item.GDSRefrenceNumber %>
            </td>
            <td>
                <%: item.PassengerName %>
            </td>
            <td>
                <%: item.Sector %>
            </td>
            <td>
                <%: String.Format("{0:g}", item.BookedOn) %>
            </td>
            <td>
                <%: item.BookedBy %>
            </td>
           
           <td>
          
            
                <a href="<%:item.ServiceProviderVoidUrl%>/<%: item.PNRId %>?serid=<%: item.ServiceProviderId %>" class="Details">
                            Detail</a>

                            
            </td>
        </tr>
    
    <% } %>

    </table>
     <div class="Adminpager">
       <%= Html.Pager(ViewData.Model.VoidRequestList.PageSize, ViewData.Model.VoidRequestList.PageNumber, ViewData.Model.VoidRequestList.TotalItemCount)%>
       </div>
     <% } %>
            <%}%>
            </div>     
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="CssContent" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
</asp:Content>

