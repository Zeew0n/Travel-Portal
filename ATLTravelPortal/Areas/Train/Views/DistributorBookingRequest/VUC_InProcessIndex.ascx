<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<ATLTravelPortal.Areas.Train.Models.TrainBookingRequestModel>" %>
<%@ Import Namespace="ATLTravelPortal.Helpers" %>
<div class="rptSearchResult">
    <% if (Model != null)
       { %>
    <%if (Model.PagedList != null && Model.PagedList.Count() > 0)
      { %>
    <div class="contentGrid">
        <table cellspacing="0" cellpadding="0" border="0" style="border-collapse: collapse;"
            class="GridView" width="100%">
            <thead>
                <tr>
                    <th>
                        SNo
                    </th>
                    <th>
                        Passenger Name
                    </th>
                    <th>
                        Sector
                    </th>
                    <th>
                        Departure Date
                    </th>
                    <th>
                        Request Date
                    </th>
                    <th>
                        Request By
                    </th>
                 
                </tr>
            </thead>
            <%var sno = 0;
              foreach (var item in Model.PagedList)
              {
                  sno++;
                  var classTblRow = (sno % 2 == 0) ? "GridAlter" : "GridItem";
            %>
            <tr id="tr_<%= sno %>" class="<%: classTblRow %>" onmouseover="this.className='GridRowOver'"
                onmouseout="this.className='<%= classTblRow %>'">
                <td>
                    <%:item.SNo%>
                </td>
                <td>
                    <%: item.FullName%>
                </td>
                <td>
                    <%: item.Sector%>
                </td>
                <td>
                    <%: ATLTravelPortal.Helpers.TimeFormat.DateFormat(item.DepartureDate.ToString())%>
                </td>
                <td>
                    <%= ATLTravelPortal.Helpers.TimeFormat.DateFormat(item.CreateDate.ToString())%>
                </td>
                <td>
                    <%:  item.CreatedByName%>
                </td>
      
            </tr>
            <% } %>
        </table>
    </div>
    <div class="pager" align="center">
        <%= Html.Pager(ViewData.Model.PagedList.PageSize, ViewData.Model.PagedList.PageNumber, ViewData.Model.PagedList.TotalItemCount, new { FromDate = TimeFormat.DateFormat(Model.FromDate.ToString()), ToDate = TimeFormat.DateFormat(Model.ToDate.ToString()) })%>
    </div>
    <%}
      else
      {
    %>
    No Records Found!
    <%}
    %>
    <%} %>
</div>
