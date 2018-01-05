<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<ATLTravelPortal.Areas.Airline.Models.PNRManagementModel>" %>
   <%if (Model != null)
     { %>
<div> <h2 style="background-color: #525252; color: #FFFFFF; font-size: 13px; height:30px; vertical-align:middle; text-align:left; font-weight: bold; padding:0px 10px; line-height:30px;"><b>PNR Information</b></h2> </div>

<div style=" border:1px solid #ccc; padding:5px;">

<table cellspacing="0" cellpadding="0" border="0" style=" border-collapse:collapse;" class="GridView" width="100%">
    <tr>
        <th><%: Html.LabelFor(m => m.PNRsModel.FirstName)%> </th>
        <td><%:Html.TextBoxFor(m => m.PNRsModel.FirstName)%></td>
        <th><%: Html.LabelFor(m => m.PNRsModel.ContactNumber)%> </th>
        <td><%: Html.TextBoxFor(m => m.PNRsModel.ContactNumber)%></td>
       
         
    </tr>
    <tr>
        <th><%: Html.LabelFor(m => m.PNRsModel.MiddleName)%> </th>
        <td><%: Html.TextBoxFor(m => m.PNRsModel.MiddleName)%></td>
        <th><%: Html.LabelFor(m => m.PNRsModel.GDSRefrenceNumber)%> </th>
        <td><%: Model.PNRsModel.GDSRefrenceNumber%></td>
      
    </tr>
    <tr>
        
        <th><%: Html.LabelFor(m => m.PNRsModel.LastName)%> </th>
        <td><%: Html.TextBoxFor(m => m.PNRsModel.LastName)%></td>
        <th><%: Html.LabelFor(m => m.PNRsModel.TicketStatusId)%> </th>
        <td><%: Html.DropDownListFor(m => m.PNRsModel.TicketStatusId, Model.TicketStatusList)%></td>
    </tr>
    <tr>
        <th><%: Html.LabelFor(m => m.PNRsModel.EmailAddress)%> </th>
        <td><%: Html.TextBoxFor(m => m.PNRsModel.EmailAddress)%></td>
        <th>&nbsp;</th>
        <td>&nbsp;</td>
    
    </tr>
    <tr>
         <th><%: Html.LabelFor(m => m.PNRsModel.CreatedBy)%> </th>
        <td><%: Model.PNRsModel.BookedPerson%></td>
        <th><%: Html.LabelFor(m => m.PNRsModel.CreatedDate)%> </th>
        <td> <%: Model.PNRsModel.CreatedDate.ToString()%></td>
    </tr>
</table>
</div>


<div> <h2  style="background-color: #525252; color: #FFFFFF; font-size: 13px; height:30px; vertical-align:middle; text-align:left; font-weight: bold; padding:0px 10px; line-height:30px; margin-top:20px;"><b>Segments</b></h2></div>
<% if (Model.PNRSegmentsList != null)
   { %>
<div style=" border:1px solid #ccc; padding:5px; overflow:auto;">
    <table cellspacing="0" cellpadding="0" border="0" style=" border-collapse:collapse;" class="GridView" width="100%">
<tr>
    <th><%: Html.LabelFor(m => m.PNRSegmentsList.ElementAtOrDefault(0).AirlineId)%> </th>
    <th><%: Html.LabelFor(m => m.PNRSegmentsList.ElementAtOrDefault(0).ArriveCityId)%> </th>
    <th><%: Html.LabelFor(m => m.PNRSegmentsList.ElementAtOrDefault(0).ArriveDate)%> </th>
    <th><%: Html.LabelFor(m => m.PNRSegmentsList.ElementAtOrDefault(0).ArriveTime)%> </th>
    <th><%: Html.LabelFor(m => m.PNRSegmentsList.ElementAtOrDefault(0).BIC)%> </th>
    
    <th><%: Html.LabelFor(m => m.PNRSegmentsList.ElementAtOrDefault(0).DepartCityId)%> </th>
    <th><%: Html.LabelFor(m => m.PNRSegmentsList.ElementAtOrDefault(0).DepartDate)%> </th>
    <th><%: Html.LabelFor(m => m.PNRSegmentsList.ElementAtOrDefault(0).DepartTime)%> </th>
</tr>

<% foreach (var item in Model.PNRSegmentsList)
   { 
 %>
<tr>
<td><a href="#" class="delete" title="Delete" onclick="return confirm('Are you sure you want to delete?')"></a></td>
                          
<td><%: Html.TextBoxFor(m => item.AirlineCode)%></td>
<td><%: Html.TextBoxFor(m => item.ArriveCityName)%></td>
<td><%: Html.TextBoxFor(m => item.ArriveDate)%></td>
<td><%: Html.TextBoxFor(m => item.ArriveTime)%></td>
<td><%: Html.TextBoxFor(m => item.BIC)%></td>

<td><%: Html.TextBoxFor(m => item.DepartCityName)%></td>
<td><%: Html.TextBoxFor(m => item.DepartDate)%></td>
<td><%: Html.TextBoxFor(m => item.DepartTime)%></td>



</tr>

<% } %>

</table>
</div>

<%} %>


<div> <h2  style="background-color: #525252; color: #FFFFFF; font-size: 13px; height:30px; vertical-align:middle; text-align:left; font-weight: bold; padding:0px 10px; line-height:30px; margin-top:20px;"><b>Passengers</b></h2></div>


<% if (Model.PassengerList != null)
   { %>
<div style=" border:1px solid #ccc; padding:5px; overflow:auto;">
    <table cellspacing="0" cellpadding="0" border="0" style=" border-collapse:collapse;" class="GridView" width="100%">
<tr>
    <th><%: Html.LabelFor(m => m.PassengerList.ElementAtOrDefault(0).DOB)%> </th>
    <th><%: Html.LabelFor(m => m.PassengerList.ElementAtOrDefault(0).EmailAddress)%> </th>
    <th><%: Html.LabelFor(m => m.PassengerList.ElementAtOrDefault(0).FirstName)%> </th>
    <th><%: Html.LabelFor(m => m.PassengerList.ElementAtOrDefault(0).LastName)%> </th>
    <th><%: Html.LabelFor(m => m.PassengerList.ElementAtOrDefault(0).MiddleName)%> </th>
    
    <th><%: Html.LabelFor(m => m.PassengerList.ElementAtOrDefault(0).PassengerTypeId)%> </th>
    <th><%: Html.LabelFor(m => m.PassengerList.ElementAtOrDefault(0).PassportNumber)%> </th>
    <th><%: Html.LabelFor(m => m.PassengerList.ElementAtOrDefault(0).TicketNumber)%> </th>
</tr>
<% foreach (var item in Model.PassengerList)
   { 
 %>
<tr>
<td><%: Html.TextBoxFor(m => item.DOB)%></td>
<td><%: Html.TextBoxFor(m => item.EmailAddress)%></td>
<td><%: Html.TextBoxFor(m => item.FirstName)%></td>
<td><%: Html.TextBoxFor(m => item.LastName)%></td>
<td><%: Html.TextBoxFor(m => item.MiddleName)%></td>
<td><%: Html.TextBoxFor(m => item.PassengerType)%></td>
<td><%: Html.TextBoxFor(m => item.PassportNumber)%></td>
<td><%: Html.TextBoxFor(m => item.TicketNumber)%></td>

</tr>

<% } %>

</table>
</div>

<%}
     } %>