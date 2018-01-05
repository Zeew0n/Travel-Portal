using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ATLTravelPortal.Areas.Hotel.Models;
using ATLTravelPortal.Areas.Hotel.Pagination;
using ATLTravelPortal.Areas.Airline;

namespace ATLTravelPortal.Areas.Hotel.Repository
{
    public class HotelBookingCancelRepository
    {
        private DateTime CurrentDateTime = ATLTravelPortal.Repository.GeneralRepository.CurrentDateTime();
        private int LoggedUserId = ATLTravelPortal.Repository.GeneralRepository.LoggedUserId();
        private int LoggedAgentId = ATLTravelPortal.Repository.GeneralRepository.LoggedAgentId();
        private string UserTerminalId = ATLTravelPortal.Areas.Hotel.Repository.HotelGeneralRepository.getIPAddress();
        public IEnumerable<HotelBookingCancelModel> List()
        {
            int SNo = 1;
            TravelPortalEntity.EntityModel _ent = new TravelPortalEntity.EntityModel();
            var result = _ent.Htl_BookingCancelDetail.Where(x => x.IsProcessed == true).OrderByDescending(x => x.CreatedDate);
            List<HotelBookingCancelModel> model = new List<HotelBookingCancelModel>();
            foreach (var item in result)
            {
                HotelBookingCancelModel _booking = new HotelBookingCancelModel();
                HotelBookingDetailModel _bookingDtl = new HotelBookingDetailModel();
                _booking.BookingCancelId = item.BookingCancelId;
                _booking.BookingRecordId = item.BookingRecordId.Value;
                _booking.CancelStatus = item.CancellationStatus;
                _bookingDtl.HotelName = item.Htl_BookingRecord.HotelName;
                var obj = item.Htl_BookingRecord.Htl_BookingGuestDetail.Where(x => x.IsLeadGuest = true).FirstOrDefault();
                List<GuestDetailModel> _guests = new List<GuestDetailModel>();
                GuestDetailModel _guest = new GuestDetailModel();

                _guest.Title = obj.Title;
                _guest.FirstName = obj.FirstName;
                _guest.MiddleName = obj.FirstName;
                _guest.LastName = obj.LastName;
                _guests.Add(_guest);
                _bookingDtl.Guests = _guests.ToArray();
                _booking.BookingDetail = _bookingDtl;
                _booking.CreatedOn = item.CreatedDate;
                _booking.SNo = SNo++;
                //BookingReferenceNo = item.BookingReferenceNo,
                //CheckInDate = item.CheckInDate,
                //CheckOutDate = item.CheckOutDate,
                //CreatedBy = item.CreatedBy,
                //CreatedDate = item.CreatedOn,
                //CurrencyCode = item.CurrencyCode,
                //FlightInfo = item.FlightInfo,
                //GDSBookingId = item.GDSBookingId,
                //GDSID = item.GDSID,
                //BookingRecordId = item.BookingRecordId,
                //HotelBookingStatus = item.HotelBookingStatus,
                //HotelCode = item.HotelCode,
                //HotelName = item.HotelName,
                //HotelRating = item.HotelRating,
                //NoOfNights = item.NoOfNights,
                //NoOfRoom = item.NoOfRoom,
                //SearchIndex = item.SearchIndex,
                //SearchSessionId = item.SearchSessionId,
                //SpecialRequest = item.SpecialRequest,
                //TotalAmount = item.TotalAmount
                model.Add(_booking);
            }

            return model.AsEnumerable();
        }

        public IEnumerable<HotelBookingCancelModel> BranchOfficeList()
        {
            int SNo = 1;
            TravelPortalEntity.EntityModel _ent = new TravelPortalEntity.EntityModel();

            var ts = SessionStore.GetTravelSession();
            var result = from a in _ent.Htl_BookingCancelDetail
                         join c in _ent.Htl_BookingRecord on a.BookingRecordId equals c.BookingRecordId
                         join b in _ent.Agents on c.AgentId equals b.AgentId
                         where b.BranchOfficeId == ts.LoginTypeId
                         select a;


            //var result = _ent.Htl_BookingCancelDetail.Where(x => x.IsProcessed == true).OrderByDescending(x => x.CreatedDate);
            List<HotelBookingCancelModel> model = new List<HotelBookingCancelModel>();
            foreach (var item in result.Where(x => x.IsProcessed == true).OrderByDescending(x => x.CreatedDate))
            {
                HotelBookingCancelModel _booking = new HotelBookingCancelModel();
                HotelBookingDetailModel _bookingDtl = new HotelBookingDetailModel();
                _booking.BookingCancelId = item.BookingCancelId;
                _booking.BookingRecordId = item.BookingRecordId.Value;
                _booking.CancelStatus = item.CancellationStatus;
                _bookingDtl.HotelName = item.Htl_BookingRecord.HotelName;
                var obj = item.Htl_BookingRecord.Htl_BookingGuestDetail.Where(x => x.IsLeadGuest = true).FirstOrDefault();
                List<GuestDetailModel> _guests = new List<GuestDetailModel>();
                GuestDetailModel _guest = new GuestDetailModel();

                _guest.Title = obj.Title;
                _guest.FirstName = obj.FirstName;
                _guest.MiddleName = obj.FirstName;
                _guest.LastName = obj.LastName;
                _guests.Add(_guest);
                _bookingDtl.Guests = _guests.ToArray();
                _booking.BookingDetail = _bookingDtl;
                _booking.CreatedOn = item.CreatedDate;
                _booking.SNo = SNo++;

                model.Add(_booking);
            }
            return model.AsEnumerable();
        }

        public IEnumerable<HotelBookingCancelModel> DistributorList()
        {
            int SNo = 1;
            TravelPortalEntity.EntityModel _ent = new TravelPortalEntity.EntityModel();

            var ts = SessionStore.GetTravelSession();
            var result = from a in _ent.Htl_BookingCancelDetail
                         join c in _ent.Htl_BookingRecord on a.BookingRecordId equals c.BookingRecordId
                         join b in _ent.Agents on c.AgentId equals b.AgentId
                         where b.DistributorId == ts.LoginTypeId
                         select a;


           // var result = _ent.Htl_BookingCancelDetail.Where(x => x.IsProcessed == true).OrderByDescending(x => x.CreatedDate);
            List<HotelBookingCancelModel> model = new List<HotelBookingCancelModel>();
            foreach (var item in result.Where(x => x.IsProcessed == true).OrderByDescending(x => x.CreatedDate))
            {
                HotelBookingCancelModel _booking = new HotelBookingCancelModel();
                HotelBookingDetailModel _bookingDtl = new HotelBookingDetailModel();
                _booking.BookingCancelId = item.BookingCancelId;
                _booking.BookingRecordId = item.BookingRecordId.Value;
                _booking.CancelStatus = item.CancellationStatus;
                _bookingDtl.HotelName = item.Htl_BookingRecord.HotelName;
                var obj = item.Htl_BookingRecord.Htl_BookingGuestDetail.Where(x => x.IsLeadGuest = true).FirstOrDefault();
                List<GuestDetailModel> _guests = new List<GuestDetailModel>();
                GuestDetailModel _guest = new GuestDetailModel();

                _guest.Title = obj.Title;
                _guest.FirstName = obj.FirstName;
                _guest.MiddleName = obj.FirstName;
                _guest.LastName = obj.LastName;
                _guests.Add(_guest);
                _bookingDtl.Guests = _guests.ToArray();
                _booking.BookingDetail = _bookingDtl;
                _booking.CreatedOn = item.CreatedDate;
                _booking.SNo = SNo++;

                model.Add(_booking);
            }

            return model.AsEnumerable();
        }

        public IPagedList<HotelBookingCancelModel> GetPagedList(int? page)
        {
            int currentPageIndex = page.HasValue ? page.Value - 1 : 0;
            return List().ToPagedList(currentPageIndex, HotelGeneralRepository.DefaultPageSize);
        }

        public IPagedList<HotelBookingCancelModel> GetBranchOfficePagedList(int? page)
        {
            int currentPageIndex = page.HasValue ? page.Value - 1 : 0;
            return BranchOfficeList().ToPagedList(currentPageIndex, HotelGeneralRepository.DefaultPageSize);
        }


        public IPagedList<HotelBookingCancelModel> GetDistributorPagedList(int? page)
        {
            int currentPageIndex = page.HasValue ? page.Value - 1 : 0;
            return DistributorList().ToPagedList(currentPageIndex, HotelGeneralRepository.DefaultPageSize);
        }
        public IPagedList<HotelBookingCancelModel> GetPagedPendingList(int? page)
        {
            int currentPageIndex = page.HasValue ? page.Value - 1 : 0;
            return PendingList().ToPagedList(currentPageIndex, HotelGeneralRepository.DefaultPageSize);
        }

        public IPagedList<HotelBookingCancelModel> GetBranchOfficePagedPendingList(int? page)
        {
            int currentPageIndex = page.HasValue ? page.Value - 1 : 0;
            return BranchOfficePendingList().ToPagedList(currentPageIndex, HotelGeneralRepository.DefaultPageSize);
        }

        public IPagedList<HotelBookingCancelModel> GetDistributorPagedPendingList(int? page)
        {
            int currentPageIndex = page.HasValue ? page.Value - 1 : 0;
            return DistributorPendingList().ToPagedList(currentPageIndex, HotelGeneralRepository.DefaultPageSize);
        }


        public HotelBookingCancelModel Cancel(HotelBookingCancelModel model)
        {
            HotelCore.SendHotelChangeRequest.Response _res = new HotelCore.SendHotelChangeRequest.Response();
            HotelCore.SendHotelChangeRequest.Request _req = new HotelCore.SendHotelChangeRequest.Request();
            TravelPortalEntity.EntityModel _ent = new TravelPortalEntity.EntityModel();
            HotelMessageModel _msg = new HotelMessageModel();

            var obj = _ent.Htl_BookingRecord.Where(x => x.BookingRecordId == model.BookingRecordId).FirstOrDefault();
            //checked null model.BookingRecordId
            var _cancelObj = _ent.Htl_BookingCancelDetail.Where(x => x.BookingRecordId == model.BookingRecordId).FirstOrDefault();
            if (_cancelObj == null)
            {
                TravelPortalEntity.Htl_BookingCancelDetail _objCancel = new TravelPortalEntity.Htl_BookingCancelDetail
                {
                    BookingRecordId = model.BookingRecordId,
                    GDSBookingID = obj.GDSBookingId,
                    GDSID = obj.GDSID,
                    GDSSessionID = obj.SearchSessionId,
                    CreatedBy = LoggedUserId,
                    CreatedDate = CurrentDateTime,
                    Remark = model.Remark
                };
                _ent.AddToHtl_BookingCancelDetail(_objCancel);
                _ent.SaveChanges();
                model.BookingCancelId = _objCancel.BookingCancelId;
            }
            else
            {
                var _cancel1 = _ent.Htl_BookingCancelDetail.Where(x => x.BookingRecordId == model.BookingRecordId).FirstOrDefault();
                model.BookingCancelId = _cancel1.BookingCancelId;
                _cancel1.ModifiedBy = LoggedUserId;
                _cancel1.ModifiedDate = CurrentDateTime;
                _ent.ApplyCurrentValues(_cancel1.EntityKey.EntitySetName, _cancel1);
                _ent.SaveChanges();
            }
            _req.BookingId = obj.GDSBookingId;
            _req.GDSID = obj.GDSID;
            _req.ConfirmationNo = obj.BookingReferenceNo;
            _req.Remarks = model.Remark;
            _req.Email = obj.RegEmail;
            _req.SessionId = obj.SearchSessionId;
            HotelCore.API _api = new HotelCore.API();
            _res = _api.SendCancelRequest(_req);
            _res.ChangeRequestId = _res.ChangeRequestId == null ? "-1" : _res.ChangeRequestId;
            if (_res.IsCancilRequest == true)
            {
                using (System.Transactions.TransactionScope ts = new System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.Required))
                {
                    TravelPortalEntity.EntityModel _ent1 = new TravelPortalEntity.EntityModel();
                    var _cancel = _ent1.Htl_BookingCancelDetail.Where(x => x.BookingCancelId == model.BookingCancelId).FirstOrDefault();
                    _cancel.CancellationReqId = _res.ChangeRequestId;
                    _cancel.GDSSessionID = obj.SearchSessionId;
                    _cancel.CancellationStatus = _res.ChangeRequestStatus.ToString();
                    _cancel.IsCancilRequest = _res.IsCancilRequest;
                    _cancel.IsProcessed = _res.IsProcessed;
                    _ent.ApplyCurrentValues(_cancel.EntityKey.EntitySetName, _cancel);
                    _ent.SaveChanges();
                    if (_res.ChangeRequestStatus.ToString() == "Processed")
                    {
                        var _record = _ent.Htl_BookingRecord.Where(x => x.BookingRecordId == model.BookingRecordId).FirstOrDefault();
                        _record.IsCanceled = true;
                        _ent.ApplyCurrentValues(_record.EntityKey.EntitySetName, _record);
                        _ent.SaveChanges();
                    }

                    if (_res.ChangeRequestId != null)
                    {
                        if (_res.ChangeRequestId != "")
                        {
                            if (_res.IsProcessed == true)
                            {
                                _ent.Htl_CancelSalesTransaction(UserTerminalId, model.BookingRecordId, LoggedAgentId, LoggedUserId);
                            }
                        }
                    }
                    ts.Complete();
                }
                model.CancelRequestId = _res.ChangeRequestId;
                HotelBookDetailRepository _dtlRep = new HotelBookDetailRepository();
                model.BookingDetail = _dtlRep.GetHotelBooking(model.BookingRecordId);
                model.CreatedOn = CurrentDateTime;

                if (_res.IsProcessed == true)
                {
                    _msg.ActionMessage = "Cancel Success";
                    _msg.MsgNumber = 1;
                    _msg.MsgStatus = true;
                    _msg.MsgType = 0;
                    model.Message = _msg;
                }
                else if (_res.IsCancilRequest == true)
                {
                    _msg.ActionMessage = "Cancelllation is in process";
                    _msg.MsgNumber = 1000;
                    _msg.MsgStatus = true;
                    _msg.MsgType = 2;
                    model.Message = _msg;
                }
            }
            else
            {
                _msg.ActionMessage = "Cancelllation Can not success.";
                _msg.MsgNumber = 1000;
                _msg.MsgStatus = true;
                _msg.MsgType = 2;
                model.Message = _msg;
            }

            model.Message = _msg;
            return model;
        }
        public IEnumerable<HotelBookingCancelModel> PendingList()
        {
            int SNo = 1;
            TravelPortalEntity.EntityModel _ent = new TravelPortalEntity.EntityModel();
            var result = _ent.Htl_BookingCancelDetail.Where(x => x.IsProcessed == false && x.IsCancilRequest == true).OrderByDescending(x => x.CreatedDate);
            List<HotelBookingCancelModel> model = new List<HotelBookingCancelModel>();
            foreach (var item in result)
            {
                HotelBookingCancelModel _booking = new HotelBookingCancelModel();
                HotelBookingDetailModel _bookingDtl = new HotelBookingDetailModel();
                _booking.BookingCancelId = item.BookingCancelId;
                _booking.BookingRecordId = item.BookingRecordId.Value;
                _booking.CancelStatus = item.CancellationStatus;
                _bookingDtl.HotelName = item.Htl_BookingRecord.HotelName;
                var obj = item.Htl_BookingRecord.Htl_BookingGuestDetail.Where(x => x.IsLeadGuest = true).FirstOrDefault();
                List<GuestDetailModel> _guests = new List<GuestDetailModel>();
                GuestDetailModel _guest = new GuestDetailModel();
                _guest.Title = obj.Title;
                _guest.FirstName = obj.FirstName;
                _guest.MiddleName = obj.MiddleName;
                _guest.LastName = obj.LastName;
                _guests.Add(_guest);
                _bookingDtl.Guests = _guests.ToArray();
                _booking.BookingDetail = _bookingDtl;
                _booking.CreatedOn = item.CreatedDate;
                _booking.SNo = SNo++;
                //BookingReferenceNo = item.BookingReferenceNo,
                //CheckInDate = item.CheckInDate,
                //CheckOutDate = item.CheckOutDate,
                //CreatedBy = item.CreatedBy,
                //CreatedDate = item.CreatedOn,
                //CurrencyCode = item.CurrencyCode,
                //FlightInfo = item.FlightInfo,
                //GDSBookingId = item.GDSBookingId,
                //GDSID = item.GDSID,
                //BookingRecordId = item.BookingRecordId,
                //HotelBookingStatus = item.HotelBookingStatus,
                //HotelCode = item.HotelCode,
                //HotelName = item.HotelName,
                //HotelRating = item.HotelRating,
                //NoOfNights = item.NoOfNights,
                //NoOfRoom = item.NoOfRoom,
                //SearchIndex = item.SearchIndex,
                //SearchSessionId = item.SearchSessionId,
                //SpecialRequest = item.SpecialRequest,
                //TotalAmount = item.TotalAmount
                model.Add(_booking);
            }

            return model.AsEnumerable();
        }

        public IEnumerable<HotelBookingCancelModel> BranchOfficePendingList()
        {
            int SNo = 1;
            TravelPortalEntity.EntityModel _ent = new TravelPortalEntity.EntityModel();

            var ts = SessionStore.GetTravelSession();
            var result = from a in _ent.Htl_BookingCancelDetail
                         join c in _ent.Htl_BookingRecord on a.BookingRecordId equals c.BookingRecordId
                         join b in _ent.Agents on c.AgentId equals b.AgentId
                         where b.BranchOfficeId == ts.LoginTypeId
                         select a;

            // var result = _ent.Htl_BookingCancelDetail.Where(x => x.IsProcessed == false && x.IsCancilRequest == true).OrderByDescending(x => x.CreatedDate);
            List<HotelBookingCancelModel> model = new List<HotelBookingCancelModel>();
            foreach (var item in result.Where(x => x.IsProcessed == false && x.IsCancilRequest == true).OrderByDescending(x => x.CreatedDate))
            {
                HotelBookingCancelModel _booking = new HotelBookingCancelModel();
                HotelBookingDetailModel _bookingDtl = new HotelBookingDetailModel();
                _booking.BookingCancelId = item.BookingCancelId;
                _booking.BookingRecordId = item.BookingRecordId.Value;
                _booking.CancelStatus = item.CancellationStatus;
                _bookingDtl.HotelName = item.Htl_BookingRecord.HotelName;
                var obj = item.Htl_BookingRecord.Htl_BookingGuestDetail.Where(x => x.IsLeadGuest = true).FirstOrDefault();
                List<GuestDetailModel> _guests = new List<GuestDetailModel>();
                GuestDetailModel _guest = new GuestDetailModel();
                _guest.Title = obj.Title;
                _guest.FirstName = obj.FirstName;
                _guest.MiddleName = obj.MiddleName;
                _guest.LastName = obj.LastName;
                _guests.Add(_guest);
                _bookingDtl.Guests = _guests.ToArray();
                _booking.BookingDetail = _bookingDtl;
                _booking.CreatedOn = item.CreatedDate;
                _booking.SNo = SNo++;

                model.Add(_booking);
            }

            return model.AsEnumerable();
        }

        public IEnumerable<HotelBookingCancelModel> DistributorPendingList()
        {
            int SNo = 1;
            TravelPortalEntity.EntityModel _ent = new TravelPortalEntity.EntityModel();



            var ts = SessionStore.GetTravelSession();
            var result = from a in _ent.Htl_BookingCancelDetail
                         join c in _ent.Htl_BookingRecord on a.BookingRecordId equals c.BookingRecordId
                         join b in _ent.Agents on c.AgentId equals b.AgentId
                         where b.DistributorId == ts.LoginTypeId
                         select a;

            // var result = _ent.Htl_BookingCancelDetail.Where(x => x.IsProcessed == false && x.IsCancilRequest == true).OrderByDescending(x => x.CreatedDate);
            List<HotelBookingCancelModel> model = new List<HotelBookingCancelModel>();
            foreach (var item in result.Where(x => x.IsProcessed == false && x.IsCancilRequest == true).OrderByDescending(x => x.CreatedDate))
            {
                HotelBookingCancelModel _booking = new HotelBookingCancelModel();
                HotelBookingDetailModel _bookingDtl = new HotelBookingDetailModel();
                _booking.BookingCancelId = item.BookingCancelId;
                _booking.BookingRecordId = item.BookingRecordId.Value;
                _booking.CancelStatus = item.CancellationStatus;
                _bookingDtl.HotelName = item.Htl_BookingRecord.HotelName;
                var obj = item.Htl_BookingRecord.Htl_BookingGuestDetail.Where(x => x.IsLeadGuest = true).FirstOrDefault();
                List<GuestDetailModel> _guests = new List<GuestDetailModel>();
                GuestDetailModel _guest = new GuestDetailModel();
                _guest.Title = obj.Title;
                _guest.FirstName = obj.FirstName;
                _guest.MiddleName = obj.MiddleName;
                _guest.LastName = obj.LastName;
                _guests.Add(_guest);
                _bookingDtl.Guests = _guests.ToArray();
                _booking.BookingDetail = _bookingDtl;
                _booking.CreatedOn = item.CreatedDate;
                _booking.SNo = SNo++;

                model.Add(_booking);
            }

            return model.AsEnumerable();
        }

        public HotelBookingCancelModel GetCancelRequestStatus(long? id)
        {
            HotelCore.GetHotelChangeRequestStatus.Response _res = new HotelCore.GetHotelChangeRequestStatus.Response();
            HotelCore.GetHotelChangeRequestStatus.Request _req = new HotelCore.GetHotelChangeRequestStatus.Request();
            HotelBookingCancelModel model = new HotelBookingCancelModel();
            HotelMessageModel _msg = new HotelMessageModel();
            TravelPortalEntity.EntityModel _ent = new TravelPortalEntity.EntityModel();
            if (id != null)
            {
                var obj = _ent.Htl_BookingCancelDetail.Where(x => x.BookingCancelId == id).FirstOrDefault();
                if (obj != null)
                {
                    using (System.Transactions.TransactionScope ts = new System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.Required))
                    {
                        HotelCore.API _api = new HotelCore.API();
                        _req.ChangeRequestId = Convert.ToInt32(obj.CancellationReqId);
                        _res = _api.GetHotelChangeRequestStatus(_req);
                        obj.CancellationCharge = _res.CancellationCharge;
                        obj.CancellationStatus = _res.ChangeRequestStatus.ToString();
                        obj.RefundableAmount = _res.RefundedAmount;
                        _ent.ApplyCurrentValues(obj.EntityKey.EntitySetName, obj);
                        _ent.SaveChanges();
                        if (_res.ChangeRequestStatus.ToString() == "Processed")
                        {
                            var obj1 = _ent.Htl_BookingRecord.Where(x => x.BookingRecordId == obj.BookingRecordId).FirstOrDefault();
                            obj1.IsCanceled = true;
                            _ent.ApplyCurrentValues(obj1.EntityKey.EntitySetName, obj1);
                            _ent.SaveChanges();
                        }
                        ts.Complete();
                    }

                    if (_res.ChangeRequestStatus.ToString() == "Processed")
                    {
                        _msg.ActionMessage = "Cancellation Success.";
                        _msg.MsgNumber = 1;
                        _msg.MsgStatus = true;
                        _msg.MsgType = 0;
                        model.Message = _msg;
                    }
                    else
                    {
                        _msg.ActionMessage = "Cancellation is " + _res.ChangeRequestStatus.ToString();
                        _msg.MsgNumber = 1000;
                        _msg.MsgStatus = true;
                        _msg.MsgType = 2;
                        model.Message = _msg;
                    }
                    HotelBookDetailRepository _dtlRep = new HotelBookDetailRepository();
                    var obj3 = _ent.Htl_BookingCancelDetail.Where(x => x.BookingCancelId == id).FirstOrDefault();
                    model.CancellationCharge = obj3.CancellationCharge == null ? 0 : obj3.CancellationCharge.Value;
                    model.RefundableAmount = obj3.RefundableAmount;
                    model.CancelStatus = obj3.CancellationStatus;
                    var BookingRecordId = _ent.Htl_BookingCancelDetail.Where(x => x.BookingCancelId == id).Select(x => x.BookingRecordId).SingleOrDefault();//
                    model.BookingDetail = _dtlRep.GetHotelBooking(BookingRecordId);
                    model.CreatedOn = obj3.CreatedDate;
                    model.Remark = obj3.Remark;
                    model.IsProcessed = obj3.IsProcessed == null ? false : obj3.IsProcessed.Value;
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
        public HotelBookingCancelModel FillForCancel(long? id)
        {
            HotelBookDetailRepository _dtlRep = new HotelBookDetailRepository();
            HotelBookingCancelModel _model = new HotelBookingCancelModel();
            _model.BookingDetail = _dtlRep.GetHotelBooking(id);
            _model.Message = _model.BookingDetail.Message;
            if (_model.BookingDetail.Message.MsgNumber == 1)
            {
                _model.BookingRecordId = id.Value;
            }
            return _model;
        }
        public HotelBookingCancelModel FillCanceledDetail(long? id)
        {
            HotelBookDetailRepository _dtlRep = new HotelBookDetailRepository();
            HotelBookingCancelModel _model = new HotelBookingCancelModel();
            HotelMessageModel _msg = new HotelMessageModel();
            TravelPortalEntity.EntityModel _ent = new TravelPortalEntity.EntityModel();
            if (id != null)
            {
                var obj = _ent.Htl_BookingCancelDetail.Where(x => x.BookingCancelId == id).FirstOrDefault();
                if (obj != null)
                {
                    _model.BookingDetail = _dtlRep.GetHotelBooking(obj.BookingRecordId);
                    _model.CancellationCharge = obj.CancellationCharge == null ? 0 : obj.CancellationCharge.Value;
                    _model.CancelStatus = obj.CancellationStatus;
                    _model.CreatedOn = obj.CreatedDate;
                    _model.RefundableAmount = obj.RefundableAmount;
                    _model.Remark = obj.Remark;
                    _model.BookingRecordId = id.Value;
                    _model.BookingCancelId = obj.BookingCancelId;
                    _model.IsProcessed = obj.IsProcessed == null ? false : obj.IsProcessed.Value;
                    _msg.ActionMessage = "Success.";
                    _msg.MsgNumber = 1;
                    _msg.MsgStatus = false;
                    _msg.MsgType = 0;
                    _model.Message = _msg;
                }
                else
                {
                    _msg.ActionMessage = "Invalid Opetration.";
                    _msg.MsgNumber = 1000;
                    _msg.MsgStatus = true;
                    _msg.MsgType = 2;
                    _model.Message = _msg;
                }
            }
            else
            {
                _msg.ActionMessage = "Invalid Opetration.";
                _msg.MsgNumber = 1000;
                _msg.MsgStatus = true;
                _msg.MsgType = 2;
                _model.Message = _msg;
            }
            return _model;
        }
    }
}