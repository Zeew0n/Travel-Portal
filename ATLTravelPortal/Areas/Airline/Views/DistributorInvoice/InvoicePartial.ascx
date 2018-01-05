<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<ATLTravelPortal.Areas.Airline.Models.InvoicePNRDetailModel>" %>
<%@ Import Namespace="ATLTravelPortal.Helpers" %>
<div style="width: 720px; margin: 20px auto 0px; font-family: Tahoma; font-size: 13px;
    padding: 10px; page-break-after: always">
    <table cellpadding="0" cellspacing="" width="100%" style="border-bottom: 2px solid #000;
        padding-bottom: 5px;">
        <tr>
            <td>
                <strong>Invoice No.:&nbsp; </strong>
                <%:Model.InvoiceNo%>
            </td>
            <td>
                <strong>Invoice Date:&nbsp; </strong>
                <%:TimeFormat.DateFormat(Model.InvoiceDate.ToString())%>
            </td>
            <td>
                <strong>PNR:&nbsp;</strong>
                <%:Model.PNR%>
            </td>
        </tr>
    </table>
    <br />
    <table cellpadding="0" cellspacing="" width="100%">
        <tr>
            <td style="vertical-align: top; width: 40%;">
                <strong>
                    <%:Model.VendorDetail.VendorName%></strong><br />
                <%:Model.VendorDetail.Address%><br />
                <%: Model.VendorDetail.PhoneNo %><br />
                <%: Model.VendorDetail.Email %><br />
                <label>
                    Pan No.:</label>
                <%: Model.VendorDetail.PanNo %>
            </td>
            <td style="text-align: right; vertical-align: top; width: 40%;">
                <strong>
                    <%:Model.AgencyDetail.AgencyName%></strong><br />
                <%:Model.AgencyDetail.Address%><br />
                Phone:&nbsp;
                <%:Model.AgencyDetail.PhoneNo%><br />
                <label>
                    Pan No.:</label>
                <%: Model.AgencyDetail.PanNo %>
            </td>
        </tr>
        <tr>
            <td colspan="2" style="font-size: 18px; width: 20%; text-align: center; vertical-align: middle;
                padding: 5px 0px;">
                <strong>DISTRIBUTOR INVOICE</strong>
            </td>
        </tr>
    </table>
    <table cellpadding="0" cellspacing="0" width="100%" style="border: 1px solid #000;
        margin-top: 5px;">
        <tr>
            <th style="padding: 2px 5px; border-bottom: 1px solid #666; border-right: 1px solid #666;
                text-align: left;">
                <strong>SN</strong>
            </th>
            <th style="padding: 2px 5px; border-bottom: 1px solid #666; border-right: 1px solid #666;
                text-align: left;">
                <strong>Ticket No</strong>
            </th>
            <th style="padding: 2px 5px; border-bottom: 1px solid #666; border-right: 1px solid #666;
                text-align: left;">
                <strong>Sectors</strong>
            </th>
            <th style="padding: 2px 5px; border-bottom: 1px solid #666; border-right: 1px solid #666;
                text-align: left;">
                <strong>Flight</strong>
            </th>
            <th style="padding: 2px 5px; border-bottom: 1px solid #666; border-right: 1px solid #666;
                text-align: left;">
                <strong>Flight Date</strong>
            </th>
            <th style="padding: 2px 5px; border-bottom: 1px solid #666; border-right: 1px solid #666;
                text-align: left;">
                <strong>PAX Name</strong>
            </th>
            <th style="padding: 2px 5px; border-bottom: 1px solid #666; border-right: 1px solid #666;
                text-align: left;">
                <strong>Type</strong>
            </th>
            <th style="padding: 2px 5px; border-bottom: 1px solid #666; border-right: 1px solid #666;
                text-align: left;">
                <strong>Class</strong>
            </th>
            <th style="padding: 2px 5px; border-bottom: 1px solid #666; border-right: 1px solid #666;
                text-align: left;">
                <strong>Fare</strong>
            </th>
            <th style="padding: 2px 5px; border-bottom: 1px solid #666; border-right: 1px solid #666;
                text-align: left;">
                <strong>Tax</strong>
            </th>
            <th style="padding: 2px 5px; border-bottom: 1px solid #666; text-align: left;">
                <strong>O/C</strong>
            </th>
        </tr>
        <%
            var mainDetail = Model.ItineraryDetails;
            int mainDetailcount = mainDetail.Count;

            string flightNo = string.Empty;
            string bic = string.Empty;
            string DepartDate = string.Empty;
            for (int m = 0; m < mainDetailcount; m++)
            {
                foreach (var segment in mainDetail[m].Segments)
                {
                    flightNo += segment.AirlineCode + "-" + segment.FlightNo + ",";
                    bic += segment.Class + ",";

                }
                DepartDate = mainDetail[m].Segments.First().DepartureDate; ;
                var itinerary = mainDetail[m];
                var pax = itinerary.PassengerDetail;
                int paxCount = pax.Count;
                for (int i = 0; i < paxCount; i++)
                {
        %>
        <tr>
            <td style="padding: 2px 5px; border-bottom: 1px solid #666; border-right: 1px solid #666;
                vertical-align: top;">
                <%: i+1%>
            </td>
            <td style="padding: 2px 5px; border-bottom: 1px solid #666; border-right: 1px solid #666;
                vertical-align: top;">
                <%--  <%: itinerary.TicketNo%>--%>
                <%: pax[i].TicketNo%>
            </td>
            <td style="padding: 2px 5px; border-bottom: 1px solid #666; border-right: 1px solid #666;
                vertical-align: top;">
                <%:itinerary.Sector %>
            </td>
            <td style="padding: 2px 5px; border-bottom: 1px solid #666; border-right: 1px solid #666;
                vertical-align: top;">
                <%:flightNo.TrimEnd(',')%>
            </td>
            <td style="padding: 2px 5px; border-bottom: 1px solid #666; border-right: 1px solid #666;
                vertical-align: top;">
                <%:TimeFormat.DateFormat(DepartDate.ToString())%>
            </td>
            <td style="padding: 2px 5px; border-bottom: 1px solid #666; border-right: 1px solid #666;
                vertical-align: top;">
                <%: pax[i].PassengerName%><br />
            </td>
            <td style="padding: 2px 5px; border-bottom: 1px solid #666; border-right: 1px solid #666;
                vertical-align: top;">
                <%: pax[i].PassengerType%>
            </td>
            <td style="padding: 2px 5px; border-bottom: 1px solid #666; border-right: 1px solid #666;
                vertical-align: top;">
                <%:bic.TrimEnd(',')%>
            </td>
            <td style="padding: 2px 5px; border-bottom: 1px solid #666; border-right: 1px solid #666;
                vertical-align: top;">
                <%:string.Format("{0:#,#,#}",pax[i].Fare)%>
            </td>
            <td style="padding: 2px 5px; border-bottom: 1px solid #666; border-right: 1px solid #666;
                vertical-align: top;">
                <%: string.Format("{0:#,#,#}",pax[i].Tax) %>
            </td>
            <td style="padding: 2px 5px; border-bottom: 1px solid #666; vertical-align: top;">
                <%: pax[i].OtherCharge %>
            </td>
        </tr>
        <% }
            } %>
    </table>
    <br />
    <table cellpadding="0" cellspacing="" width="100%">
        <tr>
            <td style="vertical-align: top;">
                <strong><em>Notes: &nbsp;</em></strong><br />
                All Penalties as per fare rules<br />
                <br />
                <br />
                <strong>Billed By:&nbsp; </strong>
                <%:Model.BilledBy%><br />
                <strong>Billed To: &nbsp; </strong>
                <%:Model.TicketedToAgent%>
            </td>
            <td style="text-align: left; vertical-align: top; width: 50%;">
                <table width="100%" cellspacing="0" cellpadding="0">
                    <tbody>
                        <tr>
                            <% if (Model.Currency == "USD")
                               { %>
                            <td>
                                <span style="background: #666; color: #fff; padding: 2px 5px;">Amount in USD</span>
                            </td>
                            <%} %>
                            <% else
                               { %>
                            <td>
                                <span style="background: #666; color: #fff; padding: 2px 5px;">Amount in Rs</span>
                            </td>
                            <%} %>
                        </tr>
                    </tbody>
                </table>
                <table cellspacing="0" cellpadding="0" width="100%" style="border: 1px solid #666;">
                    <tr>
                        <td style="padding: 5px 5px; text-align: right; border-bottom: 1px solid #666;">
                            &nbsp;
                        </td>
                        <td style="padding: 5px 5px; text-align: right; border-bottom: 1px solid #666; border-right: 1px solid #666;">
                            <strong>Total</strong>
                        </td>
                        <td style="padding: 5px 5px; text-align: right; border-bottom: 1px solid #666;">
                            <%:string.Format("{0:#,#,#}",Model.GrossAmount)%>
                        </td>
                    </tr>
                    <tr>
                        <td style="padding: 2px 5px; text-align: right;">
                            Less
                        </td>
                        <td style="padding: 2px 5px; text-align: right; border-right: 1px solid #666;">
                            <strong>Discount</strong>
                        </td>
                        <td style="padding: 2px 5px; text-align: right;">
                            <%:string.Format("{0:#,#,#}",Model.CommissionEarned)%>
                        </td>
                    </tr>
                    <tr>
                        <td style="padding: 2px 5px; text-align: right;">
                            Add
                        </td>
                        <td style="padding: 2px 5px; text-align: right; border-right: 1px solid #666;">
                            <strong>Service Tax</strong>
                        </td>
                        <td style="padding: 2px 5px; text-align: right;">
                            <%:string.Format("{0:#,#,#}",Model.ServiceTax)%>
                        </td>
                    </tr>
                    <tr>
                        <td style="padding: 2px 5px; text-align: right;">
                            Add
                        </td>
                        <td style="padding: 2px 5px; text-align: right; border-right: 1px solid #666;">
                            <strong>Transaction Fee</strong>
                        </td>
                        <td style="padding: 2px 5px; text-align: right;">
                            <%:string.Format("{0:#,#,#}",Model.TransactionFee)%>
                        </td>
                    </tr>
                    <tr>
                        <td style="padding: 2px 5px; text-align: right; border-bottom: 1px solid #666;">
                            &nbsp;
                        </td>
                        <td style="padding: 2px 5px; text-align: right; border-bottom: 1px solid #666; border-right: 1px solid #666;">
                            <strong>Grand Total</strong>
                        </td>
                        <td style="padding: 2px 5px; text-align: right; border-bottom: 1px solid #666;">
                            <%:string.Format("{0:#,#,#}",Model.NetAmount)%>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                Authorized by: ..............................................
            </td>
        </tr>
    </table>
</div>
