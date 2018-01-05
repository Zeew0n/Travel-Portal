<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<ATLTravelPortal.Areas.Hotel.Models.CardViewModel>" %>

    <div class="box3">
        <div class="userinfo">
            <h3>
               Registered Card Details
            </h3>
        </div>
        <div class="buttons-panel">
            <%--<ul>
                <li>
                    <input type="submit" value="Save" class="save"  />
                </li>
              
            </ul>--%>
        </div>
    </div>
 <div class="row-1">
           		
            	<div class="form-box1 round-corner">
               
                  <div class="form-box1-row">
                        <div class="form-box1-row-content float-left">                          
                                <div><label>Card Number:</label> 
                                      <%: Model.CardNumber %>
                                </div>                          
                        </div>
                        </div>
                         <div class="form-box1-row">
                        <div class="form-box1-row-content float-left">                          
                                <div><label>Card Type:</label>
                                       <%: Model.CardType %>
                                </div>                          
                        </div>
                    </div>
                    <div class="form-box1-row">
                        <div class="form-box1-row-content float-left">                          
                                <div><label>Card Value:</label>
                                   <%: String.Format("{0:F}", Model.CardValue) %>
                                </div>                          
                        </div></div>
                         <div class="form-box1-row">
                        <div class="form-box1-row-content float-left">                          
                                <div><label>Valid Till:</label>
                                     <%: String.Format("{0:g}", Model.ValidTill) %>
                                </div>                          
                        </div>
                    </div>
                   <%--  <div class="form-box1-row">
                        <div class="form-box1-row-content float-left">                          
                                <div><label>Card Status:</label> 
                                      <%: Model.CardStatus %>
                                </div>                        
                        </div>
                 </div>--%>
                 <div class="form-box1-row">
                        <div class="form-box1-row-content float-left">                          
                                <div><label>Sold To Agent:</label> 
                                      <%: TempData["AgentName"]%>
                                </div>                        
                        </div>
                 </div>
                   <div class="form-box1-row">
                        <div class="form-box1-row-content float-left">                          
                                <div><label>Sold Date:</label> 
                                     <%: TempData["Issue Date"]%>
                                </div>                        
                        </div>
                 </div>
                <div class="form-box1-row">
                        <div class="form-box1-row-content float-left">                          
                                <div><label>Card Rule:</label> 
                                     <%: TempData["Card Rule"]%>
                                </div>                        
                        </div>
                 </div>
               
           </div>
           </div>
