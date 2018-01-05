<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/AirlineMain.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<ATLTravelPortal.Areas.Airline.Models.UnIssuedInternationalTicketModel>>" %>

<%@ Import Namespace="ATLTravelPortal.Helpers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	 UnIssued International Ticket
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
 

    <div>
        <div class="pageTitle">
          
            <h3>
                <a href="#" class="icon_plane">Ticket Management</a> <span>&nbsp;</span><strong> UnIssued International Ticket</strong>
            </h3>
        </div>
    </div>

    <table  cellspacing="0" cellpadding="0" border="0" style="border-collapse: collapse;"
            class="GridView" width="100%">
             <thead>
        <tr>
            <th>
                SNo.
            </th>
            <th>
                Agent
            </th>
            <th>
                PNR#
            </th>
            <th>
                Passenger
            </th>
            <th>
                Airline
            </th>
            <th>
                Sector
            </th>
            <th>
                Flight Date
            </th>
            <th>
                Booked By
            </th>
           <%-- <th>
                Booked Date
            </th>--%>
            
             <th></th>
        </tr>
         </thead>
         <%  var sno = 0; %>
    <% foreach (var item in Model) {
          
           sno++;
           var classTblRow = (sno % 2 == 0) ? "GridAlter" : "GridItem";
            %>
    
        <tr>
        <td>
                    <%:sno%>
                </td>
            <td>
                <%: item.AgentName %>
            </td>
            <td>
                <%: item.GDSRefrenceNumber %>
            </td>
            <td>
                <%: item.PassengerName %>
            </td>
            <td>
                <%: item.AirlineCode %>
            </td>
            <td>
                <%: item.Sector %>
            </td>
             <td>
            <%: TimeFormat.DateFormat(item.FlightDate.ToString()) %>
            </td>
            <td>
                <%: item.BookedBy %>
            </td>
            <%--<td>
                <%: item.BookedDate %>
            </td>--%>
           
             <td>
                <%: Html.ActionLink("Details", "Details", new {  id=item.PNRid }) %>
            </td>
        </tr>
    
    <% } %>

    </table>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="CssContent" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
</asp:Content>

