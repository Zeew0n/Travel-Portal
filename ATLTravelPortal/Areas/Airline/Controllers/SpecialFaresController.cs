using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ATLTravelPortal.Areas.Airline.Repository;
using ATLTravelPortal.Areas.Airline.Models;
using ATLTravelPortal.Helpers;
using ATLTravelPortal.Helpers.Pagination;

namespace ATLTravelPortal.Areas.Airline.Controllers
{
    public class SpecialFaresController : Controller
    {
        //
        // GET: /Airline/SpecialFares/

        SpecialFaresProvider ser = new SpecialFaresProvider();

        public ActionResult Index(int? page)
        {
            int currentPageIndex = page.HasValue ? page.Value : 1;
            int defaultPageSize = 30;
            SpecialFaresModel model = new SpecialFaresModel();
            model.ListSpecialFares = ser.GetSpecialFaresList().ToPagedList(currentPageIndex, defaultPageSize);
            return View(model);
        }

        public ActionResult Create()
        {
            SpecialFaresModel model = new SpecialFaresModel();
            return View(model);
        }
        [HttpPost]
        public ActionResult Create(SpecialFaresModel model)
        {
            TravelSession obj = (TravelSession)Session["TravelPortalSessionInfo"];
            model.CreatedBy = obj.AppUserId;
            if (model.hdfAirlineName == 0)
            {
                TempData["ErrorMessage"] = "Please, enter proper airline.";
                return View(model);
            }
            else if (model.hdfFromCityId == 0)
            {
                TempData["ErrorMessage"] = "Please, enter proper city.";
                return View(model);
            }
            else if (model.hdfToCityId == 0)
            {
                TempData["ErrorMessage"] = "Please, enter proper city.";
                return View(model);
            }
            else
            {
                try
                {
                    ser.CreateSpecialFares(model);

                }
                catch
                {
                    return View(model);
                }
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int Id)
        {
            SpecialFaresModel model = new SpecialFaresModel();

            model.SpecialFareId = Id;
            model = ser.GetSpecialFaresDetail(Id);

            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(int Id, SpecialFaresModel model)
        {
            TravelSession obj = (TravelSession)Session["TravelPortalSessionInfo"];
            model.SpecialFareId = Id;
            model.UpdatedBy = obj.AppUserId;
            if (model.hdfAirlineName == 0)
            {
                TempData["ErrorMessage"] = "Please, enter proper airline.";
                return View(model);
            }
            else if (model.hdfFromCityId == 0)
            {
                TempData["ErrorMessage"] = "Please, enter proper city.";
                return View(model);
            }
            else if (model.hdfToCityId == 0)
            {
                TempData["ErrorMessage"] = "Please, enter proper city.";
                return View(model);
            }
            else
            {

                try
                {
                    ser.EditSpecialFare(model);

                }
                catch
                {
                    return View(model);
                }
            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int Id)
        {
            try
            {
                ser.DeleteSpecialFare(Id);
            }
            catch
            {
               
            }
            return RedirectToAction("Index");
        }


        [HttpGet]
        public ActionResult Detail(int Id)
        {
            SpecialFaresModel model = new SpecialFaresModel();

            model.SpecialFareId = Id;
            model = ser.GetSpecialFaresDetail(Id);

            return View(model);
        }





        [HttpPost]
        public JsonResult FindAirlineCity(string searchText, int maxResult)
        {
            var result = ser.GetAirlineCity(searchText, maxResult);
            return Json(result);
        }



    }
}
