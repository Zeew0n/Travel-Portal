<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/BusMain.Master" Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Bus.Models.BusPNRModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Edit
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
                <input type="submit" class="btn1" value="Update" name="Update" />
                <input type="submit" class="btn1" value="Issue Pnr" name="Issue" />
                 <input type="submit" class="btn1" value="Cancel Pnr" name="Cancel" />
                <%-- <a href="/Bus/UnIssuedTicket/Issue/<%=Model.BusPNRId %>" class="linkButton">Issue</a>--%>
                <input type="button" onclick="document.location.href='/Bus/UnIssuedTicket/'" value="Back to List" />
            </li>
        </ul>
        <h3>
            <a class="icon_plane" href="#">Unissued Tickets</a> <span>&nbsp;</span><strong>Edit</strong>
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
                                <strong>Agent Name:</strong></label>
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
                            <%:Model.EmailAddress %>
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
                    <div class="form-box1-row-content float-right">
                        <div>
                            <label>
                                <strong>Email:</strong></label>
                            <%:Model.OperatorEmail%>
                        </div>
                    </div>
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
                <div class="form-box1-row">
                    <div class="form-box1-row-content float-left">
                        <div>
                            <label>
                                <strong>Hide Service Charge:</strong></label>
                            <%:Html.CheckBoxFor(model=>model.HideServiceCharge) %>
                        </div>
                    </div>
                    <div class="form-box1-row-content float-right">
                        <div>
                           
                               
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
                            <%= Html.DropDownListFor(model=>model.Prefix, Model.Salutations)%>
                            <%:Html.ValidationMessageFor(model=>model.Prefix) %>
                        </div>
                    </div>
                    <div class="form-box1-row-content float-right">
                        <div>
                            <label>
                                <strong>PNR Name:</strong></label>
                            <%:Html.TextBoxFor(model=>model.FullName) %>
                            <%:Html.ValidationMessageFor(model=>model.FullName) %>
                        </div>
                    </div>
                </div>
                <div class="form-box1-row">
                    <div class="form-box1-row-content float-left">
                        <div>
                            <label>
                                <strong>Contact Number:</strong></label>
                            <%:Html.TextBoxFor(model=>model.PhoneNumber) %>
                            <%:Html.ValidationMessageFor(model=>model.PhoneNumber) %>
                        </div>
                    </div>
                    <div class="form-box1-row-content float-right">
                        <div>
                            <label>
                                <strong>Mobile:</strong>
                            </label>
                            <%:Html.TextBoxFor(model=>model.MobileNumber) %>
                            <%:Html.ValidationMessageFor(model=>model.MobileNumber) %>
                        </div>
                    </div>
                </div>
                <div class="form-box1-row">
                    <div class="form-box1-row-content float-left">
                        <div>
                            <label>
                                <strong>Contact Address:</strong></label>
                            <%:Html.TextBoxFor(model=>model.ContactAddress) %>
                            <%:Html.ValidationMessageFor(model=>model.ContactAddress) %>
                        </div>
                    </div>
                    <div class="form-box1-row-content float-right">
                        <div>
                            <label>
                                <strong>Email:</strong></label>
                            <%:Html.TextBoxFor(model=>model.EmailAddress) %>
                            <%:Html.ValidationMessageFor(model=>model.EmailAddress) %>
                        </div>
                    </div>
                </div>
                <div class="form-box1-row">
                    <div class="form-box1-row-content float-left">
                        <div>
                            <label>
                                <strong>Bus Operator:</strong></label>
                            <%= Html.DropDownListFor(model => model.BusMasterId,Model.BusOperators)%>
                            <%:Html.ValidationMessageFor(model=>model.BusMasterId) %>
                        </div>
                    </div>
                    <div class="form-box1-row-content float-right">
                        <div>
                            <label>
                                <strong>Bus Category:</strong></label>
                            <%= Html.DropDownListFor(model => model.BusCategoryId,Model.BusCategories)%>
                            <%:Html.ValidationMessageFor(model=>model.BusCategoryId) %>
                        </div>
                    </div>
                </div>
                <div class="form-box1-row">
                    <div class="form-box1-row-content float-left">
                        <div>
                            <label>
                                <strong>Bus Type:</strong></label>
                            <%:Html.DropDownListFor(model => model.Type,Model.BusTypes)%>
                            <%:Html.ValidationMessageFor(model=>model.Type) %>
                        </div>
                    </div>
                    <div class="form-box1-row-content float-right">
                        <div>
                            <label>
                                <strong>Bus No:</strong></label>
                            <%:Html.TextBoxFor(model=>model.BusNo) %>
                           <%-- <%:Html.ValidationMessageFor(model=>model.BusNo) %>--%>
                        </div>
                    </div>
                </div>
                <div class="form-box1-row">
                    <div class="form-box1-row-content float-left">
                        <div>
                            <label>
                                <strong>Departure Date:</strong></label>
                            <%:Html.TextBoxFor(model=>model.DepartureDate) %>
                            <%:Html.ValidationMessageFor(model=>model.DepartureDate) %>
                        </div>
                    </div>
                    <div class="form-box1-row-content float-right">
                        <div>
                            <label>
                                <strong>Departure Time:</strong></label>
                            <%:Html.TextBoxFor(model=>model.DepartureTime) %>
                            <%:Html.ValidationMessageFor(model=>model.DepartureTime) %>
                        </div>
                    </div>
                </div>
                <div class="form-box1-row">
                    <div class="form-box1-row-content float-left">
                        <div>
                            <label>
                                <strong>Fare:</strong>
                            </label>
                            <%:Html.TextBoxFor(model=>model.Passengers[0].Fare) %>
                            <%:Html.ValidationMessageFor(model => model.Passengers[0].Fare)%>
                        </div>
                    </div>
                    <div class="form-box1-row-content float-right">
                        <div>
                            <label>
                                <strong>Pickup Point:</strong>
                            </label>
                            <%:Html.TextBoxFor(model=>model.Passengers[0].PickupPoint) %>
                            <%:Html.ValidationMessageFor(model => model.Passengers[0].PickupPoint)%>
                        </div>
                    </div>
                </div>
                <div class="form-box1-row">
                    <div class="form-box1-row-content float-left">
                        <div>
                            <label>
                                <strong>Ticket Number:</strong></label>
                            <%:Html.TextBoxFor(model=>model.Passengers[0].TicketNumber) %>
                            <%:Html.ValidationMessageFor(model => model.Passengers[0].TicketNumber)%>
                        </div>
                    </div>
                    <div class="form-box1-row-content float-right">
                        <div>
                            <label>
                                <strong>Seat Number:</strong></label>
                            <%:Html.TextBoxFor(model=>model.Passengers[0].SeatNumber) %>
                          <%--  <%:Html.ValidationMessageFor(model => model.Passengers[0].SeatNumber)%>--%>
                        </div>
                    </div>
                </div>
                
            </div>
        </div>
    </div>
    <%:Html.HiddenFor(model=>model.NoOfSeat) %>
    <%:Html.HiddenFor(model=>model.Passengers[0].BusPassengerId) %>
    <%for (int i = 0; i < Model.Passengers.Count; i++)
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
                        <%:Html.TextBoxFor(model=>model.Passengers[i].PassengerName) %>
                        <%:Html.ValidationMessageFor(model=>model.Passengers[i].PassengerName) %>
                    </div>
                </div>
                <div class="form-box1-row-content float-right">
                    <div>
                        <label>
                            <strong>Mobile:</strong>
                        </label>
                        <%:Html.TextBoxFor(model=>model.Passengers[i].MobileNumber) %>
                        <%:Html.ValidationMessageFor(model => model.Passengers[i].MobileNumber)%>
                    </div>
                </div>
            </div>
            <div class="form-box1-row">
                <div class="form-box1-row-content float-left">
                    <div>
                        <label>
                            <strong>Fare:</strong>
                        </label>
                        <%:Html.TextBoxFor(model=>model.Passengers[i].Fare) %>
                        <%:Html.ValidationMessageFor(model => model.Passengers[i].Fare)%>
                    </div>
                </div>
                <div class="form-box1-row-content float-right">
                    <div>
                        <label>
                            <strong>Pickup Point:</strong>
                        </label>
                        <%:Html.TextBoxFor(model=>model.Passengers[i].PickupPoint) %>
                        <%:Html.ValidationMessageFor(model => model.Passengers[i].PickupPoint)%>
                    </div>
                </div>
            </div>
            <div class="form-box1-row">
                <div class="form-box1-row-content float-left">
                    <input type="hidden" value="0" name="Adult[0].index">
                    <div>
                        <label>
                            <strong>Ticket Number:</strong></label>
                        <%:Html.TextBoxFor(model=>model.Passengers[i].TicketNumber) %>
                        <%:Html.ValidationMessageFor(model => model.Passengers[i].TicketNumber)%>
                    </div>
                </div>
                <div class="form-box1-row-content float-right">
                    <div>
                        <label>
                            <strong>Seat Number:</strong></label>
                        <%:Html.TextBoxFor(model=>model.Passengers[i].SeatNumber) %>
                        <%:Html.ValidationMessageFor(model => model.Passengers[i].SeatNumber)%>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <%} %>
    <% } %>
    <%} %>
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
    <script type="text/javascript">
        $(function () {
            $("#DepartureDate").datepicker(
            {
             changeMonth:true,
             changeYear:true,
            });
        });

        $(function () {
            $("#DepartureTime").timepicker({
                ampm: false,
                timeFormat: 'hh:mm'
            });
        });
    </script>
</asp:Content>
