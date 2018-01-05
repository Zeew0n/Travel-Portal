<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<ATLTravelPortal.Areas.Hotel.Models.HotelItinearyModel>" %>
<%TimeSpan ts = Model.CheckOutDate - Model.CheckInDate;
  int days = ts.Days;
  decimal totalChargableAmount = 0;
%>
<table cellpadding="0" cellspacing="0" width="100%">
    <tr>
        <td>
            <%:Html.HiddenFor(model=>model.BookingRecordId) %>
            <div style="background: #E4F5F8; margin: 0px 0; padding: 5px; border: 1px solid #B6DAF0;">
                <table cellspacing="0" cellpadding="0" width="96%">
                    <tr>
                        <td>
                            <table cellspacing="0" cellpadding="0" border="0" width="100%">
                                <tr>
                                    <td width="70" align="left" valign="top">
                                        <img src="<%=Model.Itineary.HotelImageUrl %>" width="64" height="64" alt="<%=Model.Itineary.HotelName %>" />
                                    </td>
                                    <td valign="top">
                                        <font size="3" face="arial" color="#000000" style="font: bold 16px arial; color: #000000">
                                            <%=Model.Itineary.HotelName %></font>
                                        <br>
                                        <span class="hotelReputation"><span class="<%=Model.Itineary.HotelRating %>"></span>
                                        </span>
                                        <br>
                                        <font size="1" face="arial" color="#000000" style="font: normal 11px arial; color: #000000">
                                            <%=Model.Itineary.HotelAddress %><br />
                                            <%=Model.Itineary.CityName %>
                                            ,<%=Model.Itineary.CountryName %>
                                        </font>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td align="right" valign="top">
                            <%-- <table cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td style="padding-right: 2px">
                                            <img src="http://www.travelnow.com/BU40/_media/icons/car.gif" alt="image" width="30"
                                                height="25">
                                        </td>
                                        <td valign="middle">
                                            <a href="http://travel.ian.com/index.jsp?pageName=carSearch&amp;currencyCode=INR&amp;locale=en_US&amp;cid=55505"
                                                style="font: normal 11px arial" target="_blank">Rent a Car</a>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="padding-right: 2px">
                                            <img src="http://www.travelnow.com/BU40/_media/icons/flight.gif" alt="image" width="30"
                                                height="25">
                                        </td>
                                        <td valign="middle">
                                            <a href="http://travel.ian.com/index.jsp?pageName=airSearch&amp;currencyCode=INR&amp;locale=en_US&amp;cid=55505"
                                                style="font: normal 11px arial" target="_blank">Make Flight Plans</a>
                                        </td>
                                    </tr>
                                </table>--%>
                        </td>
                    </tr>
                </table>
            </div>
            <div style="background: #fef3b8; border: 1px solid #B6DAF0; margin: 5px 0; padding: 5px">
                <p style="font-size: 16px; line-height: 18px; color: #000; font-weight: bold; margin: 0 0 5px 0;
                    padding: 0">
                    YOUR RESERVATION HAS BEEN BOOKED!</p>
                <table cellspacing="0" cellpadding="0" border="0">
                    <tr>
                        <td valign="top">
                            <font size="2" face="arial" color="#000" style="font: bold 12px arial;">Your Itinerary
                                Number:</font>
                        </td>
                        <td valign="top" style="font: bold">
                            <font size="2" face="arial" color="#000" style="font: bold 16px arial;">
                                <%=Model.Itineary.BookingId %></font>
                        </td>
                    </tr>
                  <%--  <tr>
                        <td>
                        </td>
                        <td>
                        </td>
                    </tr>--%>
                    <tr>
                        <td valign="top">
                            <font size="2" face="arial" color="#000000" style="font: bold 12px arial; color: #000000">
                                <a href="http://www.arihantholidays.com" target="_blank">Arihant Holidays</a> <br />Confirmation
                                Number(s): </font>
                        </td>
                        <td valign="top">
                            <font size="2" face="arial" color="#000000" style="font: bold 12px arial; color: #000000">
                                <br/>
                                <%=Model.Itineary.ConfirmationNo %><br />
                            </font>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top">
                            <font size="2" face="arial" color="#000000" style="font: bold 12px arial; color: #000000">
                                Guest Name: </font>
                        </td>
                        <td valign="top">
                            <font size="2" face="arial" color="#000000" style="font: bold 12px arial; color: #000000">
                                <%=Model.Itineary.GuestName %>
                            </font>
                        </td>
                    </tr>
                </table>
                <p style="margin: 0px 0; padding: 0">
                    <font size="1" face="arial" color="#000000" style="font: normal 11px arial; color: #000000">
                        When you contact Customer Service,Please provide the above itinerary number 
                    .</font>
                </p>
            </div>
            <div style="border: #999 1px solid; padding: 0px 0; margin: 0">
                <div style="background: #cccccc; border-top: #999 1px solid; border-bottom: #999 1px solid;
                    margin: 0 0 5px 0; padding: 5px; font: bold 16px arial">
                    RESERVATION DETAILS</div>
                <div style="margin: 10px">
                    <div style="width: 49%; float: left; margin-bottom: 10px;">
                        &nbsp;<font size="2" face="arial" color="#000000" style="font: bold 14px arial; color: #000000">Check
                            In Information</font>
                        <table cellspacing="0" cellpadding="0" border="0" width="100%" style="margin-top: 15px">
                            <tr>
                                <td width="70%" style="padding-bottom: 10px; padding-right: 10px">
                                    <table cellspacing="0" cellpadding="0" width="100%">
                                        <tr>
                                            <td valign="top" width="70">
                                                <font size="2" face="arial" color="#000000" style="font: normal 13px arial; color: #000000">
                                                    Check-in:</font>
                                            </td>
                                            <td valign="top" style="line-height: 12px">
                                                <font size="2" face="arial" color="#000000" style="font: bold 13px arial; color: #000000">
                                                    <%=Model.CheckInDate.ToString("MMM dd yyyy")%></font>
                                                <br>
                                                <font size="1" face="arial" color="#000000" style="font: normal 11px arial; color: #000000">
                                                    (Check in time 12:00 PM)</font>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td valign="top">
                                     
                                    <font size="2" face="arial" color="#000000" style="font: normal 12px arial; color: #000000">
                                         Adults:
                                        <%=Model.NoOfAdult %>
                                      <br />
                                        Child:
                                       <span style="padding-left: 6px">
                                        <%=Model.NoOfChild %> 
                                    </span> 
                                    </font>
                                </td>
                            </tr>
                            <tr>
                                <td width="60%" valign="top" style="padding-right: 10px">
                                    <table cellspacing="0" cellpadding="0" width="100%">
                                        <tr>
                                            <td valign="top" width="70">
                                                <font size="2" face="arial" color="#000000" style="font: normal 13px arial; color: #000000">
                                                    Check-out:</font>
                                            </td>
                                            <td valign="top" style="line-height: 12px">
                                                <font size="2" face="arial" color="#000000" style="font: bold 13px arial; color: #000000">
                                                    <%=Model.CheckOutDate.ToString("MMM dd yyyy")%></font>
                                                <br>
                                                <font size="1" face="arial" color="#000000" style="font: normal 11px arial; color: #000000">
                                                    (Check out time 12:00 PM)</font>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td valign="top" style="line-height: 12px">
                                    &nbsp;
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div style="width: 50%; float: right; margin-bottom: 10px;">
                     <font size="2" face="arial" color="#000000" style="font: bold 14px arial; color: #000000;padding-left: 100px;" >Billing
                            Information</font>
                        <table cellpadding="3" cellspacing="0" border="0" width="100%" style="margin: 10px 0">
                            <tr>
                                <td style="text-align: right;padding-right:5px;">
                                    <font size="2" face="arial" color="#000000" style="font: normal 12px arial; color: #000000">
                                        Billing Name: </font>
                                </td>
                                <td align="left">
                                    <font size="2" face="arial" color="#000000" style="font: bold 12px arial; color: #000000;
                                        text-align: left;">
                                        <%=Model.Itineary.GuestName %></font>
                                </td>
                            </tr>
                            <tr>
                                <td valign="top" style="text-align: right;padding-right:5px;">
                                    <font size="2" face="arial" color="#000000" style="font: normal 11px arial; color: #000000">
                                        Billing Address: </font> 
                                </td>
                                <td align="left">
                                    <font size="2" face="arial" color="#000000" style="font: normal 11px arial; color: #000000;
                                        text-align: left;">
                                        <%=Model.Itineary.GuestAddress %>
                                    </font>
                                </td>
                            </tr>
    <tr>
        <td style="text-align: right;padding-right:5px;">
            <font size="2" face="arial" color="#000000" style="font: normal 11px arial; color: #000000">
                Phone Number: </font> 
        </td>
        <td align="left">
            <font size="2" face="arial" color="#000000" style="font: normal 11px arial; color: #000000;
                text-align: left;">
                <%=Model.Itineary.GuestPhoneNo %>
            </font>
        </td>
    </tr>
    <tr>
        <td style="text-align: right;padding-right:5px;">
            <font size="2" face="arial" color="#000000" style="font: normal 11px arial; color: #000000">
                Email Address: </font> 
        </td>
        <td align="left">
            <font size="2" face="arial" color="#000000" style="font: normal 11px arial; color: #000000">
                <%=Model.Itineary.GuestEmail %></font>
        </td>
    </tr>
</table>
</div>
<div style="background: #cccccc; border-top: #999 1px solid; border-bottom: #999 1px solid;
    margin: 0 -10px 5px -10px; padding: 5px; font: bold 12px arial; overflow: hidden;
    height: 15px; clear: both;">
    Room Rate Detail
</div>
<table cellspacing="0" cellpadding="0" border="0" width="96%" class="printOption">
    <tr>
        <%
            var rateIndex = 1; 
           foreach (var item1 in Model.RoomDetail)
           {%><% if (((rateIndex / 2) - 1) == 1)
                                 {%></tr>
    <tr>
        <%} %>
        <td valign="top" width="50%" style="padding-right: 10px">
            <table cellpadding="0" cellspacing="0" width="100%" border="0" style="margin: 0 0 0px 0">
                <tr>
                    <td>
                        <font size="2" face="arial" color="#000000" style="font: bold 14px arial; color: #000000">
                            <%=item1.RoomTypeName %></font>
                        <br />
                        <div style="margin: 10px 20px">
                            <table style="width: 100%;">
                                <%foreach (var item in item1.DayRates)
                                  { %>
                                <tr>
                                    <td>
                                        <%=(item.Days).ToString("MMMM dd yyyy")%>
                                    </td>
                                    <td style="text-align: right;">
                                        <%=(item.LowRate + (item1.RoomRate.AgentServiceCharge / days) + (item1.RoomRate.MarkupRatePerRoom / days)).ToString("N2")%>
                                        <font size="1" face="arial" color="#999999" style="font: normal 11px arial; color: #999999">
                                            <%=Model.CurrencyCode%></font>
                                    </td>
                                </tr>
                                <%} %>
                            </table>
                        </div>
                    </td>
                </tr>
            </table>
            <div style="margin: 10px 0; border-top: #999 1px solid">
            </div>
            <table cellpadding="0" cellspacing="0" width="100%" border="0" style="margin: 0 0 0px 0">
                <tr>
                    <td>
                        <font size="2" face="arial" color="#000000" style="font: bold 12px arial; color: #000000">
                            No. of room</font>
                    </td>
                    <td valign="top" align="right">
                        <font size="2" face="arial" color="#000000" style="font: normal 12px arial; color: #000000">
                            <%=item1.NoOfUnits%></font>
                        <br />
                    </td>
                </tr>
            </table>
            <div style="margin: 10px 0; border-top: #999 1px solid">
            </div>
            <table cellpadding="0" cellspacing="0" width="100%" border="0" style="margin: 0 0 0px 0">
                <tr>
                    <td>
                        <font size="2" face="arial" color="#000000" style="font: bold 12px arial; color: #000000">
                            Extra Guest Charges</font>
                    </td>
                    <td valign="top" align="right">
                        <font size="2" face="arial" color="#000000" style="font: normal 12px arial; color: #000000">
                            <%=(item1.RoomRate.ExtraGuestCharges + item1.RoomRate.MarkupExtraGuestCharge).ToString("N2")%></font>
                        <font size="1" face="arial" color="#999999" style="font: normal 11px arial; color: #999999">
                            <%=Model.CurrencyCode%></font>
                        <br>
                    </td>
                </tr>
            </table>
            <div style="margin: 10px 0; border-top: #999 1px solid">
            </div>
            <table cellpadding="0" cellspacing="0" width="100%" border="0" style="margin: 0 0 0px 0">
                <tr>
                    <td>
                        <font size="2" face="arial" color="#000000" style="font: bold 12px arial; color: #000000">
                            Tax Recovery Charges and<br />
                            Service Fees</font>
                    </td>
                    <td valign="top" align="right">
                        <font size="2" face="arial" color="#000000" style="font: normal 12px arial; color: #000000">
                            <%=item1.RoomRate.TotalTaxesAndFees.ToString("N2")%></font> <font size="1" face="arial"
                                color="#999999" style="font: normal 11px arial; color: #999999">
                                <%=Model.CurrencyCode%></font>
                        <br>
                    </td>
                </tr>
            </table>
            <div style="margin: 10px 0; border-top: #999 1px solid">
            </div>
            <table cellpadding="0" cellspacing="0" width="100%" border="0">
                <tr>
                    <td>
                        <font size="2" face="arial" color="#000000" style="font: normal 12px arial; color: #000000">
                            Total </font>
                        <br />
                    </td>
                    <td valign="top" align="right" style="width: 85px;">
                        <font size="2" face="arial" color="#000000" style="font: bold 12px arial; color: #000000">
                            <% decimal total = item1.RoomRate.TotalRoomRate + item1.RoomRate.TotalTaxesAndFees + item1.RoomRate.ExtraGuestCharges + item1.RoomRate.AgentServiceCharge + item1.RoomRate.MarkupRatePerRoom + item1.RoomRate.MarkupExtraGuestCharge;
                               totalChargableAmount += total; %>
                            <%=Math.Ceiling((Convert.ToDecimal( total)))  %></font> <font size="1" face="arial" color="#999999" style="font: normal 11px arial;
                                color: #999999">
                                <%=Model.CurrencyCode%></font>
                    </td>
                </tr>
            </table>
        </td>
        <% if ((rateIndex / 2) == 1)
           {
               rateIndex = 1;%></tr>
    <%} %>
    <% rateIndex++;%>
    <%} %>
    <%if (rateIndex == 1)
      { %>
    </tr><%} %>
</table>
<div style="font-size: 13px; font-weight: bold;">
    Total Charge :
    <%=Math.Ceiling(Convert.ToDecimal(totalChargableAmount.ToString()))%></div>
<div>
    <font size="1" face="arial" color="#000000" style="font: normal 10px arial; color: #000000">
        &nbsp;To view our
        full Terms &amp; Conditions, please go to our <a href="http://www.arihantholidays.com"
            target="_blank">Terms &amp; Conditions</a> page. </font>
</div>
</div>


  <%if(Model.TicketStatusId != 29){ %>
<div style="background: #cccccc; border-top: #999 1px solid; border-bottom: #999 1px solid;
    margin: 0 0 5px 0; padding: 5px; font: bold 12px arial">
    Check-in Instructions</div>
<div style="margin: 10px; color: #000000; font: 12px arial;">
    <p style="padding: 0px 5px 5px;">
        <%=Model.Itineary.CheckInInstructions %>
    </p>
</div>
<div style="background: #cccccc; border-top: #999 1px solid; border-bottom: #999 1px solid;
    margin: 0 0 5px 0; padding: 5px; font: bold 12px arial">
    Cancellation Policy</div>
<div style="margin: 10px;color: #000000; font: 12px arial;">
    <p style="font: normal 11px arial; margin: 0px; padding: 0px 5px 5px; color: #000000;
        line-height: 1.25">
        <%=Model.Itineary.CancellationPolicy %></p>
</div>
 <%} %>
</div> </td> </tr> </table> 