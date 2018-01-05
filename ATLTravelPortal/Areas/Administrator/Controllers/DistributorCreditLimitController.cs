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
    //  [PermissionDetails(View = "Index", Edit = "Edit", Add = "Create", Delete = "Delete", Order = 2)]
    public class DistributorCreditLimitController : Controller
    {
        CreditLimitProvider ser = new CreditLimitProvider();

        [HttpGet]
        public ActionResult Create()
        {
            TravelSession ts = SessionStore.GetTravelSession();
            MasterDealProvider masterDealProvider = new MasterDealProvider();

            CreditLimitModel viewModel = new CreditLimitModel()
            {
                AgentList = ser.GetAllAgentListByDistributorId(ts.LoginTypeId),
                TypeList = ser.GetAllTypeList(),
                BankList = ser.GetAllBankList(),
                Currencies = ser.GetAllCurrenciesList()
            };


            viewModel.CreditLimitList = ser.GetDistributorDateList(ts.LoginTypeId).Where(x => (x.hdfEffectiveFrom != null && x.hdfExpireOn >= DateTime.Now)).ToList();
            if (viewModel.CreditLimitList.Count() > 0)
            {
                viewModel.hdfEffectiveFrom = viewModel.CreditLimitList.FirstOrDefault().hdfEffectiveFrom;
                viewModel.hdfExpireOn = viewModel.CreditLimitList.LastOrDefault().hdfExpireOn;
            }

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Create(CreditLimitModel model)
        {
            MasterDealProvider masterDealProvider = new MasterDealProvider();

            TravelSession ts = SessionStore.GetTravelSession();
            model.MakerId = ts.AppUserId;
            model.CheckerId = ts.AppUserId;

            model.CreditLimitList = ser.GetDistributorDateList(ts.LoginTypeId).Where(x => (x.hdfEffectiveFrom != null && x.hdfExpireOn >= DateTime.Now)).ToList();
            if (model.CreditLimitList.Count() > 0)
            {
                model.hdfEffectiveFrom = model.CreditLimitList.FirstOrDefault().hdfEffectiveFrom;
                model.hdfExpireOn = model.CreditLimitList.LastOrDefault().hdfExpireOn;
            }


            if (Request.IsAjaxRequest())
            {
                CreditLimitModel viewModel = new CreditLimitModel();
                ViewData["Agent"] = ser.GetAllAgentListByDistributorId(ts.LoginTypeId);
                ViewData["Type"] = ser.GetAllTypeList();
                ViewData["Bank"] = ser.GetAllBankList();
                viewModel.Currencies = ser.GetAllCurrenciesList();

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
                    viewModel.CreditLimit = ser.GetCreditLimit(model.ddlAgentId);
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
            if (model.hdfEffectiveFrom == model.CreditLimitList.FirstOrDefault().hdfEffectiveFrom && model.hdfExpireOn == model.CreditLimitList.LastOrDefault().hdfExpireOn)
            {
                if (ser.CanDistrubutorAssignCreditLimit(ts.LoginTypeId, (double)model.txtAmount, model.CurrencyId) == true)
                {
                    ser.CreditLimitAdd(model);
                }
                else
                    TempData["InfoMessage"] = "Insufficient balance.";
            }
            else
            {
                TempData["InfoMessage"] = "Insufficient balance.";
            }
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var ts = SessionStore.GetTravelSession();

            CreditLimitModel model = new CreditLimitModel();
            model = ser.GetCreditLimitDetail(id);
            model.hdfagentid = model.ddlAgentId;
            ViewData["Bank"] = new SelectList(ser.GetBankList(), "BankId", "BankName");
            ViewData["Agent"] = new SelectList(ser.GetAllAgentListByDistributorId(ts.LoginTypeId), "Value", "Text");
            ViewData["Type"] = new SelectList(ser.GetTypeList(), "CreditLimitTypeId", "CreditLimitTypeName");
            ViewData["Currency"] = new SelectList(ser.GetAllCurrenciesList(), "Value", "Text");

            model.CreditLimitList = ser.GetDateList(ts.LoginTypeId).Where(x => (x.hdfEffectiveFrom != null && x.hdfExpireOn >= DateTime.Now)).ToList();
            if (model.CreditLimitList.Count() > 0)
            {
                model.hdfEffectiveFrom = model.CreditLimitList.FirstOrDefault().hdfEffectiveFrom;
                model.hdfExpireOn = model.CreditLimitList.LastOrDefault().hdfExpireOn;
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(CreditLimitModel model, int id)
        {
            TravelSession ts = SessionStore.GetTravelSession();
            CreditLimitModel m = new CreditLimitModel();

            m = ser.GetCreditLimit(id);
            model.CheckerId = ts.AppUserId;
            model.MakerId = ts.AppUserId;
            if (m != null)
            {
                model.hdfbank = model.ddlBankId;
                model.hdfEffectiveFrom = model.FromDate;
                model.hdfExpireOn = model.ToDate;

            }
            // int distributorid = ser.GetDistributorIdbyAgentId(model.hdfagentid);
            int chkduplicate = ser.CheckDuplicateRowForAdmin();

            if (chkduplicate != 0)
            {
                model.AgentCreditLimitId = id;
                if (model.isApproved == true)
                {
                    if (ser.CanDistrubutorAssignCreditLimit(ts.LoginTypeId, (double)model.txtAmount, model.CurrencyId) == true)
                    {
                        ser.CreditLimitEdit(model);
                    }
                    else
                    {
                        TempData["InfoMessage"] = "Insufficient balance.";
                    }
                }
                else if (model.isApproved == false)
                {
                    ser.CreditLimitEdit(model);
                }

                else
                {
                    TempData["InfoMessage"] = "Insufficient balance.";
                }
                return RedirectToAction("Index");
            }
            else
            {
                if (model.isApproved == true)
                {

                    if (ser.CanDistrubutorAssignCreditLimit(ts.LoginTypeId, (double)model.txtAmount, model.CurrencyId) == true)
                    {
                        ser.CreditLimitAdd(model);
                    }
                    else
                        TempData["InfoMessage"] = "Insufficient balance.";
                }
                else if (model.isApproved == false)
                {
                    ser.CreditLimitAdd(model);
                }

                else
                {
                    TempData["InfoMessage"] = "Insufficient balance.";
                }
                return RedirectToAction("Index");
            }

        }

        [HttpGet]
        public ActionResult Index(int? AmountType)
        {
            //CreditLimitModel model = new CreditLimitModel();
            //model.CreditLimitList = ser.GetCreditLimitList();
            //return View(model);
            CreditLimitModel model = new CreditLimitModel();
            if (Request.IsAjaxRequest())
            {
                if (AmountType == 1)
                {
                    model.CreditLimitList = ser.GetCreditLimitList().Where(x => (x.hdfEffectiveFrom == null || x.hdfExpireOn < DateTime.Now)).ToList();
                    return PartialView("VUC_Index", model);
                }
                else if (AmountType == 2)
                {
                    model.CreditLimitList = ser.GetCreditLimitList();
                    return PartialView("VUC_Index", model);

                }
                else if (AmountType == 0)
                {
                    model.CreditLimitList = ser.GetCreditLimitList().Where(x => (x.hdfEffectiveFrom != null && x.hdfExpireOn > DateTime.Now)).ToList(); ;
                    return PartialView("VUC_Index", model);
                }
            }
            else
                model.CreditLimitList = ser.GetCreditLimitList().Where(x => (x.hdfEffectiveFrom != null && x.hdfExpireOn > DateTime.Now)).ToList();
            model.ShowHideAmountType = true;
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(int? AgentId, string AgencyName)
        {
            CreditLimitModel model = new CreditLimitModel();
            if (Request.IsAjaxRequest())
            {
                model.CreditLimitList = ser.GetCreditLimitList().Where(xx => xx.ddlAgentId == AgentId);
                return PartialView("VUC_AgentCreditLimitDetails", model);
            }
            if (AgencyName != null)
            {
                string SearchText = AgencyName.ToString().Trim();
                model.CreditLimitList = ser.GetCreditLimitList().Where(xx => xx.AgencyName.Contains(SearchText));
                model.ShowHideAmountType = false;
                return View(model);
            }
            return View(model);
        }

        public ActionResult Delete(int Id)
        {
            try
            {
                ser.RejectCreditLimit(Id);
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
            model = ser.GetCreditLimitDetail(id);

            return View(model);
        }

        [HttpPost]
        public ActionResult Details(CreditLimitModel model, int id)
        {
            try
            {
                TravelSession ts = (TravelSession)Session["TravelPortalSessionInfo"];
                model.CheckerId = ts.AppUserId;
                model.AgentCreditLimitId = id;
                ser.ApproveCreditLimit(model);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(model);
            }
        }
    }
}
