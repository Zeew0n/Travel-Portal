using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelPortalEntity;
using ATLTravelPortal.Areas.Administrator.Models;
using ATLTravelPortal.Helpers;
using ATLTravelPortal.Areas.Administrator.Repository;
using ATLTravelPortal.CustomAttribute;
using ATLTravelPortal.SecurityAttributes;
using ATLTravelPortal.Models;


namespace ATLTravelPortal.Areas.Administrator.Controllers
{
    [CheckSessionFilter(Order = 1)]
    [PermissionDetails(View = "Index", Edit = "Edit", Add = "Create", Details = "Details", Delete = "DeleteBranch", Order = 2)]
    public class BankManagementController : Controller
    {
        //
        // GET: /BankManagements/
        GeneralProvider _gpro = new GeneralProvider();
        BankManagementProvider _pro = new BankManagementProvider();
        ActionResponse _res = new ATLTravelPortal.Models.ActionResponse();
        BankManagementsModel _model = new BankManagementsModel();
        public ActionResult Index()
        {
            BankManagementsModel model = new BankManagementsModel();
            model.BankList = _pro.List();
            return View(model);
        }
        [HttpGet]
        public ActionResult Create(FormCollection fc, BankManagementsModel model)
        {
            _pro.FillDdl(_model);
            return View(_model);
        }
        [HttpPost]
        public ActionResult Create(BankManagementsModel model)
        {
            _pro.Create(model, out _res);
            _pro.FillDdl(model);
            return View("Edit", model);
            //return View("Index", model);
        }

        public ActionResult Edit(int? id)
        {
           
            if (Request.IsAjaxRequest())
            {
                _model = _pro.BranchDetail(id,out _res);
                return PartialView("EditBranch", _model);
            }
            _model = _pro.BankDetail(id, out _res);
            _model.GetAllBranch = _pro.BranchList(id);
            _pro.FillDdl(_model);
            return View(_model);
        }
        [HttpPost]
        public ActionResult Edit(BankManagementsModel model, int id)
        {
            bool check = false;

            // model.hfCheckBankOrBranch = model.hfCheckBankOrBranch.Split(',').ElementAtOrDefault(0);
            int a = id;
            if (model.hfCheckBankOrBranch == 1)
            {
                model.BranchName = model.BranchName.Split(',').ElementAtOrDefault(0);
                model.BranchAddress = model.BranchAddress.Split(',')[0];
                model.BranchContactPerson = model.BranchContactPerson.Split(',').ElementAtOrDefault(0);
                model.BranchContactPhoneNo = model.BranchContactPhoneNo.Split(',').ElementAtOrDefault(0);
                model.BranchPhoneNumber = model.BranchPhoneNumber.Split(',').ElementAtOrDefault(0);
                model.BranchContactEmail = model.BranchContactEmail.Split(',').ElementAtOrDefault(0);
                check = _pro.VerifyBranchInput(model.BankBranchId, model.BranchName, model.BranchAddress, model.BranchCountryId, model.BranchPhoneNumber);
                if (check == true)
                {
                    _pro.UpdateBranch(model);
                    model.GetAllBranch = _pro.BranchList(id);
                    ViewData["Countries"] = _gpro.GetCountryList();
                    return View("Edit", model);
                }
                else
                {
                    return PartialView("BranchList");
                }
            }
            else
            {
                model.BankId = id;
                check = _pro.VerifyBankInput(model.BankName, model.BankAddress, model.PhoneNo, model.ContactPerson);
                if (check == true)
                {
                    _pro.UpdateBanks(model);
                    return RedirectToAction("Index");
                }
                else
                    return RedirectToAction("Index");
            }
        }
        [HttpGet]
        public ActionResult Detail(int? id)
        {
            if (Request.IsAjaxRequest())
            {
                _model = _pro.BranchDetail(id,out _res);

                return PartialView("BranchDetails", _model);
            }

            _model = _pro.BankDetail(id, out _res);
            _model.GetAllBranch = _pro.BranchList(id);
            ViewData["Bank"] = _model.BankName;
            return View(_model);

        }
        [HttpPost]
        public ActionResult Detail(int id, BankManagementsModel obj)
        {
            BankManagementsModel model = new BankManagementsModel();
            if (Request.IsAjaxRequest())
            {
                model = _pro.BranchDetail(id, out _res);
                return PartialView("BranchDetails", model);
            }
            return RedirectToAction("Index");
        }

        public JsonResult DeleteBranch(int id)
        {
            _pro.DeleteBranch(id);
            JsonResult result = new JsonResult();
            result.Data = id;
            return result;
        }


        public ActionResult Delete(int Id)
        {
            try
            {
                _pro.BankDelete(Id);
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }

    }
}
