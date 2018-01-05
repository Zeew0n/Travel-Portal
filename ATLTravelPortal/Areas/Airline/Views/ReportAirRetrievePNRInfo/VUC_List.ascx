<%@ Control Language="C#" 
Inherits="System.Web.Mvc.ViewUserControl<ATLTravelPortal.Areas.Airline.Models.PNRReportModel>" %>
<%@ Import Namespace="ATLTravelPortal.Helpers" %>
<% if (Model != null)
           { %>

             <%if (Model.PNRReportList != null && Model.PNRReportList.Count() >0)
              { %>  
 <div class="contentGrid" style="width:756px; overflow:auto;">
  <table cellspacing="0" cellpadding="0" border="0" style="border-collapse: collapse;"
            class="GridView" width="100%">
            <thead>
                <tr>
                    <th>Agent</th>
                    <th>FullName</th>
                    <th>Address </th>
                    <th>Created Date</th>
                    <th>GDS Ref Number</th>
                    <th>Service Provider</th>
                    <th>Airline Code</th>
                    <th>Sector</th>
                    <th>Class </th>
                    <th>Base Fare</th>
                    <th>Sur Charge</th>
                    <th>Commission On BF</th>
                    <th>Service Charge</th>
                    <th>Total Tax</th>
                    <th>Total Fare</th>
                    <th>Ticket Status</th>
                </tr>
            </thead>

             <%if (Model.PNRReportList != null)
              { %>



            <% foreach (var item in Model.PNRReportList)
               { %>
            <tr>
               <td><%: item.AgentName%></td>
            <td><%: item.FullName%></td>
            <td><%: item.Address %></td>
            <td><%: TimeFormat.DateFormat( item.CreatedDate.ToString())%></td>
            <td><%: item.GDSRefrenceNumber%></td>
            <td><%: item.ServiceProviderName%></td>
            <td><%: item.AirlineCode%></td>
            <td><%: item.Sector%></td>
            <td><%: item.Class %></td>
            <td><%: item.BaseFare%></td>
            <td><%: item.SurCharge%></td>
            <td><%: item.CommissionOnBF%></td>
            <td><%: item.ServiceCharge%></td>
            <td><%: item.TotalTax%></td>
            <td><%: item.TotalFare%></td>
            <td><%: item.ticketStatusName%></td>
             
            </tr>

           


            <% } %>



            
             <%}
                %>


                  <% } %>
         
            <%}
            %>

        </table>
        </div>

          
        <% if (Model.PNRReportList != null && Model.PNRReportList.Count() > 0)
           { %>
        <% }
           else
           {
               Html.RenderPartial("NoRecordsFound");
           } 
        %>
        <%--..............................................................--%>


      
