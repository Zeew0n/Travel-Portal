<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<ATLTravelPortal.Areas.Airline.Models.FareModel>" %>

<div> <h2 style="background-color: #0069ac; color: #FFFFFF; font-size: 13px; height:30px; vertical-align:middle; text-align:left; font-weight: bold; padding:0px 10px; line-height:30px;"><b>Fare</b></h2> </div>
  <div style=" border:1px solid #ccc; padding:5px;">
  <table>
    <tr>
        <th style="text-align:left; padding-right:10px;"><%: Html.LabelFor(m => m.Fare)%> </th>
        <td><%: Model.Fare%></td>
    </tr>
    <tr>
        <th style="text-align:left; padding-right:10px;"><%: Html.LabelFor(m => m.Discount)%> </th>
        <td><%: Model.Discount%></td>
    </tr>
</table>
</div>