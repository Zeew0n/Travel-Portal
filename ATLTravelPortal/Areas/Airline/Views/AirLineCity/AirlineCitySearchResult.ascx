<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<TravelPortalEntity.AirlineCities>>" %>
<%@ Import Namespace="ATLTravelPortal.Helpers"%>
         <%------------------------  Data for paging ------------------------%>
         <% int numberOfPage =Int32.Parse(ViewData["TotalPages"].ToString());
                       int currentPage = Int32.Parse(ViewData["CurrentPage"].ToString());%> 
          <%------------------------End  Data for paging ------------------------%>
<div class="contentGrid">
    <table cellspacing="0" cellpadding="0" border="0" style=" border-collapse:collapse;" class="GridView" width="100%">
        <thead>
            <th>SN</th>
            <th>City Code</th>            
            <th>City Name</th>
            <th>Country Name</th>
            <th>Action</th>
        </thead>
        <%if (Model != null)
          { %>

          <% var sno = ((currentPage - 1)*((int)PageSize.JePageSize));
            foreach (var item in Model)
             {
                 sno++;
                 var classTblRow = (sno % 2 == 0) ? "GridAlter" : "GridItem";
               %>
        <tbody>
           <tr id="tr_<%=sno %>"  class="<%: classTblRow %>" onmouseover="this.className='GridRowOver'" onmouseout="this.className='<%= classTblRow %>'">
               <td>
                    <%:sno%>
                 </td>
                <td>
                     <%: item.CityCode %>
                 </td>
           
                <td>
                    <%: item.CityName %>
                </td>
               
                <td>
                <%: item.CountryId == null ? "" : item.Countries.CountryName %>
                </td>

              

               
                </td>
                <td>
                    <p>
                    <a href="/Airline/AirLineCity/Details/<%: item.CityID %>" class="details" title="details"></a>
                    <a href="/Airline/AirLineCity/Edit/<%: item.CityID %>" class="edit" title="Edit"></a>
                    <a href="/Airline/AirLineCity/Delete/<%: item.CityID %>" class="delete" title="Delete" onclick = "return confirm('Are you sure you want to delete?')"></a></p>
             
                </td>
            </tr>
        </tbody>
        <%}
          } %>
    </table>
</div>


       
      <%if ((bool)TempData["Flag"] == true)
            
         { %>

             <div class="paging">
     <table class="grid_tbl" border="0" width="100%">
        <tr>
            <td>
                <div class="left">
                        <%=Ajax.ActionLink("<<First", "Index", new { controller = "AirLineCity", action = "Index", pageNo = 1, AirlineType = Model.FirstOrDefault().AirlineCityTypeId },
        new AjaxOptions() { UpdateTargetId = "AirlineCity",OnBegin = "beginList", OnSuccess = "successList", InsertionMode = InsertionMode.Replace, HttpMethod = "Get" }, new { @class = "btn1" })%>                                                  
 
                     <%=Ajax.ActionLink("Previous", "Index", new { controller = "AirLineCity", action = "Index", pageNo = currentPage, flag = 1, AirlineType = Model.FirstOrDefault().AirlineCityTypeId },
        new AjaxOptions() { UpdateTargetId = "AirlineCity",OnBegin = "beginList", OnSuccess = "successList", InsertionMode = InsertionMode.Replace, HttpMethod = "Get" }, new { @class = "btn1" })%>                                                  
 
                        &nbsp;&nbsp;Page&nbsp;&nbsp;<%=currentPage%>&nbsp;of &nbsp;<%=numberOfPage%>&nbsp;&nbsp;
                        <%=Ajax.ActionLink("Next", "Index", new { controller = "AirLineCity", action = "Index", pageNo = currentPage, flag = 2, AirlineType = Model.FirstOrDefault().AirlineCityTypeId },
        new AjaxOptions() { UpdateTargetId = "AirlineCity",OnBegin = "beginList", OnSuccess = "successList", InsertionMode = InsertionMode.Replace, HttpMethod = "Get" }, new { @class = "btn1" })%>                                                  
                      
                    <%=Ajax.ActionLink("Last>>", "Index", new { controller = "AirLineCity", action = "Index", pageNo = numberOfPage, AirlineType = Model.FirstOrDefault().AirlineCityTypeId },
        new AjaxOptions() { UpdateTargetId = "AirlineCity",OnBegin = "beginList", OnSuccess = "successList", InsertionMode = InsertionMode.Replace, HttpMethod = "Get" }, new { @class = "btn1" })%>                                                  
                      
                         
                </div>
            </td>
        </tr>
     </table>
</div>

<%} %>
  <div  id="loadingIndicator"></div>
