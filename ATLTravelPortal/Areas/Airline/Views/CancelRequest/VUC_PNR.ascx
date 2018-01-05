<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<ATLTravelPortal.Areas.Airline.Models.PNRsModel>" %>
<link href="../../../../Content/css/import.css" rel="stylesheet" type="text/css" />
<%@ Import Namespace="ATLTravelPortal.Helpers" %>

<div> <h2 style="background-color: #0069ac; color: #FFFFFF; font-size: 13px; height:30px; vertical-align:middle; text-align:left; font-weight: bold; padding:0px 10px; line-height:30px;"><b>PNR Information</b></h2> </div>

<div style=" border:1px solid #ccc; padding:5px;">

<table cellspacing="0" cellpadding="0" border="0" style=" border-collapse:collapse;" class="GridView" width="100%">
    <tr>
        <th style="text-align:right; padding-right:10px;"><%: Html.LabelFor(m => m.FirstName)%> </th>
        <td><%: Model.FirstName%></td>
        <th style="text-align:right; padding-right:10px;"><%: Html.LabelFor(m => m.ContactNumber)%> </th>
        <td><%: Model.ContactNumber%></td>
       
         
    </tr>
    <tr>
        <th style="text-align:right; padding-right:10px;"><%: Html.LabelFor(m => m.MiddleName)%> </th>
        <td><%: Model.MiddleName%></td>
        <th style="text-align:right; padding-right:10px;"><%: Html.LabelFor(m => m.GDSRefrenceNumber)%> </th>
        <td><%: Model.GDSRefrenceNumber%></td>
      
    </tr>
    <tr>
        
        <th style="text-align:right; padding-right:10px;"><%: Html.LabelFor(m => m.LastName)%> </th>
        <td><%: Model.LastName%></td>
        <th style="text-align:right; padding-right:10px;"><%: Html.LabelFor(m => m.TicketStatusId)%> </th>
        <td><%: Model.TicketStatus%></td>
    </tr>
    <tr>
        <th style="text-align:right; padding-right:10px;"><%: Html.LabelFor(m => m.EmailAddress)%> </th>
        <td><%: Model.EmailAddress%></td>
        <th style="text-align:right; padding-right:10px;">&nbsp;</th>
        <td>&nbsp;</td>
    
    </tr>
    <tr>
         <th style="text-align:right; padding-right:10px;"><%: Html.LabelFor(m => m.CreatedBy)%> </th>
        <td><%: Model.BookedBy%></td>
        <th style="text-align:right; padding-right:10px;"><%: Html.LabelFor(m => m.CreatedDate)%> </th>
        <td> <%: TimeFormat.DateFormat( Model.CreatedDate.ToString())%></td>
    </tr>
</table>
</div>