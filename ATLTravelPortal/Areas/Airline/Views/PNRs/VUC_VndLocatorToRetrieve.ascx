<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<ATLTravelPortal.Areas.Airline.Models.PNRRetrieveResult>" %>

<%-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@  Seat Sell Starts @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@ --%>
    <%
        if (Model.VendorLocatorList != null && Model.VendorLocatorList.Count() > 0)
        {
    %>
    <div class="box1">
        <h3 style="background-color: #EDF3F9; padding: 3px 5px;">
            VendorLocator To Retrieve
        </h3>
        <div class="form-box3 ">
        </div>
    </div>
     <div class="contentGrid">  
   <%-- <div class="ledger_subtable create_tbl" style="border: 1px solid #ccc;">--%>
        <%--<table width="100%" class="data-table">--%>
         <table cellspacing="0" cellpadding="0" border="0" style="border-collapse: collapse;"
            class="GridView" width="100%">
            <thead>
            <tr>
            <th>
             SNo
            </th>
                <th>
                    GDSReferenceNumber
                </th>
                <th>
                    Passenger Name
                </th>
                <th>
                    Sector
                </th>
                <th>
                    Action
                </th>
            </tr>
            </thead>
            <%                
            var sno = 0;
            foreach (var toRetrieve in Model.VendorLocatorList)
                {
                    sno++;
                    var classTblRow = (sno % 2 == 0) ? "GridAlter" : "GridItem";
                     %>
           <%-- <tr>--%>

          
                   
            <tr id="tr_<%= sno %>"  class="<%: classTblRow %>" onmouseover="this.className='GridRowOver'" onmouseout="this.className='<%= classTblRow %>'">
            <td>
                    <%:sno%>
                </td>
                <td>
                    <%: toRetrieve.GDSReferenceNumber%>
                </td>
                <td>
                    <%: toRetrieve.PassengerName%>
                </td>
                <td>
                    <%: toRetrieve.Sector%>
                </td>
                <td>
                   <%-- <a href="/Airline/PNRs/Update/<%:toRetrieve.GDSRefrenceNumber %>">Retrieve</a>--%>
                    <a href="/Airline/PNRs/Update/<%:toRetrieve.GDSReferenceNumber %>">Retrieve</a>
                </td>
            </tr>
            <%} %>




              <%------------------------  Data for paging ------------------------%>
         <% int numberOfPage =Int32.Parse(ViewData["TotalPages"].ToString());
                       int currentPage = Int32.Parse(ViewData["CurrentPage"].ToString());%> 
          <%------------------------End  Data for paging ------------------------%>




        </table>
    </div>


     <table class="grid_tbl paging" border="0" width="100%">
        <tr>
            <td>
                
                 <%=Ajax.ActionLink("<<First", "Index", new { controller = "PNRs", action = "Index", pageNo = 1 },
                                       new AjaxOptions() { UpdateTargetId = "PagingResultPlaceholder", OnBegin = "beginList", OnSuccess = "successList", InsertionMode = InsertionMode.Replace, HttpMethod = "Get" }, new { @class = "btn1" })%>                                                  
 

                 <%=Ajax.ActionLink("Previous", "Index", new { controller = "PNRs", action = "Index", pageNo = currentPage, flag = 1 },
                                      new AjaxOptions() { UpdateTargetId = "PagingResultPlaceholder", OnBegin = "beginList", OnSuccess = "successList", InsertionMode = InsertionMode.Replace, HttpMethod = "Get" }, new { @class = "btn1" })%>                                                  
 
                        &nbsp;&nbsp;Page&nbsp;&nbsp;<%=currentPage%>&nbsp;of &nbsp;<%=numberOfPage%>&nbsp;&nbsp;
                  <%=Ajax.ActionLink("Next", "Index", new { controller = "PNRs", action = "Index", pageNo = currentPage, flag = 2 },
                                          new AjaxOptions() { UpdateTargetId = "PagingResultPlaceholder", OnBegin = "beginList", OnSuccess = "successList", InsertionMode = InsertionMode.Replace, HttpMethod = "Get" }, new { @class = "btn1" })%>                                                  
                     
                 <%=Ajax.ActionLink("Last>>", "Index", new { controller = "PNRs", action = "Index", pageNo = numberOfPage },
                                       new AjaxOptions() { UpdateTargetId = "PagingResultPlaceholder", OnBegin = "beginList", OnSuccess = "successList", InsertionMode = InsertionMode.Replace, HttpMethod = "Get" }, new { @class = "btn1" })%>                                                  
                      
                         
                
            </td>
        </tr>
     </table>


    <%--</div>--%>
    <% 
        }%>
    <%-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@  Vendor Retrieve Starts @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@ --%>

