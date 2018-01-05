<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<dynamic>" %>
<%@ Import Namespace="ATLTravelPortal.Helpers" %>
<%TravelSession obj = (TravelSession)Session["TravelPortalSessionInfo"]; %>
<div class="applemenu">
    <%if (Page.User.Identity.IsAuthenticated)
      {%>
    <div class="silverheader">
        <a href="#">Booking Request</a></div>
    <div class="submenu">
        <ul>
            <li><%= Html.ActionLink("Pending Booking List", "Index", "BookingRequest")%></li>
            <li><%= Html.ActionLink("In Process List", "Process", "BookingRequest")%></li>
            <li><%= Html.ActionLink("Issued List", "Issued", "BookingRequest")%></li>
            <li><%= Html.ActionLink("Canceled List", "Canceled", "BookingRequest")%></li>
        </ul>
    </div>
     <div class="silverheader">
        <a href="#">Train Settings</a></div>
    <div class="submenu">
        <ul>          
           <li><%=Html.ActionLink("Train Search Log", "TrainSearchReport", "BookingRequest")%></li>               
           <li><%=Html.ActionLink("Train Charge", "Index", "TrainCharge")%></li>
        </ul>
    </div>
    <%} %>
</div>
