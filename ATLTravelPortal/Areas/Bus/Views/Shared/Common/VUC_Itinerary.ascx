<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<ATLTravelPortal.Areas.Bus.Models.BusPNRModel>" %>
<div>
    <div style="font-size: 20px; font-weight: bold; text-align: center;">
        ONLINE BUS TICKET (अनलाइन बस टिकट)
    </div>
    <%:Html.HiddenFor(m=>m.BusPNRId) %>
    <div style="background: #E4F5F8; margin: 0px 0; padding: 5px; border: 1px solid #B6DAF0;">
        <table width="96%" cellspacing="0" cellpadding="0">
            <tbody>
                <tr>
                    <td valign="top">
                        <%:Model.AgentName %>
                        <br />
                        <font size="1" face="arial" color="#000000" style="font: normal 11px arial; color: #000000">
                            <%:Model.AgentAddress %><br />
                            Email:
                            <%:Model.AgentEmial %>
                        </font>
                    </td>
                    <td>
                    </td>
                    <td align="right" valign="top" style="font-weight: bold;">
                        Contact<br />
                        <span style="font: normal 11px arial; color: #000000">Ph.
                            <%:Model.AgentPhone %><br />
                        </span>
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
    <div style="background: #fef3b8; border: 1px solid #B6DAF0; margin: 5px 0; padding: 5px">
        <table width="96%" cellspacing="0" cellpadding="0" border="0">
            <tbody>
                <tr>
                    <td valign="top" style="font: bold 12px arial;">
                        <span style="font: normal 15px arial; color: #000000">
                            <%:Model.OperatorName %>
                        </span>
                        <br />
                        <font size="1" face="arial" color="#000000" style="font: normal 11px arial; color: #000000">
                            <%:Model.OperatorAddress %><br />
                            Email:
                            <%:Model.OperatorEmail %>
                        </font>
                    </td>
                    <td valign="top" style="font: bold; text-align: right;">
                        <font size="2" face="arial" color="#000" style="font: bold 16px arial;">Contact</font><br />
                        <span style="font: normal 11px arial; color: #000000">Ph.
                            <%:Model.OperatorPhone %><br />
                            <%:Model.OperatorMobileNo %></span>
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
    <div style="border: #999 1px solid; padding: 0px 0; margin: 0">
        <div style="background: #cccccc; border-top: #999 1px solid; border-bottom: #999 1px solid;
            margin: 0 0 5px 0; padding: 5px; font: bold 12px arial;">
            Reservation Details</div>
        <div style="margin: 5px; font: bold 13px arial;">
            <div style="width: 49%; float: left; margin-bottom: 10px;">
                Itineary Number(यात्रा कोड नं.):<%:Model.ItinearyNumber %>
                <br />
                Bus Number(बस नं.):
                <%:Model.BusNo %><br />
                Seat Number(सिट नं.):
                <%:Model.SeatNumber %>
                <br />
                Booking Date(बुकिंग मिति):
                <%:Model.BookingDate %>
            </div>
            <div style="width: 49%; float: right; margin-bottom: 10px;">
                From:
                <%:Model.FromCityName %>
                <br />
                To:
                <%:Model.ToCityName %>
                <br />
                Depature Date(प्रस्थान मिति):<%:Model.DepartureDate.ToShortDateString() %>
                <br />
                Depature Time(बस छुट्ने समय):
                <%:Model.DepartureTime %>
                <br />
            </div>
        </div>
        <div style="background: #cccccc; border-top: #999 1px solid; border-bottom: #999 1px solid;
            margin: 0 0 5px 0; padding: 5px; font: bold 12px arial; clear: both; overflow: hidden;">
            <div style="width: 50%; float: left;">
                Passenger Detail( यात्रु विवरण )</div>
            <div style="width: 50%; float: left;">
                </div>
        </div>
        <div style="background: #ffffff; margin: 10px; color: #000000; font: 12px arial;">
            <div style="width: 50%; float: left;">
                Name:
                <%:Model.PassengerName %><br />
                Address:
                <%:Model.ContactAddress%><br />
                Mobile No:
                <%:Model.MobileNumber%><br />
                Pick up Points:
               <b> <%:Model.PickUpPouints %></b><br />
            </div>
            <div style="width: 50%; float: left;font:bold 12px arial;">
               <div style="width:100px;float:left;"> Rate:</div> <div><%:Model.DisRate %></div>
                <div style="width:100px;float:left;">Number:</div><div><%:Model.NoOfSeat %></div>
                <div style="width:100px;float:left;">Total:</div><div><%:Model.TotalAmount %></div>
                <div style="width:100px;float:left;">Service Charge:</div><div><%:Model.ServiceCharge%></div>
                <div style="width:100px;float:left;">Grand Total:</div><div><%:Model.GrandTotal %></div>
            </div>
        </div>
        <div style="overflow:hidden;clear:both; background: #cccccc; border-top: #999 1px solid; border-bottom: #999 1px solid;
            margin: 0 0 5px 0; padding: 5px; font: bold 12px arial">
            Fare Rule (नियमहरु) </div>
        <div style="margin: 10px; color: #000000; font: 10px arial;">
            <%:MvcHtmlString.Create(Model.FareRule) %>
        </div>
        <div style="background: #cccccc; border-top: #999 1px solid; border-bottom: #999 1px solid;
            margin: 0 0 5px 0; padding: 5px; font: bold 12px arial">
            Facilities (सुबिधा)</div>
        <div style="margin: 10px; color: #000000; font: 10px arial;">
            <%:MvcHtmlString.Create(Model.FacilityDetails) %>
        </div>
    </div>
    <div style="font-size: 12px; line-height: 18px; color: #000; font-weight: bold; margin: 0 0 5px 0;
        padding: 0; text-align: center;width:100%;">
        <div style="width:50%;float:left;text-align:left;"><br />
        -------------------<br />
        Prepare By
        </div><div style="width:50%;float:right;text-align:right;"><br /> -------------------<br />
        Approve By</div>
        </div>
    <p style="font-size: 12px; line-height: 18px; color: #000; font-weight: bold; margin: 0 0 5px 0;
        padding: 0; text-align: center;">
           <span style="font-size: 11px;">When you contact Customer Service,Please provide the
            above itinerary number .<br />
            <font size="1" face="arial" color="#000000" style="font: normal 10px arial; color: #000000">
            Arihant Holidays Pvt. Ltd.,Swoyambhu Kathmandu,Ph.+977-14033800,email:info@arihantholidays.com<br />
                &nbsp;To view our full Terms &amp; Conditions, please go to our <a target="_blank"
                    href="http://www.arihantholidays.com">Terms &amp; Conditions</a> page. </font>
        </span>
    </p>
</div>
