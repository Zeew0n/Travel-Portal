using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ATLTravelPortal.Helpers;
using ATLTravelPortal.Areas.Administrator.Models;
using ATLTravelPortal.Areas.Administrator.Repository;
using ATLTravelPortal.Helpers.Pagination;
using ATLTravelPortal.Models;

namespace ATLTravelPortal.Areas.Administrator.Controllers
{
    public class BranchOfficeManagementController : Controller
    {
        //
        // GET: /Administrator/BranchOfficeManagement/

        BranchOfficeManagementProvider ser = new BranchOfficeManagementProvider();
        AgentManagementRepository _repAgManagement = new AgentManagementRepository();


        DateTime CurrentDate = ATLTravelPortal.Repository.GeneralRepository.CurrentDate();
        int LogedUserId = ATLTravelPortal.Repository.GeneralRepository.LogedUserId();
        ActionResponse _res = new ATLTravelPortal.Models.ActionResponse();
        AgentModel _model = new AgentModel();
        AgentManagementRepository _rep = new AgentManagementRepository();
        UserManagementProvider _umprovider = new UserManagementProvider();
        CountryProvider _countryProvider = new CountryProvider();
        AgentdetailsProvider _agentdetailsprovider = new AgentdetailsProvider();
        DistributorManagementProvider distributorManagementProvider = new DistributorManagementProvider();


        AgentSettingProvider provider = new AgentSettingProvider();




        [HttpGet]
        public ActionResult Index(int? IsActive, string id)
        {
            BranchOfficeManagementModel model = new BranchOfficeManagementModel();
            //  model.StatusList = new SelectList(_repAgManagement.GetStatus(), "id", "Name", 1);
            try
            {
                string alphabet = string.IsNullOrEmpty(id) ? "" : id;
                model.ListBranchOffice = ser.ListBranchOfficeManagement().Where(aa => aa.BranchOffice.StartsWith(alphabet)).ToList();

                bool status = IsActive == 1 ? true : false;

                if (Request.IsAjaxRequest())
                {
                    if (IsActive != 0 && id == "")
                    {
                        model.ListBranchOffice = model.ListBranchOffice.Where(aa => aa.status == Convert.ToInt32(status)).ToList();
                        return PartialView("VUC_BranchOfficeList", model);
                    }
                    else if (IsActive == null && id != "")
                    {
                        return PartialView("VUC_BranchOfficeList", model);
                    }
                    else if (IsActive == 0 && id != "")
                    {
                        return PartialView("VUC_BranchOfficeList", model);
                    }
                    else
                    {
                        model.ListBranchOffice = model.ListBranchOffice.Where(aa => aa.status == Convert.ToInt32(status)).ToList();
                        return PartialView("VUC_BranchOfficeList", model);
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



        [HttpPost]
        public ActionResult Index(BranchOfficeManagementModel model)
        {
            try
            {

                if (model.BranchOffice != null)
                {
                    model.ListBranchOffice = ser.ListBranchOfficeManagement().Where(aa => (aa.BranchOffice.ToUpper().StartsWith(model.BranchOffice.ToUpper())) || (aa.BranchOfficeCode.ToUpper().StartsWith(model.BranchOffice.ToUpper()))).ToList();

                    return View("Index", model);
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                return RedirectToAction("Index");
            }




        }





        [HttpGet]
        public ActionResult Create()
        {
            BranchOfficeManagementModel model = new BranchOfficeManagementModel();
            TravelSession obj = (TravelSession)Session["TravelPortalSessionInfo"];
            try
            {
                model.NativeCountryList = new SelectList(_repAgManagement.GetCountry(), "CountryId", "CountryName", 0);
                model.StatusList = new SelectList(_repAgManagement.GetStatus(), "id", "Name", 1);
                model.ZoneList = new SelectList(_repAgManagement.GetZoneList(), "ZoneId", "ZoneName");
                model.DistrictList = new SelectList(_repAgManagement.GetDistrictListbyZoneId(1), "DistrictId", "DistrictName");
                model.TimeZoneList = new SelectList(_repAgManagement.GetTimeZoneList(), "RecordID", "StandardName", 66);

               
                model.MasterDealNameListOfAirlines = provider.GetBranchAllDealListOfAirlines();
                model.MasterDealNameListOfHotels = provider.GetAllDealListOfHotel();
                model.MasterDealNameListOfBus = provider.GetAllDealListOfBus();
                model.MasterDealNameListOfMobile = provider.GetAllDealListOfMobile();

                ViewData["branchClass"] = new SelectList(provider.GetBranchClass(), "BranchClassId", "BranchClassName");
                model.BranchClassId = provider.GeBranchClass(obj.LoginTypeId);
            }
            catch (Exception ex)
            {
                TempData["ActionResponse"] = ex.Message;
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult Create(BranchOfficeManagementModel model, FormCollection fc)
        {
            TravelSession obj = (TravelSession)Session["TravelPortalSessionInfo"];
            model.CreatedBy = obj.AppUserId;

            model.Email = model.Email.Trim(';');

            model.NativeCountryList = new SelectList(_repAgManagement.GetCountry(), "CountryId", "CountryName", 0);
            model.StatusList = new SelectList(_repAgManagement.GetStatus(), "id", "Name", 1);
            model.ZoneList = new SelectList(_repAgManagement.GetZoneList(), "ZoneId", "ZoneName");
            model.DistrictList = new SelectList(_repAgManagement.GetDistrictListbyZoneId(1), "DistrictId", "DistrictName");
            model.TimeZoneList = new SelectList(_repAgManagement.GetTimeZoneList(), "RecordID", "StandardName", 66);

            try
            {

                if (!ser.CheckDuplicateBranchName(model.BranchOffice))
                {

                    TempData["ErrorMessage"] = "Registration failed! Branch Name already exists, please re-enter and try again";
                    return View("Create", model);

                }


                if (!ser.CheckDuplicateEmail(model.Email))
                {
                    TempData["ErrorMessage"] = "Registration failed! Email already exists, please re-enter and try again";
                    return View("Create", model);
                }




                if (model.Password != model.ConfirmPassword)
                {
                    TempData["ErrorMessage"] = "Password and Confirm Password doesnot match, please re-enter and try again";
                    return View("Create", model);

                }
                else
                {
                    if (!string.IsNullOrEmpty(model.MobileNo) && !_repAgManagement.CheckDuplicateMobileNumber(model.MobileNo))
                    {
                        TempData["ErrorMessage"] = "Registration failed! Mobile Number already exists, please re-enter and try again";
                        return View("Create", model);

                    }
                    else
                    {
                        int branchofficeid = ser.Create(model);
                        model.MasterDealNameListOfAirlines = provider.GetBranchAllDealListOfAirlines();
                        model.MasterDealNameListOfHotels = provider.GetAllDealListOfHotel();
                        model.MasterDealNameListOfBus = provider.GetAllDealListOfBus();
                        model.MasterDealNameListOfMobile = provider.GetAllDealListOfMobile();

                        ViewData["branchClass"] = new SelectList(provider.GetBranchClass(), "BranchClassId", "BranchClassName");
                        model.BranchClassId = provider.GeBranchClass(obj.LoginTypeId);

                        SaveOrUpdateBranchSetting(branchofficeid, model, obj);
                        
                        TempData["SuccessMessage"] = "Branch office created successfully .";
                        return RedirectToAction("Index");
                    }
                }
            }
            catch (Exception ex)
            {
                TempData["ActionResponse"] = ex.Message;
                model.NativeCountryList = new SelectList(_repAgManagement.GetCountry(), "CountryId", "CountryName", 0);
                model.StatusList = new SelectList(_repAgManagement.GetStatus(), "id", "Name", 1);
                model.ZoneList = new SelectList(_repAgManagement.GetZoneList(), "ZoneId", "ZoneName");
                model.DistrictList = new SelectList(_repAgManagement.GetDistrictListbyZoneId(1), "DistrictId", "DistrictName");
                model.TimeZoneList = new SelectList(_repAgManagement.GetTimeZoneList(), "RecordID", "StandardName", 66);

                return View("Create", model);
            }
        }


        [NonAction]
        public void SaveOrUpdateBranchSetting(int id, BranchOfficeManagementModel settingmodel, TravelSession obj)
        {
          
            if (settingmodel.MasterDealIdOfAirlines != 0)
            {
                bool result = provider.CheckIFDealExistForBranch(id, 1);
                if (result == true)
                {
                    provider.UpdateBranchDeal(settingmodel, 1, id);
                }
                else
                {
                    provider.SaveBranchDeal(settingmodel, id, 1, obj.AppUserId);
                }
            }
            else
            {
                provider.DeleteBranchDeal(id, 1);
            }

            if (settingmodel.MasterDealIdOfHotel != 0)
            {
                bool result = provider.CheckIFDealExistForBranch(id, 2);
                if (result == true)
                {
                    provider.UpdateBranchDeal(settingmodel, 2, id);
                }
                else
                {

                    provider.SaveBranchDeal(settingmodel, id, 2, obj.AppUserId);
                }
            }
            else
            {
                provider.DeleteBranchDeal(id, 2);
            }

            if (settingmodel.MasterDealIdOfBus != 0)
            {
                bool result = provider.CheckIFDealExistForBranch(id, 4);
                if (result == true)
                {
                    provider.UpdateBranchDeal(settingmodel, 4, id);
                }
                else
                {

                    provider.SaveBranchDeal(settingmodel, id, 4, obj.AppUserId);
                }
            }
            else
            {
                provider.DeleteBranchDeal(id, 4);
            }

            if (settingmodel.MasterDealIdOfMobile != 0)
            {
                bool result = provider.CheckIFDealExistForBranch(id, 3);
                if (result == true)
                {
                    provider.UpdateBranchDeal(settingmodel, 3, id);
                }
                else
                {

                    provider.SaveBranchDeal(settingmodel, id, 3, obj.AppUserId);
                }
            }
            else
            {
                provider.DeleteBranchDeal(id, 3);
            }
           
        }

     


        public ActionResult Edit(int id)
        {
            BranchOfficeManagementModel model = new BranchOfficeManagementModel();
            try
            {
                model = ser.BranchOfficeManagementDetail(id);
                model.NativeCountryList = new SelectList(_repAgManagement.GetCountry(), "CountryId", "CountryName", model.NativeCountry);
                model.StatusList = new SelectList(_repAgManagement.GetStatus(), "id", "Name", model.status);
                model.ZoneList = new SelectList(_repAgManagement.GetZoneList(), "ZoneId", "ZoneName", model.Zone);
                model.DistrictList = new SelectList(_repAgManagement.GetDistrictListbyZoneId(1), "DistrictId", "DistrictName", model.District);
                model.TimeZoneList = new SelectList(_repAgManagement.GetTimeZoneList(), "RecordID", "StandardName", model.TimeZone);

                model.MasterDealIdOfAirlines = provider.GetBranchOfficeMasterDeal(id, 1) != null ? provider.GetBranchOfficeMasterDeal(id, 1).DealMasterId : 0;
                model.MasterDealIdOfHotel = provider.GetBranchOfficeMasterDeal(id, 2) != null ? provider.GetBranchOfficeMasterDeal(id, 2).DealMasterId : 0;
                model.MasterDealIdOfBus = provider.GetBranchOfficeMasterDeal(id, 4) != null ? provider.GetBranchOfficeMasterDeal(id, 4).DealMasterId : 0;
                model.MasterDealIdOfMobile = provider.GetBranchOfficeMasterDeal(id, 3) != null ? provider.GetBranchOfficeMasterDeal(id, 3).DealMasterId : 0;


                model.MasterDealNameListOfAirlines = provider.GetBranchAllDealListOfAirlines();
                model.MasterDealNameListOfHotels = provider.GetAllDealListOfHotel();
                model.MasterDealNameListOfBus = provider.GetAllDealListOfBus();
                model.MasterDealNameListOfMobile = provider.GetAllDealListOfMobile();

                ViewData["branchClass"] = new SelectList(provider.GetBranchClass(), "BranchClassId", "BranchClassName");
                model.BranchClassId = provider.GeBranchClass(id);
            }
            catch
            {
            }
            return View(model);

        }


        [HttpPost]
        public ActionResult Edit(int id, BranchOfficeManagementModel model)
        {
            TravelSession obj = (TravelSession)Session["TravelPortalSessionInfo"];
            model.BranchOfficeId = id;
            model.UpdatedBy = obj.AppUserId;
            try
            {
               

                model.NativeCountryList = new SelectList(_repAgManagement.GetCountry(), "CountryId", "CountryName", model.NativeCountry);
                model.StatusList = new SelectList(_repAgManagement.GetStatus(), "id", "Name", model.status);
                model.ZoneList = new SelectList(_repAgManagement.GetZoneList(), "ZoneId", "ZoneName", model.Zone);
                model.DistrictList = new SelectList(_repAgManagement.GetDistrictListbyZoneId(1), "DistrictId", "DistrictName", model.District);
                model.TimeZoneList = new SelectList(_repAgManagement.GetTimeZoneList(), "RecordID", "StandardName", model.TimeZone);

              
                model.MasterDealNameListOfAirlines = provider.GetBranchAllDealListOfAirlines();
                model.MasterDealNameListOfHotels = provider.GetAllDealListOfHotel();
                model.MasterDealNameListOfBus = provider.GetAllDealListOfBus();
                model.MasterDealNameListOfMobile = provider.GetAllDealListOfMobile();

                ViewData["branchClass"] = new SelectList(provider.GetBranchClass(), "BranchClassId", "BranchClassName");
             


                if (ser.CheckEditDuplicateEmail(model.Email, id))
                {
                    TempData["ActionResponse"] = "Registration failed! Email already exists, please re-enter and try again";
                    model = ser.BranchOfficeManagementDetail(id);
                    model.NativeCountryList = new SelectList(_repAgManagement.GetCountry(), "CountryId", "CountryName", model.NativeCountry);
                    model.StatusList = new SelectList(_repAgManagement.GetStatus(), "id", "Name", model.status);
                    model.ZoneList = new SelectList(_repAgManagement.GetZoneList(), "ZoneId", "ZoneName", model.Zone);
                    model.DistrictList = new SelectList(_repAgManagement.GetDistrictListbyZoneId(1), "DistrictId", "DistrictName", model.District);
                    model.TimeZoneList = new SelectList(_repAgManagement.GetTimeZoneList(), "RecordID", "StandardName", model.TimeZone);


                    model.MasterDealNameListOfAirlines = provider.GetBranchAllDealListOfAirlines();
                    model.MasterDealNameListOfHotels = provider.GetAllDealListOfHotel();
                    model.MasterDealNameListOfBus = provider.GetAllDealListOfBus();
                    model.MasterDealNameListOfMobile = provider.GetAllDealListOfMobile();

                    ViewData["branchClass"] = new SelectList(provider.GetBranchClass(), "BranchClassId", "BranchClassName");
                    model.BranchClassId = provider.GeBranchClass(id);
                    return View(model);
                }
                else
                {
                    if (!string.IsNullOrEmpty(model.MobileNo) && !ser.CheckEditDuplicateMobileNumber(model.MobileNo, model.BranchOfficeId))
                    {
                        TempData["ActionResponse"] = "Registration failed! Mobile Number already exists, please re-enter and try again";
                        model = ser.BranchOfficeManagementDetail(id);
                        model.NativeCountryList = new SelectList(_repAgManagement.GetCountry(), "CountryId", "CountryName", model.NativeCountry);
                        model.StatusList = new SelectList(_repAgManagement.GetStatus(), "id", "Name", model.status);
                        model.ZoneList = new SelectList(_repAgManagement.GetZoneList(), "ZoneId", "ZoneName", model.Zone);
                        model.DistrictList = new SelectList(_repAgManagement.GetDistrictListbyZoneId(1), "DistrictId", "DistrictName", model.District);
                        model.TimeZoneList = new SelectList(_repAgManagement.GetTimeZoneList(), "RecordID", "StandardName", model.TimeZone);


                        model.MasterDealNameListOfAirlines = provider.GetBranchAllDealListOfAirlines();
                        model.MasterDealNameListOfHotels = provider.GetAllDealListOfHotel();
                        model.MasterDealNameListOfBus = provider.GetAllDealListOfBus();
                        model.MasterDealNameListOfMobile = provider.GetAllDealListOfMobile();

                        ViewData["branchClass"] = new SelectList(provider.GetBranchClass(), "BranchClassId", "BranchClassName");
                        model.BranchClassId = provider.GeBranchClass(id);
                        return View(model);
                    }

                    else
                    {
                        ser.Edit(id, model);
                        SaveOrUpdateBranchSetting(id, model, obj);
                        model.BranchClassId = provider.GeBranchClass(id);
                        return RedirectToAction("Index");
                    }
                }
               
            }
            catch (Exception ex)
            {
                TempData["ActionResponse"] = ex.Message;
                model = ser.BranchOfficeManagementDetail(id);

                model.NativeCountryList = new SelectList(_repAgManagement.GetCountry(), "CountryId", "CountryName", model.NativeCountry);
                model.StatusList = new SelectList(_repAgManagement.GetStatus(), "id", "Name", model.status);
                model.ZoneList = new SelectList(_repAgManagement.GetZoneList(), "ZoneId", "ZoneName", model.Zone);
                model.DistrictList = new SelectList(_repAgManagement.GetDistrictListbyZoneId(1), "DistrictId", "DistrictName", model.District);
                model.TimeZoneList = new SelectList(_repAgManagement.GetTimeZoneList(), "RecordID", "StandardName", model.TimeZone);

                model.MasterDealNameListOfAirlines = provider.GetBranchAllDealListOfAirlines();
                model.MasterDealNameListOfHotels = provider.GetAllDealListOfHotel();
                model.MasterDealNameListOfBus = provider.GetAllDealListOfBus();
                model.MasterDealNameListOfMobile = provider.GetAllDealListOfMobile();

                ViewData["branchClass"] = new SelectList(provider.GetBranchClass(), "BranchClassId", "BranchClassName");
                model.BranchClassId = provider.GeBranchClass(id);

                return View(model);

            }



        }

        public ActionResult Details(int id)
        {
            BranchOfficeManagementModel model = new BranchOfficeManagementModel();
            try
            {

                model = ser.BranchOfficeManagementDetail(id);
            }
            catch (Exception ex)
            {
                TempData["ActionResponse"] = ex.Message;
            }

            return View(model);

        }


        public JsonResult CheckDuplicateBranchName(string BranchName)
        {
            bool flag;
            flag = ser.CheckDuplicateBranchName(BranchName);

            JsonResult res = new JsonResult
            {
                Data = flag
            };
            return res;
        }

        public ActionResult AgentList(int id, int? page, string name)
        {
            //AgentManagementRepository agentManagementRepository = new AgentManagementRepository();
            //var model = agentManagementRepository.GetAllAgentByPaging().Where(x => x.BranchOfficeId == id).ToList();
            //if (model.Count > 0)
            //    model[0].AgentStatus = true;
            //return PartialView(@"~\Areas\Administrator\Views\DistributorManagement\VUC_AgentList.ascx", model);

            int currentPageIndex = page.HasValue ? page.Value : 1;
            int defaultPageSize = 50;

            DistributorManagementProvider distributorManagementProvider = new DistributorManagementProvider();
            DistributorAgentManagementModel model = new DistributorAgentManagementModel();
            if (name != "Distributor")
            {
                model.AgentsList = distributorManagementProvider.AgentsListByBranchOfficeId().Where(x => x.BranchOfficeId == id).ToPagedList(currentPageIndex, defaultPageSize);
            }
            else
            {
                model.AgentsList = distributorManagementProvider.AgentsListByBranchOfficeId().Where(x => x.DistributorId == id).ToPagedList(currentPageIndex, defaultPageSize);
            }
            if (model.AgentsList.Count > 0)
            {
                model.AgentStatus = true;
            }
            model.RedirectedFrom = "BranchOfficeManagement";
            model.BranchOfficeId = id;
          
            return View(model);
        }

        public ActionResult DistributorList(int id, int? page)
        {
            //DistributorManagementProvider distributorManagementProvider = new DistributorManagementProvider();
            //IEnumerable<DistributorManagementModel> Distributors = distributorManagementProvider.GetBranchDistributorsByBranchOfficeId(id).Distributors;
            //return PartialView("VUC_DistributorList", Distributors);

            int currentPageIndex = page.HasValue ? page.Value : 1;
            int defaultPageSize = 50;

            DistributorManagementProvider distributorManagementProvider = new DistributorManagementProvider();
            DistributorManagementModel model = new DistributorManagementModel();
            model.DistributorsList = distributorManagementProvider.BranchDistributorsByBranchOfficeId(id).ToPagedList(currentPageIndex, defaultPageSize);
            model.DistributorId = id;
            return View(model);
        }

        public ActionResult DistributorAgentList(int id, int? page, string name, int? BOId)
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
            model.BranchOfficeId = (int)BOId;
            model.DistributorId = id;
            return View(model);
        }

      
            //[Authorize]
        public ActionResult DistributorAgentEdit(int? id, string redirected)
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
                
               
                return View(_model);
            }
            else
                return RedirectToAction("Index");
        }
      

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult DistributorAgentEdit(int? id, AgentModel model,  FormCollection fc)
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
                       
                            return RedirectToAction("DistributorAgentList", "BranchOfficeManagement", new { id = model.DistributorId, name = "Distributor", BOId = model.BranchOfficeId});
                      
                        
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



        public ActionResult Delete(int Id)
        {
            try
            {

                ser.DeleteBranchOfficeManagement(Id);
                TempData["InfoMessage"] = "Branch Office Deleted Successfully.";
            }
            catch
            {
                TempData["InfoMessage"] = "You cannot delete this branch office.";
            }
            return RedirectToAction("Index");
        }

        public ActionResult DistributorAgentSetting(int id, int? DisId, int? BOId)
        {
            AgentSettingModel model = new AgentSettingModel();

            model.MasterDealIdOfAirlines = provider.GetMasterDeal(id, 1) != null ? provider.GetMasterDeal(id, 1).MasterDealId : 0;
            model.MasterDealIdOfHotel = provider.GetMasterDeal(id, 2) != null ? provider.GetMasterDeal(id, 2).MasterDealId : 0;
            model.MasterDealNameListOfAirlines = provider.GetBranchAllDealListOfAirlines();
            model.MasterDealNameListOfHotels = provider.GetAllDealListOfHotel();
            model.agentsettinglist = provider.GetAllSettingList();
            model.ServiceProviders = provider.GetAllActiveServiceProviders(id).ToList();
            model.Activeagentsettinglist = provider.GetAllActiveSettingForAgent(id);
            ViewData["agentClass"] = new SelectList(provider.GetAgentClass(), "AgentClassId", "AgentClassName");
            model.AgentClassId = provider.GetAgentClass(id);
            model.AgentName = provider.GetAgentName(id);
            model.DistributorId = DisId;
            model.branchofficeid = BOId;
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
            return RedirectToAction("DistributorAgentList", new {id=settingmodel.DistributorId, name="Distributor", BOId=settingmodel.branchofficeid  });
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
