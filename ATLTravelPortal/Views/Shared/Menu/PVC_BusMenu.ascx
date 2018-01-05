<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<dynamic>" %>
<%@ Import Namespace="ATLTravelPortal.Helpers" %>
<%TravelSession obj = (TravelSession)Session["TravelPortalSessionInfo"]; %>
<div class="applemenu">
    <%if (Page.User.Identity.IsAuthenticated)
      {%>
    <div class="silverheader">
        <a href="#">Setup</a></div>
    <div class="submenu">
        <ul>
        <li>
                <%= Html.ActionLink("Deal Setup", "Index", "DealSetup")%></li>
            <li>
                <%= Html.ActionLink("City Manager", "Index", "BusCity")%></li>
            <li>
                <%= Html.ActionLink("Category Manager", "Index", "BusCategory")%></li>
            <li>
                <%= Html.ActionLink("Bus Operator", "Index", "BusOperator")%></li><li>
                    <%= Html.ActionLink("Bus Operator Category", "Index", "OperatorBusCategory")%></li>
            <li>
                <%= Html.ActionLink("Schedule Manager", "Index", "BusSchedule")%></li>
           <li>
                <%= Html.ActionLink("Update Rate", "UpdateRate", "BusSchedule")%>
           </li>
        </ul>
    </div>
    <div class="silverheader">
        <a href="#">Ticket Management</a></div>
    <div class="submenu">
        <ul>
        <li><%:Html.ActionLink("Unissued Tickets","Index","UnIssuedTicket") %></li>
        <li><%:Html.ActionLink("Issued Tickets", "Index", "IssuedTicket")%></li>
        </ul>
    </div>   
    
      <div class="silverheader">   
        <a href="#">Bus Settings</a></div>
         <div class="submenu">
        <ul>
            <%--<li><%:Html.ActionLink("Update Database", "Index", "UpdateDatabase")%></li>  --%>
            <li><%:Html.ActionLink("Bus Search Log", "Index", "BusSearchLog")%></li>        
        </ul>
    </div>   
          
    <%} %>
</div>
