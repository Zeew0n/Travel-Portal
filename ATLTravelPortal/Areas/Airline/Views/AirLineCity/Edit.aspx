<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/AirlineMain.Master" Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Airline.Models.AirLineCityModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Edit
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <% Html.EnableClientValidation(); %>
    <% using (Html.BeginForm()) {%>
        <%: Html.ValidationSummary(true) %>
        <div class="pageTitle">
        <ul class="buttons-panel">
            <li>
                <div id="loadingIndicator">
                </div>
            </li>
            <li>
                <input type="submit" value="Save" class="save" /></li>
            <li>
                <input type="button" value="Cancel" class="cancel" onclick="document.location.href='/Airline/AirLineCity/'" />
            </li>
        </ul>
        <h3>
            <a href="#" class="icon_plane">Setup</a> <span>&nbsp;</span><strong>Edit Airline City</strong>
        </h3>
    </div>
           <div class="row-1">
           		
            	<div class="form-box1 round-corner">
                	<div class="form-box1-row">
                        <div class="form-box1-row-content float-left">                            
                                <div>
                                    <label>   <%: Html.LabelFor(model => model.CityCode) %></label>
                                          <%: Html.TextBoxFor(model => model.CityCode) %>
                                            <%: Html.ValidationMessageFor(model => model.CityCode) %>
                                 </div> 
                            </div>                           
                        </div>                        
             
                    <div class="form-box1-row">
                        <div class="form-box1-row-content float-left">                            
                                <div>
                                    <label>    <%: Html.LabelFor(model => model.CityName) %></label>
                                    <%: Html.TextBoxFor(model => model.CityName) %>
                                      <%: Html.ValidationMessageFor(model => model.CityName) %>
                                </div>                            
                        </div>                        
                    </div>
                     <div class="form-box1-row">
                        <div class="form-box1-row-content float-left">                            
                               <div>
                                    <label> <%: Html.LabelFor(model => model.AirlineCityTypId)%></label>
                                        <%: Html.DropDownListFor(model => model.AirlineCityTypId, Model.AirlineCityTypList,"--- Select---")%>
                                            <%: Html.ValidationMessageFor(model => model.AirlineCityTypId, "*")%>
                                 </div>                             
                        </div>                        
                    </div>



                      <div class="form-box1-row">
                <div class="form-box1-row-content float-left">
                    <div>
                        <label>
                            <%: Html.LabelFor(model => model.CountryId)%></label>
                        <%: Html.DropDownListFor(model => model.CountryId, Model.CountryList)%>
                        <%: Html.ValidationMessageFor(model => model.CountryId, "*")%>
                    </div>
                </div>
            </div>

                                                       
                </div>
            </div>
    <% } %>

    
<%--    <div class="buttonBar">
<input type="submit" value="Save"  />     <input type="button" onclick="document.location.href='/Airline/AirLineCity/Index'" value="Cancel"  />  
                </div>--%>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="JSContent" runat="server">
</asp:Content>

