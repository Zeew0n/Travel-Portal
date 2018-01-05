<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<ATLTravelPortal.Areas.Airline.Models.OffLineBookViewModel.OfflineBookViewModel>" %>
<%@ Import Namespace="ATLTravelPortal.Helpers" %>
<% int i = 0;
%>
<table cellspacing="0" cellpadding="0" border="0" style="border-collapse: collapse;"
    class="GridView" width="100%">
    <thead>
        <tr>
            <th>
                SNo
            </th>
            <th>
                Agent Name
            </th>
            <th>
                Booking Ref.#
            </th>
            <th>
                Passenger Name
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
               Type
            </th>
            <th>
                Action
            </th>
        </tr>
    </thead>
    <%
        var sno = 1;
        foreach (var item in Model.OfflineBookTicketList)
        {%>
    <%
            
    %>
    <tr id="tr_<%:sno %>">
        <td>
            <%: sno %>
        </td>
        <td>
            <%: item.UserDetail.AgentName %>
        </td>
        <td>
            <%: item.BookingRefNo%>
        </td>
        <td>
            <%: item.PassengerName %>
        </td>
        <td>
            <%: item.Sector %>
        </td>
        <td>
            <%: item.BookedDate %>
        </td>
         <td>
            <%:item.BookedBy %>
        </td>
         <td>
            <% if (item.TicketStatusId == 28)
               {%>
             <img src="../../../../Content/images/b2c.png" /><%}
               else
               {%>
             <img src="../../../../Content/images/b2b.png" /><%} %>
        </td>
       
        <td>
            <%: Html.ActionLink("Edit", "Edit", new { Id = item.MPNRId })%>
        </td>
    </tr>
    <% sno++;

        }
    %>
</table>
