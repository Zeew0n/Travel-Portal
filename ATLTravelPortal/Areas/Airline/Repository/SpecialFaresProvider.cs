using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TravelPortalEntity;
using ATLTravelPortal.Areas.Airline.Models;
using ATLTravelPortal.Helpers;

namespace ATLTravelPortal.Areas.Airline.Repository
{
    public class SpecialFaresProvider
    {
        EntityModel ent = new EntityModel();

        public List<SpecialFaresModel> GetSpecialFaresList()
        {
            int sno = 0;
            var result = ent.Air_SpecialFares;
            List<SpecialFaresModel> model = new List<SpecialFaresModel>();
            foreach (var item in result)
            {
                sno++;
                SpecialFaresModel obj = new SpecialFaresModel();
                obj.SNO = sno;
                obj.SpecialFareId = item.SpecialFareId;
                obj.FromCityId = item.FromCityId;
                obj.FromCityName = item.AirlineCities.CityName;
                obj.ToCityId = item.ToCityId;
                obj.ToCityName = item.AirlineCities1.CityName;
                obj.AirlineId = item.AirlineId;
                obj.AirlineName = item.Airlines.AirlineName;
                obj.RegularFare = item.RegularFare;
                obj.SpecialFare = item.SpecialFare;
                obj.EffectiveFrom = item.EffectiveFrom;
                obj.ExpireOn = item.ExpireOn;

                model.Add(obj);
            }
            return model.ToList();
        }

        public SpecialFaresModel GetSpecialFaresDetail(int id)
        {
            Air_SpecialFares result = ent.Air_SpecialFares.Where(x => x.SpecialFareId == id).FirstOrDefault();
            if (result != null)
            {
                SpecialFaresModel model = new SpecialFaresModel();

                model.SpecialFareId = result.SpecialFareId;
                model.FromCityId = result.FromCityId;
                model.hdfFromCityId = (int) result.FromCityId;
                model.FromCityName = result.AirlineCities.CityName;
                model.ToCityId = result.ToCityId;
                model.hdfToCityId = (int) result.ToCityId;
                model.ToCityName = result.AirlineCities1.CityName;
                model.AirlineId = result.AirlineId;
                model.hdfAirlineName = (int) result.AirlineId;
                model.AirlineName = result.Airlines.AirlineName;
                model.RegularFare = result.RegularFare;
                model.SpecialFare = result.SpecialFare;
                model.EffectiveFrom = result.EffectiveFrom;
                model.ExpireOn = result.ExpireOn;

                return model;
            }
            return null;
        }

        public void CreateSpecialFares(SpecialFaresModel model)
        {
            Air_SpecialFares obj = new Air_SpecialFares();
          
            obj.FromCityId = model.hdfFromCityId;
            obj.ToCityId = model.hdfToCityId;
            obj.AirlineId = model.hdfAirlineName;
            obj.RegularFare = Convert.ToDouble( model.RegularFare);
            obj.SpecialFare = Convert.ToDouble( model.SpecialFare);
            obj.CreatedBy = model.CreatedBy;
            obj.CreatedDate = DateTime.Now;
            obj.EffectiveFrom = Convert.ToDateTime( model.EffectiveFrom);
            obj.ExpireOn = Convert.ToDateTime( model.ExpireOn);

            ent.AddToAir_SpecialFares(obj);
            ent.SaveChanges();

        }

        public void EditSpecialFare(SpecialFaresModel model)
        {

            Air_SpecialFares result = ent.Air_SpecialFares.Where(u => u.SpecialFareId == model.SpecialFareId).FirstOrDefault();

            if (result != null)
            {
                result.FromCityId = model.hdfFromCityId;
                result.ToCityId = model.hdfToCityId;
                result.AirlineId = model.hdfAirlineName;
                result.RegularFare = Convert.ToDouble( model.RegularFare);
                result.SpecialFare = Convert.ToDouble( model.SpecialFare);
                result.UpdatedBy = model.UpdatedBy;
                result.UpdatedDate = DateTime.Now;
                result.EffectiveFrom = Convert.ToDateTime( model.EffectiveFrom);
                result.ExpireOn = Convert.ToDateTime( model.ExpireOn);

                ent.ApplyCurrentValues(result.EntityKey.EntitySetName, result);
                ent.SaveChanges();
            }
        }

        public void DeleteSpecialFare(int id)
        {
            Air_SpecialFares result = ent.Air_SpecialFares.Where(x => x.SpecialFareId == id).FirstOrDefault();
            ent.DeleteObject(result);
            ent.SaveChanges();
        }

        public List<AirlineCities> GetAirlineCity(string AirlineCityName, int maxResult)
        {
            return GetAllAirlineCityList(AirlineCityName, maxResult).ToList();
        }
        public IEnumerable<AirlineCities> GetAllAirlineCityList(string AirlineCityNameCode, int maxResult)
        {
            EntityModel ent = new EntityModel();
            return ent.AirlineCities.Where(x => ((x.CityName.ToLower().Contains(AirlineCityNameCode) ||
                x.CityName.ToLower().Contains(AirlineCityNameCode) ||
                x.CityCode.ToUpper().Contains(AirlineCityNameCode) ||
                x.CityCode.ToUpper().Contains(AirlineCityNameCode.ToUpper())))).Take(maxResult).ToList().Select(x =>
                   new AirlineCities { CityName = x.CityName, CityID = x.CityID, CityCode = x.CityCode }
                );
        }


    }
}