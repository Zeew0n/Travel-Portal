<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/AirlineMain.Master"
    Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Airline.Models.OffLineBookViewModel.OfflineBookViewModel>" %>

<%@ Import Namespace="ATLTravelPortal.Helpers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Detail
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <%Html.RenderPartial("Utility/VUC_MessagePanel"); %>
    <%Html.EnableClientValidation(); %>
    <% using (Html.BeginForm("Edit", "IndianLccAirOfflineBook", FormMethod.Post))
       {%>
    <%: Html.ValidationSummary(true) %>
    <%
           if (Model != null)
           {
    %>
    <%foreach (var mpnr in Model.PNRBookedList)
      {%>
    <%: Html.HiddenFor(model => model.PNRBookedList[0].MPNRId) %>
    <div class="pageTitle">
        <p class="float-right" style="color: #00810C;">
            <a href="#" class="detailsPopup"><strong>
                <%:Model.PNRBookedList.FirstOrDefault().UserDetail.AgentName %></strong> <span><b></b>
                    <%=Model.PNRBookedList.FirstOrDefault().UserDetail.AgencyDescription%></span>
            </a>&nbsp; <strong style="color: #00810C;">
                <%:Model.PNRBookedList[0].TicketStatus %></strong></p>
        <h3 style="padding-bottom: 10px;">
            <strong>Booking Reference No :</strong>&nbsp;<strong class="redTxt"><%:mpnr.BookingRefNo%></strong>
        </h3>
    </div>
    <br />
    <%
int pnrcount = 0;

foreach (var pnrInfo in mpnr.PNRDetails)
{
    %>
    <div class="atsfltsearchWrap clearfix">
        <div class="borderBox">
            <%-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@ Passenger Information Starts @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@ --%>
            <%-- <strong>GDS PNR:</strong> <span class="redTxt"><strong><%:pnrInfo.PNR %></strong></span>--%>
            <div class="form-box1-row">
                <div class="form-box1-row-content float-left">
                    <p>
                        <label>
                            GDS PNR</label>
                        <%: Html.TextBoxFor(model => model.PNRBookedList[0].PNRDetails[pnrcount].PNR, new { @id = "MainPnr" + pnrcount ,@Class="pnr"})%>
                        <% Html.ValidationMessageFor(model => model.PNRBookedList[0].PNRDetails[pnrcount].PNR, "Required 5 or 6 alphanumeric");%>
                        <span class="redtxt">*</span>
                    </p>
                </div>
                <div class="form-box1-row-content float-right">
                    <p>
                        <label>
                            Booking Source
                        </label>
                        <%: Html.DropDownListFor(model => model.PNRBookedList[0].PNRDetails[pnrcount].BookingSource,Model.BookingBourceList)%>
                        <% Html.ValidationMessageFor(model => model.PNRBookedList[0].PNRDetails[pnrcount].BookingSource);%>
                        <span class="redtxt">*</span>
                    </p>
                </div>
            </div>
            <br />
            <% if (pnrInfo.PassengerDetail != null)
               { %>
            <div class="box1">
                <h3 class="hd3">
                    Ticket Information
                </h3>
                <div class="form-box3 ">
                </div>
            </div>
            <div class="ledger_subtable create_tbl" style="border: 1px solid #ccc;">
                <table width="100%" class="data-table">
                    <tr>
                        <th>
                            Name
                        </th>
                        <th>
                            Mobile
                        </th>
                        <th>
                            Pax Type
                        </th>
                        <th>
                            Ticket Id
                        </th>
                        <th>
                            Ticket No
                        </th>
                        <th>
                            Endorsment
                        </th>
                    </tr>
                    <%
                   int paxcount = 0;
                   foreach (var ticket in pnrInfo.PassengerDetail)
                   { %>
                    <tr>
                        <td>
                            <span class="orangeTxt"><strong>
                                <%:ticket.PassengerPrefix%>
                                <%:ticket.FirstName%>
                                &nbsp;
                                <%:ticket.LastName%>
                            </strong></span>
                        </td>
                        <td>
                            <span class="orangeTxt"><strong>
                                <%:ticket.Phone%></strong></span>
                        </td>
                        <td>
                            <%:ticket.PaxType%>
                        </td>
                        <td>
                            <%:ticket.FareDetail.TktId%>
                        </td>
                        <td>
                            <%:Html.TextBoxFor(model=>model.PNRBookedList[0].PNRDetails[pnrcount].PassengerDetail[paxcount].FareDetail.TicketNumber) %>
                            <span class="redtxt">*</span>
                            <% Html.ValidationMessageFor(model => model.PNRBookedList[0].PNRDetails[pnrcount].PassengerDetail[paxcount].FareDetail.TicketNumber);%>
                            <% paxcount++; %>
                        </td>
                    </tr>
                    <% } %>
                </table>
            </div>
            <% } %>
            <%-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@ Passenger Information Ends @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@ --%>
            <br />
            <%-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@ Passenger Information Starts @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@ --%>
            <% if (pnrInfo.SegmentDetail != null)
               { %>
            <div class="box1">
                <h3 class="hd3">
                    Segment Information
                </h3>
                <div class="form-box3 ">
                </div>
            </div>
            <div class="ledger_subtable create_tbl" style="border: 1px solid #ccc;">
                <table width="100%" class="data-table">
                    <tr>
                        <th>
                            Airline
                        </th>
                        <th>
                            Flight Number
                        </th>
                        <th>
                            Class
                        </th>
                        <th>
                            Departure City
                        </th>
                        <th>
                            Departure Date(Time)
                        </th>
                        <th>
                            Arrival City
                        </th>
                        <th>
                            Arrival Date(Time)
                        </th>
                        <th colspan='2'>
                            Segment Status
                        </th>
                    </tr>
                    <%
				   
                   foreach (var segment in pnrInfo.SegmentDetail)
                   { %>
                    <tr>
                        <td>
                            <span class="orangeTxt"><strong>
                                <%:segment.AirlineName + "(" + segment.AirlineCode + ")"%></strong></span>
                        </td>
                        <td>
                            <%:segment.FlightNumber%>
                        </td>
                        <td>
                            <span class="orangeTxt"><strong>
                                <%:segment.BIC%></strong></span>
                        </td>
                        <td>
                            <%:segment.DepartCityCode%>
                            <%-- <%:segment.OriginDetails.AirportName +" ("+segment.OriginDetails.AirportCode+")" %>--%>
                        </td>
                        <td>
                            <%:segment.DepartDate != null ? TimeFormat.DateFormat(segment.DepartDate.ToString()) : ""%>
                            <%:"(" + segment.DepartTime + ")"%>
                        </td>
                        <td>
                            <%:segment.ArrivalCityCode%>
                        </td>
                        <td>
                            <%:segment.ArrivalDate != null ? TimeFormat.DateFormat(segment.ArrivalDate.ToString()) : ""%>
                            <%:"(" + segment.ArrivalTime + ")"%>
                        </td>
                        <td>
                            <span class="orangeTxt"><strong>Confirmed</strong></span>
                        </td>
                    </tr>
                    <% } %>
                </table>
            </div>
            <% } %>
            <br />
            <%-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@ Fare Starts @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@ --%>
            <%
    var fareDetail = pnrInfo.PassengerDetail;
		
            %>
            <% if (fareDetail != null)
               { %>
            <div class="box1">
                <h3 class="hd3">
                    Fare Information
                </h3>
                <div class="form-box3 ">
                </div>
            </div>
            <div class="ledger_subtable create_tbl" style="border: 1px solid #ccc;">
                <table width="100%" class="data-table">
                    <tr>
                        <th>
                            Base Fare
                        </th>
                        <th>
                            Discount
                        </th>
                        <th>
                            YQ
                        </th>
                        <th>
                            Tax
                        </th>
                        <th>
                            Service Tax
                        </th>
                        <th>
                            Other Charges
                        </th>
                        <th>
                            Agent SC
                        </th>
                        <%-- <th>TDS</th>--%>
                        <th>
                            Total Fare
                        </th>
                    </tr>
                    <%
                   double basefare = 0,
                       discount = 0,
                       YQ = 0,
                       tax = 0,
                       othercharge = 0,
                       servicetax = 0,
                       agentservicecharge = 0,
                       totalFare = 0,
                        markup = 0,
                        AgentAirlineMarkup = 0,
                       TDS = 0,
                       sellingadditionaltxnfee = 0;
                   foreach (var FareInformation in fareDetail)
                   {
                       basefare += FareInformation.FareDetail.SellingBaseFare;
                       discount += FareInformation.FareDetail.DiscountAmount;
                       TDS += Math.Ceiling(FareInformation.FareDetail.DiscountAmount * 0.1);
                       YQ += FareInformation.FareDetail.SellingFSC;

                       tax += (FareInformation.FareDetail.SellingTax + FareInformation.FareDetail.SellingAdditionalTxnFee + FareInformation.FareDetail.AgentAirlineMarkup- FareInformation.FareDetail.SellingFSC) ;
                       markup = FareInformation.FareDetail.MarkupAmount;
                       othercharge += FareInformation.FareDetail.SellingOtherCharges;
                       servicetax += FareInformation.FareDetail.SellingServiceTax;
                       agentservicecharge += 0;
                       AgentAirlineMarkup += FareInformation.FareDetail.AgentAirlineMarkup;
                       sellingadditionaltxnfee += FareInformation.FareDetail.SellingAdditionalTxnFee;


                       //totalFare += FareInformation.FareDetail.SellingAdditionalTxnFee +
                       //              FareInformation.FareDetail.SellingBaseFare ?? 0 +
                       //             FareInformation.FareDetail.SellingTax ?? 0 +
                       //             FareInformation.FareDetail.SellingOtherCharges +
                       //             FareInformation.FareDetail.SellingServiceTax -
                       //             FareInformation.FareDetail.DiscountAmount +
                       //             FareInformation.FareDetail.AgentServiceCharge +
                       //             FareInformation.FareDetail.AgentAirlineMarkup;

                       if (discount < 0)
                       {
                           totalFare = basefare + Math.Abs(discount) + tax + servicetax + othercharge + agentservicecharge + YQ;
                       }
                       else
                       {
                           totalFare = basefare - discount + tax + servicetax + othercharge + agentservicecharge + YQ;
                       }





                   } %>
                    <tr>
                        <td>
                            <%:string.Format("{0:#,#.#}",basefare)%>
                        </td>
                        <td>
                            <%:discount%>
                        </td>
                        <td>
                            <%: string.Format("{0:#,#.#}", YQ)%>
                        </td>
                        <td>
                            <%:string.Format("{0:#,#.#}",tax )%>
                        </td>
                        <td>
                            <%:string.Format("{0:#,#.#}",servicetax) %>
                        </td>
                        <td>
                            <%:string.Format("{0:#,#.#}", othercharge)%>
                        </td>
                        <td>
                            <%:string.Format("{0:#,#.#}", agentservicecharge)%>
                        </td>
                        <%--<td><%:TDS%></td>--%>
                        <td>
                            <span class="orangeTxt"><strong>Rs&nbsp;<%:string.Format("{0:#,#.#}", totalFare)%>
                            </strong></span>
                        </td>
                    </tr>
                </table>
            </div>
            <span class="orangeTxt">* Includes Deal Markup Amount <font color="#0091D0">
                <%:markup %></font> and Agent Markup Amount<font color="#0091D0">
                    <%:AgentAirlineMarkup%></font></span>
            <%-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@ Fare Ends @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@ --%>
            <br />
            <%-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@ General PNR Information Starts @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@ --%>
            <div class="box1">
                <h3 class="hd3">
                    General PNR Information
                </h3>
                <div class="form-box3 ">
                </div>
            </div>
            <div class="ledger_subtable create_tbl" style="border: 1px solid #ccc;">
                <table width="100%" class="data-table">
                    <tr>
                        <th>
                            Origin
                        </th>
                        <th>
                            Destination
                        </th>
                        <th>
                            Airlines PNR
                        </th>
                        <th>
                            Remarks
                        </th>
                    </tr>
                    <%
int segcount = 0;
foreach (var segment in pnrInfo.SegmentDetail)
{%>
                    <tr>
                        <td>
                            <%: segment.DepartCityCode%>
                        </td>
                        <td>
                            <%:segment.ArrivalCityCode%>
                        </td>
                        <td>
                            <%-- <span class="orangeTxt"><strong>
								<%:pnrInfo.SegmentDetail.FirstOrDefault().AirlineRefNumber %></strong></span>--%>
                            <%:
                             Html.TextBoxFor(model => model.PNRBookedList[0].PNRDetails[pnrcount].SegmentDetail[segcount].AirlineRefNumber, new { @class = "MainPnr" + pnrcount + "AirlinePnr", @style = "text-transform: uppercase;" })%>
                            <span class="redtxt">*</span>
                            <% Html.ValidationMessageFor(model => model.PNRBookedList[0].PNRDetails[pnrcount].SegmentDetail[segcount].AirlineRefNumber);%>
                            <% segcount++; %>
                        </td>
                        <td>
                            <%: Html.TextBox("Remark") %>
                            <%--  <%:pnrInfo.PnrSectorList.FirstOrDefault().SegmentList.FirstOrDefault().VendorRemarks%> --%>
                        </td>
                    </tr>
                    <% } %>
                </table>
            </div>
            <%-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@ General PNR Information Ends @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@ --%>
        </div>
    </div>
    <br />
    <% } %>
    <% pnrcount++; %>
    <% }
      }
           }
    %>
    <input type="submit" value="Issue" onclick="return confirm('Are you sure you want to Issue?')"
        class="float-left" />
    <%} %>
    <% using (Html.BeginForm("Delete", "IndianLccAirOfflineBook", FormMethod.Post))
       {%>
    <%: Html.HiddenFor(model => model.PNRBookedList[0].MPNRId) %>
    <input type="submit" value="Reject" onclick="return confirm('Are you sure you want to Reject?')" />
    <%} %>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CssContent" runat="server">
    <link href="/Content/css/global.css" rel="stylesheet" type="text/css" />
    <link href="/Content/css/atsfltsearch.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .box1
        {
            margin: 0px;
        }
        input.input-validation-error
        {
            background-color: #FFEEEE;
            border: 1px solid #FF0000;
        }
        .pageTitle span
        {
            height: auto;
            width: auto;
            background: none;</style>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
    <script type="text/javascript">

        $('.pnr').live('keyup', function (e) {
            var eachpnrid = $(this).attr('id');
            $("#" + eachpnrid).val(($("#" + eachpnrid).val()).toUpperCase());
            if (e.which >= 97 && e.which <= 122) {
                var newKey = e.which - 32;
                e.keyCode = newKey;
                e.charCode = newKey;
            }
            $('.' + eachpnrid + "AirlinePnr").val(($("#" + eachpnrid).val()).toUpperCase());
        });


    </script>
</asp:Content>
