using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ATLTravelPortal.Areas.Administrator.Repository;
using ATLTravelPortal.Areas.Administrator.Models;
using ATLTravelPortal.CustomAttribute;
using ATLTravelPortal.SecurityAttributes;

namespace ATLTravelPortal.Areas.Administrator.Controllers
{
     [CheckSessionFilter(Order = 1)]
    [PermissionDetails(View = "Index", Edit = "Edit", Add = "Create", Delete = "Delete", Details = "Detail", Order = 2)]

    public class BankBranchController : Controller
    {
        //
        // GET: /Administrator/BankBranch/
        BankBranchProvider ser = new BankBranchProvider();

        public ActionResult Index()
        {
            BankBranchModel model = new BankBranchModel();
            model.BankBranchList = ser.ListBankBranch();
            return View(model);
        }

        public ActionResult Create()
        {
            BankBranchModel model = new BankBranchModel();
            ser.FillDdl(model);
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(BankBranchModel model)
        {
            try
            {
                ser.FillDdl(model);
                ser.CreateBankBranch(model);
            }
            catch
            {
            }
            return RedirectToAction("Index");

        }

        [HttpGet]
        public ActionResult Edit(int Id)
        {
            BankBranchModel model = new BankBranchModel();

            model = ser.BankBranchDetail(Id);
            ser.FillDdl(model);
            model.BankBranchId = Id;

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(int Id, BankBranchModel model)
        {
            model.BankBranchId = Id;
            try
            {
                ser.EditBankBranch(model);
            }
            catch
            {
            }

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int Id)
        {
            ser.BankBranchDelete(Id);
            return RedirectToAction("Index");
        }

        public ActionResult Detail(int id)
        {

            BankBranchModel model = new BankBranchModel();
            model = ser.BankBranchDetail(id);

            return View(model);


        }



    }
}
