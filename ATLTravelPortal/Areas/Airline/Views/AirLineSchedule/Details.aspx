<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/AirlineMain.Master"
    Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Airline.Models.AirLineScheduleModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Details
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="box3">
        <div class="userinfo">
            <h3>
                Details Domestic Airline Schedule</h3>
        </div>
        <div class="buttons-panel">
            <ul>
                <li>
                    <input type="button" value="Cancel" class="cancel" onclick="document.location.href='/Airline/AirLineSchedule/Index'" />
                    
                    </li>
                
            </ul>
        </div>
    </div>
    <div class="row-1">
        <div class="form-box1 round-corner">
            <div class="form-box1-row">
                <div class="form-box1-row-content float-left">
                    <div>
                        <label>
                            Airline Name:</label>
                        <%: Model.AirLineName %>
                    </div>
                </div>
                <div class="form-box1-row-content float-right">
                    <div>
                        <label>
                            Departure City:</label>
                        <%: Model.DepartureCity %>
                    </div>
                </div>
            </div>
            <div class="form-box1-row">
                <div class="form-box1-row-content float-left">
                    <div>
                        <label>
                            Destination City:</label>
                        <%: Model.DestinationCity %>
                    </div>
                </div>
                <div class="form-box1-row-content float-right">
                    <div>
                        <label>
                            Arrival Time:</label>
                        <%: Model.ArrivalTime %>
                    </div>
                </div>
            </div>
            <div class="form-box1-row">
                <div class="form-box1-row-content float-left">
                    <div>
                        <label>
                            Departure Time:</label>
                        <%: Model.DepartureTime %>
                    </div>
                </div>
                <div class="form-box1-row-content float-right">
                    <div>
                        <label>
                            Flight Number:</label>
                        <%: Model.FlightNumber %>
                    </div>
                </div>
            </div>
           <%-- <div class="form-box1-row">
                <div class="form-box1-row-content float-left">
                    <div>
                        <label>
                            Fare:</label>
                        <%: Model.Fare %>
                    </div>
                </div>
            </div>--%>
        </div>
    </div>
    <%-- <%:Html.ActionLink("Cancel", "Index", new { controller = "AirLineSchedule" }, new { @class = "cancel" })%>--%>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CssContent" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
</asp:Content>
