<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/AirlineMain.Master"
    Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Airline.Models.AirLineScheduleModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Create
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <% Html.EnableClientValidation();%>
    <% using (Html.BeginForm())
       {%>
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
                <input type="button" value="Cancel" class="cancel" onclick="document.location.href='/Airline/AirLineSchedule/'" />
            </li>
        </ul>
        <h3>
            <a href="#" class="icon_plane">Setup</a> <span>&nbsp;</span><strong>Domestic Airline Schedule</strong>
        </h3>
    </div>


    <div class="row-1">
        <div class="form-box1 round-corner">
            <div class="form-box1-row">
                <div class="form-box1-row-content float-left">
                    <div>
                        <label>
                            Airline</label>
                        <%: Html.DropDownListFor(model => model.AirlineId, new SelectList((List<TravelPortalEntity.Airlines>)ViewData["AirLinelist"], "AirlineId", "AirlineName"))%>
                        <%: Html.ValidationMessageFor(model => model.AirlineId) %>
                    </div>
                </div>
                <div class="form-box1-row-content float-right">
                    <div>
                        <label>
                            Flight Number</label>
                        <%: Html.TextBoxFor(model => model.FlightNumber) %>
                        <%: Html.ValidationMessageFor(model => model.FlightNumber) %>
                    </div>
                </div>
            </div>
            <div class="form-box1-row">
                <div class="form-box1-row-content float-left">
                    <div>
                        <label>
                            From</label>
                        <%--<%: Html.DropDownListFor(model => model.DepartureCityId, new SelectList((List<AirLines.DataModel.AirlineCities>)ViewData["DepartureCityList"], "CityID", "CityName"))%>--%>
                        <%: Html.DropDownListFor(model => model.DepartureCityId,  (SelectList)ViewData["DepartureCityList"])%>
                        <%: Html.ValidationMessageFor(model => model.DepartureCityId)%>
                    </div>
                </div>
                <div class="form-box1-row-content float-right">
                    <div>
                        <label>
                            To</label>
                        <%--<%: Html.DropDownListFor(model => model.DestinationCityId, new SelectList((List<AirLines.DataModel.AirlineCities>)ViewData["DestinationCityList"], "CityID", "CityName"))%>--%>
                        <%: Html.DropDownListFor(model => model.DestinationCityId, (SelectList)ViewData["DepartureCityList"])%>
                        <%: Html.ValidationMessageFor(model => model.DestinationCityId) %>
                    </div>
                </div>
            </div>
            <div class="form-box1-row">
                <div class="form-box1-row-content float-left">
                    <div>
                        <label>
                            Departure Time</label>
                        <%: Html.TextBoxFor(model => model.DepartureTime)%>
                        <%: Html.ValidationMessageFor(model => model.DepartureTime) %>
                    </div>
                </div>
                <div class="form-box1-row-content float-right">
                    <div>
                        <label>
                            Arrival Time</label>
                        <%: Html.TextBoxFor(model => model.ArrivalTime)%>
                        <%: Html.ValidationMessageFor(model => model.ArrivalTime) %>
                    </div>
                </div>
            </div>
            <%--<div class="form-box1-row">
                        <div class="form-box1-row-content float-left">                            
                                <div><label>Fare</label>   
                                    <%: Html.TextBoxFor(model => model.Fare) %>
                                      <%: Html.ValidationMessageFor(model => model.Fare) %>   
                                </div>                            
                        </div>                      
                    </div>--%>
            <div class="daysbox">
                <div class="days-title">
                    <strong>Days</strong>
                </div>
                <div class="days-option">
                    <p>
                        <%= Html.Label("Daily")%>
                        <%= Html.CheckBox("Daily")%></p>
                    <p style="color: Red">
                        <%:TempData["Time"] %>
                        <%:TempData["Cities"]%>
                        <%:TempData["Days"] %>
                        <%: TempData["Times"]%></p>
                    <div class="days-sub-option">
                        <p>
                            <span>
                                <%= Html.CheckBox("Sunday") %><%= Html.Label("Sun") %></span> <span>
                                    <%= Html.CheckBox("Monday")%><%= Html.Label("Mon")%></span> <span>
                                        <%= Html.CheckBox("Tuesday")%>
                                        <%= Html.Label("Tue")%></span> <span>
                                            <%= Html.CheckBox("Wednesday")%><%= Html.Label("Wed")%></span> <span>
                                                <%= Html.CheckBox("Thrusday")%>
                                                <%= Html.Label("Thu")%></span> <span>
                                                    <%= Html.CheckBox("Friday")%><%= Html.Label("Fri")%></span>
                            <span>
                                <%= Html.CheckBox("Saturday")%><%= Html.Label("Sat")%></span>
                        </p>
                    </div>
                </div>
            </div>
        </div>
         <div class="buttonBar">
<input type="submit" value="Save"  />     <input type="button" onclick="document.location.href='/Airline/AirLineSchedule/'" value="Cancel"  />  
                </div>
    </div>
   
    <% } %>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CssContent" runat="server">
 <style type="text/css">
        /* css for timepicker */
        .ui-timepicker-div .ui-widget-header
        {
            margin-bottom: 8px;
        }
        .ui-timepicker-div dl
        {
            text-align: left;
        }
        .ui-timepicker-div dl dt
        {
            height: 25px;
        }
        .ui-timepicker-div dl dd
        {
            margin: -25px 0 10px 65px;
        }
        .ui-timepicker-div td
        {
            font-size: 90%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
    <script src="../../../../Scripts/jquery.ui.timepicker.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript">

        $(document).ready(function () {
            $('#Daily').click(function () {
                $('#Daily').is(':checked') ? ($("input:checkbox").attr('checked', 'true')) : ($("input[type='checkbox']").removeAttr('checked'));

            });

            $("#DepartureTime").timepicker({
                ampm: false,
                timeFormat: 'hh:mm'
            });

            $("#ArrivalTime").timepicker({
                ampm: false,
                timeFormat: 'hh:mm'
            });
        });
    </script>
   
</asp:Content>
