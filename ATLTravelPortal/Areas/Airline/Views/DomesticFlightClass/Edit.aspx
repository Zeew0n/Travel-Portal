<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/AirlineMain.Master" 
Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Airline.Models.AirlineFlighClassViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Edit flight Class Definition
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

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
    <% using (Html.BeginForm("Edit", "DomesticFlightClass", FormMethod.Post))
       {%>
        <%: Html.ValidationSummary(true)%>
           <div class="row-1">
           		
            	<div class="form-box1 round-corner">
                	<div class="form-box1-row">
                        <div class="form-box1-row-content float-left">                            
                                <div>
                                    <label><%: Html.LabelFor(model => model.FlightClassCode)%></label>
                                        <%: Html.TextBoxFor(model => model.FlightClassCode)%>
                                         <%: Html.ValidationMessageFor(model => model.FlightClassCode, "*")%>
                                 </div> 
                            </div>                           
                     
                        <div class="form-box1-row-content float-right">                            
                                <div>
                                    <label>    <%: Html.LabelFor(model => model.ClassName)%></label>
                                    <%: Html.TextBoxFor(model => model.ClassName)%>
                                     <%: Html.ValidationMessageFor(model => model.ClassName, "*")%>
                                </div>                            
                        </div>                        
                    </div>
                    
                    <div class="form-box1-row">
                        <div class="form-box1-row-content float-left">                            
                               <div>
                                    <label> <%: Html.LabelFor(model => model.FlightTypeId)%></label>
                                        <%: Html.DropDownListFor(model => model.FlightTypeId, Model.FlightTypList, "--- Select---")%>
                                            <%: Html.ValidationMessageFor(model => model.FlightTypeId, "*")%>
                                 </div>                             
                        </div>                        
                  
                        <div class="form-box1-row-content float-right">                            
                               <div>
                                    <label> <%: Html.LabelFor(model => model.ClassType)%></label>
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
     
</div>
</div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="CssContent" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
</asp:Content>
