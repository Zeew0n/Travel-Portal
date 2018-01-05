using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ATLTravelPortal.Areas.Airline.Models;
using TravelPortalEntity;
using ATLTravelPortal.Helpers;
using ATLTravelPortal.SecurityAttributes;
using ATLTravelPortal.CustomAttribute;
using ATLTravelPortal.Areas.Airline.Repository;
namespace ATLTravelPortal.Areas.Airline.Controllers
{
    [CheckSessionFilter(Order = 1)]
    [PermissionDetails(View = "Index", Edit = "Edit", Add = "Create", Details = "Details",Delete="Delete", Order = 2)]
    public class AirLineScheduleController : Controller
    {

       AirLineScheduleProvider ser = new AirLineScheduleProvider();

        AirLineCityInformationProvider _airCity = new AirLineCityInformationProvider();
        GeneralProvider _provider = new GeneralProvider();
        EntityModel ent = new EntityModel();
        //
        // GET: /AirLineSchesule/
        public ActionResult Index()
        {
            // var model = ser.GetAirLineScheduleLists();
            //return View("~/Views/AirLineSchesule/List.aspx", model);
            List<SelectListItem> AirlineTypes = new List<SelectListItem>();

            AirlineTypes.Add(new SelectListItem { Text = "International", Value = "1" });
            AirlineTypes.Add(new SelectListItem { Text = "Domestic", Value = "2" });
            ViewData["AirlineType"] = new SelectList(AirlineTypes, "Value", "Text");
            //if (Request.IsAjaxRequest())
            //{

                
            //        var domestic = new AirLineScheduleModel
            //        {
            //            //airlineTravelportalList = _tfareprovider.GetDomesticTravelFare()
            //        };
            //        return PartialView("ListPartial", domestic);
                
            //}
            AirLineScheduleModel model = new AirLineScheduleModel();
            model.AirLineScheduleList = ser.getAirLineScheduleLists();
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(FormCollection fc)
        {
            if (Request.IsAjaxRequest())
            {
                string airlinename = fc["SearchAirline"];
                if (airlinename != null && airlinename != "")
                {
                    //var result = ser.GetAirlineScheduleByName(airlinename);
                    var result = new AirLineScheduleModel
                    {
                     AirLineScheduleList = ser.GetAirlineScheduleByName(airlinename)
                    };
                    return PartialView("ListPartial", result);
                }
                //var item = ser.getDomesticAirLineScheduleLists();
                var item = new AirLineScheduleModel
                {
                    AirLineScheduleList = ser.getDomesticAirLineScheduleLists()
                };
                return PartialView("ListPartial", item);
            }
            List<SelectListItem> AirlineTypes = new List<SelectListItem>();

            AirlineTypes.Add(new SelectListItem { Text = "International", Value = "1" });
            AirlineTypes.Add(new SelectListItem { Text = "Domestic", Value = "2" });
            ViewData["AirlineType"] = new SelectList(AirlineTypes, "Value", "Text");
            return View();
        }
        [HttpGet]
        public ActionResult Create()
        {
            ViewData["AirLinelist"] = ent.Airlines.Where(x => x.AirlineTypeId == 2).ToList();
            ViewData["DepartureCityList"] = new SelectList(ent.AirlineCities.Where(x => x.AirlineCityTypeId == 2).OrderBy(x=>x.CityName).ToList(), "CityID", "CityName");
            //ViewData["DestinationCityList"] = new SelectList(ent.AirlineCities.Where(x => x.AirlineCityTypeId == 2).ToList(), "CityID", "CityName");
            AirlineSchedules airSchedule = new AirlineSchedules();
            TimeSpan departureTime = airSchedule.DepartureTime;
            //TimeSpan arrivalTime = airSchedule.ArrivalTime;


            return View();
        }

        [HttpPost]
        //public ActionResult Create(AirlineSchedules model)
        public ActionResult Create(AirLineScheduleModel model, FormCollection fc)
        {
            //ser.AddAirLineSchedule(model);

            foreach (var key in fc.Keys)
            {
                var value = fc[key.ToString()];

            }
            string Sun = fc["Sunday"];
            string Mon = fc["Monday"];
            string Tue = fc["Tuesday"];
            string Wed = fc["Wednesday"];
            string Thu = fc["Friday"];
            string Fri = fc["Saturday"];
            string Sat = fc["Saturday"];
            if (Sun.ElementAt(0) == 't')
            {
                model.Sunday = true;
            }
            if (Mon.ElementAt(0) == 't')
            {
                model.Monday = true;
            }
            if (Tue.ElementAt(0) == 't')
            {
                model.Tuesday = true;
            }
            if (Wed.ElementAt(0) == 't')
            {
                model.Wednesday = true;
            }
            if (Thu.ElementAt(0) == 't')
            {
                model.Thursday = true;
            }
            if (Fri.ElementAt(0) == 't')
            {
                model.Friday = true;
            }

            if (Sat.ElementAt(0) == 't')
            {
                model.Saturday = true;
            }
            //model.Sunday = fc["Sunday"].ToString()

            if (ser.CheckCities(model.DepartureCityId, model.DestinationCityId) == false)
            {
                TempData["Cities"] = "Please Check the Cities";
                ModelState.AddModelError("Cities", "Please Check the Cities");
            }
            
            if (model.Sunday == false && model.Monday == false && model.Tuesday == false && model.Wednesday == false && model.Thursday == false && model.Friday == false && model.Saturday == false)
            {
                TempData["Days"] = "Please Select the Date(s)";
                ModelState.AddModelError("Days", "please Select the Date(s)");
            }
            //if (model.ArrivalTime.ToString().ValidateTime() == false && model.DepartureTime.ToString().ValidateTime() == false)
            //{
            //   TempData["Time"] = "Please enter time in correct Format";
            //   ModelState.AddModelError("Time","Please check time format");
            //}
            //string ArrivalTime = model.ArrivalTime.ToString();
            //string DepartureTime = model.DepartureTime.ToString();
            bool checkArrivalTime = model.ArrivalTime.ToString().ValidateTime();
            bool checkDepartureTime = model.DepartureTime.ToString().ValidateTime();
            if (checkArrivalTime == false && checkDepartureTime == false)
            {
                TempData["Times"] = "Please enter time in correct Format";
                ModelState.AddModelError("Time", "Please check time format");
            }
            if (ser.CheckTime(model.DepartureTime, model.ArrivalTime) == false)
            {
                TempData["Time"] = "Please Check the Time";
                ModelState.AddModelError("Time", "Please Check the Time");
            }
            ViewData["AirLinelist"] = ent.Airlines.Where(x => x.AirlineTypeId == 2).ToList();
            ViewData["DepartureCityList"] = new SelectList(ent.AirlineCities.Where(x => x.AirlineCityTypeId == 2).OrderBy(x=>x.CityName).ToList(), "CityID", "CityName");
            if (ModelState.IsValid)
            {
                ser.addAirLineSchedule(model);


                TimeSpan departureTime = model.DepartureTime;
                TimeSpan arrivalTiem = model.ArrivalTime;

                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult Edit(Int32 id)
        {
            ViewData["AirLinelist"] = ent.Airlines.Where(x => x.AirlineTypeId == 2).ToList();
            ViewData["DepartureCityList"] = ent.AirlineCities.Where(x => x.AirlineCityTypeId == 2).ToList();
            ViewData["DestinationCityList"] = ent.AirlineCities.Where(x => x.AirlineCityTypeId == 2).ToList();
            AirlineSchedules airSchedule = new AirlineSchedules();
            TimeSpan departureTime = airSchedule.DepartureTime;
            var model = ser.getAirLineScheduleById(id);
            //var model = ser.GetAirLineScheduleById(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(AirLineScheduleModel model, Int32 id, string[] days)
        {
            if (days != null)
            {
                for (int i = 0; i < days.Length; i++)
                {
                    if (days[i] == "1")
                    {
                        model.Sunday = true;
                    }
                    else if (days[i] == "2")
                    {
                        model.Monday = true;
                    }
                    else if (days[i] == "3")
                    {
                        model.Tuesday = true;
                    }
                    else if (days[i] == "4")
                    {
                        model.Wednesday = true;
                    }
                    else if (days[i] == "5")
                    {
                        model.Thursday = true;
                    }
                    else if (days[i] == "6")
                    {
                        model.Friday = true;
                    }
                    else if (days[i] == "7")
                    {
                        model.Saturday = true;
                    }
                }
            }
            else
            {
                TempData["Days"] = "Please Select the Date(s)";
                ModelState.AddModelError("Days", "please Select the Date(s)");
            }

            if (ser.CheckCities(model.DepartureCityId, model.DestinationCityId) == false)
            {
                TempData["Cities"] = "Please Check the Cities";
                ModelState.AddModelError("Cities", "Please Check the Cities");
            }
            if (ser.CheckTime(model.DepartureTime, model.ArrivalTime) == false)
            {
                TempData["Time"] = "Please Check the Time";
                ModelState.AddModelError("Time", "Please Check the Time");
            }
            if (model.Sunday == false || model.Monday == false || model.Tuesday == false || model.Wednesday == false || model.Thursday == false || model.Friday == false || model.Saturday == false)
            {
                TempData["Days"] = "Please Select the Date(s)";
                ModelState.AddModelError("Days", "please Select the Date(s)");
            }
            ViewData["AirLinelist"] = ent.Airlines.Where(x => x.AirlineTypeId == 2).ToList();
            ViewData["DepartureCityList"] = ent.AirlineCities.Where(x => x.AirlineCityTypeId == 2).ToList();
            ViewData["DestinationCityList"] = ent.AirlineCities.Where(x => x.AirlineCityTypeId == 2).ToList();
            if (this.ModelState.IsValid)
            {
                AirlineSchedules obj = new AirlineSchedules();
                obj.ScheduleId = id;
                obj.AirlineId = model.AirlineId;
                obj.DepartureCityId = model.DepartureCityId;
                obj.DestinationCityId = model.DestinationCityId;
                obj.FlightNumber = model.FlightNumber;
                obj.Sunday = model.Sunday;
                obj.Monday = model.Monday;
                obj.Tuesday = model.Tuesday;
                obj.Wednesday = model.Wednesday;
                obj.Thrusday = model.Thursday;
                obj.Friday = model.Friday;
                obj.Saturday = model.Saturday;
                obj.DepartureTime = model.DepartureTime;
                obj.ArrivalTime = model.ArrivalTime;
                obj.Fare = model.Fare;
                ser.EditAirLineSchedule(obj);
                return RedirectToAction("Index");
            }
            return View(model);
        }
        [HttpGet]
        public ActionResult Details(int id)
        {
            AirLineScheduleModel model = new AirLineScheduleModel();
            model = ser.getAirLineScheduleById(id);
            model.DestinationCity = _provider.GetCityName(model.DestinationCityId);
            model.DepartureCity = _provider.GetCityName(model.DepartureCityId);
            return View(model);

        }
        public ActionResult Delete(int id)
        {
            //if (Request.IsAjaxRequest())
            //{
                ser.DeleteSchedule(id);
                var result = new AirLineScheduleModel 
                {
                 AirLineScheduleList = ser.getDomesticAirLineScheduleLists()
                };
            //    return PartialView("ListPartial", result);
            //}
            return RedirectToAction("Index");
        }
        //[HttpPost]
        //public JsonResult FindAirline(string searchText, int maxResult)
        //{
        //var result = ser.GetAllAirlineNameList(searchText, maxResult);
        //    return Json(result);
        //}


    }
}
