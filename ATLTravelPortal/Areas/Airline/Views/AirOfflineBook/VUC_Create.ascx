<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<ATLTravelPortal.Areas.Airline.Models.OffLineBookViewModel.OfflineBookViewModel>" %>
<div class="pageTitle">
</div>
<% if (Model.PNRDetails.Count > 0) %>
<% using (Html.BeginForm("Create", "AirOfflineBook", FormMethod.Post, new { @id = "bookingForm", @class = "validate", @onsubmit = "return false;" }))
   { %>
<label>
    Agent</label>
<%: Html.TextBoxFor(model => model.UserDetail.AgentName, new { @class = "required agentAutoComplete", @style="width:200px;" })%>
<%: Html.HiddenFor(model=>model.UserDetail.AgentId) %>
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
            <%-- Booking Detail<%:i + 1%>--%>
            Booking Details
        </h2>
        <div class="passInfo clearfix">
            <div class="form-box1-row">
                <div class="form-box1-row-content float-left">
                    <h3>
                        GDS PNR</h3>
                    <ul class="detailsGrid clearfix">
                        <li>
                            <label>
                                GDS PNR
                            </label>
                            <%:Html.TextBoxFor(model => model.PNRDetails[i].PNR, new {@class = "required"})%>
                        </li>
                    </ul>
                </div>
            </div>
            <div class="form-box1-row">
                <div class="form-box1-row-content float-left">
                    <h3>
                        GDS PNR</h3>
                    <ul class="detailsGrid clearfix">
                        <li>
                            <label>
                                Booking Status
                            </label>
                            <%:Html.DropDownListFor(model => model.PNRDetails[i].BookingSource,Model.SelectListCollection.BookingSourceList)%>
                            <%:Html.ValidationMessageFor(model=>model.PNRDetails[i].BookingSource) %>
                        </li>
                    </ul>
                </div>
            </div>
        </div>
        <%  for (int j = 0; j < Model.PNRDetails[i].PassengerDetail.Count; j++)
            { %>
        <div class="Passenger<%=i%>" id="Passenger_<%=i%>">
            <input type="hidden" value="<%=j%>" name="PNRDetails[<%=i%>].PassengerDetail.Index"
                id="PNRDetails_<%=i%><%=j%>_Index" />
            <div class="passInfo clearfix">
                <h3>
                    Passenger Primary Detail</h3>
                <ul class="detailsGrid clearfix">
                    <li class="tltblk">
                        <label>
                            Pax Type</label>
                        <%:Html.DropDownListFor(model => model.PNRDetails[i].PassengerDetail[j].PaxType,
                                                         Model.SelectListCollection.PaxTypeList)%>
                    </li>
                    <li class="tltblk">
                        <label>
                            Prefix</label>
                        <%:Html.DropDownListFor(model => model.PNRDetails[i].PassengerDetail[j].Prefix,
                                                         Model.SelectListCollection.PrefixList)%>
                    </li>
                    <li>
                        <label>
                            First Name</label>
                        <%:Html.TextBoxFor(model => model.PNRDetails[i].PassengerDetail[j].FirstName,
                                                    new {@class = "required"})%>
                    </li>
                    <li>
                        <label>
                            Middle Name</label>
                        <%:Html.TextBoxFor(model => model.PNRDetails[i].PassengerDetail[j].MiddleName,
                                                    new {@class = "required"})%>
                    </li>
                    <li>
                        <label>
                            Last Name</label>
                        <%:Html.TextBoxFor(model => model.PNRDetails[i].PassengerDetail[j].LastName,
                                                    new {@class = "required"})%>
                    </li>
                </ul>
                <hr />
                <br />
                <a href="javascript:voide(0)" id="Cancel_<%=j %>" rel="<%=j %>" class="delete" style="display: none;
                    float: left;">Delete Pax</a>
            </div>
        </div>
        <%   }%>
        <input type="button" id="AddPassenger<%=i %>" value="Add Passenger" style="float: right;" />
        <br />
        <div id="Segment_<%=i %>" class="Segment<%=i %>">
            <div class="passInfo clearfix">
                <h3>
                    Segment Details</h3>
                <%
          for (int k = 0; k < Model.PNRDetails[i].SegmentDetail.Count; k++)
          {%>
                <input type="hidden" value="<%=k %>" name="PNRDetails[<%=i %>].SegmentDetail.Index"
                    id="PNRDetails_SegmentDetail<%=i %><%=k %>_Index" />
                <ul class="detailsGrid clearfix">
                    <li>
                        <label>
                            Depart City
                        </label>
                        <%:Html.DropDownListFor(model => model.PNRDetails[i].SegmentDetail[k].DepartCityId, Model.SelectListCollection.CityList)%>
                    </li>
                    <li>
                        <label>
                            Arrival City
                        </label>
                        <%:Html.DropDownListFor(model => model.PNRDetails[i].SegmentDetail[k].ArrivalCityId, Model.SelectListCollection.CityList.OrderByDescending(x=>x.Text))%>
                    </li>
                    <li>
                        <label>
                            Airline
                        </label>
                        <%:Html.DropDownListFor(model => model.PNRDetails[i].SegmentDetail[k].AirlineId, Model.SelectListCollection.AirlineList)%>
                    </li>
                    <li>
                        <label>
                            Airline PNR</label>
                        <%:Html.TextBoxFor(model => model.PNRDetails[i].SegmentDetail[k].AirlineRefNumber, new { @class = "required"})%>
                    </li>
                </ul>
                <ul class="detailsGrid clearfix">
                    <li>
                        <label>
                            Dept Date
                        </label>
                        <%: Html.TextBoxFor(model => model.PNRDetails[i].SegmentDetail[k].DepartDate, new { @class = "timepicker required", @Value = " "  })%>
                    </li>
                    <li>
                        <label>
                            DeptTime
                        </label>
                        <%: Html.TextBoxFor(model => model.PNRDetails[i].SegmentDetail[k].DepartTime, new { @class = "time required", @Value = " " })%>
                    </li>
                    <li>
                        <label>
                            Arrival Date
                        </label>
                        <%: Html.TextBoxFor(model => model.PNRDetails[i].SegmentDetail[k].ArrivalDate, new { @class = "timepicker required", @Value = " "  })%>
                    </li>
                    <li>
                        <label>
                            Arrival Time
                        </label>
                        <%: Html.TextBoxFor(model => model.PNRDetails[i].SegmentDetail[k].ArrivalTime, new { @class = "time required", @Value = " " })%>
                    </li>
                </ul>
                <ul class="detailsGrid clearfix">
                    <li>
                        <label>
                            Class</label>
                        <%:Html.DropDownListFor(model => model.PNRDetails[i].SegmentDetail[k].BIC, Model.SelectListCollection.BICList)%>
                    </li>
                    <li>
                        <label>
                            AirlineNo</label>
                        <%:Html.TextBoxFor(model => model.PNRDetails[i].SegmentDetail[k].FlightNumber, new { @class = "required"})%>
                    </li>
                    <li>
                        <label>
                            Flight Duration</label>
                        <%:Html.TextBoxFor(model => model.PNRDetails[i].SegmentDetail[k].Duration, new { @class = "time"})%>
                    </li>
                </ul>
            </div>
            <a href="javascript:voide(0)" id="Cancel_Seg<%=k %>" rel="<%=k %>" class="deleteSegment"
                style="display: none; float: left;">Delete Segment</a>
        </div>
        <input type="button" id="AddSegment<%=i %>" value="Add Segment" style="float: right;" />
        <br />
        <% } %>
        <br />
        <div id="Fare_<%=i %>" class="Fare<%=i %>">
            <div class="passInfo clearfix">
                <h3>
                    Fare Details</h3>
                <%  for (int j = 0; j < Model.PNRDetails[i].PassengerDetail.Count; j++)
                    { %>
                <input type="hidden" value="<%=j %>" name="PNRDetails[<%=i %>].FareDetail.Index"
                    id="PNRDetails_FareDetail<%=i %><%=j %>_Index" />
                <div style="" id="div1" class="inpDtls">
                    <ul class="detailsGrid clearfix">
                        <li>
                            <label>
                                Pax Type</label>
                            <%:Html.DropDownListFor(model => model.PNRDetails[i].PassengerDetail[j].FareDetail.FarePaxType,
                                                         Model.SelectListCollection.PaxTypeList)%>
                        </li>
                        <li>
                            <label>
                                Currency
                            </label>
                            <%:Html.DropDownListFor(model => model.PNRDetails[i].PassengerDetail[j].FareDetail.Currency, Model.SelectListCollection.CurrencyList)%>
                        </li>
                        <li>
                            <label>
                                Base Fare</label>
                            <%: Html.TextBoxFor(model => model.PNRDetails[i].PassengerDetail[j].FareDetail.SellingBaseFare, new { @class = "required number", @Value = "" })%>
                        </li>
                        <li>
                            <label>
                                YQ/FSC</label>
                            <%: Html.TextBoxFor(model => model.PNRDetails[i].PassengerDetail[j].FareDetail.SellingFSC, new { @class = " number", @Value = "" })%>
                        </li>
                        <li>
                            <label>
                                Tax</label>
                            <%: Html.TextBoxFor(model => model.PNRDetails[i].PassengerDetail[j].FareDetail.SellingTax, new { @class = "required number ", @Value = ""})%>
                        </li>
                        <li>
                            <label>
                                Add-Txn</label>
                            <%: Html.TextBoxFor(model => model.PNRDetails[i].PassengerDetail[j].FareDetail.SellingAdditionalTxnFee, new { @class = " number", @Value = "" })%>
                        </li>
                        <li>
                            <label>
                                Airline-Tran</label>
                            <%: Html.TextBoxFor(model => model.PNRDetails[i].PassengerDetail[j].FareDetail.SellingAirlineTransFee, new { @class = " number", @Value = "" })%>
                        </li>
                        <li>
                            <label>
                                Service Tax</label>
                            <%: Html.TextBoxFor(model => model.PNRDetails[i].PassengerDetail[j].FareDetail.ServiceTax, new { @class = " number", @Value = "" })%>
                        </li>
                        <li>
                            <label>
                                Other Charges</label>
                            <%: Html.TextBoxFor(model => model.PNRDetails[i].PassengerDetail[j].FareDetail.OtherCharges, new { @class = " number", @Value = "" })%>
                        </li>
                        <li>
                            <label>
                                Markup</label>
                            <%: Html.TextBoxFor(model => model.PNRDetails[i].PassengerDetail[j].FareDetail.MarkupAmount, new { @class = " number", @Value = "" })%>
                        </li>
                        <li>
                            <label>
                                Discount</label>
                            <%: Html.TextBoxFor(model => model.PNRDetails[i].PassengerDetail[j].FareDetail.DiscountAmount, new { @class = " number", @Value = "" })%>
                        </li>
                        <li>
                            <label>
                                Comm</label>
                            <%: Html.TextBoxFor(model => model.PNRDetails[i].PassengerDetail[j].FareDetail.CommissionAmount, new { @class = " number", @Value = "" })%>
                        </li>
                        <li>
                            <label>
                                Ticket No</label>
                            <%: Html.TextBoxFor(model => model.PNRDetails[i].PassengerDetail[j].FareDetail.TicketNumber, new { @class = "required",  @Value = "" })%>
                        </li>
                    </ul>
                </div>
                <a href="javascript:void(0)" id="Cancel_Fare<%=j %>" rel="<%=j %>" class="deleteFare"
                    style="display: none; float: left;">Delete Fare</a>
                <%   }%>
            </div>
        </div>
        <input type="button" id="AddFare<%=i %>" value="Add Fare" style="float: right;" />
        <% }
       
        %>
        <br />
        <p>
            <input type="submit"  id="Save" value="Create" onclick="submitBookingForm(this.form,'ContentBookingFormPanel')" />
        </p>
        <% } %>
    </div>
</div>
