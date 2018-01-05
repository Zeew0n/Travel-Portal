<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/AirlineMain.Master" Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Airline.Models.AirlineCappingModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Create
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <% Html.EnableClientValidation(); %>
    <% using (Html.BeginForm()) {%>
        <%: Html.ValidationSummary(true) %>
          <div class="row-1">
           		
                 <div class="pageTitle">
        <ul class="buttons-panel">
            <li>
                <div id="loadingIndicator">
                </div>
            </li>
            <li><input type="submit" value="Create"  />     <input type="button" class="linkButton" onclick="document.location.href='/Airline/AirlineCapping/Index'" value="Back to List"/>   

            </li>
        </ul>
        <h3>
            <a href="#" class="icon_plane">Setup</a> <span>&nbsp;</span><strong>Airline Capping</strong>
        </h3>
    </div>
            	<div class="form-box1 round-corner">
                <div class="divide-column">
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
                               <%-- <div>
                                    <label>  <%: Html.Label("AirLine") %></label>
                                    <%: Html.DropDownListFor(model => model.AirlineId, new SelectList((List<TravelPortalEntity.Airlines>)ViewData["AirlineList"], "AirlineId", "AirlineName"))%>
                                    <%: Html.ValidationMessageFor(model => model.AirlineId) %>
                                </div> --%>    
                                <div>
                           <%:Html.Label("Airline")%>
                        <%:Html.TextBoxFor(model => model.AirlinesName)%>
                        <%:Html.HiddenFor(model=>model.hdfAirlineName) %>
                     
                    </div>                       
                        </div>                        
                    </div>
                
                 
                    </div>
                    <div class="divide-column">
                  
                    <div class="form-box1-row">
                        <div class="form-box1-row-content float-left">                            
                                <div><label> <%: Html.LabelFor(model => model.TotalTicketNumber) %></label>
                                     <%: Html.TextBoxFor(model => model.TotalTicketNumber) %>
                                        <%: Html.ValidationMessageFor(model => model.TotalTicketNumber) %>
                                </div>                            
                        </div>                        
                    </div>
                    </div>
                                                                         
                </div>
                <div class="buttonBar">
<input type="submit" value="Create"  />     <input type="button" class="linkButton" onclick="document.location.href='/Airline/AirlineCapping/Index'" value="Back to List"/>   
                </div>
            </div>

   

    <% } %>

    <div>
         
      <%--  <%: Html.ActionLink("Back to List", "List") %>--%>
    </div>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="CssContent" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">

<script language="javascript" type="text/javascript">

     $(function () {
        var dates = $("#EffectiveFrom, #ExpireOn").datepicker({
            defaultDate: "+1d",
            changeMonth: true,
            changeYear: true,
            constrainInput: true,
            numberOfMonths: 2,
            disable: true,
            buttonImage: '../../Content/images/calendar.gif',
            minDate: new Date(),
            onSelect: function (selectedDate) {
                var option = this.id == "EffectiveFrom" ? "minDate" : "maxDate",
				instance = $(this).data("datepicker");
                date = $.datepicker.parseDate(
					instance.settings.dateFormat ||
					$.datepicker._defaults.dateFormat,
					selectedDate, instance.settings);
                dates.not(this).datepicker("option", option, date);
            }
        });
    });



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