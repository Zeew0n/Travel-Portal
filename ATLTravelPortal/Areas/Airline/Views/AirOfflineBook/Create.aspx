<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/AirlineMain.Master"
    Inherits="System.Web.Mvc.ViewPage<ATLTravelPortal.Areas.Airline.Models.OffLineBookViewModel.OfflineBookViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Create
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <%Html.RenderPartial("Utility/VUC_MessagePanel"); %>
    <div class="pageTitle">
    </div>
    <% if (Model.PNRDetails.Count > 0) %>
    <% using (Html.BeginForm("Create", "AirOfflineBook", FormMethod.Post, new { @onsubmit = "return validatePaxFare();", @id = "bookingForm", @class = "validate", enctype = "multipart/form-data" }))
       { %>
    <label>
        Agent</label>
    <%: Html.TextBoxFor(model => model.UserDetail.AgentName, new { @class = "required agentAutoComplete", @style="width:250px;" })%>
    <%: Html.HiddenFor(model=>model.UserDetail.AgentId) %>
    <div style="width: 345px; background: #f5f5f5; border: 1px solid #ccc; padding: 10px;
        -moz-border-radius: 4px; border-radius: 4px; float: left; float: right;">
        <p style="color: #333; font-weight: bold;">
            <label id="AgentInfo">
            </label>
        </p>
        <table width="100%" cellpadding="0" cellspacing="0" class="simpleStyle">
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
                    <label id="CreditLimitNPR">
                    </label>
                </td>
                <td>
                    <label id="CreditLimitUSD">
                    </label>
                </td>
            </tr>
            <tr>
                <td>
                    Available Balance
                </td>
                <td>
                    <label id="AvailableBalanceNPR">
                    </label>
                </td>
                <td>
                    <label id="AvailableBalanceUSD">
                    </label>
                </td>
            </tr>
            <tr>
                <td>
                    Ledger Balance
                </td>
                <td>
                    <label id="LedgerBalanceNPR">
                    </label>
                </td>
                <td>
                    <label id="LedgerBalanceUSD">
                    </label>
                </td>
            </tr>
        </table>
    </div>
    <%    for (int i = 0; i < Model.PNRDetails.Count; i++)
          {
              if (i == 0)
              { %>
    <%
              }
   
    %>
    <div class="clearboth">
    </div>
    <br />
    <div class="atsfltsearchWrap">
        <div class="bookingPanel">
            <h2>
                Booking Details
            </h2>
            <div class="passInfo clearfix">
                <h3>
                    GDS PNR</h3>
                <ul class="detailsGrid clearfix">
                    <li>
                        <label>
                            GDS PNR
                        </label>
                        <%:Html.TextBoxFor(model => model.PNRDetails[i].PNR, new { @class = "required", @id = "PNRDetails_0__GDSPNR" })%>
                        <div id="check_GDSPNR" class="checkIfExsit">
                        </div>
                    </li>
                    <li>
                        <label>
                            Booking Source
                        </label>
                        <%:Html.DropDownListFor(model => model.PNRDetails[i].BookingSource,Model.SelectListCollection.BookingSourceList)%>
                        <%:Html.ValidationMessageFor(model=>model.PNRDetails[i].BookingSource) %>
                    </li>
                    <li>
                        <label>
                            PCC
                        </label>
                        <%:Html.TextBoxFor(model => model.PNRDetails[i].PCC)%>
                    </li>
                    <li>
                        <label style="float: left;">
                            Remarks</label>
                        <%: Html.TextAreaFor(model => model.PNRDetails[i].Remarks, new { @style="width:250px; hegiht:100px;" })%>
                    </li>
                </ul>
            </div>
            <div class="passInfo clearfix">
                <h3>
                    PNR Information</h3>
                <ul class="detailsGrid clearfix">
                    <li class="tltblk">
                        <label>
                            Prefix</label>
                        <%:Html.DropDownListFor(model => model.PNRDetails[i].PnrInfoPrefix,
                                                                   Model.SelectListCollection.PrefixList)%>
                    </li>
                    <li>
                        <label>
                            First Name</label>
                        <%:Html.TextBoxFor(model => model.PNRDetails[i].PnrInfoFirstName,
                                                                  new { @class = "required", @onkeypress = "return CheckAlbhabet(event)" })%>
                    </li>
                    <li>
                        <label>
                            Middle Name</label>
                        <%:Html.TextBoxFor(model => model.PNRDetails[i].PnrInfoMiddleName, new {@onkeypress = "return CheckAlbhabet(event)" })%>
                    </li>
                    <li>
                        <label>
                            Last Name</label>
                        <%:Html.TextBoxFor(model => model.PNRDetails[i].PnrInfoLastName,
                                                                  new { @class = "required", @onkeypress = "return CheckAlbhabet(event)" })%>
                    </li>
                </ul>
            </div>
            <div class="passInfo clearfix">
                <h3>
                    Passenger Information</h3>
                <ul class="detailsGrid clearfix">
                    <li class="tltblk">
                        <label>
                            Pax Type</label>
                    </li>
                    <li class="tltblk">
                        <label>
                            Prefix</label>
                    </li>
                    <li>
                        <label>
                            First Name</label>
                    </li>
                    <li>
                        <label>
                            Middle Name</label>
                    </li>
                    <li>
                        <label>
                            Last Name</label>
                    </li>
                    <li style="width: 80px;">
                        <label>
                            Ticket No</label>
                    </li>
                    <li style="width: 90px;">
                        <label>
                            DOB</label>
                    </li>
                    <li style="width: 15px;">&nbsp;</li>
                </ul>
                <%  for (int j = 0; j < Model.PNRDetails[i].PassengerDetail.Count; j++)
                    { %>
                <div class="Passenger<%=i%>" id="Passenger_<%=i%>">
                    <input type="hidden" value="<%=j%>" name="PNRDetails[<%=i%>].PassengerDetail.Index"
                        id="PNRDetails_<%=i%><%=j%>_Index" />
                    <ul class="detailsGrid clearfix">
                        <li class="tltblk">
                            <%:Html.DropDownListFor(model => model.PNRDetails[i].PassengerDetail[j].PaxType, 
                                                         Model.SelectListCollection.PaxTypeList)%>
                        </li>
                        <li class="tltblk">
                            <%:Html.DropDownListFor(model => model.PNRDetails[i].PassengerDetail[j].Prefix,
                                                         Model.SelectListCollection.PrefixList)%>
                        </li>
                        <li>
                            <%:Html.TextBoxFor(model => model.PNRDetails[i].PassengerDetail[j].FirstName,
                                                                            new { @class = "required", @onkeypress = "return CheckAlbhabet(event)" })%>
                        </li>
                        <li>
                            <%:Html.TextBoxFor(model => model.PNRDetails[i].PassengerDetail[j].MiddleName, new {@onkeypress = "return CheckAlbhabet(event)" })%>
                        </li>
                        <li>
                            <%:Html.TextBoxFor(model => model.PNRDetails[i].PassengerDetail[j].LastName,
                                                                            new { @class = "required", @onkeypress = "return CheckAlbhabet(event)" })%>
                        </li>
                        <li style="width: 80px;">
                            <%: Html.TextBoxFor(model => model.PNRDetails[i].PassengerDetail[j].FareDetail.TicketNumber, new { @class = "required", @style = " width:70px;" })%>
                        </li>
                        <li style="width: 80px;">
                            <%: Html.TextBoxFor(model => model.PNRDetails[i].PassengerDetail[j].DOB, new { @class = "DOB", @style = " width:75px;" })%>
                        </li>
                        <li style="width: 15px;"><a href="javascript:voide(0)" id="Cancel_<%=j %>" rel="<%=j %>"
                            class="delete" style="display: none; float: left;">&nbsp;</a></li>
                    </ul>
                    <hr />
                </div>
                <%   }%>
                <input type="button" id="AddPassenger<%=i %>" value="Add Passenger" style="float: right;
                    text-transform: capitalize;" />
            </div>
            <div class="passInfo clearfix">
                <h3>
                    Segment Details</h3>
                <ul class="detailsGrid clearfix">
                    <li style="width: 65px;">
                        <label>
                            Dep City
                        </label>
                    </li>
                    <li style="width: 65px;">
                        <label>
                            Arr City
                        </label>
                    </li>
                    <li style="width: 48px;">
                        <label>
                            Airline
                        </label>
                    </li>
                    <li style="width: 66px;">
                        <label>
                            Airline PNR</label>
                    </li>
                    <li style="width: 81px;">
                        <label>
                            Dept Date
                        </label>
                    </li>
                    <li style="width: 70px;">
                        <label>
                            DeptTime
                        </label>
                    </li>
                    <li style="width: 81px;">
                        <label>
                            Arrival Date
                        </label>
                    </li>
                    <li style="width: 70px;">
                        <label>
                            Arrival Time
                        </label>
                    </li>
                    <li style="width: 48px;">
                        <label>
                            Class</label>
                    </li>
                    <li style="width: 70px;">
                        <label>
                            AirlineNo</label>
                    </li>
                    <li style="width: 60px;">
                        <label>
                            Baggage</label>
                    </li>
                    <li style="width: 15px;">&nbsp;</li>
                </ul>
                <%
              for (int k = 0; k < Model.PNRDetails[i].SegmentDetail.Count; k++)
              {%>
                <div id="Segment_<%=i %>" class="Segment<%=i %>">
                    <input type="hidden" value="<%=k %>" name="PNRDetails[<%=i %>].SegmentDetail.Index"
                        id="PNRDetails_SegmentDetail<%=i %><%=k %>_Index" />
                    <ul class="detailsGrid clearfix">
                        <li style="width: 65px;">
                            <%:Html.DropDownListFor(model => model.PNRDetails[i].SegmentDetail[k].DepartCityId, Model.SelectListCollection.CityList, "---Select---", new { @style = "width:60px;", @class = "required cityPair" })%>
                        </li>
                        <li style="width: 65px;">
                            <%:Html.DropDownListFor(model => model.PNRDetails[i].SegmentDetail[k].ArrivalCityId, Model.SelectListCollection.CityList, "---Select---", new { @style = "width:60px;", @class = "required" })%>
                        </li>
                        <li style="width: 48px;">
                            <%:Html.DropDownListFor(model => model.PNRDetails[i].SegmentDetail[k].AirlineId, Model.SelectListCollection.AirlineList, new { @style = " width:43px;" })%>
                        </li>
                        <li style="width: 66px;">
                            <%:Html.TextBoxFor(model => model.PNRDetails[i].SegmentDetail[k].AirlineRefNumber, new { @class = "required", @style=" width:60px;"})%>
                        </li>
                        <li style="width: 81px;">
                            <%: Html.TextBoxFor(model => model.PNRDetails[i].SegmentDetail[k].DepartDate, new { @class = "timepicker  required", @style = " width:80px;" })%>
                        </li>
                        <li style="width: 70px;">
                            <%: Html.TextBoxFor(model => model.PNRDetails[i].SegmentDetail[k].DepartTime, new { @class = "time required",  @style = " width:60px;" })%>
                        </li>
                        <li style="width: 81px;">
                            <%: Html.TextBoxFor(model => model.PNRDetails[i].SegmentDetail[k].ArrivalDate, new { @class = "timepicker required", @style = " width:80px;" })%>
                        </li>
                        <li style="width: 70px;">
                            <%: Html.TextBoxFor(model => model.PNRDetails[i].SegmentDetail[k].ArrivalTime, new { @class = "time required",  @style = " width:60px;" })%>
                        </li>
                        <li style="width: 48px;">
                            <%:Html.DropDownListFor(model => model.PNRDetails[i].SegmentDetail[k].BIC, Model.SelectListCollection.BICList, new {  @style="width:40px;"})%>
                        </li>
                        <li style="width: 70px;">
                            <%:Html.TextBoxFor(model => model.PNRDetails[i].SegmentDetail[k].FlightNumber, new { @class = "required", @style = " width:50px;" })%>
                        </li>
                        <li style="width: 60px;">
                            <%:Html.TextBoxFor(model => model.PNRDetails[i].SegmentDetail[k].Baggage, new {  @style = " width:50px;" })%>
                        </li>
                        <li style="width: 15px;"><a href="javascript:void(0)" id="Cancel_Seg<%=k %>" rel="<%=k %>"
                            class="delete2 deleteSegment" style="display: none; float: left;">&nbsp;</a>
                        </li>
                    </ul>
                    <hr />
                </div>
                <input type="button" id="AddSegment<%=i %>" value="Add Segment" style="float: right;
                    text-transform: capitalize;" />
                <br />
                <% } %>
            </div>
            <div class="passInfo clearfix">
                <h3>
                    Fare Details</h3>
                <table style="width: 100%;">
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
                <%--<ul class="detailsGrid clearfix">
                    <li style="width: 60px;">
                        <label>
                            Pax Type</label>
                    </li>
                    <li style="width: 67px;">
                        <label>
                            Currency
                        </label>
                    </li>
                    <li style="width: 50px;">
                        <label>
                            Ex Rate
                        </label>
                    </li>
                    <li style="width: 69px;">
                        <label>
                            Base Fare</label>
                    </li>
                    <li style="width: 56px;">
                        <label>
                            YQ/FSC</label>
                    </li>
                    <li style="width: 45px;">
                        <label>
                            Tax</label>
                    </li>
                    <li style="width: 55px;">
                        <label>
                            Ser Tax</label>
                    </li>
                    <li style="width: 45px;">
                        <label>
                            OC</label>
                    </li>
                    <li style="width: 48px;">
                        <label>
                            Markup</label>
                    </li>
                    <li style="width: 59px;">
                        <label>
                            Discount</label>
                    </li>
                    <li style="width: 50px;">
                        <label>
                            Comm</label>
                    </li>
                    <li style="width: 15px;">&nbsp;</li>
                </ul>--%>
                <%  for (int j = 0; j < Model.PNRDetails[i].PassengerDetail.Count; j++)
                    { %>
                <div id="Fare_<%=i %>" class="Fare<%=i %>">
                    <input type="hidden" value="<%=j %>" name="PNRDetails[<%=i %>].FareDetail.Index"
                        id="PNRDetails_FareDetail<%=i %><%=j %>_Index" />
                    <%--<ul class="detailsGrid clearfix">
                        <li style="width: 60px;">
                            <%:Html.DropDownListFor(model => model.PNRDetails[i].PassengerDetail[j].FareDetail.FarePaxType,
                                                                                 Model.SelectListCollection.PaxTypeList, new { @style = " width:55px;" })%>
                        </li>
                        <li style="width: 67px;">
                            <%:Html.DropDownListFor(model => model.PNRDetails[i].PassengerDetail[j].FareDetail.Currency, Model.SelectListCollection.CurrencyList, new { @style = " width:60px;" })%>
                        </li>
                        <li style="width: 50px;">
                            <%: Html.TextBoxFor(model => model.PNRDetails[i].PassengerDetail[j].FareDetail.ExchangeRate, new { @class = "required number", @Value = 1, @style = " width:40px;", @onkeypress = "return CheckFareNumericValue(event)" })%>
                        </li>
                        <li style="width: 69px;">
                            <%: Html.TextBoxFor(model => model.PNRDetails[i].PassengerDetail[j].FareDetail.SellingBaseFare, new { @class = "required number", @style = " width:60px;", @onkeypress = "return CheckFareNumericValue(event)" })%>
                        </li>
                        <li style="width: 56px;">
                            <%: Html.TextBoxFor(model => model.PNRDetails[i].PassengerDetail[j].FareDetail.SellingFSC, new { @style = " width:46px;", @onkeypress = "return CheckFareNumericValue(event)" })%>
                        </li>
                        <li style="width: 45px;">
                            <%: Html.TextBoxFor(model => model.PNRDetails[i].PassengerDetail[j].FareDetail.SellingTax, new { @class = "required number ", @style = " width:35px;", @onkeypress = "return CheckFareNumericValue(event)" })%>
                        </li>
                        <li style="width: 55px;">
                            <%: Html.TextBoxFor(model => model.PNRDetails[i].PassengerDetail[j].FareDetail.ServiceTax, new { @style = " width:50px;", @onkeypress = "return CheckFareNumericValue(event)" })%>
                        </li>
                        <li style="width: 45px;">
                            <%: Html.TextBoxFor(model => model.PNRDetails[i].PassengerDetail[j].FareDetail.OtherCharges, new { @Value = 0, @style = " width:40px;", @onkeypress = "return CheckFareNumericValue(event)" })%>
                        </li>
                        <li style="width: 48px;">
                            <%: Html.TextBoxFor(model => model.PNRDetails[i].PassengerDetail[j].FareDetail.MarkupAmount, new { @style = " width:39px;", @onkeypress = "return CheckFareNumericValue(event)" })%>
                        </li>
                        <li style="width: 59px;">
                            <%: Html.TextBoxFor(model => model.PNRDetails[i].PassengerDetail[j].FareDetail.DiscountAmount, new { @style = " width:46px;", @onkeypress = "return CheckFareNumericValue(event)" })%>
                        </li>
                        <li style="width: 50px;">
                            <%: Html.TextBoxFor(model => model.PNRDetails[i].PassengerDetail[j].FareDetail.CommissionAmount, new { @style = " width:40px;", @onkeypress = "return CheckFareNumericValue(event)" })%>
                        </li>
                        <li style="width: 15px;"><a href="javascript:void(0)" id="Cancel_Fare<%=j %>" rel="<%=j %>"
                            class="delete3 deleteFare" style="display: none; float: left;">&nbsp;</a> </li>
                    </ul>--%>
                    <%--New Fare Module starts--%>
                    <table style="width: 100%;">
                        <tr>
                            <td>
                                Pax Type
                            </td>
                            <td>
                                <%:Html.DropDownListFor(model => model.PNRDetails[i].PassengerDetail[j].FareDetail.FarePaxType,
                                                                                 Model.SelectListCollection.PaxTypeList, new { @style = " width:55px;" })%>
                            </td>
                            <td>
                                Ex Rate
                            </td>
                            <td>
                                <%: Html.TextBoxFor(model => model.PNRDetails[i].PassengerDetail[j].FareDetail.ExchangeRate, new { @class = "required number", @Value = 1, @onkeypress = "return CheckFareNumericValue(event)" })%>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Currency
                            </td>
                            <td>
                                <%:Html.DropDownListFor(model => model.PNRDetails[i].PassengerDetail[j].FareDetail.Currency, Model.SelectListCollection.CurrencyList, new { @style = " width:60px;" })%>
                            </td>
                            <td>
                                Markup
                            </td>
                            <td>
                                <%: Html.TextBoxFor(model => model.PNRDetails[i].PassengerDetail[j].FareDetail.MarkupAmount, new { @onkeypress = "return CheckFareNumericValue(event)", @onkeyup = "CalculateSellingBaseFare(this);" })%>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Base Fare
                            </td>
                            <td>
                                <%: Html.TextBoxFor(model => model.PNRDetails[i].PassengerDetail[j].FareDetail.BaseFare, new { @class = "required number", @onkeypress = "return CheckFareNumericValue(event);", @onkeyup = "CalculateSellingBaseFare(this);" })%>
                            </td>
                            <td>
                                Selling Base Fare
                            </td>
                            <td>
                                <%: Html.TextBoxFor(model => model.PNRDetails[i].PassengerDetail[j].FareDetail.SellingBaseFare, new { @class = "required number",  @onkeypress = "return CheckFareNumericValue(event)",@readonly=true })%>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Tax
                            </td>
                            <td>
                                <%: Html.TextBoxFor(model => model.PNRDetails[i].PassengerDetail[j].FareDetail.Tax, new { @class = "required number", @onkeypress = "return CheckFareNumericValue(event)", @onkeyup = "copyTaxColumn(this);" })%>
                            </td>
                            <td>
                                Selling Tax
                            </td>
                            <td>
                                <%: Html.TextBoxFor(model => model.PNRDetails[i].PassengerDetail[j].FareDetail.SellingTax, new { @class = "required number", @onkeypress = "return CheckFareNumericValue(event)" })%>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Commission
                            </td>
                            <td>
                                <%: Html.TextBoxFor(model => model.PNRDetails[i].PassengerDetail[j].FareDetail.CommissionAmount, new { @onkeypress = "return CheckFareNumericValue(event)" })%>
                            </td>
                            <td>
                                Discount
                            </td>
                            <td>
                                <%: Html.TextBoxFor(model => model.PNRDetails[i].PassengerDetail[j].FareDetail.DiscountAmount, new {@onkeypress = "return CheckFareNumericValue(event)" })%>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                FSC
                            </td>
                            <td>
                                <%: Html.TextBoxFor(model => model.PNRDetails[i].PassengerDetail[j].FareDetail.FSC, new { @onkeypress = "return CheckFareNumericValue(event)", @onkeyup = "copyFSCColumn(this);" })%>
                            </td>
                            <td>
                              Selling FSC
                            </td>
                            <td>
                                <%: Html.TextBoxFor(model => model.PNRDetails[i].PassengerDetail[j].FareDetail.SellingFSC, new {@onkeypress = "return CheckFareNumericValue(event)" })%>
                                &nbsp;<a href="javascript:void(0)" id="Cancel_Fare<%=j %>" rel="<%=j %>" class="delete3 deleteFare"
                                    style="display: none; float: right;">&nbsp;</a>
                            </td>
                        </tr>
                    </table>
                    <hr />
                </div>
                <%--New Fare Module ends--%>
                <%   }%>
                <input type="button" id="AddFare<%=i %>" value="Add Fare" style="float: right; text-transform: capitalize;" />
                <%--              <table style="margin-left: 487px;">
                    <tr>
                        <td>
                            <b>Airline Fee</b>
                        </td>
                        <td>
                            <%: Html.TextBoxFor(model => model.PNRDetails[0].PassengerDetail[0].FareDetail.SellingAdditionalTxnFee, new { @style = " width:45px;", @onkeypress = "return CheckFareNumericValue(event)" })%>
                        </td>
                    </tr>
                </table>--%>
            </div>
            <% }
       
            %>
            <br />
            <h6>
                Upload eTicket</h6>
            <p>
                <input type="file" id="ticket" name="ticket" /></p>
            <br />
            <p>
                <input type="submit" id="Save" value="Create" style="text-transform: capitalize;" />
                <%: Html.ActionLink("Back to List", "Index", null, new  {@class="linkButton" })%></p>
            <span id="fileError" style="color: Red;"></span>
            <% } %>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CssContent" runat="server">
    <link href="../../../../Content/css/atsfltsearch.css" rel="stylesheet" type="text/css" />
    <link href="../../../../Content/themes/redmond/jquery.ui.all.css" rel="stylesheet"
        type="text/css" />
    <link href="../../../../Content/themes/redmond/jquery.ui.base.css" rel="stylesheet"
        type="text/css" />
    <link href="../../../../Content/themes/redmond/jquery-ui-1.8.13.custom.css" rel="stylesheet"
        type="text/css" />
    <style type="text/css">
        .error
        {
            color: #FF0000;
        }
        
        input.error
        {
            background-color: #FFEEEE;
            border: 1px solid #FF0000;
        }
        label.error
        {
            display: none;
        }
        
        
        
        input
        {
            text-transform: uppercase;
        }
        
        
        
        #ui-datepicker-div, .ui-datepicker
        {
            font-size: 80%;
        }
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
            margin-bottom: -25px;
        }
        .ui-timepicker-div dl dd
        {
            margin: 0 10px 10px 65px;
        }
        .ui-timepicker-div td
        {
            font-size: 90%;
        }
        .ui-tpicker-grid-label
        {
            background: none;
            border: none;
            margin: 0;
            padding: 0;
        }
    </style>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
    <script src="../../../../Scripts/jquery.ui.timepicker.js" type="text/javascript"></script>
    <script src="/Scripts/ATL.jquery.funtion.js" type="text/javascript"></script>
    <script src="/Scripts/jquery.maskedinput-1.3.js" type="text/javascript"></script>
    <script src="/Scripts/jquery.validate.js" type="text/javascript"></script>
    <script src="../../../../Scripts/jquery.ui.autocomplete.selectFirst.js" type="text/javascript"></script>
    <script type="text/javascript">
        function CheckAlbhabet(e) {
            var key = e.which ? e.which : e.keyCode;
            //A-Z a-z and space key//              
            if ((key > 64 && key < 91) || (key > 96 && key < 123) || key == 8 || key == 32 || key == 9) {
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


        function CheckEmail(e) {

            var key = e.which ? e.which : e.keyCode;
            if ((key > 64 && key < 91) || (key > 96 && key < 123) || key == 8 || (key >= 48 && key <= 57) || key == 13 || key == 8 || key == 9 || key == 27 || key == 46 || key == 64) {
                return true;
            }
            else {

                return false;
            }
        }
    </script>
    <script type="text/javascript">
        $(".uppercase").bind('keyup', function (e) {
            if (e.which >= 97 && e.which <= 122) {
                var newKey = e.which - 32;

                e.keyCode = newKey;
                e.charCode = newKey;
            }

            $(".uppercase").val(($(".uppercase").val()).toUpperCase());
        });
    </script>
    <script type="text/javascript">
        $(document).ready(function () {
            ////////////////////////////////////////////////////////////////////////////////////////////
            $("#PNRDetails_0__GDSPNR").blur(function () {
                var GDSPNR = $("#PNRDetails_0__GDSPNR").val();

                if (GDSPNR == "") {
                    return false;
                }
                $("#imageLoaderDiv").show();
                $.post("/Administrator/AjaxRequest/CheckDuplicateGDSPNR", { GDSPNR: GDSPNR }, function (data) {
                    if (data) {
                        $("#imageLoaderDiv").hide();
                        $("#check_GDSPNR").show();
                        $("#check_GDSPNR").attr({ color: "Green" });
                        $("#check_GDSPNR").html("<span style='color:green'><b>GDS PNR is valid.</b></span>");
                    }
                    else {
                        $("#imageLoaderDiv").hide();
                        $("#check_GDSPNR").show();
                        $("#check_GDSPNR").attr({ color: "Red" });
                        $("#check_GDSPNR").html("<span style = 'color:red'>Please choose a different GDS PNR")

                    }
                }, "json");
            });
            ////////////////////////////////////////////////////////////////////////////////////////////
        });
    </script>
    <script type="text/javascript">
        $(function () {
            $('input[id$=PNRDetails_0__PnrInfoFirstName]').keyup(function () {
                var PnrInfoFirstName = $(this).val();
                var FirstName = PnrInfoFirstName;
                $('input[id$=PNRDetails_0__PassengerDetail_0__FirstName]').val(FirstName);
            });
        });


        $(function () {
            $('input[id$=PNRDetails_0__PnrInfoMiddleName]').keyup(function () {
                var PnrInfoMiddleName = $(this).val();
                var MiddleName = PnrInfoMiddleName;
                $('input[id$=PNRDetails_0__PassengerDetail_0__MiddleName]').val(MiddleName);
            });
        });

        $(function () {
            $('input[id$=PNRDetails_0__PnrInfoLastName]').keyup(function () {
                var PnrInfoLastName = $(this).val();
                var LastName = PnrInfoLastName;
                $('input[id$=PNRDetails_0__PassengerDetail_0__LastName]').val(LastName);
            });
        });

    </script>
    <!-- Depart City and Arrive City Autocomplete-->
    <script type="text/javascript">

        $(document).ready(function () {
            $('.DepartCity').live('click', function () {
                $(this).autocomplete('destroy').autocomplete({
                    source: function (request, response) {
                        $.ajax({
                            url: "/Airline/AirOfflineBook/FindAirlineCity", type: "POST", dataType: "json",
                            data: { searchText: request.term, maxResult: 5 },

                            success: function (data) {
                                response($.map(data, function (item) {
                                    return { label: item.CityName + " (" + item.CityCode + ")", value: item.CityName, id: item.CityID }
                                }))
                            }
                        });
                    },
                    width: 150,
                    select: function (event, ui) {
                        $("#hdfDepartureCityId").val(ui.item.id);
                    }
                });
            });
        }); 
  
      
    </script>
    <script type="text/javascript">

        $(document).ready(function () {
            $('.ArrivalCity').live('click', function () {
                $(this).autocomplete('destroy').autocomplete({
                    source: function (request, response) {
                        $.ajax({
                            url: "/Airline/AirOfflineBook/FindAirlineCity", type: "POST", dataType: "json",
                            data: { searchText: request.term, maxResult: 5 },

                            success: function (data) {
                                response($.map(data, function (item) {
                                    return { label: item.CityName + " (" + item.CityCode + ")", value: item.CityName, id: item.CityID }
                                }))
                            }
                        });
                    },
                    width: 150,
                    select: function (event, ui) {
                        $("#hdfArrivalCityId").val(ui.item.id);

                    }
                });
            });
        }); 
  
      
    </script>
    <script type="text/javascript">

        $(document).ready(function () {
            $('.AirlineList').live('click', function () {
                $(this).autocomplete('destroy').autocomplete({
                    source: function (request, response) {
                        $.ajax({
                            url: "/Airline/AirOfflineBook/FindAirlineCity", type: "POST", dataType: "json",
                            data: { searchText: request.term, maxResult: 5 },

                            success: function (data) {
                                response($.map(data, function (item) {
                                    return { label: item.CityName + " (" + item.CityCode + ")", value: item.CityName, id: item.CityID }
                                }))
                            }
                        });
                    },
                    width: 150,
                    select: function (event, ui) {
                        $("#hdfDepartureCityId").val(ui.item.id);
                    }
                });
            });
        }); 
  
      
    </script>
    <!-- Upload ETicket-->
    <script type="text/javascript">
        $(document).ready(function () {
            $('.validate').validate();
        });

    <%-- Delete--%>

        var paxLastId = 1;
        var segLastId = 1;
        var FareLastId = 1;

        $(".delete").live("click", function () {
            var divId = $(this).attr('rel');
            $("#Passenger_" + divId).css("background-color", "orange").fadeOut(1000, function () { $(this).remove(); });
        });

        $(".deleteSegment").live("click", function () {
            var divId = $(this).attr('rel');
            $("#Segment_" + divId).css("background-color", "orange").fadeOut(1000, function () { $(this).remove(); });
        });

         $(".deleteFare").live("click", function () {
        
            var divId = $(this).attr('rel');
            $("#Fare_" + divId).css("background-color", "orange").fadeOut(1000, function () { $(this).remove(); });
        });


    </script>
    <!-- Validation for pax type-->
    <script type="text/javascript">
        //        $("#Save").live("click", function () {
        //            validatePaxFare();
        //        });

        function CalculateSellingBaseFare(element) {

            var baseFareId = element.id;
            var prefix = baseFareId.substring(0, baseFareId.lastIndexOf('_') + 1);
            var markupAmount = parseFloat($("#" + prefix + "MarkupAmount").val());
            var baseFareAmount = parseFloat($("#" + prefix + "BaseFare").val());

            $("#" + prefix + "SellingBaseFare").val(markupAmount + baseFareAmount);
        }

        function copyTaxColumn(element) {
            var controlToCopy = element.id;
            var prefix = controlToCopy.substring(0, controlToCopy.lastIndexOf('_') + 1);
           
            var tax = parseFloat($("#" + prefix + "Tax").val());

            $("#" + prefix + "SellingTax").val(tax);
        }



        function copyFSCColumn(element) {
            var controlToCopy = element.id;
            var prefix = controlToCopy.substring(0, controlToCopy.lastIndexOf('_') + 1);

            var tax = parseFloat($("#" + prefix + "FSC").val());

            $("#" + prefix + "SellingFSC").val(tax);
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

            //CityPair Validation
//            var isValidDatePair = true;
//            $(".datePair").each(function () {
//                var DepartDateId = this.id;

//                var DepartDate = $("#" + DepartDateId).val();
//                //  alert(DepartDate);
//                var prefix = DepartDateId.substring(0, DepartDateId.lastIndexOf('__') + 2);

//                var arrivalDateId = prefix + "ArrivalDate";
//                var arrivalDate = $("#" + arrivalDateId).val();
//                // alert(arrivalDate);

//                if (DepartDate >= arrivalDate) {
//                    isValidDatePair = false;
//                }
//            });

//            //CityPair validation end
//            if (isValidDatePair == false) {
//                alert("Choose different Date pairs");
//                return false;
//            }

            var farePaxTypeElements = $('select[id$="FarePaxType"]');
            var paxTypeElements = $('select[id$=_PaxType]');
            var farePaxTypeLength = farePaxTypeElements.length;

            var isAdult = false;
            var isChild = false;
            var isInfant = false;

            var isFareAdult = false;
            var isFareChild = false;
            var isFareInfant = false;

            var paxCount = 0;
            var farePaxCount = 0;

            paxTypeElements.each(function (index) {
                if ($(this).val() == 1) {
                    isAdult = true;
                }
                else if ($(this).val() == 2) {
                    isChild = true;
                }
                else if ($(this).val() == 3) {
                    isInfant = true;
                }
            });


            if (isAdult == true) {
                paxCount = paxCount + 1;
            }
            if (isChild == true) {
                paxCount = paxCount + 1;
            }
            if (isInfant == true) {
                paxCount = paxCount + 1;
            }
            // alert('No of Pax:' + paxCount);

            farePaxTypeElements.each(function (index) {

                if ($(this).val() == 1) {
                    isFareAdult = true;
                }
                else if ($(this).val() == 2) {
                    isFareChild = true;
                }
                else if ($(this).val() == 3) {
                    isFareInfant = true;
                }
            });

            if (isFareAdult == true) {

                farePaxCount = farePaxCount + 1;
            }
            if (isFareChild == true) {

                farePaxCount = farePaxCount + 1;
            }
            if (isFareInfant == true) {

                farePaxCount = farePaxCount + 1;
            }

            if (isAdult == isFareAdult && isChild == isFareChild && isInfant == isFareInfant && paxCount == farePaxCount && farePaxTypeLength == farePaxCount) {

                var alertMsg = "'Are you sure to save the details?'";
                var isValid = $("#bookingForm").valid();
                if (isValid && alertMsg != "") {
                    if (confirm(alertMsg)) {
                        //  $('#bookingForm').submit();
                        return true;
                    }
                }
            }
            else {
                alert('Please enter valid pax type in fare.');
                return false;
            }
        }
    </script>
    <!-- AutoComplete-->
    <script type="text/javascript">
        $(document).ready(function () {
            $('.agentAutoComplete').live('click', function () {
                $(this).autocomplete('destroy').autocomplete({
                    source: function (request, response) {
                        $.ajax({
                            url: "/Airline/AjaxRequest/GetAgentNameListAC", type: "POST", dataType: "json",
                            data: { searchText: request.term, maxResult: 5 },

                            success: function (data) {
                                response($.map(data, function (item) {
                                    return { label: item.AgentName, value: item.AgentName, id: item.AgentId }
                                }))
                            }
                        });
                    },
                    width: 150,
                    selectFirst: true,
                    select: function (event, ui) {
                        $("#UserDetail_AgentId").val(ui.item.id);
                        $("#AgentInfo").html(ui.item.label);
                        GetAccountInfo(ui.item.id);
                    }
                });
            });
        });

        function GetAccountInfo(agentId) {
            $.ajax({
                url: "/Airline/AjaxRequest/GetAccountInfoByAgentId",
                type: "POST",
                dataType: "json",
                data: { agentId: agentId },
                success: function (data) {
                    $("#CreditLimitNPR").html(data.Data.CreditLimitNPR);
                    $("#AvailableBalanceNPR").html(data.Data.CurrentBalanceNPR.toFixed(2));
                    $("#LedgerBalanceNPR").html(data.Data.LeadgerBalanceNPR.toFixed(2));
                    $("#CreditLimitUSD").html(data.Data.CreditLimitUSD);
                    $("#AvailableBalanceUSD").html(data.Data.CurrentBalanceUSD.toFixed(2));
                    $("#LedgerBalanceUSD").html(data.Data.LeadgerBalanceUSD.toFixed(2));
                }
            });
        }
    </script>
    <%--  Date and Mask--%>
    <script type="text/javascript">


        $('.passportExpire').live('click', function () {
            $(this).datepicker('destroy').datepicker({
                defaultDate: new Date(),
                   changeMonth: true,
                changeYear: true,
                dateFormat: 'dd M yy',
                minDate: '+0d',
                maxDate: '+30y',
            }).focus();
        });


        $('.birthDate').live('click', function () {
            $(this).datepicker('destroy').datepicker({
                defaultDate: new Date(),
                changeMonth: true,
                changeYear: true,
                constrainInput: true,
                      maxDate: new Date(),
                numberOfMonths: 1,
                disable: true,
                showAnim: 'fold',
                dateFormat: 'dd M yy',
                     yearRange: '-95'
            }).focus();
        });

        now = new Date();
        $('.DOB').live('click', function () {
            $(this).datepicker('destroy').datepicker({
//                defaultDate: new Date(),
//                changeMonth: true,
//                changeYear: true,
//                constrainInput: true,
//                numberOfMonths: 1,
//                disable: true,
//                showAnim: 'fold',
//                dateFormat: 'dd M yy',
//                maxDate: new Date()
                 changeMonth: true,
                changeYear: true,
                dateFormat: 'dd M yy',
                yearRange: '-100:-00',
                defaultDate: new Date(now.getFullYear() - 12, 00, 01)
            }).focus();
        });



        $('.timepicker').live('click', function () {
            $(this).datepicker('destroy').datepicker({
                ampm: true,
                hourGrid: 4,
                minuteGrid: 10,
                numberOfMonths: 1,
                dateFormat: 'dd M yy',
                minDate: 0
            }).focus();
        });


        $(".time").live('click', function () {

            $(".time").mask("99:99", { placeholder: "0" });


        });


    </script>
    <%--  Passenger 0--%>
    <script type="text/javascript">
        $("#AddPassenger0").live("click", function () {

            var generateId = ++paxLastId;

            var paxTypeId = "PNRDetails_0__PassengerDetail_" + generateId.toString() + "__PaxType";
            var paxType = "PNRDetails[0].PassengerDetail[" + generateId.toString() + "].PaxType";

            var prefixId = "PNRDetails_0__PassengerDetail_" + generateId.toString() + "__Prefix";
            var prefix = "PNRDetails[0].PassengerDetail[" + generateId.toString() + "].Prefix";

            var firstNameId = "PNRDetails_0__PassengerDetail_" + generateId.toString() + "__FirstName";
            var firstName = "PNRDetails[0].PassengerDetail[" + generateId.toString() + "].FirstName";

            var middleNameId = "PNRDetails_0__PassengerDetail_" + generateId.toString() + "__MiddleName";
            var middleName = "PNRDetails[0].PassengerDetail[" + generateId.toString() + "].MiddleName";


            var lastNameId = "PNRDetails_0__PassengerDetail_" + generateId.toString() + "__LastName";
            var lastName = "PNRDetails[0].PassengerDetail[" + generateId.toString() + "].LastName";

            var phoneId = "PNRDetails_0__PassengerDetail_" + generateId.toString() + "__Phone";
            var phone = "PNRDetails[0].PassengerDetail[" + generateId.toString() + "].Phone";

            var dobId = "PNRDetails_0__PassengerDetail_" + generateId.toString() + "__DOB";
            var dob = "PNRDetails[0].PassengerDetail[" + generateId.toString() + "].DOB";

            var passportnumberId = "PNRDetails_0__PassengerDetail_" + generateId.toString() + "__PassportNumber";
            var passportnumberName = "PNRDetails[0].PassengerDetail[" + generateId.toString() + "].PassportNumber";

            var passportIssuedCountryId = "PNRDetails_0__PassengerDetail_" + generateId.toString() + "__PassportIssuedCountryId";
            var passportIssuedCountry = "PNRDetails[0].PassengerDetail[" + generateId.toString() + "].PassportIssuedCountryId";

            var passportIssuedDateId = "PNRDetails_0__PassengerDetail_" + generateId.toString() + "__PassportIssuedDate";
            var passportIssuedDate = "PNRDetails[0].PassengerDetail[" + generateId.toString() + "].PassportIssuedDate";

            var passportExpDateId = "PNRDetails_0__PassengerDetail_" + generateId.toString() + "__PassportExpDate";
            var passportExpDateName = "PNRDetails[0].PassengerDetail[" + generateId.toString() + "].PassportExpDate";

            var nationalityId = "PNRDetails_0__PassengerDetail_" + generateId.toString() + "__NationalityId";
            var nationalityName = "PNRDetails[0].PassengerDetail[" + generateId.toString() + "].NationalityId";


            var mealId = "PNRDetails_0__PassengerDetail_" + generateId.toString() + "__Meal";
            var meal = "PNRDetails[0].PassengerDetail[" + generateId.toString() + "].Meal";

            var seatId = "PNRDetails_0__PassengerDetail_" + generateId.toString() + "__Seat";
            var seat = "PNRDetails[0].PassengerDetail[" + generateId.toString() + "].Seat";

            var ffAirNameId = "PNRDetails_0__PassengerDetail_" + generateId.toString() + "__FrequentFlyerAirline";
            var ffAirName = "PNRDetails[0].PassengerDetail[" + generateId.toString() + "].FrequentFlyerAirline";

            var ffAirlineId = "PNRDetails_0__PassengerDetail_" + generateId.toString() + "__FrequentFlyerAirlineId";
            var ff = "PNRDetails[0].PassengerDetail[" + generateId.toString() + "].FrequentFlyerAirlineId";

            var ffNoId = "PNRDetails_0__PassengerDetail_" + generateId.toString() + "__FrequentFlyerNo";
            var ffno = "PNRDetails[0].PassengerDetail[" + generateId.toString() + "].FrequentFlyerNo";


            var currencyId = "PNRDetails_0__PassengerDetail_" + generateId.toString() + "__FareDetail_Currency";
            var currency = "PNRDetails[0].PassengerDetail[" + generateId.toString() + "].FareDetail.Currency";

            var baseFareId = "PNRDetails_0__PassengerDetail_" + generateId.toString() + "__FareDetail_SellingBaseFare";
            var baseFare = "PNRDetails[0].PassengerDetail[" + generateId.toString() + "].FareDetail.SellingBaseFare";

            var fscId = "PNRDetails_0__PassengerDetail_" + generateId.toString() + "__FareDetail_SellingFSC";
            var fsc = "PNRDetails[0].PassengerDetail[" + generateId.toString() + "].FareDetail.SellingFSC";

            var taxId = "PNRDetails_0__PassengerDetail_" + generateId.toString() + "__FareDetail_SellingTax";
            var tax = "PNRDetails[0].PassengerDetail[" + generateId.toString() + "].FareDetail.SellingTax";

            var addtxnId = "PNRDetails_0__PassengerDetail_" + generateId.toString() + "__FareDetail_SellingAdditionalTxnFee";
            var addtxn = "PNRDetails[0].PassengerDetail[" + generateId.toString() + "].FareDetail.SellingAdditionalTxnFee";

            var airlinetranId = "PNRDetails_0__PassengerDetail_" + generateId.toString() + "__FareDetail_SellingAirlineTransFee";
            var airlinetran = "PNRDetails[0].PassengerDetail[" + generateId.toString() + "].FareDetail.SellingAirlineTransFee";

            var serviceTaxId = "PNRDetails_0__PassengerDetail_" + generateId.toString() + "__FareDetail_ServiceTax";
            var serviceTax = "PNRDetails[0].PassengerDetail[" + generateId.toString() + "].FareDetail.ServiceTax";

            var otherchargesId = "PNRDetails_0__PassengerDetail_" + generateId.toString() + "__FareDetail_OtherCharges";
            var othercharge = "PNRDetails[0].PassengerDetail[" + generateId.toString() + "].FareDetail.OtherCharges";

            var markupId = "PNRDetails_0__PassengerDetail_" + generateId.toString() + "__FareDetail_MarkupAmount";
            var markup = "PNRDetails[0].PassengerDetail[" + generateId.toString() + "].FareDetail.MarkupAmount";

            var discountId = "PNRDetails_0__PassengerDetail_" + generateId.toString() + "__FareDetail_DiscountAmount";
            var discount = "PNRDetails[0].PassengerDetail[" + generateId.toString() + "].FareDetail.DiscountAmount";

            var commissionId = "PNRDetails_0__PassengerDetail_" + generateId.toString() + "__FareDetail_CommissionAmount";
            var commission = "PNRDetails[0].PassengerDetail[" + generateId.toString() + "].FareDetail.CommissionAmount";

            var ticketId = "PNRDetails_0__PassengerDetail_" + generateId.toString() + "__FareDetail_TicketNumber";
            var ticket = "PNRDetails[0].PassengerDetail[" + generateId.toString() + "].FareDetail.TicketNumber";

            var item = $(".Passenger0:first").clone(true);

            $.each(item, function (index, element) {
                $(this).attr({ id: "Passenger_" + generateId.toString() });
            });


            $("#PNRDetails_00_Index", item).attr({ id: 'PNRDetails_00_Index', value: generateId.toString() });
            $("#PNRDetails_0__PassengerDetail_0__PaxType", item).attr({ id: paxTypeId, name: paxType });
            $("#PNRDetails_0__PassengerDetail_0__Prefix", item).attr({ id: prefixId, name: prefix });
            $("#PNRDetails_0__PassengerDetail_0__FirstName", item).val('');
            $("#PNRDetails_0__PassengerDetail_0__FirstName", item).attr({ id: firstNameId, name: firstName });
            $("#PNRDetails_0__PassengerDetail_0__MiddleName", item).val('');
            $("#PNRDetails_0__PassengerDetail_0__MiddleName", item).attr({ id: middleNameId, name: middleName });
            $("#PNRDetails_0__PassengerDetail_0__LastName", item).val('');
            $("#PNRDetails_0__PassengerDetail_0__LastName", item).attr({ id: lastNameId, name: lastName });
            $("#PNRDetails_0__PassengerDetail_0__Phone", item).attr({ id: phoneId, name: phone }).removeAttr('class');
            $("#PNRDetails_0__PassengerDetail_0__DOB", item).attr({ id: dobId, name: dob });


            $("#PNRDetails_0__PassengerDetail_0__PassportNumber", item).attr({ id: passportnumberId, name: passportnumberName });
            $("#PNRDetails_0__PassengerDetail_0__PassportIssuedCountryId", item).attr({ id: passportIssuedCountryId, name: passportIssuedCountry });
            $("#PNRDetails_0__PassengerDetail_0__PassportIssuedDate", item).attr({ id: passportIssuedDateId, name: passportIssuedDate });
            $("#PNRDetails_0__PassengerDetail_0__PassportExpDate", item).attr({ id: passportExpDateId, name: passportExpDateName });
            $("#PNRDetails_0__PassengerDetail_0__NationalityId", item).attr({ id: nationalityId, name: nationalityName });


            $("#PNRDetails_0__PassengerDetail_0__Meal", item).attr({ id: mealId, name: meal });
            $("#PNRDetails_0__PassengerDetail_0__Seat", item).attr({ id: seatId, name: seat });
            $("#PNRDetails_0__PassengerDetail_0__FrequentFlyerAirline", item).attr({ id: ffAirNameId, name: ffAirName });
            $("#PNRDetails_0__PassengerDetail_0__FrequentFlyerAirlineId", item).attr({ id: ffAirlineId, name: ff });
            $("#PNRDetails_0__PassengerDetail_0__FrequentFlyerNo", item).attr({ id: ffNoId, name: ffno });

            $("#PNRDetails_0__PassengerDetail_0__FareDetail_Currency", item).attr({ id: currencyId, name: currency });
            $("#PNRDetails_0__PassengerDetail_0__FareDetail_SellingBaseFare", item).attr({ id: baseFareId, name: baseFare });
            $("#PNRDetails_0__PassengerDetail_0__FareDetail_SellingFSC", item).attr({ id: fscId, name: fsc });
            $("#PNRDetails_0__PassengerDetail_0__FareDetail_SellingTax", item).attr({ id: taxId, name: tax });
            $("#PNRDetails_0__PassengerDetail_0__FareDetail_SellingAdditionalTxnFee", item).attr({ id: addtxnId, name: addtxn });
            $("#PNRDetails_0__PassengerDetail_0__FareDetail_SellingAirlineTransFee", item).attr({ id: airlinetranId, name: airlinetran });
            $("#PNRDetails_0__PassengerDetail_0__FareDetail_ServiceTax", item).attr({ id: serviceTaxId, name: serviceTax });
            $("#PNRDetails_0__PassengerDetail_0__FareDetail_OtherCharges", item).attr({ id: otherchargesId, name: othercharge });
            $("#PNRDetails_0__PassengerDetail_0__FareDetail_MarkupAmount", item).attr({ id: markupId, name: markup });
            $("#PNRDetails_0__PassengerDetail_0__FareDetail_DiscountAmount", item).attr({ id: discountId, name: discount });
            $("#PNRDetails_0__PassengerDetail_0__FareDetail_CommissionAmount", item).attr({ id: commissionId, name: commission });
            $("#PNRDetails_0__PassengerDetail_0__FareDetail_TicketNumber", item).val('');
            $("#PNRDetails_0__PassengerDetail_0__FareDetail_TicketNumber", item).attr({ id: ticketId, name: ticket });

            $("#Cancel_0", item).css({ "display": "block" });
            $("#Cancel_0", item).attr({ id: 'Cancel_' + generateId.toString(), rel: generateId.toString() });

            item.insertBefore("#AddPassenger0");
        });
    </script>
    <%-- Fare 0--%>
    <script type="text/javascript">
        $("#AddFare0").live("click", function () {

            var generateId = ++FareLastId;


            var FarepaxTypeId = "PNRDetails_0__PassengerDetail_" + generateId.toString() + "__FareDetail_FarePaxType";
            var FarepaxType = "PNRDetails[0].PassengerDetail[" + generateId.toString() + "].FareDetail.FarePaxType";

            var currencyId = "PNRDetails_0__PassengerDetail_" + generateId.toString() + "__FareDetail_Currency";
            var currency = "PNRDetails[0].PassengerDetail[" + generateId.toString() + "].FareDetail.Currency";

            var ExchangeRateId = "PNRDetails_0__PassengerDetail_" + generateId.toString() + "__FareDetail_ExchangeRate";
            var ExchangeRate = "PNRDetails[0].PassengerDetail[" + generateId.toString() + "].FareDetail.ExchangeRate";

            var baseFareId = "PNRDetails_0__PassengerDetail_" + generateId.toString() + "__FareDetail_SellingBaseFare";
            var baseFare = "PNRDetails[0].PassengerDetail[" + generateId.toString() + "].FareDetail.SellingBaseFare";

            var pbaseFareId = "PNRDetails_0__PassengerDetail_" + generateId.toString() + "__FareDetail_BaseFare";
            var pbaseFare = "PNRDetails[0].PassengerDetail[" + generateId.toString() + "].FareDetail.BaseFare";

            var fscId = "PNRDetails_0__PassengerDetail_" + generateId.toString() + "__FareDetail_SellingFSC";
            var fsc = "PNRDetails[0].PassengerDetail[" + generateId.toString() + "].FareDetail.SellingFSC";

            var pfscId = "PNRDetails_0__PassengerDetail_" + generateId.toString() + "__FareDetail_FSC";
            var pfsc = "PNRDetails[0].PassengerDetail[" + generateId.toString() + "].FareDetail.FSC";


            var taxId = "PNRDetails_0__PassengerDetail_" + generateId.toString() + "__FareDetail_SellingTax";
            var tax = "PNRDetails[0].PassengerDetail[" + generateId.toString() + "].FareDetail.SellingTax";

            var ptaxId = "PNRDetails_0__PassengerDetail_" + generateId.toString() + "__FareDetail_Tax";
            var ptax = "PNRDetails[0].PassengerDetail[" + generateId.toString() + "].FareDetail.Tax";

            var addtxnId = "PNRDetails_0__PassengerDetail_" + generateId.toString() + "__FareDetail_SellingAdditionalTxnFee";
            var addtxn = "PNRDetails[0].PassengerDetail[" + generateId.toString() + "].FareDetail.SellingAdditionalTxnFee";

            var airlinetranId = "PNRDetails_0__PassengerDetail_" + generateId.toString() + "__FareDetail_SellingAirlineTransFee";
            var airlinetran = "PNRDetails[0].PassengerDetail[" + generateId.toString() + "].FareDetail.SellingAirlineTransFee";

            var serviceTaxId = "PNRDetails_0__PassengerDetail_" + generateId.toString() + "__FareDetail_ServiceTax";
            var serviceTax = "PNRDetails[0].PassengerDetail[" + generateId.toString() + "].FareDetail.ServiceTax";

            var otherchargesId = "PNRDetails_0__PassengerDetail_" + generateId.toString() + "__FareDetail_OtherCharges";
            var othercharge = "PNRDetails[0].PassengerDetail[" + generateId.toString() + "].FareDetail.OtherCharges";

            var markupId = "PNRDetails_0__PassengerDetail_" + generateId.toString() + "__FareDetail_MarkupAmount";
            var markup = "PNRDetails[0].PassengerDetail[" + generateId.toString() + "].FareDetail.MarkupAmount";

            var discountId = "PNRDetails_0__PassengerDetail_" + generateId.toString() + "__FareDetail_DiscountAmount";
            var discount = "PNRDetails[0].PassengerDetail[" + generateId.toString() + "].FareDetail.DiscountAmount";

            var commissionId = "PNRDetails_0__PassengerDetail_" + generateId.toString() + "__FareDetail_CommissionAmount";
            var commission = "PNRDetails[0].PassengerDetail[" + generateId.toString() + "].FareDetail.CommissionAmount";

            var ticketId = "PNRDetails_0__PassengerDetail_" + generateId.toString() + "__FareDetail_TicketNumber";
            var ticket = "PNRDetails[0].PassengerDetail[" + generateId.toString() + "].FareDetail.TicketNumber";


            var item = $(".Fare0:first").clone(true);

            $.each(item, function (index, element) {
                $(this).attr({ id: "Fare_" + generateId.toString() });
            });


            $("#PNRDetails_FareDetail00_Index", item).attr({ id: 'PNRDetails_FareDetail_Index', value: generateId.toString() });

            $("#PNRDetails_0__PassengerDetail_0__FareDetail_FarePaxType", item).attr({ id: FarepaxTypeId, name: FarepaxType });
            $("#PNRDetails_0__PassengerDetail_0__FareDetail_Currency", item).attr({ id: currencyId, name: currency });
            $("#PNRDetails_0__PassengerDetail_0__FareDetail_ExchangeRate", item).attr({ id: ExchangeRateId, name: ExchangeRate });
            $("#PNRDetails_0__PassengerDetail_0__FareDetail_BaseFare", item).val('');
            $("#PNRDetails_0__PassengerDetail_0__FareDetail_BaseFare", item).attr({ id: pbaseFareId, name: pbaseFare });
            $("#PNRDetails_0__PassengerDetail_0__FareDetail_SellingBaseFare", item).val('');
            $("#PNRDetails_0__PassengerDetail_0__FareDetail_SellingBaseFare", item).attr({ id: baseFareId, name: baseFare });
            $("#PNRDetails_0__PassengerDetail_0__FareDetail_SellingFSC", item).attr({ id: fscId, name: fsc });
            $("#PNRDetails_0__PassengerDetail_0__FareDetail_FSC", item).attr({ id: pfscId, name: pfsc });
            $("#PNRDetails_0__PassengerDetail_0__FareDetail_Tax", item).val('');
            $("#PNRDetails_0__PassengerDetail_0__FareDetail_Tax", item).attr({ id: ptaxId, name: ptax });
            $("#PNRDetails_0__PassengerDetail_0__FareDetail_SellingTax", item).val('');
            $("#PNRDetails_0__PassengerDetail_0__FareDetail_SellingTax", item).attr({ id: taxId, name: tax });
            $("#PNRDetails_0__PassengerDetail_0__FareDetail_SellingAdditionalTxnFee", item).attr({ id: addtxnId, name: addtxn });
            $("#PNRDetails_0__PassengerDetail_0__FareDetail_SellingAirlineTransFee", item).attr({ id: airlinetranId, name: airlinetran });
            $("#PNRDetails_0__PassengerDetail_0__FareDetail_ServiceTax", item).attr({ id: serviceTaxId, name: serviceTax });
            $("#PNRDetails_0__PassengerDetail_0__FareDetail_OtherCharges", item).attr({ id: otherchargesId, name: othercharge });
            $("#PNRDetails_0__PassengerDetail_0__FareDetail_MarkupAmount", item).attr({ id: markupId, name: markup });
            $("#PNRDetails_0__PassengerDetail_0__FareDetail_DiscountAmount", item).attr({ id: discountId, name: discount });
            $("#PNRDetails_0__PassengerDetail_0__FareDetail_CommissionAmount", item).attr({ id: commissionId, name: commission });
            $("#PNRDetails_0__PassengerDetail_0__FareDetail_TicketNumber", item).attr({ id: ticketId, name: ticket });

            $("#Cancel_Fare0", item).css({ "display": "block" });
            $("#Cancel_Fare0", item).attr({ id: 'Cancel_Fare' + generateId.toString(), rel: generateId.toString() });

            item.insertBefore("#AddFare0");
        });
    </script>
    <%--  Segment 0--%>
    <script type="text/javascript">
        $("#AddSegment0").live("click", function () {
            var generateId = ++segLastId;

            var deptCityId = "PNRDetails_0__SegmentDetail_" + generateId.toString() + "__DepartCityId";
            var deptCity = "PNRDetails[0].SegmentDetail[" + generateId.toString() + "].DepartCityId";

            var deptTimeId = "PNRDetails_0__SegmentDetail_" + generateId.toString() + "__DepartTime";
            var deptTime = "PNRDetails[0].SegmentDetail[" + generateId.toString() + "].DepartTime";

            var arriveTimeId = "PNRDetails_0__SegmentDetail_" + generateId.toString() + "__ArrivalTime";
            var arriveTime = "PNRDetails[0].SegmentDetail[" + generateId.toString() + "].ArrivalTime";

            var arriveCityId = "PNRDetails_0__SegmentDetail_" + generateId.toString() + "__ArrivalCityId";
            var arriveCity = "PNRDetails[0].SegmentDetail[" + generateId.toString() + "].ArrivalCityId";

            var deptDateId = "PNRDetails_0__SegmentDetail_" + generateId.toString() + "__DepartDate";
            var deptDate = "PNRDetails[0].SegmentDetail[" + generateId.toString() + "].DepartDate";

            var arriveDateId = "PNRDetails_0__SegmentDetail_" + generateId.toString() + "__ArrivalDate";
            var arriveDate = "PNRDetails[0].SegmentDetail[" + generateId.toString() + "].ArrivalDate";

            var bicId = "PNRDetails_0__SegmentDetail_" + generateId.toString() + "__BIC";
            var bic = "PNRDetails[0].SegmentDetail[" + generateId.toString() + "].BIC";

            var segairlineId = "PNRDetails_0__SegmentDetail_" + generateId.toString() + "__AirlineId";
            var segairline = "PNRDetails[0].SegmentDetail[" + generateId.toString() + "].AirlineId";

            var baggageId = "PNRDetails_0__SegmentDetail_" + generateId.toString() + "__Baggage";
            var baggage = "PNRDetails[0].SegmentDetail[" + generateId.toString() + "].Baggage";

            var segairlineNoId = "PNRDetails_0__SegmentDetail_" + generateId.toString() + "__FlightNumber";
            var segairlineNo = "PNRDetails[0].SegmentDetail[" + generateId.toString() + "].FlightNumber";


            var segairlinePnrId = "PNRDetails_0__SegmentDetail_" + generateId.toString() + "__AirlineRefNumber";
            var segairlinePnr = "PNRDetails[0].SegmentDetail[" + generateId.toString() + "].AirlineRefNumber";

            var segDurationId = "PNRDetails_0__SegmentDetail_" + generateId.toString() + "__Duration";
            var segDuration = "PNRDetails[0].SegmentDetail[" + generateId.toString() + "].Duration";

            var item = $(".Segment0:first").clone(true);

            $.each(item, function (index, element) {
                $(this).attr({ id: "Segment_" + generateId.toString() });
            });

            $("#PNRDetails_SegmentDetail00_Index", item).attr({ id: 'PNRDetails_SegmentDetail00_Index', value: generateId.toString() });

            $("#PNRDetails_0__SegmentDetail_0__DepartCityId", item).val('');
            $("#PNRDetails_0__SegmentDetail_0__DepartCityId", item).attr({ id: deptCityId, name: deptCity });
            $("#PNRDetails_0__SegmentDetail_0__ArrivalCityId", item).val('');
            $("#PNRDetails_0__SegmentDetail_0__ArrivalCityId", item).attr({ id: arriveCityId, name: arriveCity });
            $("#PNRDetails_0__SegmentDetail_0__DepartDate", item).attr({ id: deptDateId, name: deptDate });
            $("#PNRDetails_0__SegmentDetail_0__DepartTime", item).attr({ id: deptTimeId, name: deptTime });
            $("#PNRDetails_0__SegmentDetail_0__ArrivalDate", item).attr({ id: arriveDateId, name: arriveDate });
            $("#PNRDetails_0__SegmentDetail_0__ArrivalTime", item).attr({ id: arriveTimeId, name: arriveTime });
            $("#PNRDetails_0__SegmentDetail_0__BIC", item).attr({ id: bicId, name: bic });
            $("#PNRDetails_0__SegmentDetail_0__AirlineId", item).attr({ id: segairlineId, name: segairline });
            $("#PNRDetails_0__SegmentDetail_0__FlightNumber", item).attr({ id: segairlineNoId, name: segairlineNo });
            $("#PNRDetails_0__SegmentDetail_0__Baggage", item).attr({ id: baggageId, name: baggage });

            $("#PNRDetails_0__SegmentDetail_0__AirlineRefNumber", item).attr({ id: segairlinePnrId, name: segairlinePnr });
            $("#PNRDetails_0__SegmentDetail_0__Duration", item).attr({ id: segDurationId, name: segDuration });

            $("#Cancel_Seg0", item).css({ "display": "block" });
            $("#Cancel_Seg0", item).attr({ id: 'Cancel_Seg' + generateId.toString(), rel: generateId.toString() });

            item.insertBefore("#AddSegment0");
        });


    </script>
    <%-- Passenger RoundTrip 1--%>
    <script type="text/javascript">
        $("#AddPassenger1").live("click", function () {
            var generateId = ++paxLastId;

            var paxTypeId = "PNRDetails_1__PassengerDetail_" + generateId.toString() + "__PaxType";
            var paxType = "PNRDetails[1].PassengerDetail[" + generateId.toString() + "].PaxType";

            var prefixId = "PNRDetails_1__PassengerDetail_" + generateId.toString() + "__Prefix";
            var prefix = "PNRDetails[1].PassengerDetail[" + generateId.toString() + "].Prefix";

            var firstNameId = "PNRDetails_1__PassengerDetail_" + generateId.toString() + "__FirstName";
            var firstName = "PNRDetails[1].PassengerDetail[" + generateId.toString() + "].FirstName";

            var lastNameId = "PNRDetails_1__PassengerDetail_" + generateId.toString() + "__LastName";
            var lastName = "PNRDetails[1].PassengerDetail[" + generateId.toString() + "].LastName";

            var phoneId = "PNRDetails_1__PassengerDetail_" + generateId.toString() + "__Phone";
            var phone = "PNRDetails[1].PassengerDetail[" + generateId.toString() + "].Phone";

            var dobId = "PNRDetails_1__PassengerDetail_" + generateId.toString() + "__DOB";
            var dob = "PNRDetails[1].PassengerDetail[" + generateId.toString() + "].DOB";

            var passportnumberId = "PNRDetails_1__PassengerDetail_" + generateId.toString() + "__PassportNumber";
            var passportnumberName = "PNRDetails[1].PassengerDetail[" + generateId.toString() + "].PassportNumber";

            var passportIssuedCountryId = "PNRDetails_1__PassengerDetail_" + generateId.toString() + "__PassportIssuedCountryId";
            var passportIssuedCountry = "PNRDetails[1].PassengerDetail[" + generateId.toString() + "].PassportIssuedCountryId";

            var passportIssuedDateId = "PNRDetails_1__PassengerDetail_" + generateId.toString() + "__PassportIssuedDate";
            var passportIssuedDate = "PNRDetails[1].PassengerDetail[" + generateId.toString() + "].PassportIssuedDate";

            var passportExpDateId = "PNRDetails_1__PassengerDetail_" + generateId.toString() + "__PassportExpDate";
            var passportExpDateName = "PNRDetails[1].PassengerDetail[" + generateId.toString() + "].PassportExpDate";

            var nationalityId = "PNRDetails_1__PassengerDetail_" + generateId.toString() + "__NationalityId";
            var nationalityName = "PNRDetails[1].PassengerDetail[" + generateId.toString() + "].NationalityId";


            var mealId = "PNRDetails_1__PassengerDetail_" + generateId.toString() + "__Meal";
            var meal = "PNRDetails[1].PassengerDetail[" + generateId.toString() + "].Meal";

            var seatId = "PNRDetails_1__PassengerDetail_" + generateId.toString() + "__Seat";
            var seat = "PNRDetails[1].PassengerDetail[" + generateId.toString() + "].Seat";

            var ffAirlineId = "PNRDetails_1__PassengerDetail_" + generateId.toString() + "__FrequentFlyerAirlineId";
            var ff = "PNRDetails[1].PassengerDetail[" + generateId.toString() + "].FrequentFlyerAirlineId";

            var ffNoId = "PNRDetails_1__PassengerDetail_" + generateId.toString() + "__FrequentFlyerNo";
            var ffno = "PNRDetails[1].PassengerDetail[" + generateId.toString() + "].FrequentFlyerNo";

            var currencyId = "PNRDetails_1__PassengerDetail_" + generateId.toString() + "__FareDetail_Currency";
            var currency = "PNRDetails[1].PassengerDetail[" + generateId.toString() + "].FareDetail.Currency";

            var baseFareId = "PNRDetails_1__PassengerDetail_" + generateId.toString() + "__FareDetail_SellingBaseFare";
            var baseFare = "PNRDetails[1].PassengerDetail[" + generateId.toString() + "].FareDetail.SellingBaseFare";

            var fscId = "PNRDetails_1__PassengerDetail_" + generateId.toString() + "__FareDetail_SellingFSC";
            var fsc = "PNRDetails[1].PassengerDetail[" + generateId.toString() + "].FareDetail.SellingFSC";

            var taxId = "PNRDetails_1__PassengerDetail_" + generateId.toString() + "__FareDetail_SellingTax";
            var tax = "PNRDetails[1].PassengerDetail[" + generateId.toString() + "].FareDetail.SellingTax";

            var addtxnId = "PNRDetails_1__PassengerDetail_" + generateId.toString() + "__FareDetail_SellingAdditionalTxnFee";
            var addtxn = "PNRDetails[1].PassengerDetail[" + generateId.toString() + "].FareDetail.SellingAdditionalTxnFee";

            var airlinetranId = "PNRDetails_1__PassengerDetail_" + generateId.toString() + "__FareDetail_SellingAirlineTransFee";
            var airlinetran = "PNRDetails[1].PassengerDetail[" + generateId.toString() + "].FareDetail.SellingAirlineTransFee";

            var serviceTaxId = "PNRDetails_1__PassengerDetail_" + generateId.toString() + "__FareDetail_ServiceTax";
            var serviceTax = "PNRDetails[1].PassengerDetail[" + generateId.toString() + "].FareDetail.ServiceTax";

            var otherchargesId = "PNRDetails_1__PassengerDetail_" + generateId.toString() + "__FareDetail_OtherCharges";
            var othercharge = "PNRDetails[1].PassengerDetail[" + generateId.toString() + "].FareDetail.OtherCharges";

            var markupId = "PNRDetails_1__PassengerDetail_" + generateId.toString() + "__FareDetail_MarkupAmount";
            var markup = "PNRDetails[1].PassengerDetail[" + generateId.toString() + "].FareDetail.MarkupAmount";

            var discountId = "PNRDetails_1__PassengerDetail_" + generateId.toString() + "__FareDetail_DiscountAmount";
            var discount = "PNRDetails[1].PassengerDetail[" + generateId.toString() + "].FareDetail.DiscountAmount";

            var commissionId = "PNRDetails_1__PassengerDetail_" + generateId.toString() + "__FareDetail_CommissionAmount";
            var commission = "PNRDetails[1].PassengerDetail[" + generateId.toString() + "].FareDetail.CommissionAmount";

            var ticketId = "PNRDetails_1__PassengerDetail_" + generateId.toString() + "__FareDetail_TicketNumber";
            var ticket = "PNRDetails[1].PassengerDetail[" + generateId.toString() + "].FareDetail.TicketNumber";


            var item = $(".Passenger1:first").clone(true);

            $.each(item, function (index, element) {
                $(this).attr({ id: "Passenger_" + generateId.toString() });
            });

            $("#PNRDetails_10_Index", item).attr({ id: 'PNRDetails_10_Index', value: generateId.toString() });

            $("#PNRDetails_1__PassengerDetail_0__PaxType", item).attr({ id: paxTypeId, name: paxType });
            $("#PNRDetails_1__PassengerDetail_0__Prefix", item).attr({ id: prefixId, name: prefix });
            $("#PNRDetails_1__PassengerDetail_0__FirstName", item).attr({ id: firstNameId, name: firstName });
            $("#PNRDetails_1__PassengerDetail_0__LastName", item).attr({ id: lastNameId, name: lastName });
            $("#PNRDetails_1__PassengerDetail_0__Phone", item).attr({ id: phoneId, name: phone }).removeAttr('class'); ;
            $("#PNRDetails_1__PassengerDetail_0__DOB", item).attr({ id: dobId, name: dob });

            $("#PNRDetails_1__PassengerDetail_0__PassportNumber", item).attr({ id: passportnumberId, name: passportnumberName });
            $("#PNRDetails_1__PassengerDetail_0__PassportIssuedCountryId", item).attr({ id: passportIssuedCountryId, name: passportIssuedCountry });
            $("#PNRDetails_1__PassengerDetail_0__PassportIssuedDate", item).attr({ id: passportIssuedDateId, name: passportIssuedDate });
            $("#PNRDetails_1__PassengerDetail_0__PassportExpDate", item).attr({ id: passportExpDateId, name: passportExpDateName });
            $("#PNRDetails_1__PassengerDetail_0__NationalityId", item).attr({ id: nationalityId, name: nationalityName });

            $("#PNRDetails_1__PassengerDetail_0__Meal", item).attr({ id: mealId, name: meal });
            $("#PNRDetails_1__PassengerDetail_0__Seat", item).attr({ id: seatId, name: seat });
            $("#PNRDetails_1__PassengerDetail_0__FrequentFlyerAirlineId", item).attr({ id: ffAirlineId, name: ff });
            $("#PNRDetails_1__PassengerDetail_0__FrequentFlyerNo", item).attr({ id: ffNoId, name: ffno });

            $("#PNRDetails_1__PassengerDetail_0__FareDetail_Currency", item).attr({ id: currencyId, name: currency });
            $("#PNRDetails_1__PassengerDetail_0__FareDetail_SellingBaseFare", item).attr({ id: baseFareId, name: baseFare });
            $("#PNRDetails_1__PassengerDetail_0__FareDetail_SellingFSC", item).attr({ id: fscId, name: fsc });
            $("#PNRDetails_1__PassengerDetail_0__FareDetail_SellingTax", item).attr({ id: taxId, name: tax });
            $("#PNRDetails_1__PassengerDetail_0__FareDetail_SellingAdditionalTxnFee", item).attr({ id: addtxnId, name: addtxn });
            $("#PNRDetails_1__PassengerDetail_0__FareDetail_SellingAirlineTransFee", item).attr({ id: airlinetranId, name: airlinetran });
            $("#PNRDetails_1__PassengerDetail_0__FareDetail_ServiceTax", item).attr({ id: serviceTaxId, name: serviceTax });
            $("#PNRDetails_1__PassengerDetail_0__FareDetail_OtherCharges", item).attr({ id: otherchargesId, name: othercharge });
            $("#PNRDetails_1__PassengerDetail_0__FareDetail_MarkupAmount", item).attr({ id: markupId, name: markup });
            $("#PNRDetails_1__PassengerDetail_0__FareDetail_DiscountAmount", item).attr({ id: discountId, name: discount });
            $("#PNRDetails_1__PassengerDetail_0__FareDetail_CommissionAmount", item).attr({ id: commissionId, name: commission });
            $("#PNRDetails_1__PassengerDetail_0__FareDetail_TicketNumber", item).attr({ id: ticketId, name: ticket });

            $("#Cancel_0", item).css({ "display": "block" });
            $("#Cancel_0", item).attr({ id: 'Cancel_' + generateId.toString(), rel: generateId.toString() });

            item.insertBefore("#AddPassenger1");

        });
        
    </script>
    <%-- Segment RoundTrip 1--%>
    <script type="text/javascript">

        $("#AddSegment1").live("click", function () {
            var generateId = ++segLastId;

            var deptCityId = "PNRDetails_1__SegmentDetail_" + generateId.toString() + "__DepartCityId";
            var deptCity = "PNRDetails[1].SegmentDetail[" + generateId.toString() + "].DepartCityId";


            var deptTimeId = "PNRDetails_1__SegmentDetail_" + generateId.toString() + "__DepartTime";
            var deptTime = "PNRDetails[1].SegmentDetail[" + generateId.toString() + "].DepartTime";

            var arriveTimeId = "PNRDetails_1__SegmentDetail_" + generateId.toString() + "__ArrivalTime";
            var arriveTime = "PNRDetails[1].SegmentDetail[" + generateId.toString() + "].ArrivalTime";

            var arriveCityId = "PNRDetails_1__SegmentDetail_" + generateId.toString() + "__ArrivalCityId";
            var arriveCity = "PNRDetails[1].SegmentDetail[" + generateId.toString() + "].ArrivalCityId";

            var deptDateId = "PNRDetails_1__SegmentDetail_" + generateId.toString() + "__DepartDate";
            var deptDate = "PNRDetails[1].SegmentDetail[" + generateId.toString() + "].DepartDate";

            var arriveDateId = "PNRDetails_1__SegmentDetail_" + generateId.toString() + "__ArrivalDate";
            var arriveDate = "PNRDetails[1].SegmentDetail[" + generateId.toString() + "].ArrivalDate";

            var bicId = "PNRDetails_1__SegmentDetail_" + generateId.toString() + "__BIC";
            var bic = "PNRDetails[1].SegmentDetail[" + generateId.toString() + "].BIC";

            var segairlineId = "PNRDetails_1__SegmentDetail_" + generateId.toString() + "__AirlineId";
            var segairline = "PNRDetails[1].SegmentDetail[" + generateId.toString() + "].AirlineId";

            var segairlineNoId = "PNRDetails_1__SegmentDetail_" + generateId.toString() + "__FlightNumber";
            var segairlineNo = "PNRDetails[1].SegmentDetail[" + generateId.toString() + "].FlightNumber";


            var segairlinePnrId = "PNRDetails_1__SegmentDetail_" + generateId.toString() + "__AirlineRefNumber";
            var segairlinePnr = "PNRDetails[1].SegmentDetail[" + generateId.toString() + "].AirlineRefNumber";


            var segDurationId = "PNRDetails_1__SegmentDetail_" + generateId.toString() + "__Duration";
            var segDuration = "PNRDetails[1].SegmentDetail[" + generateId.toString() + "].Duration";

            var item = $(".Segment1:first").clone(true);
            $.each(item, function (index, element) {
                $(this).attr({ id: "Segment_" + generateId.toString() });
            });

            $("#PNRDetails_SegmentDetail10_Index", item).attr({ id: 'PNRDetails_SegmentDetail10_Index', value: generateId.toString() });
            $("#PNRDetails_1__SegmentDetail_0__DepartCityId", item).attr({ id: deptCityId, name: deptCity });
            $("#PNRDetails_1__SegmentDetail_0__ArrivalCityId", item).attr({ id: arriveCityId, name: arriveCity });
            $("#PNRDetails_1__SegmentDetail_0__DepartDate", item).attr({ id: deptDateId, name: deptDate });
            $("#PNRDetails_1__SegmentDetail_0__DepartTime", item).attr({ id: deptTimeId, name: deptTime });
            $("#PNRDetails_1__SegmentDetail_0__ArrivalDate", item).attr({ id: arriveDateId, name: arriveDate });
            $("#PNRDetails_1__SegmentDetail_0__ArrivalTime", item).attr({ id: arriveTimeId, name: arriveTime });
            $("#PNRDetails_1__SegmentDetail_0__BIC", item).attr({ id: bicId, name: bic });
            $("#PNRDetails_1__SegmentDetail_0__AirlineId", item).attr({ id: segairlineId, name: segairline });
            $("#PNRDetails_1__SegmentDetail_0__FlightNumber", item).attr({ id: segairlineNoId, name: segairlineNo });
            $("#PNRDetails_1__SegmentDetail_0__AirlineRefNumber", item).attr({ id: segairlinePnrId, name: segairlinePnr });
            $("#PNRDetails_1__SegmentDetail_0__Duration", item).attr({ id: segDurationId, name: segDuration });

            $("#Cancel_Seg0", item).css({ "display": "block" });
            $("#Cancel_Seg0", item).attr({ id: 'Cancel_Seg' + generateId.toString(), rel: generateId.toString() });

            item.insertBefore("#AddSegment1");
        });

    </script>
</asp:Content>
