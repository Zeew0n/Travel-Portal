<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<ATLTravelPortal.Areas.Airline.Models.MasterDealviewModel>" %>
  
  <%if (Model.AssociatedAgentList != null && Model.AssociatedAgentList.Count() > 0)
       {%>

 <div class="box1">
<div class="row2">
<div class="row3">
<div class="col1"><strong>Agent Associate in Deal - <%:Model.AssociatedAgentList.ElementAtOrDefault(0).DealName %></strong></div>
</div>
<%int sn = 1; %>
    <% foreach (var agent in Model.AssociatedAgentList)
                            { %>
 <div class="search-details">
    <div class="info">
                <div class="row3">
               <div class="col1">
                        <ul class="inline">
                            <li class="width">
                               <%:sn++ %>
                               </li>
                                 <li class="width">
                                <strong><%:agent.AgentName %></strong>
                               </li>
                        </ul>
                       
                    </div>
         
                    <div class="col1">
                        <ul class="inline">
                            <li class="width"><strong></strong></li>
                            <li class="width">
                        
                               </li>
                        </ul>
                       
                    </div>
                </div>
              
            </div>
            </div>
                <%} %>
</div>
</div>

 
                      
          <%} else {%>
          No Agent is associated in this deal .
          <%} %>                      