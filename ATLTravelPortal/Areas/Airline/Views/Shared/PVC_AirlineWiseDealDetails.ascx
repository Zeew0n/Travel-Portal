<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<ATLTravelPortal.Areas.Airline.Models.MasterDealviewModel>" %>

 <%--Starting of  Region determining All deal for particular airline Heading --%>

        <%if (Model.AirlineWiseDealDetailsList != null)
      {
           %>  
            <div class=" row-1 mrg-top-20">
        
          </div>
  <div class="box1">
<%var q = (from p in Model.AirlineWiseDealDetailsList select new { p.DealMasterId, p.DealName }).Distinct().ToList(); %> 


 <%--Starting of  Region determining All deal for particular airline Heading--%>



<% for (int i = 0; i < q.Count(); i++)
   {%>

 <%var k = (from l in Model.AirlineWiseDealDetailsList where l.DealMasterId == q.ToList()[i].DealMasterId select l).OrderBy(qq => qq.DealMasterId).ToList(); %>


 <div class="type-option" style=" margin-bottom:-10px; margin-top:15px;"><label></label> 
 <h5><strong><% =k.ElementAtOrDefault(0).DealName%></strong></a></h5>
</div>


    
  

         <div class="row2">

 <% for (int m = 0; m < k.Count(); m++)
    { %>

     <%--Region determining commission/Markup value is Slab or Percent--%>

     <%string CommissionSlabOrPercent=""; %>
      <%string MarkUpSlabOrPercent=""; %>
       <%if (k[m].isMarkupPercentage == true)
         { %>
         <% MarkUpSlabOrPercent = "Percentage";%>
    <%}
         else
         { %>
         <% MarkUpSlabOrPercent = "Slab";%>
         <%} %>
          <%if (k[m].isCommissionPercentage == true)
         { %>
         <% CommissionSlabOrPercent = "Percentage";%>
    <%}
         else
         { %>
         <% CommissionSlabOrPercent = "Slab";%>
         <%} %>

          <%--End of Region determining commission/Markup value is Slab or Percent--%>






          <%--Starting of  Region determining deal in particular Itenary for particular airline--%>

        <div class="search-details" id="row-<%:k[m].DealDetailsId%>">
           
           
             <div class="heading-going">
               <%:k[m].FromCity%> - <%:k[m].ToCity%>
             
              
            </div>



            <div class="info">
                <div class="row3">
               <div class="col1">
                        <ul class="inline">
                            <li class="width"><strong>Commission:</strong></li>
                            <li class="width">
                                <%:k[m].AdultCommission%>
                                (<%:CommissionSlabOrPercent%>)</li>
                        </ul>
                       
                    </div>
             
                    <div class="col1">
                        <ul class="inline">
                            <li class="width"><strong>MarkUp:</strong></li>
                            <li class="width">
                                <%:k[m].AdultMarkup%>
                                (<%:MarkUpSlabOrPercent%>)</li>
                        </ul>
                       
                    </div>
                    <div class="col1">
                        <ul class="inline">
                            <li class="width"><strong>Deal Applied On:</strong></li>
                            <li class="width">
                                <%:k[m].DealAppliedOnName%>
                              </li>
                        </ul>
                       
                    </div>
                    <div class="col1">
                        <ul class="inline">
                            <li class="width"><strong>Deal Calculate On:</strong></li>
                            <li class="width">
                                <%:k[m].DealCalculateOnName%>
                               </li>
                        </ul>
                       
                    </div>
                    <div class="col4">
                        <ul class="inline">
                            
                            <li class="width">
                                 <%-- <a href="/MasterDealSetUp/EditDeal/<%:k[m].DealDetailsId %>" class="edit" title="EDit Deal For <%:k[m].AirlineName %> - <%:k[m].FromCity %> - <%:k[m].ToCity %>"></a>--%>
                                 
                                </li>
                        </ul>
                    </div>
                     <div class="col4">
                      <ul class="inline">
                          
                            <li class="width">
                            <%-- <%: Html.ActionLink("Delete", "Delete", new { id = k[m].DealDetailsId }, new { @class = "delete", title = "\"" + k[m].AirlineName + " - " + k[m].FromCity + " - " + " - " + k[m].ToCity + "\"" })%>--%>
                                </li>
                        </ul>
                     </div>
                </div>
              
            </div>
           
            
           
        </div>

     <%--End of  Region determining deal inparticular Itenary for particular airline--%>



     <%}
    %>
     
   </div>
   
  <%}
      %>
    <%--End of  Region determining All deal for particular airline Heading--%>
   
   
     </div>
     <%} %>
        
       

