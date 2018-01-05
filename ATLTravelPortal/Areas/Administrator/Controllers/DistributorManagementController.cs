using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ATLTravelPortal.SecurityAttributes;
using ATLTravelPortal.CustomAttribute;
using ATLTravelPortal.Areas.Administrator.Repository;
using ATLTravelPortal.Areas.Administrator.Models;
using ATLTravelPortal.Helpers;
using ATLTravelPortal.Helpers.Pagination;
using ATLTravelPortal.Models;

namespace ATLTravelPortal.Areas.Administrator.Controllers
{
    [CheckSessionFilter(Order = 1)]
    [PermissionDetails(View = "Index", Add = "Create", Edit = "Edit", Details = "Details", Delete = "Delete", Order = 2)]
    public class DistributorManagementController : Controller
    {
        private DistributorManagementProvider distributorManagementProvider = new DistributorManagementProvider();
        private AgentManagementRepository agentManagementProvider = new AgentManagementRepository();

        DateTime CurrentDate = ATLTravelPortal.Repository.GeneralRepository.CurrentDate();
        int LogedUserId = ATLTravelPortal.Repository.GeneralRepository.LogedUserId();
        ActionResponse _res = new ATLTravelPortal.Models.ActionResponse();
        AgentModel _model = new AgentModel();
        AgentManagementRepository _rep = new AgentManagementRepository();
        UserManagementProvider _umprovider = new UserManagementProvider();
        CountryProvider _countryProvider = new CountryProvider();
        AgentdetailsProvider _agentdetailsprovider = new AgentdetailsProvider();
       


        AgentSettingProvider provider = new AgentSettingProvider();

        public ActionResult Index(int? IsActive, string id)
        {
            DistributorManagementModel model = new DistributorManagementModel();
            try
            {
                //string alphabet = string.IsNullOrEmpty(id) ? "A" : id;
                string alphabet = string.IsNullOrEmpty(id) ? "" : id;
                model.Distributors = distributorManagementProvider.GetDistributorsList().Distributors.Where(aa => aa.DistributorName.StartsWith(alphabet)).ToList();

                bool status = IsActive == 1 ? true : false;

                if (Request.IsAjaxRequest())
                {
                    if (IsActive != 0 && id == "")
                    {
                        model.Distributors = model.Distributors.Where(aa => aa.Status ==Convert.ToInt32( status)).ToList();
                        return PartialView("VUC_DistributorList", model.Distributors);
                    }
                    else if (IsActive == null && id != "")
                    {
                        return PartialView("VUC_DistributorList", model.Distributors);
                    }
                    else if (IsActive == 0 && id != "")
                    {
                        return PartialView("VUC_DistributorList", model.Distributors);
                    }
                    else
                    {
                        model.Distributors = model.Distributors.Where(aa => aa.Status == Convert.ToInt32( status)).ToList();
                        return PartialView("VUC_DistributorList", model.Distributors);
                    }
                }
              
                return View(model);
            }
            catch (Exception ex)
            {
                TempData["ActionResponse"] = ex.Message;
                return View(model);
            }
        }

        [HttpGet]
        public ActionResult Create()
        {
            DistributorManagementModel model = new DistributorManagementModel();
            try
            {
                model.Countries = new SelectList(agentManagementProvider.GetCountry(), "CountryId", "CountryName", 0);
                model.StatusOption = new SelectList(agentManagementProvider.GetStatus(), "id", "Name", 1);
                model.Zones = new SelectList(agentManagementProvider.GetZoneList(), "ZoneId", "ZoneName");
                model.Districts = new SelectList(agentManagementProvider.GetDistrictListbyZoneId(1), "DistrictId", "DistrictName");
                model.TimeZones = new SelectList(agentManagementProvider.GetTimeZoneList(), "RecordID", "StandardName", 66);
                model.BranchOffices = new SelectList(distributorManagementProvider.GetBranchOffices(), "BranchOfficeId", "BranchOfficeName");
                return View(model);
            }
            catch (Exception ex)
            {
                model.Countries = new SelectList(agentManagementProvider.GetCountry(), "CountryId", "CountryName", 0);
                model.StatusOption = new SelectList(agentManagementProvider.GetStatus(), "id", "Name", 1);
                model.Zones = new SelectList(agentManagementProvider.GetZoneList(), "ZoneId", "ZoneName");
                model.Districts = new SelectList(agentManagementProvider.GetDistrictListbyZoneId(1), "DistrictId", "DistrictName");
                model.TimeZones = new SelectList(agentManagementProvider.GetTimeZoneList(), "RecordID", "StandardName", 66);
                model.BranchOffices = new SelectList(distributorManagementProvider.GetBranchOffices(), "BranchOfficeId", "BranchOfficeName");
                TempData["ActionResponse"] = ex.Message;
                return View(model);
            }
        }

        [HttpPost]
        public ActionResult Create(DistributorManagementModel model)
        {
            try
            {
                TravelSession sessionObj = AdminSessionStore.GetTravelSession();
                model.CreatedBy = sessionObj.AppUserId;

                distributorManagementProvider.SaveDistributorManagementModel(model);

                TempData["InfoMessage"] = "Distributor Created Successfully.";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                model.Countries = new SelectList(agentManagementProvider.GetCountry(), "CountryId", "CountryName", model.NativeCountryId);
                model.StatusOption = new SelectList(agentManagementProvider.GetStatus(), "id", "Name", model.Status);
                model.Zones = new SelectList(agentManagementProvider.GetZoneList(), "ZoneId", "ZoneName", model.ZoneId);
                model.Districts = new SelectList(agentManagementProvider.GetDistrictListbyZoneId(1), "DistrictId", "DistrictName", model.DistrictId);
                model.TimeZones = new SelectList(agentManagementProvider.GetTimeZoneList(), "RecordID", "StandardName", model.TimeZoneId);
                model.BranchOffices = new SelectList(distributorManagementProvider.GetBranchOffices(), "BranchOfficeId", "BranchOfficeName", model.BranchOfficeId);
                TempData["ActionResponse"] = ex.Message;
                return View(model);
            }
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            DistributorManagementModel model = new DistributorManagementModel();
            try
            {
                model = distributorManagementProvider.GetDistributorsDetailsModel(id);
                return View(model);
            }
            catch (Exception ex)
            {
                TempData["ActionResponse"] = ex.Message;
                return View(model);
            }
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            DistributorManagementModel model = new DistributorManagementModel();
            try
            {
                model = distributorManagementProvider.GetDistributorsModel(id);
                return View(model);
            }
            catch (Exception ex)
            {
                model.Countries = new SelectList(agentManagementProvider.GetCountry(), "CountryId", "CountryName", model.NativeCountryId);
                model.StatusOption = new SelectList(agentManagementProvider.GetStatus(), "id", "Name", model.Status);
                model.Zones = new SelectList(agentManagementProvider.GetZoneList(), "ZoneId", "ZoneName", model.ZoneId);
                model.Districts = new SelectList(agentManagementProvider.GetDistrictListbyZoneId(1), "DistrictId", "DistrictName", model.DistrictId);
                model.TimeZones = new SelectList(agentManagementProvider.GetTimeZoneList(), "RecordID", "StandardName", model.TimeZoneId);
                model.BranchOffices = new SelectList(distributorManagementProvider.GetBranchOffices(), "BranchOfficeId", "BranchOfficeName", model.BranchOfficeId);
                TempData["ActionResponse"] = ex.Message;
                return View(model);
            }
        }

        [HttpPost]
        public ActionResult Edit(DistributorManagementModel model, int id)
        {
            try
            {
                TravelSession sessionObj = AdminSessionStore.GetTravelSession();
                model.UpdatedBy = sessionObj.AppUserId;

                model.DistributorId = id;
                distributorManagementProvider.EditDistributedManagement(model);
                model = distributorManagementProvider.GetDistributorsModel(id);
                TempData["InfoMessage"] = "Distributor Updated Successfully.";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                model.Countries = new SelectList(agentManagementProvider.GetCountry(), "CountryId", "CountryName", model.NativeCountryId);
                model.StatusOption = new SelectList(agentManagementProvider.GetStatus(), "id", "Name", model.Status);
                model.Zones = new SelectList(agentManagementProvider.GetZoneList(), "ZoneId", "ZoneName", model.ZoneId);
                model.Districts = new SelectList(agentManagementProvider.GetDistrictListbyZoneId(1), "DistrictId", "DistrictName", model.DistrictId);
                model.TimeZones = new SelectList(agentManagementProvider.GetTimeZoneList(), "RecordID", "StandardName", model.TimeZoneId);
                model.BranchOffices = new SelectList(distributorManagementProvider.GetBranchOffices(), "BranchOfficeId", "BranchOfficeName", model.BranchOfficeId);
                TempData["ActionResponse"] = ex.Message;

                return View(model);
            }
        }

      

        public ActionResult Delete(int? id)
        {
            AgentManagementRepository _rep = new AgentManagementRepository();
            ATLTravelPortal.Models.ActionResponse _res = new ATLTravelPortal.Models.ActionResponse();
            try
            {
                _res = distributorManagementProvider.Delete(id);
                TempData["InfoMessage"] = "Distributor Deleted Successfully.";

            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                _res.ActionMessage = ATLTravelPortal.Repository.SqlErrorHandle.Message(ex);
                _res.ErrNumber = ex.Number;
                _res.ResponseStatus = true;
                TempData["InfoMessage"] = "You can't delete this distributor." ;
            }
            catch (Exception)
            {
                _res.ActionMessage = Resources.SQLErrorMessage.Error;
                _res.ErrNumber = 2000;
                _res.ResponseStatus = true;
                TempData["InfoMessage"] = "You can't delete this distributor.";
            }

            
            return RedirectToAction("Index");
        }

        #region Search Action
        [HttpPost]        
        public ActionResult DistributorSearch(DistributorManagementModel model)
        {
            if (model.DistributorName != null)
            {
                //model.Distributors = distributorManagementProvider.GetDistributorsList().Distributors.
                //    Where(aa => (aa.DistributorName.ToUpper().StartsWith(model.DistributorName.ToUpper()))
                //    || (aa.DistributorCode.ToUpper().StartsWith(model.DistributorName.ToUpper()))).ToList();

               // var distributors = distributorManagementProvider.GetDistributorsList().Distributors;
                string searchText = string.Empty;
                if (model.DistributorName.Contains('('))
                {
                   // searchText = model.DistributorName;

                    model.Distributors = distributorManagementProvider.GetDistributorsList().Distributors.
                        Where(aa => ((aa.DistributorName.ToUpper()+"("+aa.DistributorCode+")").StartsWith(model.DistributorName.Trim().ToUpper()))).ToList();

                }
                else
                {
                    string[] arrayDistibutor = model.DistributorName.Split('(');
                    if (arrayDistibutor.Length > 0)
                        searchText = arrayDistibutor[0];

                    model.Distributors = distributorManagementProvider.GetDistributorsList().Distributors.
                       Where(aa => ((aa.DistributorName.ToUpper().StartsWith(searchText.Trim().ToUpper())))).ToList();
                }
                
                return View("Index", model);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
        #endregion

        public ActionResult AgentList(int id, int? page)
        {
           
            int currentPageIndex = page.HasValue ? page.Value : 1;
            int defaultPageSize = 50;

            DistributorManagementProvider distributorManagementProvider = new DistributorManagementProvider();
            DistributorAgentManagementModel model = new DistributorAgentManagementModel();
            model.AgentsList = distributorManagementProvider.AgentsListByBranchOfficeId().Where(x => x.DistributorId == id).ToPagedList(currentPageIndex, defaultPageSize);
            if (model.AgentsList.Count > 0)
            {
                model.AgentStatus = true;
            }
            model.DistributorId = id;
            return View(model);
        }

        public ActionResult DistributorAgentEdit(int? id)
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

                ViewData["Banks"] = new SelectList(_rep.GetbankInformation(), "BankId", "BankName");
                ViewData["BankBranches"] = new SelectList(_rep.GetbankBranchInformation(), "BankBranchId", "BranchName");
                ViewData["BankAccountTypes"] = new SelectList(_rep.GetbankAccountType(), "BankAccountTypeId", "AccountTypeName");
                ViewData["TimeZones"] = new SelectList(_rep.GetTimeZoneList(), "RecordID", "StandardName");
                _model.AgentId = (int) id;
                

                return View(_model);
            }
            else
                return RedirectToAction("Index");
        }


        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult DistributorAgentEdit(int? id, AgentModel model, FormCollection fc)
        {
            model.AgentId = id == null ? 0 : id.Value;
            model.UpdatedBy = LogedUserId;
            model.UpdatedDate = CurrentDate;
            model.EmailId = model.EmailId.Trim(';');
            _model = _rep.Detail(id, out _res);
            if (_rep.CheckEditDuplicateEmail(model.Email, id.Value))
            {
                TempData["ActionResponse"] = "Registration failed! Email already exists, please re-enter and try again";


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
                if (!string.IsNullOrEmpty(model.MobileNo) && !_rep.CheckEditDuplicateMobileNumber(model.MobileNo, id.Value))
                {
                    TempData["ActionResponse"] = "Registration failed! Mobile Number already exists, please re-enter and try again";


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
                    int[] ChkProductId = new int[1] { 1 };
                    _res = _rep.Edit(id, model, ChkProductId, fc);
                    TempData["InfoMessage"] = _res.ActionMessage;
                    if (_res.ErrNumber == 0)
                    {

                        return RedirectToAction("AgentList", "DistributorManagement", new { id = model.DistributorId});


                    }
                    else
                    {
                        _model = _rep.Detail(id, out _res);
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
                            return RedirectToAction("DistributorAgentList");
                        }
                    }
                }
            }
        }



        public ActionResult DistributorAgentSetting(int id, int? DISId)
        {
            AgentSettingModel model = new AgentSettingModel();

            model.MasterDealIdOfAirlines = provider.GetMasterDeal(id, 1) != null ? provider.GetMasterDeal(id, 1).MasterDealId : 0;
            model.MasterDealIdOfHotel = provider.GetMasterDeal(id, 2) != null ? provider.GetMasterDeal(id, 2).MasterDealId : 0;
            model.MasterDealNameListOfAirlines = provider.GetDistrubutorDealListOfAirlines();
            model.MasterDealNameListOfHotels = provider.GetAllDealListOfHotel();
            model.agentsettinglist = provider.GetAllSettingList();
            model.ServiceProviders = provider.GetAllActiveServiceProviders(id).ToList();
            model.Activeagentsettinglist = provider.GetAllActiveSettingForAgent(id);
            ViewData["agentClass"] = new SelectList(provider.GetAgentClass(), "AgentClassId", "AgentClassName");
            model.AgentClassId = provider.GetAgentClass(id);
            model.AgentName = provider.GetAgentName(id);
            model.DistributorId = DISId;
            return View(model);
        }
        [HttpPost]
        public ActionResult DistributorAgentSetting(int id, AgentSettingModel settingmodel)
        {
            try
            {
                TravelSession obj = (TravelSession)Session["TravelPortalSessionInfo"];
                UpdataAgentSetting(id, settingmodel, settingmodel.ServiceProviders, obj);
                TempData["InfoMessage"] = "Agent Setting Updated Successfully ";
            }
            catch (Exception ex)
            {
                TempData["InfoMessage"] = ex.Message;
            }
            // return RedirectToAction("Index");
            return RedirectToAction("AgentList", new { id = settingmodel.DistributorId});
        }

        [NonAction]
        public void UpdataAgentSetting(int id, AgentSettingModel settingmodel, List<AgentServiceProviderNames> model, TravelSession obj)
        {
            provider.UpdateAgentwithAgentClass(settingmodel.AgentClassId, obj.AppUserId, id);
            if (settingmodel.MasterDealIdOfAirlines != 0)
            {
                bool result = provider.CheckIFDealExistForAgent(id, 1);
                if (result == true)
                {
                    provider.UpdateDeal(settingmodel, 1, id);
                }
                else
                {
                    provider.SaveAgentDeal(settingmodel, id, 1, obj.AppUserId);
                }
            }
            else
            {
                provider.DeleteAgentDeal(id, 1);
            }

            if (settingmodel.MasterDealIdOfHotel != 0)
            {
                bool result = provider.CheckIFDealExistForAgent(id, 2);
                if (result == true)
                {
                    provider.UpdateDeal(settingmodel, 2, id);
                }
                else
                {

                    provider.SaveAgentDeal(settingmodel, id, 2, obj.AppUserId);
                }
            }
            else
            {
                provider.DeleteAgentDeal(id, 2);
            }

            /////////////////Begin Updating Agent Setting Lists /////////////////////////////////////////////
            provider.DeleteAgentSetting(id); //// First delete all agent setting///
            if (settingmodel.ChkSettingId != null)    //////////  Checking if product is other than Ticketing
            {
                List<int> AgentSettingIds = new List<int>();
                foreach (int sid in settingmodel.ChkSettingId)
                {
                    AgentSettingIds.Add(sid);
                }

                provider.SaveAgentSetting(AgentSettingIds, id);
            }
            //// Get Selected Account Setting Of Agent
            if (model.Count != 0)
            {
                model = model.Where(xx => xx.ServiceProviderId != 0).ToList();
                provider.DeleteServiceProviderAccountSetting(id);
                provider.SaveServiceProviderAccountSetting(model, obj.AppUserId, id);
            }
        }










    }
}
