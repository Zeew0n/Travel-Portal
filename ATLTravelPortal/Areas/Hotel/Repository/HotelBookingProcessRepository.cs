using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ATLTravelPortal.Areas.Hotel.Models;
using ATLTravelPortal.Areas.Hotel.Pagination;
using ATLTravelPortal.Areas.Airline;

namespace ATLTravelPortal.Areas.Hotel.Repository
{
    public class HotelBookingProcessRepository
    {
        private DateTime CurrentDateTime = ATLTravelPortal.Repository.GeneralRepository.CurrentDateTime();
        private int LoggedAgentId = ATLTravelPortal.Repository.GeneralRepository.LoggedAgentId();
        public IEnumerable<HotelBookingRecordModel> List()
        {
            int SNO= 0;
            TravelPortalEntity.EntityModel _ent = new TravelPortalEntity.EntityModel();
            int GDSID = HotelCore.Utility.AppSetting.TBOHotelAPI;
            var result = _ent.Htl_BookingRecord.Where(x => x.IsProcessed == false && x.IsBookingSuccess == true).OrderByDescending(x => x.CreatedOn);
             //&& x.GDSID == GDSID && x.AgentId == LoggedAgentId
            List<HotelBookingRecordModel> model = new List<HotelBookingRecordModel>();
            foreach (var item in result)
            {
               SNO= SNO + 1;
                HotelBookingRecordModel _booking = new HotelBookingRecordModel
                {
                    SNo=SNO,
                    AddBookingRefId = item.AddBookingRefId,
                    AgentId = item.AgentId,
                    BookingReferenceNo = item.BookingReferenceNo,
                    CheckInDate = item.CheckInDate,
                    CheckOutDate = item.CheckOutDate,
                    CreatedBy = item.CreatedBy,
                    CreatedDate = item.CreatedOn,
                    CurrencyCode = item.CurrencyCode,
                    FlightInfo = item.FlightInfo,
                    GDSBookingId = item.GDSBookingId,
                    GDSID = item.GDSID,
                    BookingRecordId = item.BookingRecordId,
                    HotelBookingStatus = item.HotelBookingStatus,
                    HotelCode = item.HotelCode,
                    HotelName = item.HotelName,
                    HotelRating = item.HotelRating,
                    NoOfNights = item.NoOfNights,
                    NoOfRoom = item.NoOfRoom,
                    SearchIndex = item.SearchIndex,
                    SearchSessionId = item.SearchSessionId,
                    SpecialRequest = item.SpecialRequest,
                    TotalAmount = item.TotalChargeableAmount
                };
                List<GuestDetailModel> _liguest = new List<GuestDetailModel>();
                var _guestList = _ent.Htl_BookingGuestDetail.Where(x => x.BookingRecordId == item.BookingRecordId);
                foreach (var items in _guestList)
                {
                    GuestDetailModel _guest = new GuestDetailModel
                    {
                        Address1 = items.Address1,
                        Address2 = items.Address1,
                        Age = items.Age,
                        City = items.City,
                        Country = items.Country,
                        Email = items.Email,
                        FirstName = items.FirstName,
                        GuestState = items.GuestState,
                        //GuestType = item.GuestType.,
                        LastName = items.LastName,
                        MiddleName = items.MiddleName,
                        PhoneNo = items.PhoneNo,
                        RoomIndex = items.RoomIndex,
                        Title = items.Title,
                        ZipCoade = items.ZipCoade
                    };
                    _booking.CountryName = items.Country;
                    _booking.CityName = items.City;
                    _booking.GuestName = items.Title + " " + items.FirstName + " " + items.MiddleName + " " + items.LastName;
                    _liguest.Add(_guest);
                }
                _booking.GuestDetails = _liguest.AsEnumerable();
                model.Add(_booking);
            }
            return model.AsEnumerable();
        }
        public HotelBookingProcessModel ProcessPendingBooking(long? id)
        {
            TravelPortalEntity.EntityModel _ent = new TravelPortalEntity.EntityModel();
            int BaseCurrencyId = 0;
            int CurrencyCodeId = 0;
            string BaseCurrencyCode = System.Configuration.ConfigurationManager.AppSettings["HotelBaseCurrencyCode"];
            string CurrencyCode = System.Configuration.ConfigurationManager.AppSettings["HotelCurrencyCode"];
            var _BaseCurrencyCode = _ent.Currencies.Where(x => x.CurrencyCode.Trim() == BaseCurrencyCode).FirstOrDefault();
            if (_BaseCurrencyCode != null)
            {
                BaseCurrencyId = _BaseCurrencyCode.CurrencyId == null ? 0 : _BaseCurrencyCode.CurrencyId;
            }
            var _CurrencyCode = _ent.Currencies.Where(x => x.CurrencyCode.Trim() == CurrencyCode).FirstOrDefault();
            if (_CurrencyCode != null)
            {
                CurrencyCodeId = _CurrencyCode.CurrencyId == null ? 0 : _CurrencyCode.CurrencyId;
            }
            var _ExchangeRate = _ent.Core_FXRate.Where(x => x.BaseCurrencyID == BaseCurrencyId && x.CurrencyID == CurrencyCodeId).OrderByDescending(x => x.CreatedDate).FirstOrDefault();
            decimal ExchangeRate = 1;
            if (_ExchangeRate != null)
            {
                ExchangeRate = (decimal)(_ExchangeRate.ExchangeRate == null ? 1 : _ExchangeRate.ExchangeRate == 0 ? 1 : _ExchangeRate.ExchangeRate);
            }
            HotelItinearyModel _itmodel = new HotelItinearyModel();
            HotelBookingProcessModel _model = new HotelBookingProcessModel();
            HotelMessageModel _msg = new HotelMessageModel();
            HotelCore.GetHotelBooking.Request _getBookingReq = new HotelCore.GetHotelBooking.Request();
            HotelCore.GetHotelBooking.Response _getBookingRes = new HotelCore.GetHotelBooking.Response();
            HotelCore.AddHotelBookingDetail.Request _addBookingReq = new HotelCore.AddHotelBookingDetail.Request();
            HotelCore.AddHotelBookingDetail.Response _addBookingRes = new HotelCore.AddHotelBookingDetail.Response();
            HotelCore.Book.Request _bookingReq = new HotelCore.Book.Request();
            HotelCore.API api = new HotelCore.API();
            if (id != null)
            {
                var obj = _ent.Htl_BookingRecord.FirstOrDefault(x => x.BookingRecordId == id && x.IsProcessed == false);
                if (obj != null)
                {
                    if (obj.BookingStatusCode.Trim() == "Pending")
                    {
                        _getBookingReq.BookingId = obj.GDSBookingId;
                        _getBookingRes = api.GetHotelBooking(_getBookingReq);
                        if (_getBookingRes.Status.StatusNumber == 0)
                        {
                            if (_getBookingRes.BookingDetail != null)
                            {
                                var _bookRecObj = _ent.Htl_BookingRecord.Where(x => x.BookingRecordId == id).FirstOrDefault();
                                _bookRecObj.BookingStatusCode = _getBookingRes.BookingDetail[0].BookingStatus.ToString();
                                _bookRecObj.BookingReferenceNo = _getBookingRes.BookingDetail[0].BookingRefNo;
                                _bookRecObj.BookingConformationNo = _getBookingRes.BookingDetail[0].ConfirmationNo;
                                _bookRecObj.LastCancilationDate = _getBookingRes.BookingDetail[0].LastCancellationDate;
                                _bookRecObj.BookingStatusCode = _getBookingRes.BookingDetail[0].BookingStatus.ToString();
                                _bookRecObj.IsGetBookingDetail = true;
                                _ent.ApplyCurrentValues(obj.EntityKey.EntitySetName, _bookRecObj);
                                _ent.SaveChanges();
                                var _bookingRecord = _ent.Htl_BookingRecord.Where(x => x.BookingRecordId == id).FirstOrDefault();
                                _bookingReq.SessionId = _bookingRecord.SearchSessionId;
                                _bookingReq.Index = _bookingRecord.SearchIndex;
                                _bookingReq.CountryName = _bookingRecord.CountryName;
                                HotelCore.Utility.PaymentInformation pinfo = new HotelCore.Utility.PaymentInformation();
                                pinfo.Amount = _bookingRecord.TotalChargeableAmount;
                                _bookingReq.PaymentInfo = pinfo;
                                List<HotelCore.Utility.Guest> Guest = new List<HotelCore.Utility.Guest>();
                                var _guest = _ent.Htl_BookingGuestDetail.Where(x => x.BookingRecordId == id);
                                if (_guest != null)
                                {
                                    if (_guest.Count() > 0)
                                    {
                                        foreach (var item in _guest)
                                        {
                                            HotelCore.Utility.Guest gu = new HotelCore.Utility.Guest();
                                            gu.Age = item.Age;
                                            gu.Addressline1 = item.Address1;
                                            gu.Addressline2 = item.Address2;
                                            gu.Areacode = item.AreaPhCode;
                                            gu.City = item.City;
                                            gu.Country = item.Country;
                                            gu.Countrycode = item.CountryPhCode;
                                            gu.Email = item.Email;
                                            gu.FirstName = item.FirstName;
                                            gu.GuestType = item.GuestType.Trim() == "Child" ? HotelCore.Utility.HotelGuestType.Child : HotelCore.Utility.HotelGuestType.Adult;
                                            gu.LastName = item.LastName;
                                            gu.LeadGuest = item.IsLeadGuest;
                                            gu.MiddleName = item.MiddleName;
                                            gu.Phoneno = item.PhoneNo;
                                            gu.RoomIndex = item.RoomIndex;
                                            gu.State = item.GuestState;
                                            gu.Title = item.Title;
                                            gu.Zipcode = item.ZipCoade;
                                            Guest.Add(gu);
                                        }
                                    }
                                }
                                _bookingReq.Guest = Guest.ToArray();
                                _bookingReq.CreatedOn = CurrentDateTime;
                                _bookingReq.DisplayExchangeRate = ExchangeRate;
                                if (_getBookingRes.BookingDetail[0].BookingStatus.ToString() == "Confirmed")
                                {
                                    _addBookingReq = api.FillAddBookingRequest(1, _getBookingRes, _bookingReq);
                                    _addBookingRes = api.AddHotelBookingDetail(_addBookingReq);
                                    if (_addBookingRes.Status.StatusNumber == 0)
                                    {
                                        var _bookRecObj1 = _ent.Htl_BookingRecord.Where(x => x.BookingRecordId == id).FirstOrDefault();
                                        _bookRecObj.AddBookingRefId = _addBookingRes.ReferenceId;
                                        _bookRecObj.IsBookingAdded = true;
                                        _ent.ApplyCurrentValues(obj.EntityKey.EntitySetName, _bookRecObj1);
                                        _ent.SaveChanges();
                                    }
                                }
                            }
                        }
                    }
                    else if ((obj.IsProcessed == false && obj.IsGetBookingDetail == false && obj.BookingStatusCode.Trim() == "Confirmed") || (obj.IsBookingAdded == false))
                    {
                        _getBookingReq.BookingId = obj.GDSBookingId;
                        _getBookingRes = api.GetHotelBooking(_getBookingReq);
                        if (_getBookingRes.Status.StatusNumber == 0)
                        {
                            if (_getBookingRes.BookingDetail != null)
                            {
                                var _bookRecObj = _ent.Htl_BookingRecord.Where(x => x.BookingRecordId == id).FirstOrDefault();
                                _bookRecObj.BookingStatusCode = _getBookingRes.BookingDetail[0].BookingStatus.ToString();
                                _bookRecObj.BookingReferenceNo = _getBookingRes.BookingDetail[0].BookingRefNo;
                                _bookRecObj.BookingConformationNo = _getBookingRes.BookingDetail[0].ConfirmationNo;
                                _bookRecObj.LastCancilationDate = _getBookingRes.BookingDetail[0].LastCancellationDate;
                                _bookRecObj.IsGetBookingDetail = true;
                                _ent.ApplyCurrentValues(obj.EntityKey.EntitySetName, _bookRecObj);
                                _ent.SaveChanges();
                                var _bookingRecord = _ent.Htl_BookingRecord.Where(x => x.BookingRecordId == id).FirstOrDefault();
                                _bookingReq.SessionId = _bookingRecord.SearchSessionId;
                                _bookingReq.Index = _bookingRecord.SearchIndex;
                                _bookingReq.CountryName = _bookingRecord.CountryName;
                                HotelCore.Utility.PaymentInformation pinfo = new HotelCore.Utility.PaymentInformation();
                                pinfo.Amount = _bookingRecord.TotalChargeableAmount;
                                _bookingReq.PaymentInfo = pinfo;
                                List<HotelCore.Utility.Guest> Guest = new List<HotelCore.Utility.Guest>();
                                var _guest = _ent.Htl_BookingGuestDetail.Where(x => x.BookingRecordId == id);
                                if (_guest != null)
                                {
                                    if (_guest.Count() > 0)
                                    {
                                        foreach (var item in _guest)
                                        {
                                            HotelCore.Utility.Guest gu = new HotelCore.Utility.Guest();
                                            gu.Age = item.Age;
                                            gu.Addressline1 = item.Address1;
                                            gu.Addressline2 = item.Address2;
                                            gu.Areacode = item.AreaPhCode;
                                            gu.City = item.City;
                                            gu.Country = item.Country;
                                            gu.Countrycode = item.CountryPhCode;
                                            gu.Email = item.Email;
                                            gu.FirstName = item.FirstName;
                                            gu.GuestType = item.GuestType.Trim() == "Child" ? HotelCore.Utility.HotelGuestType.Child : HotelCore.Utility.HotelGuestType.Adult;
                                            gu.LastName = item.LastName;
                                            gu.LeadGuest = item.IsLeadGuest;
                                            gu.MiddleName = item.MiddleName;
                                            gu.Phoneno = item.PhoneNo;
                                            gu.RoomIndex = item.RoomIndex;
                                            gu.State = item.GuestState;
                                            gu.Title = item.Title;
                                            gu.Zipcode = item.ZipCoade;
                                            Guest.Add(gu);
                                        }
                                    }
                                }
                                _bookingReq.Guest = Guest.ToArray();
                                _bookingReq.CreatedOn = CurrentDateTime;
                                _bookingReq.DisplayExchangeRate = ExchangeRate;
                                _addBookingReq = api.FillAddBookingRequest(1, _getBookingRes, _bookingReq);
                                _addBookingRes = api.AddHotelBookingDetail(_addBookingReq);
                                if (_addBookingRes.Status.StatusNumber == 0)
                                {
                                    var _bookRecObj1 = _ent.Htl_BookingRecord.Where(x => x.BookingRecordId == id).FirstOrDefault();
                                    _bookRecObj1.AddBookingRefId = _addBookingRes.ReferenceId;
                                    _bookRecObj1.IsBookingAdded = true;
                                    _ent.ApplyCurrentValues(_bookRecObj1.EntityKey.EntitySetName, _bookRecObj1);
                                    _ent.SaveChanges();
                                }
                            }
                        }
                    }
                    else if (obj.IsVouchered == false)
                    {
                        _getBookingReq.BookingId = obj.GDSBookingId;
                        _getBookingRes = api.GetHotelBooking(_getBookingReq);
                        var _bookRecObj1 = _ent.Htl_BookingRecord.Where(x => x.BookingRecordId == id).FirstOrDefault();
                        _bookRecObj1.IsVouchered = _getBookingRes.BookingDetail[0].VoucherStatus;
                        _bookRecObj1.IsProcessed = _getBookingRes.BookingDetail[0].VoucherStatus;
                        _ent.ApplyCurrentValues(_bookRecObj1.EntityKey.EntitySetName, _bookRecObj1);
                        _ent.SaveChanges();
                    }

                }
                var _bookRecObj2 = _ent.Htl_BookingRecord.Where(x => x.BookingRecordId == id).FirstOrDefault();
                if (_bookRecObj2.IsBookingSuccess == true && _bookRecObj2.IsBookingAdded == true && _bookRecObj2.BookingStatusCode == "Confirmed")
                {
                    _bookRecObj2.IsProcessed = true;
                    _ent.ApplyCurrentValues(_bookRecObj2.EntityKey.EntitySetName, _bookRecObj2);
                    _ent.SaveChanges();
                }
                HotelItinearyModel _itinModel = new HotelItinearyModel();
                HotelBookRepository _bookRep = new HotelBookRepository();
                HotelBookDetailRepository _bookingDtlRep = new HotelBookDetailRepository();
                _model.BookingDetail = _bookingDtlRep.GetHotelBooking(id);
                _itinModel = _bookRep.GetItineary(id);
                _model.Itineary = _itinModel.Itineary;
                if (_itinModel.Itineary.BookingStatusDesc == "Confirmed" || _itinModel.Itineary.IsProcessed == true)
                {
                    _msg.ActionMessage = "Booking Success";
                    _msg.MsgNumber = 1;
                    _msg.MsgStatus = true;
                    _msg.MsgType = 0;
                    _model.Message = _msg;
                }
                else
                {
                    _msg.ActionMessage = "Booking can not complete try again.";
                    _msg.MsgNumber = 1001;
                    _msg.MsgStatus = true;
                    _msg.MsgType = 2;
                    _model.Message = _msg;
                }
            }
            else
            {
                _msg.ActionMessage = "Invalid Operation.";
                _msg.MsgNumber = 1000;
                _msg.MsgStatus = true;
                _msg.MsgType = 2;
                _model.Message = _msg;
            }

            return _model;
        }
        public HotelBookingProcessModel GetDetail(long? id)
        {
            HotelBookingProcessModel _model = new HotelBookingProcessModel();
            HotelMessageModel _msg = new HotelMessageModel();
            if (id != null)
            {
                HotelItinearyModel _itinModel = new HotelItinearyModel();
                HotelBookRepository _bookRep = new HotelBookRepository();
                HotelBookDetailRepository _bookingDtlRep = new HotelBookDetailRepository();
                HotelBookingDetailModel _bookingDtlModel = new HotelBookingDetailModel();
                _bookingDtlModel=_bookingDtlRep.GetHotelBooking(id);
                _model.BookingDetail = _bookingDtlModel;
                _model.BookingRecordId = id.Value;
                _itinModel = _bookRep.GetItineary(id);
                _model.Itineary = _itinModel.Itineary;
                _model.Message = _bookingDtlModel.Message;
            }
            else
            {
                _msg.ActionMessage = "Invalid Operation.";
                _msg.MsgNumber = 1000;
                _msg.MsgStatus = true;
                _msg.MsgType = 2;
                _model.Message = _msg;
            }

            return _model;
        }
        public IPagedList<HotelBookingRecordModel> GetPagedList(int? page)
        {
            int currentPageIndex = page.HasValue ? page.Value - 1 : 0;
            return List().ToPagedList(currentPageIndex, HotelGeneralRepository.DefaultPageSize);
        }

        public IPagedList<HotelBookingRecordModel> GetBranchOfficeHotelBookingProcessPagedList(int? page)
        {
            int currentPageIndex = page.HasValue ? page.Value - 1 : 0;
            return ListBranchOfficeHotelBookingProcess().ToPagedList(currentPageIndex, HotelGeneralRepository.DefaultPageSize);
        }



        public IEnumerable<HotelBookingRecordModel> ListBranchOfficeHotelBookingProcess()
        {
            int SNO = 0;
            TravelPortalEntity.EntityModel _ent = new TravelPortalEntity.EntityModel();
            int GDSID = HotelCore.Utility.AppSetting.TBOHotelAPI;

            var ts = SessionStore.GetTravelSession();
            var result = from a in _ent.Htl_BookingRecord
                         join b in _ent.Agents on a.AgentId equals b.AgentId
                         where b.BranchOfficeId == ts.LoginTypeId
                         select a;

           // var result = _ent.Htl_BookingRecord.Where(x => x.IsProcessed == false && x.IsBookingSuccess == true).OrderByDescending(x => x.CreatedOn);
            //&& x.GDSID == GDSID && x.AgentId == LoggedAgentId
            List<HotelBookingRecordModel> model = new List<HotelBookingRecordModel>();
            foreach (var item in result.Where(x=>x.IsProcessed == false && x.IsBookingSuccess == true).OrderByDescending(x=>x.CreatedOn))
            {
                SNO = SNO + 1;
                HotelBookingRecordModel _booking = new HotelBookingRecordModel
                {
                    SNo = SNO,
                    AddBookingRefId = item.AddBookingRefId,
                    AgentId = item.AgentId,
                    BookingReferenceNo = item.BookingReferenceNo,
                    CheckInDate = item.CheckInDate,
                    CheckOutDate = item.CheckOutDate,
                    CreatedBy = item.CreatedBy,
                    CreatedDate = item.CreatedOn,
                    CurrencyCode = item.CurrencyCode,
                    FlightInfo = item.FlightInfo,
                    GDSBookingId = item.GDSBookingId,
                    GDSID = item.GDSID,
                    BookingRecordId = item.BookingRecordId,
                    HotelBookingStatus = item.HotelBookingStatus,
                    HotelCode = item.HotelCode,
                    HotelName = item.HotelName,
                    HotelRating = item.HotelRating,
                    NoOfNights = item.NoOfNights,
                    NoOfRoom = item.NoOfRoom,
                    SearchIndex = item.SearchIndex,
                    SearchSessionId = item.SearchSessionId,
                    SpecialRequest = item.SpecialRequest,
                    TotalAmount = item.TotalChargeableAmount
                };
                List<GuestDetailModel> _liguest = new List<GuestDetailModel>();
                var _guestList = _ent.Htl_BookingGuestDetail.Where(x => x.BookingRecordId == item.BookingRecordId);
                foreach (var items in _guestList)
                {
                    GuestDetailModel _guest = new GuestDetailModel
                    {
                        Address1 = items.Address1,
                        Address2 = items.Address1,
                        Age = items.Age,
                        City = items.City,
                        Country = items.Country,
                        Email = items.Email,
                        FirstName = items.FirstName,
                        GuestState = items.GuestState,
                        //GuestType = item.GuestType.,
                        LastName = items.LastName,
                        MiddleName = items.MiddleName,
                        PhoneNo = items.PhoneNo,
                        RoomIndex = items.RoomIndex,
                        Title = items.Title,
                        ZipCoade = items.ZipCoade
                    };
                    _booking.CountryName = items.Country;
                    _booking.CityName = items.City;
                    _booking.GuestName = items.Title + " " + items.FirstName + " " + items.MiddleName + " " + items.LastName;
                    _liguest.Add(_guest);
                }
                _booking.GuestDetails = _liguest.AsEnumerable();
                model.Add(_booking);
            }
            return model.AsEnumerable();
        }

        public IPagedList<HotelBookingRecordModel> GetDistributorHotelBookingProcessPagedList(int? page)
        {
            int currentPageIndex = page.HasValue ? page.Value - 1 : 0;
            return ListDistributorHotelBookingProcess().ToPagedList(currentPageIndex, HotelGeneralRepository.DefaultPageSize);
        }


        public IEnumerable<HotelBookingRecordModel> ListDistributorHotelBookingProcess()
        {
            int SNO = 0;
            TravelPortalEntity.EntityModel _ent = new TravelPortalEntity.EntityModel();
            int GDSID = HotelCore.Utility.AppSetting.TBOHotelAPI;

            var ts = SessionStore.GetTravelSession();
            var result = from a in _ent.Htl_BookingRecord
                         join b in _ent.Agents on a.AgentId equals b.AgentId
                         where b.DistributorId == ts.LoginTypeId
                         select a;



            //var result = _ent.Htl_BookingRecord.Where(x => x.IsProcessed == false && x.IsBookingSuccess == true).OrderByDescending(x => x.CreatedOn);


            //&& x.GDSID == GDSID && x.AgentId == LoggedAgentId
            List<HotelBookingRecordModel> model = new List<HotelBookingRecordModel>();
            foreach (var item in result.Where(x => x.IsProcessed == false && x.IsBookingSuccess == true).OrderByDescending(x => x.CreatedOn))
            {
                SNO = SNO + 1;
                HotelBookingRecordModel _booking = new HotelBookingRecordModel
                {
                    SNo = SNO,
                    AddBookingRefId = item.AddBookingRefId,
                    AgentId = item.AgentId,
                    BookingReferenceNo = item.BookingReferenceNo,
                    CheckInDate = item.CheckInDate,
                    CheckOutDate = item.CheckOutDate,
                    CreatedBy = item.CreatedBy,
                    CreatedDate = item.CreatedOn,
                    CurrencyCode = item.CurrencyCode,
                    FlightInfo = item.FlightInfo,
                    GDSBookingId = item.GDSBookingId,
                    GDSID = item.GDSID,
                    BookingRecordId = item.BookingRecordId,
                    HotelBookingStatus = item.HotelBookingStatus,
                    HotelCode = item.HotelCode,
                    HotelName = item.HotelName,
                    HotelRating = item.HotelRating,
                    NoOfNights = item.NoOfNights,
                    NoOfRoom = item.NoOfRoom,
                    SearchIndex = item.SearchIndex,
                    SearchSessionId = item.SearchSessionId,
                    SpecialRequest = item.SpecialRequest,
                    TotalAmount = item.TotalChargeableAmount
                };
                List<GuestDetailModel> _liguest = new List<GuestDetailModel>();
                var _guestList = _ent.Htl_BookingGuestDetail.Where(x => x.BookingRecordId == item.BookingRecordId);
                foreach (var items in _guestList)
                {
                    GuestDetailModel _guest = new GuestDetailModel
                    {
                        Address1 = items.Address1,
                        Address2 = items.Address1,
                        Age = items.Age,
                        City = items.City,
                        Country = items.Country,
                        Email = items.Email,
                        FirstName = items.FirstName,
                        GuestState = items.GuestState,
                        //GuestType = item.GuestType.,
                        LastName = items.LastName,
                        MiddleName = items.MiddleName,
                        PhoneNo = items.PhoneNo,
                        RoomIndex = items.RoomIndex,
                        Title = items.Title,
                        ZipCoade = items.ZipCoade
                    };
                    _booking.CountryName = items.Country;
                    _booking.CityName = items.City;
                    _booking.GuestName = items.Title + " " + items.FirstName + " " + items.MiddleName + " " + items.LastName;
                    _liguest.Add(_guest);
                }
                _booking.GuestDetails = _liguest.AsEnumerable();
                model.Add(_booking);
            }
            return model.AsEnumerable();
        }
    }
}