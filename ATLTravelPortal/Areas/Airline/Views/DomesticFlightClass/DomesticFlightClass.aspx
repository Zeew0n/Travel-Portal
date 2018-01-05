<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/AirlineMain.Master"
 Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Airline.Models.AirlineFlighClassViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Domestic Flight Class Definition
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

         <div class="pageTitle">
        <ul class="buttons-panel">
            <li>
                <div id="loadingIndicator">
                </div>
            </li>
            <li><input type="submit" value="Update" />
                </li>
            <li>
                 <input type="button"  value="Cancel"  />              </li>
        </ul>
        <h3>
            Setup <span>&nbsp;</span><strong> Domestic Flight Class Definition</strong>
        </h3>
    </div>

            <div class="row-1  mrg-top-20">
                    <div class="form-box1 round-corner">
                      <h3> Domestic Airline </h3>



                       <% using (Html.BeginForm("ViewDomesticFlightClass", "DomesticFlightClass", FormMethod.Post))
                          {%>
     
                	<div class="form-box1-row">
                        <div class="form-box1-row-content float-left">                            
                                 <div>
                                    <label></label>
                                        <%: Html.DropDownListFor(model => model.AirlineId, Model.DomesticAirlineList, "--- Select---", new { onchange = "this.form.submit();" })%>        
                                 </div>   
                            </div>                           
                                      
                    </div>
                    <%} %>
                    </div>
                    </div>

                    
                     <%if ((Model.AirlineFlighClass != null) || (Model.ActiveFlightClassForAirline != null))
                       { %>

                    <% Html.EnableClientValidation(); %>
                    <% using (Html.BeginForm("DomesticFlightClass", "DomesticFlightClass", FormMethod.Post))
                       {%>
                        <%: Html.ValidationSummary(true)%>
                        <div class="row-1  mrg-top-20">
                    <div class="form-box1 round-corner">
                    <div class="form-box1-row">
                    
                        <div class="form-box1-row-content float-left">
                                
                            <% foreach (var Class in Model.AirlineFlighClass)
                               { %>
                            <div>
                            
                              <%if ((AirLines.Models.AirLine.AirlineFlighClassExtensionModel.IsActiveAirlineFlightClasses(Class.FlightClassId, Model.ActiveFlightClassForAirline)) == true)
                                { %>
                              <input type="checkbox" name="ChkFlightClassId" value="<%=Class.FlightClassId%>" checked="checked"/>
                              <%}
                                else
                                { %>
                              <input type="checkbox" name="ChkFlightClassId" value="<%=Class.FlightClassId%>"/>
                              <%} %>
                               <label>  <% =Class.FlightClassCode%></label>
                               </div>
                                <%}%>
                                
                                                   
                        </div>      
                   </div>
                   <div id="checkfield" style="display: block;"></div>
                 
                    <div class="form-box1-row">
                        <p class="mrg-lft-130">
                          <input type="submit" value="Update" class="btn1" />  
                           <%: Html.HiddenFor(model => model.AirlineId)%>                                        
                        </p>                        
                    </div>   
                                            
                </div>
            </div>
            <div class="buttonBar">
<input type="submit" value="Update"  />     <input type="button"  value="Cancel"  />  
                </div>
              <%:TempData["Message"]%>
            <%}
                       } %>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="CssContent" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
</asp:Content>
