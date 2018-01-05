
#region  © 2010 Arihant Technologies Ltd. All rights reserved
// All rights are reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical or otherwise, is prohibited
// without the prior written permission of the copyright owner.
// Filename: AdminUserManagementController.cs
#endregion


#region Development Track
/*
 * Created By:Madan Tamang
 * Created Date:
 * Updated By:
 * Updated Date:
 * Reason to update:
 */
#endregion


using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using ATLTravelPortal.Areas.Airline.Models;
using TravelPortalEntity;
using ATLTravelPortal.Helpers;
using System.Web.Script.Serialization;
using System.Text;
using ATLTravelPortal.SecurityAttributes;
using ATLTravelPortal.CustomAttribute;
using ATLTravelPortal.Areas.Airline.Repository;

namespace ATLTravelPortal.Areas.Airline.Controllers
{
    [CheckSessionFilter(Order = 1)]
    [PermissionDetails(View = "Index", Edit = "Edit", Add = "Create", Details = "Details", Delete = "Delete", Order = 2)]
    public class AirLineController : Controller
    {
        //
        // GET: /AirLine/

        AirLineInformationProvider ser = new AirLineInformationProvider();


        // Get : /List: Airline Information/
        [Authorize]
        public ActionResult Index(int? IsActive, int? pageNo, int? flag,int? Type)
        {

            List<SelectListItem> Status = new List<SelectListItem>();
            Status.Add
                (new SelectListItem
                {
                    Text = "Active",
                    Value = "1"
                });
            Status.Add
                (new SelectListItem
                {
                    Text = "Inactive",
                    Value = "2"
                }
                );
            ViewData["Status"] = new SelectList(Status, "Value", "Text");
            List<SelectListItem> AirlineType = new List<SelectListItem>();
            AirlineType.Add(new SelectListItem {Text="Domestic",Value="1" });
            AirlineType.Add(new SelectListItem {Text = "International", Value = "2" });
            ViewData["AirlineType"] = new SelectList(AirlineType,"Value","Text");
            if (Request.IsAjaxRequest())
            {

                //if (IsActive == true)
                if(IsActive == 1)
                {
                    // var item = ser.GetAllInActiveAirlineByByPaging( pageNo.Value, out  currentPageNo, out numberOfPage, flag).ToList();
                    if (Type == 1)
                    {
                        var domestic = ser.GetAllActiveDomesticAirline();
                        return PartialView("AirlineSearchResult", domestic);
                    }
                    var item = ser.GetAllActiveInternationalAirlineList();

                    return PartialView("AirlineSearchResult", item);
                }
                else
                {
                    if (Type == 1)
                    {
                       // var domestic = ser.GetAllInActiveDomesticAirline();
                        var international = ser.GetAllInActiveInternationalAirlineList();
                        return PartialView("AirlineSearchResult", international);
                    }
                    //var result = ser.GetAllAirlineByByPaging(pageNo.Value, out  currentPageNo, out numberOfPage, flag).ToList();
                    var result = ser.GetAllInActiveInternationalAirlineList();

                    return PartialView("AirlineSearchResult", result);
                }
            }
            // var model = ser.GetAllAirlineByByPaging(pageNo.Value, out  currentPageNo, out numberOfPage, flag).ToList();

            //var model = ser.GetAllAirline();

           // var model = ser.GetAllActiveDomesticAirline();
            var model = ser.GetAllActiveInternationalAirlineList();

            //ViewData["TotalPages"] = numberOfPage;
            //ViewData["CurrentPage"] = currentPageNo;

            return View(model);
        }
        [HttpPost]
        public ActionResult Index(FormCollection fc,int ddlStatus,int AirlineType, int? IsActive, int? pageNo, int? flag)
        {
            if (Request.IsAjaxRequest())
            {
                int currentPageNo = 0; int numberOfPage = 0;
                if (pageNo == null)
                    pageNo = 1;
                TempData["Flag"] = false;
                string airlinename = fc["SearchAirline"];
                if (airlinename != null && airlinename!="")
                {
                    var result = ser.GetAllSearchAirlineNameList(airlinename);
                    return PartialView("AirlineSearchResult", result);
                }
                /*IsActive == true means user is searching for Airline whose status is InActive*/
               // if (IsActive == true)
                if (AirlineType == 1)
                {
                    if (ddlStatus == 1)
                    {
                        var domestic = ser.GetAllActiveDomesticAirline();
                        return PartialView("AirlineSearchResult", domestic);
                    }
                    else
                    {
                        // var result = ser.GetAllInActivehAirlineNameList(airlinename, pageNo.Value, out  currentPageNo, out numberOfPage, flag).ToList();
                       // var result = ser.GetAllInActivehAirlineNameList(airlinename);
                        var result = ser.GetAllInActiveDomesticAirline();
                        //ViewData["TotalPages"] = numberOfPage;
                        //ViewData["CurrentPage"] = currentPageNo;
                        return PartialView("AirlineSearchResult", result);
                    }
                }
                else
                {
                    if (ddlStatus == 1)
                    {
                        var international = ser.GetAllActiveInternationalAirlineList();
                        return PartialView("AirlineSearchResult", international);
                    }
                    else
                    {
                        //var item = ser.GetAllSearchAirlineNameList(airlinename,pageNo.Value, out  currentPageNo, out numberOfPage, flag).Where(aa => aa.AirlineName.Contains(airlinename)).ToList();
                       // var item = ser.GetAllSearchAirlineNameList(airlinename);
                        var item = ser.GetAllInActiveInternationalAirlineList();
                        //ViewData["TotalPages"] = numberOfPage;
                        //ViewData["CurrentPage"] = currentPageNo;
                        return PartialView("AirlineSearchResult", item);
                    }
                }
            }
            return View();
        }
        // Get : /Add Form: Airline Information/

        [HttpGet]
        public ActionResult Create()
        {
            var AirlinesModel = new AirLinesModel()
            {
                AirlineTypList = ser.GetAirlineTypeList (),
                AccTypesList = ser.GetAllAccTypesList(),
                BSPorConsolidatorList = ser.GetAllGetLedgername(),
                
            CountryList = ser.GetAllCountriesList(),
            };
            return View(AirlinesModel);
        }

        [HttpPost]
        public ActionResult Create(AirLinesModel model)
        {
            EntityModel ent = new EntityModel();
            bool check = ser.CheckAirlineName(model.AirlineName);
            if(check ==true)
            {
            //AirLinesServices.ServiceAirlineClient ser = new AirLinesServices.ServiceAirlineClient();
            try
            {
                            
                                    //new save with settlement Condition//
                                    Airlines datamodel = new Airlines();

                                   
                                    if (model.chkSettlement == false)
                                    {
                                       
                                        datamodel.AirlineCode = model.AirlineCode.TrimEnd();
                                        datamodel.AirlineName = model.AirlineName.TrimEnd();
                                       
                                        datamodel.AirlineTypeId = model.AirlineTypId;
                                       //datamodel.SettlmentLedgerId = model.LedgerId;
                                         datamodel.SettlmentLedgerId = model.LedgerId;
                                         datamodel.CountryId = Convert.ToInt32( model.CountryId);
                                        datamodel.isActive = true;

                                        ser.AddAirLine(datamodel);

                                    }

                                    if (model.chkSettlement == true)
                                    {
                                        ////////insertng into Airline Table////////////
                                        datamodel.AirlineCode = model.AirlineCode.TrimEnd();
                                        datamodel.AirlineName = model.AirlineName.TrimEnd();
                                        
                                        datamodel.AirlineTypeId = model.AirlineTypId;
                                        datamodel.SettlmentLedgerId = model.AirlineId;
                                        datamodel.CountryId = Convert.ToInt32( model.CountryId);
                                        datamodel.isActive = true;

                                       int airlineid = ser.AddAirLine(datamodel);

                                      // datamodel.SettlmentLedgerId = airlineid;
                                     // ser.AddAirLine(datamodel);

                                       datamodel.SettlmentLedgerId = airlineid;
                                       ser.EditAirLineInfo(datamodel);

                                        ///////////inserting into Legder Table////////
                                       GL_Ledgers datamodel1 = new GL_Ledgers();
                                      // datamodel1.LedgerId = airlineid;
                                       datamodel1.ProductId = 1;
                                       datamodel1.AccGroupId = 2;
                                       datamodel1.AccSubGroupId = 2;
                                       datamodel1.AccTypeId = 1;
                                       datamodel1.Id = airlineid;
                                       //datamodel1.LedgerName = "A/C" + " " + model.AirlineName.TrimEnd();
                                       datamodel1.LedgerName =  model.AirlineName.TrimEnd();
                                       datamodel1.CreatedDate = DateTime.Now;

                                       ser.AddLedger(datamodel1);
                                        //////////////////////////////////////////////////
                                 
                            }
                        }
                    
                
            
            catch
            {
            //    var AirlineModel = new AirLineModel()
            //    {
            //        AirlineTypList = ser.GetAirlineTypeList(),
            //        AccTypesList = ser.GetAllAccTypesList(),
            //        BSPorConsolidatorList = ser.GetAllGetLedgername()
            //    };
            //    return View(AirlineModel);
            }

            return RedirectToAction("Index");
        }
            var viewModel = new AirLinesModel()
            {
                AirlineTypList = ser.GetAirlineTypeList(),
                AccTypesList = ser.GetAllAccTypesList(),
                BSPorConsolidatorList = ser.GetAllGetLedgername()
            };
            TempData["Error"] = "Airline Name Already Exists";
            return View(viewModel);
        }

        /// <summary>
        /// To change the Status of an Airline to Active
        /// </summary>
        /// <param name="model"></param>
        /// <param name="chkAirLine"></param>
        /// <returns></returns>
        /// 
        [HttpPost]
        public ActionResult Active(Airlines model, string chkAirLine, string Mode,int Type, int? pageNo, int? flag)
        {


            TempData["Flag"] = true;
            //int currentPageNo = 0; int numberOfPage = 0;Type =1 means domestic is been selected and in db 1 means International so conversion is necessay
            if (pageNo == null)
                pageNo = 1;
            var result = ser.GetAllAirline();
            if (chkAirLine == "")
            {
                ModelState.AddModelError("AirlineId", "please select Airline");
                return RedirectToAction("Index");
            }
            if (Request.IsAjaxRequest())
            {
                if (chkAirLine != "" || chkAirLine != null)
                {
                    int[] prodIds = chkAirLine.Split(',').Select(s => int.Parse(s)).ToArray();
                    foreach (int AirlineId in prodIds)
                    {
                        if (Mode == "Activate")
                        {

                            ser.ChangeStatusToActive(AirlineId, model);
                            // result = ser.GetAllAirlineByByPaging(pageNo.Value, out  currentPageNo, out numberOfPage, flag).ToList();
                            if (Type == 1)
                            {
                                result = ser.GetAllActiveAirLinesList(2);

                            }
                            else
                            {
                                result = ser.GetAllActiveAirLinesList(1);
                            }
                        }
                        else
                        {
                            ser.ChangeStatusToInActive(AirlineId, model);
                            if (Type == 1)
                            {
                                result = ser.GetAllInActiveAirlineList(2);//Since 2 will bring all domestic and 1 will brin all international
                            }
                            else
                            {
                                result = ser.GetAllInActiveAirlineList(1);
                            }
                            //result = ser.GetAllInActiveAirlineByByPaging(pageNo.Value, out  currentPageNo, out numberOfPage, flag).ToList();

                        }
                    }
                    //ViewData["TotalPages"] = numberOfPage;
                    //ViewData["CurrentPage"] = currentPageNo;
                    return PartialView("AirlineSearchResult", result);

                }
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(Int32 id)
        {
            
            var LegderModel = ser.GetLedgerInfoById(id);

            // int LegerId = ser.GetLedgerInformationById(id);

            var model = ser.GetAirLineInfoById(id);

            if (LegderModel != null)
            {

                var AirlineModel = new AirLinesModel()
                {
                    AirlineCode = model.AirlineCode,
                    AirlineName = model.AirlineName,
                    AirlineId = model.AirlineId,
                    AirlineTypId = model.AirlineTypeId,
                    CountryId =  model.CountryId.ToString(),
                    AirlineTypList = ser.GetAirlineTypeList(),
                   
                    AccTypes = (LegderModel.AccTypeId == 0) ? 0 : LegderModel.AccTypeId,
                    AccTypesList = ser.GetAllAccTypesList(),
                    BSPorConsolidatorList = ser.GetAllGetLedgername(),
                    CountryList = ser.GetAllCountriesList(),
                    SettlmentLedgerId=model.SettlmentLedgerId
                };

                if (AirlineModel.AccTypes == 1 && AirlineModel.SettlmentLedgerId == LegderModel.LedgerId)
                {
                    AirlineModel.chkSettlement = true;
                    AirlineModel.AccTypes = 0;
                    AirlineModel.BSPorConsolidatorId = 0;
                }
                else if (AirlineModel.SettlmentLedgerId != null && AirlineModel.SettlmentLedgerId>0)
                {
                    var m = ser.GetLedgerInfoByLedgerId((int)AirlineModel.SettlmentLedgerId);
                    AirlineModel.AccTypes = m.AccTypeId;
                    AirlineModel.BSPorConsolidatorId = (int)m.LedgerId;
                }

               
                return View(AirlineModel);
            }
            else
            {
                var AirlineModel = new AirLinesModel()
                {
                    AirlineCode = model.AirlineCode,
                    AirlineName = model.AirlineName,
                    AirlineId = model.AirlineId,
                    AirlineTypId = model.AirlineTypeId,
                   // CountryId = (int)model.CountryId==0?0 : (int)model.CountryId,
                   CountryId = model.CountryId == null ? "" : model.CountryId.ToString(),
                    AirlineTypList = ser.GetAirlineTypeList(),
                    
                    AccTypesList = ser.GetAllAccTypesList(),
                    BSPorConsolidatorList = ser.GetAllGetLedgername(),
                    CountryList = ser.GetAllCountriesList(),
                    SettlmentLedgerId = model.SettlmentLedgerId
                };

                if (AirlineModel.SettlmentLedgerId != null && AirlineModel.SettlmentLedgerId > 0)
                {
                    var m = ser.GetLedgerInfoByLedgerId((int)AirlineModel.SettlmentLedgerId);
                    AirlineModel.AccTypes = m.AccTypeId;
                    AirlineModel.BSPorConsolidatorId = (int)m.LedgerId;
                }
                return View(AirlineModel);

               
            }
        }

        [HttpPost]
        public ActionResult Edit(AirLinesModel model, Int32 id,  FormCollection fs)
        {
         

             
                    
                   // ser.EditAirLineInfo(obj);

                    //new edit
                    Airlines obj = new Airlines();
                    if (model.chkSettlement == false)
                    {
                        obj.AirlineId = id;
                        obj.AirlineCode = model.AirlineCode.Trim();
                        obj.AirlineName = model.AirlineName.Trim();
                        
                        obj.AirlineTypeId = model.AirlineTypId;
                        obj.isActive = true;
                        obj.SettlmentLedgerId = model.LedgerId;
                        obj.CountryId = Convert.ToInt32( model.CountryId);
                        ser.EditAirLineInfo(obj);

                        ser.DeleteLedgerMaster(id);
                    }
                    if (model.chkSettlement == true)
                    {
                         obj.AirlineId = id;
                        obj.AirlineCode = model.AirlineCode.Trim();
                        obj.AirlineName = model.AirlineName.Trim();
                        
                        obj.AirlineTypeId = model.AirlineTypId;
                        obj.isActive = true;
                        obj.SettlmentLedgerId = obj.AirlineId;
                        obj.CountryId = obj.CountryId;
                        ser.EditAirLineInfo(obj);

                        

                        //to get the ID from GL_Ledger
                      int LedId =  ser.GetLedgerMasterDetail(id);


                        GL_Ledgers obj1 = new GL_Ledgers();

                        if (LedId == 0)
                        {
                            obj1.LedgerId = id;
                            obj1.ProductId = 1;
                            obj1.AccGroupId = 2;
                            obj1.AccSubGroupId = 2;
                            obj1.AccTypeId = 1;
                            obj1.Id = id;
                            obj1.LedgerName = model.AirlineName.Trim();
                            obj1.CreatedDate = DateTime.Now;
                            ser.AddLedger(obj1);
                        }
                        else
                        {

                            //obj1.LedgerId = id;
                            obj1.ProductId = 1;
                            obj1.AccGroupId = 2;
                            obj1.AccSubGroupId = 2;
                            obj1.AccTypeId = 1;
                            obj1.Id = id;
                            obj1.LedgerName = model.AirlineName.Trim();
                            obj1.CreatedDate = DateTime.Now;
                            ser.EditLedgerInfo(obj1);

                        }


                       
                    }
                    
                
                    

               

                   


                    //new edit
                    //new edit
                    Airlines obj2 = new Airlines();
                    if (model.chkSettlement == false)
                    {
                        obj2.AirlineId = id;
                        obj2.AirlineCode = model.AirlineCode.Trim();
                        obj2.AirlineName = model.AirlineName.Trim();
                      
                        obj2.AirlineTypeId = model.AirlineTypId;
                        obj2.isActive = true;
                        obj2.SettlmentLedgerId = model.BSPorConsolidatorId;
                        obj2.CountryId = Convert.ToInt32( model.CountryId);
                        ser.EditAirLineInfo(obj2);
                    }
                    if (model.chkSettlement == true)
                    {

                        GL_Ledgers obj1 = new GL_Ledgers();

                        //obj1.LedgerId = id;
                        obj1.ProductId = 1;
                        obj1.AccGroupId = 2;
                        obj1.AccSubGroupId = 2;
                        obj1.AccTypeId = 1;
                        obj1.Id = id;
                        obj1.LedgerName = model.AirlineName.Trim();
                        obj1.CreatedDate = DateTime.Now;

                        Int64 LedgerId = 0;



                        if (!ser.isLedgerExists(id))
                            LedgerId = ser.AddLedger(obj1);
                        else
                        {
                            ser.EditLedgerInfo(obj1);
                            LedgerId = ser.getLedgerId(id);
                        }

                        obj2.AirlineId = id;
                        obj2.AirlineCode = model.AirlineCode.Trim();
                        obj2.AirlineName = model.AirlineName.Trim();
                      
                        obj2.AirlineTypeId = model.AirlineTypId;
                        obj2.isActive = true;
                        obj2.SettlmentLedgerId = (int)LedgerId;
                        obj2.CountryId = Convert.ToInt32( model.CountryId);
                        ser.EditAirLineInfo(obj2);

                    


                }
                
            
            return RedirectToAction("Index");
        }

        public ActionResult Details(Int32 id)
        {
            var model = ser.GetAirLineInfoById(id);
            return View(model);
        }

        public ActionResult Delete(Int32 id)
        {
            ser.DeleteAirline(id);
            return RedirectToAction("Index");
        }
        ////////////////////find airline//////////////////
        //[HttpPost]
        //public JsonResult FindAirline(string searchText, int maxResult, int Type)
        //{

        //    var result = GetAirline(searchText, maxResult, Type);
        //    return Json(result);
        //}

        //public List<Airlines> GetAirline(string AirlineName, int maxResult, int Type)
        //{
        //    if (Type == 1)
        //    {
        //        return ser.GetAllAirlineNameList(AirlineName, maxResult).ToList();
        //    }
        //    return ser.GetAllDomesticAirlineNameList(AirlineName, maxResult).ToList();
        //}
    }
}