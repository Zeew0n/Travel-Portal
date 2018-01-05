<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/AirlineMain.Master"
    Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Airline.Models.OffLineBookViewModel.OfflineBookViewModel>" %>

<%@ Import Namespace="ATLTravelPortal.Helpers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Detail
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <%Html.RenderPartial("Utility/VUC_MessagePanel"); %>
    <%Html.EnableClientValidation(); %>
    <% using (Html.BeginForm("Details", "AirOfflineBook", FormMethod.Post, new { @onsubmit = "return validatePaxFare();", id = "ATForm", enctype = "multipart/form-data" }))
       {%>
    <%: Html.ValidationSummary(true) %>
    <%:Html.HiddenFor(model=>model.isDeleted) %>
    <%
           if (Model != null)
           {
                    
    %>
    <%foreach (var mpnr in Model.PNRBookedList)
      {%>
    <%: Html.HiddenFor(model => model.PNRBookedList[0].MPNRId) %>
    <%--<%: Html.HiddenFor(model => model.PNRBookedList[0].ServiceProviderId) %>--%>
    <%:Html.Hidden("PreviousServiceProviderId",Model.PNRBookedList[0].ServiceProviderId) %>
    <div class="pageTitle">
        <%--        <% ATLTravelPortal.Areas.Airline.Repository.AirOfflineBookProvider
    ser = new ATLTravelPortal.Areas.Airline.Repository.AirOfflineBookProvider(); int
    ticketstatusid = Model.PNRBookedList[0].TicketStatusId;
    %>

         <p id="buttonBar" class="float-right">
        <% if (ticketstatusid!= 16 && ticketstatusid != 4 && ticketstatusid != 19 && ticketstatusid != 25 && ticketstatusid != 27 && ticketstatusid != 29 && ticketstatusid != 32 && ticketstatusid != 26 && ticketstatusid != 33 && ticketstatusid!=34)
           {
        %>
        <input type="submit" value="Issue PNR" name="Issue" id="Issue" onclick="return confirm('Are
    you sure you want to Issue?')" class="float-left" />
        <input type="submit" value="Cancel PNR" id="Cancel" name="Cancel" onclick="return confirm('Are you sure
    you want to Reject?')" />
        <%} %>
        <%if (ticketstatusid == 27 || ticketstatusid == 25)
          { %>
        <input type="submit" value="Cancel PNR" id="Cancel" name="Cancel" onclick="return
    confirm('Are you sure you want to Reject?')" />
        <%} %>
        <input type="submit" value="Save" name="Save" id="Save" onclick="return confirm('Are you sure you want to Save?')" />
        <% if (ticketstatusid == 14 || ticketstatusid == 17 || ticketstatusid == 1 || ticketstatusid == 25 || ticketstatusid == 28 || ticketstatusid == 24)
           { %>
        <%: Html.ActionLink("Back to List", "Index", null, new
    {@class="linkButton" })%>
        <%} %>
        <%else
           { %>
        <%: Html.ActionLink("Back to List", "Index", "IssuedTicket", null, new
    { @class = "linkButton" })%>
        <%} %>
    </p>--%>
        <h3 style="padding-bottom: 10px; position: relative;">
            Booking on: <strong>
                <%: mpnr.ServiceProviderName %></strong> <span style="margin-left: 20px; position: absolute;
                    left: 37%; top: 0;"><strong style="color: #00810C; font-size: 18px;">
                        <%:Model.PNRBookedList[0].TicketStatus %></strong></span>
        </h3>
        <p class="float-right" style="color: #00810C;">
            <a href="#" class="detailsPopup"><strong>
                <%:Model.PNRBookedList.FirstOrDefault().UserDetail.AgentName %></strong><span><b></b><%=Model.PNRBookedList.FirstOrDefault().UserDetail.AgencyDescription%>
                    <%:Html.HiddenFor(model=>model.PNRBookedList[0].UserDetail.AgentId) %>
                    <%:Html.HiddenFor(model=>model.PNRBookedList[0].TicketStatusId) %>
                </span></a>&nbsp; <strong style="color: #00810C;"></strong>
        </p>
    </div>
    <br />
    <div style="width: 345px; background: #f5f5f5; border: 1px solid #ccc; padding: 10px;
        -moz-border-radius: 4px; border-radius: 4px; float: left;">
        <table width="100%" cellpadding="0" cellspacing="0" class="simpleStyle">
            <caption>
                <b><u>Account Detail</u></b><hr />
            </caption>
            <thead>
                <th>
                </th>
                <th>
                    NPR
                </th>
                <th>
                    USD
                </th>
            </thead>
            <tr>
                <td>
                    Credit Limit
                </td>
                <td>
                    <%:Model.AvailableBalance.CreditLimitNPR %>
                </td>
                <td>
                    <%:Model.AvailableBalance.CreditLimitUSD %>
                </td>
            </tr>
            <tr>
                <td>
                    Available Balance
                </td>
                <td>
                    <%:Model.AvailableBalance.CurrentBalanceNPR %>
                </td>
                <td>
                    <%:Model.AvailableBalance.CurrentBalanceUSD %>
                </td>
            </tr>
            <tr>
                <td>
                    Ledger Balance
                </td>
                <td>
                    <%:Model.AvailableBalance.LeadgerBalanceNPR %>
                </td>
                <td>
                    <%:Model.AvailableBalance.LeadgerBalanceUSD %>
                </td>
            </tr>
        </table>
    </div>
    <div style="width: 290px; background: #f5f5f5; border: 1px solid #ccc; padding: 10px;
        -moz-border-radius: 4px; border-radius: 4px; float: left; margin-left: 20px;">
        <table width="100%" cellpadding="0" cellspacing="0" class="simpleStyle">
            <thead>
                <th>
                </th>
                <th>
                    Branch Office
                </th>
                <th>
                    Distributor
                </th>
            </thead>
            <tr>
                <td>
                </td>
                <% if (Model.PNRBookedList.FirstOrDefault().UserDetail.BranchId == 1)
                   { %>
                <td>
                    -
                </td>
                <%} %>
                <% else
                   { %>
                <td>
                    <%:Model.PNRBookedList.FirstOrDefault().UserDetail.BranchOfficeName%>
                </td>
                <%} %>
                <% if (Model.PNRBookedList.FirstOrDefault().UserDetail.DistributorId == 1)
                   { %>
                <td>
                    -
                </td>
                <%} %>
                <% else
                   { %>
                <td>
                    <%:Model.PNRBookedList.FirstOrDefault().UserDetail.DistributorOfficeName%>
                </td>
                <%} %>
            </tr>
        </table>
    </div>
    <div style="width: 216px; background: #f5f5f5; border: 1px solid #ccc; padding: 10px;
        -moz-border-radius: 4px; border-radius: 4px; float: right; margin-left: 20px;">
        <table width="100%" cellpadding="0" cellspacing="0" class="simpleStyle">
            <caption>
                <b><u>User Detail</u></b><hr />
            </caption>
            <tr>
                <td>
                    <b>Name:</b>
                </td>
                <td>
                    <%: Model.PNRBookedList.FirstOrDefault().UserDetail.UserFullName%>
                </td>
            </tr>
            <tr>
                <td>
                    <b>Address:</b>
                </td>
                <td>
                    <%: Model.PNRBookedList.FirstOrDefault().UserDetail.UserAddress%>
                </td>
            </tr>
            <tr>
                <td>
                    <b>Mobile:</b>
                </td>
                <td>
                    <%: Model.PNRBookedList.FirstOrDefault().UserDetail.UserMobileNumber%>
                </td>
            </tr>
            <tr>
                <td>
                    <b>Phone:</b>
                </td>
                <td>
                    <%: Model.PNRBookedList.FirstOrDefault().UserDetail.UserPhoneNumber%>
                </td>
            </tr>
        </table>
    </div>
    <div class="clearboth">
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
            <div class="form-box1-row">
                <div class="form-box1-row-content float-left" style="width: 530px;">
                    <p>
                        <span style="float: left; margin-right: 7px;">
                            <label>
                                Source Using</label>
                            <%:Html.DropDownListFor(model => model.PNRBookedList[0].ServiceProviderId, Model.SelectListCollection.BookingSourceList, new { @onchange="ShowHideIssueButton(this);"})%>
                            <%:Html.ValidationMessageFor(model=>model.PNRDetails[0].BookingSource) %>
                        </span><span style="float: left;">
                            <label>
                                GDS PNR</label>
                            <% if (Model.PNRBookedList[0].ServiceProviderId == 3 || (Model.PNRBookedList[0].ServiceProviderId == 5 && Model.PNRBookedList[0].TicketStatusId == 33) || (Model.PNRBookedList[0].ServiceProviderId == 5 && Model.PNRBookedList[0].TicketStatusId == 34))
                               { %>
                            <%: Html.TextBoxFor(model => model.PNRBookedList[0].PNRDetails[pnrcount].PNR, new { @class = "pnr" })%>
                            <%} %>
                            <% else
                               { %>
                            <%: Html.TextBoxFor(model => model.PNRBookedList[0].PNRDetails[pnrcount].PNR, new { @class = "pnr" })%>
                            <% Html.ValidationMessageFor(model => model.PNRBookedList[0].PNRDetails[pnrcount].PNR, "Required 5 or 6 alphanumeric");%>
                            <span class="redtxt">*</span>
                            <%} %>
                        </span><span style="float: right;">
                            <label>
                                PCC</label>
                            <%: Html.TextBoxFor(model => model.PNRBookedList[0].PNRDetails[pnrcount].PCC)%>
                        </span>
                    </p>
                </div>
                <div class="form-box1-row-content float-right">
                    <p>
                        <span>
                            <label style="float: left;">
                                Remarks</label>
                            <%: Html.TextAreaFor(model => model.PNRBookedList[0].PNRDetails[pnrcount].Remarks, new { @style="width:250px; hegiht:100px;" })%>
                        </span>
                    </p>
                </div>
            </div>
            <br />
            <%-- ---------------------------------------------------------------%>
            <div class="box1">
                <h3 class="hd3">
                    PNR Information
                </h3>
                <div class="form-box3 ">
                </div>
            </div>
            <div class="ledger_subtable create_tbl" style="border: 1px solid #ccc;">
                <table width="100%" class="data-table">
                    <tr>
                        <th>
                            Prefix
                        </th>
                        <th>
                            First Name
                        </th>
                        <th>
                            Middle Name
                        </th>
                        <th>
                            Last Name
                        </th>
                    </tr>
                    <tr>
                        <td>
                            <%: Html.DropDownListFor(model=>model.PNRBookedList[0].PnrInfoPrefix, Model.PNRBookedList[0].PnrInfoPrefixList, new { @style = "width:60px;", @class = "required" })%>
                        </td>
                        <td>
                            <%: Html.TextBoxFor(model => model.PNRBookedList[0].PnrInfoFirstName, new {@onkeypress = "return CheckAlbhabet(event)" })%>
                        </td>
                        <td>
                            <%: Html.TextBoxFor(model => model.PNRBookedList[0].PnrInfoMiddleName, new { @onkeypress = "return CheckAlbhabet(event)" })%>
                        </td>
                        <td>
                            <%: Html.TextBoxFor(model => model.PNRBookedList[0].PnrInfoLastName, new { @onkeypress = "return CheckAlbhabet(event)" })%>
                        </td>
                    </tr>
                </table>
            </div>
            <%--  ----------------------------------------------------------------%>
            <% if (pnrInfo.PassengerDetail != null)
               { %>
            <div class="box1">
                <h3 class="hd3">
                    Passenger Information
                </h3>
                <div class="form-box3 ">
                </div>
            </div>
            <div class="ledger_subtable create_tbl" style="border: 1px solid #ccc;">
                <table width="100%" class="data-table">
                    <tr>
                        <th>
                            Pax Type
                        </th>
                        <th>
                            Prefix
                        </th>
                        <th>
                            First Name
                        </th>
                        <th>
                            Middle Name
                        </th>
                        <th>
                            Last Name
                        </th>
                        <th>
                            Ticket No
                        </th>
                        <th>
                            DOB
                        </th>
                    </tr>
                    <%
                   int paxcount = 0;
                   foreach (var ticket in pnrInfo.PassengerDetail)
                   { %>
                    <tr>
                        <td>
                            <%: Html.DropDownListFor(model=>model.PNRBookedList[0].PNRDetails[pnrcount].PassengerDetail[paxcount].PaxType, Model.PNRBookedList[0].PNRDetails[pnrcount].PassengerDetail[paxcount].PaxTypeList, new { @style = "width:60px;", @class = "required" })%>
                        </td>
                        <td>
                            <%: Html.DropDownListFor(model => model.PNRBookedList[0].PNRDetails[pnrcount].PassengerDetail[paxcount].PrefixId,
                        Model.PNRBookedList[0].PNRDetails[pnrcount].PassengerDetail[paxcount].PrefixList, new { @style = "width:60px;", @class = "required" })%>
                        </td>
                        <td>
                            <%: Html.TextBoxFor(model => model.PNRBookedList[0].PNRDetails[pnrcount].PassengerDetail[paxcount].FirstName, new {@onkeypress = "return CheckAlbhabet(event)" })%>
                        </td>
                        <td>
                            <%: Html.TextBoxFor(model => model.PNRBookedList[0].PNRDetails[pnrcount].PassengerDetail[paxcount].MiddleName, new {@onkeypress = "return CheckAlbhabet(event)" })%>
                        </td>
                        <td>
                            <%: Html.TextBoxFor(model => model.PNRBookedList[0].PNRDetails[pnrcount].PassengerDetail[paxcount].LastName, new {@onkeypress = "return CheckAlbhabet(event)" })%>
                        </td>
                        <% if (Model.PNRBookedList[0].ServiceProviderId == 3 || Model.PNRBookedList[0].ServiceProviderId == 4 || Model.PNRBookedList[0].ServiceProviderId == 1 || (Model.PNRBookedList[0].ServiceProviderId == 5 && Model.PNRBookedList[0].TicketStatusId == 33) || (Model.PNRBookedList[0].ServiceProviderId == 5 && Model.PNRBookedList[0].TicketStatusId == 34))
                           { %>
                        <td>
                            <%:Html.TextBoxFor(model => model.PNRBookedList[0].PNRDetails[pnrcount].PassengerDetail[paxcount].FareDetail.TicketNumber)%>
                            <%:Html.HiddenFor(model=>model.PNRBookedList[0].PNRDetails[pnrcount].PassengerDetail[paxcount].FareDetail.PassengerId) %>
                        </td>
                        <%} %>
                        <% else
                           { %>
                        <td>
                            <%:Html.TextBoxFor(model => model.PNRBookedList[0].PNRDetails[pnrcount].PassengerDetail[paxcount].FareDetail.TicketNumber)%>
                            <% Html.ValidationMessageFor(model => model.PNRBookedList[0].PNRDetails[pnrcount].PassengerDetail[paxcount].FareDetail.TicketNumber, "*");%>
                            <%:Html.HiddenFor(model=>model.PNRBookedList[0].PNRDetails[pnrcount].PassengerDetail[paxcount].FareDetail.PassengerId) %>
                        </td>
                        <%} %>
                        <% if (ticket.DOB != null)
                           { %>
                        <td>
                            <%: Html.TextBoxFor(model=>model.PNRBookedList[0].PNRDetails[pnrcount].PassengerDetail[paxcount].DOB, new { @style = "width: 123px;", @class = "DOB" })%>
                        </td>
                        <%} %>
                        <% else
                           { %>
                        <td>
                            <%: Html.TextBoxFor(model=>model.PNRBookedList[0].PNRDetails[pnrcount].PassengerDetail[paxcount].DOB, new { @style = "width: 123px;", @class = "DOB" })%>
                        </td>
                        <%} %>
                        <% paxcount++; %>
                    </tr>
                    <% } %>
                </table>
            </div>
            <% } %>
            <%-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@ Passenger Information Ends @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@ --%>
            <br />
            <%-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@ Segment Information Starts @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@ --%>
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
                            Flight No.
                        </th>
                        <th>
                            Class
                        </th>
                        <th>
                            From
                        </th>
                        <th>
                            Departure Date(Time)
                        </th>
                        <th>
                            To
                        </th>
                        <th>
                            Arrival Date(Time)
                        </th>
                        <th>
                            Airline PNR
                        </th>
                        <th>
                            Baggage
                        </th>
                    </tr>
                    <%
                   int PnrSectorsegCount = 0;

                   foreach (var segment in pnrInfo.SegmentDetail)
                   { %>
                    <tr>
                        <td>
                            <%: Html.DropDownListFor(model => model.PNRBookedList[0].PNRDetails[pnrcount].SegmentDetail[PnrSectorsegCount].AirlineId, Model.PNRBookedList[0].PNRDetails[pnrcount].SegmentDetail[PnrSectorsegCount].AirlineList, new { @style = "width:60px;", @class = "required" })%>
                        </td>
                        <td>
                            <%: Html.TextBox("PNRBookedList[0].PNRDetails[" + pnrcount + "].SegmentDetail[" + PnrSectorsegCount + "].FlightNumber", segment.FlightNumber, new { @style = "width: 50px;" })%>
                        </td>
                        <td>
                            <span class="orangeTxt"><strong>
                                <%: Html.TextBox("PNRBookedList[0].PNRDetails[" + pnrcount + "].SegmentDetail[" + PnrSectorsegCount + "].BIC", segment.BIC, new { @style = "width: 50px;" })%>
                            </strong></span>
                        </td>
                        <td>
                            <%: Html.DropDownListFor(model => model.PNRBookedList[0].PNRDetails[pnrcount].SegmentDetail[PnrSectorsegCount].DepartCityId, Model.PNRBookedList[0].PNRDetails[pnrcount].SegmentDetail[PnrSectorsegCount].DepartCityList, new { @style = "width:60px;", @class = "required cityPair" })%>
                        </td>
                        <td>
                            <%: Html.TextBox("PNRBookedList[0].PNRDetails[" + pnrcount + "].SegmentDetail[" + PnrSectorsegCount + "].DepartDate", (segment.DepartDate.Value).ToString("dd MMM yyyy HH:mm"), new { @style = "width: 123px;", @class = "timepicker datePair" })%>
                        </td>
                        <td>
                            <%: Html.DropDownListFor(model => model.PNRBookedList[0].PNRDetails[pnrcount].SegmentDetail[PnrSectorsegCount].ArrivalCityId, Model.PNRBookedList[0].PNRDetails[pnrcount].SegmentDetail[PnrSectorsegCount].ArriveCityList, new { @style = "width:60px;", @class = "required" })%>
                        </td>
                        <td>
                            <%if (Model.PNRBookedList[0].ServiceProviderId != 4)
                              { %>
                            <%: Html.TextBox("PNRBookedList[0].PNRDetails[" + pnrcount + "].SegmentDetail[" + PnrSectorsegCount + "].ArrivalDate", (segment.ArrivalDate.Value).ToString("dd MMM yyyy HH:mm"), new { @style = "width: 123px;", @class = "timepicker" })%>
                            <%}
                              else
                              { %>
                            <%: Html.TextBox("PNRBookedList[0].PNRDetails[" + pnrcount + "].SegmentDetail[" + PnrSectorsegCount + "].ArrivalDate", (segment.ArrivalDate.Value).ToString("dd MMM yyyy"), new { @style = "width: 123px;", @class = "timepicker" })%>
                            <%} %>
                        </td>
                        <%if (Model.PNRBookedList[0].ServiceProviderId == 3 || Model.PNRBookedList[0].ServiceProviderId == 1 || Model.PNRBookedList[0].ServiceProviderId == 4 || (Model.PNRBookedList[0].ServiceProviderId == 5 && Model.PNRBookedList[0].TicketStatusId == 33) || (Model.PNRBookedList[0].ServiceProviderId == 5 && Model.PNRBookedList[0].TicketStatusId == 34))
                          {%>
                        <td>
                            <%:
                             Html.TextBoxFor(model => model.PNRBookedList[0].PNRDetails[pnrcount].SegmentDetail[PnrSectorsegCount].AirlineRefNumber)%>
                        </td>
                        <%} %>
                        <% else
                          { %>
                        <td>
                            <%: Html.TextBoxFor(model => model.PNRBookedList[0].PNRDetails[pnrcount].SegmentDetail[PnrSectorsegCount].AirlineRefNumber)%>
                            <%: Html.ValidationMessageFor(model => model.PNRBookedList[0].PNRDetails[pnrcount].SegmentDetail[PnrSectorsegCount].AirlineRefNumber) %>
                        </td>
                        <%} %>
                        <td>
                            <%:Html.TextBoxFor(model => model.PNRBookedList[0].PNRDetails[pnrcount].SegmentDetail[PnrSectorsegCount].Baggage, new { @style=" width:50px;"})%>
                        </td>
                        <% PnrSectorsegCount++; %>
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
            <div class="ledger_subtable create_tbl" style="border: 1px solid #ccc; padding: 2px;">
                <table style="width: 100%">
                    <tr>
                        <td colspan="2">
                            <strong>Purchase</strong>
                        </td>
                        <td colspan="2">
                            <strong>Sales</strong>
                        </td>
                    </tr>
                </table>
                <hr />
                <%int PnrFareCount = 0; %>
                <% 
                
                  ATLTravelPortal.Areas.Airline.Repository.AirOfflineBookProvider Provider = new ATLTravelPortal.Areas.Airline.Repository.AirOfflineBookProvider();
                  int? totalnumberofadult = Provider.GetNumberofAdultPassenger(Model.PNRBookedList[0].MPNRId, 1);
                  int? totalnumberofChild = Provider.GetNumberofChildPassenger(Model.PNRBookedList[0].MPNRId, 2);
                  int? totalnumberofinfant = Provider.GetNumberofInfantPassenger(Model.PNRBookedList[0].MPNRId, 3);


                  foreach (var fare in Model.FarePassengerInfo)
                  {
                %>
                <table style="width: 100%;">
                    <tr>
                        <td>
                            Currency
                        </td>
                        <td>
                            <label style="float: left; background: red; color: #fff; padding: 0px 5px; font-size: 12px;">
                                <%:fareDetail[0].FareDetail.Currency%></label>
                        </td>
                        <td>
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Pax Type
                        </td>
                        <td>
                            <%: Html.DropDownListFor(model => model.FarePassengerInfo[PnrFareCount].PaxType,
                           Model.FarePassengerInfo[PnrFareCount].PaxTypeList, new { @style = "width:60px;", @class = "required" })%>
                            <%: Html.Hidden("PNRBookedList[0].PNRDetails[" + pnrcount + "].PassengerDetail[0].FareDetails[" + PnrFareCount + "].Currency", fare.Currency)%>
                            <%: Html.Hidden("PNRBookedList[0].PNRDetails[" + pnrcount + "].PassengerDetail[0].FareDetails[" + PnrFareCount + "].PaxType", fare.PaxType)%>
                            <% if (fare.PaxType.ToString() == "Adult")
                               { %>
                            <%: Html.Hidden("PNRBookedList[0].PNRDetails[" + pnrcount + "].PassengerDetail[0].FareDetails[" + PnrFareCount + "].NoOfAdult", totalnumberofadult)%>
                            <%}
                               else if (fare.PaxType.ToString() == "Child")
                               {                                             
                            %>
                            <%: Html.Hidden("PNRBookedList[0].PNRDetails[" + pnrcount + "].PassengerDetail[0].FareDetails[" + PnrFareCount + "].NoOfChild", totalnumberofChild)%>
                            <%}
                               else if (fare.PaxType.ToString() == "Infant")
                               { %>
                            <%: Html.Hidden("PNRBookedList[0].PNRDetails[" + pnrcount + "].PassengerDetail[0].FareDetails[" + PnrFareCount + "].NoOfInfant", totalnumberofinfant)%>
                            <%} %>
                        </td>
                        <td>
                            Markup
                        </td>
                        <td>
                            <%: Html.TextBox("PNRBookedList[0].PNRDetails[" + pnrcount + "].PassengerDetail[0].FareDetails[" + PnrFareCount + "].MarkupAmount", fare.MarkupAmount, new { @onkeypress = "return CheckFareNumericValue(event)", @onkeyup = "CalculateSellingBaseFare(this);" })%>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Base Fare
                        </td>
                        <td>
                            <%: Html.TextBox("PNRBookedList[0].PNRDetails[" + pnrcount + "].PassengerDetail[0].FareDetails[" + PnrFareCount + "].BaseFare", fare.BaseFare, new { @onkeypress = "return CheckFareNumericValue(event)", @onkeyup = "CalculateSellingBaseFare(this);" })%>
                        </td>
                        <td>
                            Selling BF
                        </td>
                        <td>
                            <%: Html.TextBox("PNRBookedList[0].PNRDetails[" + pnrcount + "].PassengerDetail[0].FareDetails[" + PnrFareCount + "].SellingBaseFare", fare.SellingBaseFare, new { @onkeypress = "return CheckFareNumericValue(event)" })%>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Additional Txn Fee
                        </td>
                        <td>
                            <%: Html.TextBox("PNRBookedList[0].PNRDetails[" + pnrcount + "].PassengerDetail[0].FareDetails[" + PnrFareCount + "].AdditionalTxnFee", fare.AdditionalTxnFee, new { @onkeypress = "return CheckFareNumericValue(event)" })%>
                        </td>
                        <td>
                            Selling Additional Txn Fee
                        </td>
                        <td>
                            <%: Html.TextBox("PNRBookedList[0].PNRDetails[" + pnrcount + "].PassengerDetail[0].FareDetails[" + PnrFareCount + "].SellingAdditionalTxnFee", fare.SellingAdditionalTxnFee, new { @onkeypress = "return CheckFareNumericValue(event)" })%>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Airline Trans Fee
                        </td>
                        <td>
                            <%: Html.TextBox("PNRBookedList[0].PNRDetails[" + pnrcount + "].PassengerDetail[0].FareDetails[" + PnrFareCount + "].AirlineTransFee", fare.AirlineTransFee, new { @onkeypress = "return CheckFareNumericValue(event)" })%>
                        </td>
                        <td>
                            Selling ATF
                        </td>
                        <td>
                            <%: Html.TextBox("PNRBookedList[0].PNRDetails[" + pnrcount + "].PassengerDetail[0].FareDetails[" + PnrFareCount + "].SellingAirlineTransFee", fare.SellingAirlineTransFee, new { @onkeypress = "return CheckFareNumericValue(event)" })%>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Tax
                        </td>
                        <td>
                            <%: Html.TextBox("PNRBookedList[0].PNRDetails[" + pnrcount + "].PassengerDetail[0].FareDetails[" + PnrFareCount + "].Tax", fare.Tax, new { @onkeypress = "return CheckFareNumericValue(event)" })%>
                        </td>
                        <td>
                            Selling Tax
                        </td>
                        <td>
                            <%: Html.TextBox("PNRBookedList[0].PNRDetails[" + pnrcount + "].PassengerDetail[0].FareDetails[" + PnrFareCount + "].SellingTax", fare.SellingTax, new {  @onkeypress = "return CheckFareNumericValue(event)" })%>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Service Tax
                        </td>
                        <td>
                            <%: Html.TextBox("PNRBookedList[0].PNRDetails[" + pnrcount + "].PassengerDetail[0].FareDetails[" + PnrFareCount + "].ServiceTax", fare.ServiceTax, new { @onkeypress = "return CheckFareNumericValue(event)" })%>
                        </td>
                        <td>
                            Selling Service Tax
                        </td>
                        <td>
                            <%: Html.TextBox("PNRBookedList[0].PNRDetails[" + pnrcount + "].PassengerDetail[0].FareDetails[" + PnrFareCount + "].SellingServiceTax", fare.SellingServiceTax, new { @onkeypress = "return CheckFareNumericValue(event)" })%>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            FSC
                        </td>
                        <td>
                            <%: Html.TextBox("PNRBookedList[0].PNRDetails[" + pnrcount + "].PassengerDetail[0].FareDetails[" + PnrFareCount + "].FSC", fare.FSC, new {  @onkeypress = "return CheckFareNumericValue(event)" })%>
                        </td>
                        <td>
                            Selling FSC
                        </td>
                        <td>
                            <%: Html.TextBox("PNRBookedList[0].PNRDetails[" + pnrcount + "].PassengerDetail[0].FareDetails[" + PnrFareCount + "].SellingFSC", fare.SellingFSC, new {  @onkeypress = "return CheckFareNumericValue(event)" })%>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Commission
                        </td>
                        <td>
                            <%: Html.TextBox("PNRBookedList[0].PNRDetails[" + pnrcount + "].PassengerDetail[0].FareDetails[" + PnrFareCount + "].CommissionAmount", fare.CommissionAmount, new { @onkeypress = "return CheckFareNumericValue(event)" })%>
                        </td>
                        <td>
                            Discount
                        </td>
                        <td>
                            <%: Html.TextBox("PNRBookedList[0].PNRDetails[" + pnrcount + "].PassengerDetail[0].FareDetails[" + PnrFareCount + "].DiscountAmount", fare.DiscountAmount, new {  @onkeypress = "return CheckFareNumericValue(event)" })%>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Other Charges
                        </td>
                        <td>
                            <%: Html.TextBox("PNRBookedList[0].PNRDetails[" + pnrcount + "].PassengerDetail[0].FareDetails[" + PnrFareCount + "].OtherCharges", fare.OtherCharges, new {@onkeypress = "return CheckFareNumericValue(event)" })%>
                        </td>
                        <td>
                            Selling Other Charges
                        </td>
                        <td>
                            <%: Html.TextBox("PNRBookedList[0].PNRDetails[" + pnrcount + "].PassengerDetail[0].FareDetails[" + PnrFareCount + "].SellingOtherCharges", fare.SellingOtherCharges, new {@onkeypress = "return CheckFareNumericValue(event)" })%>
                        </td>
                    </tr>
                </table>
                <hr />
                <%
PnrFareCount++;
                  } %>
                <%--<table width="100%" class="data-table">
                    <tr>
                        <th>
                            PaxType&nbsp;&nbsp;Base Fare
                        </th>
                        <th>
                            YQ/FSC
                        </th>
                        <th>
                            Tax
                        </th>
                        <th>
                            Service-Tax
                        </th>
                        <th>
                            Other-Charges
                        </th>
                        <th>
                            Markup
                        </th>
                        <th>
                            Discount
                        </th>
                        <th>
                            Comm
                        </th>
                        <th>
                        </th>
                        <th>
                            Total/Pax
                        </th>
                        <th>
                            Total
                        </th>
                    </tr>
                    <%int PnrFareCount = 0; %>
                    <% 
                      double? totalperpax = 0;
                      double? total = 0;
                      ATLTravelPortal.Areas.Airline.Repository.AirOfflineBookProvider Provider = new ATLTravelPortal.Areas.Airline.Repository.AirOfflineBookProvider();
                      int? totalnumberofadult = Provider.GetNumberofAdultPassenger(Model.PNRBookedList[0].MPNRId, 1);
                      int? totalnumberofChild = Provider.GetNumberofChildPassenger(Model.PNRBookedList[0].MPNRId, 2);
                      int? totalnumberofinfant = Provider.GetNumberofInfantPassenger(Model.PNRBookedList[0].MPNRId, 3);


                      foreach (var fare in Model.FarePassengerInfo)
                      {
                       
                    %>
                    <tr>
                        <td>
                            <%: Html.DropDownListFor(model => model.FarePassengerInfo[PnrFareCount].PaxType,
                           Model.FarePassengerInfo[PnrFareCount].PaxTypeList, new { @style = "width:60px;", @class = "required" })%>
                            <%: Html.Hidden("PNRBookedList[0].PNRDetails[" + pnrcount + "].PassengerDetail[0].FareDetails[" + PnrFareCount + "].Currency", fare.Currency)%>
                            <%: Html.Hidden("PNRBookedList[0].PNRDetails[" + pnrcount + "].PassengerDetail[0].FareDetails[" + PnrFareCount + "].PaxType", fare.PaxType)%>
                            <% if (fare.PaxType.ToString() == "Adult")
                               { %>
                            <%: Html.Hidden("PNRBookedList[0].PNRDetails[" + pnrcount + "].PassengerDetail[0].FareDetails[" + PnrFareCount + "].NoOfAdult", totalnumberofadult)%>
                            <%}
                               else if (fare.PaxType.ToString() == "Child")
                               {                                             
                            %>
                            <%: Html.Hidden("PNRBookedList[0].PNRDetails[" + pnrcount + "].PassengerDetail[0].FareDetails[" + PnrFareCount + "].NoOfChild", totalnumberofChild)%>
                            <%}
                               else if (fare.PaxType.ToString() == "Infant")
                               { %>
                            <%: Html.Hidden("PNRBookedList[0].PNRDetails[" + pnrcount + "].PassengerDetail[0].FareDetails[" + PnrFareCount + "].NoOfInfant", totalnumberofinfant)%>
                            <%} %>
                            <%: Html.TextBox("PNRBookedList[0].PNRDetails[" + pnrcount + "].PassengerDetail[0].FareDetails[" + PnrFareCount + "].BaseFare", fare.BaseFare, new { @style = "width: 45px; margin-left:0px;", @onkeyup = "EvaluateTotalFare(this," + pnrcount + ")", @onkeypress = "return CheckFareNumericValue(event)" })%>
                        </td>
                        <td>
                            <%: Html.TextBox("PNRBookedList[0].PNRDetails[" + pnrcount + "].PassengerDetail[0].FareDetails[" + PnrFareCount + "].SellingFSC", fare.SellingFSC, new { @style = "width: 50px;", @onkeyup = "EvaluateTotalFare(this," + pnrcount + ")", @onkeypress = "return CheckFareNumericValue(event)" })%>
                        </td>
                        <% if (Model.PNRBookedList[0].ServiceProviderId != 5)
                           { %>
                        <td>
                            <%: Html.TextBox("PNRBookedList[0].PNRDetails[" + pnrcount + "].PassengerDetail[0].FareDetails[" + PnrFareCount + "].SellingTax", fare.SellingTax, new { @style = "width: 50px;", @onkeyup = "EvaluateTotalFare(this," + pnrcount + ")", @onkeypress = "return CheckFareNumericValue(event)" })%>
                        </td>
                        <%} %>
                        <%else
                           { %>
                        <td>
                            <%: Html.TextBox("PNRBookedList[0].PNRDetails[" + pnrcount + "].PassengerDetail[0].FareDetails[" + PnrFareCount + "].SellingTax", fare.SellingTax + fare.SellingAdditionalTxnFee, new { @style = "width: 50px;", @onkeyup = "EvaluateTotalFare(this," + pnrcount + ")", @onkeypress = "return CheckFareNumericValue(event)" })%>
                        </td>
                        <%} %>
                        <td>
                            <%: Html.TextBox("PNRBookedList[0].PNRDetails[" + pnrcount + "].PassengerDetail[0].FareDetails[" + PnrFareCount + "].ServiceTax", fare.SellingServiceTax, new { @style = "width: 50px;", @onkeyup = "EvaluateTotalFare(this," + pnrcount + ")", @onkeypress = "return CheckFareNumericValue(event)" })%>
                        </td>
                        <td>
                            <%: Html.TextBox("PNRBookedList[0].PNRDetails[" + pnrcount + "].PassengerDetail[0].FareDetails[" + PnrFareCount + "].OtherCharges", fare.SellingOtherCharges, new { @style = "width: 50px;", @onkeyup = "EvaluateTotalFare(this," + pnrcount + ")", @onkeypress = "return CheckFareNumericValue(event)" })%>
                        </td>
                        <td>
                            <%: fare.MarkupAmount %>
                        </td>
                        <td>
                            <%: Html.TextBox("PNRBookedList[0].PNRDetails[" + pnrcount + "].PassengerDetail[0].FareDetails[" + PnrFareCount + "].DiscountAmount", fare.DiscountAmount, new { @style = "width: 50px;", @onkeyup = "EvaluateTotalFare(this," + pnrcount + ")", @onkeypress = "return CheckFareNumericValue(event)" })%>
                        </td>
                        <td>
                            <%: Html.TextBox("PNRBookedList[0].PNRDetails[" + pnrcount + "].PassengerDetail[0].FareDetails[" + PnrFareCount + "].CommissionAmount", fare.CommissionAmount, new { @style = "width: 50px;", @onkeyup = "EvaluateTotalFare(this," + pnrcount + ")", @onkeypress = "return CheckFareNumericValue(event)" })%>
                        </td>
                        <td>
                        </td>
                        <td>
                            <% if (fare.DiscountAmount < 0)
                               { %>
                            <span class="orangeTxt"><strong id="edittotalfareamount<%:PnrFareCount %>">
                                <%:string.Format("{0:#.#}", fare.BaseFare +(Model.PNRBookedList[0].ServiceProviderId!=5? fare.SellingFSC:0) +
                                 + (Model.PNRBookedList[0].ServiceProviderId!=5? fare.SellingTax: (fare.SellingTax + fare.SellingAdditionalTxnFee)) + fare.SellingAirlineTransFee
                                + fare.ServiceTax + fare.OtherCharges  + Math.Abs(fare.DiscountAmount) )%>
                            </strong></span>
                            <%} %>
                            <% else
                               { %>
                            <span class="orangeTxt"><strong id="edittotalfareamount<%:PnrFareCount %>">
                                <%:string.Format("{0:#.#}", fare.BaseFare + (Model.PNRBookedList[0].ServiceProviderId!=5? fare.SellingFSC:0) +
                                +(Model.PNRBookedList[0].ServiceProviderId != 5 ? fare.SellingTax : (fare.SellingTax + fare.SellingAdditionalTxnFee)) + fare.SellingAirlineTransFee
                                + fare.ServiceTax + fare.OtherCharges  - fare.DiscountAmount)%>
                            </strong></span>
                            <%} %>
                        </td>
                        <% if (fare.DiscountAmount < 0)
                           { %>
                        <% totalperpax += (fare.BaseFare + (Model.PNRBookedList[0].ServiceProviderId != 5 ? fare.SellingFSC : 0) +
                            +(Model.PNRBookedList[0].ServiceProviderId != 5 ? fare.SellingTax : (fare.SellingTax + fare.SellingAdditionalTxnFee)) + fare.SellingAirlineTransFee
                                + fare.ServiceTax + fare.OtherCharges + Math.Abs(fare.DiscountAmount)); %>
                        <%} %>
                        <%else
                           { %>
                        <% totalperpax += (fare.BaseFare + (Model.PNRBookedList[0].ServiceProviderId != 5 ? fare.SellingFSC : 0) +
                               +(Model.PNRBookedList[0].ServiceProviderId != 5 ? fare.SellingTax : (fare.SellingTax + fare.SellingAdditionalTxnFee)) + fare.SellingAirlineTransFee
                                + fare.ServiceTax + fare.OtherCharges - fare.DiscountAmount); %>
                        <%} %>
                        <% if (fare.PaxType.ToString() == "Adult")
                           { %>
                        <td>
                            <% if (fare.DiscountAmount < 0)
                               { %>
                            <span class="orangeTxt"><strong id="editpaxwisetotalfareamount<%:PnrFareCount %>">
                                <%:string.Format("{0:#.#}", (fare.BaseFare + (Model.PNRBookedList[0].ServiceProviderId != 5 ? fare.SellingFSC : 0) +
                                 +(Model.PNRBookedList[0].ServiceProviderId != 5 ? fare.SellingTax : (fare.SellingTax + fare.SellingAdditionalTxnFee)) + fare.SellingAirlineTransFee
                                + fare.ServiceTax + fare.OtherCharges  + Math.Abs(fare.DiscountAmount))*totalnumberofadult)%>
                                <% total += (fare.BaseFare + fare.SellingFSC + +(Model.PNRBookedList[0].ServiceProviderId != 5 ? fare.SellingTax : (fare.SellingTax + fare.SellingAdditionalTxnFee)) + fare.SellingAirlineTransFee
                                + fare.ServiceTax + fare.OtherCharges + Math.Abs(fare.DiscountAmount)) * Convert.ToDouble(totalnumberofadult); %>
                            </strong></span>
                            <%} %>
                            <% else
                               { %>
                            <span class="orangeTxt"><strong id="editpaxwisetotalfareamount<%:PnrFareCount %>">
                                <%:string.Format("{0:#.#}", (fare.BaseFare + (Model.PNRBookedList[0].ServiceProviderId != 5 ? fare.SellingFSC : 0) +
                                +(Model.PNRBookedList[0].ServiceProviderId != 5 ? fare.SellingTax : (fare.SellingTax + fare.SellingAdditionalTxnFee)) + fare.SellingAirlineTransFee
                                + fare.ServiceTax + fare.OtherCharges  - fare.DiscountAmount)*totalnumberofadult)%>
                                <% total += (fare.BaseFare + (Model.PNRBookedList[0].ServiceProviderId != 5 ? fare.SellingFSC : 0) + +(Model.PNRBookedList[0].ServiceProviderId != 5 ? fare.SellingTax : (fare.SellingTax + fare.SellingAdditionalTxnFee)) + fare.SellingAirlineTransFee
                                + fare.ServiceTax + fare.OtherCharges - fare.DiscountAmount) * Convert.ToDouble(totalnumberofadult); %>
                            </strong></span>
                            <%} %>
                        </td>
                        <%} %>
                        <% else if (fare.PaxType.ToString() == "Child")
                           { %>
                        <td>
                            <% if (fare.DiscountAmount < 0)
                               { %>
                            <span class="orangeTxt"><strong id="editpaxwisetotalfareamount<%:PnrFareCount %>">
                                <%:string.Format("{0:#.#}", (fare.BaseFare + (Model.PNRBookedList[0].ServiceProviderId != 5 ? fare.SellingFSC : 0) +
                                 +(Model.PNRBookedList[0].ServiceProviderId != 5 ? fare.SellingTax : (fare.SellingTax + fare.SellingAdditionalTxnFee)) + fare.SellingAirlineTransFee
                                + fare.ServiceTax + fare.OtherCharges  + Math.Abs(fare.DiscountAmount) )*totalnumberofChild)%>
                                <% total += (fare.BaseFare + (Model.PNRBookedList[0].ServiceProviderId != 5 ? fare.SellingFSC : 0) + +(Model.PNRBookedList[0].ServiceProviderId != 5 ? fare.SellingTax : (fare.SellingTax + fare.SellingAdditionalTxnFee)) + fare.SellingAirlineTransFee
                                + fare.ServiceTax + fare.OtherCharges + Math.Abs(fare.DiscountAmount)) * Convert.ToDouble(totalnumberofChild); %>
                            </strong></span>
                            <%} %>
                            <% else
                               { %>
                            <span class="orangeTxt"><strong id="editpaxwisetotalfareamount<%:PnrFareCount %>">
                                <%:string.Format("{0:#.#}", (fare.BaseFare + (Model.PNRBookedList[0].ServiceProviderId != 5 ? fare.SellingFSC : 0) +
                                +(Model.PNRBookedList[0].ServiceProviderId != 5 ? fare.SellingTax : (fare.SellingTax + fare.SellingAdditionalTxnFee)) + fare.SellingAirlineTransFee
                                + fare.ServiceTax + fare.OtherCharges - fare.DiscountAmount ) * totalnumberofChild)%>
                                <% total += (fare.BaseFare + (Model.PNRBookedList[0].ServiceProviderId != 5 ? fare.SellingFSC : 0) + +(Model.PNRBookedList[0].ServiceProviderId != 5 ? fare.SellingTax : (fare.SellingTax + fare.SellingAdditionalTxnFee)) + fare.SellingAirlineTransFee
                                + fare.ServiceTax + fare.OtherCharges - fare.DiscountAmount) * Convert.ToDouble(totalnumberofChild); %>
                            </strong></span>
                            <%} %>
                        </td>
                        <%} %>
                        <% else if (fare.PaxType.ToString() == "Infant")
                           {%>
                        <td>
                            <% if (fare.DiscountAmount < 0)
                               { %>
                            <span class="orangeTxt"><strong id="editpaxwisetotalfareamount<%:PnrFareCount %>">
                                <%:string.Format("{0:#.#}", (fare.BaseFare + (Model.PNRBookedList[0].ServiceProviderId != 5 ? fare.SellingFSC : 0) +
                                +(Model.PNRBookedList[0].ServiceProviderId != 5 ? fare.SellingTax : (fare.SellingTax + fare.SellingAdditionalTxnFee)) + fare.SellingAirlineTransFee
                                + fare.ServiceTax + fare.OtherCharges + Math.Abs(fare.DiscountAmount))*totalnumberofinfant)%>
                                <% total += (fare.BaseFare + (Model.PNRBookedList[0].ServiceProviderId != 5 ? fare.SellingFSC : 0) + +(Model.PNRBookedList[0].ServiceProviderId != 5 ? fare.SellingTax : (fare.SellingTax + fare.SellingAdditionalTxnFee)) + fare.SellingAirlineTransFee
                                + fare.ServiceTax + fare.OtherCharges + Math.Abs(fare.DiscountAmount)) * Convert.ToDouble(totalnumberofinfant); %>
                            </strong></span>
                            <%} %>
                            <% else
                               { %>
                            <span class="orangeTxt"><strong id="editpaxwisetotalfareamount<%:PnrFareCount %>">
                                <%:string.Format("{0:#.#}", (fare.BaseFare + (Model.PNRBookedList[0].ServiceProviderId != 5 ? fare.SellingFSC : 0) +
                                +(Model.PNRBookedList[0].ServiceProviderId != 5 ? fare.SellingTax : (fare.SellingTax + fare.SellingAdditionalTxnFee)) + fare.SellingAirlineTransFee
                                + fare.ServiceTax + fare.OtherCharges  - fare.DiscountAmount ) * totalnumberofinfant)%>
                                <% total += (fare.BaseFare + (Model.PNRBookedList[0].ServiceProviderId != 5 ? fare.SellingFSC : 0) + +(Model.PNRBookedList[0].ServiceProviderId != 5 ? fare.SellingTax : (fare.SellingTax + fare.SellingAdditionalTxnFee)) + fare.SellingAirlineTransFee
                                + fare.ServiceTax + fare.OtherCharges - fare.DiscountAmount) * Convert.ToDouble(totalnumberofinfant); %>
                            </strong></span>
                            <%} %>
                        </td>
                        <%} %>
                    </tr>
                    <%
                           PnrFareCount++;
                      } %>
                    <tr>
                        <td colspan="6">
                            &nbsp;
                        </td>
                        <% if (Model.PNRBookedList[0].ServiceProviderId != 5)
                           { %>
                        <td>
                            <b>Airline Fee</b>
                        </td>
                        <%} %>
                        <% else
                           { %>
                        <td>
                        </td>
                        <%} %>
                        <% if (Model.PNRBookedList[0].ServiceProviderId != 5)
                           { %>
                        <td>
                            <%: Html.TextBox("PNRBookedList[0].PNRDetails[" + pnrcount + "].PassengerDetail[0].FareDetails[0].SellingAdditionalTxnFee", Model.FarePassengerInfo[0].SellingAdditionalTxnFee, new { @style = "width: 50px;", @onkeyup = "EvaluateTotalFareWithTranFee(this," + pnrcount + ")" })%>
                        </td>
                        <%} %>
                        <% else
                           { %>
                        <td>
                        </td>
                        <%} %>
                        <td>
                        </td>
                        <td>
                            <span id="paxTotal"><b>
                                <%:string.Format("{0:#,#.#}", totalperpax)%>
                            </b></span>
                        </td>
                        <td>
                            <span id="allTotal"><b>
                                <%: string.Format("{0:#,#.#}", total)%>
                            </b></span>
                        </td>
                    </tr>
                </table>--%>
            </div>
            <br />
        </div>
    </div>
    <br />
    <% } %>
    <%-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@ Fare Ends @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@ --%>
    <% pnrcount++; %>
    <% }
      }
           } %>
    <h6>
        Upload eTicket</h6>
    <% ATLTravelPortal.Areas.Airline.Repository.AirOfflineBookProvider
    ser = new ATLTravelPortal.Areas.Airline.Repository.AirOfflineBookProvider(); int
    ticketstatusid = Model.PNRBookedList[0].TicketStatusId;
    %>
    <p>
        <input type="file" id="ticket" name="ticket" />
    </p>
    <br />
    <p id="buttonBar">
        <% if (ticketstatusid
    != 16 && ticketstatusid != 4 && ticketstatusid != 19 && ticketstatusid != 25 && ticketstatusid != 27 && ticketstatusid != 29 && ticketstatusid != 32 && ticketstatusid != 26 && ticketstatusid != 33 && ticketstatusid != 34)
           {
        %>
        <input type="submit" value="Issue PNR" name="Issue" id="Issue" onclick="return confirm('Are
    you sure you want to Issue?')" class="float-left" />
        <input type="submit" value="Cancel PNR" id="Cancel" name="Cancel" onclick="return confirm('Are you sure
    you want to Reject?')" />
        <%} %>
        <%if (ticketstatusid == 27 || ticketstatusid == 25)
          { %>
        <input type="submit" value="Cancel PNR" id="Cancel" name="Cancel" onclick="return
    confirm('Are you sure you want to Reject?')" />
        <%} %>
        <input type="submit" value="Save" name="Save" id="Save" onclick="return confirm('Are you sure you want to Save?')" />
        <% if (ticketstatusid == 14 || ticketstatusid == 17 || ticketstatusid == 1 || ticketstatusid == 25 || ticketstatusid == 28 || ticketstatusid == 24)
           { %>
        <%: Html.ActionLink("Back to List", "Index", null, new
    {@class="linkButton" })%>
        <%} %>
        <%else
           { %>
        <%: Html.ActionLink("Back to List", "Index", "IssuedTicket", null, new
    { @class = "linkButton" })%>
        <%} %>
    </p>
    <%} %>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CssContent" runat="server">
    <link href="../../../../Content/css/global.css" rel="stylesheet" type="text/css" />
    <link href="../../../../Content/css/atsfltsearch.css" rel="stylesheet" type="text/css" />
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
    <script src="../../../../Scripts/timepicker.js" type="text/javascript"></script>
    <script type="text/javascript">
        $('#Cancel').live('click', function () {
            $("#isDeleted").val('true');
            $("#ATForm").submit();
        });
    </script>
    <script type="text/javascript">

        function CheckAlbhabet(e) {
            var key = e.which ? e.which : e.keyCode;
            //A-Z a-z and space key//              
            if ((key > 64 && key < 91) || (key > 96 && key < 123) || key == 8 || key == 32) {
                return true;
            }
            else {

                return false;
            }
        }

        function CheckNumericValue(e) {

            var key = e.which ? e.which : e.keyCode;
            //enter key  //backspace //tabkey      //escape key     
            if ((key >= 48 && key <= 57) || key == 13 || key == 8 || key == 9 || key == 27) {
                return true;
            }
            else {

                return false;
            }
        }

        function CheckFareNumericValue(e) {

            var key = e.which ? e.which : e.keyCode;
            //enter key  //backspace //tabkey      //escape key  //dot  //minus             
            if ((key >= 48 && key <= 57) || key == 13 || key == 8 || key == 9 || key == 27 || key == 46 || key == 45) {
                return true;
            }
            else {

                return false;
            }
        }
    </script>
    <script type="text/javascript">
        $("#Save").live("click", function () {
            validatePaxFare();
        });

        function validatePaxFare() {
            var farePaxTypeElements = $('select[id$="FarePaxType"]');
            var paxTypeElements = $('select[id$=PaxType]');


            var isAdult, isChild, isInfant = false;
            var isFareAdult, isFareChild, isFareInfant = false;

            paxTypeElements.each(function (index) {
                if ($(this).val() == "Adult") {
                    isAdult = true;
                }
                else if ($(this).val() == "Child") {
                    isChild = true;
                }
                else if ($(this).val() == "Infant") {
                    isInfant = true;
                }
            });

            farePaxTypeElements.each(function (index) {
                if ($(this).val() == "Adult") {
                    isFareAdult = true;
                }
                else if ($(this).val() == "Child") {
                    isFareChild = true;
                }
                else if ($(this).val() == "Infant") {
                    isFareInfant = true;
                }
            });
            if (isAdult == isFareAdult && isChild == isFareChild && isInfant == isFareInfant) {
                //                alert('Submit form');
                $('#bookingForm').submit();
            }
            else {
                alert('Please enter valid pax type in fare.');
                return false;
            }
        }
    </script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('.datepicker').live('click', function () {
                $(this).datepicker('destroy').datepicker({
                    ampm: true,
                    hourGrid: 4,
                    minuteGrid: 10,
                    numberOfMonths: 1,
                    dateFormat: 'dd M yy',
                    minDate: 0
                }).focus();
            });
        });
    </script>
    <script type="text/javascript">
      
        $('.pnr').live('keyup', function (e) {
            $('.pnr').val(($('.pnr').val()).toUpperCase());
            if (e.which >= 97 && e.which <= 122) {
                var newKey = e.which - 32;
                e.keyCode = newKey;
                e.charCode = newKey;
            }
            $('.Airlinepnr').val(($('.pnr').val()).toUpperCase());
        });



         $(document).ready(function () {
        $('.timepicker').live('click', function () {
            $(this).datetimepicker('destroy').datetimepicker({
                ampm: true,
                hourGrid: 4,
                minuteGrid: 10,
                numberOfMonths: 1,
               
            }).focus();
        });


        now = new Date();
$('.DOB').live('click', function () {
$(this).datepicker('destroy').datepicker({
// defaultDate: new Date(),
// changeMonth: true,
// changeYear: true,
// constrainInput: true,
// numberOfMonths: 1,
// disable: true,
// showAnim: 'fold',
// dateFormat: 'dd M yy',
// maxDate: new Date()
changeMonth: true,
changeYear: true,
dateFormat: 'dd M yy',
yearRange: '-100:-00',
defaultDate: new Date(now.getFullYear() - 12, 00, 01)
}).focus();
});

    });

   
         function CalculateSellingBaseFare(element) {

            var baseFareId = element.id;
            var prefix = baseFareId.substring(0, baseFareId.lastIndexOf('_') + 1);
            var markupAmount = parseFloat($("#" + prefix + "MarkupAmount").val());
            var baseFareAmount = parseFloat($("#" + prefix + "BaseFare").val());

            $("#" + prefix + "SellingBaseFare").val(markupAmount + baseFareAmount);
        }


      function EvaluateTotalFare(element, pnrcount) {
        var elementId = element.id;        
         var elementIndex =  elementId.substr(62,1);          

         var noOfPax=0;

          var BaseFare = $("#PNRBookedList_0__PNRDetails_0__PassengerDetail_0__FareDetails_"+elementIndex+"__BaseFare").val();
           var serviceProviderId=$("#PNRBookedList_0__ServiceProviderId").val();

            var YQ =  $("#PNRBookedList_0__PNRDetails_0__PassengerDetail_0__FareDetails_"+elementIndex+"__SellingFSC").val();
            var Tax =$("#PNRBookedList_0__PNRDetails_0__PassengerDetail_0__FareDetails_"+elementIndex+"__SellingTax").val();
           var AdditionalTxnFee = $("#PNRBookedList_0__PNRDetails_0__PassengerDetail_0__FareDetails_"+elementIndex+"__SellingAdditionalTxnFee").val();

             var ServiceTax = $("#PNRBookedList_0__PNRDetails_0__PassengerDetail_0__FareDetails_"+elementIndex+"__ServiceTax").val();
             var OtherCharge = $("#PNRBookedList_0__PNRDetails_0__PassengerDetail_0__FareDetails_"+elementIndex+"__OtherCharges").val();
             var MarkUp = $("#PNRBookedList_0__PNRDetails_0__PassengerDetail_0__FareDetails_"+elementIndex+"__MarkupAmount").val();
             var Discount = $("#PNRBookedList_0__PNRDetails_0__PassengerDetail_0__FareDetails_"+elementIndex+"__DiscountAmount").val();
             var ServiceCharge=$("#PNRBookedList_0__PNRDetails_0__PassengerDetail_0__FareDetails_"+elementIndex+"__ServiceCharge").val();
            
            if(elementIndex==0)
            {
            noOfPax=$("#PNRBookedList_0__PNRDetails_0__PassengerDetail_0__FareDetails_"+elementIndex+"__NoOfAdult").val();
            }
            else if(elementIndex==1)
            {
            noOfPax= $("#PNRBookedList_0__PNRDetails_0__PassengerDetail_0__FareDetails_"+elementIndex+"__NoOfChild").val();
            }
            else if (elementIndex==2)
            {
              noOfPax= $("#PNRBookedList_0__PNRDetails_0__PassengerDetail_0__FareDetails_"+elementIndex+"__NoOfInfant").val();
            }




             var totalfare = (parseFloat(BaseFare) + parseFloat(serviceProviderId!=5?YQ:0) + parseFloat(Tax)   + parseFloat(ServiceTax) + parseFloat(OtherCharge)  - parseFloat(Discount)  ).toFixed(2);

            $('#edittotalfareamount' + elementIndex).html('');
            $('#edittotalfareamount' + elementIndex).html(totalfare);

            $('#editpaxwisetotalfareamount'+elementIndex).html('');
            $('#editpaxwisetotalfareamount'+elementIndex).html(totalfare * noOfPax);
            

            
            var paxTotal=0;
            var allTotal=0;

            var perPaxFareComponents= $('strong[id^=edittotalfareamount]');
          

            var allPaxFareComponents= $('strong[id^=editpaxwisetotalfareamount]');
             perPaxFareComponents.each(function (index) {  
                     
                  
                   paxTotal = paxTotal + parseFloat($(this).html());       
            });

             allPaxFareComponents.each(function (index) {                
                   allTotal+=parseFloat($(this).html());       
            });


            $('#paxTotal').html('').html('<b>'+paxTotal+'</b>');
            $('#allTotal').html('').html('<b>'+allTotal+'</b>');            
    }



     function EvaluateTotalFareWithTranFee(element, pnrcount) {

      var allTotal=0;
       var AdditionalTxnFee = $("#PNRBookedList_0__PNRDetails_0__PassengerDetail_0__FareDetails_0__SellingAdditionalTxnFee").val();
         var allPaxFareComponents= $('strong[id^=editpaxwisetotalfareamount]');
       allPaxFareComponents.each(function (index) {                
                   allTotal+=parseFloat($(this).html());       
            });
          
            allTotal = allTotal + parseFloat(AdditionalTxnFee);
              $('#allTotal').html('').html('<b>'+allTotal +'</b>');  

     }

     function ShowHideIssueButton(sources)
     {
        var sourceId=$("#"+sources.id).val();
        if(sourceId!=5)
        {
        if(!$("#Issue").length)
        {
         var button='<input type="submit" value="Issue PNR" name="Issue" id="Issue" onclick="return confirm('+'\'Are you sure you want to Issue?\''+')" class="float-left" />';
         $("#buttonBar").append(button);
         }
        }  
        else{
            $("#Issue").remove();
        }   
     }


       function validatePaxFare() {
            //CityPair Validation
            var isValidCityPair = true;
            $(".cityPair").each(function () {
                var fromCityId = this.id;
                // alert(fromCityId);
                var fromCity = $("#" + fromCityId).val();

                var prefix = fromCityId.substring(0, fromCityId.lastIndexOf('__') + 2);

                var toCityId = prefix + "ArrivalCityId";
                var toCity = $("#" + toCityId).val();

                if (fromCity == toCity) {
                    // alert("Choose different city pairs");
                    isValidCityPair = false;

                }

            });
            //CityPair validation end
            if (isValidCityPair == false) {
                alert("Choose different city pairs");
                return false;
            }

//              //CityPair Validation
//            var isValidDatePair = true;
//            $(".datePair").each(function () {
//                var DepartDateId = this.id;

//                var DepartDate = $("#" + DepartDateId).val();
//                alert(DepartDate);
//                var prefix = DepartDateId.substring(0, DepartDateId.lastIndexOf('__') + 2);

//                var arrivalDateId = prefix + "ArrivalDate";
//                var arrivalDate = $("#" + arrivalDateId).val();
//               // alert(arrivalDate);

//                if (DepartDate >= arrivalDate) {
//                    isValidDatePair = false;
//                }
//            });

//            //CityPair validation end
//            if (isValidDatePair == false) {
//                alert("Choose different Date pairs");
//                return false;
//            }
          }
    </script>
</asp:Content>
