using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Common;
using System.Data.Objects;
using ATLTravelPortal.Areas.Airline.Models;
using TravelPortalEntity;
using ATLTravelPortal.Helpers;

namespace ATLTravelPortal.Areas.Airline.Repository
{
    public class AirLineScheduleProvider
    {
        EntityModel ent = new EntityModel();

        public void AddAirLineSchedule(AirlineSchedules obj)
        {
            EntityModel ent = new EntityModel();
            ent.AddToAirlineSchedules(obj);
            ent.SaveChanges();
        }

        public void addAirLineSchedule(AirLineScheduleModel obj)
        {
            AirlineSchedules model = new AirlineSchedules
            {
                AirlineId = obj.AirlineId,
                DepartureCityId = obj.DepartureCityId,
                ArrivalTime = obj.ArrivalTime,
                DepartureTime = obj.DepartureTime,
                FlightNumber = obj.FlightNumber,
                Fare = obj.Fare,
                DestinationCityId = obj.DestinationCityId,
                ScheduleId = obj.ScheduleId,
                Sunday = obj.Sunday,
                Monday = obj.Monday,
                Tuesday = obj.Tuesday,
                Wednesday = obj.Wednesday,
                Thrusday = obj.Thursday,
                Friday = obj.Friday,
                Saturday = obj.Saturday

            };
            ent.AddToAirlineSchedules(model);
            ent.SaveChanges();
        }
        public IEnumerable<AirlineSchedules> GetAirLineSchedule()
        {
            EntityModel ent = new EntityModel();
            foreach (var airschdule in ent.AirlineSchedules)
            {
                yield return airschdule;
            }
        }
        public IEnumerable<AirLineScheduleModel> GetAirlineScheduleByName(string airlineName)
        {
            int AirlineId = ent.Airlines.Where(x => x.AirlineName == airlineName).Select(x=>x.AirlineId).FirstOrDefault();
            var item = ent.sp_Schedule().Where(x=>x.AirlineId == AirlineId);
            List<AirLineScheduleModel> model = new List<AirLineScheduleModel>();
            foreach (var result in item)
            {
                AirLineScheduleModel obj = new AirLineScheduleModel
                {
                    ScheduleId = result.ScheduleId,
                    AirLineName = result.AirlineName,
                    DepartureCity = result.DepartureCity,
                    DestinationCity = result.DestinationCity,
                    FlightNumber = result.FlightNumber,


                };
                model.Add(obj);
            }

            return model.AsEnumerable();
        }
        public AirlineSchedules GetAirLineScheduleById(int ScheduleId)
        {
            EntityModel ent = new EntityModel();
            return ent.AirlineSchedules.Where(x => x.ScheduleId == ScheduleId).FirstOrDefault();
        }

        public AirLineScheduleModel getAirLineScheduleById(int ScheduleId)
        {
            var result = ent.AirlineSchedules.Where(x => x.ScheduleId == ScheduleId).FirstOrDefault();
            AirLineScheduleModel model = new AirLineScheduleModel
            {
                ScheduleId = result.ScheduleId,
                AirlineId = result.AirlineId,
                AirLineName = result.Airlines.AirlineName,
                ArrivalTime = result.ArrivalTime,
                DepartureCityId = result.DepartureCityId,
                DestinationCityId = result.DestinationCityId,
                DepartureTime = result.DepartureTime,
                FlightNumber = result.FlightNumber,
                Fare = result.Fare,
                Sunday = result.Sunday,
                Monday = result.Monday,
                Tuesday = result.Tuesday,
                Wednesday = result.Wednesday,
                Thursday = result.Thrusday,
                Friday = result.Friday,
                Saturday = result.Saturday,

            };
            return model;

        }
        public IEnumerable<sp_Schedule_Result> GetAirLineScheduleLists()
        {
            return ent.sp_Schedule();

        }

        public IEnumerable<AirLineScheduleModel> getAirLineScheduleLists()
        {
            var item = ent.sp_Schedule().OrderBy(x=>x.AirlineName);
            List<AirLineScheduleModel> model = new List<AirLineScheduleModel>();
            foreach (var result in item)
            {
                AirLineScheduleModel obj = new AirLineScheduleModel
                {
                    ScheduleId = result.ScheduleId,
                    AirLineName = result.AirlineName,
                    DepartureCity = result.DepartureCity,
                    DestinationCity = result.DestinationCity,
                    FlightNumber = result.FlightNumber,


                };
                model.Add(obj);
            }

            return model.AsEnumerable();


        }
        public IEnumerable<AirLineScheduleModel> getDomesticAirLineScheduleLists()
        {
            var item = ent.sp_Schedule();
            List<AirLineScheduleModel> model = new List<AirLineScheduleModel>();
            foreach (var result in item)
            {
                AirLineScheduleModel obj = new AirLineScheduleModel
                {
                    ScheduleId = result.ScheduleId,
                    AirLineName = result.AirlineName,
                    DepartureCity = result.DepartureCity,
                    DestinationCity = result.DestinationCity,
                    FlightNumber = result.FlightNumber,


                };
                model.Add(obj);
            }

            return model.AsEnumerable();


        }
        public void EditAirLineSchedule(AirlineSchedules obj)
        {
            EntityModel ent = new EntityModel();
            var result = ent.AirlineSchedules.Where(x => x.ScheduleId == obj.ScheduleId).FirstOrDefault();
            if (result != null)
            {
                ent.ApplyCurrentValues(result.EntityKey.EntitySetName, obj);
                ent.SaveChanges();
            }
        }

        public IEnumerable<AirlineSchedules> GetAllScheduleNameList(string FlightNumber, int maxResult)
        {
            EntityModel ent = new EntityModel();
            return ent.AirlineSchedules.Where(x => (x.AirlineId.ToString().Contains(FlightNumber.ToString()) || x.DepartureCityId.ToString().Contains(FlightNumber.ToLower()) ||
                x.DestinationCityId.ToString().Contains(FlightNumber.ToLower()) || x.FlightNumber.ToLower().Contains(FlightNumber.ToLower()) ||
                x.Sunday.ToString().Contains(FlightNumber.ToLower()) || x.Monday.ToString().Contains(FlightNumber.ToLower()) ||
                x.Tuesday.ToString().Contains(FlightNumber.ToLower()) || x.Wednesday.ToString().Contains(FlightNumber.ToLower()) ||
                x.Thrusday.ToString().Contains(FlightNumber.ToLower()) || x.Friday.ToString().Contains(FlightNumber.ToLower()) ||
                x.Saturday.ToString().Contains(FlightNumber.ToLower()) || x.DepartureTime.ToString().Contains(FlightNumber.ToLower()) ||
                x.ArrivalTime.ToString().Contains(FlightNumber.ToLower()) || x.Fare.ToString().Contains(FlightNumber.ToLower()))).Select(x =>
                                new AirlineSchedules
                                {
                                    AirlineId = x.AirlineId,
                                    DepartureCityId = x.DepartureCityId,
                                    DestinationCityId = x.DestinationCityId,
                                    FlightNumber = x.FlightNumber,
                                    Sunday = x.Sunday,
                                    Monday = x.Monday,
                                    Tuesday = x.Tuesday,
                                    Wednesday = x.Wednesday,
                                    Thrusday = x.Thrusday,
                                    Friday = x.Friday,
                                    Saturday = x.Saturday,
                                    DepartureTime = x.DepartureTime,
                                    ArrivalTime = x.ArrivalTime,
                                    Fare = x.Fare,
                                    ScheduleId = x.ScheduleId
                                }
                ).Take(maxResult).ToList();
        }
        public IEnumerable<Airlines> GetAllAirlineNameList(string AirlineNameCode, int maxResult)
        {
            EntityModel ent = new EntityModel();
            return ent.Airlines.Where(x=>x.AirlineTypeId==2).Where(x => ( x.AirlineName.ToLower().Contains(AirlineNameCode.ToLower()) || x.AirlineCode.ToLower().Contains(AirlineNameCode.ToLower()))).Take(maxResult).ToList().Select(x =>
                                new Airlines { AirlineName = x.AirlineName, AirlineId = x.AirlineId, AirlineCode = x.AirlineCode }
                );
        }
        public void DeleteSchedule(int id)
        {
            AirlineSchedules obj = ent.AirlineSchedules.Where(x => x.ScheduleId == id).FirstOrDefault();
            ent.DeleteObject(obj);
            ent.SaveChanges();
        }
        public bool CheckCities(int FromCity, int ToCity)
        {
            if (FromCity == ToCity)
            {
                return false;
            }
            else
                return true;
        }
        public bool CheckTime(TimeSpan From, TimeSpan To)
        {
            int check = TimeSpan.Compare(From, To);
            if (check == 0 || check > 0)
            {
                return false;
            }
            else
                return true;
        }
        
    }
}