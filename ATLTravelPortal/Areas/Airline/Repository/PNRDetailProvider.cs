using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using ATLTravelPortal.Areas.Airline.Models;
using TravelPortalEntity;
using ATLTravelPortal.Helpers;
using ATLTravelPortal.Repository;


namespace ATLTravelPortal.Areas.Airline.Repository
{
    public class PNRDetailProvider
    {
        EntityModel _ent = new EntityModel();

        public PNRsModel GetPNRDetail(int PNRId)
        {
            var result = _ent.PNRs.Where(x => x.PNRId == PNRId).FirstOrDefault();

            if (result == null)
                return GetIndianLccPNRDetail(PNRId);


            var CreatedBystring = _ent.UsersDetails.Where(x => x.AppUserId == result.CreatedBy).FirstOrDefault();
            PNRsModel model = new PNRsModel();
            if (result != null)
            {
                model = new PNRsModel
                {
                    AgentId = result.AgentId,
                    //ATLTTL = (DateTime)?result.ATLTTL,
                    ContactNumber = result.ContactNumber,
                    BookedBy = CreatedBystring.FullName,
                    CreatedDate = result.CreatedDate,
                    DispatchedDate = result.DispatchedDate,
                    EmailAddress = result.EmailAddress,
                    FirstName = result.FirstName,
                    GDSRefrenceNumber = result.GDSRefrenceNumber,
                    IssuedDate = result.IssuedDate,
                    LastName = result.LastName,
                    MiddleName = result.MiddleName,
                    PNRId = result.PNRId,
                    Prefix = result.Prefix,
                    ServiceProviderId = result.ServiceProviderId,
                    TicketStatusId = result.TicketStatusId,
                    TTL = result.TTL,
                    UpdatedBy = result.UpdatedBy,
                    UpdatedDate = result.UpdatedDate,

                    TicketStatus = result.TicketStatus.ticketStatusName
                    //BookedBy = result..

                };
            }
            return model;
        }


        public IEnumerable<PNRSegmentsModel> GetPNRSegmentList(int PNRId)
        {
            List<PNRSegmentsModel> model = new List<PNRSegmentsModel>();
            var result = _ent.PNRSegments.Where(x => x.PNRId == PNRId).ToList();

            if (result.Count == 0)
                return GetIndianLccPNRSegmentList(PNRId);

            foreach (var item in result)
            {
                PNRSegmentsModel obj = new PNRSegmentsModel
                {
                    AirlineId = item.AirlineId,
                    AirlineRefrenceNumber = item.AirlineRefrenceNumber,
                    ArriveCityId = item.ArriveCityId,
                    ArriveDate = item.ArriveDate,
                    ArriveTime = item.ArriveTime,
                    BIC = item.BIC,
                    CreatedBy = item.CreatedBy,
                    CreatedDate = item.CreatedDate,
                    DepartCityId = item.DepartCityId,
                    DepartDate = item.DepartDate,
                    DepartTime = item.DepartTime,
                    EndTerminal = item.EndTerminal,
                    FlightNumber = item.FlightNumber,
                    PNRId = item.PNRId,
                    SectorId = item.SectorId,
                    SegmentId = item.SegmentId,
                    StartTerminal = item.StartTerminal,
                    UpdatedBy = item.UpdatedBy,
                    UpdatedDate = item.UpdatedDate,

                    AirlineCode = item.Airlines.AirlineCode,
                    ArriveCityName = item.AirlineCities1.CityName,
                    DepartCityName = item.AirlineCities2.CityName,

                };
                model.Add(obj);
            }
            return model.AsEnumerable();


        }


        public IEnumerable<PassengersModel> GetPassengersList(int PNRId)
        {

            List<PassengersModel> model = new List<PassengersModel>();
            var result = _ent.Passengers.Where(x => x.PNRId == PNRId).Where(x => x.isDeleted == false).ToList();

            if (result.Count == 0)
                return GetIndianLccPassengersList(PNRId);

            foreach (var item in result)
            {
                PassengersModel obj = new PassengersModel
                {
                    AirlineId = item.AirlineId,

                    CreatedBy = item.CreatedBy,
                    CreatedDate = item.CreatedDate,
                    DOB = item.DOB,
                    DOCA = item.DOCA,
                    DOCO = item.DOCO,
                    DOCS = item.DOCS,
                    EmailAddress = item.EmailAddress,

                    FirstName = item.FirstName,
                    FrequentFlierNo = item.FrequentFlierNo,

                    LastName = item.LastName,

                    MiddleName = item.MiddleName,
                    MobileNumber = item.MobileNumber,
                    Nationality = item.Nationality,
                    OSI = item.OSI,
                    OtherSSRCode = item.OtherSSRCode,
                    PassengerId = item.PassengerId,
                    PassengerTypeId = item.PassengerTypeId,
                    PassportExpDate = item.PassportExpDate,
                    PassportNumber = item.PassportNumber,
                    PNRId = item.PNRId,
                    Prefix = item.Prefix,

                    SSR = item.SSR,

                    TicketNumber = item.TicketNumber,
                    TicketStatusId = item.TicketStatusId,
                    UpdatedBy = item.UpdatedBy,
                    UpdatedDate = item.UpdatedDate,

                    Fare = item.Fare + item.MarkupAmount,
                    FSC = item.FSC,
                    TaxAmount = item.TaxAmount,
                    CommissionAmount = item.DiscountAmount,
                    ServiceCharge = Math.Round(item.ServiceCharge),

                    MarkupAmount = item.MarkupAmount,

                    PassengerType = item.PassengerTypes.PassengerTypeName,


                    DiscountAmount = item.DiscountAmount




                };
                model.Add(obj);
            }
            return model.AsEnumerable();



        }
        public FareModel GetFare(int PNRId)
        {
            FareModel model = new FareModel();
            TBO_MasterPNRs newResult = null;

            var result = _ent.PNRs.Where(x => x.PNRId == PNRId).FirstOrDefault();
            if (result != null)
            {
                int TicketStatusId = result.TicketStatusId;
                var collection = _ent.Passengers.Where(x => x.PNRId == PNRId).ToList();
                double Fare = 0;
                double discount = 0;
                double Tax = 0;
                double ServiceCharge = 0;
                foreach (var item in collection)
                {
                    Fare += item.Fare + item.MarkupAmount + item.FSC;
                    discount += item.DiscountAmount;
                    Tax += item.TaxAmount;
                    ServiceCharge += item.ServiceCharge;
                }

                model.Fare = Fare;
                model.Discount = discount;
                model.Tax = Tax;
                model.ServiceCharge = ServiceCharge;
            }
            else if ((newResult = _ent.TBO_MasterPNRs.Where(x => x.MPNRId == PNRId).FirstOrDefault()) != null)
            {

                int TicketStatusId = newResult.TicketStatusId;
                var collection = _ent.TBO_PNRTickets.Where(x => x.MPNRId == PNRId).ToList();
                double Fare = 0;
                double discount = 0;
                double Tax = 0;
                double ServiceCharge = 0;
                foreach (var item in collection)
                {
                    Fare += item.BaseFare + item.MarkupAmount + item.FSC;
                    discount += item.DiscountAmount;
                    Tax += item.SellingTax;
                    ServiceCharge += item.ServiceCharge;
                }

                model.Fare = Fare;
                model.Discount = discount;
                model.Tax = Tax;
                model.ServiceCharge = ServiceCharge;

            }




            //if (TicketStatusId == 12)
            // {
            //     Int64 VoucherNo = _ent.GL_VoucherNumber.Where(x => x.TranId == PNRId).OrderByDescending(x=>x.VoucherNumber).FirstOrDefault().VoucherNumber;
            //     int Agentid = _ent.PNRs.Where(x => x.PNRId == PNRId).FirstOrDefault().AgentId;
            //     Int64 AgentLedgerId = _ent.GL_Ledgers.Where(x => x.AccTypeId == 2 && x.Id == Agentid).FirstOrDefault().LedgerId;

            //     if(_ent.GL_Transactions.Where(x => x.VoucherNo == VoucherNo && x.LedgerId == AgentLedgerId && x.Dr_Cr == "D")!=null)
            //         model.Fare = _ent.GL_Transactions.Where(x => x.VoucherNo == VoucherNo && x.LedgerId == AgentLedgerId && x.Dr_Cr == "D").FirstOrDefault().Amount;
            //     if(_ent.GL_Transactions.Where(x => x.VoucherNo == VoucherNo && x.LedgerId == AgentLedgerId && x.Dr_Cr == "C").FirstOrDefault()!=null)
            //         model.Discount = _ent.GL_Transactions.Where(x => x.VoucherNo == VoucherNo && x.LedgerId == AgentLedgerId && x.Dr_Cr == "C").FirstOrDefault().Amount;
            // }
            return model;

        }

        public bool isAlreadyCanceledPNR(Int64 PNRId)
        {
            int TicketStatusId = _ent.PNRs.Where(x => x.PNRId == PNRId).FirstOrDefault().TicketStatusId;
            if (TicketStatusId == 13)
                return true;
            else
                return false;
        }

        public void CancelPNR(Int64 PNRId, int userid)
        {
            PNRs result = _ent.PNRs.Where(x => x.PNRId == PNRId).FirstOrDefault();
            if (result != null)
            {
                result.TicketStatusId = 2;
                result.UpdatedBy = userid;
                result.UpdatedDate = GeneralRepository.CurrentDateTime();

                _ent.ApplyCurrentValues(result.EntityKey.EntitySetName, result);
                _ent.SaveChanges();
            }
            else
            {
                TBO_MasterPNRs tboResult = _ent.TBO_MasterPNRs.Where(x => x.MPNRId == PNRId).FirstOrDefault();
                if (tboResult != null)
                {
                    tboResult.TicketStatusId = 2;
                    tboResult.UpdatedBy = userid;
                    tboResult.UpdatedDate = GeneralRepository.CurrentDateTime();

                    _ent.ApplyCurrentValues(tboResult.EntityKey.EntitySetName, tboResult);
                    _ent.SaveChanges();
                }
            }
        }


        /////////////////////////////////For IndianLcc and Domestic//////////////////////////////////////////
        public PNRsModel GetIndianLccPNRDetail(int PNRId)
        {
            var result = _ent.TBO_MasterPNRs.Where(x => x.MPNRId == PNRId).FirstOrDefault();
            var CreatedBystring = _ent.UsersDetails.Where(x => x.AppUserId == result.CreatedBy).FirstOrDefault();

            PNRsModel model = new PNRsModel();
            if (result != null)
            {
                model = new PNRsModel
                {
                    AgentId = result.AgentId,
                    ContactNumber = result.Phone,
                    BookedBy = CreatedBystring.FullName,
                    CreatedDate = result.CreatedDate,
                    EmailAddress = result.Email,
                    FirstName = result.FirstName,
                    GDSRefrenceNumber = result.TBO_PNRs.FirstOrDefault().RecLoc,
                    LastName = result.LastName,
                    MiddleName = result.MiddleName,
                    PNRId = result.MPNRId,
                    Prefix = result.Prefix,
                    ServiceProviderId = result.ServiceProviderId,
                    TicketStatusId = result.TicketStatusId,
                    UpdatedBy = result.UpdatedBy,
                    UpdatedDate = result.UpdatedDate,

                    TicketStatus = result.TicketStatus.ticketStatusName


                };
            }
            return model;
        }

        public IEnumerable<PNRSegmentsModel> GetIndianLccPNRSegmentList(int PNRId)
        {

            List<PNRSegmentsModel> model = new List<PNRSegmentsModel>();
            var result = _ent.TBO_PNRsegments.Where(x => x.MPNRId == PNRId);
            foreach (var item in result)
            {
                PNRSegmentsModel obj = new PNRSegmentsModel
                {
                    AirlineId = item.AirlineId,
                    AirlineRefrenceNumber = item.AirlineRefNumber,
                    ArriveCityId = item.ArrivalCityId,
                    ArriveDate = item.ArrivalDate,
                    ArriveTime = item.ArrivalTime,
                    BIC = item.BIC,
                    DepartCityId = item.DepartCityId,
                    DepartDate = item.DepartDate,
                    DepartTime = item.DepartTime,
                    EndTerminal = item.EndTerminal,
                    FlightNumber = item.FlightNumber,
                    PNRId = item.PNRId,
                    SectorId = item.SectorId,
                    SegmentId = item.SegmentId,
                    StartTerminal = item.StartTerminal,
                    UpdatedBy = item.UpdatedBy,
                    UpdatedDate = item.UpdatedDate,
                    AirlineCode = item.Airlines.AirlineCode,
                    ArriveCityName = item.AirlineCities.CityName,
                    DepartCityName = item.AirlineCities1.CityName,

                };
                model.Add(obj);
            }
            return model.AsEnumerable();

        }

        public IEnumerable<PassengersModel> GetIndianLccPassengersList(int PNRId)
        {

            List<PassengersModel> model = new List<PassengersModel>();
            var result = _ent.TBO_Passengers.Where(x => x.MPNRId == PNRId);
            foreach (var item in result)
            {
                PassengersModel obj = new PassengersModel
                {
                    AirlineId = item.FFAirline,
                    DOB = item.DOB,
                    DOCA = item.DOCA,
                    DOCO = item.DOCO,
                    DOCS = item.DOCS,
                    EmailAddress = item.Email,
                    FirstName = item.FirstName,
                    FrequentFlierNo = item.FFNumber,
                    LastName = item.LastName,
                    MiddleName = item.MiddleName,
                    Nationality = item.Nationality,
                    PassengerId = item.PassengerId,
                    PassportExpDate = item.PassportExpDate,
                    PassportNumber = item.PassportNumber,
                    PNRId = item.PNRId,
                    Prefix = item.Prefix,
                    SSR = item.SSR,
                    TicketNumber = item.TBO_PNRTickets.SingleOrDefault().TicketNumber,
                    UpdatedBy = item.UpdatedBy,
                    UpdatedDate = item.UpdatedDate,
                    PassengerType = item.PassengerTypes.PassengerTypeName,

                    Fare = item.TBO_PNRTickets.SingleOrDefault().BaseFare + item.TBO_PNRTickets.SingleOrDefault().MarkupAmount,
                    FSC = item.TBO_PNRTickets.SingleOrDefault().FSC + item.TBO_PNRTickets.SingleOrDefault().SellingAdditionalTxnFee,
                    TaxAmount = item.TBO_PNRTickets.SingleOrDefault().Tax,
                    CommissionAmount = item.TBO_PNRTickets.SingleOrDefault().DiscountAmount,
                    ServiceCharge = Math.Round(item.TBO_PNRTickets.SingleOrDefault().ServiceCharge),
                };
                model.Add(obj);
            }
            return model.AsEnumerable();
        }

        public FareModel GetIndianLccFare(int PNRId)
        {
            FareModel model = new FareModel();


            int TicketStatusId = _ent.TBO_MasterPNRs.Where(x => x.MPNRId == PNRId).FirstOrDefault().TicketStatusId;
            if (TicketStatusId == 12)
            {
                Int64 VoucherNo = _ent.GL_VoucherNumber.Where(x => x.TranId == PNRId).OrderByDescending(x => x.VoucherNumber).FirstOrDefault().VoucherNumber;
                int Agentid = _ent.TBO_MasterPNRs.Where(x => x.MPNRId == PNRId).FirstOrDefault().AgentId;
                Int64 AgentLedgerId = _ent.GL_Ledgers.Where(x => x.AccTypeId == 2 && x.Id == Agentid).FirstOrDefault().LedgerId;
                if (_ent.GL_Transactions.Where(x => x.VoucherNo == VoucherNo && x.LedgerId == AgentLedgerId && x.Dr_Cr == "D").FirstOrDefault() != null)
                    model.Fare = _ent.GL_Transactions.Where(x => x.VoucherNo == VoucherNo && x.LedgerId == AgentLedgerId && x.Dr_Cr == "D").FirstOrDefault().Amount;
                if (_ent.GL_Transactions.Where(x => x.VoucherNo == VoucherNo && x.LedgerId == AgentLedgerId && x.Dr_Cr == "C").FirstOrDefault() != null)
                    model.Discount = _ent.GL_Transactions.Where(x => x.VoucherNo == VoucherNo && x.LedgerId == AgentLedgerId && x.Dr_Cr == "C").FirstOrDefault().Amount;
            }
            return model;

        }


        //////////////////////////////////////////////////////////////////////////////////////////////////////



    }
}