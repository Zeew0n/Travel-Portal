using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using  ATLTravelPortal.Areas.Airline.Models;
using TravelPortalEntity;
using System.Web.Mvc;

namespace ATLTravelPortal.Areas.Airline.Repository
{
    public class PNRManagementRepository
    {
        EntityModel _ent = new EntityModel();

        public PNRsModel GetPNRDetail(string GDSPNR)
        {
            var result = _ent.PNRs.Where(x => x.GDSRefrenceNumber == GDSPNR).FirstOrDefault();
            PNRsModel model = new PNRsModel();
            if (result != null)
            {
                model = new PNRsModel
                {
                    AgentId = result.AgentId,
                    AgentName=result.Agents.AgentName,
                    ATLTTL = result.ATLTTL.ToString(),
                    ContactNumber = result.ContactNumber,
                    CreatedBy = result.UsersDetails.AppUserId,
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
                    Checker = result.UsersDetails.FullName,
                    UpdatedDate = result.UpdatedDate,
                    TicketStatus = result.TicketStatus.ticketStatusName,
                    BookedPerson = result.UsersDetails.FullName

                };
            }
            return model;
        }


        public IEnumerable<PNRSegmentsModel> GetPNRSegmentList(long PNRId)
        {

            List<PNRSegmentsModel> model = new List<PNRSegmentsModel>();
            var result = _ent.PNRSegments.Where(x => x.PNRId == PNRId);
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
                    ArriveCityName = item.AirlineCities2.CityName,
                    DepartCityName = item.AirlineCities1.CityName,

                };
                model.Add(obj);
            }
            return model.AsEnumerable();



        }


        public IEnumerable<PassengersModel> GetPassengersList(long PNRId)
        {

            List<PassengersModel> model = new List<PassengersModel>();
            var result = _ent.Passengers.Where(x => x.PNRId == PNRId);
            foreach (var item in result)
            {
                PassengersModel obj = new PassengersModel
                {
                    AirlineId = item.AirlineId,
                    CommissionAmount = item.CommissionAmount,
                    CreatedBy = item.CreatedBy,
                    CreatedDate = item.CreatedDate,
                    DOB = item.DOB,
                    DOCA = item.DOCA,
                    DOCO = item.DOCO,
                    DOCS = item.DOCS,
                    EmailAddress = item.EmailAddress,
                    Fare = item.Fare,
                    FirstName = item.FirstName,
                    FrequentFlierNo = item.FrequentFlierNo,
                    FSC = item.FSC,
                    LastName = item.LastName,
                    MarkupAmount = item.MarkupAmount,
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
                    ServiceCharge = item.ServiceCharge,
                    SSR = item.SSR,
                    TaxAmount = item.TaxAmount,
                    TicketNumber = item.TicketNumber,
                    TicketStatusId = item.TicketStatusId,
                    UpdatedBy = item.UpdatedBy,
                    UpdatedDate = item.UpdatedDate,

                    PassengerType = item.PassengerTypes.PassengerTypeName,

                };
                model.Add(obj);
            }
            return model.AsEnumerable();

        }
        public IEnumerable<SelectListItem> GetAllTicketStatusList()
        {
            List<TicketStatus> all = _ent.TicketStatus.OrderBy(xx => xx.ticketStatusId).ToList();
            var GetAllStatusList = new List<SelectListItem>();
            foreach (var item in all)
            {
                var teml = new SelectListItem
                {
                    Text = item.ticketStatusName,
                    Value = item.ticketStatusId.ToString()
                };
                GetAllStatusList.Add(teml);
            }
            return GetAllStatusList.AsEnumerable();
        }



        public List<AirlineCities> GetAllAirlineCity(string searchText, int maxResults)
        {
            var result = from n in _ent.AirlineCities
                         where n.CityName.StartsWith(searchText) || n.CityCode.StartsWith(searchText)
                         orderby n.CityName
                         select n;

            return result.Take(maxResults).ToList();
        }
        
    }
}