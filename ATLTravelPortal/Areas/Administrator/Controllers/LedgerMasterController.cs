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
using ATLTravelPortal.Helpers.Pagination;

namespace ATLTravelPortal.Areas.Administrator.Controllers
{
    [CheckSessionFilter(Order = 1)]
    [PermissionDetails(View = "Index", Add = "Create", Details = "Detail", Edit = "Edit", Delete = "Delete", Order = 2)]
    public class LedgerMasterController : Controller
    {
        //
        // GET: /LedgerMaster/

        TravelPortalEntity.EntityModel ent = new TravelPortalEntity.EntityModel();
        LedgerMasterProvider _pro = new LedgerMasterProvider();
        LedgerMasterModel _model = new LedgerMasterModel();
        [HttpGet]
        public ActionResult Create(int? page)
        {
           
            _model = _pro.FillDdl(_model);
            return View(_model);
        }

        [HttpPost]
        public ActionResult Create(LedgerMasterModel model)
        {
            TravelSession obj = (TravelSession)Session["TravelPortalSessionInfo"];
            if (!ModelState.IsValid)
            {
                LedgerMasterModel viewModel = new LedgerMasterModel()
                {
                    ProductNameList = _pro.GetAllProductList(),
                    AccGroupNameList = _pro.GetAllAccountGroupList(),
                    AccSubGroupNameList = _pro.GetAllAccountSubGroupName(),
                    AccTypeNameList = _pro.GetAllAccountTypeName(),
                    ddlAirLinesList = _pro.GetAllAirlinesName()
                };
                return View(viewModel);
            }
            else
            {
                //if((string.IsNullOrEmpty(model.ddlAirLines.ToString())==true) 
                //    model.ddlAirLines=null;

                bool checkLedgerName = _pro.CheckDuplicateLedgerName(model.ddlAirLines, model.LedgerName);
                if (checkLedgerName == false)
                {
                    _pro.LedgerAdd(model);
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["success"] = "Ledger Name already exists!";

                    LedgerMasterModel viewModel1 = new LedgerMasterModel()
                    {
                        ProductNameList = _pro.GetAllProductList(),
                        AccGroupNameList = _pro.GetAllAccountGroupList(),
                        AccSubGroupNameList = _pro.GetAllAccountSubGroupName(),
                        AccTypeNameList = _pro.GetAllAccountTypeName(),
                        ddlAirLinesList = _pro.GetAllAirlinesName()
                    };
                    return View(viewModel1);

                }


                // ser.LedgerAdd(model);
            }
            
        }


        public ActionResult Index(int? page)
        {
            int currentPageIndex = page.HasValue ? page.Value : 1;
            int defaultPageSize = 30;
            _model.LedgerMasterList = _pro.List().ToPagedList(currentPageIndex,defaultPageSize);
            return View(_model);
        }


        [HttpGet]
        public ActionResult Edit(int Id)
        {
            TravelSession obj = (TravelSession)Session["TravelPortalSessionInfo"];
            LedgerMasterModel model = new LedgerMasterModel();

            LedgerMasterModel viewModel = new LedgerMasterModel()
            {
                ProductNameList = _pro.GetAllProductList(),
                AccGroupNameList = _pro.GetAllAccountGroupList(),
                AccSubGroupNameList = _pro.GetAllAccountSubGroupName(),
                AccTypeNameList = _pro.GetAllAccountTypeName(),
                ddlAirLinesList = _pro.GetAllAirlinesName()
            };



            viewModel = _pro.Detail(Id);



            ViewData["Product Name"] = new SelectList(_pro.GetProductList(), "ProductId", "ProductName");
            ViewData["Account Group Name"] = new SelectList(_pro.GetAccountGroupList(), "AccGroupId", "AccGroupName");
            ViewData["Account Sub Group Name"] = new SelectList(_pro.GetAccountSubGroupName(), "AccSubGroupId", "AccSubGroupName");
            ViewData["Account Type Name"] = new SelectList(_pro.GetAccountTypeName(), "AccTypeId", "AccTypeName");



            ViewData["Type Name"] = new SelectList(_pro.GetAllAirlineNameBasedonAccTypeName(viewModel.MapTable, viewModel.DisplayMember, viewModel.ValueMember), "ValueMember", "DisplayMember");
           


            

            return View(viewModel);

        }


       
       

        [HttpPost]
        public ActionResult Edit(int id, LedgerMasterModel model)
        {
           // model = ser.GetLedgerMasterDetail(id);
            model.LedgerId = id;

            bool checkDuplicateLedgerName = _pro.CheckDuplicateLedgerNameforEdit(id, model.ddlAirLines, model.LedgerName);
            if (checkDuplicateLedgerName == false)
            {
                _pro.EditLedgerMaster(model);
                return RedirectToAction("Index");
            }
            else
            {
                TempData["success"] = "Ledger Name already exists!";

                try
                {
                    LedgerMasterModel viewModel = new LedgerMasterModel()
                    {
                        ProductNameList = _pro.GetAllProductList(),
                        AccGroupNameList = _pro.GetAllAccountGroupList(),
                        AccSubGroupNameList = _pro.GetAllAccountSubGroupName(),
                        AccTypeNameList = _pro.GetAllAccountTypeName(),
                        ddlAirLinesList = _pro.GetAllAirlinesName()
                    };

                    viewModel = _pro.Detail(id);



                    ViewData["Product Name"] = new SelectList(_pro.GetProductList(), "ProductId", "ProductName");
                    ViewData["Account Group Name"] = new SelectList(_pro.GetAccountGroupList(), "AccGroupId", "AccGroupName");
                    ViewData["Account Sub Group Name"] = new SelectList(_pro.GetAccountSubGroupName(), "AccSubGroupId", "AccSubGroupName");
                    ViewData["Account Type Name"] = new SelectList(_pro.GetAccountTypeName(), "AccTypeId", "AccTypeName");

                    ViewData["Type Name"] = new SelectList(_pro.GetAllAirlineNameBasedonAccTypeName(viewModel.MapTable, viewModel.DisplayMember, viewModel.ValueMember), "ValueMember", "DisplayMember");

                }
                catch
                {

                }
                return View(model);

                

            }


        }

        public ActionResult Delete(int Id)
        {
            _pro.DeleteLedgerMaster(Id);
            return RedirectToAction("Index");
        }

        public ActionResult Detail(int id)
        {

            _model = _pro.Detail(id);

            ViewData["Type Name"] = _pro.GetddlAirlinesDetail(_model.MapTable, _model.DisplayMember, _model.ValueMember);

            return View(_model);


        }





    }
}
