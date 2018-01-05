using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TBO;
using TBO.Payment;
using ATLTravelPortal.CustomAttribute;

namespace ATLTravelPortal.Areas.Administrator.Controllers
{
    [PermissionDetails(View = "Index", Order = 2)]
    public class IndianLCCBalanceController : Controller
    {
        //
        // GET: /Administrator/IndianLCCBalance/

        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public JsonResult Index(FormCollection collection)
        {
                JsonResult result = new JsonResult();
                if(Request.IsAjaxRequest())
                {
                    decimal balance = PaymentInfoManager.GetAgencyBalance();
                    result.Data = balance;
                }
                return result;
        }

        //
        // GET: /Administrator/IndianLCCBalance/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Administrator/IndianLCCBalance/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        
        //
        // GET: /Administrator/IndianLCCBalance/Edit/5
 
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Administrator/IndianLCCBalance/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Administrator/IndianLCCBalance/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Administrator/IndianLCCBalance/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
