<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<ATLTravelPortal.Areas.Hotel.Models.HotelBookingDetailModel>" %>
<% var TotalGuests = 0; %>
<%TimeSpan ts = Model.CheckOutDate - Model.CheckInDate;
  int days = ts.Days;
  decimal totalChargableAmount = 0;
%>
<div class="bookingSummary">
<div style="width: 600px;" class="float-left">
Agent Name: <%=Model.AgentDetail.AgentName %><br />
Agent Address: <%=Model.AgentDetail.Address %><br />
Agent Phone No: <%=Model.AgentDetail.Phone %>
</div>
    <div style="width: 600px;" class="float-left">
        <div style="width: 600px;" class="form-box1-row">
            <div style="width: 600px;" class="float-left">
                <div style="font-size: 14px; font-weight: bold;">
                    <label>
                        Ref No :
                    </label>
                    <label style="color: #FF7902;">
                        <%=Model.BookingRecordId +"#"+Model.BookingId+"#"+Model.ConfirmationNo+"#"+Model.ReferenceNo %></label>
                </div>
            </div>
        </div>
        <div style="width: 600px;" class="form-box1-row">
            <div class=" float-left">
                <div style="font-size: 12px; width: 250px;">
                    <label>
                        Check In Date :
                    </label>
                    <label style="color: #FF7902;">
                        <%=Model.CheckInDate.ToShortDateString() %></label>
                </div>
            </div>
            <div class=" float-left">
                <div style="font-size: 12px; width: 250px;">
                    <label>
                        Check Out Date :
                    </label>
                    <label style="color: #FF7902;">
                        <%=Model.CheckOutDate.ToShortDateString() %></label>
                </div>
            </div>
            <div class=" float-right">
                <div style="font-size: 12px;">
                    <label>
                        No Of Adult :
                    </label>
                    <label style="color: #FF7902;">
                     <%var NoOfAdult = 0; var NoOfChild = 0; foreach (var item in Model.RoomGuest)
                              {
                                  NoOfAdult += item.NoOfAdults;
                                  NoOfChild += item.NoOfChild;
                              }%>
                        <%=NoOfAdult%></label>
                </div>
            </div>
        </div>
        <div style="width: 600px;" class="form-box1-row">
            <div class="float-left">
                <div style="font-size: 12px; width: 250px;">
                    <label>
                        No of Room :
                    </label>
                    <label style="color: #FF7902;">
                        <%=Model.NoOfRooms%></label>
                </div>
            </div>
            <div class="float-left">
                <div style="font-size: 12px; width: 250px;">
                    <label>
                        Nights :
                    </label>
                    <label style="color: #FF7902;">
                        <%=days %></label>
                </div>
            </div>
            <div class=" float-right">
                <div style="font-size: 12px;">
                    <label>
                        No Of Child :
                    </label>
                    <label style="color: #FF7902;">
                        <%=NoOfChild%></label>
                </div>
            </div>
        </div>
    </div>
</div>
<div class="bookingLabel">
    <div style="width: 68%; float: left;">
        <h3 class="headingTlt" onclick="javascript:ToggleDiv('HotelDetail')" style="cursor: pointer;">
            <span id="SignHotelDetail" style="font-size: 14px;">-</span> Hotel Details</h3>
        <div id="HotelDetail" class="float-left" style="width: 97.5%; border: 1px solid #ccc;
            padding: 1%;">
            <div class="form-box1-row" style="width: 99%;">
                <div class="float-left" style="width: 99%;">
                    <div class="hotelSummaryBox" style="border: none;">
                        <div class="hotelIntroWrap">
                            <div class="hotelImg" style="margin-left: 0px; width: 76px;">
                                <img width="70" height="70" title="<%:Html.Encode(Model.HotelName) %>" alt="<%:Html.Encode(Model.HotelName) %>"
                                    src=" <%=Model.HotelImageUrl%>" />
                            </div>
                            <div class="hotelIntro">
                                <div style="width: 99%;" class="hotelDetails">
                                    <h6>
                                        <%=Model.HotelName%></h6>
                                    <%=Model.HotelAddress%>
                                    <br />
                                    <%: Html.Encode(Model.CityName)%>,<%:Html.Encode(Model.CountryName)%><br />
                                    <span class="hotelReputation"><span class="<%=Model.HotelRating %>"></span></span>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="form-box1-row" style="width: 99%;">
                <div class=" float-left">
                    <div>
                        <label>
                            Check In Date :
                        </label>
                        <%:Html.Encode(Model.CheckInDate.ToString("MM/dd/yyyy"))%>
                    </div>
                </div>
                <div class=" float-right">
                    <div>
                        <label>
                            Check Out Date :
                        </label>
                        <%:Html.Encode(Model.CheckOutDate.ToString("MM/dd/yyyy"))%>
                    </div>
                </div>
            </div>
            <div class="form-box1-row" style="width: 99%px;">
                <div class="float-left">
                    <div>
                        <label>
                            No of Room :
                        </label>
                        <%:Html.Encode(Model.NoOfRooms)%>
                    </div>
                </div>
                <div class="float-right">
                    <div>
                        <label>
                            Nights :
                        </label>
                        <%:Html.Encode(days.ToString())%>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
<%--***************************************************************************--%>
<%--***************************************************************************--%>
<%int roomIndex = 0;  %>
<div class="fairDetail">
    <h3 class="headingTlt">
        Fare Details
    </h3>
    <%roomIndex = 0; foreach (var room in Model.RoomDetail)
      {
          roomIndex++; %>
    <div>
        Room:
        <%=roomIndex.ToString()%></div>
    <div class="form-box1-row-content float-right" style="width: 99%; border: 1px solid #ccc; margin-bottom:5px;">
        <div id="rateBreakUp">
            <label>
                Rate :</label>
            <label style="width: 80px;">
                <%:Html.Encode((room.RoomRate.TotalRoomRate + room.RoomRate.AgentServiceCharge + room.RoomRate.MarkupRatePerRoom).ToString("N2"))%></label><br />
            <label>
                Tax
            </label>
            <label style="width: 80px;">
                <%:Html.Encode((room.RoomRate.TotalRoomTax + room.RoomRate.ServiceTax).ToString("N2"))%></label><br />
            <label>
                Extra Guest Charge :</label>
            <label style="width: 80px;">
                <%:Html.Encode((room.RoomRate.ExtraGuestCharges + room.RoomRate.MarkupExtraGuestCharge).ToString("N2"))%></label><br />
            <label>
                Less Discount :</label>
            <label style="width: 80px;">
                <%:Html.Encode(room.RoomRate.DisCount.ToString("N2"))%></label><br />
            <label>
                No of Room :</label>
            <label style="width: 80px;">
                1
            </label>
            <br />
            <label>
                Total :</label>
            <% var total = (room.RoomRate.TotalRoomRate + room.RoomRate.TotalRoomTax + room.RoomRate.ServiceTax + room.RoomRate.ExtraGuestCharges + room.RoomRate.MarkupRatePerRoom + room.RoomRate.AgentServiceCharge);
               totalChargableAmount += total; %>
               
            <label style="width: 80px;">
                <%:Html.Encode(Model.CurrencyCode)%>
                <%:Html.Encode(Math.Ceiling(Decimal.Parse(total.ToString("N2")))  )%>
            </label>
            <br />
        </div>
    </div>
    <%} %>
    <div class="headingTlt" style="text-align: center;">
        <label style="width: 80px;">
            Total :</label>
        <label style="width: 80px;">
            <%:Html.Encode(Model.RoomDetail[0].RoomRate.CurrencyCode)%>
            <%:Html.Encode(Math.Ceiling(Decimal.Parse( totalChargableAmount.ToString())))%>
        </label>
    </div>
</div>
<div style="width: 68%; float: left; margin-top: 10px;">
    <h3 class="headingTlt" onclick="javascript:ToggleDiv('NightRates')" style="cursor: pointer;">
        <span id="Span1" style="font-size: 14px;">-</span> Night Rates</h3>
    <div id="Div1" class="float-left" style="width: 97.5%; border: 1px solid #ccc; padding: 1%;">
        <%for (var i = 1; i <= Model.NoOfRooms; i++)
          {
              var Rooms = Model.RoomDetail[0];
              if (Model.RoomDetail[0].SequenceNo != null)
              {
                  Rooms = Model.RoomDetail.Where(x => x.SequenceNo == i.ToString().Trim()).FirstOrDefault();
              }
              else
              {
                  Rooms = Model.RoomDetail[0];
              } %>
        <div>
            Room:
            <%=i %></div>
        <table cellspacing="0" cellpadding="0" width="100%" class="hotelroomlist">
            <thead>
                <th>
                    <dl class="dlTlt" style="background: none; height: 11px; margin-bottom; 0px;">
                        <dd style="width: 30px; line-height: 3px;">
                        </dd>
                        <% int daysCount = 1; foreach (var item1 in Rooms.DayRates)
                           {
                               if (daysCount <= 7)
                               { %>
                        <dd style="width: 70px; line-height: 3px;">
                            <%=item1.Days.DayOfWeek.ToString().Substring(0, 3)%>
                        </dd>
                        <%}
                               daysCount++;
                           } %>
                    </dl>
                </th>
            </thead>
            <tbody>
                <tr>
                    <td>
                        <% daysCount = 1; int currentWeek = 0; int weekCount = 0; bool IsFiest = true; foreach (var item1 in Rooms.DayRates)
                           { %>
                        <%if (daysCount == 1 || currentWeek != (daysCount / 9))
                          {
                              daysCount = 1; weekCount++;%>
                        <%if (IsFiest == false)
                          { %>
                        <%} %>
                        <dl class="dlTlt">
                            <dd style="width: 30px; font-size: 10px; font-weight: normal;">
                                WK-<%=weekCount.ToString()%>
                            </dd>
                            <%} %>
                            <% if (daysCount <= 7)
                               { %>
                            <dd style="width: 70px; font-size: 10px; font-weight: normal;">
                                <%if (item1.IsHighRate == true)
                                  { %>
                                <span style="width: 50px; color: #999999; text-decoration: line-through;">
                                    <%=Model.CurrencyCode%>.<%= item1.HighRate.ToString("N2")%></span><br />
                                <%} %>
                                <%=Model.CurrencyCode%>.<%=(item1.LowRate + (Rooms.RoomRate.AgentServiceCharge / days) + (Rooms.RoomRate.MarkupRatePerRoom / days)).ToString("N2")%>
                            </dd>
                            <%}
                               IsFiest = false;
                               daysCount++;
                               currentWeek = daysCount / 8;

                           } %>
                        </dl>
                    </td>
                </tr>
            </tbody>
        </table>
        <%} %>
    </div>
</div>
<div style="width: 68%; float: left; margin-top: 10px;">
    <h3 class="headingTlt" onclick="javascript:ToggleDiv('RoomDetails')" style="cursor: pointer;">
        <span id="SignRoomDetails" style="font-size: 14px;">-</span> Room Details</h3>
    <div id="RoomDetails" style="width: 98%; border: 1px solid #B6DAF0; padding: 1%;
        overflow: hidden;">
        <% if (Model.RoomGuest != null)
           { %>
        <% foreach (var item in Model.RoomGuest)
           {
               TotalGuests += (item.NoOfAdults + item.NoOfChild);%>
        <div style="width: 98%;">
            <p>
                <span style="width: 98%; float: left;">Room Type :
                    <%=item.RoomTypeName %>
                </span>
                <br />
                <span style="width: 120px; float: left;">No. of Rooms : 1 </span><span style="width: 120px;
                    float: left;">No. of Guests :
                    <%=(item.NoOfAdults + item.NoOfChild).ToString()%></span> <span style="width: 120px;
                        float: left;">
                        <%=item.NoOfAdults.ToString()%>
                        Adult(s) </span><span style="width: 120px; float: left;">
                            <%=item.NoOfChild.ToString()%>
                            Child(s) </span>
            </p>
        </div>
        <%} %>
        <%} %>
    </div>
</div>
<div style="width: 100%; float: left; margin-top: 10px;">
    <h3 class="headingTlt">
        Guest Details</h3>
    <div style="width: 97.8%; border: 1px solid #B6DAF0; padding: 1%; overflow: hidden;">
        <div class="form-box1-row-content flightType" style="width: auto; margin-bottom: 5px;">
            <div>
                <label>
                    Room Index : 1
                </label>
                <label>
                    Adult : 1
                </label>
            </div>
            <br />
            <%  roomIndex = 0; foreach (var item in Model.Guests.Where(x => x.IsLeadGuest == true))
                {
                    roomIndex = item.RoomIndex;
            %>
        </div>
        <div class="form-box1-row">
            <div class="form-box1-row-content float-left">
                <div>
                    <label>
                        Name:
                    </label>
                    <%:Html.Encode(Model.Guests[0].Title)%>
                    <%:Html.Encode(Model.Guests[0].FirstName)%>
                    <%:Html.Encode(Model.Guests[0].MiddleName)%>
                    <%:Html.Encode(Model.Guests[0].LastName)%>
                </div>
            </div>
            <div class="form-box1-row-content float-right">
                <div>
                    <label>
                        Age:
                    </label>
                    <%:Html.Encode(Model.Guests[0].Age.ToString())%>
                </div>
            </div>
        </div>
        <div class="form-box1-row">
            <div class="form-box1-row-content float-left">
                <div>
                    <label>
                        Phone No:
                    </label>
                    <%:Html.Encode(Model.Guests[0].PhoneNo)%>
                </div>
            </div>
          <%--  <div class="form-box1-row-content float-right">
                <div>
                    <label>
                        Email:
                    </label>
                    <%:Html.Encode(Model.Guests[0].Email)%>
                </div>
            </div>--%>
        </div>
        <div class="form-box1-row">
            <div class="form-box1-row-content float-left">
                <div>
                    <label>
                        Address 1:
                    </label>
                    <%:Html.Encode(Model.Guests[0].Address1)%>
                </div>
            </div>
            <div class="form-box1-row-content float-right">
                <div>
                    <label>
                        Address 2:
                    </label>
                    <%:Html.Encode(Model.Guests[0].Address2)%>
                </div>
            </div>
        </div>
        <div class="form-box1-row">
            <div class="form-box1-row-content float-left">
                <div>
                    <label>
                        City:
                    </label>
                    <%:Html.Encode(Model.Guests[0].City)%>
                </div>
            </div>
            <div class="form-box1-row-content float-right">
                <div>
                    <label>
                        State:
                    </label>
                    <%:Html.Encode(Model.Guests[0].GuestState)%>
                </div>
            </div>
        </div>
        <div class="form-box1-row">
            <div class="form-box1-row-content float-left">
                <div>
                    <label>
                        Country:
                    </label>
                    <%:Html.Encode(Model.Guests[0].Country)%>
                </div>
            </div>
            <div class="form-box1-row-content float-right">
                <div>
                    <label>
                        Lead Guest:
                    </label>
                    <%:Html.Encode(Model.Guests[0].IsLeadGuest)%>
                </div>
            </div>
        </div>
        <%} %>
       <%var _guestId = 0; var isfirst = true; var roomindex = 0; int Adultindex = 0; int Childindex = 0; foreach (var item in Model.RoomGuest)
              {
                  var nextRoom = true;
            %>

        <%for (var i = isfirst == true ? 2 : 1; i <= Model.RoomGuest[Adultindex].NoOfAdults; i++)
              {
               
                  _guestId++;%>
                
            <div class="form-box1-row">
               
                    <div class="form-box1-row-content flightType" style="width: auto; margin-bottom: 5px;">
                        <label style="width:70px; padding-left:50px;">
                            Room Index:
                            <%=(roomindex + 1).ToString()%>
                        </label >     
                          <label style="padding-left:100px"></label> 
                             <label  style="width:70px">Adult:
                                <%=i.ToString()%></label>

                     </div>
                    <div style="padding-left:70px">
                       
                  
                        <label>
                             Name:
                        </label>
                        <%:Html.DisplayFor(model => model.Guests[_guestId].FirstName)%> <%:Html.DisplayFor(model => model.Guests[_guestId].MiddleName)%> <%:Html.DisplayFor(model => model.Guests[_guestId].LastName)%>
                       <label style="padding-left:600px"></label>
                        <label>
                            Age:
                        </label>
                        <%if (nextRoom == true && isfirst == false)
                          {  %>
                        <%} %>
                      
                        <%:Html.DisplayFor(model => model.Guests[_guestId].Age)%>
                    </div>
               
            </div>
            <% nextRoom = false;
              }


                  for (var i = 1; i <= Model.RoomGuest[Childindex].NoOfChild; i++)
              {
                  _guestId++;%>
            <div class="form-box1-row">
                <div  class="form-box1-row-content flightType" style="width: auto; margin-bottom: 5px;">
                   
                        <label  style="width:70px; padding-left:50px;">
                            Room Index:
                            <%=(roomindex + 1).ToString()%></label>    
                            <label style="padding-left:100px"></label>       
                             <label>Child:
                                <%=i.ToString()%></label>
                    </div>
                    <div style="padding-left:70px">
                       
                        
                        <label >
                             Name:
                        </label>
                        <%:Html.DisplayFor(model => model.Guests[_guestId].FirstName)%> <%:Html.DisplayFor(model => model.Guests[_guestId].MiddleName)%> <%:Html.DisplayFor(model => model.Guests[_guestId].LastName)%>
                        <label style="padding-left:600px"></label>
                        <label>
                            Age:
                        </label>
                         <%:Html.DisplayFor(model => model.Guests[_guestId].Age)%>
                     
                    </div>
                
            </div>
            <% nextRoom = false;
              } roomindex++;
              isfirst = false;
              Adultindex++;
              Childindex++;
              }%>
       
        <div class="form-box1-row">
            <div class="form-box1-row-content float-left">
                <div>
                    <label>
                        Special request :
                    </label>
                    <%:Html.Encode(Model.SpecialRequest)%>
                </div>
            </div>
            <div class="form-box1-row-content float-right">
                <div>
                    <label>
                        Flight Info :
                    </label>
                    <%:Html.Encode(Model.Flightinfo)%>
                </div>
            </div>
        </div>
    </div>
</div>
