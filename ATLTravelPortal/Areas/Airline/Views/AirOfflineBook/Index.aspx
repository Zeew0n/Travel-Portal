<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/AirlineMain.Master" Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Airline.Models.OffLineBookViewModel.OfflineBookViewModel>" %>
<%@ Import Namespace="ATLTravelPortal.Helpers" %>


<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

     <% Html.EnableClientValidation(); %>

      <%:Html.ActionLink("New Booking", "Create", "AirOfflineBook",null, new { @class = "createDeal linkButton", @title = "New Offline Booking" })%>
      <br />
      <br />

    <% using (Html.BeginForm("Index", "AirOfflineBook", FormMethod.Post, new { @class = "validate" }))%>
    <% { %>
    <%: Html.ValidationSummary(true)%>



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
        <%: item.ServiceProviderName %>
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
            <% if (item.TicketStatusId == 28 || item.TicketStatusId == 34)
               {%>
             <img src="../../../../Content/images/b2c.png" /><%}
               else
               {%>
             <img src="../../../../Content/images/b2b.png" /><%} %>
        </td>

        <td>
            <%: Html.ActionLink("Details", "Details", new { Id = item.MPNRId })%>
        </td>
     
    </tr>
    <% sno++;

        }
    %>
</table>

<%} %>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="CssContent" runat="server">
    <link href="../../../../Content/css/atsfltsearch.css" rel="stylesheet" type="text/css" />
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
</asp:Content>
