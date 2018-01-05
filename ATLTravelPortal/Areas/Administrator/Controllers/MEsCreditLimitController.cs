using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ATLTravelPortal.Areas.Administrator.Repository;
using ATLTravelPortal.Areas.Administrator.Models;
using ATLTravelPortal.Helpers;
using ATLTravelPortal.SecurityAttributes;

namespace ATLTravelPortal.Areas.Administrator.Controllers
{
    [CheckSessionFilter(Order = 1)]
    public class MEsCreditLimitController : Controller
    {
        //
        // GET: /Administrator/MEsCreditLimit/
        MEsCreditLimitProvider MEcCLP = new MEsCreditLimitProvider();

        public ActionResult Index()
        {
            MEsCreditLimitModel model = new MEsCreditLimitModel();
            model.MEsCreditLimitList = MEcCLP.GetAllCreditLimitList();
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            MEsCreditLimitModel model = new MEsCreditLimitModel();
            model.CurrencyList = new SelectList(MEcCLP.GetCurrency(), "CurrencyId", "CurrencyCode");
            model.MEsList = new SelectList(MEcCLP.GetMEsList(), "AppUserId", "FullName");
            return View(model);

        }
        [HttpPost]
        public ActionResult Create(MEsCreditLimitModel model)
        {
            TravelSession obj = (TravelSession)Session["TravelPortalSessionInfo"];


            if (ModelState.IsValid)
            {
                MEcCLP.Insert(model, obj.AppUserId);
                return RedirectToAction("Index");
            }

            model.CurrencyList = new SelectList(MEcCLP.GetCurrency(), "CurrencyId", "CurrencyCode");
            model.MEsList = new SelectList(MEcCLP.GetMEsList(), "AppUserId", "FullName");
            return View(model);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            MEsCreditLimitModel model = MEcCLP.GetAllCreditLimitList().Where(x => x.MEsCreditLimitId == id).FirstOrDefault();
            model.CurrencyList = new SelectList(MEcCLP.GetCurrency(), "CurrencyId", "CurrencyCode");
            model.MEsList = new SelectList(MEcCLP.GetMEsList(), "AppUserId", "FullName");
            return View(model);
        }

        public ActionResult Edit(int id, MEsCreditLimitModel model)
        {
            TravelSession obj = (TravelSession)Session["TravelPortalSessionInfo"];
            if (ModelState.IsValid)
            {
                MEcCLP.Insert(model,obj.AppUserId);
                return RedirectToAction("Index");
            }

            model.CurrencyList = new SelectList(MEcCLP.GetCurrency(), "CurrencyId", "CurrencyCode");
            model.MEsList = new SelectList(MEcCLP.GetMEsList(), "AppUserId", "FullName");
            return View(model);
        }

        public ActionResult Delete(int id)
        {
            TravelSession obj = (TravelSession)Session["TravelPortalSessionInfo"];
            MEcCLP.Delete(id,obj.AppUserId);
            return RedirectToAction("Index");
        }
    }
}
