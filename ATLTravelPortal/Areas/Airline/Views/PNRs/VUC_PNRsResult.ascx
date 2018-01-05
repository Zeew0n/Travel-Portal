<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<ATLTravelPortal.Areas.Airline.Models.PNRRetrieveResult>" %>


 <%       
        if (Model != null && Model.CreationDt != DateTime.MinValue)
        {%><div class="borderBox">
   
    <%-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@ General PNR Information Starts @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@ --%>
    <div class="box1">
        <h3 style="background-color: #EDF3F9; padding: 3px 5px;">
            General PNR Information
        </h3>
        <div class="form-box3 ">
        </div>
    </div>
    <div class="ledger_subtable create_tbl" style="border: 1px solid #ccc;">
        <table width="100%" class="data-table">
            <tr>
                <th>
                    Record Locator
                </th>
                <th>
                    Creation Date
                </th>
                <th>
                    E-Ticket Exists
                </th>
                <th>
                    Fare File Exists
                </th>
                <th>
                    Received From
                </th>
            </tr>
            <tr>
                <td>
                    <span class="orangeTxt"><strong>
                        <%: Model.RecLoc%></strong></span>
                </td>
                <td>
                    <%: (Model.CreationDt != null ? ATLTravelPortal.Helpers.TimeFormat.DateFormat(Model.CreationDt.ToString()) :"") %>
                </td>
                <td>
                    <%:Model.ETkDataExistInd%>
                </td>
                <td>
                    <span class="orangeTxt"><strong>
                        <%: Model.FareDataExistsInd%></strong></span>
                </td>
                <td>
                    <%: Model.OrigRcvd%>
                </td>
            </tr>
        </table>
    </div>
    <%-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@ General PNR Information Ends @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@ --%>
    <br />
    <%-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@  Airline PNR Starts @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@ --%>
    <%
        if (Model.vendorRecordLocatorList != null)
        {
    %>
    <div class="box1">
        <h3 style="background-color: #EDF3F9; padding: 3px 5px;">
            Airline PNR
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
                    Airline PNR
                </th>
                <th>
                    Date
                </th>
                <th>
                    Time
                </th>
            </tr>
            <%foreach (var vndRec in Model.vendorRecordLocatorList)
              { %>
            <tr>
                <td>
                    <%: vndRec.Vendor%>
                </td>
                <td>
                    <span class="orangeTxt"><strong>
                        <%: vndRec.RecordLocator%></strong></span>
                </td>
                <td>
                    <%:ATLTravelPortal.Helpers.TimeFormat.DateFormat(vndRec.DtStamp.ToString())%>
                </td>
                <td>
                    <%:ATLTravelPortal.Helpers.TimeFormat.GetFormattedTime(vndRec.TmStamp)%>
                </td>
            </tr>
            <%} %>
        </table>
    </div>
    <%
        } %>
    <%-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@  Airline PNR Ends @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@ --%>
    <br />
    <%-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@ Passenger Information Starts @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@ --%>
    <div class="box1" id="PassangerInfo">
        <%
            if (Model.passengerList != null)
            {
        %>
        <div class="box1">
            <h3 style="background-color: #EDF3F9; padding: 3px 5px;">
                Passenger Information
            </h3>
            <div class="form-box3 ">
            </div>
        </div>
        <div class="ledger_subtable create_tbl" style="border: 1px solid #ccc;">
            <table width="100%" class="data-table">
                <tr>
                    <th>
                        First Name
                    </th>
                    <th>
                        Last Name
                    </th>
                    <th>
                        Passenger Number
                    </th>
                    <th>
                        Name Remark
                    </th>
                    <%--     <th>
                        Seat Location
                    </th>
                    <th>
                        Seat Status
                    </th>--%>
                </tr>
                <%
                    foreach (var passenger in Model.passengerList)
                    {%>
                <tr>
                    <td>
                        <%: passenger.FirstName%>
                    </td>
                    <td>
                        <%: passenger.LastName%>
                    </td>
                    <td>
                        <%:passenger.AbsNum%>
                    </td>
                    <td>
                        <%: passenger.NameRmk%>
                    </td>
                    <%--  <%if (passenger.SeatAssignmentInfo != null)
                      { %>
                    <td>
                        <%: passenger.SeatAssignmentInfo.Locn%>
                    </td>
                    <td>
                        <a rel="#" class="info orangeTxt" style="font-weight: bold;">
                            <%:passenger.SeatAssignmentInfo.Status%>
                            <span>
                                <%:passenger.SeatAssignmentInfo.Status%>
                                →
                                <br />
                                <%:passenger.SeatAssignmentInfo.StatusExplanation%>
                                <b>&nbsp;</b> </span></a>
                    </td>
                    <%} %>--%>
                </tr>
                <%} %>
            </table>
        </div>
        <%
            } %>
    </div>
    <%-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@ Passenger Information Ends @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@ --%>
    <br />
    <%-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@  Airline Remark Starts @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@ --%>
    <%
        if (Model.vndRemark != null)
        {
    %>
    <div class="box1">
        <h3 style="background-color: #EDF3F9; padding: 3px 5px;">
            Airline Remark
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
                    Airline Type
                </th>
                <th>
                    Remark
                </th>
                <th>
                    Remark Type
                </th>
                <th>
                    Remark No
                </th>
                <th>
                    Date
                </th>
                <th>
                    Time
                </th>
            </tr>
            <%foreach (var vndRemark in Model.vndRemark)
              { %>
            <tr>
                <td>
                    <%: vndRemark.Vnd%>
                </td>
                <td>
                    <%:  vndRemark.VType%>
                </td>
                <td>
                    <%: vndRemark.Rmk%>
                </td>
                <td>
                    <%: vndRemark.RmkType%>
                </td>
                <td>
                    <%:vndRemark.RmkNum%>
                </td>
                <td>
                    <%: vndRemark.DtStamp%>
                </td>
                <td>
                    <%: vndRemark.TmStamp%>
                </td>
            </tr>
            <%} %>
        </table>
    </div>
    <%
        } %>
    <%-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@  Airline Remark Ends @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@ --%>
    <br />
    <%-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@  Phone Information Starts @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@ --%>
    <%
        if (Model.phoneInfo != null)
        {%>
    <div class="box1" id="Div1">
        <h3 style="background-color: #EDF3F9; padding: 3px 5px;">
            Phone Information
        </h3>
        <%
            foreach (var phone in Model.phoneInfo)
            {%>
        <div class="form-box3 borderBox">
            <div class="flightType">
                <u><strong></strong></u>
            </div>
            <div class="form-box1-row">
                <div class="form-box1-row-content float-left">
                    <div>
                        <label>
                            City Name:</label>
                        <b>
                            <%: phone.CityName%></b>
                    </div>
                </div>
                <div class="form-box1-row-content float-left">
                    <div>
                        <label>
                            Phone Name:</label>
                        <b>
                            <%: phone.PhoneNum%></b>
                    </div>
                </div>
            </div>
        </div>
        <%}%>
    </div>
    <%} %>
    <%-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@  Phone Information Ends @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@ --%>
    <br />
    <%-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@  Segment Information Starts @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@ --%>
    <%
        if (Model.segList != null)
        {
    %>
    <div class="box1">
        <h3 style="background-color: #EDF3F9; padding: 3px 5px;">
            Segment Information
        </h3>
        <div class="form-box3 ">
        </div>
    </div>
    <div class="ledger_subtable create_tbl" style="border: 1px solid #ccc;">
        <table width="100%" class="data-table">
            <tr>
                <th>
                    Segment No.
                </th>
                <th>
                    Airline
                </th>
                <th>
                    Flight Number
                </th>
                <th>
                    BIC
                </th>
                <th>
                    Departure City
                </th>
                <th>
                    Departure Time
                </th>
                <th>
                    Arrival City
                </th>
                <th>
                    Arrival Time
                </th>
                <th>
                    Creation Date
                </th>
                <th colspan='2'>
                    Segment Status
                </th>
            </tr>
            <%foreach (var segment in Model.segList)
              { %>
            <tr>
                <td>
                    <%: segment.SegNum%>
                </td>
                <td>
                    <%: segment.AirV%>
                </td>
                <td>
                    <%: segment.FltNum%>
                </td>
                <td>
                    <%: segment.BIC%>
                </td>
                <td>
                    <%: segment.StartAirp%>
                </td>
                <td>
                    <%:ATLTravelPortal.Helpers.TimeFormat.GetFormattedTime(segment.StartTm)%>
                </td>
                <td>
                    <%: segment.EndAirp%>
                </td>
                <td>
                    <%:ATLTravelPortal.Helpers.TimeFormat.GetFormattedTime(segment.EndTm)%>
                </td>
                <td>
                    <%:ATLTravelPortal.Helpers.TimeFormat.DateFormat(segment.Dt.ToString())%>
                </td>
                <td colspan='2'>
                    <a rel="#" class="info orangeTxt" style="font-weight: bold;">
                        <%: segment.Status%>
                        <span>
                            <%: segment.Status%>
                            →
                            <br />
                            <%:segment.StatusExplanation%>
                            <b>&nbsp;</b> </span></a>
                </td>
            </tr>
            <%} %>
        </table>
    </div>
    <% 
        }%>
    <%-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@  Segment Information Ends @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@ --%>
    <br />
    <%-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@  Seat Sell Starts @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@ --%>
    <%
        if (Model.seatSellList != null && Model.seatSellList.Count > 0)
        {
    %>
    <div class="box1">
        <h3 style="background-color: #EDF3F9; padding: 3px 5px;">
            Seat Sell
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
                    Start Airport
                </th>
                <th>
                    End Airport
                </th>
                <th>
                    BIC
                </th>
                <th>
                    Flight No
                </th>
                <th>
                    Flight Seg No
                </th>
                <th>
                    Start Date
                </th>
                <th>
                    No of Passenger
                </th>
            </tr>
            <%foreach (var seatSell in Model.seatSellList)
              { %>
            <tr>
                <td>
                    <%: seatSell.AirVendor%>
                </td>
                <td>
                    <%: seatSell.StartAirport%>
                </td>
                <td>
                    <%: seatSell.EndAirport%>
                </td>
                <td>
                    <%: seatSell.BIC%>
                </td>
                <td>
                    <%: seatSell.FlightNum%>
                </td>
                <td>
                    <%:seatSell.FlightSegNum%>
                </td>
                <td>
                    <%: ATLTravelPortal.Helpers.TimeFormat.DateFormat(seatSell.StartDt.ToString())%>
                </td>
                <td>
                    <%:seatSell.NumOfPax%>
                </td>
            </tr>
            <%} %>
        </table>
    </div>
    <% 
        }%>
    <%-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@  Seat Sell Starts @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@ --%>
  

    <span style="color: green; font-weight: bold; font-size: 13px;"><strong>
        <%if (ViewData["message"] != null)
          { %>
        <%:ViewData["message"] %>
        <%} %>
    </strong></span>
</div>
  <%} %>

