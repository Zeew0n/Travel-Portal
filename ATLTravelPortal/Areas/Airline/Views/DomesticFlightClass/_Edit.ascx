<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<ATLTravelPortal.Areas.Airline.Models.AirlineFlighClassViewModel>" %>

   <% Html.EnableClientValidation(); %>
    <% using (Html.BeginForm("Edit","DomesticFlightClass", FormMethod.Post))
       {%>
        <%: Html.ValidationSummary(true)%>
 

  <div class="pageTitle">
        <ul class="buttons-panel">
            <li>
                <div id="loadingIndicator">
                </div>
            </li>
            <li><input type="submit" value="Save" />
                </li>
           <%-- <li>
                 <input type="button"  value="Cancel"  /> 
             </li>--%>
        </ul>
        <h3>
            Setup <span>&nbsp;</span><strong> Edit flight Class Definition</strong>
        </h3>
    </div>
           <div class="row-1">
           		
            	<div class="form-box1 round-corner">
                	<div class="form-box1-row">
                        <div class="form-box1-row-content float-left"> 
                                     
                                     <div>
                                    <label> <%: Html.Label("Airline")%></label>
                                        <%: Html.DropDownListFor(model => model.AirlineId, Model.DomesticAirlineList, "--- Select---", new { @disabled = "disabled" })%>
                                          <%: Html.ValidationMessageFor(model => model.AirlineId, "*")%>
                                            <%: Html.HiddenFor(model => model.HFAirlineId)%>
                                              <%: Html.HiddenFor(model => model.FlightClassId,ID)%>
                                 </div>              
                                 
                            </div>                           
                     
                                          
                    </div>
                    
                    <div class="form-box1-row">
                        <div class="form-box1-row-content float-left">    
                                                
                           <div>
                                    <label><%: Html.Label("Code")%></label>
                                        <%: Html.TextBoxFor(model => model.FlightClassCode)%>
                                         <%: Html.ValidationMessageFor(model => model.FlightClassCode, "*")%>
                                 </div>                                 
                        </div>                        
                  
                        <div class="form-box1-row-content float-left">                            
                               <div>
                                    <label> <%: Html.Label("Type")%></label>
                                    <%: Html.TextBoxFor(model => model.ClassType)%>
                                    <%: Html.ValidationMessageFor(model => model.ClassType, "*")%>
                                 </div>                             
                        </div>                        
                    </div> 
                   <div class="buttonBar">
<input type="submit" value="Save"  />     
<%--<input type="button"  value="Cancel"  />--%>  
                </div>   
                                            
                </div>
            </div>
            <%} %>
     


