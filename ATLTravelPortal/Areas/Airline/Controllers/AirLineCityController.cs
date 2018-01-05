#region  © 2010 Arihant Technologies Ltd. All rights reserved
// All rights are reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical or otherwise, is prohibited
// without the prior written permission of the copyright owner.
// Filename: AdminUserManagementController.cs
#endregion


#region Development Track
/*
 * Created By:Madan Tamang
 * Created Date:
 * Updated By:
 * Updated Date:
 * Reason to update:
 */
#endregion


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
    [PermissionDetails(View = "Index", Edit = "Edit", Add = "Create", Delete= "Delete", Order = 2)]
    public class AirLineCityController : Controller
    {
        //
        // GET: /AirLineCity/

       AirLineCityInformationProvider ser = new AirLineCityInformationProvider();


        //Get : /List: AirLine City Information/
        [Authorize]
        public ActionResult Index(int? Type, int? pageNo, int? flag, int? AirlineType)
        {
            TempData["Flag"] = true;
            int currentPageNo = 0; int numberOfPage = 0;
            if (pageNo == null)
                pageNo = 1;
            List<SelectListItem> AirlineTypes = new List<SelectListItem>();

            AirlineTypes.Add(new SelectListItem { Text = "International", Value = "1" });
            AirlineTypes.Add(new SelectListItem { Text = "Domestic", Value = "2" });
            ViewData["AirlineType"] = new SelectList(AirlineTypes, "Value", "Text");
            if (Request.IsAjaxRequest())
            {

                if (AirlineType == 1)
                {
                    var result = ser.GetAllInternationalAirlineCityByByPaging(pageNo.Value, out  currentPageNo, out numberOfPage, flag).ToList();
                    ViewData["TotalPages"] = numberOfPage;
                    ViewData["CurrentPage"] = currentPageNo;
                    return PartialView("AirlineCitySearchResult", result);
                }

                var domestic = ser.GetAllDomesticAirlineCityByByPaging(pageNo.Value, out currentPageNo, out numberOfPage, flag).ToList();
                ViewData["TotalPages"] = numberOfPage;
                ViewData["CurrentPage"] = currentPageNo;
                return PartialView("AirlineCitySearchResult", domestic);


            }
            var model = ser.GetAllInternationalAirlineCityByByPaging(pageNo.Value, out currentPageNo, out numberOfPage, flag).ToList();
            // var model = ser.GetAllAirlineCityByByPaging(pageNo.Value, out  currentPageNo, out numberOfPage, flag).ToList();
            ViewData["TotalPages"] = numberOfPage;
            ViewData["CurrentPage"] = currentPageNo;
            return View(model);
        }


        [HttpPost]
        public ActionResult Index(FormCollection fc, int? pageNo, int? flag, int? AirlineType)
        {
            if (Request.IsAjaxRequest())
            {
                int currentPageNo = 0; int numberOfPage = 0;
                if (pageNo == null)
                    pageNo = 1;
                TempData["Flag"] = false;
                string airlineCityname = fc["SearchCity"];
                if (airlineCityname != null && airlineCityname != "")
                {
                    var result = ser.GetAllSearchAirlineCityNameList(airlineCityname, pageNo.Value, out  currentPageNo, out numberOfPage, flag).Where(aa => aa.CityName.Contains(airlineCityname)).ToList();
                    ViewData["TotalPages"] = numberOfPage;
                    ViewData["CurrentPage"] = currentPageNo;
                    return PartialView("AirlineCitySearchResult", result);
                }
                else 
                {
                    if (AirlineType == 1)
                    {
                        var model = ser.GetAllInternationalAirlineCityByByPaging(pageNo.Value, out currentPageNo, out numberOfPage, flag).ToList();
                        ViewData["TotalPages"] = numberOfPage;
                        ViewData["CurrentPage"] = currentPageNo;
                        TempData["Flag"] = true;
                        return PartialView("AirlineCitySearchResult", model);
                    }
                    else
                    {
                        var domestic = ser.GetAllDomesticAirlineCityByByPaging(pageNo.Value, out currentPageNo, out numberOfPage, flag).ToList();
                        ViewData["TotalPages"] = numberOfPage;
                        ViewData["CurrentPage"] = currentPageNo;
                        TempData["Flag"] = true;
                        return PartialView("AirlineCitySearchResult", domestic);
                    }
                }
                
            }
            return View();
        }


        //Get: /Add Form: AirLine City Information/
        public ActionResult Create()
        {
            var AirLineCityModel = new AirLineCityModel()
            {
                AirlineCityTypList = ser.GetAirlineCityTypeList(),
                CountryList = ser.GetAllCountriesList()
            };
            return View(AirLineCityModel);
        }

        [HttpPost]
        public ActionResult Create(AirLineCityModel model)
        {
            bool check = ser.CheckCityName(model.CityName);
            string Name = model.CityName;
            string Code = model.CityCode;
            if (check == true)
            {
                ser.AddAirLineCityInfo(model);
                return RedirectToAction("Index");
            }
            else
                model = new AirLineCityModel()
            {
                AirlineCityTypList = ser.GetAirlineCityTypeList(),
                CountryList = ser.GetAllCountriesList()
            };
            model.CityName = Name;
            model.CityCode = Code;
            TempData["Error"] = "City Already Exists";
            return View(model);
        }

        //Get: /Update Form: AirLine City Information/
        [HttpGet]
        public ActionResult Edit(Int32 id)
        {
            var model = ser.GetAirLineCityinfoByid(id);
            var AirLineCityModel = new AirLineCityModel()
            {
                CityCode = model.CityCode,
                AirlineCityTypId = model.AirlineCityTypeId,
                CityName = model.CityName,
                CityID = model.CityID,
                CountryId = model.CountryId,
                CountryList = ser.GetAllCountriesList(),
                AirlineCityTypList = ser.GetAirlineCityTypeList()
            };
            return View(AirLineCityModel);
        }

        public ActionResult Details(Int32 id)
        {
            var model = ser.GetAirLineCityinfoByid(id);
            var AirLineCityModel = new AirLineCityModel()
            {
                CityCode = model.CityCode,
                AirlineCityTypId = model.AirlineCityTypeId,
                CityName = model.CityName,
                CityID = model.CityID,
                CountryId = model.CountryId,
                CountryName=model.Countries==null?"":model.Countries.CountryName,
                CountryList = ser.GetAllCountriesList(),
                AirlineCityTypList = ser.GetAirlineCityTypeList()
            };
            return View(AirLineCityModel);
        }

        [HttpPost]
        public ActionResult Edit(AirLineCityModel model, Int32 id)
        {
            if (model.CityCode == "")
            {
                ModelState.AddModelError("", "City Code is Required");
            }
            else if (model.CityName == "")
            {
                ModelState.AddModelError("", "City Name is Required");
            }
            else
            {

                model.CityID = id;
                ser.EditAirLineCityInfo(model);
            }
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            ser.DeleteAirlineCity(id);
            return RedirectToAction("Index");
        }
        /// <summary>
        /// ////////////
        /// </summary>
        /// <param name="searchText"></param>
        /// <param name="maxResult"></param>
        /// <returns></returns>
        //[HttpPost]
        //public JsonResult FindAirlineCity(string searchText, int maxResult)
        //{
        //    var result = GetAirlineCity(searchText, maxResult);
        //    return Json(result);
        //}

        //public List<AirlineCities> GetAirlineCity(string AirlineCityName, int maxResult)
        //{
        //    return ser.GetAllAirlineCityList(AirlineCityName, maxResult).ToList();
        //}
    }
}
