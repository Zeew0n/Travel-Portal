using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ATLTravelPortal.Areas.Administrator.Models;
using ATLTravelPortal.Areas.Administrator.Repository;
using ATLTravelPortal.CustomAttribute;
using ATLTravelPortal.SecurityAttributes;

namespace ATLTravelPortal.Areas.Administrator.Controllers
{
     [CheckSessionFilter(Order = 1)]
    [PermissionDetails(View = "Index", Edit = "Edit", Add = "Create", Delete = "Delete", Order = 2)]
    public class BankController : Controller
    {
        //
        // GET: /Administrator/Bank/
        BankProvider ser = new BankProvider();


        public ActionResult Index()
        {
            BankModel model = new BankModel();
            model.BankList = ser.ListBank();
            return View(model);
        }

        public ActionResult Create()
        {
            BankModel model = new BankModel();
            ser.FillDdl(model);
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(BankModel model)
        {
            try
            {
                ser.FillDdl(model);
                ser.CreateBank(model);
            }
            catch
            {
            }
            return RedirectToAction("Index");

        }

        [HttpGet]
        public ActionResult Edit(int Id)
        {
            BankModel model = new BankModel();
           
            model = ser.BankDetail(Id);
            ser.FillDdl(model);
            model.BankId = Id;

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(int Id, BankModel model)
        {
            model.BankId = Id;
            try
            {
                ser.EditBank(model);
            }
            catch
            {
            }

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int Id)
        {
            ser.BankDelete(Id);
            return RedirectToAction("Index");
        }

        public ActionResult Detail(int id)
        {

            BankModel model = new BankModel();
            model = ser.BankDetail(id);

            return View(model);


        }

        


    }
}
