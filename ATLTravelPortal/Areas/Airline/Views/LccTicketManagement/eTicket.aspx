<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/TicketPrint.Master"
    Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Airline.Models.ETicketViewModel>" %>

<%@ Import Namespace="ATLTravelPortal.Areas.Airline.Repository" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    TicketPrint
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <%TicketManagementProvider ticketprovider = new TicketManagementProvider();%>
    <%if (ViewData["isEmailSent"] != null)
      {%>
    <div>
        <%:ViewData["isEmailSent"]%></div>
    <% } %>
    <%-- <%if (!Model.isProduction)
      {%>
<div style="position:absolute; top:350px; left:300px;  font-size: 124px; color:#eaeaea;margin:0px auto; width:369px; text-align:center;">
    <img src="../../../../Content/images/sample-watermark.jpg" id="samplewatermark"/>
</div>
  <%} %>--%>
    <%-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@ Begin View eTicket @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@--%>
    <%if (Model != null)
      { %>
    <% using (Html.BeginForm("ViewETicket", "LccTicketManagement", FormMethod.Post, new { @style = "position:relative; z-index:3;" }))
       {%>
    <%  foreach (var PNR in Model.PNRList)
        {%>
    <%var PassengerListPerPNR = Model.PassengerList.Where(pp => pp.PNRId == PNR.PNRId); %>
    <%-- --------------------#region Satart Main Ticket-------------------------------------------- --%>
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
                        <strong>Issuing Agent:</strong>
                    </td>
                    <td style="padding: 2px 10px;">
                        <%:Model.AgentName %>
                    </td>
                </tr>
                <tr>
                    <td style="padding: 2px 10px;">
                        <strong>Issued Date:</strong>
                    </td>
                    <td style="padding: 2px 10px;">
                        <%=ATLTravelPortal.Helpers.TimeFormat.DateFormat(Model.IssuedDate.ToString())%>
                    </td>
                    <td style="padding: 2px 10px;">
                        <strong>Issuing Airline:</strong>
                    </td>
                    <td style="padding: 2px 10px;">
                        <%:Model.PNRSegmentList.ElementAtOrDefault(0).AirLineName %>
                    </td>
                </tr>
                <tr>
                    <td style="padding: 2px 10px;">
                        <strong>GDS Booking Ref:</strong>
                    </td>
                    <td colspan="1" style="padding: 2px 10px; background-color: #ccc;">
                        <%:PNR.GDSReferenceNumber.TrimEnd(' ').TrimEnd(',') %>
                    </td>
                    <td style="padding: 2px 10px;">
                        <strong>Tour Code:</strong>
                    </td>
                    <td style="padding: 2px 10px;">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td style="padding: 2px 10px;">
                        <strong>Operating Airline:</strong>
                    </td>
                    <td colspan="1" style="padding: 2px 10px;">
                        <%:PNR.OperatingAirline %>
                    </td>
                    <td style="padding: 2px 10px;">
                        &nbsp;
                    </td>
                    <td style="padding: 2px 10px;">
                        &nbsp;
                    </td>
                </tr>
            </tbody>
        </table>
        <hr style="border-bottom: 0.5px solid #000; border-right: 5px solid #fff;" />
        <table border="0" width="100%" cellpadding="0" cellspacing="0">
            <thead>
                <tr>
                    <td style="padding: 2px 10px;">
                        <strong>Passenger Name:</strong>
                    </td>
                    <td style="padding: 2px 10px;">
                        <strong>Ticket No:</strong>
                    </td>
                    <td style="padding: 2px 10px;">
                        <strong>Frequent Flyer No:</strong>
                    </td>
                </tr>
            </thead>
            <tbody>
                <%  foreach (var pass in PassengerListPerPNR)
                    {%>
                <%var TicketNo = ATLTravelPortal.Areas.Airline.Repository.TicketManagementProvider.eTicketdataProviderHelper.GetPassengerTicketNoOnETicket(pass.PassengerId, pass.PNRId);%>
                <tr>
                    <td style="padding: 2px 10px;">
                        <%:pass.PNRName%>
                    </td>
                    <td style="padding: 2px 10px;">
                        <%:TicketNo%>
                    </td>
                    <td style="padding: 2px 10px;">
                        <%:pass.FrequentFlyerNo%>-<%:ticketprovider.GetAirlineCodeByAirlineId(pass.FrequentFlyerAirlineId.Value)%>
                    </td>
                </tr>
                <%} %>
            </tbody>
        </table>
        <table border="0" width="100%" cellpadding="0" cellspacing="0">
            <thead>
                <tr>
                    <th style="border-bottom: 2px solid #000; border-right: 5px solid #fff;">
                        <strong>
                            <br />
                            <br />
                            Day</strong>
                    </th>
                    <th style="border-bottom: 2px solid #000; border-right: 5px solid #fff;">
                        <strong>
                            <br />
                            <br />
                            Date</strong>
                    </th>
                    <th style="border-bottom: 2px solid #000; border-right: 5px solid #fff;">
                        <strong>
                            <br />
                            <br />
                            &nbsp;</strong>
                    </th>
                    <th style="border-bottom: 2px solid #000; border-right: 5px solid #fff;">
                        <strong>
                            <br />
                            City/Terminal/<br />
                            Stopover City</strong>
                    </th>
                    <th style="border-bottom: 2px solid #000; border-right: 5px solid #fff;">
                        <strong>
                            <br />
                            <br />
                            Time</strong>
                    </th>
                    <th style="border-bottom: 2px solid #000; border-right: 5px solid #fff;">
                        <strong>
                            <br />
                            Flight/Class/<br />
                            Status</strong>
                    </th>
                    <th style="border-bottom: 2px solid #000; border-right: 5px solid #fff;">
                        <strong>
                            <br />
                            Stop/<br />
                            Flying Time</strong>
                    </th>
                    <th style="border-bottom: 2px solid #000; border-right: 5px solid #fff;">
                        <strong>
                            <br />
                            <br />
                            Fare Basis</strong>
                    </th>
                </tr>
            </thead>
            <%var segmentListPerPNR = Model.PNRSegmentList.Where(pp => pp.PNRId == PNR.PNRId); %>
            <%  foreach (var segment in segmentListPerPNR)
                {%>
            <%var SegmentAdditionalInfoList = ATLTravelPortal.Areas.Airline.Repository.TicketManagementProvider.eTicketdataProviderHelper.GetPassengerAdditionalInfoOnETicket(segment.SegmentID); %>
            <tbody style="padding: 10px;">
                <tr>
                    <td style="padding-top: 20px;">
                        <%:segment.DepartureDate.Value.DayOfWeek%>
                    </td>
                    <td style="padding-top: 20px; width:76px;">
                        <%=ATLTravelPortal.Helpers.TimeFormat.DateFormat(segment.DepartureDate.Value.ToShortDateString())%>
                    </td>
                    <td style="padding-top: 20px;">
                        DEP
                    </td>
                    <td style="padding-top: 20px;">
                        <%:segment.DepartureCity%><br />
                        <%:(string.IsNullOrWhiteSpace(segment.StartTerminalNumber) ? "" : "  Terminal " + (segment.StartTerminalNumber))%>
                    </td>
                    <td style="padding-top: 20px;">
                        <%:segment.DepartureTime %>
                    </td>
                    <td style="padding-top: 20px;">
                        <%:ticketprovider.GetAirlineCodeByAirlineId(segment.AirLineId)%>-<%:segment.FlightNumber %>/<%:segment.BIC %>/Confirmed
                    </td>
                    <td style="padding-top: 20px;">
                        Non-Stop/<%:segment.FlightDuration %><br />
                    </td>
                    <td style="padding-top: 20px;">
                        <% if (SegmentAdditionalInfoList.Count() > 0)
                           { %>
                        <%: SegmentAdditionalInfoList.FirstOrDefault().FIC%>
                    </td>
                    <%} %>
                    <% else
                           { %>
                    <%: string.Empty %>
                    <%} %>
                    <%--  <%:(SegmentAdditionalInfoList != null ? SegmentAdditionalInfoList.FirstOrDefault().FIC : "")%></td> --%>
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
                        <%:segment.ArrivalCity%><br />
                        <%:(!string.IsNullOrWhiteSpace(segment.EndTerminalNumber) ? "  Terminal " + (segment.EndTerminalNumber) : "")%>
                    </td>
                    <td>
                        <%:segment.ArrivalTime %>
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td colspan="5">
                        <br />
                        <strong>
                            <%:segment.AirLineName %>
                            Ref:&nbsp;</strong><%:segment.AirLineReferenceNumber %>
                    </td>
                    <% if (SegmentAdditionalInfoList.Count() > 0)
                       { %>
                    <td>
                        <br />
                        <strong>NVB:&nbsp
                            <%: SegmentAdditionalInfoList.FirstOrDefault().LccNVB%>
                        </strong>
                    </td>
                    <%} %>
                    <%else
                       { %>
                    <td>
                        <br />
                        <strong>NVB:&nbsp;<%: string.Empty %>
                        </strong>
                    </td>
                    <%} %>
                    <%-- <td><br /><strong>NVB:&nbsp;<%:(SegmentAdditionalInfoList != null ? SegmentAdditionalInfoList.FirstOrDefault().LccNVB : "")%> </strong></td>--%>
                    <% if (SegmentAdditionalInfoList.Count() > 0)
                       { %>
                    <td>
                        <br />
                        <strong>NVA:&nbsp
                            <%: SegmentAdditionalInfoList.FirstOrDefault().LccNVA%>
                        </strong>
                    </td>
                    <%} %>
                    <%else
                       { %>
                    <td>
                        <br />
                        <strong>NVA:&nbsp;<%: string.Empty %>
                        </strong>
                    </td>
                    <%} %>
                    <%-- <td><br /><strong>NVA:&nbsp;<%:(SegmentAdditionalInfoList != null ? SegmentAdditionalInfoList.FirstOrDefault().LccNVA : "")%> </strong></td>--%>
                    <% if (SegmentAdditionalInfoList.Count() > 0)
                       { %>
                    <td>
                        <br />
                        <strong>Baggage:</strong>&nbsp
                        <%: SegmentAdditionalInfoList.FirstOrDefault().Baggage%>
                    </td>
                    <%} %>
                    <%else
                       { %>
                    <td>
                        <br />
                        <strong>Baggage: </strong>&nbsp;<%: string.Empty %>
                    </td>
                    <%} %>
                    <%-- <td><br /><strong>Baggage:&nbsp;</strong><%:(SegmentAdditionalInfoList != null ? SegmentAdditionalInfoList.FirstOrDefault().Baggage : "")%></td> --%>
                </tr>
                <tr>
                    <td colspan="8">
                        <strong></strong>
                    </td>
                </tr>
            </tbody>
            <%} %>
            <% if (Model.ShowFareOnETicket == true)
               { %>
            <%var PNRFare = ticketprovider.GetFareByPNR(Model.MasterPNRId.Value);


              //double totalDiscount = (PNRFare.DiscountAmount > 0 ? PNRFare.DiscountAmount : 0 +
              //                        (PNRFare.BranchDealAmount < 0 ? Math.Abs(PNRFare.BranchDealAmount) : 0) +
              //                        (PNRFare.DistrubutorDealAmount < 0 ? Math.Abs(PNRFare.DistrubutorDealAmount) : 0));

              //double totalTranFee = ((PNRFare.DiscountAmount < 0 ? Math.Abs(PNRFare.DiscountAmount) : 0) +
              //                       (PNRFare.BranchDealAmount > 0 ? Math.Abs(PNRFare.BranchDealAmount) : 0) +
              //                       (PNRFare.DistrubutorDealAmount > 0 ? Math.Abs(PNRFare.DistrubutorDealAmount) : 0));

              double totalTranFee = 0;
              if (PNRFare.DiscountAmount < 0)
                  totalTranFee = Math.Abs(PNRFare.DiscountAmount);

              double totalDiscount = 0;
              if (PNRFare.DiscountAmount > 0)
                  totalDiscount = PNRFare.DiscountAmount;

              if (Model.IsBranchByPassDeal == false)
              {
                  totalDiscount = PNRFare.BranchDealAmount < 0 ? Math.Abs(PNRFare.BranchDealAmount) : 0;
                  if (PNRFare.BranchDealAmount > 0)
                      totalTranFee += PNRFare.BranchDealAmount;
              }

              if (Model.IsDistributorByPassDeal == false)
              {
                  totalDiscount = PNRFare.DistrubutorDealAmount < 0 ? Math.Abs(PNRFare.DistrubutorDealAmount) : 0;

                  if (PNRFare.DistrubutorDealAmount > 0)
                      totalTranFee += PNRFare.DistrubutorDealAmount;
              }   
              
            %>
            <tbody>
                <tr>
                    <td colspan="3" style="padding-top: 30px;">
                        <strong>Form of Payment:</strong>
                    </td>
                    <td colspan="5" style="padding-top: 30px;">
                        Cash (<%:PNRFare.Currency%>)
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        <strong>Fare BreakDown </strong>
                    </td>
                    <td colspan="5">
                    </td>
                </tr>
            </tbody>
            <tbody style="background-color: #eaeaea;">
                <tr>
                    <td colspan="3" style="text-align: right;">
                        <strong>Base Fare:&nbsp;</strong>
                    </td>
                    <td colspan="2">
                        <%:PNRFare.BaseFare %>
                    </td>
                </tr>
                <% if (Model.ShowServiceChargeOnETicket == false)
                   { %>
                <tr>
                    <td colspan="3" style="text-align: right;">
                        <strong>Taxes/Fees/Charges:&nbsp;</strong>
                    </td>
                    <td colspan="2">
                        <%if (Model.ServiceProviderId == 5)
                          { %>
                        <%:PNRFare.Tax + PNRFare.AdditionalTxnFee + PNRFare.AirlineTransFee + PNRFare.OtherCharges - totalDiscount%>
                        <%}
                          else
                          {%>
                        <%:PNRFare.Tax + PNRFare.AdditionalTxnFee + PNRFare.AirlineTransFee + PNRFare.OtherCharges+PNRFare.FSC - totalDiscount%>
                        <%} %>
                    </td>
                </tr>
                <tr>
                    <td colspan="3" style="text-align: right;">
                        <strong>Service Charges:&nbsp;</strong>
                    </td>
                    <td colspan="2">
                        <%:PNRFare.ServiceCharge %>
                    </td>
                </tr>
                <%} %>
                <%else
                   { %>
                <tr>
                    <td colspan="3" style="text-align: right;">
                        <strong>Taxes/Fees/Charges:&nbsp;</strong>
                    </td>
                    <td colspan="2">
                        <%if (Model.ServiceProviderId == 5)
                          { %>
                        <%:PNRFare.Tax + PNRFare.AdditionalTxnFee + PNRFare.AirlineTransFee + PNRFare.OtherCharges + PNRFare.ServiceCharge%>
                        <%}
                          else
                          { %>
                        <%:PNRFare.Tax + PNRFare.AdditionalTxnFee + PNRFare.AirlineTransFee + PNRFare.OtherCharges + PNRFare.ServiceCharge + PNRFare.FSC  - totalDiscount%>
                        <%} %>
                    </td>
                </tr>
                <%} %>
                <tr>
                    <td colspan="3" style="text-align: right;">
                        <strong>Service Tax:&nbsp;</strong>
                    </td>
                    <td colspan="2">
                        <%:PNRFare.ServiceTax %>
                    </td>
                </tr>
                <tr>
                    <td colspan="3" style="text-align: right;">
                        <strong>Tran Fee:&nbsp;</strong>
                    </td>
                    <td colspan="2">
                        <%:totalTranFee%>
                    </td>
                </tr>
                <tr>
                    <td colspan="3" style="background-color: #ccc; text-align: right;">
                        <strong>Total:&nbsp;</strong>
                    </td>
                    <td colspan="2" style="background-color: #ccc;">
                        <%: string.Format("{0:#,#}", (PNRFare.AdditionalTxnFee + PNRFare.AirlineTransFee + PNRFare.BaseFare + PNRFare.Tax + PNRFare.OtherCharges + PNRFare.ServiceTax + PNRFare.ServiceCharge) + totalTranFee - totalDiscount + (Model.ServiceProviderId != 5 ? PNRFare.FSC : 0))%>
                    </td>
                </tr>
            </tbody>
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
                    <strong>IATA Ticket Notice:</strong> <a href="#">http://www.iatatravelcentre.com/e-ticket-notice/General/English/</a><br />
                    (Subject to change without prior notice)
                </td>
            </tr>
            <tr>
                <td colspan="8" style="padding-top: 20px; text-align: right;">
                    Powered by <a href="http://www.arihanttech.com" target="_blank" id="poweredByLogo">Arihant
                        Technologies</a>
                </td>
            </tr>
            </tbody>
            <%} %>
        </table>
    </div>
    <%--<%} %>--%>
    <%} %>
    <div id="emailTextBox" style="width: 720px; margin: 0px auto 20px;" class="printdivhideshow">
        <%: Html.LabelFor(model => model.txtEmailTo)%>
        <%: Html.TextBoxFor(model => model.txtEmailTo)%>
        <%: Html.ValidationMessageFor(model => model.txtEmailTo)%>
        <input id="btnSendEmail" type="submit" value="Send Email" /><input type="button"
            value="Print" id="btnPrintTicket" onclick="window.print()" />
    </div>
    <% } %>
    <%} %>
    <%-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@ End View eTicket @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@--%>
    <%-- @@@@@@@@@@@@@@@@@@@@@@@@@@ handling Hacking by Unauthorized Agent @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@--%>
    <%
        if (ViewData["ErrorInfoMsg"] != null)
        {%>
    <div>
        <%:ViewData["ErrorInfoMsg"]%><br />
        <img src="../../../../Content/images/Accessdenied.jpg" height="80" width="100" />
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
