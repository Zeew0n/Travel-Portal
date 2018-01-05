using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ATLTravelPortal.Areas.Bus.Models;
using ATLTravelPortal.Helpers.Pagination;
using TravelPortalEntity;
using ATLTravelPortal.Helpers;
using System.Web.Mvc;
using System.Text;

namespace ATLTravelPortal.Areas.Bus.Repository
{
    public class UnIssuedTicketRepository
    {
        int SNo = 1;
        TravelPortalEntity.EntityModel _ent = new TravelPortalEntity.EntityModel();
        BusMessageModel _act = new BusMessageModel();

        public List<BusPNRModel> List(int AgentId)
        {
            IEnumerable<Bus_PNRs> _res = null;

            if (AgentId != 0)
            {
                _res = _ent.Bus_PNRs.Where(x => x.AgentId == AgentId && (x.TicketStatusId == 1 || x.TicketStatusId == 7 || x.TicketStatusId == 14 || x.TicketStatusId == 28)).OrderByDescending(o => o.CreateDate);
            }
            else
            {
                _res = _ent.Bus_PNRs.Where(x => x.TicketStatusId == 1 || x.TicketStatusId == 7 || x.TicketStatusId == 14 || x.TicketStatusId == 28).OrderByDescending(o => o.CreateDate);
            }

            List<BusPNRModel> list = new List<BusPNRModel>();
            foreach (var item in _res)
            {
                BusPNRModel busPnrModel = new BusPNRModel()
                {
                    Sno = SNo++,
                    BusPNRId = item.BusPNRId,
                    ServiceProviderId = item.ServiceProviderId,
                    AgentId = item.AgentId,
                    RefrenceNumber = item.RefrenceNumber,
                    BusMasterId = item.BusMasterId,
                    BusMasterName = item.Bus_Master.BusMasterName,
                    BusCategoryId = item.BusCategoryId,
                    BusCategoryName = item.Bus_Categories.BusCategoryName,
                    BusNo = item.BusNo,
                    NoOfSeat = item.NoOfSeat,
                    TicketStatusId = item.TicketStatusId,
                    FromCityId = item.FromCityId,
                    FromCityName = item.Bus_Cities.BusCityName,
                    ToCityId = item.ToCityId,
                    ToCityName = item.Bus_Cities1.BusCityName,
                    DepartureDate = item.DepartureDate,
                    DepartureTime = item.DepartureTime,
                    ArrivalDate = item.ArrivalDate,
                    ArrivalTime = item.ArrivalTime,
                    InsurenceAmount = item.InsurenceAmount,
                    Remarks = item.Remarks,
                    FareRule = item.FareRule,
                    FacilityDetails = item.FacilityDetails,
                    Prefix = item.Prefix,
                    FullName = item.FullName,
                    EmailAddress = item.EmailAddress,
                    MobileNumber = item.MobileNumber,
                    PhoneNumber = item.PhoneNumber,
                    ContactAddress = item.ContactAddress,
                    Type = item.Type,
                };
                list.Add(busPnrModel);
            }
            return list;

        }

        public List<BusPNRModel> IssueList(DateTime? fromdate, DateTime? todate, int AgentId)
        {
            IEnumerable<Bus_PNRs> _res = null;

            if (AgentId != 0)
            {
                if (fromdate != null && todate != null)
                {
                    _res = _ent.Bus_PNRs.Where(x => x.AgentId == AgentId && (x.TicketStatusId == 4 || x.TicketStatusId == 16 || x.TicketStatusId == 19 || x.TicketStatusId == 32) && x.IssuedDate >= fromdate && x.IssuedDate <= todate).OrderByDescending(o => o.CreateDate);
                }
                else if (fromdate != null && todate == null)
                {
                    _res = _ent.Bus_PNRs.Where(x => x.AgentId == AgentId && (x.TicketStatusId == 4 || x.TicketStatusId == 16 || x.TicketStatusId == 19 || x.TicketStatusId == 32) && x.IssuedDate >= fromdate).OrderByDescending(o => o.CreateDate);
                }
                else
                {
                    _res = _ent.Bus_PNRs.Where(x => x.AgentId == AgentId && (x.TicketStatusId == 4 || x.TicketStatusId == 16 || x.TicketStatusId == 19 || x.TicketStatusId == 32)).OrderByDescending(o => o.CreateDate);
                }
            }
            else
            {
                if (fromdate != null && todate != null)
                {
                    _res = _ent.Bus_PNRs.Where(x => (x.TicketStatusId == 4 || x.TicketStatusId == 16 || x.TicketStatusId == 19 || x.TicketStatusId == 32) && x.IssuedDate >= fromdate && x.IssuedDate <= todate).OrderByDescending(o => o.CreateDate);
                }
                else if (fromdate != null && todate == null)
                {
                    _res = _ent.Bus_PNRs.Where(x => (x.TicketStatusId == 4 || x.TicketStatusId == 16 || x.TicketStatusId == 19 || x.TicketStatusId == 32) && x.IssuedDate >= fromdate).OrderByDescending(o => o.CreateDate);
                }
                else
                {
                    _res = _ent.Bus_PNRs.Where(x => x.TicketStatusId == 4 || x.TicketStatusId == 16 || x.TicketStatusId == 19 || x.TicketStatusId == 32).OrderByDescending(o => o.CreateDate);
                }
            }

            List<BusPNRModel> list = new List<BusPNRModel>();

            foreach (var item in _res)
            {
                BusPNRModel busPnrModel = new BusPNRModel()
                {
                    Sno = SNo++,
                    BusPNRId = item.BusPNRId,
                    ServiceProviderId = item.ServiceProviderId,
                    AgentId = item.AgentId,
                    RefrenceNumber = item.RefrenceNumber,
                    BusMasterId = item.BusMasterId,
                    BusMasterName = item.Bus_Master.BusMasterName,
                    BusCategoryId = item.BusCategoryId,
                    BusCategoryName = item.Bus_Categories.BusCategoryName,
                    BusNo = item.BusNo,
                    NoOfSeat = item.NoOfSeat,
                    TicketStatusId = item.TicketStatusId,
                    FromCityId = item.FromCityId,
                    FromCityName = item.Bus_Cities.BusCityName,
                    ToCityId = item.ToCityId,
                    ToCityName = item.Bus_Cities1.BusCityName,
                    DepartureDate = item.DepartureDate,
                    ArrivalDate = item.ArrivalDate,
                    ArrivalTime = item.ArrivalTime,
                    InsurenceAmount = item.InsurenceAmount,
                    Remarks = item.Remarks,
                    FareRule = item.FareRule,
                    FacilityDetails = item.FacilityDetails,
                    Prefix = item.Prefix,
                    FullName = item.FullName,
                    EmailAddress = item.EmailAddress,
                    MobileNumber = item.MobileNumber,
                    PhoneNumber = item.PhoneNumber,
                    ContactAddress = item.ContactAddress,
                    DepartureTime = item.DepartureTime,
                    Type = item.Type,
                    IssuedDate = item.IssuedDate,
                    IsOnline = item.IsOnline,
                    PNRNo = item.PNRNo

                };
                list.Add(busPnrModel);
            }
            return list;
        }

        public List<BusPNRModel> DistributorIssueList(DateTime? fromdate, DateTime? todate, int AgentId, int distributorID)
        {
            IEnumerable<Bus_PNRs> _res = null;

            if (AgentId != 0)
            {
                if (fromdate != null && todate != null)
                {
                    _res = from a in _ent.Bus_PNRs
                           join b in _ent.Agents on a.AgentId equals b.AgentId
                           where a.AgentId == AgentId
                                  && b.DistributorId == distributorID
                                  && (a.TicketStatusId == 4 || a.TicketStatusId == 16 || a.TicketStatusId == 19)
                                  && (a.IssuedDate >= fromdate && a.IssuedDate <= todate)
                           orderby a.IssuedDate
                           select a;

                    //_res = _ent.Bus_PNRs.Where(x => x.AgentId == AgentId  && (x.TicketStatusId == 4 || x.TicketStatusId == 16 || x.TicketStatusId == 19) && x.IssuedDate >= fromdate && x.IssuedDate <= todate).OrderByDescending(o => o.CreateDate);
                }
                else if (fromdate != null && todate == null)
                {
                    _res = from a in _ent.Bus_PNRs
                           join b in _ent.Agents on a.AgentId equals b.AgentId
                           where a.AgentId == AgentId
                                  && b.DistributorId == distributorID
                                  && (a.TicketStatusId == 4 || a.TicketStatusId == 16 || a.TicketStatusId == 19)
                                  && (a.IssuedDate >= fromdate)
                           orderby a.IssuedDate
                           select a;


                    //_res = _ent.Bus_PNRs.Where(x => x.AgentId == AgentId && (x.TicketStatusId == 4 || x.TicketStatusId == 16 || x.TicketStatusId == 19) && x.IssuedDate >= fromdate).OrderByDescending(o => o.CreateDate);
                }
                else
                {
                    _res = from a in _ent.Bus_PNRs
                           join b in _ent.Agents on a.AgentId equals b.AgentId
                           where a.AgentId == AgentId
                                  && b.DistributorId == distributorID
                                  && (a.TicketStatusId == 4 || a.TicketStatusId == 16 || a.TicketStatusId == 19)

                           orderby a.IssuedDate
                           select a;

                    //_res = _ent.Bus_PNRs.Where(x => x.AgentId == AgentId && (x.TicketStatusId == 4 || x.TicketStatusId == 16 || x.TicketStatusId == 19)).OrderByDescending(o => o.CreateDate);
                }
            }
            else
            {
                if (fromdate != null && todate != null)
                {

                    _res = from a in _ent.Bus_PNRs
                           join b in _ent.Agents on a.AgentId equals b.AgentId
                           where b.DistributorId == distributorID
                                  && (a.TicketStatusId == 4 || a.TicketStatusId == 16 || a.TicketStatusId == 19)
                                  && (a.IssuedDate >= fromdate && a.IssuedDate <= todate)
                           orderby a.IssuedDate
                           select a;


                    //_res = _ent.Bus_PNRs.Where(x => (x.TicketStatusId == 4 || x.TicketStatusId == 16 || x.TicketStatusId == 19) && x.IssuedDate >= fromdate && x.IssuedDate <= todate).OrderByDescending(o => o.CreateDate);
                }
                else if (fromdate != null && todate == null)
                {
                    _res = from a in _ent.Bus_PNRs
                           join b in _ent.Agents on a.AgentId equals b.AgentId
                           where
                                   b.DistributorId == distributorID
                                  && (a.TicketStatusId == 4 || a.TicketStatusId == 16 || a.TicketStatusId == 19)
                                  && (a.IssuedDate >= fromdate)
                           orderby a.IssuedDate
                           select a;

                    //_res = _ent.Bus_PNRs.Where(x => (x.TicketStatusId == 4 || x.TicketStatusId == 16 || x.TicketStatusId == 19) && x.IssuedDate >= fromdate).OrderByDescending(o => o.CreateDate);
                }
                else
                {

                    _res = from a in _ent.Bus_PNRs
                           join b in _ent.Agents on a.AgentId equals b.AgentId
                           where b.DistributorId == distributorID
                                  && (a.TicketStatusId == 4 || a.TicketStatusId == 16 || a.TicketStatusId == 19)
                           orderby a.IssuedDate
                           select a;

                    //_res = _ent.Bus_PNRs.Where(x => x.TicketStatusId == 4 || x.TicketStatusId == 16 || x.TicketStatusId == 19).OrderByDescending(o => o.CreateDate);
                }
            }

            List<BusPNRModel> list = new List<BusPNRModel>();

            foreach (var item in _res)
            {
                BusPNRModel busPnrModel = new BusPNRModel()
                {
                    Sno = SNo++,
                    BusPNRId = item.BusPNRId,
                    ServiceProviderId = item.ServiceProviderId,
                    AgentId = item.AgentId,
                    RefrenceNumber = item.RefrenceNumber,
                    BusMasterId = item.BusMasterId,
                    BusMasterName = item.Bus_Master.BusMasterName,
                    BusCategoryId = item.BusCategoryId,
                    BusCategoryName = item.Bus_Categories.BusCategoryName,
                    BusNo = item.BusNo,
                    NoOfSeat = item.NoOfSeat,
                    TicketStatusId = item.TicketStatusId,
                    FromCityId = item.FromCityId,
                    FromCityName = item.Bus_Cities.BusCityName,
                    ToCityId = item.ToCityId,
                    ToCityName = item.Bus_Cities1.BusCityName,
                    DepartureDate = item.DepartureDate,
                    ArrivalDate = item.ArrivalDate,
                    ArrivalTime = item.ArrivalTime,
                    InsurenceAmount = item.InsurenceAmount,
                    Remarks = item.Remarks,
                    FareRule = item.FareRule,
                    FacilityDetails = item.FacilityDetails,
                    Prefix = item.Prefix,
                    FullName = item.FullName,
                    EmailAddress = item.EmailAddress,
                    MobileNumber = item.MobileNumber,
                    PhoneNumber = item.PhoneNumber,
                    ContactAddress = item.ContactAddress,
                    DepartureTime = item.DepartureTime,
                    Type = item.Type,
                    IssuedDate = item.IssuedDate
                };
                list.Add(busPnrModel);
            }
            return list;
        }

        public List<BusPNRModel> BranchIssueList(DateTime? fromdate, DateTime? todate, int AgentId, int branchID)
        {
            IEnumerable<Bus_PNRs> _res = null;

            if (AgentId != 0)
            {
                if (fromdate != null && todate != null)
                {
                    _res = from a in _ent.Bus_PNRs
                           join b in _ent.Agents on a.AgentId equals b.AgentId
                           where a.AgentId == AgentId
                                  && b.BranchOfficeId == branchID
                                  && (a.TicketStatusId == 4 || a.TicketStatusId == 16 || a.TicketStatusId == 19)
                                  && (a.IssuedDate >= fromdate && a.IssuedDate <= todate)
                           orderby a.IssuedDate
                           select a;

                    //_res = _ent.Bus_PNRs.Where(x => x.AgentId == AgentId  && (x.TicketStatusId == 4 || x.TicketStatusId == 16 || x.TicketStatusId == 19) && x.IssuedDate >= fromdate && x.IssuedDate <= todate).OrderByDescending(o => o.CreateDate);
                }
                else if (fromdate != null && todate == null)
                {
                    _res = from a in _ent.Bus_PNRs
                           join b in _ent.Agents on a.AgentId equals b.AgentId
                           where a.AgentId == AgentId
                                  && b.BranchOfficeId == branchID
                                  && (a.TicketStatusId == 4 || a.TicketStatusId == 16 || a.TicketStatusId == 19)
                                  && (a.IssuedDate >= fromdate)
                           orderby a.IssuedDate
                           select a;


                    //_res = _ent.Bus_PNRs.Where(x => x.AgentId == AgentId && (x.TicketStatusId == 4 || x.TicketStatusId == 16 || x.TicketStatusId == 19) && x.IssuedDate >= fromdate).OrderByDescending(o => o.CreateDate);
                }
                else
                {
                    _res = from a in _ent.Bus_PNRs
                           join b in _ent.Agents on a.AgentId equals b.AgentId
                           where a.AgentId == AgentId
                                  && b.BranchOfficeId == branchID
                                  && (a.TicketStatusId == 4 || a.TicketStatusId == 16 || a.TicketStatusId == 19)

                           orderby a.IssuedDate
                           select a;

                    //_res = _ent.Bus_PNRs.Where(x => x.AgentId == AgentId && (x.TicketStatusId == 4 || x.TicketStatusId == 16 || x.TicketStatusId == 19)).OrderByDescending(o => o.CreateDate);
                }
            }
            else
            {
                if (fromdate != null && todate != null)
                {

                    _res = from a in _ent.Bus_PNRs
                           join b in _ent.Agents on a.AgentId equals b.AgentId
                           where b.BranchOfficeId == branchID
                                  && (a.TicketStatusId == 4 || a.TicketStatusId == 16 || a.TicketStatusId == 19)
                                  && (a.IssuedDate >= fromdate && a.IssuedDate <= todate)
                           orderby a.IssuedDate
                           select a;


                    //_res = _ent.Bus_PNRs.Where(x => (x.TicketStatusId == 4 || x.TicketStatusId == 16 || x.TicketStatusId == 19) && x.IssuedDate >= fromdate && x.IssuedDate <= todate).OrderByDescending(o => o.CreateDate);
                }
                else if (fromdate != null && todate == null)
                {
                    _res = from a in _ent.Bus_PNRs
                           join b in _ent.Agents on a.AgentId equals b.AgentId
                           where
                                   b.BranchOfficeId == branchID
                                  && (a.TicketStatusId == 4 || a.TicketStatusId == 16 || a.TicketStatusId == 19)
                                  && (a.IssuedDate >= fromdate)
                           orderby a.IssuedDate
                           select a;

                    //_res = _ent.Bus_PNRs.Where(x => (x.TicketStatusId == 4 || x.TicketStatusId == 16 || x.TicketStatusId == 19) && x.IssuedDate >= fromdate).OrderByDescending(o => o.CreateDate);
                }
                else
                {

                    _res = from a in _ent.Bus_PNRs
                           join b in _ent.Agents on a.AgentId equals b.AgentId
                           where b.BranchOfficeId == branchID
                                  && (a.TicketStatusId == 4 || a.TicketStatusId == 16 || a.TicketStatusId == 19)
                           orderby a.IssuedDate
                           select a;

                    //_res = _ent.Bus_PNRs.Where(x => x.TicketStatusId == 4 || x.TicketStatusId == 16 || x.TicketStatusId == 19).OrderByDescending(o => o.CreateDate);
                }
            }

            List<BusPNRModel> list = new List<BusPNRModel>();

            foreach (var item in _res)
            {
                BusPNRModel busPnrModel = new BusPNRModel()
                {
                    Sno = SNo++,
                    BusPNRId = item.BusPNRId,
                    ServiceProviderId = item.ServiceProviderId,
                    AgentId = item.AgentId,
                    RefrenceNumber = item.RefrenceNumber,
                    BusMasterId = item.BusMasterId,
                    BusMasterName = item.Bus_Master.BusMasterName,
                    BusCategoryId = item.BusCategoryId,
                    BusCategoryName = item.Bus_Categories.BusCategoryName,
                    BusNo = item.BusNo,
                    NoOfSeat = item.NoOfSeat,
                    TicketStatusId = item.TicketStatusId,
                    FromCityId = item.FromCityId,
                    FromCityName = item.Bus_Cities.BusCityName,
                    ToCityId = item.ToCityId,
                    ToCityName = item.Bus_Cities1.BusCityName,
                    DepartureDate = item.DepartureDate,
                    ArrivalDate = item.ArrivalDate,
                    ArrivalTime = item.ArrivalTime,
                    InsurenceAmount = item.InsurenceAmount,
                    Remarks = item.Remarks,
                    FareRule = item.FareRule,
                    FacilityDetails = item.FacilityDetails,
                    Prefix = item.Prefix,
                    FullName = item.FullName,
                    EmailAddress = item.EmailAddress,
                    MobileNumber = item.MobileNumber,
                    PhoneNumber = item.PhoneNumber,
                    ContactAddress = item.ContactAddress,
                    DepartureTime = item.DepartureTime,
                    Type = item.Type,
                    IssuedDate = item.IssuedDate
                };
                list.Add(busPnrModel);
            }
            return list;
        }

        public BusPNRModel GetBusPNRModelByBusPNRId(Int64? busPNRId)
        {
            var _res = _ent.Bus_PNRs.Where(x => x.BusPNRId == busPNRId).FirstOrDefault();
            BusPNRModel model = new BusPNRModel();
            if (_res != null)
            {
                model.BusPNRId = _res.BusPNRId;
                model.ServiceProviderId = _res.ServiceProviderId;
                model.AgentId = _res.AgentId;
                model.RefrenceNumber = _res.RefrenceNumber;
                model.BusMasterId = _res.BusMasterId;
                model.BusMasterName = _res.Bus_Master.BusMasterName;
                model.BusCategoryId = _res.BusCategoryId;
                model.BusCategoryName = _res.Bus_Categories.BusCategoryName;
                model.BusNo = _res.BusNo;
                model.NoOfSeat = _res.NoOfSeat;
                model.TicketStatusId = _res.TicketStatusId;
                model.FromCityId = _res.FromCityId;
                model.FromCityName = _res.Bus_Cities.BusCityName;
                model.ToCityId = _res.ToCityId;
                model.ToCityName = _res.Bus_Cities1.BusCityName;
                model.DepartureDate = _res.DepartureDate;
                model.DepartureTime = _res.DepartureTime;
                model.ArrivalDate = _res.ArrivalDate;
                model.ArrivalTime = _res.ArrivalTime;
                model.InsurenceAmount = _res.InsurenceAmount;
                model.Remarks = _res.Remarks;
                model.FareRule = _res.FareRule;
                model.FacilityDetails = _res.FacilityDetails;
                model.FullName = _res.FullName;
                model.Prefix = _res.Prefix;
                model.PhoneNumber = _res.PhoneNumber;
                model.ContactAddress = _res.ContactAddress;
                model.EmailAddress = _res.EmailAddress;
                model.MobileNumber = _res.MobileNumber;
                model.AgentAddress = _res.Agents.Address;
                model.AgentCode = _res.Agents.AgentCode;
                model.AgentEmial = _res.Agents.Email;
                model.AgentName = _res.Agents.AgentName;
                model.AgentPhone = _res.Agents.Phone;
                model.OperatorAddress = _res.Bus_Master.ContactAddress;
                model.OperatorContactPerson = _res.Bus_Master.ContactPerson;
                model.OperatorEmail = _res.Bus_Master.BusMasterEmial;
                model.OperatorMobileNo = _res.Bus_Master.Mobile;
                model.OperatorName = _res.Bus_Master.BusMasterName;
                model.OperatorPhone = _res.Bus_Master.Phone;
                model.FacilityDetails = _res.FacilityDetails;
                model.Type = _res.Type;
                model.Salutations = new SelectList(EnumHelper.GetEnumDescription(typeof(Salutation)).ToList(), "Name", "Description", _res.Prefix);
                model.BusCategories = new SelectList(new BusCategoryRepository().List(), "BusCategoryId", "BusCategoryName", _res.BusCategoryId);
                BusScheduleRepository busScheduleRepository = new BusScheduleRepository();
                model.BusOperators = new SelectList(busScheduleRepository.ddlMasterList(), "Value", "Text", _res.BusMasterId);
                model.BusTypes = new SelectList(busScheduleRepository.ddlTypeList(), "Value", "Text", _res.Type);


                model.FareRule = _res.FareRule;
                model.ItinearyNumber = "AH-" + _res.BusPNRId.ToString().PadLeft(5, '0');
                model.Type = _res.Type;
                model.BusNo = _res.BusNo;
                model.BookingDate = _res.CreateDate.ToShortDateString();
                model.HideServiceCharge = _res.HideServiceCharge == null ? false : _res.HideServiceCharge.Value;
                double _rate = 0;
                double _total = 0;
                double _serviceCharge = 0;
                double _grandTotal = 0;
                string _seatNo = "";
                string _pickUpPoints = "";
                string _passangerName = "";
                var passengers = _res.Bus_Passengers;

                double totalCalculatedDiscount = 0;
                double totalSummedDiscount = 0;
                double totalTranFee = 0;


                List<BusPassengerModel> passList = new List<BusPassengerModel>();
                List<string> PassNameList = new List<string>();
                List<string> PickUpPointsList = new List<string>();
                foreach (var pax in passengers)
                {
                    totalCalculatedDiscount = pax.DiscountAmount > 0 ? pax.DiscountAmount : 0;
                    totalTranFee = (pax.DiscountAmount < 0 ? Math.Abs(pax.DiscountAmount) : 0);
                    if (_res.isBranchByPassDeal == false)
                    {
                        totalCalculatedDiscount = pax.BranchDeal < 0 ? Math.Abs(pax.BranchDeal) : 0;
                        totalTranFee += (pax.BranchDeal > 0 ? Math.Abs(pax.BranchDeal) : 0);
                    }
                    if (_res.isDistributorByPassDeal == false)
                    {
                        totalCalculatedDiscount = pax.DistributorDeal < 0 ? Math.Abs(pax.DistributorDeal) : 0;
                        totalTranFee += (pax.DistributorDeal > 0 ? Math.Abs(pax.DistributorDeal) : 0);
                    }


                    if (model.HideServiceCharge == true)
                    {
                        _total = _total + (pax.Fare + pax.Markup + (pax.ServiceCharge == null ? 0 : pax.ServiceCharge.Value));
                        if (_rate < 1) { _rate = (pax.Fare + pax.Markup - totalCalculatedDiscount + (pax.ServiceCharge == null ? 0 : pax.ServiceCharge.Value)); }
                    }
                    else
                    {
                        _total = _total + pax.Fare + pax.Markup; _serviceCharge = _serviceCharge + (pax.ServiceCharge == null ? 0 : pax.ServiceCharge.Value);
                        if (_rate < 1) { _rate = pax.Fare + pax.Markup - totalCalculatedDiscount; }
                    }


                    if (_seatNo.Trim() != "")
                    {
                        _seatNo = _seatNo + "," + pax.SeatNoalias;
                    }
                    else { _seatNo = pax.SeatNoalias == null ? "" : pax.SeatNoalias; }
                    if (_pickUpPoints.Trim() != "")
                    {
                        if (pax.PickupPoint != null)
                        {
                            if (!PickUpPointsList.Contains(pax.PickupPoint.Trim()))
                            {
                                //_pickUpPoints = _pickUpPoints + "," + pax.PickupPoint !=null?pax.PickupPoint.Trim():string.Empty;
                                string formatedText = pax.PickupPoint != null ? pax.PickupPoint.Trim() : string.Empty;
                                _pickUpPoints = _pickUpPoints + "," + formatedText;
                                PickUpPointsList.Add(pax.PickupPoint.Trim());
                            }
                        }
                    }
                    else
                    {
                        _pickUpPoints = pax.PickupPoint == null ? "" : pax.PickupPoint; PickUpPointsList.Add(pax.PickupPoint != null ? pax.PickupPoint.Trim() : string.Empty);
                    }
                    if (_passangerName.Trim() != "")
                    {
                        if (pax.PassengerName != null)
                        {
                            if (!PassNameList.Contains(pax.PassengerName.Trim()))
                            {
                                string formatedText = pax.PassengerName != null ? pax.PassengerName.Trim() : string.Empty;
                                _passangerName = _passangerName + "," + formatedText;

                                PassNameList.Add(pax.PassengerName.Trim());
                            }
                        }
                    }
                    else
                    {
                        _passangerName = pax.PassengerName == null ? "" : pax.PassengerName;
                        PassNameList.Add(pax.PassengerName.Trim());
                    }
                    BusPassengerModel busPassengerModel = new BusPassengerModel()
                    {
                        BusPassengerId = pax.BusPassengerId,
                        BusPNRId = pax.BusPNRId,
                        PassengerName = pax.PassengerName,
                        MobileNumber = pax.MobileNumber,
                        TicketStatusId = pax.TicketStatusId.Value,
                        StatusName = pax.TicketStatus.ticketStatusName,
                        TicketNumber = pax.TicketNumber,
                        SeatNumber = pax.SeatNoalias,
                        PickupPoint = pax.PickupPoint,
                        Fare = pax.Fare + pax.Markup,
                        Markup = pax.Markup,
                        TaxAmount = pax.TaxAmount,

                        CommissionAmount = pax.CommissionAmount,
                        DiscountAmount = pax.DiscountAmount
                    };
                    totalSummedDiscount += totalCalculatedDiscount;
                    passList.Add(busPassengerModel);
                }
                model.DisRate = _rate - totalTranFee;
                model.TotalAmount = _total - totalSummedDiscount + totalTranFee;
                model.Passengers = passList;
                model.SeatNumber = _seatNo;
                model.ServiceCharge = _serviceCharge;
                model.GrandTotal = _total + _serviceCharge - totalSummedDiscount + totalTranFee; ;
                model.PickUpPouints = _pickUpPoints;
                model.PassengerName = _passangerName;
                model.AvilableBalance = AvilableBalance(_res.AgentId);
                _act.ActionMessage = "Success";
                _act.MsgNumber = 0;
                _act.ErrSource = "DataBase";
                _act.MsgType = 3;
                _act.MsgStatus = false;
            }
            else
            {
                _act.ActionMessage = String.Format(Resources.Message.InvalidOperation, "Itineary");
                _act.MsgNumber = 1005;
                _act.ErrSource = "DataBase";
                _act.MsgType = 3;
                _act.MsgStatus = true;
            }
            model.Message = _act;
            return model;
        }

        public AvailableBalanceViewModel AvilableBalance(int AgentId)
        {
            var AvailableBalanceResult = _ent.Air_GetAvailableBalance(AgentId).ToList();
            var Balanceviewmodel = new AvailableBalanceViewModel();
            /// For NPR balance
            ///  //Currency
            Balanceviewmodel.CurrencyNPR = AvailableBalanceResult.ElementAtOrDefault(0).CurrencyCode;
            Balanceviewmodel.CreditLimitNPR = AvailableBalanceResult.ElementAtOrDefault(0).CreditLimit;
            Balanceviewmodel.CurrentBalanceNPR = AvailableBalanceResult.ElementAtOrDefault(0).Amount;

            /// For USD balance
            Balanceviewmodel.CurrencyUSD = AvailableBalanceResult.ElementAtOrDefault(1).CurrencyCode == "USD" ? AvailableBalanceResult.ElementAtOrDefault(1).CurrencyCode : "";
            Balanceviewmodel.CreditLimitUSD = AvailableBalanceResult.ElementAtOrDefault(1).CurrencyCode == "USD" ? AvailableBalanceResult.ElementAtOrDefault(1).CreditLimit : double.Parse("");
            Balanceviewmodel.CurrentBalanceUSD = AvailableBalanceResult.ElementAtOrDefault(1).CurrencyCode == "USD" ? AvailableBalanceResult.ElementAtOrDefault(1).Amount : double.Parse("");

            /// For INR balance
            Balanceviewmodel.CurrencyINR = AvailableBalanceResult.ElementAtOrDefault(2).CurrencyCode == "INR" ? AvailableBalanceResult.ElementAtOrDefault(2).CurrencyCode : "";
            Balanceviewmodel.CreditLimitINR = AvailableBalanceResult.ElementAtOrDefault(2).CurrencyCode == "INR" ? AvailableBalanceResult.ElementAtOrDefault(2).CreditLimit : double.Parse("");
            Balanceviewmodel.CurrentBalanceINR = AvailableBalanceResult.ElementAtOrDefault(2).CurrencyCode == "INR" ? AvailableBalanceResult.ElementAtOrDefault(2).Amount : double.Parse("");


            if (Balanceviewmodel.CurrentBalanceNPR == null)
                Balanceviewmodel.CurrentBalanceNPR = 0;


            double minBalance = Balanceviewmodel.CreditLimitNPR.Value * 10 * 0.01;//10 % of Credit limit
            if (Balanceviewmodel.CurrentBalanceNPR <= minBalance)//|| Balanceviewmodel.Amount==0)
                Balanceviewmodel.isLowBalanceNPR = true;
            else
                Balanceviewmodel.isLowBalanceNPR = false;

            double minBalanceUSD = Balanceviewmodel.CreditLimitUSD.Value * 10 * 0.01;//10 % of Credit limit
            if (Balanceviewmodel.CurrentBalanceUSD <= minBalance)//|| Balanceviewmodel.Amount==0)
                Balanceviewmodel.isLowBalanceUSD = true;
            else
                Balanceviewmodel.isLowBalanceUSD = false;

            double minBalanceINR = Balanceviewmodel.CreditLimitINR.Value * 10 * 0.01;//10 % of Credit limit
            if (Balanceviewmodel.CurrentBalanceINR <= minBalanceINR)//|| Balanceviewmodel.Amount==0)
                Balanceviewmodel.isLowBalanceINR = true;
            else
                Balanceviewmodel.isLowBalanceINR = false;
            return Balanceviewmodel;

        }

        public bool UpdateBusPNRModel(BusPNRModel model)
        {
            Bus_PNRs bus_PNRs = _ent.Bus_PNRs.Where(x => x.BusPNRId == model.BusPNRId).FirstOrDefault();
            //int _discountRate = int.Parse(System.Configuration.ConfigurationManager.AppSettings["BusDiscount"].ToString());
            bus_PNRs.Prefix = model.Prefix;
            bus_PNRs.FullName = model.FullName;
            bus_PNRs.PhoneNumber = model.PhoneNumber;
            bus_PNRs.ContactAddress = model.ContactAddress;
            bus_PNRs.MobileNumber = model.MobileNumber;
            bus_PNRs.EmailAddress = model.EmailAddress;

            bus_PNRs.Type = model.Type;
            bus_PNRs.BusCategoryId = model.BusCategoryId;
            bus_PNRs.BusMasterId = model.BusMasterId;
            bus_PNRs.DepartureDate = model.DepartureDate;
            bus_PNRs.DepartureTime = model.DepartureTime;
            bus_PNRs.BusNo = model.BusNo;
            bus_PNRs.HideServiceCharge = model.HideServiceCharge;

            _ent.ApplyCurrentValues(bus_PNRs.EntityKey.EntitySetName, bus_PNRs);

            if (bus_PNRs.Bus_Passengers != null)
            {
                foreach (var pax in model.Passengers)
                {
                    Bus_Passengers paxToUpdate = _ent.Bus_Passengers.Where(x => x.BusPassengerId == pax.BusPassengerId).FirstOrDefault();
                    if (paxToUpdate.IsPrimary)
                    {
                        paxToUpdate.PassengerName = model.Prefix + " " + model.FullName;
                        paxToUpdate.MobileNumber = model.MobileNumber;
                        paxToUpdate.Fare = pax.Fare - paxToUpdate.Markup;
                        paxToUpdate.PickupPoint = pax.PickupPoint;
                        paxToUpdate.TicketNumber = pax.TicketNumber;
                        paxToUpdate.SeatNoalias = pax.SeatNumber;
                        paxToUpdate.IsPrimary = true;
                        //paxToUpdate.DiscountAmount = (pax.Fare * _discountRate) / 100;
                        _ent.ApplyCurrentValues(paxToUpdate.EntityKey.EntitySetName, paxToUpdate);
                    }
                    else
                    {
                        paxToUpdate.PassengerName = pax.PassengerName == null ? "" : pax.PassengerName;
                        paxToUpdate.MobileNumber = pax.MobileNumber == null ? "" : pax.MobileNumber;
                        paxToUpdate.Fare = pax.Fare - paxToUpdate.Markup;
                        paxToUpdate.PickupPoint = pax.PickupPoint;
                        paxToUpdate.TicketNumber = pax.TicketNumber;
                        paxToUpdate.SeatNoalias = pax.SeatNumber;
                        //paxToUpdate.DiscountAmount = (pax.Fare * _discountRate) / 100;
                        _ent.ApplyCurrentValues(paxToUpdate.EntityKey.EntitySetName, paxToUpdate);
                    }
                }
            }
            _ent.SaveChanges();
            return true;
        }

        public bool IssueBusTickets(Int64 busPnrId, int appUserId)
        {
            try
            {

                _ent.Bus_IssueTickets(busPnrId, appUserId);

                //change status here--
                var changestatusobj = _ent.Bus_PNRs.FirstOrDefault(x => x.BusPNRId == busPnrId);
                if (changestatusobj != null)
                {
                    changestatusobj.TicketStatusId = 4;
                    _ent.ApplyCurrentValues(changestatusobj.EntityKey.EntitySetName, changestatusobj);

                    if (changestatusobj.Bus_Passengers != null && changestatusobj.Bus_Passengers.Any())
                    {
                        foreach (var item in changestatusobj.Bus_Passengers)
                        {
                            item.TicketStatusId = 4;
                            _ent.ApplyCurrentValues(item.EntityKey.EntitySetName, item);
                        }
                    }
                    _ent.SaveChanges();
                }
                //=========================
            }

            catch
            {
                return false;
            }
            return true;
        }

        public void CanCelBusTickets(Int64 busPnrId, int appUserId)
        {
            var result = _ent.Bus_PNRs.Where(x => x.BusPNRId == busPnrId).FirstOrDefault();
            if (result != null)
            {
                result.TicketStatusId = 2;
                result.UpdatedBy = appUserId;
                _ent.ApplyCurrentValues(result.EntityKey.EntitySetName, result);
                _ent.SaveChanges();

            }

        }

        public string CreateMessage(BusPNRModel model, string MobileNo)
        {
            string _operatorName = model.BusMasterName.IndexOf('(') < 0 ? model.BusMasterName : model.BusMasterName.Substring(0, model.BusMasterName.IndexOf('('));
            _operatorName = _operatorName.Length > 30 ? _operatorName.Substring(0, 30) : _operatorName;
            string _fromCityName = model.FromCityName.IndexOf('(') < 0 ? model.FromCityName : model.FromCityName.Substring(0, model.FromCityName.IndexOf('('));
            _fromCityName = _fromCityName.Length > 13 ? _fromCityName.Substring(0, 13) : _fromCityName;
            string _toCityName = model.ToCityName.IndexOf('(') < 0 ? model.ToCityName : model.ToCityName.Substring(0, model.ToCityName.IndexOf('('));
            _toCityName = _toCityName.Length > 13 ? _toCityName.Substring(0, 13) : _toCityName;
            string _category = model.BusCategoryName.IndexOf('(') < 0 ? model.BusCategoryName : model.BusCategoryName.Substring(0, model.BusCategoryName.IndexOf('('));
            _category = _category.Length > 10 ? _category.Substring(0, 10) : _category;
            string _type = model.Type.IndexOf('(') < 0 ? model.ToCityName : model.Type.Substring(0, model.Type.IndexOf('('));
            _type = _type.Length > 5 ? _type.Substring(0, 5) : _type;
            string _busNo = model.BusNo.Length > 20 ? model.BusNo.Substring(0, 20) : model.BusNo;
            string _seatNumber = model.SeatNumber.Length > 23 ? model.SeatNumber.Substring(0, 23) : model.SeatNumber;
            //string _seatNumber = model.SeatNumber;
            StringBuilder message = new StringBuilder();
            message.Append(_operatorName + "\r\n");
            message.Append(_fromCityName + "-" + _toCityName + "\r\n");
            message.Append(model.DepartureDate.ToShortDateString() + "\r\n");
            message.Append(model.DepartureTime.Hours + ":" + model.DepartureTime.Minutes + "\r\n");
            message.Append(_category + "\r\n");
            message.Append(_type + "\r\n");
            message.Append("ID:" + model.ItinearyNumber + "\r\n");
            message.Append("Bus:" + _busNo + "\r\n");
            message.Append("Seat:" + _seatNumber + "\r\n");
            message.Append("Ph:" + MobileNo);
            return message.ToString();
        }


        public BusMessageModel CancelOnlineIssues(string pnrcode)
        {
            BusMessageModel _msg = new BusMessageModel();
            try
            {
                using (System.Transactions.TransactionScope ts = new System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.Required))
                {
                    //remove status from local database

                    var OnlineBusPnr = _ent.Bus_PNRs.FirstOrDefault(x => x.PNRNo == pnrcode);
                    if (OnlineBusPnr == null)
                    {
                        _msg.ActionMessage = "Cancellation Failed !!!!";
                        _msg.ErrSource = "Data";
                        _msg.MsgNumber = 1001;
                        _msg.MsgType = 3;
                        _msg.MsgStatus = true;
                        return _msg;
                    }
                    BusApi.BusApiClient _api = new BusApi.BusApiClient();
                    BusApi.IssueCancelRequest _req = new BusApi.IssueCancelRequest()
                    {
                        Auth = BusGeneralProvider.AAuth,
                        Remarks = "Issue Cancelled.",
                        PNRCode = pnrcode,
                        PassengerId = null,
                        IsSingleCancel = false
                    };

                    var _spiRes = _api.CancelIssued(_req);

                    if (_spiRes.Message.Number == 0)
                    {
                        OnlineBusPnr.TicketStatusId = 12;
                        _ent.ApplyCurrentValues(OnlineBusPnr.EntityKey.EntitySetName, OnlineBusPnr);
                        // change status of bus_passengers table
                        if (OnlineBusPnr.Bus_Passengers != null)
                        {
                            foreach (var itm in OnlineBusPnr.Bus_Passengers)
                            {
                                itm.TicketStatusId = 12;
                                _ent.ApplyCurrentValues(itm.EntityKey.EntitySetName, itm);
                            }
                        }
                        _ent.Bus_CancelTickets(OnlineBusPnr.BusPNRId, 0, 0, false, ATLTravelPortal.Repository.GeneralRepository.LoggedUserId(), 0);
                        _ent.SaveChanges();
                        ts.Complete(); _msg.ActionMessage = "Cancellation success !! PNR (" + pnrcode + ")";
                        _msg.ErrSource = "Data";
                        _msg.MsgNumber = 1001;
                        _msg.MsgType = 0;
                        _msg.MsgStatus = true;
                        return _msg;

                    }
                    else
                    {
                        _msg.ActionMessage = "Cancellation Failed !!!!";
                        _msg.ErrSource = "Data";
                        _msg.MsgNumber = 1001;
                        _msg.MsgType = 3;
                        _msg.MsgStatus = true;
                        return _msg;
                    }

                }

            }
            catch
            {
                _msg.ActionMessage = "Cancellation Failed !!!!";
                _msg.ErrSource = "Data";
                _msg.MsgNumber = 1001;
                _msg.MsgType = 3;
                _msg.MsgStatus = true;
                return _msg;
            }
        }

        public IPagedList<BusPNRModel> GetPagedList(int? page, int agentId)
        {
            int currentPageIndex = page.HasValue ? page.Value : 1;
            return List(agentId).ToPagedList(currentPageIndex, BusGeneralRepository.DefaultPageSize);
        }

        public IPagedList<BusPNRModel> GetPagedIssueList(int? page, DateTime? fromDate, DateTime? toDate, int agentId)
        {
            int currentPageIndex = page.HasValue ? page.Value : 1;
            return IssueList(fromDate, toDate, agentId).ToPagedList(currentPageIndex, BusGeneralRepository.DefaultPageSize);
        }


        public IPagedList<BusPNRModel> GetBranchPagedIssueList(int? page, DateTime? fromDate, DateTime? toDate, int agentId, int branchID)
        {
            int currentPageIndex = page.HasValue ? page.Value : 1;
            return BranchIssueList(fromDate, toDate, agentId, branchID).ToPagedList(currentPageIndex, BusGeneralRepository.DefaultPageSize);
        }

        public IPagedList<BusPNRModel> GetDistributorPagedIssueList(int? page, DateTime? fromDate, DateTime? toDate, int agentId, int distributorID)
        {
            int currentPageIndex = page.HasValue ? page.Value : 1;
            return DistributorIssueList(fromDate, toDate, agentId, distributorID).ToPagedList(currentPageIndex, BusGeneralRepository.DefaultPageSize);
        }
    }
}