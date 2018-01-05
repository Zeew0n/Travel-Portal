<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<ATLTravelPortal.Areas.Airline.Models.SectorSalesReportModel>" %>

<%@ Import Namespace="ATLTravelPortal.Helpers" %>




<div class="contentGrid">

  <%
      if (Model != null)
      {
        %>

         <%if (Model.SegmentSalesReportList != null && Model.SegmentSalesReportList.Count() > 0)
           { %>

       <table cellspacing="0" cellpadding="0" border="0" style="border-collapse: collapse;"
            class="GridView" width="100%">
        <thead>
      
        <tr>
            <th>
                SNo
            </th>
            <th>
                Depart
            </th>
            <th>
                Arrive
            </th>
            <th>
                Segment
            </th>
        </tr>
        </thead>
      
        <% var sno = 0;


           int count = Model.SegmentSalesReportList.Count();
           if (count > 0)
           {
               Model.txtSumMainSegment = Model.SegmentSalesReportList.ElementAt(count - 1).txtSumMainSegment;
           }




           foreach (var item in Model.SegmentSalesReportList)
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
                    <%: item.DepartCity%>
                </td>
                <td>
                    <%: item.ArriveCity%>
                    </td>
             
             <%--  <%: Html.ActionLink(item.FacilityName, "Detail", new { id = item.FacilityId }, new { @class = "Details" })%>--%>
                <td>
               <%-- <a href ="/SectorSalesReport/Detail?dcity=<%:item.DepartCityId %>&acity=<%:item.ArriveCityId %>&fdate=<%:Model.FromDate %>&tdate=<%:Model.ToDate %>" class="Details" >  <%: item.SegmentId%> </a> --%>

              <%--  <a href ="/SectorSalesReport/Detail?dcity=<%:item.DepartCityId %>&acity=<%:item.ArriveCityId %>" class="Details" >  <%: item.SegmentId%> </a> --%>
               
              <%: Html.ActionLink(item.SegmentId.Value.ToString(), "Detail", new { DepartCityId = item.DepartCityId, ArriveCityId = item.ArriveCityId, FromDate = Model.FromDate, Todate = Model.ToDate }, new { @class = "Details" })%> 
                </td>
            </tr>
      
     </tbody>
        <%      }%>
        <tbody>
            <tr>


                <% if (Model.SegmentSalesReportList != null)
                   {


                       if (count > 0)
                       {
                %>

                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
                <td>
                    Total Segments:<%:Model.txtSumMainSegment == null ? "" : (Model.txtSumMainSegment).ToString()%>
                </td>
                <%}
                   }
                %>
            </tr>
        </tbody>

        <%--new code--%>
         <% if (Model.SegmentSalesReportList != null && Model.SegmentSalesReportList.Count() > 0)
            { %>
           
        <% }
            else
            {
                Html.RenderPartial("NoRecordsFound");
            } 
                %>
<%--..............................................................--%>


        <%}%>

        <%} %>
    </table>


   




  
</div>

