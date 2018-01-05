#region  © 2010 Arihant Technologies Ltd. All rights reserved
// All rights are reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical or otherwise, is prohibited
// without the prior written permission of the copyright owner.
// Filename: AgentManagementController.cs
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
using System.IO;
using System.Web.Security;
using System.Web.Mvc;
using System.Data.SqlClient;
using TravelPortalEntity;
using ATLTravelPortal.Areas.Administrator.Models;
using ATLTravelPortal.Helpers;
using ATLTravelPortal.SecurityAttributes;
using ATLTravelPortal.Areas.Administrator.Repository;
using ATLTravelPortal.CustomAttribute;
using ATLTravelPortal.Models;
using ATLTravelPortal.Helpers.Pagination;


namespace ATLTravelPortal.Areas.Administrator.Controllers
{
    [CheckSessionFilter(Order = 1)]
    [PermissionDetails(View = "Index", Edit = "Edit", Add = "Create", Details = "Details", Delete = "Delete", Custom1 = "AgentSearch", Order = 2)]
    public class AgentManagementController : Controller
    {
        //
        // GET: /agent/
        TravelPortalEntity.EntityModel ent = new TravelPortalEntity.EntityModel();
        DateTime CurrentDate = ATLTravelPortal.Repository.GeneralRepository.CurrentDate();
        int LogedUserId = ATLTravelPortal.Repository.GeneralRepository.LogedUserId();
        ActionResponse _res = new ATLTravelPortal.Models.ActionResponse();
        AgentModel _model = new AgentModel();
        AgentManagementRepository _rep = new AgentManagementRepository();
        //static bool scroll = false;
        //static int previousId = 0;
        UserManagementProvider _umprovider = new UserManagementProvider();

        CountryProvider _countryProvider = new CountryProvider();

        AgentdetailsProvider _agentdetailsprovider = new AgentdetailsProvider();
        // ***********************************************************************************
        //
        // GET: /agentlist/
        // ***********************************************************************************
        [Authorize]
        [HttpGet]
        public ActionResult Index(int? IsActive, string id)
        {

            TravelSession obj = (TravelSession)Session["TravelPortalSessionInfo"];
            string alphabet = string.IsNullOrEmpty(id) ? "A" : id;
            var model = _rep.GetAllAgentByPaging().Where(aa => aa.AgentName.StartsWith(alphabet)).ToList();
            bool status = IsActive == 1 ? true : false;
            if (Request.IsAjaxRequest())
            {
                if (IsActive != 0 && id == "")
                {
                    model = model.Where(aa => aa.AgentStatus == status).ToList();
                    return PartialView("AgentListPartial", model);
                }
                else if (IsActive == null && id != "")
                {
                    return PartialView("AgentListPartial", model);
                }
                else if (IsActive == 0 && id != "")
                {
                    return PartialView("AgentListPartial", model);
                }
                else
                {
                    //  return PartialView("AgentListPartial", model);
                    model = model.Where(aa => aa.AgentStatus == status).ToList();
                    return PartialView("AgentListPartial", model);
                }

            }

            return View(model);

        }
        // ***********************************************************************************
        //
        // GET: /UserManagement/Details/5
        // ***********************************************************************************
        public ActionResult Details(int? id)
        {
            _model = _rep.Detail(id, out _res);
            Session["ActionResponse"] = _res;
            if (_res.ErrNumber == 0)
                return View(_model);
            else
                return RedirectToAction("Index");
        }

        // ***********************************************************************************
        //
        // GET: /UserManagement/Create
        // ***********************************************************************************
        [Authorize]
        public ActionResult Create()
        {
            ViewData["Countrylist"] = new SelectList(_rep.GetCountry(), "CountryId", "CountryName", 0);
            ViewData["Status"] = new SelectList(_rep.GetStatus(), "id", "Name", 1);
            ViewData["AirlineGroup"] = new SelectList(_rep.GetAirlineGroup(), "AirlineGroupId", "AirlineGroupName");

            AgentModel viewmodel = new AgentModel
            {
                agentsettinglist = _rep.GetAllSettingList(),
                ProductBaseRoleList = _rep.GetProductList(),
                ReferredByList = _rep.GetAllGetSalesAgentList(),
                MEsNameList = _rep.GetAllGetSalesAgentList(),

                // MasterDealNameListOfAirlines = _rep.GetAllDealListOfAirlines(),
                // MasterDealNameListOfHotels=_rep.GetAllDealListOfHotel(),
            };
            /////// TODO : Repalce View data into Strongly Type Model ViewData /////////////
            ViewData["AirlineGroup"] = new SelectList(_rep.GetAirlineGroup(), "AirlineGroupId", "AirlineGroupName");
            ViewData["RoleAssign"] = new SelectList("", "RoleName", "RoleName", "");
            ViewData["AgentTypes"] = new SelectList(_rep.GetAgentType(), "AgentTypeId", "AgentTypeName");

            ViewData["AgentZone"] = new SelectList(_rep.GetZoneList(), "ZoneId", "ZoneName");
            ViewData["AgentDistrict"] = new SelectList(_rep.GetDistrictListbyZoneId(1), "DistrictId", "DistrictName");
            ViewData["BankAccountTypes"] = new SelectList(_rep.GetbankAccountType(), "BankAccountTypeId", "AccountTypeName");
            ViewData["TimeZones"] = new SelectList(_rep.GetTimeZoneList(), "RecordID", "StandardName", 66);
            return View(viewmodel);
        }

        // ***********************************************************************************
        //
        // POST: /UserManagement/Create
        // ***********************************************************************************
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create(AgentModel model, List<AgentBankModel> AgentBankModel, int[] ChkSettingId, int[] ChkProductId, FormCollection fc)
        {
            TravelSession obj = (TravelSession)Session["TravelPortalSessionInfo"];

            model.BranchOfficeId = 1;
            model.DistributorId = 1;

            model.CreatedbyUser = obj.AppUserId;
            model.CreatedBy = LogedUserId;
            model.CreatedDate = CurrentDate;
            model.AgentStatusid = 1;
            model.EmailId = model.EmailId.Trim(';');
            if (!_rep.CheckDuplicateEmail(model.Email))
            {
                TempData["ErrorMessage"] = "Registration failed! Email already exists, please re-enter and try again";
                AgentModel viewmodel = new AgentModel
                {
                    ProductBaseRoleList = _rep.GetProductList(),
                    ReferredByList = _rep.GetAllGetSalesAgentList(),
                    MEsNameList = _rep.GetAllGetSalesAgentList(),
                };
                ViewData["Countrylist"] = new SelectList(_rep.GetCountry(), "CountryId", "CountryName", 0);
                ViewData["Status"] = new SelectList(_rep.GetStatus(), "id", "Name", 1);
                ViewData["AirlineGroup"] = new SelectList(_rep.GetAirlineGroup(), "AirlineGroupId", "AirlineGroupName");
                ViewData["RoleAssign"] = new SelectList("", "RoleName", "RoleName", "");
                ViewData["AgentTypes"] = new SelectList(_rep.GetAgentType(), "AgentTypeId", "AgentTypeName");

                ViewData["AgentZone"] = new SelectList(_rep.GetZoneList(), "ZoneId", "ZoneName");
                ViewData["AgentDistrict"] = new SelectList(_rep.GetDistrictListbyZoneId(1), "DistrictId", "DistrictName");
                ViewData["Banks"] = new SelectList(_rep.GetbankInformation(), "BankId", "BankName");
                ViewData["BankBranches"] = new SelectList(_rep.GetbankBranchInformation(), "BankBranchId", "BranchName");
                ViewData["BankAccountTypes"] = new SelectList(_rep.GetbankAccountType(), "BankAccountTypeId", "AccountTypeName");
                ViewData["TimeZones"] = new SelectList(_rep.GetTimeZoneList(), "RecordID", "StandardName", 66);
                return View("Create", viewmodel);
            }
            else
            {
                if (!string.IsNullOrEmpty(model.MobileNo) && !_rep.CheckDuplicateMobileNumber(model.MobileNo))
                {
                    TempData["ErrorMessage"] = "Registration failed! Mobile Number already exists, please re-enter and try again";
                    AgentModel viewmodel = new AgentModel
                    {
                        ProductBaseRoleList = _rep.GetProductList(),
                        ReferredByList = _rep.GetAllGetSalesAgentList(),
                    };
                    ViewData["Countrylist"] = new SelectList(_rep.GetCountry(), "CountryId", "CountryName", 0);
                    ViewData["Status"] = new SelectList(_rep.GetStatus(), "id", "Name", 1);
                    ViewData["AirlineGroup"] = new SelectList(_rep.GetAirlineGroup(), "AirlineGroupId", "AirlineGroupName");
                    ViewData["RoleAssign"] = new SelectList("", "RoleName", "RoleName", "");
                    ViewData["AgentTypes"] = new SelectList(_rep.GetAgentType(), "AgentTypeId", "AgentTypeName");

                    ViewData["AgentZone"] = new SelectList(_rep.GetZoneList(), "ZoneId", "ZoneName");
                    ViewData["AgentDistrict"] = new SelectList(_rep.GetDistrictListbyZoneId(1), "DistrictId", "DistrictName");
                    ViewData["Banks"] = new SelectList(_rep.GetbankInformation(), "BankId", "BankName");
                    ViewData["BankBranches"] = new SelectList(_rep.GetbankBranchInformation(), "BankBranchId", "BranchName");
                    ViewData["BankAccountTypes"] = new SelectList(_rep.GetbankAccountType(), "BankAccountTypeId", "AccountTypeName");
                    ViewData["TimeZones"] = new SelectList(_rep.GetTimeZoneList(), "RecordID", "StandardName", 66);
                    return View("Create", viewmodel);

                }
                else
                {
                    _res = _rep.Create(model, AgentBankModel, ChkProductId, fc);

                    TempData["InfoMessage"] = _res.ActionMessage;
                    if (_res.ErrNumber == 0)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        AgentModel viewmodel = new AgentModel
                        {
                            ProductBaseRoleList = _rep.GetProductList(),
                            ReferredByList = _rep.GetAllGetSalesAgentList(),
                            MEsNameList = _rep.GetAllGetSalesAgentList(),
                        };
                        TempData["ErrorMessage"] = "Registration failed! Either Enter Username or Your passwords must match, please re-enter and try again";
                        ViewData["Countrylist"] = new SelectList(_rep.GetCountry(), "CountryId", "CountryName", 0);
                        ViewData["Status"] = new SelectList(_rep.GetStatus(), "id", "Name", 1);
                        ViewData["AirlineGroup"] = new SelectList(_rep.GetAirlineGroup(), "AirlineGroupId", "AirlineGroupName");
                        ViewData["RoleAssign"] = new SelectList("", "RoleName", "RoleName", "");
                        ViewData["AgentTypes"] = new SelectList(_rep.GetAgentType(), "AgentTypeId", "AgentTypeName");

                        ViewData["AgentZone"] = new SelectList(_rep.GetZoneList(), "ZoneId", "ZoneName");
                        ViewData["AgentDistrict"] = new SelectList(_rep.GetDistrictListbyZoneId(1), "DistrictId", "DistrictName");
                        ViewData["Banks"] = new SelectList(_rep.GetbankInformation(), "BankId", "BankName");
                        ViewData["BankBranches"] = new SelectList(_rep.GetbankBranchInformation(), "BankBranchId", "BranchName");
                        ViewData["BankAccountTypes"] = new SelectList(_rep.GetbankAccountType(), "BankAccountTypeId", "AccountTypeName");
                        ViewData["TimeZones"] = new SelectList(_rep.GetTimeZoneList(), "RecordID", "StandardName", 66);
                        return View("Create", viewmodel);
                    }
                }
            }
        }

        /*------------------------------------------------------------------------------------------------------/**/
        // GET: /UserManagement/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            _model = _rep.Detail(id, out _res);
            TempData["InfoMessage"] = _res.ActionMessage;
            if (_res.ErrNumber == 0)
            {
                ViewData["AgentBank"] = _agentdetailsprovider.GetAgentBankList(id.Value);

                foreach (var AsociatedProductOfAgent in _model.AgentProductList)
                {
                    ViewData[AsociatedProductOfAgent.ProductName] = new SelectList(_rep.GetAllRolesListonProductWise(AsociatedProductOfAgent.ProductId), "RoleName", "RoleName", "");
                }
                ViewData["Countrylist"] = new SelectList(_rep.GetCountry(), "CountryId", "CountryName", _rep.GetCountryInfo(_model.NativeCountryId));
                ViewData["AgentZone"] = new SelectList(_rep.GetZoneList(), "ZoneId", "ZoneName", _model.ZoneId);
                ViewData["AgentDistrict"] = new SelectList(_rep.GetDistrictListbyZoneId(_model.ZoneId), "DistrictId", "DistrictName", _model.DistrictId);
                ViewData["Status"] = new SelectList(_rep.GetStatus(), "id", "Name");
                ViewData["AgentTypes"] = new SelectList(_rep.GetAgentType(), "AgentTypeId", "AgentTypeName", _model.AgentTypeId);
                //ViewData["agentClass"] = new SelectList(_rep.GetAgentClass(), "AgentClassId", "AgentClassName", _model.AgentClassId);
                ViewData["Banks"] = new SelectList(_rep.GetbankInformation(), "BankId", "BankName");
                ViewData["BankBranches"] = new SelectList(_rep.GetbankBranchInformation(), "BankBranchId", "BranchName");
                ViewData["BankAccountTypes"] = new SelectList(_rep.GetbankAccountType(), "BankAccountTypeId", "AccountTypeName");
                ViewData["TimeZones"] = new SelectList(_rep.GetTimeZoneList(), "RecordID", "StandardName");
                _model.ReferredByList = _rep.GetAllGetSalesAgentList();
                _model.MEsNameList = _rep.GetAllGetSalesAgentList();
                return View(_model);
            }
            else
                return RedirectToAction("Index");
        }
        /*------------------------------------------------------------------------------------------------------/**/
        //
        // POST: /UserManagement/Edit/5

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Edit(int? id, AgentModel model, int[] ChkProductId, FormCollection fc)
        {
            model.AgentId = id == null ? 0 : id.Value;
            model.UpdatedBy = LogedUserId;
            model.UpdatedDate = CurrentDate;
            model.EmailId = model.EmailId.Trim(';');
            if (_rep.CheckEditDuplicateEmail(model.Email, id.Value))
            {
                TempData["ActionResponse"] = "Registration failed! Email already exists, please re-enter and try again";
                _model = _rep.Detail(id, out _res);

                foreach (var AsociatedProductOfAgent in _model.AgentProductList)
                {
                    ViewData[AsociatedProductOfAgent.ProductName] = new SelectList(_rep.GetAllRolesListonProductWise(AsociatedProductOfAgent.ProductId), "RoleName", "RoleName", "");
                }
                ViewData["AgentBank"] = _agentdetailsprovider.GetAgentBankList(id.Value);
                ViewData["Countrylist"] = new SelectList(_rep.GetCountry(), "CountryId", "CountryName", _rep.GetCountryInfo(_model.NativeCountryId));
                ViewData["AgentZone"] = new SelectList(_rep.GetZoneList(), "ZoneId", "ZoneName", _model.ZoneId);
                ViewData["AgentDistrict"] = new SelectList(_rep.GetDistrictListbyZoneId(Convert.ToInt32(_model.ZoneId)), "DistrictId", "DistrictName", Convert.ToInt32(_model.DistrictId));
                ViewData["Status"] = new SelectList(_rep.GetStatus(), "id", "Name", 1);
                ViewData["AgentTypes"] = new SelectList(_rep.GetAgentType(), "AgentTypeId", "AgentTypeName");
                ViewData["agentClass"] = new SelectList(_rep.GetAgentClass(), "AgentClassId", "AgentClassName");
                ViewData["Banks"] = new SelectList(_rep.GetbankInformation(), "BankId", "BankName");
                ViewData["BankBranches"] = new SelectList(_rep.GetbankBranchInformation(), "BankBranchId", "BranchName");
                ViewData["BankAccountTypes"] = new SelectList(_rep.GetbankAccountType(), "BankAccountTypeId", "AccountTypeName");
                ViewData["TimeZones"] = new SelectList(_rep.GetTimeZoneList(), "RecordID", "DisplayName");
                _model.ReferredByList = _rep.GetAllGetSalesAgentList();
                _model.MEsNameList = _rep.GetAllGetSalesAgentList();
                return View(_model);
            }
            else
            {
                if (!string.IsNullOrEmpty(model.MobileNo) && !_rep.CheckEditDuplicateMobileNumber(model.MobileNo, id.Value))
                {
                    TempData["ActionResponse"] = "Registration failed! Mobile Number already exists, please re-enter and try again";
                    _model = _rep.Detail(id, out _res);

                    foreach (var AsociatedProductOfAgent in _model.AgentProductList)
                    {
                        ViewData[AsociatedProductOfAgent.ProductName] = new SelectList(_rep.GetAllRolesListonProductWise(AsociatedProductOfAgent.ProductId), "RoleName", "RoleName", "");
                    }
                    ViewData["AgentBank"] = _agentdetailsprovider.GetAgentBankList(id.Value);
                    ViewData["Countrylist"] = new SelectList(_rep.GetCountry(), "CountryId", "CountryName", _rep.GetCountryInfo(_model.NativeCountryId));
                    ViewData["AgentZone"] = new SelectList(_rep.GetZoneList(), "ZoneId", "ZoneName", _model.ZoneId);
                    ViewData["AgentDistrict"] = new SelectList(_rep.GetDistrictListbyZoneId(Convert.ToInt32(_model.ZoneId)), "DistrictId", "DistrictName", Convert.ToInt32(_model.DistrictId));
                    ViewData["Status"] = new SelectList(_rep.GetStatus(), "id", "Name", 1);
                    ViewData["AgentTypes"] = new SelectList(_rep.GetAgentType(), "AgentTypeId", "AgentTypeName");
                    ViewData["agentClass"] = new SelectList(_rep.GetAgentClass(), "AgentClassId", "AgentClassName");
                    ViewData["Banks"] = new SelectList(_rep.GetbankInformation(), "BankId", "BankName");
                    ViewData["BankBranches"] = new SelectList(_rep.GetbankBranchInformation(), "BankBranchId", "BranchName");
                    ViewData["BankAccountTypes"] = new SelectList(_rep.GetbankAccountType(), "BankAccountTypeId", "AccountTypeName");
                    ViewData["TimeZones"] = new SelectList(_rep.GetTimeZoneList(), "RecordID", "DisplayName");
                    _model.ReferredByList = _rep.GetAllGetSalesAgentList();
                    _model.MEsNameList = _rep.GetAllGetSalesAgentList();
                    return View(_model);
                }
               
                else
                {

                    _res = _rep.Edit(id, model, ChkProductId, fc);
                    TempData["InfoMessage"] = _res.ActionMessage;
                    if (_res.ErrNumber == 0)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        _model = _rep.Detail(id, out _res);
                        _model.ReferredByList = _rep.GetAllGetSalesAgentList();
                        TempData["InfoMessage"] = _res.ActionMessage;
                        if (_res.ErrNumber == 0)
                        {
                            foreach (var AsociatedProductOfAgent in _model.AgentProductList)
                            {
                                ViewData[AsociatedProductOfAgent.ProductName] = new SelectList(_rep.GetAllRolesListonProductWise(AsociatedProductOfAgent.ProductId), "RoleName", "RoleName", "");
                            }
                            ViewData["AgentBank"] = _agentdetailsprovider.GetAgentBankList(id.Value);
                            ViewData["Countrylist"] = new SelectList(_rep.GetCountry(), "CountryId", "CountryName", _rep.GetCountryInfo(_model.NativeCountryId));
                            ViewData["AgentZone"] = new SelectList(_rep.GetZoneList(), "ZoneId", "ZoneName", _model.ZoneId);
                            ViewData["AgentDistrict"] = new SelectList(_rep.GetDistrictListbyZoneId(Convert.ToInt32(_model.ZoneId)), "DistrictId", "DistrictName", Convert.ToInt32(_model.DistrictId));
                            ViewData["Status"] = new SelectList(_rep.GetStatus(), "id", "Name", 1);
                            ViewData["AgentTypes"] = new SelectList(_rep.GetAgentType(), "AgentTypeId", "AgentTypeName");
                            ViewData["agentClass"] = new SelectList(_rep.GetAgentClass(), "AgentClassId", "AgentClassName");
                            ViewData["Banks"] = new SelectList(_rep.GetbankInformation(), "BankId", "BankName");
                            ViewData["BankBranches"] = new SelectList(_rep.GetbankBranchInformation(), "BankBranchId", "BranchName");
                            ViewData["BankAccountTypes"] = new SelectList(_rep.GetbankAccountType(), "BankAccountTypeId", "AccountTypeName");
                            ViewData["TimeZones"] = new SelectList(_rep.GetTimeZoneList(), "RecordID", "DisplayName");
                            return View(_model);
                        }
                        else
                        {
                            return RedirectToAction("Index");
                        }
                    }
                }
            }
        }
        // Post: /UserManagement/Delete/5
        public ActionResult Delete(int? id)
        {
            try
            {
                _res = _rep.Delete(id);

            }
            catch (SqlException ex)
            {
                _res.ActionMessage = ATLTravelPortal.Repository.SqlErrorHandle.Message(ex);
                _res.ErrNumber = ex.Number;
                _res.ResponseStatus = true;
            }
            catch (Exception)
            {
                _res.ActionMessage = Resources.SQLErrorMessage.Error;
                _res.ErrNumber = 2000;
                _res.ResponseStatus = true;
            }

            Session["ActionResponse"] = _res;
            return RedirectToAction("Index");
        }

        /////////// Add Associated Agent Product /////////////////////////////////////////////////////////

        ///////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// /////////////////////////////////////////////////////////////////////////////////////////////
        /// </summary>
        /// <param name="uInfo"></param>
        /// <param name="AgentId"></param>

        #region


        public JsonResult CheckDuplicateAirline(int AirlineId, int agentid)
        {
            bool flag;
            flag = _rep.CheckDuplicateAirline(AirlineId, agentid);

            JsonResult res = new JsonResult
            {
                Data = flag
            };
            return res;
        }
        public void filleddata(int id)
        {
            Agents tn = _rep.GetAgentInfo(id);

        }


        #endregion



        [HttpPost]
        public ActionResult AgentSearch(AgentModel model)
        {
            if (model.AgentSearch != null)
            {
                var agentsearchlist = _rep.GetAgentSearchResult(model.AgentSearch.TrimStart(' ').TrimEnd(' ')).ToList();

                return View("AgentSearch", agentsearchlist);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        public ActionResult AgentSearch()
        {

            return View();

        }



    }
}
