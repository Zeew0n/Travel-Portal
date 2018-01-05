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
    public class HotelRoomTypeController : Controller
    {
        HotelRoomTypeRepository _RoomTypeRepo = new HotelRoomTypeRepository();

        //
        // GET: /HotelRoomType/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            var _list = _RoomTypeRepo.HotelRoomTypeList();
            return View(_list);
        }
//
        public ActionResult Create()
        {
            return View();
        }
//
        [HttpPost]
        public ActionResult Create(HotelRoomTypes model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            else
            {
                _RoomTypeRepo.HotelRoomTypeAdd(model);
                //Htl_HotelRoomTypes obj = new Htl_HotelRoomTypes();
                
                //obj.TypeName = model.TypeName;
                //obj.Details = model.Details;
                //obj.RoomCapacity = model.RoomCapacity;
                //obj.isActive = model.isActive;
                //obj.CreatedBy = App_Class.AppSession.LogUserID;
                //obj.CreatedDate = DateTime.Now;
               

                //ViewData["success"] = "Record successfully added.";

                return RedirectToAction("List");
            }
        }

        public ActionResult Edit(int id)
        {
            return View(_RoomTypeRepo.GetHotelRoomTypeById(id));
        }

        [HttpPost]
        public ActionResult Edit(HotelRoomTypes model, int id)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            else
            {
               
                model.HotelRoomTypeId = id;
                _RoomTypeRepo.HotelRoomTypeEdit(model);
                //Htl_HotelRoomTypes obj = new Htl_HotelRoomTypes();

                //obj.HotelRoomTypeId = id;
                //obj.TypeName = model.TypeName;
                //obj.Details = model.Details;
                //obj.RoomCapacity = model.RoomCapacity;
                //obj.isActive = model.isActive;
                //obj.UpdatedBy = App_Class.AppSession.LogUserID;
                //obj.UpdatedDate = DateTime.Now;
                //_RoomTypeRepo.HotelRoomTypeEdit(obj);
               // ViewData["success"] = "Record edited successfully .";

                return RedirectToAction("List");
            }
        }


        public ActionResult Detail(int id)
        {
            return View(_RoomTypeRepo.GetHotelRoomTypeById(id));
        }

   
        public ActionResult Delete(int id)
        {
            try
            {
                _RoomTypeRepo.HotelRoomTypeDelete(id);
                return View("List", _RoomTypeRepo.HotelRoomTypeList());// Content("true");
            }
            catch
            {
                return Content("error");
            }
        }

    }
}
