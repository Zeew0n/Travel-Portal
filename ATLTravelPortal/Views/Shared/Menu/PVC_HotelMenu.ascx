<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<dynamic>" %>
<%@ Import Namespace="ATLTravelPortal.Helpers" %>
<%TravelSession obj = (TravelSession)Session["TravelPortalSessionInfo"]; %>
<div class="applemenu">
    <%if (Page.User.Identity.IsAuthenticated)
      {%>
    <div class="silverheader">
        <a href="#">Hotel Setup</a></div>
    <div class="submenu">
        <ul>
            <li>
                <%=Html.ActionLink("Deal Setup","Index","HotelDeal") %></li>
            <%-- <li><%= Html.ActionLink("Hotel Registration", "List", "HotelInfo")%></li>
            <li><%= Html.ActionLink("Hotel Type", "List", "HotelTypeInfo")%></li>
            <li> <%=Html.ActionLink("Hotel Room Type","List","HotelRoomType") %> </li>
            <li> <%=Html.ActionLink("Hotel Facility","List","HotelFacility") %></li>                   
            <li> <%=Html.ActionLink("Hotel Additional Charge","List","HotelAdditionalCharge") %></li>
            <li> <%=Html.ActionLink("Hotel Photo Category","List","HotelPhotoCategory") %></li>                                                    
            <li><%=Html.ActionLink("Hotel Photos Gallery","UploadPhoto","HotelPhoto") %></li>  
            <li><%=Html.ActionLink("Hotel Google Map Data", "List", "HotelGoogleMap")%></li> --%>
        </ul>
    </div>
    <%--<div class="silverheader">
        <a href="#">Card Setup</a></div>
    <div class="submenu">
        <ul>
        <li><%= Html.ActionLink("Card Registration", "Index", "CardRegistration")%></li>
        <li><%= Html.ActionLink("Issue Card", "Index", "IssueCard")%></li>
        <li><%= Html.ActionLink("Customer Card", "Index", "CustomerCard")%></li>
        <li><%= Html.ActionLink("Search Card", "Search", "SearchCard")%></li>
        </ul>
    </div>--%>
    <div class="silverheader">
        <a href="#">Booking Record</a></div>
    <div class="submenu">
        <ul>
            <li>
                <%= Html.ActionLink("Booking Record", "Index", "HotelBookingRecord")%></li>
            <li>
                <%= Html.ActionLink("Cancellation List", "CancellationList", "HotelBookingRecord")%></li>
        </ul>
    </div>
    <div class="silverheader">
        <a href="#">Booking Status</a></div>
    <div class="submenu">
        <ul>
            <li>
                <%= Html.ActionLink("Pending Booking", "Index", "HotelBookingProcess")%></li>
            <li>
                <%= Html.ActionLink("Pending Cancellation", "PendingCancellationList", "HotelBookingProcess")%></li>
        </ul>
    </div>

     <div class="silverheader">
        <a href="#">Offline Hotel Booking</a></div>
    <div class="submenu">
        <ul>
            <li>
                <%= Html.ActionLink("Offline Booking", "Index", "HotelOfflineBook")%></li>
                 <li>
                <%= Html.ActionLink("Issued Ticket", "Index", "HotelOfflineIssueTicket")%></li>
                 <li>
                <%= Html.ActionLink("Cancel Ticket", "Index", "HotelOfflineCancelTicket")%></li>
        </ul>
    </div>
<%} %>
</div> 