using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ATLTravelPortal.Areas.Hotel.Models;
using System.Web.Mvc;

namespace ATLTravelPortal.Areas.Hotel.Repository
{
    public class HotelBookRepository
    {
        private DateTime CurrentDateTime = ATLTravelPortal.Repository.GeneralRepository.CurrentDateTime();
        private int LoggedUserId = ATLTravelPortal.Repository.GeneralRepository.LoggedUserId();
        private int LoggedAgentId = ATLTravelPortal.Repository.GeneralRepository.LoggedAgentId();
        private string UserTerminalId = ATLTravelPortal.Areas.Hotel.Repository.HotelGeneralRepository.getIPAddress();

        public HotelBookModel FillBook(string HotelCode, int Index, string SessionId, string[] RoomCode, HotelSearchResultModel model)
        {
            HotelBookModel _book = new HotelBookModel();
            HotelCore.Book.Request _req = new HotelCore.Book.Request();
            _req.RoomGuestData = model.RoomGestDataList;
            _req.CheckInDate = model.CheckInDate;
            _req.CheckOutDate = model.CheckOutDate;
            _req.CityName = model.CityName;
            _req.CountryName = model.CountryName;
            _req.GDSID = model.GDSID;
            _req.NoOfRooms = model.NoOfRooms;
            _req.SessionId = model.SessionId;
            _req.HotelCode = HotelCode;
            _req.Index = Index;
            _req.RoomCodes = RoomCode;
            _req.DisplayExchangeRate = model.DisplayExchangeRate;
            HotelCore.API api = new HotelCore.API();
            _req = api.FillBooking(_req, model.Result);
            _book.CheckInDate = _req.CheckInDate;
            _book.CheckOutDate = _req.CheckOutDate;
            _book.CityName = _req.CityName;
            _book.CountryName = _req.CountryName;
            _book.ddlCountryList = ddlCountryList();
            _book.GDSID = _req.GDSID;
            _book.HotelAddress = _req.HotelAddress;
            _book.HotelCode = _req.HotelCode;
            _book.HotelEmail = _req.HotelEmail;
            _book.HotelName = _req.HotelName;
            _book.HotelPhoneNo = _req.HotelPhoneNo;
            _book.HotelRating = _req.HotelRating;
            _book.HotelImageUrl = _req.HotelImageUrl;
            _book.HotelDescription = _req.HotelDescription;
            _book.PromoDescription = _req.PromoDescription;
            _book.Index = _req.Index;
            _book.NoOfRooms = _req.NoOfRooms;
            _book.RoomCodes = _req.RoomCodes;
            _book.RoomGuest = _req.RoomGuestData;
            _book.RoomDetail = _req.RoomDetails;
            _book.RoomTypeName = _req.RoomTypeName;
            _book.SessionId = _req.SessionId;
            _book.BookingRoomRate = _req.BookingRoomRate;
            _book.RateKey = _req.RateKey;
            _book.RoomDetail = _req.RoomDetails;
            _book.HotelMap = _req.HotelMap;
            _book.DisplayExchangeRate = model.DisplayExchangeRate;
            _book.BaseCurrencyCode = model.BaseCurrencyCode;
            _book.TotalChargableAmount = _req.TotalChargableAmount;
            _book.MarkupExtraGuestCharge = _req.MarkupExtraGuestCharge;
            _book.MarkupRatePerRoom = _req.MarkupRatePerRoom;
            _book.DiscountRatePerRoom = _req.DiscountRatePerRoom;
            _book.DiscountExtraGuestCharge = _req.DiscountExtraGuestCharge;
            _book.CommissionRatePerRoom = _req.CommissionRatePerRoom;
            _book.CommissionExtraGuestCharge = _req.CommissionExtraGuestCharge;
            HotelCancellationPolicyModel _policyModel = new HotelCancellationPolicyModel();
            HotelCore.GetCancellationPolicy.Response _policyRes = new HotelCore.GetCancellationPolicy.Response();
            HotelCore.GetHotelDetails.RoomDescRequest _policyReq = new HotelCore.GetHotelDetails.RoomDescRequest();
            HotelCancellationPolicyRepository _policyRep = new HotelCancellationPolicyRepository();
            _policyModel.SearchIndex = Index;
            _policyModel.NoOfRoom = _req.NoOfRooms;
            _policyModel.RatePlanCode = model.Result.Where(x => x.HotelInfo.HotelCode == HotelCode).FirstOrDefault().RoomDetails.Where(x => x.RoomTypeCode == RoomCode[0]).FirstOrDefault().RatePlanCode;
            _policyModel.RoomTypeCode = RoomCode[0];
            _policyModel.SessiobId = SessionId;
            _policyModel.HotelCode = HotelCode;
            _book.PolicyModel = _policyRep.Get(_policyModel, model);
            return _book;
        }
        public HotelBookModel Book(HotelBookModel model)
        {
            HotelCore.API api = new HotelCore.API();
            HotelCore.Book.Response _res = new HotelCore.Book.Response();
            HotelCore.Book.Request _req = new HotelCore.Book.Request();
            _req.FlightInfo = model.Flightinfo;
            _req.Guest = model.Guest;
            _req.HotelCode = model.HotelCode;
            _req.HotelName = model.HotelName;
            _req.HotelAddress = model.HotelAddress;
            _req.HotelEmail = model.HotelEmail;
            _req.HotelPhoneNo = model.HotelPhoneNo;
            _req.HotelImageUrl = model.HotelImageUrl;
            _req.HotelRating = model.HotelRating;
            _req.Index = model.Index;
            _req.NoOfRooms = model.NoOfRooms;
            _req.CheckInDate = model.CheckInDate;
            _req.CheckOutDate = model.CheckOutDate;
            _req.RoomCodes = model.RoomCodes;
            _req.RoomDetails = model.RoomDetail;
            _req.SessionId = model.SessionId;
            _req.SpecialRequest = model.SpecialRequest;
            _req.TotalChargableAmount = model.TotalChargableAmount;
            _req.ExtraGuestCharges = model.RoomDetail[0].RoomRate.ExtraGuestCharges * model.NoOfRooms;
            _req.TotalTaxAndFees = model.RoomDetail[0].RoomRate.TotalTaxesAndFees;
            _req.CurrencyCode = model.RoomDetail[0].RoomRate.CurrencyCode;
            _req.RoomGuestData = model.RoomGuest;
            _req.GDSID = model.GDSID;
            _req.CountryName = model.CountryName;
            _req.CityName = model.CityName;
            _req.BookingRoomRate = model.BookingRoomRate;
            _req.RateKey = model.RateKey;
            _req.DisplayExchangeRate = model.DisplayExchangeRate;
            _req.BaseCurrencyCode = model.BaseCurrencyCode;
            _req.MarkupExtraGuestCharge = model.MarkupExtraGuestCharge;
            _req.MarkupRatePerRoom = model.MarkupRatePerRoom;
            _req.DiscountRatePerRoom = model.DiscountRatePerRoom;
            _req.DiscountExtraGuestCharge = model.DiscountExtraGuestCharge;
            _req.CommissionRatePerRoom = model.CommissionRatePerRoom;
            _req.CommissionExtraGuestCharge = model.CommissionExtraGuestCharge;
            _req.AgentServiceCharge = model.AgentServiceCharge;
            _req.UserIpAddress = HotelGeneralRepository.getIPAddress();

            long BookingRecordId = 0;
            using (System.Transactions.TransactionScope _ts = new System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.Required))
            {
                BookingRecordId = SaveHotelBooking(_req);
                _ts.Complete();
            };
            HotelSearchResultModel _model = new HotelSearchResultModel();
            _res = api.Book(_req);
            using (System.Transactions.TransactionScope ts1 = new System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.Required))
            {
                UpdateHotelBooking(_res, BookingRecordId);
                ts1.Complete();
            }
            HotelItinearyModel _itinModel = new HotelItinearyModel();
            _itinModel = GetItineary(BookingRecordId);
            HotelMessageModel _msg = new HotelMessageModel();
            var _statsuBooking = _res.Status.Where(x => x.StatusLabel == "Booking").FirstOrDefault();
            var _statsuBookingDtl = _res.Status.Where(x => x.StatusLabel == "Get Booking Detail").FirstOrDefault();
            var _statsuAddBooking = _res.Status.Where(x => x.StatusLabel == "Add Booking Detail").FirstOrDefault();
            if (_res.IsBookingSuccess==false)
            {
                _msg.ActionMessage = "Booking Cannot success.";
                _msg.ErrSource = "GDS";
                _msg.MsgNumber = _statsuBooking.StatusNumber;
                _msg.MsgStatus = true;
                _msg.MsgType = 3;
            }
            else if(_res.IsGetBookingDetail==false)
            {
                _msg.ActionMessage = "Booking-In-Process";
                _msg.ErrSource = "GDS";
                _msg.MsgNumber = _statsuBookingDtl.StatusNumber;
                _msg.MsgStatus = true;
                _msg.MsgType = 10;
            }
            else if (_res.IsBookingAdded==false)
            {
                _msg.ActionMessage = "Booking-In-Process";
                _msg.ErrSource = "GDS";
                _msg.MsgNumber = _statsuBookingDtl.StatusNumber;
                _msg.MsgStatus = true;
                _msg.MsgType = 10;
            }
            else
            {
                _msg.ActionMessage = "Booking Success.";
                _msg.ErrSource = "GDS";
                _msg.MsgNumber = _statsuBookingDtl.StatusNumber;
                _msg.MsgStatus = true;
                _msg.MsgType = 0;
            }
            model.Itineary = _itinModel.Itineary;
            model.Message = _msg;
            return model;
        }
        private long SaveHotelBooking(HotelCore.Book.Request _req)
        {
            TimeSpan ts = _req.CheckOutDate - _req.CheckInDate;
            int NoOfNights = ts.Days;
            TravelPortalEntity.EntityModel _ent = new TravelPortalEntity.EntityModel();
            TravelPortalEntity.Htl_BookingRecord obj = new TravelPortalEntity.Htl_BookingRecord
            {
                AgentId = LoggedAgentId,
                CheckInDate = _req.CheckInDate,
                CheckOutDate = _req.CheckOutDate,
                CreatedBy = LoggedUserId,
                CreatedOn = CurrentDateTime,
                CurrencyCode = _req.CurrencyCode,
                FlightInfo = _req.FlightInfo,
                GDSID = _req.GDSID,
                HotelCode = _req.HotelCode,
                HotelName = _req.HotelName,
                HotelRating = _req.HotelRating.ToString(),
                IsCanceled = false,
                NoOfNights = NoOfNights,
                NoOfRoom = _req.NoOfRooms,
                SearchIndex = _req.Index,
                SearchSessionId = _req.SessionId,
                SpecialRequest = _req.SpecialRequest,
                TotalChargeableAmount = _req.TotalChargableAmount,
                TotalChargeableAmountCeiling = Math.Ceiling(_req.TotalChargableAmount),
                HotelAddress = _req.HotelAddress,
                HotelEmail = _req.HotelEmail,
                HotelPhone = _req.HotelPhoneNo,
                CountryName = _req.CountryName,
                CityName = _req.CityName,
                TotalTaxAndFees = _req.TotalTaxAndFees,
                TotalTaxAndFeesCeiling = Math.Ceiling(_req.TotalTaxAndFees),
                HotelImageUrl = _req.HotelImageUrl,
                UserIpAddress = _req.UserIpAddress,
                ExtraGuestCharges = _req.ExtraGuestCharges,
            };
            _ent.AddToHtl_BookingRecord(obj);
            _ent.SaveChanges();
            long BookingRecordId = obj.BookingRecordId;
            if (_req.Guest != null)
            {
                foreach (var item in _req.Guest)
                {
                    TravelPortalEntity.Htl_BookingGuestDetail _guest = new TravelPortalEntity.Htl_BookingGuestDetail
                    {
                        Address1 = item.Addressline1,
                        Address2 = item.Addressline2,
                        Age = item.Age,
                        City = item.City,
                        Country = item.Country,
                        Email = item.Email,
                        FirstName = item.FirstName,
                        GuestState = item.State,
                        GuestType = item.GuestType.ToString(),
                        BookingRecordId = BookingRecordId,
                        LastName = item.LastName,
                        MiddleName = item.MiddleName,
                        PhoneNo = item.Phoneno,
                        AreaPhCode = item.Areacode,
                        CountryPhCode = item.Countrycode,
                        RoomIndex = item.RoomIndex,
                        Title = item.Title,
                        ZipCoade = item.Zipcode,
                        IsLeadGuest = item.LeadGuest,
                    };
                    _ent.AddToHtl_BookingGuestDetail(_guest);
                }
                _ent.SaveChanges();
            }

            if (_req.RoomDetails != null)
            {
                foreach (var item in _req.RoomGuestData)
                {
                    TravelPortalEntity.Htl_BookingRoomDetail _room = new TravelPortalEntity.Htl_BookingRoomDetail();
                    if (_req.RoomGuestData.Count() == _req.RoomDetails.Count())
                    {
                        _room.BookingRoomCode = _req.RoomDetails[item.RoomIndex].RoomTypeCode;
                        _room.RoomTypeName = _req.RoomDetails[item.RoomIndex].RoomTypeName;
                    }
                    else
                    {
                        _room.BookingRoomCode = _req.RoomDetails[0].RoomTypeCode;
                        _room.RoomTypeName = _req.RoomDetails[0].RoomTypeName;
                    }
                    _room.BookingRecordId = BookingRecordId;
                    _room.RoomIndex = item.RoomIndex;
                    _room.NoOfAdult = item.NoOfAdults;
                    _room.NoOfChild = item.NoOfChild;
                    _room.ChildAge = " ";
                    _room.BedTypeDesc = " ";
                    _ent.AddToHtl_BookingRoomDetail(_room);
                    _ent.SaveChanges();
                    if (_req.RoomGuestData.Count() == _req.RoomDetails.Count())
                    {
                        foreach (var item2 in _req.RoomDetails[item.RoomIndex].RoomRate.DayRates)
                        {
                            TravelPortalEntity.Htl_BookingNightRate _nightRate = new TravelPortalEntity.Htl_BookingNightRate
                            {
                                BookingDate = item2.Days,
                                BookingRate = item2.LowRate,
                                RoomTypeCode = item.RoomTypeCode,
                                BookingRecordId = BookingRecordId,
                                BookingRoomCodeId = _room.BookingRoomCodeId
                            };
                            _ent.AddToHtl_BookingNightRate(_nightRate);
                        }
                        _ent.SaveChanges();
                    }
                    else
                    {
                        foreach (var item2 in _req.RoomDetails[0].RoomRate.DayRates)
                        {
                            TravelPortalEntity.Htl_BookingNightRate _nightRate = new TravelPortalEntity.Htl_BookingNightRate
                            {
                                BookingDate = item2.Days,
                                BookingRate = item2.LowRate,
                                RoomTypeCode = item.RoomTypeCode,
                                BookingRecordId = BookingRecordId,
                                BookingRoomCodeId = _room.BookingRoomCodeId
                            };
                            _ent.AddToHtl_BookingNightRate(_nightRate);
                        }
                        _ent.SaveChanges();
                    }

                    foreach (var item3 in _req.BookingRoomRate.Where(x => x.RoomTypeCode == _room.BookingRoomCode))
                    {
                        TravelPortalEntity.Htl_BookingRoomRate _bookingRate = new TravelPortalEntity.Htl_BookingRoomRate
                        {
                            Amount = item3.Particular == "Agent-Service-Charge" ? (_req.AgentServiceCharge * NoOfNights) : item3.Amount,
                            AmountType = item3.AmountType,
                            Particular = item3.Particular,
                            RoomTypeCode = item3.RoomTypeCode,
                            NoOfRoom = item3.NoOfRoom,
                            BookingRecordId = BookingRecordId,
                            RateOrder = item3.RateOrder,
                            CurrencyCode = _req.CurrencyCode,
                            BookingRoomCodeId = _room.BookingRoomCodeId
                        };
                        _ent.AddToHtl_BookingRoomRate(_bookingRate);
                    }
                    _ent.SaveChanges();
                }

            }
            return BookingRecordId;
        }
        private void SaveBookingRate(HotelCore.Book.Request _req)
        {

            //var obj=_ent.Htl_BookingRoomRate
        }
        public bool ValidateEmail(string email)
        {
            string _emailPatt = @"^[a-z][a-z|0-9|]*([_][a-z|0-9]+)*([.][a-z|" +
                @"0-9]+([_][a-z|0-9]+)*)?@[a-z][a-z|0-9|]*\.([a-z]" +
                @"[a-z|0-9]*(\.[a-z][a-z|0-9]*)?)$";
            System.Text.RegularExpressions.Regex regexp = new System.Text.RegularExpressions.Regex(_emailPatt, System.Text.RegularExpressions.RegexOptions.Singleline);
            return (regexp.IsMatch(email));
        }
        public HotelMessageModel VaildateModel(HotelBookModel model)
        {
            HotelMessageModel _msg = new HotelMessageModel();
            string _emailPatt = @"^[a-z][a-z|0-9|]*([_][a-z|0-9]+)*([.][a-z|" +
              @"0-9]+([_][a-z|0-9]+)*)?@[a-z][a-z|0-9|]*\.([a-z]" +
              @"[a-z|0-9]*(\.[a-z][a-z|0-9]*)?)$";
            if (model.TermsConditions == false)
            {
                _msg.ActionMessage = "Accept terms and conditions.";
                _msg.MsgNumber = 1001;
                _msg.MsgStatus = true;
                _msg.MsgType = 3;
                goto message;
            }
            var count = 0;
            foreach (var item in model.Guest)
            {
                count++;
                if (item.LeadGuest == true && count == 1)
                {
                    if (item.Addressline1 == null)
                    {
                        _msg.ActionMessage = "Lead guest address required.";
                        _msg.MsgNumber = 1001;
                        _msg.MsgStatus = true;
                        _msg.MsgType = 3;
                        goto message;
                    }
                    else if (item.Addressline1.Count() < 10)
                    {
                        _msg.ActionMessage = "Invalid address.";
                        _msg.MsgNumber = 1001;
                        _msg.MsgStatus = true;
                        _msg.MsgType = 3;
                        goto message;
                    }
                    if (item.Areacode == null)
                    {
                        _msg.ActionMessage = "Area code address required.";
                        _msg.MsgNumber = 1001;
                        _msg.MsgStatus = true;
                        _msg.MsgType = 3;
                        goto message;
                    }
                    else if (item.Areacode.Trim() == "")
                    {
                        _msg.ActionMessage = "Invalid Area Code.";
                        _msg.MsgNumber = 1001;
                        _msg.MsgStatus = true;
                        _msg.MsgType = 3;
                        goto message;
                    }
                    if (item.Email == null)
                    {
                        _msg.ActionMessage = "Email required.";
                        _msg.MsgNumber = 1001;
                        _msg.MsgStatus = true;
                        _msg.MsgType = 3;
                        goto message;
                    }
                    else if (item.Email.Count() < 5)
                    {
                        _msg.ActionMessage = "Invalid email address.";
                        _msg.MsgNumber = 1001;
                        _msg.MsgStatus = true;
                        _msg.MsgType = 3;
                        goto message;
                    }
                    else
                    {
                        System.Text.RegularExpressions.Regex regexp = new System.Text.RegularExpressions.Regex(_emailPatt, System.Text.RegularExpressions.RegexOptions.Singleline);
                        var x = (regexp.IsMatch(item.Email));
                        if (x == false)
                        {
                            _msg.ActionMessage = "invalid email address.";
                            _msg.MsgNumber = 1001;
                            _msg.MsgStatus = true;
                            _msg.MsgType = 3;
                            goto message;
                        }
                    }
                    if (item.FirstName == null)
                    {
                        _msg.ActionMessage = "First name required.";
                        _msg.MsgNumber = 1001;
                        _msg.MsgStatus = true;
                        _msg.MsgType = 3;
                        goto message;
                    }
                    else if (item.FirstName.Trim() == "")
                    {
                        _msg.ActionMessage = "Invalid first name.";
                        _msg.MsgNumber = 1001;
                        _msg.MsgStatus = true;
                        _msg.MsgType = 3;
                        goto message;
                    }
                    if (item.LastName == null)
                    {
                        _msg.ActionMessage = "Last name required.";
                        _msg.MsgNumber = 1001;
                        _msg.MsgStatus = true;
                        _msg.MsgType = 3;//Error
                        goto message;
                    }
                    else if (item.LastName.Trim() == "")
                    {
                        _msg.ActionMessage = "Invalid Last Name.";
                        _msg.MsgNumber = 1001;
                        _msg.MsgStatus = true;
                        _msg.MsgType = 3;
                        goto message;
                    }
                    if (item.Phoneno == null)
                    {
                        _msg.ActionMessage = "Phone No required.";
                        _msg.MsgNumber = 1001;
                        _msg.MsgStatus = true;
                        _msg.MsgType = 3;
                        goto message;
                    }
                    else if (item.Phoneno.Trim().Count() < 6)
                    {
                        _msg.ActionMessage = "Invalid phone No.";
                        _msg.MsgNumber = 1001;
                        _msg.MsgStatus = true;
                        _msg.MsgType = 3;
                        goto message;
                    }
                    if (item.State == null)
                    {
                        _msg.ActionMessage = "State required.";
                        _msg.MsgNumber = 1001;
                        _msg.MsgStatus = true;
                        _msg.MsgType = 3;
                        goto message;
                    }
                    else if (item.State.Trim() == "")
                    {
                        _msg.ActionMessage = "invalid state.";
                        _msg.MsgNumber = 1001;
                        _msg.MsgStatus = true;
                        _msg.MsgType = 3;
                        goto message;
                    }
                    if (item.Title == null)
                    {
                        _msg.ActionMessage = "Title required.";
                        _msg.MsgNumber = 1001;
                        _msg.MsgStatus = true;
                        _msg.MsgType = 3;
                        goto message;
                    }
                    else if (item.Title.Trim() == "")
                    {
                        _msg.ActionMessage = "Invalid Title.";
                        _msg.MsgNumber = 1001;
                        _msg.MsgStatus = true;
                        _msg.MsgType = 3;
                        goto message;
                    }
                    if (item.Country == null)
                    {
                        _msg.ActionMessage = "Guest country required.";
                        _msg.MsgNumber = 1001;
                        _msg.MsgStatus = true;
                        _msg.MsgType = 3;
                        goto message;
                    }
                    else if (item.Country.Trim() == "")
                    {
                        _msg.ActionMessage = "Invalid Guest country.";
                        _msg.MsgNumber = 1001;
                        _msg.MsgStatus = true;
                        _msg.MsgType = 3;
                        goto message;
                    }
                    else
                    {
                        TravelPortalEntity.EntityModel _ent = new TravelPortalEntity.EntityModel();
                        var obj = _ent.Htl_BookingDestinationCity.Where(x => x.CountryName.Trim() == item.Country.Trim()).FirstOrDefault();
                        if (obj == null)
                        {
                            _msg.ActionMessage = "Invalid Guest country.";
                            _msg.MsgNumber = 1001;
                            _msg.MsgStatus = true;
                            _msg.MsgType = 3;
                            goto message;
                        }
                    }
                }
                else
                {
                    if (item.Title == null)
                    {
                        _msg.ActionMessage = "Title required.";
                        _msg.MsgNumber = 1001;
                        _msg.MsgStatus = true;
                        _msg.MsgType = 3;
                        goto message;
                    }
                    else if (item.Title.Trim() == "")
                    {
                        _msg.ActionMessage = "Invalid Title.";
                        _msg.MsgNumber = 1001;
                        _msg.MsgStatus = true;
                        _msg.MsgType = 3;//Error
                        goto message;
                    } if (item.FirstName == null)
                    {
                        _msg.ActionMessage = "Fitst Name required.";
                        _msg.MsgNumber = 1001;
                        _msg.MsgStatus = true;
                        _msg.MsgType = 3;
                        goto message;
                    }
                    else if (item.FirstName.Trim() == "")
                    {
                        _msg.ActionMessage = "Invalid First Name.";
                        _msg.MsgNumber = 1001;
                        _msg.MsgStatus = true;
                        _msg.MsgType = 3;
                        goto message;
                    }
                    if (item.LastName == null)
                    {
                        _msg.ActionMessage = "Last Name required.";
                        _msg.MsgNumber = 1001;
                        _msg.MsgStatus = true;
                        _msg.MsgType = 3;
                        goto message;
                    }
                    else if (item.LastName.Trim() == "")
                    {
                        _msg.ActionMessage = "Invalid Last Name.";
                        _msg.MsgNumber = 1001;
                        _msg.MsgStatus = true;
                        _msg.MsgType = 3;
                        goto message;
                    }
                }
            }
            _msg.ActionMessage = "Valied Data.";
            _msg.MsgNumber = 1;
            _msg.MsgStatus = false;
            _msg.MsgType = 0;
            goto message;
        message:
            return _msg;
        }
        public HotelMessageModel ValidateBookingParam(string HotelCode, int? IndexId, string SessionId, string[] RoomCode)
        {
            HotelMessageModel _msg = new HotelMessageModel();
            if (HotelCode == null)
            {
                _msg.ActionMessage = "Invalid Opetration.";
                _msg.MsgNumber = 1000;
                _msg.MsgStatus = true;
                _msg.MsgType = 2;
                goto message;
            }
            else
            {
                if (HotelCode.Count() <= 1)
                {
                    _msg.ActionMessage = "Invalid Opetration.";
                    _msg.MsgNumber = 1000;
                    _msg.MsgStatus = true;
                    _msg.MsgType = 2;
                    goto message;
                }
            }
            if (IndexId == null)
            {
                _msg.ActionMessage = "Invalid Opetration.";
                _msg.MsgNumber = 1000;
                _msg.MsgStatus = true;
                _msg.MsgType = 2;
                goto message;
            }
            else
            {
                if (IndexId < 0)
                {
                    _msg.ActionMessage = "Invalid Opetration.";
                    _msg.MsgNumber = 1000;
                    _msg.MsgStatus = true;
                    _msg.MsgType = 2;
                    goto message;
                }
            }
            if (SessionId == null)
            {
                _msg.ActionMessage = "Invalid Opetration.";
                _msg.MsgNumber = 1000;
                _msg.MsgStatus = true;
                _msg.MsgType = 2;
                goto message;
            }
            else
            {
                if (SessionId.Count() <= 4)
                {
                    _msg.ActionMessage = "Invalid Opetration.";
                    _msg.MsgNumber = 1000;
                    _msg.MsgStatus = true;
                    _msg.MsgType = 2;
                    goto message;
                }
            }
            if (RoomCode == null)
            {
                _msg.ActionMessage = "Invalid Opetration.";
                _msg.MsgNumber = 1000;
                _msg.MsgStatus = true;
                _msg.MsgType = 2;
                goto message;
            }
            else
            {
                if (RoomCode.Count() <= 0)
                {
                    _msg.ActionMessage = "Invalid Opetration.";
                    _msg.MsgNumber = 1000;
                    _msg.MsgStatus = true;
                    _msg.MsgType = 2;
                    goto message;
                }
            }
            _msg.ActionMessage = "Valied Date.";
            _msg.MsgNumber = 1;
            _msg.MsgStatus = false;
            _msg.MsgType = 0;
            goto message;
        message:

            return _msg;
        }
        private void UpdateHotelBooking(HotelCore.Book.Response _res, long BookingRecordId)
        {
            TravelPortalEntity.EntityModel _ent = new TravelPortalEntity.EntityModel();
            var obj = _ent.Htl_BookingRecord.Where(x => x.BookingRecordId == BookingRecordId).FirstOrDefault();
            obj.GDSBookingId = _res.Itineary.BookingId;
            obj.BookingReferenceNo = _res.Itineary.ReferenceNo;
            obj.BookingConformationNo = _res.Itineary.ConfirmationNo;
            if (_res.SessionId != null)
            {
                obj.SearchSessionId = _res.SessionId;
            }
            obj.ErrorText = _res.Itineary.ErrorText;
            obj.HotelRepalyText = _res.Itineary.HotelReplyText;
            obj.BookingStatusCode = _res.Itineary.BookingStatusDesc;
            obj.CheckInInstructions = _res.Itineary.CheckInInstructions;
            obj.StateProvidedCode = _res.HotelStateProvinceCode;
            obj.IsNonRefundable = _res.Itineary.IsNonRefundable;
            obj.RateOccupancyPerRoom = _res.RateOccupancyPerRoom;
            obj.CancellationPolicy = _res.Itineary.CancellationPolicy;
            obj.RegEmail = _res.BookingEmail;
            obj.CardHolderName = _res.CardHolderName;
            obj.CardHolderHomePhome = _res.CardHolderPhone;
            obj.CreditCardType = _res.CardType;
            obj.CreditCardNumber = _res.CardNo;
            obj.CardExpirationDate = _res.CardExparyDate;
            obj.HotelPolicy = _res.Itineary.HotelPolicy;
            obj.HotelBookingStatus = _res.HotelBookingStatus;
            obj.IsBookingAdded = _res.IsBookingAdded;
            obj.AddBookingRefId = _res.AddBookingRefId;
            obj.UserIpAddress = _res.UserIpAddress;
            obj.SupplierType = _res.Itineary.SupplierType;
            obj.IsBookingAdded = _res.IsBookingAdded;
            obj.IsBookingSuccess = _res.IsBookingSuccess;
            obj.IsGetBookingDetail = _res.IsGetBookingDetail;
            obj.LastCancilationDate = _res.LastCancilationDate;
            obj.IsVouchered = _res.IsVouchered;
            obj.IsProcessed = _res.IsProcessed ;
            _ent.ApplyCurrentValues(obj.EntityKey.EntitySetName, obj);
            foreach (var item in _res.Status)
            {
                TravelPortalEntity.Htl_BookingStatus _obj = new TravelPortalEntity.Htl_BookingStatus
                {
                    BookingRecordId = BookingRecordId,
                    StatusCategory = item.Category,
                    StatusCode = item.StatusCode,
                    StatusDescription = item.Description,
                    StatusLabel = item.StatusLabel,
                    GDSID = item.GDSId
                };
                _ent.AddToHtl_BookingStatus(_obj);
            }
            _ent.SaveChanges();
            if (obj.IsBookingSuccess == true)
            {
                _ent.Htl_SaveSalesTransaction(UserTerminalId, BookingRecordId, LoggedAgentId, LoggedUserId);
            }
        }
        public HotelItinearyModel GetItineary(long? BookingRecordId)
        {
            HotelItinearyModel model = new HotelItinearyModel();
            HotelMessageModel _msg = new HotelMessageModel();
            HotelCore.Utility.Itineary _itineary = new HotelCore.Utility.Itineary();
            TravelPortalEntity.EntityModel _ent = new TravelPortalEntity.EntityModel();
            if (BookingRecordId != null)
            {
                var _booking = _ent.Htl_BookingRecord.Where(x => x.BookingRecordId == BookingRecordId).FirstOrDefault();
                if (_booking != null)
                {
                    _itineary.BookingRecordId = BookingRecordId.Value; ;
                    _itineary.BookingId = _booking.GDSBookingId;
                    _itineary.BookingIdAvailable = _booking.GDSBookingId != null ? _booking.GDSBookingId != "" ? true : false : false;
                    _itineary.BookingStatusDesc = _booking.BookingStatusCode;
                    _itineary.BookingStatusDescAvailable = _booking.BookingStatusCode != null ? _booking.BookingStatusCode != "" ? true : false : false;
                    _itineary.CancellationPolicy = _booking.CancellationPolicy;
                    _itineary.CancellationPolicyAvailable = _booking.CancellationPolicy != null ? _booking.CancellationPolicy != "" ? true : false : false;
                    _itineary.CheckInInstructions = _booking.CheckInInstructions;
                    _itineary.CheckInInstructionsAvailable = _booking.CheckInInstructions != null ? _booking.CheckInInstructions != "" ? true : false : false;
                    _itineary.CityName = _booking.CityName;
                    _itineary.CityNameAvailable = _booking.CityName != null ? _booking.CityName != "" ? true : false : false;
                    _itineary.ConfirmationNo = _booking.BookingConformationNo;
                    _itineary.ConfirmationNoAvailable = _booking.BookingConformationNo != null ? _booking.BookingConformationNo != "" ? true : false : false;
                    _itineary.CountryName = _booking.CountryName;
                    _itineary.CountryNameAvailable = _booking.CountryName != null ? _booking.CountryName != "" ? true : false : false;
                    _itineary.ErrorText = _booking.ErrorText;
                    _itineary.ErrorTextAvailable = _booking.ErrorText != null ? _booking.ErrorText != "" ? true : false : false;
                    _itineary.GuestAddress = "";
                    _itineary.GuestEmail = "";
                    _itineary.GuestName = "";
                    _itineary.GuestPhoneNo = "";
                    _itineary.HotelAddress = _booking.HotelAddress;
                    _itineary.HotelEmail = _booking.HotelEmail;
                    _itineary.HotelImageUrl = _booking.HotelImageUrl;
                    _itineary.HotelName = _booking.HotelName;
                    _itineary.HotelPhoneNo = _booking.HotelPhone;
                    _itineary.HotelReplyText = _booking.HotelRepalyText;
                    _itineary.HotelReplyTextAvailable = _booking.HotelRepalyText != null ? _booking.HotelRepalyText != "" ? true : false : false;
                    _itineary.HotelRating = _booking.HotelRating;
                    _itineary.IsNonRefundable = _booking.IsNonRefundable;
                    _itineary.IsProcessed = _booking.IsProcessed;
                    _itineary.ReferenceNo = _booking.BookingReferenceNo;
                    _itineary.ReferenceNoAvailable = _booking.BookingReferenceNo != null ? _booking.BookingReferenceNo != "" ? true : false : false;
                    var _guests = _ent.Htl_BookingGuestDetail.Where(x => x.BookingRecordId == BookingRecordId && x.IsLeadGuest == true).FirstOrDefault();
                    _itineary.GuestAddress = _guests.Address1 + ", " + _guests.City + ", " + _guests.GuestState;
                    _itineary.GuestEmail = _guests.Email;
                    _itineary.GuestName = _guests.FirstName + " " + _guests.MiddleName + " " + _guests.LastName;
                    _itineary.GuestPhoneNo =  _guests.CountryPhCode+"-"+_guests.AreaPhCode+"-"+_guests.PhoneNo;
                    var _roomDtl = _ent.Htl_BookingRoomDetail.Where(x => x.BookingRecordId == BookingRecordId);
                    int NoOfChild = 0;
                    int NoOfAdult = 0;
                    foreach (var item in _roomDtl)
                    {
                        NoOfAdult += item.NoOfAdult;
                        NoOfChild += item.NoOfChild;
                    }

                    model.Itineary = _itineary;
                    var _roomType = _ent.Htl_BookingRoomDetail.Where(x => x.BookingRecordId == BookingRecordId);
                    model.Itineary.RoomTypeName = _roomType.FirstOrDefault().RoomTypeName;
                    List<HotelCore.Utility.HotelRoomsDetails> RoomList = new List<HotelCore.Utility.HotelRoomsDetails>();
                    var bookingRoomCode = "";
                    foreach (var item in _roomType)
                    {
                        HotelCore.Utility.HotelRoomsDetails room = new HotelCore.Utility.HotelRoomsDetails();
                        room.RoomTypeName = item.RoomTypeName;
                        room.NoOfUnits = 1;
                        bookingRoomCode = item.BookingRoomCode;
                        var _nightRate = _ent.Htl_BookingNightRate.Where(x => x.BookingRoomCodeId == item.BookingRoomCodeId);
                        List<HotelCore.Utility.DayRates> _dayRates = new List<HotelCore.Utility.DayRates>();
                        foreach (var item1 in _nightRate)
                        {
                            HotelCore.Utility.DayRates _dayRate = new HotelCore.Utility.DayRates();
                            _dayRate.Days = item1.BookingDate;
                            _dayRate.LowRate = item1.BookingRate;
                            _dayRates.Add(_dayRate);
                        }
                        room.DayRates = _dayRates.ToArray();
                        var _roomRate = _ent.Htl_BookingRoomRate.Where(x => x.BookingRoomCodeId == item.BookingRoomCodeId);
                        List<HotelCore.Utility.RoomRate> _roomRateList = new List<HotelCore.Utility.RoomRate>();
                        HotelCore.Utility.RoomRate RoomRate = new HotelCore.Utility.RoomRate();
                        RoomRate.TotalRoomRate = _roomRate.Where(x => x.Particular == "Total-Rate").FirstOrDefault().Amount;
                        RoomRate.ExtraGuestCharges = _roomRate.Where(x => x.Particular == "Extra-Guest-Charge").FirstOrDefault().Amount;
                        RoomRate.TotalRoomTax = _roomRate.Where(x => x.Particular == "Tax").FirstOrDefault().Amount;
                        RoomRate.ServiceTax = _roomRate.Where(x => x.Particular == "Service-Tax").FirstOrDefault().Amount;
                        RoomRate.AgentServiceCharge = _roomRate.Where(x => x.Particular == "Agent-Service-Charge").FirstOrDefault().Amount;
                        RoomRate.CommissionExtraGuestCharge = _roomRate.Where(x => x.Particular == "Commission-Extra-Guest-Charge").FirstOrDefault().Amount;
                        RoomRate.CommissionRatePerRoom = _roomRate.Where(x => x.Particular == "Commission-Rate-Per-Room").FirstOrDefault().Amount;
                        RoomRate.DiscountExtraGuestCharge = _roomRate.Where(x => x.Particular == "Discount-Extra-Guest-Charge").FirstOrDefault().Amount;
                        RoomRate.DiscountRatePerRoom = _roomRate.Where(x => x.Particular == "Discount-Rate-Per-Room").FirstOrDefault().Amount;
                        RoomRate.MarkupExtraGuestCharge = _roomRate.Where(x => x.Particular == "Markup-Extra-Guest-Charge").FirstOrDefault().Amount;
                        RoomRate.MarkupRatePerRoom = _roomRate.Where(x => x.Particular == "Markup-Rate-Per-Room").FirstOrDefault().Amount;
                        RoomRate.TotalTaxesAndFees = RoomRate.TotalRoomTax + RoomRate.ServiceTax;
                        room.RoomRate = RoomRate;
                        RoomList.Add(room);
                    }

                    model.RoomDetail = RoomList.ToArray();
                    model.NoOfAdult = NoOfAdult;
                    model.NoOfChild = NoOfChild;
                    model.NoOfRoom = _booking.NoOfRoom;
                    model.CurrencyCode = _booking.CurrencyCode;
                    model.GDSID = _booking.GDSID;
                    model.CheckInDate = _booking.CheckInDate;
                    model.CheckOutDate = _booking.CheckOutDate;
                    model.TotalCharge = _booking.TotalChargeableAmount;
                    model.TotalTaxAndFees = _booking.TotalTaxAndFees;
                    model.ExtraGuestCharges = _booking.ExtraGuestCharges;
                    model.TicketStatusId = _booking.TicketStatusId;
                    
                    var _cancel = _ent.Htl_BookingCancelDetail.Where(c => c.BookingRecordId == BookingRecordId).FirstOrDefault();
                    if (_cancel != null)
                    {
                        model.CancellationNumber = _cancel.CancellationReqId;
                    }
                    _msg.ActionMessage = "Success.";
                    _msg.MsgNumber = 1;
                    _msg.MsgStatus = false;
                    _msg.MsgType = 0;
                    model.Message = _msg;
                }
                else
                {
                    _msg.ActionMessage = "Invalid operation.";
                    _msg.MsgNumber = 1000;
                    _msg.MsgStatus = true;
                    _msg.MsgType = 2;
                    model.Message = _msg;
                }
            }
            else
            {
                _msg.ActionMessage = "Invalid operation.";
                _msg.MsgNumber = 1000;
                _msg.MsgStatus = true;
                _msg.MsgType = 2;
                model.Message = _msg;
            }
            return model;
        }
        public HotelCore.GetHotelBooking.Response GetHotelBooking(HotelCore.GetHotelBooking.Request _req)
        {
            HotelCore.GetHotelBooking.Response _res = new HotelCore.GetHotelBooking.Response();
            HotelCore.API _api = new HotelCore.API();
            _res = _api.GetHotelBooking(_req);
            return _res;
        }
        public HotelCore.AddHotelBookingDetail.Response AddHotelBookingDetail(HotelCore.GetHotelBooking.Response BookingDtl, HotelBookModel model)
        {
            HotelCore.AddHotelBookingDetail.Request _req = new HotelCore.AddHotelBookingDetail.Request();
            HotelCore.AddHotelBookingDetail.Response _res = new HotelCore.AddHotelBookingDetail.Response();
            int AdultCount = 0;
            int ChildCount = 0;
            foreach (var item in model.RoomGuest)
            {
                AdultCount += item.NoOfAdults;
                ChildCount += item.NoOfChild;
            }
            //_req.AdultCount = AdultCount;
            //_req.AgencyId = 0;
            //_req.BookingId = Convert.ToInt32(model.BookingId);
            //_req.BookingRefNo = model.ReferenceNo;
            //_req.BookingStatus = BookingDtl.BookingDetail[0].BookingStatus;
            //_req.CheckInDate = model.CheckInDate;
            //_req.ChildCount = ChildCount;
            //_req.CityRef = model.CityName;
            //_req.ConfirmationNo = BookingDtl.BookingDetail[0].ConfirmationNo;
            //_req.Country = model.CountryName;
            //_req.CreatedBy = 1;
            //_req.CreatedOn = DateTime.Now.Date;
            //_req.HotelIndex = model.Index;
            //_req.HotelName = model.HotelName;
            //_req.IsDomestic = BookingDtl.BookingDetail[0].IsDomestic;
            //_req.NoOfRooms = model.NoOfRooms;
            //_req.PassengerInfo = "Name: " + BookingDtl.BookingDetail[0].Guest.Title + " " + BookingDtl.BookingDetail[0].Guest.FirstName + " " + BookingDtl.BookingDetail[0].Guest.MiddleName + " " + BookingDtl.BookingDetail[0].Guest.LastName;
            //_req.PaymentAmount = model.PaymentInfo.Amount;
            //_req.PaymentId = model.PaymentInfo.PaymentId;
            //_req.PaySource = model.PaymentInfo.PaymentGateway;
            //_req.ReferenceId = 0;
            //_req.Remarks = "";
            //_req.SessionId = model.SessionId;
            //_req.StarRating = BookingDtl.BookingDetail[0].Rating;
            //_req.VoucherStatus = BookingDtl.BookingDetail[0].VoucherStatus;
            HotelCore.API _api = new HotelCore.API();
            _res = _api.AddHotelBookingDetail(_req);
            return _res;

        }
        private String UTF8ByteArrayToString(Byte[] characters)
        {
            System.Text.UTF8Encoding encoding = new System.Text.UTF8Encoding();
            String constructedString = encoding.GetString(characters);
            return (constructedString);
        }
        public IEnumerable<SelectListItem> ddlCountryList()
        {
            List<SelectListItem> ddl = new List<SelectListItem>();
            TravelPortalEntity.EntityModel _ent = new TravelPortalEntity.EntityModel();
            var obj = from c in _ent.Htl_BookingDestinationCity select new { c.CountryName };
            obj = obj.Distinct();
            foreach (var item in obj)
            {
                ddl.Add(new SelectListItem { Value = item.CountryName, Text = item.CountryName });
            }
            return ddl;
        }
        public IEnumerable<SelectListItem> ddlCountryList(string filterString, int take)
        {
            List<SelectListItem> ddl = new List<SelectListItem>();
            TravelPortalEntity.EntityModel _ent = new TravelPortalEntity.EntityModel();
            var obj = from c in _ent.Htl_BookingDestinationCity select new { c.CountryName };
            obj = obj.Distinct();
            obj = obj.Where(x => x.CountryName.StartsWith(filterString)).Take(20);
            foreach (var item in obj)
            {
                ddl.Add(new SelectListItem { Value = item.CountryName, Text = item.CountryName });
            }
            return ddl;
        }
    }
}