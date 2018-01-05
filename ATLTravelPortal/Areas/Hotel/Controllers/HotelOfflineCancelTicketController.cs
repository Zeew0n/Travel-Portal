using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ATLTravelPortal.Areas.Hotel.Models;
using ATLTravelPortal.Areas.Hotel.Repository;

namespace ATLTravelPortal.Areas.Hotel.Controllers
{
    public class HotelOfflineCancelTicketController : Controller
    {
        //
        // GET: /Hotel/HotelOfflineCancelTicket/

        public ActionResult Index(int?page)
        {
            HotelOfflineBookModel _model = new HotelOfflineBookModel();
            HotelOfflineCancelTicketRepository _rep = new HotelOfflineCancelTicketRepository();
            HotelGeneralRepository.SetRequestPageRow();
            _model.TabularList = _rep.GetPagedList(page);
            return View(_model);
        }

    }
}
