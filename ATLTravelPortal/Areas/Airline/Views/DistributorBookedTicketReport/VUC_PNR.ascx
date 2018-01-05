<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<ATLTravelPortal.Areas.Airline.Models.PNRsDetailsModel>" %>

<%@ Import Namespace="ATLTravelPortal.Helpers" %>

<div> <h2 style="background-color: #0069ac; color: #FFFFFF; font-size: 13px; height:30px; vertical-align:middle; text-align:left; font-weight: bold; padding:0px 10px; line-height:30px;"><b>PNR Information</b></h2> </div>

<div style=" border:1px solid #ccc; padding:5px;">

<table cellspacing="0" cellpadding="0" border="0" style=" border-collapse:collapse;" class="GridView" width="100%">
    <tr>
        <th style="width:100px;  padding-right:10px;"><%: Html.LabelFor(m => m.pnrmodel.FirstName)%> </th>
        <td><%: Model.pnrmodel.FirstName%></td>
        <th style="width:100px;  padding-right:10px;"><%: Html.LabelFor(m => m.pnrmodel.ContactNumber)%> </th>
        <td><%: Model.pnrmodel.ContactNumber%></td>
       
         
    </tr>
    <tr>
        <th style="width:100px;  padding-right:10px;"><%: Html.LabelFor(m => m.pnrmodel.MiddleName)%> </th>
        <td><%: Model.pnrmodel.MiddleName%></td>
        <th style="width:100px;  padding-right:10px;"><%: Html.LabelFor(m => m.pnrmodel.GDSRefrenceNumber)%> </th>
        <td><%: Model.pnrmodel.GDSRefrenceNumber%></td>
      
    </tr>
    <tr>
        
        <th style="width:100px;  padding-right:10px;"><%: Html.LabelFor(m => m.pnrmodel.LastName)%> </th>
        <td><%: Model.pnrmodel.LastName%></td>
        <th style="width:100px;  padding-right:10px;"><%: Html.LabelFor(m => m.pnrmodel.TicketStatusId)%> </th>
        <td><%: Model.pnrmodel.TicketStatus%></td>
    </tr>
    <tr>
        <th style="width:100px;  padding-right:10px;"><%: Html.LabelFor(m => m.pnrmodel.EmailAddress)%> </th>
        <td><%: Model.pnrmodel.EmailAddress%></td>
        <th style="width:100px;  padding-right:10px;">&nbsp;</th>
        <td>&nbsp;</td>
    
    </tr>
    <tr>
         <th style="width:100px;  padding-right:10px;" <%:Html.LabelFor(m => m.pnrmodel.CreatedBy)%> </th>
        <td><%: Model.pnrmodel.BookedBy%></td>
        <th style="width:100px;  padding-right:10px;"><%: Html.LabelFor(m => m.pnrmodel.CreatedDate)%> </th>
        <td> <%: TimeFormat.DateFormat(Model.pnrmodel.CreatedDate.ToString())%></td>
    </tr>
</table>
</div>



<div> <h2  style="background-color: #0069ac; color: #FFFFFF; font-size: 13px; height:30px; vertical-align:middle; text-align:left; font-weight: bold; padding:0px 10px; line-height:30px; margin-top:20px;"><b>Passengers</b></h2></div>


<% if (Model.pnrpassengermodel != null)
   { %>
<div style=" border:1px solid #ccc; padding:5px;">
    <table cellspacing="0" cellpadding="0" border="0" style=" border-collapse:collapse;" class="GridView" width="100%">
<tr>
    <th><%: Html.LabelFor(m => m.pnrpassengermodel.ElementAtOrDefault(0).DOB)%> </th>
    <th><%: Html.LabelFor(m => m.pnrpassengermodel.ElementAtOrDefault(0).EmailAddress)%> </th>
    <th><%: Html.LabelFor(m => m.pnrpassengermodel.ElementAtOrDefault(0).FirstName)%> </th>
    <th><%: Html.LabelFor(m => m.pnrpassengermodel.ElementAtOrDefault(0).LastName)%> </th>
    <th><%: Html.LabelFor(m => m.pnrpassengermodel.ElementAtOrDefault(0).MiddleName)%> </th>
    
    <th><%: Html.LabelFor(m => m.pnrpassengermodel.ElementAtOrDefault(0).PassengerTypeId)%> </th>
    <th><%: Html.LabelFor(m => m.pnrpassengermodel.ElementAtOrDefault(0).PassportNumber)%> </th>
    <th><%: Html.LabelFor(m => m.pnrpassengermodel.ElementAtOrDefault(0).TicketNumber)%> </th>
</tr>
<% foreach (var item in Model.pnrpassengermodel)
   { 
 %>
<tr>
<td><%: TimeFormat.DateFormat(item.DOB.ToString())%></td>
<td><%: item.EmailAddress%></td>
<td><%: item.FirstName%></td>
<td><%: item.LastName%></td>
<td><%: item.MiddleName%></td>
<td><%: item.PassengerType%></td>
<td><%: item.PassportNumber%></td>
<td><%: item.TicketNumber%></td>

</tr>

<% } %>

</table>
</div>

<%} %>

<div> <h2  style="background-color: #0069ac; color: #FFFFFF; font-size: 13px; height:30px; vertical-align:middle; text-align:left; font-weight: bold; padding:0px 10px; line-height:30px; margin-top:20px;"><b>Segments</b></h2></div>
<% if (Model.pnrsegemnetmodel != null)
   { %>
<div style=" border:1px solid #ccc; padding:5px;">
    <table cellspacing="0" cellpadding="0" border="0" style=" border-collapse:collapse;" class="GridView" width="100%">
<tr>
    <th><%: Html.LabelFor(m => m.pnrsegemnetmodel.ElementAtOrDefault(0).AirlineId)%> </th>
    <th><%: Html.LabelFor(m => m.pnrsegemnetmodel.ElementAtOrDefault(0).ArriveCityId)%> </th>
    <th><%: Html.LabelFor(m => m.pnrsegemnetmodel.ElementAtOrDefault(0).ArriveDate)%> </th>
    <th><%: Html.LabelFor(m => m.pnrsegemnetmodel.ElementAtOrDefault(0).ArriveTime)%> </th>
    <th><%: Html.LabelFor(m => m.pnrsegemnetmodel.ElementAtOrDefault(0).BIC)%> </th>
    
    <th><%: Html.LabelFor(m => m.pnrsegemnetmodel.ElementAtOrDefault(0).DepartCityId)%> </th>
    <th><%: Html.LabelFor(m => m.pnrsegemnetmodel.ElementAtOrDefault(0).DepartDate)%> </th>
    <th><%: Html.LabelFor(m => m.pnrsegemnetmodel.ElementAtOrDefault(0).DepartTime)%> </th>
</tr>

<% foreach (var item in Model.pnrsegemnetmodel)
   { 
 %>
<tr>
<td><%: item.AirlineCode%></td>
<td><%: item.ArriveCityName%></td>
<td><%: TimeFormat.DateFormat(item.ArriveDate.ToString())%></td>
<td><%: item.ArriveTime%></td>
<td><%: item.BIC%></td>

<td><%: item.DepartCityName%></td>
<td><%: TimeFormat.DateFormat(item.DepartDate.ToString())%></td>
<td><%: item.DepartTime%></td>

</tr>

<% } %>

</table>
</div>

<%} %>