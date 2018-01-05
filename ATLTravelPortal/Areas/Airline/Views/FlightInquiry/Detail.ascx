<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<ATLTravelPortal.Areas.Airline.Models.FlightInquiryModel>" %>
<div>

<div class="divLeft"><%=Html.LabelFor(model => model.JourneyType)%> : <%:Model.JourneyType%></div>
<div class="divRight"><%=Html.LabelFor(model => model.FlightType)%> : <%:Model.FlightType%></div>
<div class="divLeft"><%=Html.LabelFor(model => model.OriginCity)%> : <%:(Model.OriginCity)%></div>
<div class="divRight"><%=Html.LabelFor(model => model.DepartureCity)%> : <%:(Model.DepartureCity)%></div>
<div class="divLeft"><%=Html.LabelFor(model => model.DepartureDate)%> : <%:Model.DepartureDate%></div>
                                    
<div class="divRight"><%=Html.LabelFor(model => model.ReturnDate)%> : <%:Model.ReturnDate%></div>
<div style="clear: both"></div>
        
<div class="divFull">     
    <div style="margin-right: 25px; float:left; color:#fff;"><%=Html.LabelFor(model => model.CabinClass)%> : <%:Model.CabinClass%></div>   
    <div style="margin-right: 25px; float:left; color:#fff;"><%=Html.LabelFor(model => model.AirlinePreference)%> : <%:Model.AirlinePreference%></div>  
</div>

<div class="divLeft"><%=Html.LabelFor(model => model.Nationality)%> : <%:Model.Nationality%></div>
<div style="clear: both"></div>
<div class="pageTitle"><h3>contact Information</h3></div>
<div class="divLeft">
    <div><%=Html.LabelFor(model => model.ContactName)%><%:Model.ContactName %></div>
    <div><%=Html.LabelFor(model => model.ContactNumber)%><%:Model.ContactNumber %></div>
</div>
<div class="divRight">
    <div><%=Html.LabelFor(model => model.EmailAddress)%><%:Model.EmailAddress %></div>
    <div><%=Html.LabelFor(model => model.CompanyAgentName)%><%:Model.CompanyAgentName %></div>
</div>
<div style="clear: both"></div>
 <div class="pageTitle"><h3>Passenger Detail</h3></div>
<% 
    if (Model.FlightInquiryPax.Count() > 0)
    {
        int i = 0;
        foreach (var item in Model.FlightInquiryPax)
        {
            i++;

%> 
<br />
<div class="pageTitle"><h6><%:item.PassengerType%> Passenger - <%:(i + 1)%></h6></div>      
<div class="divLeft">
    <div><%:item.Title%>&nbsp; <%:item.FirstName%>&nbsp;<%:item.MiddleName%>&nbsp; <%:item.LastName%></div>
    <div><%=Html.LabelFor(model => model.FlightInquiryPax[0].PassengerType)%><%:item.PassengerType%></div>
    <div><%=Html.LabelFor(model => model.FlightInquiryPax[0].Gender)%><%:item.Gender%></div>
</div>
<div class="divRight">
    <div><%=Html.LabelFor(model => model.FlightInquiryPax[0].ContactNumber)%><%:item.ContactNumber%></div>
    <div><%=Html.LabelFor(model => model.FlightInquiryPax[0].EmailAddress)%><%:item.EmailAddress%></div>
</div>

<div style="clear:both;"></div>   
   
   
   
   
<%  }
    }
    else {
%>        
        <%=MvcHtmlString.Create("<div>No Record</div>")%>
<%     
    } %>
</div>

