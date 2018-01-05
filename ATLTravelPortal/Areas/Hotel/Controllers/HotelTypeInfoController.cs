using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelPortalEntity;
using ATLTravelPortal.Areas.Hotel.Repository;
using ATLTravelPortal.Areas.Hotel.Models;
using ATLTravelPortal.Helpers;
using ATLTravelPortal.SecurityAttributes;



namespace ATLTravelPortal.Areas.Hotel.Controllers
{
     [CheckSessionFilter(Order = 1)]
    public class HotelTypeInfoController : Controller
    {
        HotelTypeInfoRepository _HotelTypeInfRepo = new HotelTypeInfoRepository();
        HotelInfoRepository _HotelInfRepo = new HotelInfoRepository();
        //
        // GET: /HotelType/

        public ActionResult Index()
        {
         
            
            return View();
            
        }
//
        public ActionResult List()
        {

            var _list = _HotelTypeInfRepo.HotelTypeInfoList();
            return View(_list);
        }
   //     
        public ActionResult Create( )
        {
            return View();
        }
//
        [HttpPost]
        public ActionResult Create(HotelTypeInfos model)
        {
            var ts = (TravelSession)Session["TravelSessionInfo"];
            if (!ModelState.IsValid)
            {
                return View();
            }
            else
            {
                //Htl_HotelTypeInfos obj = new Htl_HotelTypeInfos();
                //obj.HotelTypeName = model.HotelTypeName;
                //obj.Description = model.Description;
                //obj.isActive = model.isActive;
                //obj.CreatedBy = App_Class.AppSession.LogUserID;
                //obj.CreatedDate = DateTime.Now;
                _HotelTypeInfRepo.HotelTypeInfoAdd(model);

               // ViewData["success"] = "Record successfully added.";

                
                return RedirectToAction("List");
            }
        }
//
        public ActionResult Edit(int id)
        {
            return View(_HotelTypeInfRepo.HotelTypeInfoById(id));
        }

        [HttpPost]
        public ActionResult Edit(HotelTypeInfos model, int id)
        {
            var ts = (TravelSession)Session["TravelSessionInfo"];
            if (!ModelState.IsValid)
            {
                
                return View();
            }
            else
            {
                model.HotelTypeId = id;
                _HotelTypeInfRepo.HotelTypeInfoEdit(model);
                //Htl_HotelTypeInfos obj = new Htl_HotelTypeInfos();
               
                //obj.HotelTypeName = model.HotelTypeName;
                //obj.Description = model.Description;
                //obj.isActive = model.isActive;
                //obj.UpdatedBy = App_Class.AppSession.LogUserID;
                //obj.UpdatedDate = DateTime.Now;
                
                //ViewData["success"] = "Record edited successfully .";

                return RedirectToAction("List");
            }
        }


        public ActionResult Detail(int id)
        {
            return View(_HotelTypeInfRepo.HotelTypeInfoById(id));
        }

        public ActionResult Delete(int id)
        {
            try
            {
                _HotelTypeInfRepo.HotelTypeInfoDelete(id);
                return View("List", _HotelTypeInfRepo.HotelTypeInfoList());
            }
            catch
            {
                return Content("error");
            }
        }
    }
}
