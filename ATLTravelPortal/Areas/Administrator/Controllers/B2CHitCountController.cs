using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ATLTravelPortal.Areas.Administrator.Models;
using ATLTravelPortal.Areas.Administrator.Repository;
using ATLTravelPortal.SecurityAttributes;

namespace ATLTravelPortal.Areas.Administrator.Controllers
{
     [CheckSessionFilter(Order = 1)]
    public class B2CHitCountController : Controller
    {
        B2CHitCountProvider pro = new B2CHitCountProvider();

        public ActionResult Index()
        {
            B2CHitCountModel model = new B2CHitCountModel();
            model.CountB2CHitCount = pro.GetHitCount(model);
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(B2CHitCountModel model)
        {
            B2CHitCountModel data = new B2CHitCountModel();
            data.CountB2CHitCount = pro.GetHitCount(model);
            return View(data);
        }

    }
}
