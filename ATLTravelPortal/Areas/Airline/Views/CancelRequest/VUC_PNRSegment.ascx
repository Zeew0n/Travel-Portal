<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<ATLTravelPortal.Areas.Airline.Models.PNRSegmentsModel>" %>
 <%@ Import Namespace="ATLTravelPortal.Helpers" %>

<div> <h2  style="background-color: #0069ac; color: #FFFFFF; font-size: 13px; height:30px; vertical-align:middle; text-align:left; font-weight: bold; padding:0px 10px; line-height:30px; margin-top:20px;"><b>Segments</b></h2></div>
<% if(Model.PNRSegmentsList != null){ %>
<div style=" border:1px solid #ccc; padding:5px;">
    <table cellspacing="0" cellpadding="0" border="0" style=" border-collapse:collapse;" class="GridView" width="100%">
<tr>
    <th><%: Html.LabelFor(m => m.AirlineId)%> </th>
    <th><%: Html.LabelFor(m => m.DepartCityId)%> </th>
    <th><%: Html.LabelFor(m => m.DepartDate)%> </th>
    <th><%: Html.LabelFor(m => m.DepartTime)%> </th>

   
    <th><%: Html.LabelFor(m => m.BIC)%> </th>
    
    <th><%: Html.LabelFor(m => m.ArriveCityId)%> </th>
    <th><%: Html.LabelFor(m => m.ArriveDate)%> </th>
    <th><%: Html.LabelFor(m => m.ArriveTime)%> </th>
</tr>

<% foreach (var item in Model.PNRSegmentsList)
   { 
 %>
<tr>
<td><%: item.AirlineCode%></td>
<td><%: item.DepartCityName%></td>
<td><%: TimeFormat.DateFormat(item.DepartDate.ToString())%></td>
<td><%: item.DepartTime%></td>
<td><%: item.BIC%></td>
<td><%: item.ArriveCityName%></td>
<td><%: TimeFormat.DateFormat(item.ArriveDate.ToString())%></td>
<td><%: item.ArriveTime%></td>

</tr>

<% } %>

</table>
</div>

<%} %>


