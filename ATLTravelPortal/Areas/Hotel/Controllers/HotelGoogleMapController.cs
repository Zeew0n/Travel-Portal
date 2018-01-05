using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelPortalEntity;
using ATLTravelPortal.App_Class;
using ATLTravelPortal.Helpers;
using ATLTravelPortal.Areas.Hotel.Models;
using ATLTravelPortal.Areas.Hotel.Repository;
using ATLTravelPortal.SecurityAttributes;

namespace ATLTravelPortal.Areas.Hotel.Controllers
{
    [CheckSessionFilter(Order = 1)]
    public class HotelGoogleMapController : Controller
    {


        HotelInfoRepository _HotelInfoRepo = new HotelInfoRepository();
        HotelCityInfoRepository _CityInfoRepo = new HotelCityInfoRepository();
        HotelCityInfoAssociationRepository _CityInfoAssocaitionRepo = new HotelCityInfoAssociationRepository();

        //
        // GET: /HotelGoogleMap/

        public ActionResult Index()
        {
            return View();
        }


        public ActionResult List()
        {
            return View(_CityInfoAssocaitionRepo.HotelCityInfoAssociationList());
        }

        public ActionResult Create()
        {
            var viewModel = new HotelCityInfoAssociation
            {
                HotelNameList = _HotelInfoRepo.HotelInfoList(),
                HotelCityInfoList = _CityInfoRepo.HotelCityInfoList(),



            };
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Create(HotelCityInfoAssociation model)
        {
            var viewModel = new HotelCityInfoAssociation
            {
                HotelNameList = _HotelInfoRepo.HotelInfoList(),
                HotelCityInfoList = _CityInfoRepo.HotelCityInfoList(),


            };

            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }
            else
            {
                //Htl_HotelCityInfoAssociation obj = new Htl_HotelCityInfoAssociation();
                //obj.HotelId = model.HotelId;
                //obj.CityId = model.CityId;
                //obj.Latitude = model.Latitude;
                //obj.Longitude = model.Longitude;

                _HotelInfoRepo.HotelCityInfoAssociationAdd(model);
            }

            ViewData["success"] = "Record successfully added.";

            return View(viewModel);
            //return View("List", viewModel);

        }

        public ActionResult Edit(int id)
        {
            return View(GetViewModel(id));
        }

        [HttpPost]
        public ActionResult Edit(HotelCityInfoAssociation model, int id)
        {
            var viewModel = new HotelCityInfoAssociation
            {
                HotelNameList = _HotelInfoRepo.HotelInfoList(),
                HotelCityInfoList = _CityInfoRepo.HotelCityInfoList(),


            };

            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }
            else
            {
                //Htl_HotelCityInfoAssociation obj = new Htl_HotelCityInfoAssociation();
                //obj.HotelId = model.HotelId;
                //obj.CityId = model.CityId;
                //obj.Latitude = model.Latitude;
                //obj.Longitude = model.Longitude;

                _HotelInfoRepo.HotelCityInfoAssociationEdit(model);
            }

            ViewData["success"] = "Record edited successfully .";

            return View(viewModel);
            //return View ("List", viewModel);

        }

        private HotelCityInfoAssociation GetViewModel(int id)
        {
            Htl_HotelCityInfoAssociation recordToEdit;
            recordToEdit = _CityInfoAssocaitionRepo.GetHotelCityInfoAssociationyByHotelId(id);

            var viewModel = new HotelCityInfoAssociation
            {
                HotelNameList = _HotelInfoRepo.HotelInfoList(),
                HotelCityInfoList = _CityInfoRepo.HotelCityInfoList(),

                HotelId = recordToEdit.HotelId,
                CityId = recordToEdit.CityId,
                Latitude = recordToEdit.Latitude,
                Longitude = recordToEdit.Longitude,


            };
            return viewModel;
        }

        public ActionResult Detail(int id)
        {

            return View(_CityInfoAssocaitionRepo.HotelCityInfoAssociationByHotelId(id));

        }

        /// <summary>
        /// Get Models
        /// </summary>
        /// <param name="HotelId"></param>
        /// <returns></returns>
        //public JsonResult GetHotelCityInfo(string id)
        //{
        //    JsonResult result = new JsonResult();

        //    var filteredModels = _CityInfoAssocaitionRepo.HotelCityInfoAssociationByHotelId(int.Parse(id));

        //    result.Data = filteredModels.ToList();
        //    result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
        //    return result;
        //}



        //public ActionResult HotelsForMap(int id)
        //{
        //    JsonResult jsResult = new JsonResult();
        //    jsResult.Data = new HotelCityInfoAssociationRepository().GetHotels(id);

        //    return Json(jsResult, JsonRequestBehavior.AllowGet);
        //}

    }
}
