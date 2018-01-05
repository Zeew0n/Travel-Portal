<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/AirlineMain.Master"
    Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Airline.Models.AirLineScheduleModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Edit
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
                <input type="submit" value="Save"  /></li>
            <li>
               <input type="button" value="Cancel" class="cancel" onclick="document.location.href='/Airline/AirLineSchedule/Index'" />

            </li>
        </ul>
        <h3>
           Setup<span>&nbsp;</span><strong>Domestic Airline Schedule</strong>
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
                            Departure City</label>
                        <%: Html.DropDownListFor(model => model.DepartureCityId, new SelectList((List<TravelPortalEntity.AirlineCities>)ViewData["DepartureCityList"], "CityID", "CityName"))%>
                        <%: Html.ValidationMessageFor(model => model.DepartureCityId)%>
                    </div>
                </div>
                <div class="form-box1-row-content float-right">
                    <div>
                        <label>
                            Destination City</label>
                        <%: Html.DropDownListFor(model => model.DestinationCityId, new SelectList((List<TravelPortalEntity.AirlineCities>)ViewData["DestinationCityList"], "CityID", "CityName"))%>
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
            <div class="form-box1-row">
                <div class="form-box1-row-content float-left">
                    <%--<div>
                        <label>
                            Fare</label>
                        <%: Html.TextBoxFor(model => model.Fare) %>
                        <%: Html.ValidationMessageFor(model => model.Fare) %>
                    </div>--%>
                </div>
            </div>
            <div class="daysbox">
                <div class="days-title">
                    <strong>Days</strong>
                </div>
                <div class="days-option">
                    <p style="color: Red">
                        <%:TempData["Time"] %>
                        <%:TempData["Cities"]%>
                        <%:TempData["Days"] %></p>
                    <%--<p><%= Html.Label("Daily")%> <%= Html.CheckBox("Daily")%></p>--%>
                    <div class="days-sub-option">
                        <p>
                            <span>
                                <%if (Model.Sunday == true)
                                  { %>
                                <input type="checkbox" checked="checked" name="days" value="1" /><%:Html.Label("Sun") %>
                                <% }
                                  else
                                  {%>
                                <input type="checkbox" name="days" value="1" /><%:Html.Label("Sun") %>
                                <% }
                                %>
                            </span><span>
                                <%if (Model.Monday == true)
                                  { %>
                                <input type="checkbox" checked="checked" name="days" value="2" /><%:Html.Label("Mon") %>
                                <% }
                                  else
                                  {%>
                                <input type="checkbox" name="days" value="2" /><%:Html.Label("Mon") %>
                                <% }
                                %>
                            </span><span>
                                <%if (Model.Tuesday == true)
                                  { %>
                                <input type="checkbox" checked="checked" name="days" value="3" /><%:Html.Label("Tue") %>
                                <% }
                                  else
                                  {%>
                                <input type="checkbox" name="days" value="3" /><%:Html.Label("Tue") %>
                                <% }
                                %>
                            </span><span>
                                <%if (Model.Wednesday == true)
                                  { %>
                                <input type="checkbox" checked="checked" name="days" value="4" /><%:Html.Label("Wed") %>
                                <% }
                                  else
                                  {%>
                                <input type="checkbox" name="days" value="4" /><%:Html.Label("Wed") %>
                                <% }
                                %>
                            </span><span>
                                <%if (Model.Thursday == true)
                                  { %>
                                <input type="checkbox" checked="checked" name="days" value="5" /><%:Html.Label("Thu") %>
                                <% }
                                  else
                                  {%>
                                <input type="checkbox" name="days" value="5" /><%:Html.Label("Thu") %>
                                <% }
                                %>
                            </span><span>
                                <%if (Model.Friday == true)
                                  { %>
                                <input type="checkbox" checked="checked" name="days" value="6" /><%:Html.Label("Fri") %>
                                <% }
                                  else
                                  {%>
                                <input type="checkbox" name="days" value="6" /><%:Html.Label("Fri") %>
                                <% }
                                %>
                            </span><span>
                                <%if (Model.Saturday == true)
                                  { %>
                                <input type="checkbox" checked="checked" name="days" value="7" /><%:Html.Label("Sat") %>
                                <% }
                                  else
                                  {%>
                                <input type="checkbox" name="days" value="7" /><%:Html.Label("Sat") %>
                                <% }
                                %>
                            </span>
                        </p>
                        
                    </div>
                </div>
            </div>
        </div>
    </div>
    
    <div>
           <div class="buttonBar">
<input type="submit" value="Save"  />     <input type="button" onclick="document.location.href='/Airline/AirLineSchedule/Index'" value="Cancel"  />  
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
    <script src="../../../../Scripts/jquery-1.5.1.min.js" type="text/javascript"></script>
    <script src="../../../../Scripts/jquery-ui-1.8.13.custom.min.js" type="text/javascript"></script>
    <script src="../../../../Scripts/ddaccordion.js" type="text/javascript"></script>
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
