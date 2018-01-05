<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<ATLTravelPortal.Areas.Airline.Models.PNRsModel>" %>
<link href="../../../../Content/css/import.css" rel="stylesheet" type="text/css" />
<%@ Import Namespace="ATLTravelPortal.Helpers" %>

<div> <h2 style="background-color: #0069ac; color: #FFFFFF; font-size: 13px; height:30px; vertical-align:middle; text-align:left; font-weight: bold; padding:0px 10px; line-height:30px;"><b>PNR Information</b></h2> </div>

<div style=" border:1px solid #ccc; padding:5px;">

<table cellspacing="0" cellpadding="0" border="0" style=" border-collapse:collapse;" class="GridView" widtd="100%">
<colgroup>
    <col width="20%" />
    <col width="30%" />
    <col width="20%" />
    <col width="30%" />

</colgroup>
    <tr>
        <td style="text-align:left; padding-right:10px; font-weight:bold;"><%: Html.LabelFor(m => m.FirstName)%> </td>
        <td><%: Model.FirstName%></td>
        <td style="text-align:left; padding-right:10px; font-weight:bold; border-left:1px solid #ccc;"><%: Html.LabelFor(m => m.ContactNumber)%> </td>
        <td><%: Model.ContactNumber%></td>
       
         
    </tr>
    <tr>
        <td style="text-align:left; padding-right:10px; font-weight:bold;"><%: Html.LabelFor(m => m.MiddleName)%> </td>
        <td><%: Model.MiddleName%></td> 
        <td style="text-align:left; padding-right:10px; font-weight:bold; border-left:1px solid #ccc;"><%: Html.LabelFor(m => m.GDSRefrenceNumber)%> </td>
        <td><%: Model.GDSRefrenceNumber%></td>
      
    </tr>
    <tr>
        
        <td style="text-align:left; padding-right:10px; font-weight:bold;"><%: Html.LabelFor(m => m.LastName)%> </td>
        <td><%: Model.LastName%></td>
        <td style="text-align:left; padding-right:10px; font-weight:bold; border-left:1px solid #ccc;"><%: Html.LabelFor(m => m.TicketStatusId)%> </td>
        <td><%: Model.TicketStatus%></td>
    </tr>
    <tr>
        <td style="text-align:left; padding-right:10px; font-weight:bold;"><%: Html.LabelFor(m => m.EmailAddress)%> </td>
        <td><%: Model.EmailAddress%></td>
        <td style="text-align:left; padding-right:10px; font-weight:bold; border-left:1px solid #ccc;">&nbsp;</td>
        <td>&nbsp;</td>
    
    </tr>
    <tr>
         <td style="text-align:left; padding-right:10px; font-weight:bold;"><%: Html.LabelFor(m => m.CreatedBy)%> </td>
        <td><%: Model.BookedBy%></td>
        <td style="text-align:left; padding-right:10px; font-weight:bold; border-left:1px solid #ccc;"><%: Html.LabelFor(m => m.CreatedDate)%> </td>
        <td> <%: TimeFormat.DateFormat( Model.CreatedDate.ToString())%></td>
    </tr>
</table>
</div>