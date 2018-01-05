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
    public class HotelFacilityController : Controller
    {
        HotelFacilityRepository _repo = new HotelFacilityRepository();
        //
        // GET: /HotelFacility/

        public ActionResult Index()
        {
            return View();
        }
        //
        public ActionResult List()
        {
            return View(_repo.HotelFacilityList());
        }
        //
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(HotelFacilities model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            else
            {
                //Htl_HotelFacilities obj = new Htl_HotelFacilities();

                //obj.FacilityName = model.FacilityName ;
                //obj.Details = model.Details;           
                //obj.isActive = model.isActive;
                //obj.CreatedBy = App_Class.AppSession.LogUserID;
                //obj.CreatedDate = DateTime.Now;

                _repo.HotelFacilityAdd(model);



                return RedirectToAction("List");
            }
        }

        public ActionResult Edit(int id)
        {
            return View(_repo.GetHotelFacilityById(id));
        }

        [HttpPost]
        public ActionResult Edit(HotelFacilities model, int id)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            else
            {


                model.FacilityId = id;
                //Htl_HotelFacilities obj = new Htl_HotelFacilities();
                //obj.FacilityName = model.FacilityName;
                //obj.Details = model.Details;
                //obj.isActive = model.isActive;
                //obj.UpdatedBy = App_Class.AppSession.LogUserID;
                //obj.UpdatedDate = DateTime.Now;

                _repo.HotelFacilityEdit(model);



                return RedirectToAction("List");
            }
        }


        public ActionResult Detail(int id)
        {
            return View(_repo.GetHotelFacilityById(id));
        }

        public ActionResult Delete(int id)
        {
            try
            {
                _repo.HotelFacilityDelete(id);
                return View("List", _repo.HotelFacilityList());// Content("true");
            }
            catch
            {
                return Content("error");
            }
        }

    }
}
