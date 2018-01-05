<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/AirlineMain.Master" Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Airline.Models.CancelRequestModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
 <div>
        <div class="pageTitle">
          
            <h3>
                <a href="#" class="icon_plane">Ticket Management</a> <span>&nbsp;</span><strong>Cancel Request</strong>
            </h3>
        </div>
    </div>
    <table cellspacing="0" cellpadding="0" border="0" style="border-collapse: collapse;"
            class="GridView" width="100%">
             <thead>
        <tr>
           <th>
           S.No.
           </th>
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
             <th></th>
        </tr>
        </thead>
    <% foreach (var item in Model.CancelRequestList) { %>
    
        <tr>
           <td>
           <%:item.SNO %>
           </td>
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
                 <%: Html.ActionLink("Confirm", "Details", new {  id=item.PNRId, serid=item.serviceproviderid })%> 
            </td>
        </tr>
    
    <% } %>

    </table>
      <div class="Adminpager">
       <%= Html.Pager(ViewData.Model.CancelRequestList.PageSize, ViewData.Model.CancelRequestList.PageNumber, ViewData.Model.CancelRequestList.TotalItemCount)%>
       </div>
  <%--  <p>
        <%: Html.ActionLink("Create New", "Create") %>
    </p>--%>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="CssContent" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
</asp:Content>

