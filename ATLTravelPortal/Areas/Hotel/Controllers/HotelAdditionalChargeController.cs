using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ATLTravelPortal.Repository;
using ATLTravelPortal.Areas.Hotel.Repository;
using TravelPortalEntity;
using ATLTravelPortal.Helpers;
using ATLTravelPortal.SecurityAttributes;
using ATLTravelPortal.App_Class;
using ATLTravelPortal.Areas.Hotel.Models;


namespace ATLTravelPortal.Areas.Hotel.Controllers
{
      [CheckSessionFilter(Order = 1)]
    public class HotelAdditionalChargeController : Controller
    {
        
        HotelAdditionalChargeRepository _repo = new HotelAdditionalChargeRepository();
        //
        // GET: /HotelAdditionalCharge/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            return View(_repo.HotelAdditionalChargeList());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(HotelAdditionalCharge model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            else
            {
                //Htl_HotelAdditionalCharge obj = new Htl_HotelAdditionalCharge();
              
                //obj.ChargeName = model.ChargeName;
                //obj.Detail = model.Detail;
                //obj.Rate = model.Rate;
                //obj.isActive = model.isActive;        
                //obj.CreatedBy = App_Class.AppSession.LogUserID;
                //obj.CreatedDate = DateTime.Now;

                _repo.HotelAdditionalChargeAdd(model);



                return RedirectToAction("List");
            }
        }

        public ActionResult Edit(int id)
        {
            return View(_repo.GetHotelAdditionalChargeById(id));
        }

        [HttpPost]
        public ActionResult Edit(HotelAdditionalCharge model, int id)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            else
            {
               

                model.ChargeId  = id;
                _repo.HotelAdditionalChargeEdit(model);

                

                return RedirectToAction("List");
            }
        }

        public ActionResult Detail(int id)
        {
            return View(_repo.GetHotelAdditionalChargeById(id));
        }

        public ActionResult Delete(int id)
        {
            try
            {
                _repo.HotelAdditionalChargeDelete(id);
                return View("List", _repo.HotelAdditionalChargeList());// Content("true");
            }
            catch
            {
                return Content("error");
            }
        }

    }
}
