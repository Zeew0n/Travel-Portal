<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/BusMain.Master" Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Bus.Models.BusPNRModel>" %>

<%@ Import Namespace="ATLTravelPortal.Helpers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Details
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <%Html.RenderPartial("~/Views/Shared/Utility/VUC_MessagePanel.ascx"); %>
    <%if (Model != null)
      { %>
    <%Html.EnableClientValidation(); %>
    <% using (Html.BeginForm())
       { %>
    <div class="pageTitle">
        <ul class="buttons-panel">
            <li>
                <input type="button" onclick="document.location.href='/Bus/UnIssuedTicket/'" value="Back To List" />
            </li>
        </ul>
        <h3>
            <a class="icon_plane" href="#">Unissued Tickets</a> <span>&nbsp;</span><strong>Detail</strong>
        </h3>
    </div>
    <div class="box1">
        <div class="row-1 mrg-top-20">
            <h3>
                Agent Detail</h3>
            <div class="form-box3 round-corner">
                <div class="form-box1-row">
                    <div class="form-box1-row-content float-left">
                        <div>
                            <label>
                               <strong> Agent Name:</strong></label>
                            <%:Model.AgentName %>
                        </div>
                    </div>
                    <div class="form-box1-row-content float-right">
                        <div>
                            <label>
                                <strong>Agent Code:</strong></label>
                            <%:Model.AgentCode %>
                        </div>
                    </div>
                </div>
                <div class="form-box1-row">
                    <div class="form-box1-row-content float-left">
                        <div>
                            <label>
                               <strong>Phone:</strong></label>
                            <%:Model.AgentPhone %>
                        </div>
                    </div>
                    <div class="form-box1-row-content float-right">
                        <div>
                            <label>
                                <strong>Email:</strong></label>
                            <%:Model.AgentEmial %>
                        </div>
                    </div>
                </div>
                <div class="form-box1-row">
                    <div class="form-box1-row-content float-left">
                        <div>
                            <label>
                                <strong>Address:</strong></label>
                            <%:Model.AgentAddress %>
                        </div>
                    </div>
                    <div class="form-box1-row-content float-right">
                        <div>
                        </div>
                    </div>
                </div>
                <div class="form-box1-row" style="border: 1px solid #000000;color:#2B7617;height:25px;font-weight:bold;font-size: 11px;">
                    <div class="form-box1-row-content float-left">
                        <div style="width:250px;">
                            <label>
                                <strong>Credit Limit:</strong></label>
                            <%:Model.AvilableBalance.CreditLimitNPR == null ? "N/A" : Model.AvilableBalance.CreditLimitNPR.Value.ToString("N2")%>
                        </div>
                    </div>
                    <div class="form-box1-row-content float-right">
                        <div style="width:250px;">
                        <label>
                                <strong>Available Balance:</strong></label>
                            <%:Model.AvilableBalance.CurrentBalanceNPR == null ? "N/A" : Model.AvilableBalance.CurrentBalanceNPR.Value.ToString("N2")%>
                        </div>
                    </div>
                </div>
            </div>
            <h3>
                Operator Detail</h3>
            <div class="form-box3 round-corner">
                <div class="form-box1-row">
                    <div class="form-box1-row-content float-left">
                        <div>
                            <label>
                                <strong>Operator Name:</strong></label>
                            <%:Model.OperatorName%>
                        </div>
                    </div>
                    <div class="form-box1-row-content float-right">
                        <div>
                            <label>
                                <strong>Contact Person:</strong></label>
                            <%:Model.OperatorContactPerson%>
                        </div>
                    </div>
                </div>
                <div class="form-box1-row">
                    <div class="form-box1-row-content float-left">
                        <div>
                            <label>
                                <strong>Phone:</strong></label>
                            <%:Model.OperatorPhone%>
                        </div>
                    </div>
                    <%if (Model.OperatorEmail != null)
                      { %>
                    <div class="form-box1-row-content float-right">
                        <div>
                            <label>
                                <strong>Email:</strong></label>
                            <%:Model.OperatorEmail%>
                        </div>
                    </div>
                    <%} %>
                </div>
                <div class="form-box1-row">
                    <div class="form-box1-row-content float-left">
                        <div>
                            <label>
                                <strong>Address:</strong></label>
                            <%:Model.OperatorAddress%>
                        </div>
                    </div>
                    <div class="form-box1-row-content float-right">
                        <div>
                            <label>
                                <strong>Mobile:</strong></label>
                            <%:Model.OperatorMobileNo%>
                        </div>
                    </div>
                </div>
            </div>
            <h3>
                PNR Information</h3>
            <%:Html.HiddenFor(model=>model.BusPNRId) %>
            <div class="form-box3 round-corner">
                <div class="form-box1-row">
                    <div class="form-box1-row-content float-left">
                        <div>
                            <label>
                                <strong>From:</strong></label>
                            <%:Model.FromCityName %>
                        </div>
                    </div>
                    <div class="form-box1-row-content float-right">
                        <div>
                            <label>
                                <strong>To:</strong></label>
                            <%:Model.ToCityName %>
                        </div>
                    </div>
                </div>
                <div class="form-box1-row">
                    <div class="form-box1-row-content float-left">
                        <div>
                            <label>
                                <strong>Title:</strong></label>
                            <%:Model.Prefix %>
                        </div>
                    </div>
                    <div class="form-box1-row-content float-right">
                        <div>
                            <label>
                                <strong>PNR Name:</strong></label>
                            <%:Model.FullName %>
                        </div>
                    </div>
                </div>
                <div class="form-box1-row">
                   <%-- <div class="form-box1-row-content float-left">
                        <div>
                            <label>
                                <strong>Contact Number:</strong></label>
                            <%:Model.PhoneNumber %>
                        </div>
                    </div>--%>
                    <div class="form-box1-row-content float-left">
                        <div>
                            <label>
                                <strong>Contact Number:</strong>
                            </label>
                            <%:Model.MobileNumber %>
                        </div>
                    </div>
                </div>
                <div class="form-box1-row">
                    <div class="form-box1-row-content float-left">
                        <div>
                            <label>
                                <strong>Contact Address:</strong></label>
                            <%:Model.ContactAddress %>
                        </div>
                    </div>
                    <div class="form-box1-row-content float-right">
                        <div>
                            <label>
                                <strong>Email:</strong></label>
                            <%:Model.EmailAddress %>
                        </div>
                    </div>
                </div>
                <div class="form-box1-row">
                    <div class="form-box1-row-content float-left">
                        <div>
                            <label>
                                <strong>Bus Operator:</strong></label>
                            <%:Model.BusMasterName %>
                        </div>
                    </div>
                    <div class="form-box1-row-content float-right">
                        <div>
                            <label>
                                <strong>Bus Category:</strong></label>
                            <%:Model.BusCategoryName %>
                        </div>
                    </div>
                </div>
                <div class="form-box1-row">
                    <div class="form-box1-row-content float-left">
                        <div>
                            <label>
                                <strong>Bus Type:</strong></label>
                            <%:Model.Type %>
                        </div>
                    </div>
                    <%if (Model.BusNo != null)
                      { %>
                    <div class="form-box1-row-content float-right">
                        <div>
                            <label>
                                <strong>Bus No:</strong></label>
                            <%:Model.BusNo%>
                        </div>
                    </div>
                    <%} %>
                </div>
                <div class="form-box1-row">
                    <div class="form-box1-row-content float-left">
                        <div>
                            <label>
                                <strong>Departure Date:</strong></label>
                            <%:TimeFormat.DateFormat( Model.DepartureDate.ToString()) %>
                        </div>
                    </div>
                    <div class="form-box1-row-content float-right">
                        <div>
                            <label>
                                <strong>Departure Time:</strong></label>
                            <%:TimeFormat.GetAMPMTimeFormat( Model.DepartureTime.ToString()) %>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <%:Html.HiddenFor(model=>model.NoOfSeat) %>
   <%-- <%for (int i = 0; i < Model.Passengers.Count; i++)
      { %>
    <div class="row-1 mrg-top-20">
        <h3>
            Traveller Information -
            <%=i+1 %></h3>
        <div class="form-box3 round-corner">
            <div class="form-box1-row">
                <div class="form-box1-row-content float-left">
                    <%:Html.HiddenFor(model=>model.Passengers[i].BusPassengerId) %>
                    <div>
                        <label>
                            <strong>Full Name:</strong>
                        </label>
                        <%:Model.Passengers[i].PassengerName %>
                    </div>
                </div>
                <div class="form-box1-row-content float-right">
                    <div>
                        <label>
                           <strong> Mobile:</strong>
                        </label>
                        <%:Model.Passengers[i].MobileNumber %>
                    </div>
                </div>
            </div>
            <div class="form-box1-row">
                <div class="form-box1-row-content float-left">
                    <div>
                        <label>
                            <strong>Fare:</strong>
                        </label>
                        <%:Model.Passengers[i].Fare%>
                    </div>
                </div>
                <div class="form-box1-row-content float-right">
                    <div>
                        <label>
                            <strong>Pickup Point:</strong>
                        </label>
                        <%:Model.Passengers[i].PickupPoint%>
                    </div>
                </div>
            </div>
            <div class="form-box1-row">
                <div class="form-box1-row-content float-left">
                    <input type="hidden" value="0" name="Adult[0].index"/>
                    <div>
                        <label>
                            <strong>Ticket Number:</strong></label>
                        <%:Model.Passengers[i].TicketNumber%>
                    </div>
                </div>
                <div class="form-box1-row-content float-right">
                    <div>
                        <label>
                            <strong>Seat Number:</strong></label>
                        <%:Model.Passengers[i].SeatNumber%>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <%} %>--%>

    <div class="row-1 mrg-top-20">
        <h3>
            Traveler Information(No. of Passenger: <%:Model.Passengers.Count %>)</h3>
        <div class="form-box3 round-corner">
            <div class="form-box1-row">
                <div class="form-box1-row-content float-left">
                    <%:Html.HiddenFor(model=>model.Passengers[0].BusPassengerId) %>
                    <div>
                        <label>
                            <strong>Full Name:</strong>
                        </label>
                        <%:Model.Passengers[0].PassengerName %>
                    </div>
                </div>
                <div class="form-box1-row-content float-right">
                    <div>
                        <label>
                           <strong> Mobile:</strong>
                        </label>
                        <%:Model.Passengers[0].MobileNumber %>
                    </div>
                </div>
            </div>
            <div class="form-box1-row">
                <div class="form-box1-row-content float-left">
                    <div>
                        <label>
                            <strong>Fare:</strong>
                        </label>
                        <%:Model.Passengers[0].Fare%>
                    </div>
                </div>
                <div class="form-box1-row-content float-right">
                    <div>
                        <label>
                            <strong>Pickup Point:</strong>
                        </label>
                        <%:Model.Passengers[0].PickupPoint%>
                    </div>
                </div>
            </div>
            <div class="form-box1-row">
            <% if (Model.Passengers[0].TicketNumber != null)
               { %>
                <div class="form-box1-row-content float-left">
                    <input type="hidden" value="0" name="Adult[0].index"/>
                    <div>
                        <label>
                            <strong>Ticket Number:</strong></label>
                        <%:Model.Passengers[0].TicketNumber%>
                    </div>
                </div>
                <%} %>
                <% if (Model.Passengers[0].SeatNumber != null)
                   { %>
                <div class="form-box1-row-content float-right">
                    <div>
                        <label>
                            <strong>Seat Number:</strong></label>
                        <%:Model.Passengers[0].SeatNumber%>
                    </div>
                </div>
                <%} %>

            </div>
        </div>
    </div>
    <% } %>
    <%} %>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CssContent" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
</asp:Content>
