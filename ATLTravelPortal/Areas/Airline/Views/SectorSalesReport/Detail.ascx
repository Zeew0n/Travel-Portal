<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<ATLTravelPortal.Areas.Airline.Models.SectorSalesReportModel>" %>



<div class="contentGrid">
   

       <table cellspacing="0" cellpadding="0" border="0" style="border-collapse: collapse;"
            class="GridView" width="100%">
        <thead>
      
        <tr>
            <th>
                SNo
            </th>
            <th>
                Agent
            </th>
           
            <th>
                Segment
            </th>
        </tr>
        </thead>
        <%
            if (Model != null)
            {
        %>
        <% var sno = 0;

           int count = Model.SegmentSalesDetailsReportList.Count();
           if (count > 0)
           {
               Model.txtSumSegment = Model.SegmentSalesDetailsReportList.ElementAt(count - 1).txtSumSegment;
               Model.txtSumTotalBookedTicketStatus = Model.SegmentSalesDetailsReportList.ElementAt(count - 1).txtSumTotalBookedTicketStatus;
               Model.txtSumTotalCancelledTicketStatus = Model.SegmentSalesDetailsReportList.ElementAt(count - 1).txtSumTotalCancelledTicketStatus;
               Model.txtDifference = Model.SegmentSalesDetailsReportList.ElementAt(count - 1).txtDifference;
           }

           foreach (var item in Model.SegmentSalesDetailsReportList)
           {
               sno++;

              
               
               var classTblRow = (sno % 2 == 0) ? "GridAlter" : "GridItem";
        %>
        <tbody>
            <tr id="tr_<%=sno %>" class="<%: classTblRow %>" onmouseover="this.className='GridRowOver'"
                onmouseout="this.className='<%= classTblRow %>'">
                <td>
                    <%:sno%>
                </td>
                <td>
                    <%: item.Agent%>
                </td>
                <td>
                    <%: item.SegmentId%>
                    </td>
          
            </tr>
      


     </tbody>
        <%      }%>
        <tbody>
            <tr>
                <% if (Model.SegmentSalesDetailsReportList != null)
                   {
                       if (count > 0)
                       {
                %>
                <td>
                </td>
                <td>
                </td>
               <%-- <td>
                </td>--%>
               <%-- <td>
                    Total Segments:<%:Model.txtSumSegment == null ? "" : (Model.txtSumSegment).ToString()%>
                </td>--%>
                 <td>
                        <b>Net: <%:Model.txtDifference == null ? "" : Model.txtDifference.ToString()%></b>
                        </td>
                        <td></td>
                <%}
              }
                %>
            </tr>
        </tbody>
        <%}%>
    </table>

     <div>
                        <b>Total Booked:<%:Model.txtSumTotalBookedTicketStatus == null ? "" : Model.txtSumTotalBookedTicketStatus.ToString() %></b>
                       <br />
                       
                        <b>Total Cancelled:<%:Model.txtSumTotalCancelledTicketStatus == null ? "" : Model.txtSumTotalCancelledTicketStatus.ToString()%></b>
                      
                        </div>

  
</div>