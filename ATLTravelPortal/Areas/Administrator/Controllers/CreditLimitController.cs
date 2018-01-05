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
using ATLTravelPortal.Areas.Airline.Repository;
using ATLTravelPortal.Areas.Airline;

namespace ATLTravelPortal.Areas.Administrator.Controllers
{
    [CheckSessionFilter(Order = 1)]
    [PermissionDetails(View = "Index", Edit = "Edit", Add = "Create", Delete = "Delete", Order = 2)]
    public class CreditLimitController : Controller
    {
        //
        // GET: /CreditLimit/

        CreditLimitProvider ser = new CreditLimitProvider();

        [HttpGet]
        public ActionResult Create()
        {
            TravelSession ts = (TravelSession)Session["TravelPortalSessionInfo"];
            MasterDealProvider masterDealProvider = new MasterDealProvider();

            CreditLimitModel viewModel = new CreditLimitModel()
            {
                AgentList = ser.GetAllBranchOfficeList(),
                TypeList = ser.GetAllTypeList(),
                BankList = ser.GetAllBankList(),
                Currencies = masterDealProvider.GetCurrencyList()
            };
            return View(viewModel);
        }




        [HttpPost]
        public ActionResult Create(CreditLimitModel model)
        {
            MasterDealProvider masterDealProvider = new MasterDealProvider();

            TravelSession ts = SessionStore.GetTravelSession();
            model.MakerId = ts.AppUserId;
            model.CheckerId = ts.AppUserId;
            if (Request.IsAjaxRequest())
            {
                CreditLimitModel viewModel = new CreditLimitModel();
                ViewData["Agent"] = ser.GetAllBranchOfficeList();
                ViewData["Type"] = ser.GetAllTypeList();
                ViewData["Bank"] = ser.GetAllBankList();
                viewModel.Currencies = masterDealProvider.GetCurrencyList();

                if (model.ddlTypeId == 2)
                {
                    model.hdBank = false;
                    model.hdEffectiveFrom = false;
                    model.hdExpireOn = false;
                    model.hdAmount = true;
                    model.showbutton = true;

                    viewModel.ddlTypeId = 2;

                    viewModel.BankList = ser.GetAllBankList();
                    viewModel.hdAmount = true;
                    viewModel.showbutton = true;
                }
                else
                {
                    viewModel.hdBank = true;
                    viewModel.hdEffectiveFrom = true;
                    viewModel.hdExpireOn = true;
                    viewModel.hdAmount = true;
                    viewModel.showbutton = true;

                    viewModel.CreditLimit = ser.GetAdminCreditLimit(model.ddlAgentId);

                    if (viewModel.CreditLimit != null)
                    {
                        viewModel.BankList = ser.GetAllBankList();
                    }
                    else
                    {
                        viewModel.BankList = ser.GetAllBankList();
                        viewModel.ddlTypeId = model.ddlTypeId;
                        viewModel.ddlAgentId = model.ddlAgentId;

                        return PartialView("CreditLimitSettingPartial", viewModel);
                    }
                }
                if (viewModel.CreditLimit != null)
                {
                    return PartialView("CreditLimitSettingPartial", viewModel);
                }
                else
                {
                    return PartialView("CreditLimitSettingPartial", viewModel);
                }
            }

            model.BankList = ser.GetAllBankList();
            ser.AdminCreditLimitAdd(model);
            //if (ser.CanBranchAssignCreditlimit(model.hdfagentid, (double)model.txtAmount, model.CurrencyId) == true)
            //{
            //    ser.AdminCreditLimitAdd(model);
            //}
            //else
            //{
            //    TempData["InfoMessage"] = "Insufficient balance.";
            //}
            return RedirectToAction("Index");
        }


        public ActionResult Edit(int id)
        {
            CreditLimitModel model = new CreditLimitModel();
            model = ser.GetAdminCreditLimitDetail(id);
            model.hdfagentid = model.ddlAgentId;
            ViewData["Bank"] = new SelectList(ser.GetBankList(), "BankId", "BankName");
            ViewData["Agent"] = new SelectList(ser.GetAllBranchOfficeList(), "Value", "Text");
            ViewData["Type"] = new SelectList(ser.GetTypeList(), "CreditLimitTypeId", "CreditLimitTypeName");
            ViewData["Currency"] = new SelectList(ser.GetCurrencies(), "CurrencyId", "CurrencyCode");

            return View(model);
        }



        [HttpPost]
        public ActionResult Edit(CreditLimitModel model, int id)
        {
            var ts = SessionStore.GetTravelSession();
            CreditLimitModel m = new CreditLimitModel();
           
            m = ser.GetAdminCreditLimit(id);
            model.CheckerId = ts.AppUserId;
            model.MakerId = ts.AppUserId;
            if (m != null)
            {
                model.hdfbank = model.ddlBankId;
                model.hdfEffectiveFrom = model.FromDate;
                model.hdfExpireOn = model.ToDate;
            }

            int chkduplicate = ser.CheckDuplicateRow();

            if (chkduplicate != 0)
            {
                model.AgentCreditLimitId = id;
                ser.AdminCreditLimitEdit(model);
                return RedirectToAction("Index");
            }
            else
            {
                ser.AdminCreditLimitAdd(model);
                return RedirectToAction("Index");
            }

        }

        [HttpGet]
        public ActionResult Index(int? AmountType)
        {
            //model.CreditLimitList = ser.GetAdminCreditLimitList();
            CreditLimitModel model = new CreditLimitModel();

            if (Request.IsAjaxRequest())
            {
                if (AmountType == 1)
                {
                    model.CreditLimitList = ser.GetAdminCreditLimitList().Where(x => (x.hdfEffectiveFrom == null || x.hdfExpireOn < DateTime.Now)).ToList();
                    return PartialView("VUC_Index", model);
                }
                else if (AmountType == 2)
                {
                    model.CreditLimitList = ser.GetAdminCreditLimitList();
                    return PartialView("VUC_Index", model);

                }
                else if (AmountType == 0)
                {
                    model.CreditLimitList = ser.GetAdminCreditLimitList().Where(x => (x.hdfEffectiveFrom != null && x.hdfExpireOn > DateTime.Now)).ToList(); ;
                    return PartialView("VUC_Index", model);
                }
            }
            else
                model.CreditLimitList = ser.GetAdminCreditLimitList().Where(x => (x.hdfEffectiveFrom != null && x.hdfExpireOn > DateTime.Now)).ToList();
            model.ShowHideAmountType = true;
            return View(model);
          
        }

        [HttpPost]
        public ActionResult Index(int? AgentId, string AgencyName)
        {
            CreditLimitModel model = new CreditLimitModel();
            if (Request.IsAjaxRequest())
            {
                model.CreditLimitList = ser.GetAdminCreditLimitList().Where(xx => xx.ddlAgentId == AgentId);
                return PartialView("VUC_AgentCreditLimitDetails", model);
            }
            if (AgencyName != null)
            {
                string SearchText = AgencyName.ToString().Trim();
                model.CreditLimitList = ser.GetAdminCreditLimitList().Where(xx => xx.AgencyName.Contains(SearchText));
                model.ShowHideAmountType = false;
                return View(model);
            }
            return View(model);
        }

        public ActionResult Delete(int Id)
        {
            try
            {

                ser.RejectAdminCreditLimit(Id);
                return RedirectToAction("Index");
            }
            catch
            {
                TempData["error"] = "Cannot reject this record";
                return RedirectToAction("Index");
            }
        }


        public ActionResult Details(int id)
        {
            CreditLimitModel model = new CreditLimitModel();
            model.AgentCreditLimitId = id;
            model = ser.GetAdminCreditLimitDetail(id);

            return View(model);
        }
        public ActionResult Reject(int Id)
        {
            try
            {
                TravelSession ts = (TravelSession)Session["TravelPortalSessionInfo"];
                ser.RejectBranchOfficeCreditLimit(Id, ts.AppUserId);
                return RedirectToAction("Index");
            }
            catch
            {
                TempData["error"] = "Cannot reject this record";
                return RedirectToAction("Index");
            }
        }


        [HttpPost]
        public ActionResult Details(CreditLimitModel model, int id)
        {
            try
            {
                TravelSession ts = SessionStore.GetTravelSession();
                model.CheckerId = ts.AppUserId;
                model.AgentCreditLimitId = id;
                ser.ApproveBranchOfficesCreditLimit(model);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(model);
            }
        }
    }
}
