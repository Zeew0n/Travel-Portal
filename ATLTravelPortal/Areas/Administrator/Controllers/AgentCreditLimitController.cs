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

namespace ATLTravelPortal.Areas.Administrator.Controllers
{
    [CheckSessionFilter(Order = 1)]
    [PermissionDetails(View = "Index", Edit = "Edit", Add = "Create", Delete = "Delete", Details = "Details", Custom1 = "UnapprovedCreditLimit",Custom2="Reject", Order = 2)]
    public class AgentCreditLimitController : Controller
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
                AgentList = ser.GetAllAgentList(),
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

            TravelSession ts = (TravelSession)Session["TravelPortalSessionInfo"];
            model.MakerId = ts.AppUserId;
            model.CheckerId = ts.AppUserId;
            if (Request.IsAjaxRequest())
            {
                CreditLimitModel viewModel = new CreditLimitModel();
                ViewData["Agent"] = ser.GetAllAgentList();
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


            ser.CreditLimitAdd(model);
            return RedirectToAction("Index");


        }


        public ActionResult Edit(int id)
        {
            CreditLimitModel model = new CreditLimitModel();
            model = ser.GetCreditLimitDetail(id);
            model.hdfagentid = model.ddlAgentId;
            ViewData["Bank"] = new SelectList(ser.GetBankList(), "BankId", "BankName");
            ViewData["Agent"] = new SelectList(ser.GetAgentList(), "AgentId", "AgentName");
            ViewData["Type"] = new SelectList(ser.GetTypeList(), "CreditLimitTypeId", "CreditLimitTypeName");
            ViewData["Currency"] = new SelectList(ser.GetCurrencies(), "CurrencyId", "CurrencyCode");

            return View(model);



            // return View(ser.GetCreditLimit(id));
        }



        [HttpPost]
        public ActionResult Edit(CreditLimitModel model, int id)
        {
            TravelSession ts = (TravelSession)Session["TravelPortalSessionInfo"];
            CreditLimitModel m = new CreditLimitModel();
            //  model.ddlTypeId = 2;
            m = ser.GetCreditLimit(id);
            model.CheckerId = ts.AppUserId;
            if (m != null)
            {
                model.hdfbank = model.ddlBankId;
                model.hdfEffectiveFrom = model.FromDate;
                model.hdfExpireOn = model.ToDate;
            }

            int chkduplicate = ser.CheckDuplicateRowForAdmin();

            if (chkduplicate != 0)
            {
                model.AgentCreditLimitId = id;
                ser.CreditLimitEdit(model);
                return RedirectToAction("Index");
            }
            else
            {
                ser.CreditLimitAdd(model);
                return RedirectToAction("Index");
            }

        }

        [HttpGet]
        public ActionResult Index(int? AmountType)
        {
            CreditLimitModel model = new CreditLimitModel();
          
            if (Request.IsAjaxRequest())
            {
                if (AmountType == 1)
                {
                    model.CreditLimitList = ser.GetAgentCreditLimitList().Where(x => (x.hdfEffectiveFrom == null || x.hdfExpireOn < DateTime.Now)).ToList();
                    return PartialView("VUC_Index", model);
                }
                else if (AmountType == 2)
                {
                    model.CreditLimitList = ser.GetAgentCreditLimitList();
                    return PartialView("VUC_Index", model);

                }
                else if (AmountType == 0)
                {
                    model.CreditLimitList = ser.GetAgentCreditLimitList().Where(x => (x.hdfEffectiveFrom != null && x.hdfExpireOn > DateTime.Now)).ToList(); ;
                    return PartialView("VUC_Index", model);
                }
            }
            else
                model.CreditLimitList = ser.GetAgentCreditLimitList().Where(x => (x.hdfEffectiveFrom != null && x.hdfExpireOn > DateTime.Now)).ToList();
            model.ShowHideAmountType = true;
                return View(model);
               // model.CreditLimitList = ser.GetAgentCreditLimitList();
            
        }

        [HttpPost]
        public ActionResult Index(int? AgentId, string AgencyName)
        {
            CreditLimitModel model = new CreditLimitModel();
            if (Request.IsAjaxRequest())
            {
                model.CreditLimitList = ser.GetAgentCreditLimitList().Where(xx => xx.ddlAgentId == AgentId);
                return PartialView("VUC_AgentCreditLimitDetails", model);
            }
            if (AgencyName != null)
            {
                string SearchText = AgencyName.ToString().Trim();
                model.CreditLimitList = ser.GetAgentCreditLimitList().Where(xx => xx.AgencyName.Contains(SearchText));
                return View(model);
            }
            model.ShowHideAmountType = false;
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



        [HttpGet]
        public ActionResult UnapprovedCreditLimit()
        {
            CreditLimitModel model = new CreditLimitModel();

            model.CreditLimitList = ser.GetAgentCreditLimitList().Where(xx => xx.isApproved == false).ToList();
            return View(model);
        }

        public ActionResult Reject(int Id)
        {
            try
            {
                TravelSession ts = (TravelSession)Session["TravelPortalSessionInfo"];
                ser.RejectCreditLimit(Id, ts.AppUserId);
                return RedirectToAction("Index");
            }
            catch
            {
                TempData["error"] = "Cannot reject this record";
                return RedirectToAction("Index");
            }
        }


    }
}
