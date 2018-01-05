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

    public class AjaxRequestController : Controller
    {
        AdminUserManagementRepository pro = new AdminUserManagementRepository();
        AgentManagementRepository _agentProvider = new AgentManagementRepository();
        ATLTravelPortal.Areas.Administrator.Repository.UserRolePrevilageProvider ser = new ATLTravelPortal.Areas.Administrator.Repository.UserRolePrevilageProvider();
        LedgerMasterProvider _ser = new LedgerMasterProvider();
        ATLTravelPortal.Areas.Administrator.Repository.GeneralProvider _generalProvider = new ATLTravelPortal.Areas.Administrator.Repository.GeneralProvider();
        ATLTravelPortal.Areas.Administrator.Repository.BankManagementProvider _bankmanagementser = new ATLTravelPortal.Areas.Administrator.Repository.BankManagementProvider();
        LedgerVoucherProvider _voucherprovider = new LedgerVoucherProvider();
        AdminBankAccountProvider _serABA = new AdminBankAccountProvider();
        AgentCallLogProvider AgentCallLog = new AgentCallLogProvider();
        CreditLimitProvider CreditLimitPro = new CreditLimitProvider();
        /// <summary>
        /// /  
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>


        [HttpPost]
        public JsonResult FindAgentName(string searchText, int maxResult)
        {
            var result = AgentCallLog.GetAgentName(searchText, maxResult);
            return Json(result);


        }

        [HttpPost]
        public JsonResult FindDistributorName(string searchText, int maxResult)
        {
            var result = CreditLimitPro.GetDistributorName(searchText, maxResult);
            return Json(result);


        }
        public ActionResult ListAllDistributors(string AgencyName)
        {
            var ts = SessionStore.GetTravelSession();
            return Json(new ATLTravelPortal.Areas.Administrator.Repository.CreditLimitProvider().FindDistributorsByNameOrCode(AgencyName.Trim(), ts.LoginTypeId), JsonRequestBehavior.AllowGet);
        }



        public ActionResult ListAllSignUpAgency(string AgencyName)
        {
            return Json(new ATLTravelPortal.Areas.Administrator.Repository.AgencyProvider().FindSignUpAgentByNameOrCode(AgencyName.Trim()), JsonRequestBehavior.AllowGet);
        }

        public ActionResult ListAllAgency(string AgencyName)
        {
            return Json(new ATLTravelPortal.Areas.Administrator.Repository.AgentManagementRepository().FindAgentByNameOrCode(AgencyName.Trim()), JsonRequestBehavior.AllowGet);
        }

        public ActionResult ListAllAgencyByDistributorId(string AgencyName)
        {
            var ts = SessionStore.GetTravelSession();
            return Json(new ATLTravelPortal.Areas.Administrator.Repository.AgentManagementRepository().FindAgentByNameOrCodeByDistributorId(AgencyName.Trim(), ts.LoginTypeId), JsonRequestBehavior.AllowGet);
        }

        public ActionResult ListAllBranchOffice(string BranchOffice)
        {
            return Json(new ATLTravelPortal.Areas.Administrator.Repository.BranchOfficeManagementProvider().FindBranchOfficeNameOrCode(BranchOffice.Trim()), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult FindBranchOffice(string searchText, int maxResult)
        {
            var result = new ATLTravelPortal.Areas.Administrator.Repository.BranchOfficeManagementProvider().GetBranchOfficeName(searchText, maxResult);
            return Json(result);


        }

        public ActionResult ListAllBranchOffices(string AgencyName)
        {
            var ts = SessionStore.GetTravelSession();
            return Json(new ATLTravelPortal.Areas.Administrator.Repository.CreditLimitProvider().FindBrachOfficeByNameOrCode(AgencyName.Trim(), ts.LoginTypeId), JsonRequestBehavior.AllowGet);
        }



        public JsonResult GetRolesByProductId(int id)
        {
            var result = new JsonResult();
            var lists = new SelectList(pro.GetAllRolesBasedonProduct(id), "RoleName", "RoleName");
            result.Data = lists;
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return result;

        }

        public JsonResult GetRolesBySubProductId(int id)
        {
            var result = new JsonResult();
            var lists = new SelectList(pro.GetAllRolesBasedonSubProduct(id), "RoleName", "RoleName");
            result.Data = lists;
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return result;

        }


        public JsonResult GeAdminRoleOfTicketing()
        {
            var result = new JsonResult();
            var lists = new SelectList(pro.GetAllRolesBasedonSubProduct(1), "RoleName", "RoleName");
            result.Data = lists;
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return result;

        }

        public JsonResult GetRolesonProductId(int id)
        {
            var result = new JsonResult();
            var lists = new SelectList(ser.GetAllRolesBasedonProduct(id), "RoleId", "RoleName");
            result.Data = lists;
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return result;

        }

        public JsonResult GetAdminRolesonSubProductId(int id)
        {
            var result = new JsonResult();
            var lists = new SelectList(ser.GetAllAdminRolesBasedonProductAndSubProduct(id), "RoleName", "RoleName");
            result.Data = lists;
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return result;

        }

        public JsonResult GetRolesonSubProductId(int ProductId, int SubProductId)
        {
            var result = new JsonResult();
            var lists = new SelectList(ser.GetAllRolesBasedonProductAndSubProduct(ProductId, SubProductId), "RoleName", "RoleName");
            result.Data = lists;
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return result;

        }

        public JsonResult GetGroupNameProductId(int id)
        {
            var result = new JsonResult();
            var lists = new SelectList(ser.GetAllControllerGroupNameBasedonProduct(id), "ControllerGroupId", "ControllerGroupName");
            result.Data = lists;
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return result;

        }

        [HttpPost]
        public JsonResult FindLedgerName(string searchText, int maxResult)
        {
            var result = _voucherprovider.GetLedgerName(searchText, maxResult);
            return Json(result);
        }


        public JsonResult GetControllerNamebyProductIdandSubProductId(int ProductId, int SubProductId)
        {
            var result = new JsonResult();
            var lists = new SelectList(ser.GetAllControllerNameBasedonProductandSubProduct(ProductId, SubProductId), "ControllerId", "ControllerName");
            result.Data = lists;
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return result;

        }

        //public JsonResult GetMapTableList(int id)
        //{
        //    var result = new JsonResult();
        //    var lists = new SelectList(_ser.GetAllAccTypesName(id), "ValueMember", "DisplayMember");
        //    result.Data = lists;
        //    result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
        //    return result;
        //}


        public JsonResult GetMapTableList(int id)
        {
            var result = new JsonResult();
            var AccMember = _ser.GetGLAccTypesBasedOnTypeName(id);
            LedgerMasterModel model = new LedgerMasterModel();
            //var test = _ser.GetAllDisplayValueMenberForDropdown(AccMember.MapTable, AccMember.DisplayMember, AccMember.ValueMember);
            var lists = new SelectList(_ser.GetAllDisplayValueMenberForDropdown(AccMember.MapTable, AccMember.DisplayMember, AccMember.ValueMember), "Value", "Text");
            // model.DisplayMemberList = _ser.GetAllDisplayValueMenberForDropdown(AccMember.MapTable, AccMember.DisplayMember, AccMember.ValueMember);
            result.Data = lists;
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return result;

        }


        public JsonResult GetAccTypeNameBasedOnProductName(int id)
        {
            var result = new JsonResult();
            var lists = new SelectList(_ser.GetAccTypeNameList(id), "AccTypeId", "AccTypeName");
            result.Data = lists;
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return result;
        }


        public JsonResult GetAccSubGroupBasedOnProductNameandAccountGroupName(int id, int accgroupid)
        {
            var result = new JsonResult();
            var lists = new SelectList(_ser.GetAccSubGroupBasedOnProductNameandAccountGroupNameList(id, accgroupid), "AccSubGroupId", "AccSubGroupName");
            result.Data = lists;
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return result;
        }


        public JsonResult CheckDuplicateUserName(string loginName)
        {
            bool flag;
            flag = _agentProvider.CheckDuplicateUsername(loginName);

            JsonResult res = new JsonResult
            {
                Data = flag
            };
            return res;
        }


        public JsonResult CheckDuplicateBranchUserUserName(string loginName)
        {
            bool flag;
            flag = new ATLTravelPortal.Areas.Administrator.Repository.BranchOfficeManagementProvider().CheckDuplicateBranchUsername(loginName);

            JsonResult res = new JsonResult
            {
                Data = flag
            };
            return res;
        }




        public JsonResult GetDistrictOptionsByZoneId(int id)
        {

            var result = new JsonResult();
            var lists = new SelectList(_agentProvider.GetDistrictListbyZoneId(id), "DistrictId", "DistrictName");//_agentProvider.GetDistrictListbyZoneId(id);
            result.Data = lists;
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return result;

        }


        public JsonResult GetBranchListbyBankId(int id)
        {
            var result = new JsonResult();
            var lists = new SelectList(_agentProvider.GetBranchListbyBankId(id), "BankBranchId", "BranchName");//_agentProvider.GetDistrictListbyZoneId(id);
            result.Data = lists;
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return result;

        }


        public JsonResult CheckDuplicateGDSPNR(string GDSPNR)
        {
            AirOfflineBookProvider airofflineProvider = new AirOfflineBookProvider();
            bool flag;

            flag = airofflineProvider.CheckDuplicateGDSPNR(GDSPNR.ToUpper());

            JsonResult res = new JsonResult
            {
                Data = flag
            };
            return res;
        }



        public JsonResult CheckDuplicateAgentName(string AgentName)
        {
            bool flag;
            flag = _agentProvider.CheckDuplicateAgentname(AgentName);

            JsonResult res = new JsonResult
            {
                Data = flag
            };
            return res;
        }
        public JsonResult CheckDuplicateAgentCode(string AgentCode)
        {
            bool flag;
            flag = _agentProvider.CheckDuplicateAgentCode(AgentCode);

            JsonResult res = new JsonResult
            {
                Data = flag
            };
            return res;
        }
        public JsonResult GetProductByAgent(int AgentId)
        {
            var model = _generalProvider.GetProducts(AgentId).ToList();
            JsonResult result = new JsonResult();
            result.Data = new SelectList(model, "ProductId", "ProductName");
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return result;
        }
        public JsonResult DeleteAgentIP(int id)
        {
            _agentProvider.DeleteAgentIPInfo(id);
            JsonResult result = new JsonResult();
            result.Data = id;
            return result;

        }
        public JsonResult DeleteAgentBank(int id)
        {

            _agentProvider.DeleteAgentBankInfo(id);
            JsonResult result = new JsonResult();
            result.Data = id;
            return result;

        }
        /// <summary>////////////////////////////////////////////////////////////////////////////////////////
        /// / Add/update bank information
        /// </summary>
        /// <param name="id"></param>
        /// <param name="agentId"></param>
        /// <param name="bankId"></param>
        /// <param name="branchId"></param>
        /// <param name="accountTypeId"></param>
        /// <param name="accountname"></param>
        /// <param name="accountnumber"></param>
        /// <returns></returns>
        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult AddUpdateAgentBank(int id, int agentId, int bankId, int branchId, int accountTypeId, string accountname, string accountnumber, string banktype)
        {
            AgentBankModel agentbankresult = new AgentBankModel();
            if (id == 0)    //// adding new data
            {
                AgentBankModel SaveAgentBank = new AgentBankModel()
                {
                    BankId = bankId,
                    BankBranchId = branchId,
                    BankAccountTypeId = accountTypeId,
                    AccountName = accountname,
                    AccountNumber = accountnumber,

                    BankType = banktype

                };
                int AgentBankid = _agentProvider.SaveAgentBankInfo(SaveAgentBank, agentId);
                agentbankresult = _agentProvider.GetAgentBankInfo(AgentBankid);
            }
            else        ///// updating existing data
            {
                AgentBankModel UpdateAgentBank = new AgentBankModel()
                {
                    AgentBankId = id,
                    BankId = bankId,
                    BankBranchId = branchId,
                    BankAccountTypeId = accountTypeId,
                    AccountName = accountname,
                    AccountNumber = accountnumber,
                };
                _agentProvider.UpdateAgentBankInfo(UpdateAgentBank);
                agentbankresult = _agentProvider.GetAgentBankInfo(id);
            }
            /////// Returing JSON Result Back ///////////////

            JsonResult result = new JsonResult();
            result.Data = agentbankresult;
            return result;

        }
        /// <summary> IP controller managejment for agent
        /// ////////////////////////////////////////////////////////////////////////////////////////////////
        /// </summary>
        /// 
        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult AddUpdateAgentIP(int agentId, string IPAddress, bool IsAutoExpire, DateTime ActiveDate, DateTime ExpiryDate, bool IsActive)
        {
            AgentIPManagementModel SaveAgentIPInfo = new AgentIPManagementModel()
            {
                IPAddress = IPAddress,
                IsActive = IsActive,
                IsAutoExpire = IsAutoExpire,
                ActiveDate = ActiveDate,
                ExpiryDateTime = ExpiryDate,
                AgentId = agentId,
            };
            var ts = (TravelSession)Session["TravelPortalSessionInfo"];
            int AgentIPid = _agentProvider.SaveAgentIPInfo(SaveAgentIPInfo, ts.AppUserId);
            SaveAgentIPInfo = _agentProvider.GetAgentIPInfo(AgentIPid);
            /////// Returing JSON Result Back //////////////////////////////
            JsonResult result = new JsonResult();
            result.Data = SaveAgentIPInfo;
            return result;

        }
        ///////////////////////////////////************* ////////////////////////////////////////////////////////////////
        ///////////////// BankManagement Controller Region//////////////////////////////////////////////////////////////
        ///////////////////////////////////************* /////////////////////////////////////////////////////////////
        [HttpPost]
        public ActionResult SaveBranch(FormCollection fc)
        {
            //foreach (var key in fc.AllKeys)
            //{
            //    var value = fc[key];
            //    // etc.
            //}



            var value = fc["BranchCountryId"];

            // int a = int.Parse(value.Split(',').ElementAtOrDefault(0));
            // int a = Convert.ToInt32((value.Split(',')).ElementAt(0));
            // int b = Convert.ToInt32((value.Split(',')));
            BankManagementsModel model = new BankManagementsModel();
            model.BranchName = fc["BranchName"].Split(',')[0];
            model.BranchCountryId = Convert.ToInt32(fc["BranchCountryId"].Split(',').ElementAtOrDefault(0));
            model.BranchPhoneNumber = fc["BranchPhoneNumber"].Split(',').ElementAtOrDefault(0);
            model.BranchAddress = fc["BranchAddress"];
            model.BranchContactPhoneNo = fc["BranchContactPhoneNo"].Split(',').ElementAtOrDefault(0);
            model.BranchContactPerson = fc["BranchContactPerson"].Split(',').ElementAtOrDefault(0);
            model.BranchContactEmail = fc["BranchContactEmail"].Split(',').ElementAtOrDefault(0);
            model.BankId = Convert.ToInt32(fc["BankId"]);
            bool check = false;
            int a = model.BankId;
            check = _bankmanagementser.VerifyBranchInput(model.BankId, model.BranchName, model.BranchAddress, model.BranchCountryId, model.BranchPhoneNumber);
            if (check == true)
            {

                model.Branch = _bankmanagementser.ConverToBranch(model);
                _bankmanagementser.CreateBranch(model.Branch);
                model.GetAllBranch = _bankmanagementser.BranchList(a);
                ViewData["Countries"] = _generalProvider.GetCountryList();

                return View("Edit", model);


            }
            else

                return RedirectToAction("Index");
        }

        [HttpPost]
        public JsonResult AddUpdateBranch(int BankId, int BranchId, int BranchCountryId, string BranchName, string BranchPhoneNumber, string BranchAddress, string ContactPhoneNo, string ContactPerson, string ContactEmail)
        {
            bool check = _bankmanagementser.VerifyBranchInput(BankId, BranchName, BranchAddress, BranchCountryId, BranchPhoneNumber);
            if (check == true)
            {
                if (BranchId == 0)
                {
                    BranchManagementsModel model = new BranchManagementsModel
                    {
                        BankId = BankId,
                        BankBranchId = BranchId,
                        BranchCountryId = BranchCountryId,
                        BranchName = BranchName,
                        BranchPhoneNumber = BranchPhoneNumber,
                        BranchAddress = BranchAddress,
                        BranchContactPhoneNo = ContactPhoneNo,
                        BranchContactPerson = ContactPerson,
                        BranchContactEmail = ContactEmail
                    };
                    _bankmanagementser.CreateBranch(model);
                    model.BankBranchId = _bankmanagementser.GetLastBranchId(model.BankId);
                    BranchManagementsModel item = _bankmanagementser.GetBranchDetails(model.BankBranchId);
                    JsonResult result = new JsonResult();
                    result.Data = item;
                    return result;
                }
                else
                {
                    BranchManagementsModel model = new BranchManagementsModel
                    {
                        BankId = BankId,
                        BankBranchId = BranchId,
                        BranchCountryId = BranchCountryId,
                        BranchName = BranchName,
                        BranchPhoneNumber = BranchPhoneNumber,
                        BranchAddress = BranchAddress,
                        BranchContactPhoneNo = ContactPhoneNo,
                        BranchContactPerson = ContactPerson,
                        BranchContactEmail = ContactEmail
                    };
                    _bankmanagementser.BranchUpdate(model);
                    BranchManagementsModel item = _bankmanagementser.GetBranchDetails(model.BankBranchId);
                    JsonResult result = new JsonResult();
                    result.Data = item;
                    return result;
                }
            }
            else
            {

                JsonResult answer = new JsonResult();
                answer.Data = null;
                return answer;
            }
        }

        public JsonResult AddBank(int CountryId, string BankName, string BankPhoneNo, string BankAddress, string ContactPersonPhoneNo, string ContactPersonMobileNo, string ContactPerson, string ContactPersonEmail)
        {
            bool check = false;
            JsonResult result = new JsonResult();

            {
                check = _bankmanagementser.VerifyBankInput(BankName, BankAddress, BankPhoneNo, ContactPerson);
                if (check == true)
                {
                    BankManagementsModel model = new BankManagementsModel();
                    model.BankName = BankName;
                    model.BankAddress = BankAddress;
                    model.CountryId = CountryId;
                    model.PhoneNo = BankPhoneNo;
                    model.ContactPerson = ContactPerson;
                    model.ContactPersonPhoneNo = ContactPersonPhoneNo;
                    model.ContactPersonMobileNo = ContactPersonMobileNo;
                    model.ContactPersonEmail = ContactPersonEmail;
                    _bankmanagementser.CreateBank(model);
                    result.Data = _bankmanagementser.GetLastBankId();

                    return result;
                }
                result.Data = null;
                return result;



            }
        }
        /////////////////End of BankManagement Controller Region///////////////////////////////////////////
        ///////////////////////////////////************* /////////////////////////////////////////////////
        /////////////////////////////////// start region for New controller and Controllergroup setup /////////////////////////////////////////////////
        [HttpGet]
        public ActionResult CreateControllerGroup()
        {
            TravelSession obj = (TravelSession)Session["TravelPortalSessionInfo"];
            RolePrivilageModel viewModel = new RolePrivilageModel()
            {
                ProductList = ser.GetAllProductList(),
            };

            if (Request.IsAjaxRequest())
            {
                return PartialView("PriviledgeSetupPartial", viewModel);
            }

            return RedirectToAction("Create", "PriviledgeSetup", viewModel);
        }


        [HttpPost]
        public ActionResult CreateControllerGroup(RolePrivilageModel model)
        {
            TravelSession obj = (TravelSession)Session["TravelPortalSessionInfo"];

            RolePrivilageModel viewModel = new RolePrivilageModel()
            {
                ProductList = ser.GetAllProductList(),
            };

            if (!ModelState.IsValid)
            {
                if (Request.IsAjaxRequest())
                    return PartialView("PriviledgeSetupPartial", viewModel);
            }
            else
            {
                //if (Request.IsAjaxRequest())

                model.SeqNumber = ser.GetAllSequenceNoFromControllerGroup() + 1;    // use sequence no last sequence No. + 1


                // for checking duplicate insertion of Group Name
                bool checkGroupName = ser.CheckDuplicateGroupName(model.GroupName);
                if (checkGroupName == true)
                {
                    ser.ControllerGroupAdd(model);
                }
                else
                {
                    TempData["success"] = "Group Name already exists";
                }
                //ser.ControllerGroupAdd(model);
            }
            return RedirectToAction("Create", "PriviledgeSetup");
        }

        public JsonResult GetSubGroupNameProductId(int id)
        {
            var result = new JsonResult();
            var lists = new SelectList(ser.GetSubProductList(id), "Value", "Text");
            result.Data = lists;
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return result;

        }

        [HttpGet]
        public ActionResult RegisterNewController()
        {
            TravelSession obj = (TravelSession)Session["TravelPortalSessionInfo"];

            RolePrivilageModel viewModel = new RolePrivilageModel()
            {
                ProductList = ser.GetAllProductList(),
                SubProductList = ser.GetSubProductList(0),
                GroupNameList = ser.GetSubProductList(0)
            };

            if (Request.IsAjaxRequest())
            {
                return PartialView("ControllerNameSetupPartial", viewModel);

            }

            return RedirectToAction("Create", "PriviledgeSetup");

        }

        [HttpPost]
        public ActionResult RegisterNewController(RolePrivilageModel model)
        {
            TravelSession obj = (TravelSession)Session["TravelPortalSessionInfo"];

            RolePrivilageModel viewModel = new RolePrivilageModel()
            {
                ProductList = ser.GetAllProductList(),
                SubProductList = ser.GetSubProductList(0),
                GroupNameList = ser.GetSubProductList(0)
            };

            if (!ModelState.IsValid)
            {
                if (Request.IsAjaxRequest())
                    return PartialView("ControllerNameSetupPartial", viewModel);
            }
            else
            {
                //if (Request.IsAjaxRequest())

                model.SeqNumber = ser.GetAllSequenceNoFromControllerList(model.ControllerName) + 1;    // use sequence no last sequence No. + 1
                try
                {

                    ser.ControllerListAdd(model);
                }
                catch
                {
                    TempData["success"] = "ControllerName already exists!";
                }
            }
            return RedirectToAction("Create", "PriviledgeSetup");
        }
        ///////////////////// End region for New controller and Controllergroup setup ////////////////////////////
        //////////**********************************************************/////////////////////////////////////

        public JsonResult GetBankBranchBasedonBankId(int id)
        {
            var result = new JsonResult();
            var lists = new SelectList(_serABA.GetBankBranchList(id), "BankBranchId", "BranchName");
            result.Data = lists;
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return result;

        }


        public ActionResult DeleteComment(int phonelogid, int commentid)
        {
            TravelSession ts = (ATLTravelPortal.Helpers.TravelSession)Session["TravelPortalSessionInfo"];
            AgentCallLogModel model = new AgentCallLogModel();

            model.CreatedBy = ts.AppUserId;
            AgentCallLogProvider Provider = new AgentCallLogProvider();
            int CallLogcommentid = Provider.GetCommentCreatedBy(commentid);

            if (model.CreatedBy == CallLogcommentid)
            {

                Provider.DeleteComment(phonelogid, commentid);
            }
            else
            {

            }

            return RedirectToAction("Edit", "AgentCallLog", new { @id = phonelogid });
        }


        public ActionResult DeleteAgentTeleLogComment(int telelogid, int commentid)
        {
            TravelSession ts = (ATLTravelPortal.Helpers.TravelSession)Session["TravelPortalSessionInfo"];
            AgentTeleLogsModel model = new AgentTeleLogsModel();
            model.CreatedBy = ts.AppUserId;
            AgentTeleLogsProvider Provider = new AgentTeleLogsProvider();
            int TeleLogcommentid = Provider.GetCommentCreatedBy(commentid);

            if (model.CreatedBy == TeleLogcommentid)
            {
                Provider.DeleteComment(telelogid, commentid);
            }
            else
            {
            }
            return RedirectToAction("Edit", "AgentTeleLogs", new { @id = telelogid });
        }

        public JsonResult CheckDuplicateEmail(string Email)
        {
            bool flag;
            flag = _agentProvider.CheckDuplicateEmail(Email);

            JsonResult res = new JsonResult
            {
                Data = flag
            };
            return res;
        }

        public JsonResult CheckDuplicateMobileNumber(string MobileNumber)
        {
            bool flag;
            flag = _agentProvider.CheckDuplicateMobileNumber(MobileNumber);

            JsonResult res = new JsonResult
            {
                Data = flag
            };
            return res;
        }




        public JsonResult CheckDuplicateBranchOfficeEmail(string Email)
        {
            bool flag;
            flag = new ATLTravelPortal.Areas.Administrator.Repository.BranchOfficeManagementProvider().CheckDuplicateEmail(Email);

            JsonResult res = new JsonResult
            {
                Data = flag
            };
            return res;
        }


        //public string FindAgents(string id, string callback, string term)
        //{
        //    var ddlSelectOptionList = GetAllAgentsList().Where(x => x.AgentName.ToLower().IndexOf(term.ToLower()) >= 0);

        //    string resResult = callback + "([";
        //    foreach (var item in ddlSelectOptionList)
        //    {
        //        resResult += "{\"name\":\"" + item.AgentName + "\" , \"agentId\":\""+item.AgentId + "\"},";
        //    }
        //    resResult += "])";
        //    return resResult;          
        //}


        [HttpPost]
        public JsonResult FindAgents(string term, int maxResults)//
        {
            var result = GetAgents(term, 10);//, maxResults
            return Json(result);
        }
        public List<Agents> GetAgents(string agentName, int maxResult)
        {
            return GetAllAgentsList(agentName, maxResult).ToList();
        }

        public IEnumerable<Agents> GetAllAgentsList(string agentName, int maxResult)
        {
            EntityModel ent = new EntityModel();
            return ent.Agents.Where(x => (x.AgentName.ToLower().Contains(agentName.ToLower()) || x.AgentName.ToLower().Contains(agentName.ToLower()))).Take(maxResult).ToList().Select(x =>
                                new Agents { AgentName = x.AgentName, AgentId = x.AgentId, AgentCode = x.AgentCode }
                );
        }

        public IEnumerable<Agents> GetAllAgentsList()
        {
            EntityModel ent = new EntityModel();
            return ent.Agents;
        }

        public JsonResult GetDistributorByBranchOfficeId(int? id)
        {
            AgentCLApprovedProvider agentCLApprovedProvider = new AgentCLApprovedProvider();
            var result = new JsonResult();
            IEnumerable<SelectListItem> lists = new SelectList(agentCLApprovedProvider.GetAllDistributorsByBranchOfficeId(id ?? 0), "DistributorId", "DistributorName"); 
            result.Data = lists;
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return result;
        }

        public JsonResult GetAgentsByDistributorId(int? id)
        {
            AgentCLApprovedProvider agentCLApprovedProvider = new AgentCLApprovedProvider();
            var result = new JsonResult();
            IEnumerable<SelectListItem> lists = new SelectList(agentCLApprovedProvider.GetAgentsByDistributorId(id ?? 0), "AgentId", "AgentName"); 
            result.Data = lists;
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return result;
        }

        public JsonResult GetDistributorUsers(int? id)
        {
            AgentCLApprovedProvider agentCLApprovedProvider = new AgentCLApprovedProvider();
            var result = new JsonResult();
            IEnumerable<SelectListItem> lists = new SelectList(agentCLApprovedProvider.GetDistributorUsers(id), "AppUserId", "FullName"); 
            result.Data = lists;
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return result;
        }

        public JsonResult GetAllBackOfficeUsers(int? id)
        {
            ATLTravelPortal.Areas.Administrator.Repository.GeneralProvider defaultProvider = new  ATLTravelPortal.Areas.Administrator.Repository.GeneralProvider ();
            var result = new JsonResult();
            IEnumerable<SelectListItem> lists = new SelectList(defaultProvider.GetUserList(), "AppUserId", "FullName");
            result.Data = lists;
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return result;
        }
    }
}
