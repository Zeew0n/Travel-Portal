<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/TicketPrint.Master"
    Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Airline.Models.ETicketViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    TicketPrint
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <%ATLTravelPortal.Areas.Airline.Repository.TicketManagementProvider ticketprovider = new ATLTravelPortal.Areas.Airline.Repository.TicketManagementProvider();%>
    <%
        if (ViewData["isEmailSent"] != null)
        {
    %>
    <div>
        <%:ViewData["isEmailSent"]%>
    </div>
    <% } %>
    <%-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@ Begin View eTicket @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@--%>
    <%if (Model != null)
      { %>
    <% using (Html.BeginForm())
       {%>
    <%  foreach (var Passenger in Model.PassengerList)
        {%>
    <div style="width: 720px; margin: 0px auto; font-family: Tahoma; font-size: 13px;
        background-color: 10px; padding: 10px; page-break-after: always">
        <%--@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@ Begin Region showing custom Logo on E-Ticket @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@--%>
        <%if (Model.ShowAgentLogoOnETicket == false)
          { %>
        <img src="../../../../Content/images/logo.png" alt="Logo " id="agentLogo" />
        <%}
          else
          { %>
        <div class="agentBrandingLogo">
            <img src="../../../../Content/AgentLogo/<%:Model.AgentLogo %>" alt="Logo " id="agentLogo" />
            <%if (Model.ServiceProviderId == 8)
              { %>
            <img src="../../../../Content/images/AirArabialogo.jpg" width="125px" style="float: right;" />
            <%} %>
        </div>
        <%} %>
        <%--@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@ End Region showibg custom Logo on E-Ticket @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@--%>
        <br />
        <center>
            <strong>ELECTRONIC TICKET</strong>
            <br />
            Passenger Itinerary/Receipt<br />
            Customer Copy
        </center>
        <br />
        <table border="0" width="100%" cellpadding="0" cellspacing="0">
            <tbody>
                <tr>
                    <td style="padding: 2px 10px;">
                        <strong>Passenger:</strong>
                    </td>
                    <td style="padding: 2px 10px;">
                        <%:Passenger.PNRName%>
                    </td>
                    <td style="padding: 2px 10px;">
                        <strong>Ticket No:</strong>
                    </td>
                    <td style="padding: 2px 10px;">
                        <%:Model.ServiceProviderId == 8 ? Model.GDSReferenceNumber : Passenger.TicketNO%>
                    </td>
                </tr>
                <tr>
                    <td style="padding: 2px 10px;">
                        <strong>Issue Date:</strong>
                    </td>
                    <td style="padding: 2px 10px;">
                        <%=ATLTravelPortal.Helpers.TimeFormat.DateFormat(Model.IssuedDate.ToString())%>
                    </td>
                    <td style="padding: 2px 10px;">
                        <strong>Issuing Airline:</strong>
                    </td>
                    <td style="padding: 2px 10px;">
                        <%:Model.PNRSegmentList.ElementAtOrDefault(0).AirLineName%>
                    </td>
                </tr>
                <%if (Model.ServiceProviderId != 8)
                  {%>
                <tr>
                    <td style="padding: 2px 10px;">
                        <strong>FOID:</strong>
                    </td>
                    <td style="padding: 2px 10px;">
                    </td>
                    <td style="padding: 2px 10px;">
                        <strong>IATA No:</strong>
                    </td>
                    <td style="padding: 2px 10px;">
                        10302902
                    </td>
                </tr>
                <%} %>
                <tr>
                    <td style="padding: 2px 10px;">
                        <strong>Frequent Flyer No:</strong>
                    </td>
                    <td style="padding: 2px 10px;">
                        <%:Passenger.FrequentFlyerNo%>
                        <%if (Passenger.FrequentFlyerAirlineId != null)
                          { %>
                        -<%:ticketprovider.GetAirlineCodeByAirlineId(Passenger.FrequentFlyerAirlineId.Value)%>
                        <%} %>
                    </td>
                    <td style="padding: 2px 10px;">
                        <strong>Issuing Agent:</strong>
                    </td>
                    <td style="padding: 2px 10px;">
                        <%:Model.AgentName%>
                    </td>
                </tr>
                <tr>
                    <td style="padding: 2px 10px;">
                        <strong>Booking Ref:</strong>
                    </td>
                    <td style="padding: 2px 10px;">
                        <%:Model.ServiceProviderId == 8 ? "G9-" + Model.GDSReferenceNumber : Model.GDSReferenceNumber%>
                    </td>
                    <td style="padding: 2px 10px;">
                        <strong>Tour Code:</strong>
                    </td>
                    <td style="padding: 2px 10px;">
                    </td>
                </tr>
                <%if (Model.ServiceProviderId != 8)
                  {%>
                <% 
                      string vendorLocators = string.Empty;

                      foreach (var locator in Model.AirlineVendorLocators)
                      {
                          vendorLocators += locator.AirLineName + "/" + locator.AirLineReferenceNumber + ", ";

                      }%>
                <tr>
                    <td style="padding: 2px 10px;">
                        <strong>Airline Booking Ref:</strong>
                    </td>
                    <td colspan="1" style="padding: 2px 10px; background-color: #ccc;">
                        <%:vendorLocators.TrimEnd(' ').TrimEnd(',')%>
                    </td>
                    <td>
                        <strong>Operating Airline:</strong>
                    </td>
                    <td>
                        <%:Model.OperatingAirline %>
                    </td>
                </tr>
                <%} %>
            </tbody>
        </table>
        <br />
        <table border="0" width="100%" cellpadding="0" cellspacing="0">
            <thead>
                <tr>
                    <th style="border-bottom: 2px solid #000; border-right: 5px solid #fff;">
                        <strong>
                            <br />
                            Day</strong>
                    </th>
                    <th style="border-bottom: 2px solid #000; border-right: 5px solid #fff;">
                        <strong>
                            <br />
                            Date</strong>
                    </th>
                    <th style="border-bottom: 2px solid #000; border-right: 5px solid #fff;">
                        <strong>
                            <br />
                            &nbsp;</strong>
                    </th>
                    <th style="border-bottom: 2px solid #000; border-right: 5px solid #fff;">
                        <strong>City/Terminal/<br />
                            Stopover City</strong>
                    </th>
                    <th style="border-bottom: 2px solid #000; border-right: 5px solid #fff;">
                        <strong>
                            <br />
                            Time</strong>
                    </th>
                    <th style="border-bottom: 2px solid #000; border-right: 5px solid #fff;">
                        <strong>Flight/<br />
                            Class/Status</strong>
                    </th>
                    <th style="border-bottom: 2px solid #000; border-right: 5px solid #fff;">
                        <strong>Stop/<br />
                            Flying Time/Services</strong>
                    </th>
                    <%if (Model.ServiceProviderId != 8)
                      {%>
                    <th style="border-bottom: 2px solid #000; border-right: 5px solid #fff;">
                        <strong>
                            <br />
                            Fare Basis</strong>
                    </th>
                    <%} %>
                </tr>
            </thead>
            <%  foreach (var segment in Model.PNRSegmentList)
                {%>
            <tbody style="padding: 10px;">
                <tr>
                    <td style="padding-top: 10px;">
                        <%:segment.DepartureDate.Value.DayOfWeek%>
                    </td>
                    <td style="padding-top: 10px; width:76px;">
                        <%=ATLTravelPortal.Helpers.TimeFormat.DateFormat(segment.DepartureDate.Value.ToShortDateString())%>
                    </td>
                    <td style="padding-top: 10px;">
                        DEP
                    </td>
                    <td style="padding-top: 10px;">
                        <%:segment.DepartureCity%>/<br />
                        <%:segment.StartTerminalNumber%>
                    </td>
                    <td style="padding-top: 10px;">
                        <%:segment.DepartureTime%>
                    </td>
                    <td style="padding-top: 10px;">
                        <%:ticketprovider.GetAirlineCodeByAirlineId(segment.AirLineId)%>-<%:segment.FlightNumber%>/<%:(segment.BIC =="Ec" ? "Economy":segment.BIC)%>/Confirmed
                    </td>
                    <td style="padding-top: 10px;">
                        Non-Stop<br />
                        <%:ATLTravelPortal.Helpers.TimeFormat.ConvertToHourMin(segment.FlightDuration.ToString())%>/<%:Passenger.SSR%>
                    </td>
                    <%if (Model.ServiceProviderId != 8)
                      {%>
                    <td style="padding-top: 10px;">
                        <%:segment.FIC%>
                    </td>
                    <%} %>
                </tr>
                <tr>
                    <td>
                        <%:segment.ArrivalDate.Value.DayOfWeek%>
                    </td>
                    <td>
                        <%=ATLTravelPortal.Helpers.TimeFormat.DateFormat(segment.ArrivalDate.Value.ToShortDateString())%>
                    </td>
                    <td>
                        ARR
                    </td>
                    <td>
                        <%:segment.ArrivalCity%>/<br />
                        <%:segment.EndTerminalNumber%>
                    </td>
                    <td>
                        <%:segment.ArrivalTime%>
                    </td>
                    <td>
                    </td>
                    <td>
                        <br />
                    </td>
                    <td>
                    </td>
                </tr>
                <%if (Model.ServiceProviderId != 8)
                  {%>
                <tr>
                    <td colspan="5">
                    </td>
                    <td>
                        <strong>NVB:</strong>
                        <%=ATLTravelPortal.Helpers.TimeFormat.DateFormat(segment.NVB.ToString())%>
                    </td>
                    <td>
                        <strong>NVA:</strong>
                        <%=ATLTravelPortal.Helpers.TimeFormat.DateFormat(segment.NVA.ToString())%>
                    </td>
                    <td>
                        <strong>Baggage:</strong><%:ticketprovider.GetPassengerBaggageInfo(Passenger.PassengerTypeId, segment.SegmentID)%>
                    </td>
                </tr>
                <%} %>
                <tr>
                    <td colspan="8">
                        <strong></strong>
                    </td>
                </tr>
            </tbody>
            <%} %>
            <% if (Model.ShowFareOnETicket == true)
               {
                   double totalTranFee = 0;
                   if (Passenger.Discount < 0)
                       totalTranFee = Math.Abs(Passenger.Discount);

                   double totalDiscount = 0;
                   if (Passenger.Discount > 0)
                       totalDiscount = Passenger.Discount;


                   if (Model.IsBranchByPassDeal == false)
                   {
                       totalDiscount = Passenger.BranchDeal < 0 ? Math.Abs(Passenger.BranchDeal) : 0;
                       if (Passenger.BranchDeal > 0)
                           totalTranFee += Passenger.BranchDeal;
                   }

                   if (Model.IsDistributorByPassDeal == false)
                   {
                       totalDiscount = Passenger.DistributorDeal < 0 ? Math.Abs(Passenger.DistributorDeal) : 0;



                       if (Passenger.DistributorDeal > 0)
                           totalTranFee += Passenger.DistributorDeal;
                   }
                   

            %>
            <tbody>
                <tbody>
                    <tr>
                        <td colspan="3" style="padding-top: 10px; text-align: right;">
                            <strong>Form of Payment :</strong>
                        </td>
                        <td colspan="1" style="padding-top: 10px; text-align: right;">
                            Cash(<%:Passenger.Currency%>)
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3" style="text-align: right;">
                            <strong><u>Fare Calculation </u></strong>
                        </td>
                        <td colspan="1" style="text-align: right;">
                            <%-- <% foreach (var TaxName in ticketprovider.GetAirTaxNameList(Passenger.PassengerId))
                               { %><%:TaxName%>
                            <%} %>--%>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3" style="text-align: right;">
                            <strong>Fare :</strong>
                        </td>
                        <td colspan="1" style="text-align: right;">
                            <%:Passenger.Fare%>
                        </td>
                        <td colspan="3" style="text-align: right;">
                            <%-- <strong>Equivalent Fare: </strong>
                            <%:Passenger.Currency%>
                            <%:Passenger.Fare%>--%>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3" style="text-align: right;">
                            <strong>Taxes/Fees :</strong>
                        </td>
                        <td colspan="1" style="text-align: right;">
                            <%:Passenger.Tax - totalDiscount%>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3" style="text-align: right;">
                            <strong>Service Charges :</strong>
                        </td>
                        <td colspan="1" style="text-align: right;">
                            <%:Passenger.ServiceCharge%>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3" style="text-align: right;">
                            <strong>Tran Fee :</strong>
                        </td>
                        <td colspan="1" style="text-align: right;">
                            <%:totalTranFee%>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3" style="text-align: right;">
                            <strong>Total :</strong>
                        </td>
                        <td colspan="1" style="text-align: right;">
                            <%:(Passenger.Fare + Passenger.Tax + Passenger.ServiceCharge +totalTranFee-totalDiscount)%>
                        </td>
                    </tr>
                    <%} %>
                    <%-- @@@@@@@@@@@ Begin Displaying Conditional Term and condition @@@@@@@@@@@@@@@@@@@@@@@@--%>
                    <%if (Model.ServiceProviderId != 8)
                      {%>
                    <tr>
                        <td colspan="8" style="padding-top: 20px;">
                            <strong>Positive identification required for airport check in</strong><br />
                            <strong>Notice:</strong>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="8">
                            PASSENGERS ON A JOURNEY INVOLVING AN ULTIMATE DESTINATION OR A STOP IN A COUNTRY
                            OTHER THAN THE COUNTRY OF DEPARTURE ARE ADVISED THAT INTERNATIONAL TREATIES KNOWN
                            AS THE MONTREAL CONVENTION, OR ITS PREDECESSOR, THE WARSAW CONVENTION, INCLUDING
                            ITS AMENDMENTS (THE WARSAW CONVENTION SYSTEM), MAY APPLY TO THE ENTIRE JOURNEY,
                            INCLUDING ANY PORTION THEREOF WITHIN A COUNTRY. FOR SUCH PASSENGERS, THE APPLICABLE
                            TREATY, INCLUDING SPECIAL CONTRACTS OF CARRIAGE EMBODIED IN ANY APPLICABLE TARIFFS,
                            GOVERNS AND MAY LIMIT THE LIABILITY OF THE CARRIER. Further information may be obtained
                            from the carrier as to the limits applicable to your journey. If your journey involves
                            carriage by different carriers, you should contact each carrier for information
                            on the applicable limits of liability.
                        </td>
                    </tr>
                    <tr>
                        <td colspan="8" style="padding-top: 20px;">
                            <strong>IATA Ticket Notice :</strong> <a href="http://www.iatatravelcentre.com/e-ticket-notice/General/English/"
                                target="_blank">http://www.iatatravelcentre.com/e-ticket-notice/General/English/</a><br />
                            (Subject to change without prior notice)
                        </td>
                    </tr>
                    <%}
                      else
                      { %>
                    <div style="width: 235px; position: relative; top: 573px; left: 456px;">
                        <img src="../../../../Content/images/AirArabialiquidstamp.jpg" width="125px" style="float: right;"
                            alt="G9 Liquidstamp" /></div>
                    <tr>
                        <td colspan="8" style="padding-top: 20px;">
                            <strong>THIS ITINERARY IS YOUR OFFICIAL TRAVEL DOCUMENT</strong><br />
                            <strong>Check IN:</strong>
                            <ul>
                                <li>Our check-in counters open 3 hours prior to the scheduled flight departure time.
                                    Passengers must complete all check-in formalities 1 hour prior to the scheduled
                                    flight departure time. </li>
                                <li>Check-in counters close 1 hour prior to the scheduled time. Passengers failing to
                                    check-in on time will not be accepted for travel and will forfeit their flight and
                                    their ticket. </li>
                                <li>It is the passenger's responsibility to ensure that they have the necessary valid
                                    documents, including visas, to meet the immigration requirements of their destination.
                                </li>
                            </ul>
                            <strong>Unaccompanied Minors</strong>
                            <ul>
                                <li>Air Arabia does not accept children traveling unaccompanied under their 12th birthday.</li>
                                <li>Infants under the age of 2 weeks cannot be accepted for travel.</li>
                            </ul>
                            <strong>Free Baggage Allowance per Passenger (excluding infant)</strong>
                            <ul>
                                <li>Checked baggage </li>
                                <ul>
                                    <li>Flights to Almaty 20 kgs.</li>
                                    <li>Flights within GCC (excluding Jeddah) 25 kgs.</li>
                                    <li>Flights to Kiev 20 kgs (Starting from October 1, 2009)</li>
                                    <li>Flights outside GCC (including Jeddah) 30 kgs.</li>
                                </ul>
                                <li>Maximum weight permitted per individual piece of baggage is 32 kgs with total dimensions
                                    of 160 cms (W+D+L).</li>
                                <li>Only one box is permitted as part of free baggage allowance. The box must be the
                                    original manufacture's box containing the original item.</li>
                                <li>Hand baggage allowance per passenger must not exceed 7 kgs with dimensions within
                                    55 x 40 20 cms.</li>
                                <li>Items which you MUST NOT include within your Checked Baggage(Foods or other Items
                                    ,Money, Jewellery, Medicine , Business Documents, Passports or other Identification
                                    Documents, Fragile or Valuable Items )</li>
                                <li>Any liquid, aerosols, gels or pasted greater than 100ml each must be packed in your
                                    check in baggage. Any individual container over 100ml in your hand baggage (even
                                    if there is less than 100ml still inside) will NOT be allowed on board. All such
                                    items must be carried in a separate clear plastic, zip-top, re-sealable bag that
                                    does not exceed 20cm X 20cm or equivalent to one litre capacity.</li>
                            </ul>
                            <strong>Handling Fee</strong>
                            <ul>
                                <li>Travel Agency handling fee not exceed:-
                                    <ul>
                                        <li>AED 30 (or equivalent) per passenger for travel within GCC and AED 50 (or equivalent)
                                            per passenger for travel outside GCC.( The above mentioned fees will not be credited
                                            in case of cancellation )</li>
                                        <li>INR 400 (one way trip) and INR 650 (return trip) per passenger for reservations
                                            made in India. &amp; PKR 400 (one way trip) and PKR 650 (return trip) per passenger
                                            for reservations made in Pakistan.</li>
                                        <li>LKR 900 (one way trip) and LKR 1,500 (return trip) per passenger for reservation
                                            made in Sri Lanka.</li>
                                        <li>EURO 12 (one way trip and return trip) per passenger for reservations made in Turkey
                                            and the European Union.</li>
                                        <li>AMD 8000 (Armenian Dram) (or equivalent) per passenger (one way trip and return
                                            trip) for reservations made in Armenia.</li>
                                        <li>BDT 600 (one way trip) and BDT 1000 (return trip) per passenger for reservations
                                            made in Bangladesh.</li>
                                        <li>KZT 2500 (one way trip and return) per passenger for reservations made in Kazakhstan.</li>
                                    </ul>
                                </li>
                                <li>Handling fees are not applicable on Air Arabia Holiday packages.</li>
                                <li>Government tax of AMD 10000 (Equivalent 30 USD) is required to be paid by all passengers
                                    traveling from Yerevan (Armenia).</li>
                            </ul>
                            <strong>Flight Changes, cancellations and Credit</strong>
                            <ul>
                                <li>Reservations must be modified or cancelled at least 24 hours before local scheduled
                                    flight departure time by calling our Air Arabia Call Centre or by contacting Air
                                    Arabia Sales Centres or Travel Agents in the region. A fee of AED 50 (or equivalent)
                                    per passenger, per sector will be applicable plus any difference in the total fare
                                    of the applicable flight at the time of the modification.</li>
                                <li>Air Arabia <b>does not have a refund policy</b> once the booking is paid for. Should
                                    a passenger cancel a flight 24 hours prior to the scheduled flight departure time,
                                    Air Arabia will retain the amount, less cancellation charges of AED 100 (or equivalent)
                                    per passenger, per sector, as a credit towards a future flight to be used for travel
                                    within one year from the date of payment. </li>
                                <li>Passengers failing to modify or cancel their reservation 24 hours prior to the scheduled
                                    flight departure time forfiet their ticket and amount paid to Air Arabia.</li>
                                <li>Please note the above conditions do not apply to air inclusive Air Arabia Holiday
                                    packages. A separate cancellation and change policy is applicable to holiday package
                                    bookings which is available from Air Arabia Holidays at the time of booking.</li>
                                <li>Govt. taxes, fees and or any other charges are subject to change. If it is increased
                                    or a new tax or charge is imposed after confirmation and payment, the customer has
                                    to pay the difference. Similarly, if any taxes, fees or charges are reduced or abolished
                                    after making payment, the customer will be entitled to refund of this amount in
                                    form of credit, to be utilized within 12 months from the date of payment for the
                                    same passenger or it can be transfered to one of his immediate family member by
                                    paying a charge of AED 50 per passenger.</li>
                            </ul>
                            <strong>Visit Visa, Residence Visa</strong>
                            <ul>
                                <li>Passengers holding original visa do not require OK to Board message. However in
                                    case passenger is traveling from India &amp; Pakistan to UAE and holding copy of
                                    UAE visa, the sponsor or the representative of the passengers have to produce the
                                    original visa in person along with a fee of AED 10 at one of our sales shop in Sharjah
                                    or Dubai or at Hala Service at Sharjah airport between 0830 to 15:00 and it has
                                    to be done minimum 24 hours before departure of the flight. These offices after
                                    verifying with the authorities concerned will authorize to accept the passenger
                                    by inserting a remark in the reservation. The failure to do so will lead in Air
                                    Arabia refusing to carry the passengers.</li>
                            </ul>
                            <strong>Wheelchairs at the Airport</strong>
                            <ul>
                                <li>Starting February 1, 2008, Sharjah International Airport shall levy a charge of
                                    AED 50 for wheelchair request to be used at the airport. This charge shall apply
                                    for all bookings made from January 28, 2008 onwards. Please note that relevant wheelchair
                                    charges may apply at other cities based on the respective airport policy. For details
                                    call the air Arabia call center in your city.</li>
                            </ul>
                            <br />
                            By buying this ticket, the passenger confirms herewith that he/she has agreed on
                            all terms and conditions as issued and amended by the Carrier from time to time.
                            In case of any dispute related to any/all of the services as provided by the Carrier
                            and/or any of its authorized representatives before, during and/or after the provision
                            of the service, such dispute shall be exclusively and solely raised, filed, submitted,
                            registered and/or presented in front of any of the legal courts operating in the
                            Emirate of Sharjah in the United Arab Emirates.
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="8">
                            By buying this ticket, the passenger confirms herewith that he/she has agreed on
                            all terms and conditions as issued and amended by the Carrier from time to time.
                            In case of any dispute related to any/all of the services as provided by the Carrier
                            and/or any of its authorized representatives before, during and/or after the provision
                            of the service, such dispute shall be exclusively and solely raised, filed, submitted,
                            registered and/or presented in front of any of the legal courts operating in the
                            Emirate of Sharjah in the United Arab Emirates.
                        </td>
                    </tr>
                    <tr>
                        <td colspan="8" style="padding-top: 20px;">
                            <strong>Queries :</strong>
                            <h3>
                                Our Call Centre Numbers:</h3>
                            <p>
                                UAE: Sharjah (06) 5580000, Abu Dhabi (02) 6315888, (02) 5555446, Ajman (06) 7451444,
                                Al Ain (03) 7666630, Fujairah (09) 2231991, Ras Al Khaimah (07) 2221144 Other Regions:
                                : Ahmedabad (079) 26403804/7, Aleppo (021) 2286207, Almaty (32)72 728228 Al Khobar
                                (03) 8691460, Amman (06) 560 3666, Astana (31) 72 344797, Bahrain (17) 505111, Beirut
                                (01) 756666, Cairo (202) 7709990, Chennai (044) 45508435, Chittagong (+880) 312513467/65,
                                Colombo (011) 2393994/2393995, Damascus (011) 23497682, Delhi (011) 25656440/1/2,
                                Doha 4322111, Istanbul (212) 234 2088, Jaipur (141) 2378501/2/3/4, Jeddah (02) 6640291,
                                Kabul (07) 99700095, Karachi (021) 5693816/21, Kathmandu (1) 4233210/11/12, Khartoum
                                (0183) 770977, Kochi (0484) 2359601, Kuwait 2449824, Latakia (41) 454577/8, Mumbai
                                (022) 28395240, Muscat (24) 700828, Nagpur (0712) 2557640, Peshawar (091) 5509425/26/27,
                                Riyadh (01) 2937701, Saudi Arabia All Regions 9200 133 22, Sanaa (01) 440001, Sohar
                                (26) 846388, Tehran (021) 88706111, Thiruvananthapuram (471) 2339251, Yerevan (10)
                                534533.</p>
                        </td>
                    </tr>
                    <%} %>
                    <%-- @@@@@@@@@@@ End Displaying Conditional Term and condition @@@@@@@@@@@@@@@@@@@@@@@@--%>
                    <tr>
                        <td colspan="8" style="padding-top: 20px; text-align: right;">
                            Powered by <a href="http://www.arihanttech.com" target="_blank" id="poweredByLogo">Arihant
                                Technologies</a>
                        </td>
                    </tr>
                </tbody>
            </tbody>
        </table>
    </div>
    <%} %>
    <div id="emailTextBox" style="width: 720px; margin: 0px auto 20px;" class="printdivhideshow">
        <%: Html.LabelFor(model => model.txtEmailTo)%>
        <%: Html.TextBoxFor(model => model.txtEmailTo, new { @style = "width:200px;" })%>
        <%: Html.ValidationMessageFor(model => model.txtEmailTo)%>
        <input id="btnSendEmail" type="submit" value="Send Email" />
    </div>
    <% }
      }%>
    <%-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@ End View eTicket @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@--%>
    <%-- @@@@@@@@@@@@@@@@@@@@@@@@@@ handling Hacking by Unauthorized Agent @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@--%>
    <%
        if (ViewData["ErrorInfoMsg"] != null)
        {%>
    <div>
        <%:ViewData["ErrorInfoMsg"]%>
    </div>
    <% } %>
    <%-- @@@@@@@@@@@@@@@@@@@@@@@@@@ handling Hacking by Unauthorized Agent @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@--%>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CssContent" runat="server">
    <link href="../../../../Content/css/eticketing.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        @media screen
        {
            .printdivhideshow
            {
                display: block;
            }
        }
        @media print
        {
            .printdivhideshow
            {
                display: none;
            }
        }
    </style>
</asp:Content>
