<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<ATLTravelPortal.Areas.Airline.Models.PassengersModel>" %>
<link href="../../../../Content/css/import.css" rel="stylesheet" type="text/css" />
<%@ Import Namespace="ATLTravelPortal.Helpers" %>
  <div> <h2  style="background-color: #0069ac; color: #FFFFFF; font-size: 13px; height:30px; vertical-align:middle; text-align:left; font-weight: bold; padding:0px 10px; line-height:30px; margin-top:20px;"><b>Passengers</b></h2></div>


<% if(Model.PassengersList != null){ %>
<div style=" border:1px solid #ccc; padding:5px;">
    <table cellspacing="0" cellpadding="0" border="0" style=" border-collapse:collapse;" class="GridView" width="100%">
<tr>
    <th><%: Html.LabelFor(m => m.DOB)%> </th>
    <th><%: Html.LabelFor(m => m.EmailAddress)%> </th>
    <th><%: Html.LabelFor(m => m.FirstName)%> </th>
    <th><%: Html.LabelFor(m => m.LastName)%> </th>
    <th><%: Html.LabelFor(m => m.MiddleName)%> </th>
    
    <th><%: Html.LabelFor(m => m.PassengerTypeId)%> </th>
    <th><%: Html.LabelFor(m => m.PassportNumber)%> </th>
    <th><%: Html.LabelFor(m => m.TicketNumber)%> </th>
</tr>
<% foreach (var item in Model.PassengersList)
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