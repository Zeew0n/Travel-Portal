<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<ATLTravelPortal.Areas.Airline.Models.AirLineScheduleModel>" %>

  
 <%--Starting of  Region determining All AirLine for particular AirLine Schedule --%>

        <%if (Model.AirLineScheduleList != null)
      {
           %>  

  <div class="box1">
<%var q = (from p in Model.AirLineScheduleList select new { p.AirLineName }).Distinct().ToList(); %> 


 <%--Starting of  Region determining All AirLine for particular AirLine Schedule--%>



<% for (int i = 0; i < q.Count(); i++)
   {%>

 <%var k = (from l in Model.AirLineScheduleList where l.AirLineName == q.ToList()[i].AirLineName select l).OrderBy(x=>x.DepartureCity).ToList(); %>

    
  
<div class="type-option" style=" margin-bottom:-10px; margin-top:15px;"><label></label> 
          <h5>  <a id="displayUserinfo_<%:q.ToList()[i].AirLineName%>" href="javascript:toggle('<%:q.ToList()[i].AirLineName%>');"><% =k.ElementAtOrDefault(0).AirLineName%></h5></a>
                  
                  </div>
         <div class="row2">
          <div class="row3">
         <div class="col4">Departure City</div>
          <div class="col4">Destination City</div>
                            
           <div class="col4">FlightNumber</div>
            <div class="col4"></div>
             <div class="col4"></div>
             <div class="col5"></div>
         </div>

<div id="toggleUserinfo_<%:q.ToList()[i].AirLineName%>" style="display: none">
 <% for (int m = 0; m < k.Count(); m++)
    { %>

          <%--Starting of  Region determining AirLine for particular AirLine Schedule--%>

        <div class="search-details">
        
           
             <div class="heading-going">
         
              
            </div>



            <div class="info">
                <div class="row3">
               <div class="col4">
                        <ul class="inline">
                           
                            <li class="width">
                               <strong> <%:k[m].DepartureCity%></strong>
                              </li>
                        </ul>
                       
                    </div>
             
                    <div class="col4">
                        <ul class="inline">
                         
                            <li class="width">
                                <strong><%:k[m].DestinationCity%></strong>
                               </li>
                        </ul>
                       
                    </div>
                    <div class="col4">
                        <ul class="inline">
                            <li class="width"><strong> <%:k[m].FlightNumber%></strong></li>
                           
                        </ul>
                       
                    </div>
                  <%--  <div class="col1">
                        <ul class="inline">
                            <li class="width"><strong>Fare:</strong></li>
                            <li class="width">
                                <%:k[m].Fare%>
                               </li>
                        </ul>
                       
                    </div>--%>
                    <div class="col4">
                        <ul class="inline">
                            
                            <li class="width">
                                  <a href="/Airline/AirLineSchedule/Edit/<%: k[m].ScheduleId %>" class="edit" title="Edit"></a>
                                 
                                </li>
                        </ul>
                      

                    </div>
                     <div class="col4">
                      <ul class="inline">
                          
                            <li class="width">
                                   <a href="/Airline/AirLineSchedule/Delete/<%:k[m].ScheduleId %>" class="delete" title="Delete" id="de<%: k[m].ScheduleId %>" onclick="return confirm('Are you sure  want to delete?');"></a>

                                </li>
                        </ul>
                     </div>
                </div>
              
            </div>
           
            
           
        </div>

     <%--End of  Region determining deal AirLine for particular AirLine Schedule--%>



     <%}
    %>
     </div>  
   </div>
   

  <%}
      %>
    <%--End of  Region determining All AirLine for particular AirLine Schedule--%>
   
   
     </div>
     <%} %>
        
<script type="text/javascript">
    function toggle(user_id) {
        e = document.getElementById('toggleUserinfo_' + user_id);
        a = document.getElementById('displayUserinfo_' + user_id);
        if (e.style.display == 'block') {
            e.style.display = 'none';

        }
        else {
            e.style.display = 'block';

        }
    }
            
              </script>


