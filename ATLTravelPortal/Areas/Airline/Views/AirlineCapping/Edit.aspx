<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/AirlineMain.Master" Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Airline.Models.AirlineCappingModel>" %>

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
                <input type="button" value="Cancel" class="cancel" onclick="document.location.href='/Airline/AirlineCapping/Index'" />
            </li>
        </ul>
        <h3>
            Setup <span>&nbsp;</span><strong>Create Airport Information</strong>
        </h3>
    </div>
           <div class="row-1">
           		
            	<div class="form-box1 round-corner">
                	<div class="form-box1-row">
                        <div class="form-box1-row-content float-left">                            
                                <div>
                                    <label> <%: Html.Label("GDS") %></label>
                                       <%: Html.DropDownListFor(model => model.ServiceProviderId, new SelectList((List<TravelPortalEntity.ServiceProviders>)ViewData["GDSList"], "ServiceProviderId", "ServiceProviderName"))%>
                                        <%: Html.ValidationMessageFor(model => model.ServiceProviderId) %>
                                 </div> 
                            </div>                           
                        </div>                        
             
                    <div class="form-box1-row">
                        <div class="form-box1-row-content float-left">                            
                                <%--<div>
                                    <label>  <%: Html.Label("AirLine") %></label>
                                    <%: Html.DropDownListFor(model => model.AirlineId, new SelectList((List<TravelPortalEntity.Airlines>)ViewData["AirlineList"], "AirlineId", "AirlineName"))%>
                                    <%: Html.ValidationMessageFor(model => model.AirlineId) %>
                                </div> --%>
                                 <div>
                           <%:Html.Label("Airline")%>
                        <%:Html.TextBoxFor(model => model.AirlinesName)%>
                        <%:Html.HiddenFor(model => model.hdfAirlineName)%>
                         <%: Html.ValidationMessageFor(model => model.AirlinesName)%>
                     
                    </div>                            
                        </div>                        
                    </div>
                    <div class="form-box1-row">
                        <div class="form-box1-row-content float-left">                            
                                <div><label> <%: Html.LabelFor(model => model.TotalTicketNumber) %></label>
                                     <%: Html.TextBoxFor(model => model.TotalTicketNumber) %>
                                        <%: Html.ValidationMessageFor(model => model.TotalTicketNumber) %>
                                </div>                            
                        </div>                        
                    </div>
                    <div class="form-box1-row">
                        <p class="mrg-lft-130">
                                                     
                        </p>                        
                    </div>  
                                                       
                </div>
                <div class="buttonBar">
<input type="submit" value="Save"  />    
 <input type="button"  onclick="document.location.href='/Airline/AirlineCapping/Index'" value="Cancel"  />  
                </div>
            </div>

   

    <% } %>

  
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="CssContent" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
    <script src="../../../../Scripts/jquery-1.5.1.min.js" type="text/javascript"></script>
    <script src="../../../../Scripts/jquery-ui-1.8.13.custom.min.js" type="text/javascript"></script>
<script language="javascript" type="text/javascript">

   



    ///////////////////////////////////////// Autocomplete ////////////////////////////////////////////////
    $(document).ready(function () {

        $(function () {
            $("#AirlinesName").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: "/Airline/AirlineCapping/FindAirline", type: "POST", dataType: "json",
                        data: { searchText: request.term, maxResult: 5 },

                        success: function (data) {
                            response($.map(data, function (item) {
                                return { label: item.AirlineName + " (" + item.AirlineCode + ")", value: item.AirlineName, id: item.AirlineId }
                            }))
                        }
                    });
                },
                width: 150,
                select: function (event, ui) {
                    //                        $("#AirlinesName").val(ui.item.id);
                    $("#hdfAirlineName").val(ui.item.id);



                }

            });
        });



    });


    /////////////////////////////////////////End  Autocomplete ////////////////////////////////////////////////


    </script>
</asp:Content>

