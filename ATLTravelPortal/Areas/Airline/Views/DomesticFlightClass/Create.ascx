<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<ATLTravelPortal.Areas.Airline.Models.AirlineFlighClassViewModel>" %>
 <div class="pageTitle">
        <ul class="buttons-panel">
            <li>
                <div id="loadingIndicator">
                </div>
            </li>
            <li><input type="submit" value="Save" />
                </li>
            <li>
                 <input type="button"  value="Cancel"  />              </li>
        </ul>
        <h3>
            Setup <span>&nbsp;</span><strong> Domestic Flight Class Definition</strong>
        </h3>
    </div>



    <% Html.EnableClientValidation(); %>
    <% using (Html.BeginForm("Create", "DomesticFlightClass", FormMethod.Post,new { @class = "validate" }))
       {%>
        <%: Html.ValidationSummary(true)%>
           <div class="row-1">
           		
            	<div class="form-box1 round-corner">
                	<div class="form-box1-row">
                        <div class="form-box1-row-content float-left"> 
                                                   
                                <div>
                                    <label> <%: Html.LabelFor(model => model.AirlineId)%></label>
                                        <%: Html.DropDownListFor(model => model.AirlineId, Model.DomesticAirlineList)%>
                                            <%: Html.ValidationMessageFor(model => model.AirlineId, "*")%>
                                 </div> 
                            </div>                           
                     
                                           
                    </div>
                    
                    <div class="form-box1-row">
                        <div class="form-box1-row-content float-left">   
                                     
                                     <div>
                                    <label><%: Html.Label("Class Code")%></label>
                                        <%: Html.TextBoxFor(model => model.FlightClassCode, new { @class = "required" })%>
                                         <%: Html.ValidationMessageFor(model => model.FlightClassCode, "*")%>
                                 </div>            
                                                            
                        </div>                        
                  
                        <div class="form-box1-row-content float-left">                            
                               <div>
                                    <label> <%: Html.Label("Class Type")%></label>
                                    <%: Html.TextBoxFor(model => model.ClassType)%>
                                    <%: Html.ValidationMessageFor(model => model.ClassType, "*")%>
                                 </div>                             
                        </div>                        
                    </div> 
                    <div class="buttonBar">
<input type="submit" value="Save"  />     <input type="button"  value="Cancel"  />  
                </div> 
                                            
                </div>
            </div>
            <%} %>

    <%--
  <script type="text/javascript">
      $(document).ready(function () {
          $('.validate').validate();
      });
   </script>--%>