using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ATLTravelPortal.Areas.Hotel.Models;
using ATLTravelPortal.Areas.Hotel.Repository;

namespace ATLTravelPortal.Areas.Hotel.Controllers
{
    public class HotelOfflineBookController : Controller
    {
        //
        // GET: /Hotel/HotelOfflineBook/

        public ActionResult Index(int? page)
        {
            HotelOfflineBookModel _model = new HotelOfflineBookModel();
            HotelOfflineBookRepository _rep = new HotelOfflineBookRepository();
            HotelGeneralRepository.SetRequestPageRow();
            _model.TabularList = _rep.GetPagedList(page);
            return View(_model);
        }

        public ActionResult Detail(long? id)
        {
            HotelOfflineBookModel _model = new HotelOfflineBookModel();
            HotelOfflineBookRepository _rep = new HotelOfflineBookRepository();
            _model = _rep.GetDetail(id);
            return View(_model);
        }

        [HttpPost]
        public ActionResult Detail(HotelOfflineBookModel model, FormCollection fs)
        {
            HotelOfflineBookModel _model = new HotelOfflineBookModel();
            HotelOfflineBookRepository _rep = new HotelOfflineBookRepository();
            try
            {
                if (fs.AllKeys.Contains("Issue"))
                {
                    _rep.UpdateHtl_BookingRecord(model);
                }
                else
                {
                    _rep.CancelOfflineTicket(model);
                }
            }
            catch
            {
                TempData["InfoMessage"] = "Cannot process your request.";
            }
            return RedirectToAction("Index");
        }

    }
}
