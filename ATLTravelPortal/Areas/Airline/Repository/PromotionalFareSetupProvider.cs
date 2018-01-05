using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ATLTravelPortal.Areas.Airline.Models;
using TravelPortalEntity;
using System.Web.Mvc;

namespace ATLTravelPortal.Areas.Airline.Repository
{
    public class PromotionalFareSetupProvider
    {
        EntityModel entity = new EntityModel();

        public List<PromotionalFareListModel> GetPromotionalFareListModel()
        {
            IEnumerable<Air_PromotionalFares> air_PromotionalFares = entity.Air_PromotionalFares.Where(x=>x.isActive==true);
            List<PromotionalFareListModel> promotionalFareListModel = new List<PromotionalFareListModel>();
            foreach (Air_PromotionalFares promotionalFare in air_PromotionalFares)
            {
                PromotionalFareListModel model = new PromotionalFareListModel();
                //model.PromotionalFareId = promotionalFare.PromotionalFareId;
                //model.AirlineName = promotionalFare.Airlines.AirlineCode;
                //model.FromCity = promotionalFare.AirlineCities.CityCode;
                //model.ToCity = promotionalFare.AirlineCities1.CityCode;
                //model.DepartureDate = promotionalFare.DepartureDate;
                //model.DepartureTime = promotionalFare.DepartureTime;
                //model.ArrivalDate = promotionalFare.ArrivalDate;
                //model.ArrivalTime = promotionalFare.ArrivalTime;
                //model.Currency = promotionalFare.Currencies.CurrencyCode;
                //model.BaseFare = promotionalFare.BaseFare;
                //model.Tax = promotionalFare.Air_PromotionalFareTaxes.Sum(z => z.TaxAmount);
                //model.OtherCharges = promotionalFare.OtherCharges;
                //model.EffectiveFrom = promotionalFare.EffectiveFrom;
                //model.ExpireOn = promotionalFare.ExpireOn;
                //model.NoOfPax = promotionalFare.NoOfPax;
                model.FlightNo = promotionalFare.Air_PromotionalFareSegments.FirstOrDefault() != null ? promotionalFare.Air_PromotionalFareSegments.FirstOrDefault().FlightNo : null;

                promotionalFareListModel.Add(model);
            }

            return promotionalFareListModel;
        }



        public PromotionalFareModel GetPromotionalFareSetupCreateModel()
        {
            GeneralProvider generalProvider = new GeneralProvider();

            PromotionalFareModel model = new PromotionalFareModel();

            PromotionalFareSector promotionalFareSector = new PromotionalFareSector();
            List<PromotionalFareSegment> segments = new List<PromotionalFareSegment>();
            PromotionalFareSegment segment = new PromotionalFareSegment();
            var cities=generalProvider.GetAirlineCityList();

            segment.FromCityList = cities;
            segment.ToCityList = cities;
            segments.Add(segment);
            promotionalFareSector.PromotionalFareSegment=segments;

            //promotionalFareSector.CityList = generalProvider.GetAirlineCityList();
            promotionalFareSector.AirlinesList = generalProvider.GetInternationAirlinesList(1);
            promotionalFareSector.CurrencyList = generalProvider.GetCurrencyList();
            model.PromotionalFareSector = promotionalFareSector;
            return model;
        }

        public PromotionalFareModel GetPromotionalFareSetupEditModel(Int64 promotionalFareId)
        {
            GeneralProvider generalProvider = new GeneralProvider();
            PromotionalFareModel model = new PromotionalFareModel();
            PromotionalFareSector promotionalFareSector = new PromotionalFareSector();

            Air_PromotionalFares promotionalFares = entity.Air_PromotionalFares.Where(x => x.PromotionalFareId == promotionalFareId).FirstOrDefault();
            if (promotionalFares != null)
            {
              //  promotionalFareSector.CityList = generalProvider.GetAirlineCityList();
                //promotionalFareSector.AirlinesList = generalProvider.GetInternationAirlinesList(1);
                //promotionalFareSector.CurrencyList = generalProvider.GetCurrencyList();

                //promotionalFareSector.PromotionalFareId = promotionalFares.PromotionalFareId;
                //promotionalFareSector.AirlineId = promotionalFares.AirlineId;
                
                //promotionalFareSector.TourCode = promotionalFares.TourCode;
                //promotionalFareSector.CurrencyId = promotionalFares.CurrencyId;
                //promotionalFareSector.BICClass = promotionalFares.Class;

                //promotionalFareSector.FareBasis = promotionalFares.FareBasis;
                //promotionalFareSector.EffectiveFrom = promotionalFares.EffectiveFrom;
                //promotionalFareSector.ExpireOn = promotionalFares.ExpireOn;
                //promotionalFareSector.NoOfPax = promotionalFares.NoOfPax;

                //promotionalFareSector.BaseFare = (decimal)promotionalFares.BaseFare;
                //promotionalFareSector.OtherCharges = (decimal)promotionalFares.OtherCharges;
                //promotionalFareSector.NoOfPax = promotionalFares.NoOfPax;

                var taxes = promotionalFares.Air_PromotionalFareTaxes;
                List<PromotionalFareTaxes> promotionalFareTaxesList = new List<PromotionalFareTaxes>();
                foreach (var tax in taxes)
                {
                    PromotionalFareTaxes promotionalFareTaxes = new PromotionalFareTaxes()
                    {
                        PromotionalFareId = tax.PromotionalFareId,
                        PromotionalFareTaxId = tax.PromotionalFareTaxId,
                        TaxName = tax.TaxName,
                        TaxAmount = tax.TaxAmount
                    };
                    promotionalFareTaxesList.Add(promotionalFareTaxes);
                }

                promotionalFareSector.Taxes = promotionalFareTaxesList;

                var segments = promotionalFares.Air_PromotionalFareSegments;
                List<PromotionalFareSegment> promotionalFareSegmentList = new List<PromotionalFareSegment>();
                foreach (var segment in segments)
                {
                    PromotionalFareSegment promotionalFareSegment = new PromotionalFareSegment()
                    {
                        //PromotionalFareId = segment.PromotionalFareId,
                        //PromotionalFareSegmentId = segment.PromotionalFareSegmentId,
                        //FromCity = entity.Air_PromotionalFares.Where(x =>x.FromCityId== segment.FromCityId).Select(x=>x.AirlineCities.CityCode).FirstOrDefault(),
                        //ToCity = entity.Air_PromotionalFares.Where(x => x.ToCityId == segment.ToCityId).Select(x => x.AirlineCities1.CityCode).FirstOrDefault(),
                        //FromCityId = segment.FromCityId,
                        //ToCityId = segment.ToCityId,
                        //DepartureDate = segment.DepartureDate,
                        //DepartureTime = segment.DepartureTime,
                        //ArrivalDate = segment.ArrivalDate,
                        //ArrivalTime = segment.ArrivalTime,
                        //FlightNo = segment.FlightNo,
                        //FromCityList=new SelectList( generalProvider.GetAirlineCityList(),"Value","Text",segment.FromCityId),
                        //ToCityList = new SelectList(generalProvider.GetAirlineCityList(), "Value", "Text", segment.ToCityId)
                    };
                    promotionalFareSegmentList.Add(promotionalFareSegment);
                }
                promotionalFareSector.PromotionalFareSegment = promotionalFareSegmentList;
            }
            model.PromotionalFareSector = promotionalFareSector;
            return model;
        }


        public bool SavePromotionalFare(PromotionalFareModel model)
        {
            //Save Air_PromotionalFares
            Air_PromotionalFares promotionalFareToSave = new Air_PromotionalFares
            {
                //AirlineId = model.PromotionalFareSector.AirlineId,
                //FromCityId = model.PromotionalFareSector.PromotionalFareSegment.FirstOrDefault().FromCityId,
                //ToCityId = model.PromotionalFareSector.PromotionalFareSegment.LastOrDefault().ToCityId,
                //DepartureDate = model.PromotionalFareSector.PromotionalFareSegment.FirstOrDefault().DepartureDate,
                //ArrivalDate = model.PromotionalFareSector.PromotionalFareSegment.LastOrDefault().ArrivalDate,
                //DepartureTime = model.PromotionalFareSector.PromotionalFareSegment.FirstOrDefault().DepartureDate.Value.TimeOfDay,
                //ArrivalTime = model.PromotionalFareSector.PromotionalFareSegment.LastOrDefault().ArrivalDate.Value.TimeOfDay,
                //TourCode = model.PromotionalFareSector.TourCode,
                //CurrencyId = model.PromotionalFareSector.CurrencyId,
                //BaseFare = (double)model.PromotionalFareSector.BaseFare,
                //OtherCharges = (double)model.PromotionalFareSector.OtherCharges,
                //Class = model.PromotionalFareSector.BICClass,
                //FareBasis = model.PromotionalFareSector.FareBasis,
                //EffectiveFrom = model.PromotionalFareSector.EffectiveFrom,
                //ExpireOn = model.PromotionalFareSector.ExpireOn,
                //NoOfPax = model.PromotionalFareSector.NoOfPax,
                //CreatedBy = 1,
                //CreatedDate = DateTime.UtcNow,
                //isActive = true
            };
            entity.AddToAir_PromotionalFares(promotionalFareToSave);
            entity.SaveChanges();

            SavePromotionalSegments(model, promotionalFareToSave.PromotionalFareId);
            SavePromotionalFareTaxes(model, promotionalFareToSave.PromotionalFareId);
            entity.SaveChanges();
            return true;
        }

        public bool EditPromotionalFare(PromotionalFareModel model)
        {
            Air_PromotionalFares promotionalFareToEdit = entity.Air_PromotionalFares.Where(x => x.PromotionalFareId == model.PromotionalFareSector.PromotionalFareId).FirstOrDefault();

            //promotionalFareToEdit.AirlineId = model.PromotionalFareSector.AirlineId;

            //promotionalFareToEdit.FromCityId = model.PromotionalFareSector.PromotionalFareSegment.FirstOrDefault().FromCityId;
            //promotionalFareToEdit.ToCityId = model.PromotionalFareSector.PromotionalFareSegment.LastOrDefault().ToCityId;
            //promotionalFareToEdit.DepartureDate = model.PromotionalFareSector.PromotionalFareSegment.FirstOrDefault().DepartureDate;
            //promotionalFareToEdit.ArrivalDate = model.PromotionalFareSector.PromotionalFareSegment.LastOrDefault().ArrivalDate;
            //promotionalFareToEdit.DepartureTime = model.PromotionalFareSector.PromotionalFareSegment.FirstOrDefault().DepartureDate.Value.TimeOfDay;
            //promotionalFareToEdit.ArrivalTime = model.PromotionalFareSector.PromotionalFareSegment.LastOrDefault().ArrivalDate.Value.TimeOfDay;
            //promotionalFareToEdit.TourCode = model.PromotionalFareSector.TourCode;
            //promotionalFareToEdit.CurrencyId = model.PromotionalFareSector.CurrencyId;
            //promotionalFareToEdit.BaseFare = (double)model.PromotionalFareSector.BaseFare;
            //promotionalFareToEdit.OtherCharges = (double)model.PromotionalFareSector.OtherCharges;
            //promotionalFareToEdit.Class = model.PromotionalFareSector.BICClass;
            //promotionalFareToEdit.FareBasis = model.PromotionalFareSector.FareBasis;
            //promotionalFareToEdit.EffectiveFrom = model.PromotionalFareSector.EffectiveFrom;
            //promotionalFareToEdit.ExpireOn = model.PromotionalFareSector.ExpireOn;
            //promotionalFareToEdit.NoOfPax = model.PromotionalFareSector.NoOfPax;
            //promotionalFareToEdit.CreatedBy = 1;
            //promotionalFareToEdit.CreatedDate = DateTime.UtcNow;
            //promotionalFareToEdit.isActive = true;

            entity.ApplyCurrentValues(promotionalFareToEdit.EntityKey.EntitySetName, promotionalFareToEdit);

            EditPromotionalSegments(model);
            EditPromotionalFareTaxes(model);
            entity.SaveChanges();
            return true;
        }



        public void SavePromotionalSegments(PromotionalFareModel model, Int64 promotionalFareId)
        {
            //Save Air_PromotionalFareSegments
            foreach (var segment in model.PromotionalFareSector.PromotionalFareSegment)
            {
                Air_PromotionalFareSegments promotionalFareSegmentsToSave = new Air_PromotionalFareSegments()
                {
                    //PromotionalFareId = promotionalFareId,
                    //FromCityId = segment.FromCityId,
                    //ToCityId = segment.ToCityId,
                    //DepartureDate = segment.DepartureDate,
                    //DepartureTime = segment.DepartureTime,
                    //ArrivalDate = segment.ArrivalDate,
                    //ArrivalTime = segment.ArrivalTime,
                    //FlightNo = segment.FlightNo
                };
                entity.AddToAir_PromotionalFareSegments(promotionalFareSegmentsToSave);
            }
        }

        public void EditPromotionalSegments(PromotionalFareModel model)
        {
            foreach (PromotionalFareSegment segment in model.PromotionalFareSector.PromotionalFareSegment)
            {
                Air_PromotionalFareSegments promotionalFareSegmentsToEdit = entity.Air_PromotionalFareSegments.Where(x => x.PromotionalFareSegmentId == segment.PromotionalFareSegmentId).FirstOrDefault();

                //promotionalFareSegmentsToEdit.PromotionalFareSegmentId = segment.PromotionalFareSegmentId;
                //promotionalFareSegmentsToEdit.PromotionalFareId = model.PromotionalFareSector.PromotionalFareId;
                //promotionalFareSegmentsToEdit.FromCityId = segment.FromCityId;
                //promotionalFareSegmentsToEdit.ToCityId = segment.ToCityId;
                //promotionalFareSegmentsToEdit.DepartureDate = segment.DepartureDate;
                //promotionalFareSegmentsToEdit.DepartureTime = segment.DepartureDate.Value.TimeOfDay;
                //promotionalFareSegmentsToEdit.ArrivalDate = segment.ArrivalDate;
                //promotionalFareSegmentsToEdit.ArrivalTime = segment.ArrivalDate.Value.TimeOfDay;
                //promotionalFareSegmentsToEdit.FlightNo = segment.FlightNo;

                entity.ApplyCurrentValues(promotionalFareSegmentsToEdit.EntityKey.EntitySetName, promotionalFareSegmentsToEdit);
            }
        }

        public void SavePromotionalFareTaxes(PromotionalFareModel model, Int64 promotionalFareId)
        {
            //Save Air_PromotionalFareTaxes
            foreach (var tax in model.PromotionalFareSector.Taxes)
            {
                Air_PromotionalFareTaxes promotionalFareTaxes = new Air_PromotionalFareTaxes()
                {
                    PromotionalFareId = promotionalFareId,
                    TaxName = tax.TaxName,
                    TaxAmount = (double)tax.TaxAmount
                };
                entity.AddToAir_PromotionalFareTaxes(promotionalFareTaxes);
            }
        }

        public void EditPromotionalFareTaxes(PromotionalFareModel model)
        {
            foreach (PromotionalFareTaxes tax in model.PromotionalFareSector.Taxes)
            {
                Air_PromotionalFareTaxes promotionalFareTaxToEdit = entity.Air_PromotionalFareTaxes.Where(x => x.PromotionalFareTaxId == tax.PromotionalFareTaxId).FirstOrDefault();

                promotionalFareTaxToEdit.PromotionalFareTaxId = tax.PromotionalFareTaxId;
                promotionalFareTaxToEdit.PromotionalFareId = model.PromotionalFareSector.PromotionalFareId;
                promotionalFareTaxToEdit.TaxName = tax.TaxName;
                promotionalFareTaxToEdit.TaxAmount = (double)tax.TaxAmount;

                entity.ApplyCurrentValues(promotionalFareTaxToEdit.EntityKey.EntitySetName, promotionalFareTaxToEdit);
            }
        }

        public bool Delete(Int64 promotionalFareId)
        {
            Air_PromotionalFares promotionalFares = entity.Air_PromotionalFares.Where(x => x.PromotionalFareId == promotionalFareId).FirstOrDefault();
            promotionalFares.isActive = false;
            entity.ApplyCurrentValues(promotionalFares.EntityKey.EntitySetName, promotionalFares);
            entity.SaveChanges();
            return true;
        }
    }
}