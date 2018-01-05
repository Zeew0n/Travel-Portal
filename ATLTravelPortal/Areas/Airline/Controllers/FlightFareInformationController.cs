using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ATLTravelPortal.Areas.Airline.Models;
using ATLTravelPortal.Areas.Airline.Repository;
using ATLTravelPortal.AirArabiaEmailNotification;
using Microsoft.Win32.TaskScheduler;
using ATLTravelPortal.SecurityAttributes;
using ATLTravelPortal.CustomAttribute;

namespace ATLTravelPortal.Areas.Airline.Controllers
{
    [CheckSessionFilter(Order = 1)]
    [PermissionDetails(View = "Index", Add="Create", Order = 2)]
    public class FlightFareInformationController : Controller
    {
        //
        // GET: /Airline/FlightFareInformation/
        FlightFareInformationProvider ser = new FlightFareInformationProvider();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            FlightFareInformationModel model = new FlightFareInformationModel();
            model.DepartCityList = new SelectList(ser.GetDepartCityList(), "CityID", "CityCode");
            model.ArriveCityList = new SelectList(ser.GetArriveCityList(), "CityID", "CityCode");
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(FlightFareInformationModel model)
        {

                try
                {
                    string origin = model.DepartCity;
                    string destination = model.ArriveCity;
                    string[] emails = model.EmailReceivers.SplitNewLine();
                    DateTime taskStartDate = model.TaskBeginDate.Value;
                    DateTime[] departureDate = model.DepartureDate.SplitNewLine().Select(Convert.ToDateTime).ToArray();

                    int hour = Convert.ToInt32(StringHelper.GetHour(model.Duration));
                    int minute = Convert.ToInt32(StringHelper.GetMinute(model.Duration));
                    bool isAm = model.rdbAmPm == AmPm.AM;

                    EmailTask task = new EmailTask(origin, destination, departureDate.Distinct().ToArray());
                    task.EmailReceiver = emails.Distinct(StringComparer.CurrentCultureIgnoreCase).ToArray();
                    task.Time = new TimeSpan(0, isAm ? hour : hour + 12, minute, 0);
                    task.TaskStartDate = taskStartDate;


                    using (var lib = new TaskLibrary())
                    {
                        lib.AddTask(task);

                        TempData["SuccessMessage"] = "Task has been successfully created.";
                        return RedirectToAction("Create");
                    }
                }
                catch (Exception ex)
                {
                    model.DepartCityList = new SelectList(ser.GetCityList(), "CityID", "CityCode");
                    model.ArriveCityList = new SelectList(ser.GetCityList(), "CityID", "CityCode");
                    //TempData["ActionResponse"] = "Unable to create a task.";
                    TempData["ActionResponse"] = ex.Message;

                    return View(model);
                }

         

          
        }

    }
    public static class StringHelper
    {
        public static String[] SplitNewLine(this string text)
        {
            return text.Trim().Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
        }
        public static string GetHour(string duration)
        {
            return duration.Split(':').First();
        }
        public static string GetMinute(string duration)
        {
            return duration.Split(':').Skip(1).Take(1).First();
        }
    }
}
