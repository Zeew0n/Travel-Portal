<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<ATLTravelPortal.Areas.Airline.Models.OffLineBookViewModel.OfflineBookViewModel>" %>


    <div class="pageTitle">
   
    </div>
   
    <% if(Model.PNRDetails.Count > 0) %>
    <% using (Html.BeginForm("Create", "IndianLccAirOfflineBook", FormMethod.Post, new { @id = "bookingForm", @class = "validate", @onsubmit = "return false;" }))
       { %>
       <p style="float:right; background:red; color:#fff; padding:0px 5px; font-size:20px;">Fare should be in NPR</p>
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
                Booking Detail<%:i + 1%></h2>
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
                                Title</label>
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
                                Surname</label>
                            <%:Html.TextBoxFor(model => model.PNRDetails[i].PassengerDetail[j].LastName,
                                                    new {@class = "required"})%>
                        </li>
                        <li>
                            <label>
                                Mobile</label>
                            <%:Html.TextBoxFor(model => model.PNRDetails[i].PassengerDetail[j].Phone, new {@class = "required number"})%>
                        </li>
                        <li>
                            <label>
                                Date of Birth</label>
                            <%:Html.TextBoxFor(model => model.PNRDetails[i].PassengerDetail[j].DOB,
                                                                                          new { @class = "birthDate", @Value = " " })%>
                        </li>
                    </ul>
                    <hr />
                    <ul class="detailsGrid clearfix">
                        <li>
                            <label>
                                Passport No</label>
                            <%:Html.TextBoxFor(model => model.PNRDetails[i].PassengerDetail[j].PassportNumber)%>
                        </li>
                        <li>
                            <label>
                                Passport Issued Country</label>
                            <%:Html.DropDownListFor(model => model.PNRDetails[i].PassengerDetail[j].PassportIssuedCountryId, Model.SelectListCollection.CountryList,"--Select--")%>
                        </li>
                        <li>
                            <label>
                                Passport Issued Date</label>
                            <%:Html.TextBoxFor(model => model.PNRDetails[i].PassengerDetail[j].PassportIssuedDate, new {@class = "DOB", @Value = " "})%>
                        </li>
                        <li>
                            <label>
                                Passport Expiry</label>
                            <%:Html.TextBoxFor(model => model.PNRDetails[i].PassengerDetail[j].PassportExpDate,
                                                    new {@class = "passportExpire", @Value = " "})%>
                        </li>
                        <li>
                            <label>
                                Nationality</label>
                            <%:Html.DropDownListFor(model => model.PNRDetails[i].PassengerDetail[j].NationalityId,
                                                         Model.SelectListCollection.NationalityList,"--Select--")%>
                        </li>
                      
                    </ul>
                    <div class="adsInfo">
                        <h4 id="ssr_Adult_0" class="addSSRInfo">
                            Add Frequent Flyer and Meal Preference</h4>
                        <div style="" id="div_ssr_Adult_0" class="inpDtls">
                            <ul class="detailsGrid clearfix">
                                <li>
                                    <label>
                                        Meal</label>
                                    <%:Html.DropDownListFor(model => model.PNRDetails[i].PassengerDetail[j].Meal.Code,
                                                         Model.SelectListCollection.MealList,"--Select")%>
                                </li>
                                <li>
                                    <label>
                                        Seat</label>
                                    <%:Html.DropDownListFor(model => model.PNRDetails[i].PassengerDetail[j].Seat.Code,
                                                         Model.SelectListCollection.SeatList,"--Select--")%>
                                </li>
                                <li>
                                    <label>
                                        FrequentFlyer Airline</label>
                                    <%:Html.DropDownListFor(model => model.PNRDetails[i].PassengerDetail[j].FrequentFlyerAirlineId, Model.SelectListCollection.AirlineList,"--Select--")%>
                                    <%:Html.HiddenFor(model=>model.PNRDetails[i].PassengerDetail[j].FrequentFlyerAirlineId) %>
                                </li>
                                <li>
                                    <label>
                                        FrequentFlyer No</label>
                                    <%: Html.TextBoxFor(model => model.PNRDetails[i].PassengerDetail[j].FrequentFlyerNo)%>
                                </li>
                            </ul>
                        </div>
                    </div>
                    <br />
                    <div class="adsInfo">
                        <h4 id="H1" class="addSSRInfo">
                            Fare Details</h4>
                        <div style="" id="div1" class="inpDtls">
                            <ul class="detailsGrid clearfix">
                                <li>
                                    <label>
                                        Base Fare</label>
                                    <%: Html.TextBoxFor(model => model.PNRDetails[i].PassengerDetail[j].FareDetail.SellingBaseFare, new { @class = "required number", @Value = "" })%>
                                </li>
                                <li>
                                    <label>
                                        Taxes</label>
                                    <%: Html.TextBoxFor(model => model.PNRDetails[i].PassengerDetail[j].FareDetail.SellingTax, new { @class = "required number ", @Value = ""})%>
                                </li>
                                <li>
                                    <label>
                                        Fuel Surcharge</label>
                                    <%: Html.TextBoxFor(model => model.PNRDetails[i].PassengerDetail[j].FareDetail.SellingFSC, new {@class = " number", @Value = ""})%>
                                </li>
                                <li>
                                    <label>
                                        Other Charges</label>
                                    <%: Html.TextBoxFor(model => model.PNRDetails[i].PassengerDetail[j].FareDetail.SellingOtherCharges, new { @class = " number", @Value = "" })%>
                                </li>
                                <li>
                                    <label>
                                        Commission</label>
                                    <%: Html.TextBoxFor(model => model.PNRDetails[i].PassengerDetail[j].FareDetail.CommissionAmount, new { @class = " number", @Value = "" })%>
                                </li>
                                <li>
                                    <label>
                                        Service Tax</label>
                                    <%: Html.TextBoxFor(model => model.PNRDetails[i].PassengerDetail[j].FareDetail.SellingServiceTax, new { @class = " number", @Value = "" })%>
                                </li>
                        <%--        <li>
                                    <label>
                                        Agent Service Charge</label>
                                    <%: Html.TextBoxFor(model => model.PNRDetails[i].PassengerDetail[j].FareDetail.AgentServiceCharge, new { @class = " number", @Value = "" })%>
                                </li>--%>
                                <li>
                                    <label>
                                        Ticket No</label>
                                    <%: Html.TextBoxFor(model => model.PNRDetails[i].PassengerDetail[j].FareDetail.TicketNumber, new { @class = "required",  @Value = "" })%>
                                </li>
                            </ul>
                        </div>
                    </div>
                    <a href="javascript:voide(0)" id="Cancel_<%=j %>" rel="<%=j %>" class="delete" style="display: none;
                        float: left;">Delete Pax</a>
                </div>
            </div>
            <%   }%>
            <input type="button" id="AddPassenger<%=i %>" value="Add Passenger" style="float: right; text-transform:capitalize;" />
            <br />
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
                </div></div>
                 <div class="form-box1-row">
               <div class="form-box1-row-content float-left">
                 <h3>
                    GDS PNR</h3>
                <ul class="detailsGrid clearfix">
                    <li>
                        <label>
                            Booking Source
                        </label>
                        <%--<%:Html.DropDownListFor(model => model.PNRDetails[i].BookingSource,Model.BookingBourceList,"----------select-----------", new {@class = "required"})%>--%>
                        <%:Html.DropDownListFor(model => model.PNRDetails[i].BookingSource,Model.BookingBourceList,"----------select-----------")%>
                    </li>
                </ul>
                                </div></div>
            </div>
      
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
                <a href="javascript:voide(0)" id="Cancel_Seg<%=k %>" rel="<%=k %>" class="deleteSegment" style="display: none;
                    float: left;">Delete Segment</a>
            </div>
            <input type="button" id="AddSegment<%=i %>" value="Add Segment" style="float: right; text-transform:capitalize;" />
            <br />
            <% } %>
        </div>
        <% }
       
        %>
        <br />
     

         <p>
                <input type="submit" value="Create" onclick="submitBookingForm(this.form,'ContentBookingFormPanel')"  style=" text-transform:capitalize;"/>
            </p>
       
       

        <% } %>
    </div>



