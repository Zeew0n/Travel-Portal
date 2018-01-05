<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<ATLTravelPortal.Areas.Airline.Models.OnLineAirlineSettingsModel>" %>

 <div class="contentGrid">
        <% if (Model != null)
           { %>
        <%if (Model.OnLineAirlineSettingList != null && Model.OnLineAirlineSettingList.Count() > 0)
          { %>
        <table cellspacing="0" cellpadding="0" border="0" style="border-collapse: collapse;"
            class="GridView tablesorter" width="100%">
            <thead>
                <tr>
                    <th>
                        SNo
                    </th>
                    <th>
                        Service Provider
                    </th>
                    <th>
                        Code
                    </th>
                    <th>
                        Name
                    </th>
                    <th>
                        
                    </th>
                    
                </tr>
            </thead>
            <tbody>
                <%  var sno = 0;

                    foreach (var item in Model.OnLineAirlineSettingList)
                    {
                        sno++;
                        var classTblRow = (sno % 2 == 0) ? "GridAlter" : "GridItem";
                %>
                <tr class="<%:classTblRow %>" onmouseout="this.className='GridAlter'" onmouseover="this.className='GridRowOver'">
                    <td>
                        <%:sno%>
                    </td>
                    <td>
                        <%: item.ServiceProviderName %>
                    </td>
                    <td>
                        <%: item.AirlineCode %>
                    </td>
                    <td>
                        <%: item.AirlineName %>
                    </td>
                  
                    <td>
                        <a href="/Airline/OnLineAirlineSettings/Delete/<%:item.OnlineAirlineSettingId %>" class="linkButton"
                            onclick="return confirm('Are you sure you want to make [<%: item.AirlineName %>] offline  mode?')"> Make Off-Line</a>
                    </td>
                    
                </tr>
                <% } %>
                <%}
                %>
            </tbody>
            <tfoot>
               
            </tfoot>
        </table>
        <%} %>
      
    </div>

