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
    public class HotelPhotoCategoryController : Controller
    {

        HotelPhotoCategoryRepository _PhotoCatRepo = new HotelPhotoCategoryRepository();
        HotelInfoRepository _InfoRepo = new HotelInfoRepository();
        //
        // GET: /HotelPhotoCategory/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            return View(_PhotoCatRepo.HotelPhotoCategoryList());
        }

        public ActionResult Create()
        {
            var viewModel = new HotelPhotoCategories
            {
                HotelNameList = _InfoRepo.HotelInfoList(),
            };
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Create(HotelPhotoCategories model)
        {
            var viewModel = new HotelPhotoCategories
            {
                HotelNameList = _InfoRepo.HotelInfoList(),
            };

            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }
            else
            {
                //Htl_HotelPhotoCategories obj = new Htl_HotelPhotoCategories();

                //obj.CategoryName = model.CategoryName;
                //obj.Details = model.Details;
                //obj.HotelId = model.HotelId;
                //obj.isActive = model.isActive;
                //obj.CreatedBy = App_Class.AppSession.LogUserID;
                //obj.CreatedDate = DateTime.Now;

                _PhotoCatRepo.HotelPhotoCategoryAdd(model);



                return RedirectToAction("List");
            }
        }



        public ActionResult Edit(int id)
        {
            return View(GetViewModel(id));
        }

        private HotelPhotoCategories GetViewModel(int id)
        {
            HotelPhotoCategories recordToEdit;
            recordToEdit = _PhotoCatRepo.GetHotelPhotoCategoryById(id);

            var viewModel = new HotelPhotoCategories
            {
                HotelNameList = _InfoRepo.HotelInfoList(),
                CategoryName = recordToEdit.CategoryName,
                Details=recordToEdit.Details,
                HotelId = recordToEdit.HotelId,
                HotelName = recordToEdit.Details,
                isActive = recordToEdit.isActive,
            };
            return viewModel;
        }

        [HttpPost]
        public ActionResult Edit(HotelPhotoCategories model, int id)
        {
            if (!ModelState.IsValid)
            {
                return View(GetViewModel(id));
            }
            else
            {
                //Htl_HotelPhotoCategories obj = new Htl_HotelPhotoCategories();

                model.PhotoCategoryId = id;
                _PhotoCatRepo.HotelPhotoCategoryEdit(model);
                //obj.CategoryName = model.CategoryName;
                //obj.Details = model.Details;
                //obj.HotelId = model.HotelId;
                //obj.isActive = model.isActive;
                //obj.UpdatedBy = App_Class.AppSession.LogUserID;
                //obj.UpdatedDate = DateTime.Now;



                // ViewData["success"] = "Record edited successfully .";

                //return RedirectToAction("List", GetViewModel(id));

                //  return View(GetViewModel(id));

                return RedirectToAction("List");
            }
        }


        public ActionResult Detail(int id)
        {
            return View(_PhotoCatRepo.GetHotelPhotoCategoryById(id));
        }

        public ActionResult Delete(int id)
        {
            try
            {
                _PhotoCatRepo.HotelPhotoCategoryDelete(id);
                return View("List", _PhotoCatRepo.HotelPhotoCategoryList());// Content("true");
            }
            catch
            {
                return Content("error");
            }
        }
    }
}
