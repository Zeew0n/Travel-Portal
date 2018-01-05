using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ATLTravelPortal.Areas.Airline.Models;
using TravelPortalEntity;
using ATLTravelPortal.Helpers;
using System.Web.Mvc;

namespace ATLTravelPortal.Areas.Airline.Repository
{
    public class TravelFareProvider
    {
        EntityModel ent = new EntityModel();
        GeneralProvider _provider = new GeneralProvider();
        public void SavePaperFareRule(PaperFareRules obj)
        {
            ent.AddToPaperFareRules(obj);
            ent.SaveChanges();
        }

        public void EditPaperFlightFareRule(PaperFareRules obj)
        {
            var res = ent.PaperFareRules.Where(x => x.PaperFareId == obj.PaperFareId).FirstOrDefault();
            ent.ApplyCurrentValues(res.EntityKey.EntitySetName, obj);
            ent.SaveChanges();
        }

        public PaperFareRules GetPaperFlightFareRuleById(int Id)
        {
            return ent.PaperFareRules.Where(x => x.PaperFareId == Id).FirstOrDefault();    
        
        }

        public IQueryable<GetPaperFairRules_Result> ListAllPaperFlightFareRule()
        {
            return ent.GetPaperFairRules().AsQueryable();
            //return ent.PaperFareRules.AsQueryable();
        }
        public IEnumerable<TravelFareModel> GetDomesticTravelFare()
        {
            var tempData = ent.PaperFareRules.Where(x=>x.FlightTypeId==2).ToList();
            var reviewModel = new List<TravelFareModel>();

            foreach (var item in tempData)
            {
                var viewModel = new TravelFareModel
                {
                    PaperFareId = item.PaperFareId,
                    AirlineId = item.AirlineId,
                    AirlineNmae = item.Airlines.AirlineName,
                    FlightSeasonId = item.FlightSeasonId,
                    DepartureCityId = item.DepartureCityId,
                    DestinationCityName = _provider.GetCityName(item.DestinationCityId),
                    DestinationCityId = item.DepartureCityId,
                    DepartureCityName = _provider.GetCityName(item.DepartureCityId),
                    FlightClassId = item.FlightClassId,
                    OneWayFareBasis = item.OneWayFareBasis,
                    OneWayFare = item.OneWayFare,
                    RoundWayFareBasis = item.RoundWayFareBasis,
                    RoundWayFare = item.RoundWayFare,
                    EffectiveFrom = item.EffectiveFrom,
                    ExpireOn = item.ExpireOn,
                    FlightTypeId = item.FlightTypeId,
                    ChildFare = item.ChildFare,
                    ChildFareType = item.ChildFareType,
                    ChildFareOn = item.ChildFareOn,
                    InfantFare = item.InfantFare,
                    InfantFareType = item.InfantFareType,
                    InfantFareOn = item.InfantFareOn,
                    RefundFee = item.RefundFee,
                    ReissueFee = item.ReissueFee,
                    //FlightClassName = _provider.GetFlightClassName(item.FlightClassId),
                    TermsAndConditions = item.TermsAndConditions,
                    TourCode = item.TourCode,
                    FlightClassName = item.Air_DomesticFlightClasses.FlightClassCode+"("+item.Air_DomesticFlightClasses.FlightClassType+")"

                };
                reviewModel.Add(viewModel);
            }
            return reviewModel.AsEnumerable();
        }
        public IEnumerable<TravelFareModel> GetInternationalTravelFare()
        {
            var tempData = ent.PaperFareRules.Where(x=>x.FlightTypeId==1).ToList();
            var reviewModel = new List<TravelFareModel>();

            foreach (var item in tempData)
            {
                var viewModel = new TravelFareModel
                {
                    PaperFareId = item.PaperFareId,
                    AirlineId = item.AirlineId,
                    AirlineNmae = item.Airlines.AirlineName,
                    FlightSeasonId = item.FlightSeasonId,
                    DepartureCityId = item.DepartureCityId,
                    DestinationCityName = _provider.GetCityName(item.DestinationCityId),
                    DestinationCityId = item.DepartureCityId,
                    DepartureCityName = _provider.GetCityName(item.DepartureCityId),
                    FlightClassId = item.DestinationCityId,
                    OneWayFareBasis = item.OneWayFareBasis,
                    OneWayFare = item.OneWayFare,
                    RoundWayFareBasis = item.RoundWayFareBasis,
                    RoundWayFare = item.RoundWayFare,
                    EffectiveFrom = item.EffectiveFrom,
                    ExpireOn = item.ExpireOn,
                    FlightTypeId = item.FlightTypeId,
                    ChildFare = item.ChildFare,
                    ChildFareType = item.ChildFareType,
                    ChildFareOn = item.ChildFareOn,
                    InfantFare = item.InfantFare,
                    InfantFareType = item.InfantFareType,
                    InfantFareOn = item.InfantFareOn,
                    RefundFee = item.RefundFee,
                    ReissueFee = item.ReissueFee,
                    TermsAndConditions = item.TermsAndConditions,
                    TourCode = item.TourCode,
                   // FlightClassName = item.FlightClasses.ClassName

                };
                reviewModel.Add(viewModel);
            }
            return reviewModel.AsEnumerable();
        }
        public IEnumerable<TravelFareModel> GetTravelFareByName(string airlineName)
        {
            //var result = ent.Airlines.Where(x => (x.AirlineName.ToLower().Contains(airlineName.ToLower()) || x.AirlineCode.ToLower().Contains(airlineName.ToLower())));
            int AirlineId = ent.Airlines.Where(x => x.AirlineName == airlineName).Select(x => x.AirlineId).FirstOrDefault();
            var tempData = ent.PaperFareRules.Where(x => x.AirlineId == AirlineId);
            var reviewModel = new List<TravelFareModel>();

            foreach (var item in tempData)
            {
                var viewModel = new TravelFareModel
                {
                    PaperFareId = item.PaperFareId,
                    AirlineId = item.AirlineId,
                    AirlineNmae = item.Airlines.AirlineName,
                    FlightSeasonId = item.FlightSeasonId,
                    DepartureCityId = item.DepartureCityId,
                    DestinationCityName = _provider.GetCityName(item.DestinationCityId),
                    DestinationCityId = item.DepartureCityId,
                    DepartureCityName = _provider.GetCityName(item.DepartureCityId),
                    FlightClassId = item.DestinationCityId,
                    FlightClassName = _provider.GetFlightClassName(item.FlightClassId),
                    OneWayFareBasis = item.OneWayFareBasis,
                    OneWayFare = item.OneWayFare,
                    RoundWayFareBasis = item.RoundWayFareBasis,
                    RoundWayFare = item.RoundWayFare,
                    EffectiveFrom = item.EffectiveFrom,
                    ExpireOn = item.ExpireOn,
                    FlightTypeId = item.FlightTypeId,
                    ChildFare = item.ChildFare,
                    ChildFareType = item.ChildFareType,
                    ChildFareOn = item.ChildFareOn,
                    InfantFare = item.InfantFare,
                    InfantFareType = item.InfantFareType,
                    InfantFareOn = item.InfantFareOn,
                    RefundFee = item.RefundFee,
                    ReissueFee = item.ReissueFee,
                    TermsAndConditions = item.TermsAndConditions,
                    TourCode = item.TourCode,
                  //  FlightClassName = item.FlightClasses.ClassName

                };
                reviewModel.Add(viewModel);
            }
            return reviewModel.AsEnumerable();
        }
        //public IEnumerable<TravelFareModel> GetListByAgentId(int AgentId)
        //{
        //    List<TravelFareModel> model = new List<TravelFareModel>();
        //    var obj = ent.trave.Where(x => x.AgentId == AgentId).ToList();
        //    foreach (var item in obj)
        //    {
        //        var temp = new AgentSegmentCommissionModel
        //        {
        //            SegmentCommissionId = item.SegmentCommissionId,
        //            ServiceProviderName = item.GDSInformation.ServiceProviderName,
        //            AgentName = item.Agents.AgentName,
        //            FromSegmentNumber = item.FromSegmentNumber,
        //            ToSegmentNumber = item.ToSegmentNumber,
        //            EffectiveFrom = item.EffectiveFrom,
        //            ExpireOn = item.ExpireOn
        //        };
        //        model.Add(temp);
        //    }
        //    return model.AsEnumerable();
        //}


        public List<FlightClasses> GetAllFlightClass()
        {
            return ent.FlightClasses.ToList();
        }

        public List<Currencies> GetAllCurrencyType()
        {
            return ent.Currencies.ToList();
        }
        public List<FlightTypes> GetDomesticFlightType()
        {
            return ent.FlightTypes.Where(x=>x.FlightTypeId ==2).ToList();
        }
        public List<FlightSeasons> GetAllFlightSeason()
        {
            return ent.FlightSeasons.ToList();
        }
        public List<Airlines> GetAllAirline()
        {
            return ent.Airlines.ToList();
        }
        public List<AirlineCities> GetAllAirlineCity()
        {
            return ent.AirlineCities.ToList();
        }

        public List<Air_DomesticFlightClasses> GetFlightClassCodeByAirlineID(int AirlineId)
        {
            return ent.Air_DomesticFlightClasses.Where(cc => cc.AirlineId == AirlineId).ToList();
        }

        public DefaultPaperFareRules GetDefaultPaperFairRule()
        {
            return ent.DefaultPaperFareRules.Where(x => x.isCurrent ==true).FirstOrDefault();

        }
        public void DeleteFare(int PaperFareId)
        {
            PaperFareRules obj = ent.PaperFareRules.Where(x => x.PaperFareId == PaperFareId).FirstOrDefault();
            ent.DeleteObject(obj);
            ent.SaveChanges();
        }
        public bool CheckPaperFareExist(int AirlineId,int FlightClassId,DateTime From,DateTime ExpireOn,int DepartureCity,int DestinationCity)
        {
           //PaperFareRules result = ent.PaperFareRules.Where(x => x.AirlineId == AirlineId).Where(x => x.FlightClassId == FlightClassId).Where(x => x.EffectiveFrom >= From).Where(x => x.ExpireOn <= ExpireOn).Where(x=>x.DepartureCityId==DepartureCity).Where(x=>x.DestinationCityId == DestinationCity).FirstOrDefault() ;
            PaperFareRules result = ent.PaperFareRules.Where(x => x.AirlineId == AirlineId).Where(x => x.FlightClassId == FlightClassId).Where(x => x.DepartureCityId == DepartureCity).Where(x => x.DestinationCityId == DestinationCity).Where(x=>x.EffectiveFrom <= From && x.ExpireOn >=From).FirstOrDefault();
            PaperFareRules item = ent.PaperFareRules.Where(x => x.AirlineId == AirlineId).Where(x => x.FlightClassId == FlightClassId).Where(x => x.DepartureCityId == DepartureCity).Where(x => x.DestinationCityId == DestinationCity).Where(x => x.ExpireOn >= ExpireOn && x.EffectiveFrom <= ExpireOn).FirstOrDefault();
            if (result == null && item == null)
            {
                PaperFareRules check = ent.PaperFareRules.Where(x => x.AirlineId == AirlineId).Where(x => x.FlightClassId == FlightClassId).Where(x => x.DepartureCityId == DepartureCity).Where(x => x.DestinationCityId == DestinationCity).Where(x => x.EffectiveFrom >= From && x.ExpireOn >= From && x.ExpireOn <=ExpireOn).FirstOrDefault();
                if (check == null)

                    return true;
                else
                    return false;
            }
            else
            {
                return false;
            }
        }
        public bool IfPaperFareExist(int AirlineId, int FlightClassId, DateTime From, int DepartureCity, int DestinationCity)
        {
            
            PaperFareRules result = ent.PaperFareRules.Where(x => x.AirlineId == AirlineId && x.FlightClassId == FlightClassId && x.DepartureCityId == DepartureCity && x.DestinationCityId == DestinationCity && x.EffectiveFrom == From).FirstOrDefault();
            if (result == null )
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool CheckClassNameExist(int AirlineId, int FlightClassId, int DepartureCityId, int DestinationCityId)
        {
           // PaperFareRules result = ent.PaperFareRules.Where(x => x.AirlineId == AirlineId && x.FlightClassId == FlightClassId && x.DepartureCityId==DepartureCityId && x.DestinationCityId == DestinationCityId).FirstOrDefault();
            PaperFareRules result = ent.PaperFareRules.Where(x => x.AirlineId == AirlineId).Where(x => x.FlightClassId==FlightClassId).Where(x => x.DepartureCityId == DepartureCityId).Where(x => x.DestinationCityId == DestinationCityId).FirstOrDefault();
            if (result == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public List<Airlines> GetAllDomesticAirlines()
        {
            return ent.Airlines.Where(x => x.AirlineTypeId == 2).ToList();
        }
        public List<AirlineCities> GetDomesticCities()
        {
            return ent.AirlineCities.Where(x => x.AirlineCityTypeId == 2).ToList();
        }
        public bool CheckValuesForAParticularID(int AirlineId,int DepartureCityId,int DestinationCityId,int ClassId,int PaperFareId)
        {
         var  result = ent.PaperFareRules.Where(x=>x.PaperFareId == PaperFareId).FirstOrDefault();
            if(result.AirlineId == AirlineId && result.DepartureCityId == DepartureCityId && result.DestinationCityId == DestinationCityId && result.FlightClassId== ClassId)
            {
             return true;
            }
            return false;
        }

    }
}