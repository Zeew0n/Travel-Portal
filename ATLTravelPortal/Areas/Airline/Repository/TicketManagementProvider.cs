using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ATLTravelPortal.Areas.Airline.Models;
using TravelPortalEntity;
using ATLTravelPortal.Helpers;

namespace ATLTravelPortal.Areas.Airline.Repository
{

    public class TicketManagementProvider
    {
        EntityModel ent = new EntityModel();



        public ETicketViewModel GetAllInformationForeTicket(long PNRId, long agentId)
        {

            var cc = (from aa in ent.PNRs
                      join bb in ent.PNRSectors
                      on aa.PNRId equals bb.PNRId
                      where (aa.PNRId == PNRId && aa.AgentId == agentId && (aa.TicketStatusId == 4 || aa.TicketStatusId == 16 || aa.TicketStatusId == 19 || aa.TicketStatusId == 32))
                      select new ETicketViewModel
                      {
                          PNRId = aa.PNRId,
                          SectorID = bb.SectorId,
                          PNRName = aa.LastName + ", " + aa.FirstName + " " + (aa.MiddleName ?? "") + "/" + aa.Prefix,
                          GDSReferenceNumber = aa.GDSRefrenceNumber,
                          AgentName = aa.Agents.AgentName,

                          AgentAddress = aa.Agents.Address,
                          AgentContact = aa.Agents.Phone,
                          AgentIATACode = aa.Agents.AgentCode,
                          AgentLogo = aa.Agents.AgentLogo != "" ? aa.Agents.AgentLogo : "DefaultLogo.PNG",
                          IssuedDate = aa.IssuedDate,
                          DepartureCity = bb.AirlineCities.CityName,
                          ArrivalCity = bb.AirlineCities1.CityName,
                          AgentDistrict = aa.Agents.Districts.DistrictName,
                          AgentZone = aa.Agents.Zones.ZoneName,
                          AgentNativeCountry = aa.Agents.Countries.CountryName,
                          ServiceProviderId = aa.ServiceProviderId,
                      }).FirstOrDefault();

            if (cc == null)
                return GetTBOAllInformationForTicket(PNRId, agentId);

            return cc;
        }

        public ETicketViewModel GetTBOAllInformationForTicket(long PNRId, long agentId)
        {
            var result = (from aa in ent.TBO_MasterPNRs
                          join bb in ent.TBO_PNRs on aa.MPNRId equals bb.MPNRId
                          join cc in ent.TBO_PNRsectors on bb.PNRId equals cc.PNRId
                          where (aa.MPNRId == PNRId && aa.AgentId == agentId && (aa.TicketStatusId == 4 ||aa.TicketStatusId == 16 || aa.TicketStatusId == 19 || aa.TicketStatusId==32))
                          select new ETicketViewModel
                          {
                              PNRId = aa.MPNRId,
                              SectorID = cc.SectorId,
                              PNRName = aa.LastName + ", " + aa.FirstName + " " + (aa.MiddleName ?? "") + "/" + aa.Prefix,
                              GDSReferenceNumber = bb.RecLoc,
                              AgentName = aa.Agents.AgentName,
                              AgentAddress = aa.Agents.Address,
                              AgentContact = aa.Agents.Phone,
                              AgentIATACode = aa.Agents.AgentCode,
                              AgentLogo = aa.Agents.AgentLogo != "" ? aa.Agents.AgentLogo : "DefaultLogo.PNG",
                              IssuedDate = aa.IssuedDate,
                              DepartureCity = cc.AirlineCities.CityName,
                              ArrivalCity = cc.AirlineCities1.CityName,
                              AgentDistrict = aa.Agents.Districts.DistrictName,
                              AgentZone = aa.Agents.Zones.ZoneName,
                              AgentNativeCountry = aa.Agents.Countries.CountryName,
                              ServiceProviderId = aa.ServiceProviderId,
                              OperatingAirline = bb.Airlines != null ? bb.Airlines.AirlineCode : null,
                              IsBranchByPassDeal = aa.isBranchByPassDeal,
                              IsDistributorByPassDeal = aa.isDistributorByPassDeal
                          }).FirstOrDefault();

            return result;
        }

        public List<ETicketViewModel> DeterminePNRSectorCount(long PNRId)
        {
            var cc = (from aa in ent.PNRSectors.Where(pp => (pp.PNRId == PNRId))
                      select new ETicketViewModel
                      {
                          PNRId = aa.PNRId,
                          SectorID = aa.SectorId,
                      }).AsQueryable();
            if (cc.ToList().Count == 0)
                return DetermineTBOPNRSectorCount(PNRId);

            return cc.ToList();
        }

        public List<ETicketViewModel> DetermineTBOPNRSectorCount(long PNRId)
        {
            var cc = (from aa in ent.TBO_PNRsectors.Where(pp => (pp.MPNRId == PNRId))
                      select new ETicketViewModel
                      {
                          PNRId = aa.PNRId,
                          SectorID = aa.SectorId,
                      }).AsQueryable();
            return cc.ToList();
        }

        public List<ETicketViewModel> GetPassengerListByPNRID(long PNRId, int AgentId)
        {
            bool isServiceChargeIncludeInTaxAmount = isServiceChargeIncludeInTax(AgentId);

            if (isServiceChargeIncludeInTaxAmount)
            {
                var cc = (from aa in ent.Passengers.Where(pp => pp.PNRId == PNRId && pp.isDeleted == false)
                          select new ETicketViewModel
                          {
                              PassengerId = aa.PassengerId,
                              PNRName = aa.LastName + ", " + aa.FirstName + " " + (aa.MiddleName ?? "") + "/" + aa.Prefix,
                              DateOfBirth = aa.DOB,
                              PassportNumber = aa.PassportNumber,
                              Email = aa.EmailAddress,
                              Fare = aa.Fare + aa.MarkupAmount,
                              Tax = aa.TaxAmount + aa.ServiceCharge + aa.FSC,
                              TicketNO = aa.TicketNumber,
                              ServiceCharge = 0,
                              AirLineName = aa.Airlines.AirlineName,
                              Currency = aa.Currency,
                              FrequentFlyerNo = aa.FrequentFlierNo,
                              FrequentFlyerAirlineId = aa.AirlineId ?? 0,
                              PassengerTypeId = aa.PassengerTypeId,
                              SSR = aa.SSR,
                              Discount = aa.DiscountAmount
                          }).AsQueryable();

                if (cc.ToList().Count == 0)
                    return GetTBOPassengerListByPNRID(PNRId, AgentId, isServiceChargeIncludeInTaxAmount);
                return cc.ToList();
            }
            else
            {
                var cc = (from aa in ent.Passengers.Where(pp => pp.PNRId == PNRId && pp.isDeleted == false)
                          select new ETicketViewModel
                          {
                              PassengerId = aa.PassengerId,
                              PNRName = aa.LastName + ", " + aa.FirstName + " " + (aa.MiddleName ?? "") + "/" + aa.Prefix,
                              DateOfBirth = aa.DOB,
                              PassportNumber = aa.PassportNumber,
                              Email = aa.EmailAddress,
                              Fare = aa.Fare + aa.MarkupAmount,
                              Tax = aa.TaxAmount + aa.FSC,
                              TicketNO = aa.TicketNumber,
                              ServiceCharge = aa.ServiceCharge,
                              AirLineName = aa.Airlines.AirlineName,
                              Currency = aa.Currency,
                              FrequentFlyerNo = aa.FrequentFlierNo,
                              FrequentFlyerAirlineId = aa.AirlineId ?? 0,
                              PassengerTypeId = aa.PassengerTypeId,
                              SSR = aa.SSR,
                          }).AsQueryable();

                if (cc.ToList().Count == 0)
                    return GetTBOPassengerListByPNRID(PNRId, AgentId, isServiceChargeIncludeInTaxAmount);

                return cc.ToList();
            }
        }

        public List<ETicketViewModel> GetTBOPassengerListByPNRID(long PNRId, int AgentId, bool isServiceChargeIncludeInTaxAmount)
        {
            GeneralProvider generalProvider = new GeneralProvider();

            if (isServiceChargeIncludeInTaxAmount)
            {
                var result = (from aa in ent.TBO_Passengers
                              join bb in ent.TBO_PNRTickets on aa.PassengerId equals bb.PassengerId
                              where (aa.MPNRId == PNRId && aa.IsDeleted == false)
                              select new ETicketViewModel
                              {
                                  PassengerId = aa.PassengerId,
                                  PNRName = aa.LastName + ", " + aa.FirstName + " " + (aa.MiddleName ?? "") + "/" + aa.Prefix,
                                  DateOfBirth = aa.DOB,
                                  PassportNumber = aa.PassportNumber,
                                  Email = aa.Email,
                                  Fare = bb.SellingBaseFare,// + bb.MarkupAmount
                                  Tax = bb.SellingTax + bb.ServiceCharge + bb.FSC + bb.AdditionalTxnFee,
                                  TicketNO = bb.TicketNumber,
                                  ServiceCharge = 0,
                                  AirLineName = "",//aa.FFAirline != null ? generalProvider.GetAirlineName(aa.FFAirline.Value) : null,
                                  Currency = bb.Currency,
                                  FrequentFlyerNo = aa.FFNumber,
                                  FrequentFlyerAirlineId = aa.FFAirline ?? 0,
                                  PassengerTypeId = (int)aa.PassengerTypeId,
                                  SSR = aa.SSR,
                                  Discount = bb.DiscountAmount,
                                  BranchDeal = bb.BranchDealAmount,
                                  DistributorDeal = bb.DistrubutorDealAmount,
                                  TotalCalculatedDiscount = (bb.DiscountAmount > 0 ? bb.DiscountAmount : 0 +
                                                            (bb.BranchDealAmount < 0 ? Math.Abs(bb.BranchDealAmount) : 0) +
                                                            (bb.DistrubutorDealAmount < 0 ? Math.Abs(bb.DistrubutorDealAmount) : 0)),
                                  TotalTranFee = ((bb.DiscountAmount < 0 ? Math.Abs(bb.DiscountAmount) : 0) +
                                                 (bb.BranchDealAmount > 0 ? Math.Abs(bb.BranchDealAmount) : 0) +
                                                 (bb.DistrubutorDealAmount > 0 ? Math.Abs(bb.DistrubutorDealAmount) : 0))

                              }).ToList();



                return result;
            }
            else
            {
                var result = (from aa in ent.TBO_Passengers
                              join bb in ent.TBO_PNRTickets on aa.PassengerId equals bb.PassengerId
                              where (aa.MPNRId == PNRId && aa.IsDeleted == false)

                              select new ETicketViewModel
                              {
                                  PassengerId = aa.PassengerId,
                                  PNRName = aa.LastName + ", " + aa.FirstName + " " + (aa.MiddleName ?? "") + "/" + aa.Prefix,
                                  DateOfBirth = aa.DOB,
                                  PassportNumber = aa.PassportNumber,
                                  Email = aa.Email,
                                  Fare = bb.SellingBaseFare,//+ bb.MarkupAmount
                                  Tax = bb.SellingTax + bb.FSC + bb.AdditionalTxnFee,
                                  TicketNO = bb.TicketNumber,
                                  ServiceCharge = bb.ServiceCharge,
                                  AirLineName = "",// aa.FFAirline != null ? generalProvider.GetAirlineName(aa.FFAirline.Value) : null,
                                  Currency = bb.Currency,
                                  FrequentFlyerNo = aa.FFNumber,
                                  FrequentFlyerAirlineId = aa.FFAirline ?? 0,
                                  PassengerTypeId = (int)aa.PassengerTypeId,
                                  SSR = aa.SSR,
                                  Discount = bb.DiscountAmount,
                                  BranchDeal = bb.BranchDealAmount,
                                  DistributorDeal = bb.DistrubutorDealAmount,
                                  TotalCalculatedDiscount = (bb.DiscountAmount > 0 ? bb.DiscountAmount : 0 +
                                                            (bb.BranchDealAmount < 0 ? Math.Abs(bb.BranchDealAmount) : 0) +
                                                            (bb.DistrubutorDealAmount < 0 ? Math.Abs(bb.DistrubutorDealAmount) : 0)),
                                  TotalTranFee = ((bb.DiscountAmount < 0 ? Math.Abs(bb.DiscountAmount) : 0) +
                                                 (bb.BranchDealAmount > 0 ? Math.Abs(bb.BranchDealAmount) : 0) +
                                                 (bb.DistrubutorDealAmount > 0 ? Math.Abs(bb.DistrubutorDealAmount) : 0))
                              }).AsEnumerable();


                return result.ToList();
            }
        }


        public IQueryable<ETicketViewModel> GetPNRSegmentListByPNRSectorID(long PNRId, long SectorId)
        {
            var cc = (from aa in ent.PNRSegments.Where(pp => (pp.PNRId == PNRId) && (pp.SectorId == SectorId))
                      select new ETicketViewModel
                      {

                          AirLineName = aa.Airlines.AirlineName,
                          FlightNumber = aa.FlightNumber,
                          DepartureCity = aa.AirlineCities1.CityName,
                          ArrivalDate = aa.ArriveDate,
                          ArrivalTime = aa.ArriveTime,
                          ArrivalCity = aa.AirlineCities1.CityName,
                          DepartureDate = aa.DepartDate,
                          DepartureTime = aa.DepartTime,
                          BIC = aa.BIC,
                          TerminalNumber = aa.StartTerminal,
                          AirLineReferenceNumber = aa.AirlineRefrenceNumber,
                      }).AsQueryable();
            return cc.AsQueryable();
        }

        public List<ETicketViewModel> GetPNRSegmentListByPNRSectorID(long PNRId)
        {
            List<ETicketViewModel> model = new List<ETicketViewModel>();
            var result = ent.PNRSegments.Where(pp => (pp.PNRId == PNRId));
            foreach (var aa in result)
            {
                ETicketViewModel obj = new ETicketViewModel
                {
                    SegmentID = aa.SegmentId,
                    AirLineId = aa.AirlineId,
                    AirLineName = aa.Airlines.AirlineName,
                    FlightNumber = aa.FlightNumber,
                    DepartureCity = aa.AirlineCities2.CityName,
                    ArrivalDate = aa.ArriveDate,
                    ArrivalTime = aa.ArriveTime,
                    ArrivalCity = aa.AirlineCities1.CityName,
                    DepartureDate = aa.DepartDate,
                    DepartureTime = aa.DepartTime,
                    FIC = aa.FIC,
                    BIC = aa.BIC,
                    StartTerminalNumber = aa.StartTerminal,
                    EndTerminalNumber = aa.EndTerminal,
                    AirLineReferenceNumber = aa.AirlineRefrenceNumber,
                    NVA = aa.NVA,
                    NVB = aa.NVB,
                    FlightDuration = aa.FlightDuration.ToString(),
                };
                model.Add(obj);
            }
            if (result.ToList().Count == 0)
                return GetTBOPNRSegmentListByPNRSectorID(PNRId);
            return model.ToList();
        }

        public List<ETicketViewModel> GetTBOPNRSegmentListByPNRSectorID(long PNRId)
        {
            List<ETicketViewModel> model = new List<ETicketViewModel>();
            var result = ent.TBO_PNRsegments.Where(pp => (pp.MPNRId == PNRId));
            foreach (var aa in result)
            {
                DateTime? nva = null;
                DateTime? nvb = null;

                if (aa.NVA != null)
                    nva = DateTime.Parse(aa.NVA);
                if (aa.NVB != null)
                    nvb = DateTime.Parse(aa.NVB);

                ETicketViewModel obj = new ETicketViewModel
                {
                    SegmentID = aa.SegmentId,
                    AirLineId = aa.AirlineId,
                    AirLineName = aa.Airlines.AirlineName,
                    FlightNumber = aa.FlightNumber,
                    DepartureCity = aa.AirlineCities.CityName,
                    ArrivalDate = aa.ArrivalDate,
                    ArrivalTime = aa.ArrivalTime,
                    ArrivalCity = aa.AirlineCities1.CityName,
                    DepartureDate = aa.DepartDate,
                    DepartureTime = aa.DepartTime,
                    FIC = aa.FareBasis,
                    BIC = aa.BIC,
                    StartTerminalNumber = aa.StartTerminal,
                    EndTerminalNumber = aa.EndTerminal,
                    AirLineReferenceNumber = aa.AirlineRefNumber,
                    NVA = nva,
                    NVB = nvb,
                    FlightDuration = aa.FlightDuration.ToString(),
                };
                model.Add(obj);
            }
            return model.ToList();
        }

        public string GetAirlineCodeByAirlineId(int AirlineId)
        {
            var result = ent.Airlines.Where(model => model.AirlineId == AirlineId).FirstOrDefault();
            if (result != null)
            {
                if (!string.IsNullOrEmpty(result.AirlineCode))
                {
                    return result.AirlineCode;
                }
                else
                {
                    return "";
                }
            }
            else
            {
                return "";
            }
        }

        public string GetPassengerBaggageInfo(int PasssengerTypeId, Int64 SegmentId)
        {
            return ent.Air_PassengerBaggage.Where(pp => (pp.PassengerTypeId == PasssengerTypeId && pp.SegmentId == SegmentId)).Select(xx => xx.Baggage).FirstOrDefault();
        }



        public bool ShowFareOnETicket(int Agentid)
        {
            return ent.Core_AgentConfiguration.Where(x => x.AgentId == Agentid).Select(x => x.ShowFareOnETicket).FirstOrDefault().Value;
        }

        private bool isServiceChargeIncludeInTax(int AgentId)
        {

            return ent.Core_AgentConfiguration.Where(x => x.AgentId == AgentId).Select(x => x.ServiceChargeIncludeInTax).FirstOrDefault().Value;
        }

        public bool ShowAgentLogoOnETicket(int Agentid)
        {
            var result = ent.AgentSettings.Where(model => (model.AgentId == Agentid && model.SettingId == 5)).FirstOrDefault();
            if (result != null)
            {

                return true;
            }
            else
            {
                return false;
            }
        }

        public List<ETicketViewModel> GetAirlineVendorLocatorsById(long PNRId)
        {
            List<ETicketViewModel> model = new List<ETicketViewModel>();
            var result = ent.Air_AirlineVendorLocators.Where(pp => (pp.PNRId == PNRId));
            foreach (var aa in result)
            {
                ETicketViewModel obj = new ETicketViewModel
                {
                    PNRId = aa.PNRId,
                    AirLineName = aa.AirlineCode,
                    AirLineReferenceNumber = aa.VendorLocatorNo
                };
                model.Add(obj);
            }
            if (result.ToList().Count == 0)
                return GetTBOAirlineVendorLocatorsById(PNRId);

            return model.ToList();
        }

        public List<ETicketViewModel> GetTBOAirlineVendorLocatorsById(long PNRId)
        {
            List<ETicketViewModel> model = new List<ETicketViewModel>();
            var result = ent.TBO_Air_AirlineVendorLocators.Where(pp => (pp.MPNRId == PNRId));
            foreach (var aa in result)
            {
                ETicketViewModel obj = new ETicketViewModel
                {
                    PNRId = aa.PNRId,
                    AirLineName = aa.AirlineCode,
                    AirLineReferenceNumber = aa.VendorLocatorNo
                };
                model.Add(obj);
            }
            return model.ToList();
        }
        public int  GetAgentIdbyPNRId(long PNRid)
        {
            PNRs pnrs = ent.PNRs.Where(x => x.PNRId == PNRid).FirstOrDefault();
            if (pnrs == null)
                return GetTBOAgentIdbyPNRId(PNRid);

            return pnrs.AgentId;
        }


        public TBO_MasterPNRs GetTicketStatusIdByMPNRId(long MPNRId)
        {
            TBO_MasterPNRs masterpnrs = ent.TBO_MasterPNRs.Where(x => x.MPNRId == MPNRId).FirstOrDefault();
            if (masterpnrs != null)
            {
                return masterpnrs;
            }
            else
            {
                return null;
            }
        }



        public int GetTBOAgentIdbyPNRId(long PNRid)
        {
            TBO_MasterPNRs pnrs = ent.TBO_MasterPNRs.Where(x => x.MPNRId == PNRid).FirstOrDefault();
            return pnrs.AgentId;
        }
        /// <summary>
        /// ////////////////////////////Indian Lcc ETicket Methods start here//////////////////////////////////////////////
        /// </summary>
        /// <param name="PNRid"></param>
        /// <returns></returns>

        public int GetAgentIdbyPNRIdLcc(long PNRid)
        {
            var agentid = ent.TBO_MasterPNRs.Where(x => x.MPNRId == PNRid).Select(x => x.AgentId).FirstOrDefault();
            return Convert.ToInt32(agentid);
        }




        public ETicketViewModel GetLccMasterInformationForeTicket(long MPNRId, int AgentId)
        {
            var cc = (from aa in ent.TBO_MasterPNRs.Where(aa => aa.MPNRId == MPNRId && aa.AgentId == AgentId && (aa.TicketStatusId == 4 || aa.TicketStatusId == 16 || aa.TicketStatusId == 19 || aa.TicketStatusId == 32))
                      select new ETicketViewModel
                      {
                          MasterPNRId = aa.MPNRId,
                          AgentName = aa.Agents.AgentName,
                          PassengerName = aa.LastName + aa.FirstName + (aa.MiddleName ?? "") + aa.Prefix,
                          AgentLogo = aa.Agents.AgentLogo != "" ? aa.Agents.AgentLogo : "DefaultLogo.PNG",
                          PNREmailAdd = aa.Email,
                          MobileNumber = aa.Phone,
                          PassengerAddress = aa.Address,
                          IssuedDate = aa.IssuedDate,
                          ServiceProviderId=aa.ServiceProviderId,
                          IsBranchByPassDeal=aa.isBranchByPassDeal,
                          IsDistributorByPassDeal=aa.isDistributorByPassDeal
                      }).FirstOrDefault();
            return cc;
        }



        public List<ETicketViewModel> GetLccPNRInformationForeTicket(long? MasterPNRId)
        {
            List<ETicketViewModel> model = new List<ETicketViewModel>();
            var result = ent.TBO_PNRs.Where(aa => aa.MPNRId == MasterPNRId);
            foreach (var aa in result)
            {
                ETicketViewModel obj = new ETicketViewModel
                {
                    PNRId = aa.PNRId,
                    BookingId = aa.BookingId,
                    StatusId = aa.TicketStatus.ticketStatusName,
                    GDSReferenceNumber = aa.RecLoc,
                   // OperatingAirline = aa.Airlines != null ? aa.Airlines.AirlineCode : null
                    OperatingAirline = GetAirlineCodeByMasterPnrId(MasterPNRId),
                };
                model.Add(obj);
            }
            return model.ToList();
        }

        public string GetAirlineCodeByMasterPnrId(long? masterpnrid)
        {
            var res = ent.TBO_PNRsegments.Where(x => x.MPNRId == masterpnrid).Select(x => x.Airlines.AirlineCode).FirstOrDefault();
            return res;
        }

        public List<ETicketViewModel> GetAllLccPNRSector(long? MPNRId)
        {
            var cc = (from aa in ent.TBO_PNRsectors.Where(pp => (pp.MPNRId == MPNRId))
                      select new ETicketViewModel
                      {
                          PNRId = aa.PNRId,
                          SectorID = aa.SectorId,
                          MasterPNRId = aa.MPNRId,
                          PlatingAirLineName = aa.Airlines.AirlineName,
                          DepartureCity = aa.AirlineCities.CityName,
                          DepartureDate = aa.DepartDate,
                          DepartureTime = aa.DepartTime,
                          ArrivalCity = aa.AirlineCities1.CityName,
                          ArrivalDate = aa.ArriveDate,
                          ArrivalTime = aa.ArriveTime,
                          StartTerminalNumber = aa.StartTerminal,
                          EndTerminalNumber = aa.EndTerminal
                      }).AsQueryable();
            return cc.ToList();
        }

        public List<ETicketViewModel> GetAllLccPNRSegment(long? MPNRId)
        {
            List<ETicketViewModel> model = new List<ETicketViewModel>();
            var result = ent.TBO_PNRsegments.Where(pp => (pp.MPNRId == MPNRId));
            foreach (var aa in result)
            {
                ETicketViewModel obj = new ETicketViewModel
                {
                    PNRId = aa.PNRId,
                    MasterPNRId = aa.MPNRId,
                    SectorID = aa.SectorId,
                    AirLineId = aa.AirlineId,
                    AirLineName = aa.Airlines.AirlineName,
                    FlightNumber = aa.FlightNumber,
                    DepartureCity = aa.AirlineCities.CityName,
                    ArrivalDate = aa.ArrivalDate,
                    ArrivalTime = aa.ArrivalTime,
                    ArrivalCity = aa.AirlineCities1.CityName,
                    DepartureDate = aa.DepartDate,
                    DepartureTime = aa.DepartTime,
                    BIC = aa.BIC,
                    StartTerminalNumber = aa.StartTerminal,
                    EndTerminalNumber = aa.EndTerminal,
                    AirLineReferenceNumber = aa.AirlineRefNumber,
                    // FlightDuration = (int) Convert.ToInt64( aa.FlightDuration),
                    FlightDuration = aa.FlightDuration,// (int) Convert.ToInt64( (( aa.FlightDuration)==""?"" : aa.FlightDuration)) ,
                    VendorRemark = aa.VndRemarks,
                    SegmentID = aa.SegmentId,
                };
                model.Add(obj);
            }
            return model.ToList();
        }

        public List<ETicketViewModel> GetAllLccPNRPassenger(long? PNRId)
        {
            List<ETicketViewModel> model = new List<ETicketViewModel>();
            var result = ent.TBO_Passengers.Where(pp => (pp.MPNRId == PNRId));
            foreach (var aa in result)
            {
                ETicketViewModel obj = new ETicketViewModel
                {
                    PNRId = aa.PNRId,
                    MasterPNRId = aa.MPNRId,
                    PassengerId = aa.PassengerId,
                    PNRName = aa.LastName + " " + aa.FirstName + " " + (aa.MiddleName ?? "") + " " + aa.Prefix,
                    DateOfBirth = aa.DOB,
                    PassportNumber = aa.PassportNumber,
                    Email = aa.Email,
                    MobileNumber = aa.Phone,
                    FrequentFlyerNo = aa.FFNumber,
                    FrequentFlyerAirlineId = aa.FFAirline ?? 0,
                };
                model.Add(obj);
            }
            return model.ToList();
        }


        public ETicketViewModel GetB2CMasterInformationForeTicket(long MPNRId, int CreatedBy)
        {
            var cc = (from aa in ent.TBO_MasterPNRs.Where(aa => aa.MPNRId == MPNRId && aa.CreatedBy == CreatedBy && (aa.TicketStatusId==29))
                      select new ETicketViewModel
                      {
                          MasterPNRId = aa.MPNRId,
                          AgentName = aa.Agents.AgentName,
                          PassengerName = aa.LastName + aa.FirstName + (aa.MiddleName ?? "") + aa.Prefix,
                          AgentLogo = aa.Agents.AgentLogo != "" ? aa.Agents.AgentLogo : "DefaultLogo.PNG",
                          PNREmailAdd = aa.Email,
                          MobileNumber = aa.Phone,
                          PassengerAddress = aa.Address,
                          IssuedDate = aa.IssuedDate,
                          ServiceProviderId = aa.ServiceProviderId
                      }).FirstOrDefault();
            return cc;
        }

        public static class eTicketdataProviderHelper
        {

            public static string GetPassengerTicketNoOnETicket(long PassengerId, long? PNRId)
            {
                EntityModel ent = new EntityModel();
                var cc = ent.TBO_PNRTickets.Where(aa => (aa.PassengerId == PassengerId && aa.PNRId == PNRId)).FirstOrDefault();
                return cc.TicketNumber;
            }

            public static List<ETicketViewModel> GetPassengerAdditionalInfoOnETicket(long SegmentId)
            {
                EntityModel ent = new EntityModel();
                List<ETicketViewModel> model = new List<ETicketViewModel>();
                var result = ent.TBO_PNRsegmentAdditionalInfo.Where(aa => (aa.SegmentId == SegmentId));
                foreach (var aa in result)
                {
                    ETicketViewModel obj = new ETicketViewModel
                    {
                        LccNVA = aa.NVA,
                        LccNVB = aa.NVB,
                        FlightKey = aa.FlightKey,
                        FIC = aa.FareBasis,
                        Baggage = aa.Baggage,
                    };
                    model.Add(obj);
                }
                return model.ToList();

            }

        }

        public bool isLccServiceChargeIncludeInTax(int AgentId)
        {

            return ent.Core_AgentConfiguration.Where(x => x.AgentId == AgentId).Select(x => x.ServiceChargeIncludeInTax).FirstOrDefault().Value;
        }



        public TBO_PNRTickets GetFareByPNR(Int64 MPNRId)
        {
            var pax = GetTickets(MPNRId);
            TBO_PNRTickets AggregateFare = new TBO_PNRTickets();

            foreach (var pass in pax)
            {
                AggregateFare.AdditionalTxnFee += pass.SellingAdditionalTxnFee;
                AggregateFare.AirlineTransFee += pass.SellingAirlineTransFee;
                AggregateFare.BaseFare += pass.SellingBaseFare;
                AggregateFare.Tax += pass.SellingTax;
                AggregateFare.OtherCharges += pass.SellingOtherCharges;
                AggregateFare.ServiceTax += pass.SellingServiceTax;
                AggregateFare.MarkupAmount += pass.MarkupAmount;
                AggregateFare.CommissionAmount += pass.CommissionAmount;
                AggregateFare.DiscountAmount += pass.DiscountAmount;
                AggregateFare.ServiceCharge += pass.ServiceCharge;
                AggregateFare.FSC += pass.SellingFSC;
                AggregateFare.Currency = pass.Currency;
                AggregateFare.BranchDealAmount += pass.BranchDealAmount;
                AggregateFare.DistrubutorDealAmount += pass.DistrubutorDealAmount;
            }
            return AggregateFare;
        }
        public IEnumerable<TBO_PNRTickets> GetTickets(Int64 MPNRId )
        {
            EntityModel entity = new EntityModel();
            return entity.TBO_PNRTickets.Where(x => x.MPNRId == MPNRId);
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////




    }
}
