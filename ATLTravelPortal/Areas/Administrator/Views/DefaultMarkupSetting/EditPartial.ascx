<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<ATBackOffice.DataModel.GetAdminAirlineMarkupValueList_Result>>" %>
<%@ Import Namespace="ATBackOffice.Helpers"%>
 <%------------------------  Data for paging ------------------------%>
         <% int numberOfPage =Int32.Parse(ViewData["TotalPages"].ToString());
                       int currentPage = Int32.Parse(ViewData["CurrentPage"].ToString());%> 
          <%------------------------End  Data for paging ------------------------%>

  <div class="contentGrid">    	
   <table cellspacing="0" cellpadding="0" border="0" style="border-collapse: collapse;" class="GridView" width="100%">
        <thead>
          <th>SN</th>   
           <th>Airline Name</th>
            <th>MarkUp Value</th>
        </thead>

         <%
             if (Model != null)
             {
         %>
     <% var sno = ((currentPage - 1)*((int)PageSize.JePageSize));
             var onBlur = "";
        foreach (var item in Model)
        {
            sno++;
            var classTblRow = (sno % 2 == 0) ? "GridAlter" : "GridItem";
            onBlur = "jqueryPostOnBlur('" + item.AirlineId + "','" + item.MarkupValue + "',this,'/DefaultMarkupSetting/MarkupSetting','')";
            %>

       <tbody >
        
        <tr id="tr1"  class="<%: classTblRow %>" onmouseover="this.className='GridRowOver'" onmouseout="this.className='<%= classTblRow %>'">
           
          <td>
                <%:sno%>
            </td>
        
            <td>
                <%: item.AirlineName%>
            </td>
            <td>              
               <%= Html.TextBox("MarkupValue", item.MarkupValue, new { @onblur = onBlur })%>
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
                        <%=Ajax.ActionLink("<<First", "Edit", new { controller = "DefaultMarkupSetting", action = "Edit", pageNo = 1 },
        new AjaxOptions() { UpdateTargetId = "AirlineMarkUp", InsertionMode = InsertionMode.Replace, HttpMethod = "Get" }, new { @class = "btn1" })%>                                                  
 
                     <%=Ajax.ActionLink("Previous", "Edit", new { controller = "DefaultMarkupSetting", action = "Edit", pageNo = currentPage, flag = 1 },
        new AjaxOptions() { UpdateTargetId = "AirlineMarkUp",InsertionMode = InsertionMode.Replace, HttpMethod = "Get" }, new { @class = "btn1" })%>                                                  
 
                        &nbsp;&nbsp;Page&nbsp;&nbsp;<%=currentPage%>&nbsp;of &nbsp;<%=numberOfPage%>&nbsp;&nbsp;
                        <%=Ajax.ActionLink("Next", "Edit", new { controller = "DefaultMarkupSetting", action = "Edit", pageNo = currentPage, flag = 2 },
        new AjaxOptions() { UpdateTargetId = "AirlineMarkUp",InsertionMode = InsertionMode.Replace, HttpMethod = "Get" }, new { @class = "btn1" })%>                                                  
                      
                    <%=Ajax.ActionLink("Last>>", "Edit", new { controller = "DefaultMarkupSetting", action = "Edit", pageNo = numberOfPage },
        new AjaxOptions() { UpdateTargetId = "AirlineMarkUp", InsertionMode = InsertionMode.Replace, HttpMethod = "Get" }, new { @class = "btn1" })%>                                                  
                      
                         
                </div>
            </td>
        </tr>
     </table>
</div>

<%} %>
  <div class="msgbox" id="loadingIndicator"></div>