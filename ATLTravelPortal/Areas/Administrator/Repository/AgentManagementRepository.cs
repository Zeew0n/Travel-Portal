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
using System.Data.Common;
using System.Data.Objects;
using System.Data.Objects.DataClasses;
using System.Web.Mvc;
using TravelPortalEntity;
using ATLTravelPortal.Helpers;
using ATLTravelPortal.Areas.Administrator.Models;
using ATLTravelPortal.Models;
using System.IO;
using System.Web.Security;
using iTextSharp.text;



namespace ATLTravelPortal.Areas.Administrator.Repository
{
    public class AgentManagementRepository
    {
        /// <summary>
        /// ////////Listing Agent management by Admin
        /// </summary>
        /// 
        TravelPortalEntity.EntityModel _ent = new TravelPortalEntity.EntityModel();
        ActionResponse _res = new ATLTravelPortal.Models.ActionResponse();
        UserManagementProvider _usRep = new UserManagementProvider();
        AgentdetailsProvider _agentdetailsprovider = new AgentdetailsProvider();
        AdminUserManagementRepository pro = new AdminUserManagementRepository();
        #region

        public int GetSignUpAgentIdByAgentName(string agentname)
        {
            int signupagentid = _ent.SignUpAgents.Where(x => x.AgentName == agentname).Select(x => x.AgentId).FirstOrDefault();
            return signupagentid;

        }

        public string GetSignUpAgentpassword(int signupagentid)
        {
            string password = _ent.SignUpAgents.Where(x => x.AgentId == signupagentid).Select(x => x.Password).FirstOrDefault();
            return password;

        }

        public AgentModel Detail(int? pId, out ActionResponse _ores)
        {
            AgentModel model = new AgentModel();

            if (pId != null)
            {
                var obj = _ent.Agents.SingleOrDefault(u => u.AgentId == pId);
                if (obj != null)
                {
                    Agents datamodel = GetAgentInfo(pId.Value);
                    Core_AgentsDeals dealmodelofAirline = GetMasterDeal(pId.Value, 1);
                    Core_AgentsDeals dealmodelofHotel = GetMasterDeal(pId.Value, 2);
                    View_AgentDetails Agentadmindetails = _agentdetailsprovider.GetAgentAdminUser(pId.Value);
                    UsersDetails usersDetails = GetDefaultUserDetailsByAgentId(pId.Value);

                    int signupagentid = GetSignUpAgentIdByAgentName(datamodel.AgentName);

                    string password = GetSignUpAgentpassword(signupagentid);

                    AgentModel viewmodel = new AgentModel();
                    viewmodel.AgentId = datamodel.AgentId;
                    viewmodel.AgentName = datamodel.AgentName;
                    viewmodel.Email = datamodel.Email;
                    viewmodel.Phone = datamodel.Phone;

                    viewmodel.RefferedBy = datamodel.ReferredBy;
                    viewmodel.MEsId = datamodel.MEsId;
                    if (usersDetails == null)
                    {
                        viewmodel.MobileNo = "";
                    }
                    else
                    {
                        viewmodel.MobileNo = usersDetails.MobileNumber;
                    }
                    // viewmodel. MobileNo = usersDetails.MobileNumber==null?"":usersDetails.MobileNumber;
                    viewmodel.Address = datamodel.Address;
                    viewmodel.AgentStatusid = Convert.ToInt32(datamodel.AgentStatus);
                    viewmodel.FaxNo = datamodel.FaxNo;
                    viewmodel.PanNo = datamodel.PanNo;
                    viewmodel.Web = datamodel.Web;
                    viewmodel.AgentLogo = datamodel.AgentLogo;
                    viewmodel.AgentCode = datamodel.AgentCode;
                    viewmodel.MaxNumberOfAgentUser = datamodel.MaxNumberOfAgentUser;
                    viewmodel.AirlineGroupId = datamodel.AirlineGroupId;
                    viewmodel.BranchOfficeId = datamodel.BranchOfficeId;
                    viewmodel.DistributorId = datamodel.DistributorId;
                    // viewmodel.AirlineGroupName = datamodel.AirlineGroups.AirlineGroupName;
                    if (datamodel.AirlineGroups == null)
                    {
                        viewmodel.AirlineGroupName = "";
                    }
                    else
                    {
                        viewmodel.AirlineGroupName = datamodel.AirlineGroups.AirlineGroupName;
                    }
                    viewmodel.MasterDealIdOfAirlines = dealmodelofAirline != null ? dealmodelofAirline.MasterDealId : 0;
                    viewmodel.MasterDealIdOfHotel = dealmodelofHotel != null ? dealmodelofHotel.MasterDealId : 0;

                    viewmodel.AgentDealName = dealmodelofAirline != null ? dealmodelofAirline.Tkt_DealMasters.DealName : string.Empty;

                    viewmodel.TimeZoneId = datamodel.TimeZoneId;
                    viewmodel.TimeZoneName = datamodel.TimeZones.StandardName;

                    viewmodel.ZoneId = datamodel.ZoneId;
                    viewmodel.ZoneName = datamodel.Zones != null ? datamodel.Zones.ZoneName : null;

                    viewmodel.DistrictId = datamodel.DistrictId;
                    viewmodel.DistrictName = datamodel.Districts != null ? datamodel.Districts.DistrictName : null;

                    viewmodel.AgentClassId = Convert.ToInt32(datamodel.AgentClassId);
                    viewmodel.AgentTypeId = datamodel.AgentTypeId;
                    viewmodel.AgentTypeName = datamodel.AgentTypes.AgentTypeName;
                    viewmodel.NativeCountryId = datamodel.NativeCountry;
                    viewmodel.AgentCountryName = datamodel.Countries.CountryName;
                    //// login details
                    // viewmodel.UserName = Agentadmindetails.UserName;
                    viewmodel.UserName = Agentadmindetails == null ? GetUserName(signupagentid) : Agentadmindetails.UserName;
                    //viewmodel.EmailId = Membership.GetUser(usersDetails.UserId).Email;
                    viewmodel.EmailId = usersDetails == null ? GetEmailID(signupagentid) : Membership.GetUser(usersDetails.UserId).Email;
                    // viewmodel.Address1 = usersDetails.UserAddress;
                    viewmodel.Address1 = usersDetails == null ? GetAddress(signupagentid) : usersDetails.UserAddress;
                    // viewmodel.PhoneNo = usersDetails.PhoneNumber;
                    viewmodel.PhoneNo = usersDetails == null ? "" : usersDetails.PhoneNumber;
                    //viewmodel.FullName = Agentadmindetails.FullName;
                    viewmodel.FullName = Agentadmindetails == null ? GetFullName(signupagentid) : Agentadmindetails.FullName;
                    viewmodel.Password = GetSignUpAgentpassword(signupagentid);
                    viewmodel.ConfirmPassword = GetSignUpAgentpassword(signupagentid);
                    ///// Bank information
                    /////Agent setting information //////
                    viewmodel.agentsettinglist = GetAllSettingList();
                    viewmodel.Activeagentsettinglist = GetAllActiveSettingForAgent(pId.Value);
                    viewmodel.AgentProductList = GetAllAssociatedProductofAgent(pId.Value);
                    viewmodel.ProductBaseRoleList = GetProductList();
                    viewmodel.MasterDealNameListOfAirlines = GetAllDealListOfAirlines();
                    viewmodel.MasterDealNameListOfHotels = GetAllDealListOfHotel();

                    viewmodel.AirlineGroupList = GetAllAirlineGroups();
                    viewmodel.AgentSettingDetailList = GetAllSettingList(pId.Value);
                    viewmodel.agentbankDetaillist = GetBankInfo(pId.Value);
                    viewmodel.agentIPList = GetIPInfo(pId.Value);



                    //AgentModel viewmodel = new AgentModel
                    //{
                    //    AgentId = datamodel.AgentId,
                    //    AgentName = datamodel.AgentName,
                    //    Email = datamodel.Email,
                    //    Phone = datamodel.Phone,
                    //    MobileNo = usersDetails.MobileNumber,
                    //    Address = datamodel.Address,
                    //    AgentStatusid = Convert.ToInt32(datamodel.AgentStatus),
                    //    FaxNo = datamodel.FaxNo,
                    //    PanNo = datamodel.PanNo,
                    //    Web = datamodel.Web,
                    //    AgentLogo = datamodel.AgentLogo,
                    //    AgentCode = datamodel.AgentCode,
                    //    MaxNumberOfAgentUser = datamodel.MaxNumberOfAgentUser,
                    //    AirlineGroupId = datamodel.AirlineGroupId,
                    //    AirlineGroupName = datamodel.AirlineGroups.AirlineGroupName,
                    //    MasterDealIdOfAirlines = dealmodelofAirline != null ? dealmodelofAirline.MasterDealId : 0,
                    //    MasterDealIdOfHotel = dealmodelofHotel != null ? dealmodelofHotel.MasterDealId : 0,




                    //    AgentDealName = dealmodelofAirline != null ? dealmodelofAirline.Tkt_DealMasters.DealName : string.Empty,

                    //    TimeZoneId = datamodel.TimeZoneId,
                    //    TimeZoneName = datamodel.TimeZones.StandardName,

                    //    ZoneId = datamodel.ZoneId,
                    //    ZoneName = datamodel.Zones!= null? datamodel.Zones.ZoneName:null,

                    //    DistrictId = datamodel.DistrictId,
                    //    DistrictName = datamodel.Districts!=null?datamodel.Districts.DistrictName:null,

                    //    AgentClassId = Convert.ToInt32(datamodel.AgentClassId),
                    //    AgentTypeId = datamodel.AgentTypeId,
                    //    AgentTypeName = datamodel.AgentTypes.AgentTypeName,
                    //    NativeCountryId = datamodel.NativeCountry,
                    //    AgentCountryName = datamodel.Countries.CountryName,
                    //    //// login details
                    //    UserName = Agentadmindetails.UserName,
                    //    EmailId = Membership.GetUser(usersDetails.UserId).Email,
                    //    Address1 = usersDetails.UserAddress,
                    //    PhoneNo = usersDetails.PhoneNumber,
                    //    FullName = Agentadmindetails.FullName,
                    //    ///// Bank information
                    //    /////Agent setting information //////
                    //    agentsettinglist = GetAllSettingList(),
                    //    Activeagentsettinglist = GetAllActiveSettingForAgent(pId.Value),
                    //    AgentProductList = GetAllAssociatedProductofAgent(pId.Value),
                    //    ProductBaseRoleList = GetProductList(),
                    //    MasterDealNameListOfAirlines = GetAllDealListOfAirlines(),
                    //    MasterDealNameListOfHotels = GetAllDealListOfHotel(),

                    //    AirlineGroupList = GetAllAirlineGroups(),
                    //    AgentSettingDetailList = GetAllSettingList(pId.Value),
                    //    agentbankDetaillist = GetBankInfo(pId.Value),
                    //    agentIPList = GetIPInfo(pId.Value)

                    //};

                    if (dealmodelofAirline != null && dealmodelofAirline.Agents != null && dealmodelofAirline.Agents.AgentClasses != null)
                        viewmodel.AgentClassName = dealmodelofAirline.Agents.AgentClasses.AgentClassName;
                    else
                        viewmodel.AgentClassName = string.Empty;

                    model = viewmodel;
                }
                else
                {
                    _res.ActionMessage = String.Format(Resources.Message.InvalidOperation, "Agents");
                    _res.ErrNumber = 1005;
                    _res.ErrSource = "DataBase";
                    _res.ErrType = "App";
                    _res.ResponseStatus = true;
                }
            }
            else
            {
                _res.ActionMessage = String.Format(Resources.Message.InvalidOperation, "Agents");
                _res.ErrNumber = 1005;
                _res.ErrSource = "DataBase";
                _res.ErrType = "App";
                _res.ResponseStatus = true;
            }
            _ores = _res;
            return model;
        }

        public string GetUserName(int? agentId)
        {
            string UserName = _ent.SignUpAgents.Where(x => x.AgentId == agentId).Select(x => x.UserName).FirstOrDefault();
            return UserName;
        }


        public void CreateUser(AgentModel obj)
        {
            _ent.CreateASPUser(obj.UserName, obj.Password, obj.Email, "AGENT", null, obj.FullName, obj.Address, obj.MobileNo, obj.PhoneNo, (int)ATLTravelPortal.Helpers.UserTypes.User, obj.CreatedbyUser, "Holidays");

        }
        public ActionResponse Create(AgentModel model, List<AgentBankModel> AgentBankModel, int[] ChkProductId, FormCollection fc)
        {
            if (model.Password != model.ConfirmPassword)
            {
                _res.ActionMessage = "Registration failed! Either Enter Username or Your passwords must match, please re-enter and try again";
                _res.ErrNumber = 1011;
                _res.ResponseStatus = true;
                goto End;
            }

            /*------------ handling various checkbox -----------------------------------------------*/

            if (fc["Unlimiteduser"].Contains("true"))
            {
                model.MaxNumberOfAgentUser = -1;
            }
            /*------------End of handling various checkbox  -------------------------------------------*/


            int AgentId = 0;
            _res = SaveAgent(model, out AgentId);
            if (_res.ErrNumber > 0)
                goto End;
            /*------------ Begin of Saving Agent Authorize User  --------------------------------------------------------*/
            model.AgentId = AgentId;
            _res = CreateAgentUser(model, (int)ATLTravelPortal.Helpers.UserTypes.User);
            if (_res.ErrNumber > 0)
                goto End;
            /*Create User*/

            //////////////collect Agent Associate Product and save /////////////////////////////////////////////////////////////
            List<int> ChkProductIdS = new List<int>();
            foreach (int pid in ChkProductId)
            {
                ChkProductIdS.Add(pid);
                /////////  Save individual User Roles in database ////
                model.AgentRole = fc["RoleId"] ?? fc["RoleId" + pid];

                if (model.AgentRole == null)
                {
                    model.AgentRole = "Ticketing Agent";
                    Roles.AddUserToRole(model.UserName, model.AgentRole);
                }
                else
                {

                    Roles.AddUserToRole(model.UserName, model.AgentRole);
                }
            }

            AddAgentProduct(ChkProductIdS, AgentId);
            MembershipUser mem = Membership.GetUser(model.UserName);   // Call membership API for Getting UserId in GUID
            Guid userGUId = new Guid(mem.ProviderUserKey.ToString());
            if (model.AgentStatusid == 0) ///If select status is deactive then Lockuser
            {

                pro.LockUserNow(model.UserName);
                Membership.UpdateUser(mem);
            }
            int AppUserId = GetUserDetails(userGUId); /// Call this method to get AppUserId
            AddUserProduct(ChkProductIdS, AppUserId);  // Save Add User Product
            // ***********************************************************************************************
            if (ChkProductIdS.Contains(1))  ///// Create General Ledger For this Agents
            {
                SaveAgentGeneralLedger(AgentId, 1, model.CreatedBy);
            }

            /*------------ Saving configuration ----------------------------------*/
            SaveAgentCoreConfiguration(AgentId, model.Email);

            // ***********************************************************************************************
            ///////////Begin of Saving Agent Bank info  /////////////////////////////////////////////////////////////////////
            if (model.MasterDealIdOfAirlines != 0)
            {
                SaveAgentDeal(model, AgentId, 1);
            }


            _res.ErrNumber = 0;
            _res.ResponseStatus = true;
            goto End;

        End:
            return _res;
        }

        public bool CheckIfLegerAccountAlreadyExist(int agentId)
        {
            var result = _ent.GL_Ledgers.Where(gg => gg.Id == agentId).FirstOrDefault();
            if (result != null)
                return true;
            else
                return false;
        }


        public ActionResponse Edit(int? id, AgentModel model, int[] ChkProductId, FormCollection fc)
        {

            if (id == null)
            {
                _res.ActionMessage = String.Format(Resources.Message.InvalidOperation, "Agent");
                _res.ErrNumber = 1005;
                _res.ErrSource = "DataBase";
                _res.ErrType = "App";
                _res.ResponseStatus = true;
                goto End;
            }
            var obj = _ent.Agents.Where(x => x.AgentId == id).FirstOrDefault();
            if (obj == null)
            {
                _res.ActionMessage = String.Format(Resources.Message.InvalidOperation, "Agent");
                _res.ErrNumber = 1005;
                _res.ErrSource = "DataBase";
                _res.ErrType = "App";
                _res.ResponseStatus = true;
                goto End;
            }

            ///////////////////////End of Agent Logo File updates  //////////////////////////////////////////
            /////    handling  checkbox /////////////////////////////////////////////////////////////////////
            if (fc["Unlimiteduser"].Contains("true"))
            {
                model.MaxNumberOfAgentUser = -1;
            }
            //Lock/Unlock user on Basis of active/deactive status
            if (model.AgentStatusid == 0) ///If select status is deactive then Lockuser
            {
                MembershipUser muUser = Membership.GetUser(model.UserName);
                pro.LockUserNow(model.UserName);
                Membership.UpdateUser(muUser);
            }
            else
            {
                MembershipUser muUser = Membership.GetUser(model.UserName);
                Membership.GetUser(model.UserName).UnlockUser();
                muUser.Email = model.EmailId;

                Membership.UpdateUser(muUser);

                UsersDetails usersDetails = _ent.UsersDetails.Where(x => x.UserId == (Guid)muUser.ProviderUserKey).FirstOrDefault();
                if (usersDetails != null)
                {
                    usersDetails.MobileNumber = model.MobileNo;
                    usersDetails.PhoneNumber = model.PhoneNo;
                    usersDetails.UserAddress = model.Address1;

                    _ent.ApplyCurrentValues(usersDetails.EntityKey.EntitySetName, usersDetails);
                    _ent.SaveChanges();
                }
            }
            /////End of handling various checkbox //////////////////////////////////////////////////////////
            /////////////// Update Agent in Agents table //////////////////////////////////////////////
            UpdateAgent(model);
            // _agentProvider.UpdateUser(models);
            ////////////// Begin of Updateing Agent Associate Product //////////////////////////////////
            DeleteAgentProduct(id.Value);            //// First delete all agent Product///
            List<int> ChkProductIdS = new List<int>();

            if (ChkProductId != null)
            {
                foreach (int pid in ChkProductId)
                {
                    ChkProductIdS.Add(pid);
                }
            }

            AddAgentProduct(ChkProductIdS, id.Value);
            //if (model.MasterDealIdOfAirlines != 0)
            //{
            //    bool result = CheckIFDealExistForAgent(id.Value, 1);
            //    if (result == true)
            //    {
            //        UpdateDeal(model, 1);
            //    }
            //    else
            //    {
            //        model.CreatedBy = model.UpdatedBy;
            //        model.CreatedDate = model.UpdatedDate;
            //        SaveAgentDeal(model, id.Value, 1);
            //    }
            //}
            //else
            //{
            //    DeleteAgentDeal(id.Value, 1);
            //}

            //if (model.MasterDealIdOfHotel != 0)
            //{
            //    bool result = CheckIFDealExistForAgent(id.Value, 2);
            //    if (result == true)
            //    {
            //        UpdateDeal(model, 1);
            //    }
            //    else
            //    {
            //        model.CreatedBy = model.UpdatedBy;
            //        model.CreatedDate = model.UpdatedDate;
            //        SaveAgentDeal(model, id.Value, 2);
            //    }
            //}
            //else
            //{
            //    DeleteAgentDeal(id.Value, 2);
            //}

            /////////////////Begin Updating Agent Setting Lists /////////////////////////////////////////////
            //DeleteAgentSetting(id.Value); //// First delete all agent setting///
            //if (ChkSettingId != null)    //////////  Checking if product is other than Ticketing
            //{
            //    List<int> AgentSettingIds = new List<int>();
            //    foreach (int sid in ChkSettingId)
            //    {
            //        AgentSettingIds.Add(sid);
            //    }

            //    AddAgentSetting(AgentSettingIds, id.Value);
            //}



            _res.ActionMessage = String.Format(Resources.Message.SuccessfullyUpdated, "Agent");
            _res.ErrNumber = 0;
            _res.ResponseStatus = true;
            goto End;

        End:
            return _res;
        }
        private ActionResponse CreateAgentUser(AgentModel model, int p)
        {
            UserManagementModel.CreateAspUser obj = new UserManagementModel.CreateAspUser();
            obj.UserName = model.UserName;
            obj.Password = model.Password;
            obj.Email = model.EmailId;
            obj.FullName = model.FullName;
            obj.Address = model.Address1;
            obj.MobileNo = model.MobileNo;
            obj.PhoneNo = model.PhoneNo;
            obj.AgentId = model.AgentId;
            obj.CreatedBy = model.CreatedBy;
            _usRep.CreateUser(obj, (int)ATLTravelPortal.Helpers.UserTypes.User);
            return _res;
        }
        private bool IsAgentCodeExists(int? Pid, string AgentCode)
        {
            var result = _ent.Agents.Where(x => x.AgentCode == AgentCode.Trim().ToLower() && x.AgentId != Pid).FirstOrDefault();
            if (result == null)
                return false;
            else
                return true;
        }
        private bool IsAgentNameExists(int? Pid, string AgentName)
        {
            var result = _ent.Agents.Where(x => x.AgentName == AgentName.Trim().ToLower() && x.AgentId != Pid).FirstOrDefault();
            if (result == null)
                return false;
            else
                return true;
        }

        #endregion
        #region Agent Management Service

        // TravelProtalEntities ent = new TravelProtalEntities();

        CountryProvider _countryPro = new CountryProvider();
        public List<TimeZones> GetTimeZoneList()
        {
            return _ent.TimeZones.ToList();
        }

        /// <summary>
        /// /////////////needed code////////////
        /// </summary>
        /// <returns></returns>
        public IQueryable<Agents> GetAll()
        {
            return _ent.Agents/*.Include("tbl_AgentType")*/.OrderByDescending(xx => xx.AgentId).AsQueryable();


        }

        public string GetFullName(int? agentId)
        {
            string FullName = _ent.SignUpAgents.Where(x => x.AgentId == agentId).Select(x => x.FullName).FirstOrDefault();
            return FullName;
        }
        /// <summary>
        /// ////////////////////////////
        /// </summary>
        /// <returns></returns>
        /// 

        //public IEnumerable<AgentModel> GetAll()
        //{
        //    List<AgentModel> model = new List<AgentModel>();
        //    var result = _ent.Agents;
        //    foreach (var item in result)
        //    {
        //        AgentModel obj = new AgentModel
        //        {
        //            FullName = item.userde
        //        };
        //        model.Add(obj);
        //    }

        //    return model.OrderByDescending(xx => xx.AgentId).AsEnumerable();
        //}

        public IQueryable<Agents> GetLastId()
        {
            return _ent.Agents.AsQueryable();
        }
        public int GetUserDetails(Guid ID)
        {
            UsersDetails udetails = _ent.UsersDetails.SingleOrDefault(u => u.UserId == ID);
            return udetails.AppUserId;
        }
        public IQueryable<View_AgentDetails> ListAllAgentSuperUser(int AgentId)
        {

            return _ent.View_AgentDetails.Where(uu => uu.AgentId == AgentId).AsQueryable();
        }

        public string GetAddress(int? agentId)
        {
            string Address = _ent.SignUpAgents.Where(x => x.AgentId == agentId).Select(x => x.Address).FirstOrDefault();
            return Address;
        }

        //public IQueryable<Agents> GetAllAgentByPaging(int pageNo, out int currentPageNo, out int numberOfPages, int? flag)
        //{
        //    int pageSize = (int)ATLTravelPortal.Helpers.PageSize.JePageSize;
        //    int rowCount = GetAll().Count();
        //    numberOfPages = (int)Math.Ceiling((decimal)rowCount / (decimal)pageSize);
        //    if (flag != null)//Checking for next/Previous
        //    {
        //        if (flag == 1)
        //            if (pageNo != 1) //represents previous
        //                pageNo -= 1;
        //        if (flag == 2)
        //            if (pageNo != numberOfPages)//represents next
        //                pageNo += 1;

        //    }
        //    currentPageNo = pageNo;
        //    int rowsToSkip = (pageSize * currentPageNo) - pageSize;
        //    IQueryable<Agents> pagingdata = GetAll().OrderBy(t => t.AgentName).Skip(rowsToSkip).Take(pageSize).AsQueryable();

        //    return pagingdata;
        //}

        public IQueryable<Agents> GetAllAgentByPaging()
        {

            IQueryable<Agents> pagingdata = GetAll().OrderBy(t => t.AgentName).AsQueryable();
            return pagingdata;
        }

        public List<AgentTypes> GetAllAgent()
        {
            return _ent.AgentTypes.ToList();
        }

        public string GetEmailID(int? agentId)
        {
            string EmailID = _ent.SignUpAgents.Where(x => x.AgentId == agentId).Select(x => x.Email).FirstOrDefault();
            return EmailID;
        }

        public IEnumerable<SelectListItem> getAllAgentList()
        {
            List<Agents> all = GetAll().ToList();
            var agentList = new List<SelectListItem>();
            foreach (var item in all)
            {
                var teml = new SelectListItem
                {
                    Text = item.AgentName,
                    Value = item.AgentId.ToString()
                };
                agentList.Add(teml);
            }
            return agentList.AsEnumerable();
        }

        public List<AirlineGroups> GetAirlineGroups()
        {
            return _ent.AirlineGroups.ToList();
        }

        public List<SelectListItem> GetAllAirlineGroups()
        {
            List<AirlineGroups> all = GetAirlineGroups().ToList();
            var airlinegroup = new List<SelectListItem>();
            foreach (var item in all)
            {
                var teml = new SelectListItem
                {
                    Text = item.AirlineGroupName,
                    Value = item.AirlineGroupId.ToString()
                };
                airlinegroup.Add(teml);
            }
            return airlinegroup.ToList();
        }
        public aspnet_UsersAgentRelation GetRelationInfo(Guid userid)
        {
            return _ent.aspnet_UsersAgentRelation.SingleOrDefault(u => u.UserId == userid);
        }

        public Countries GetCountryInfo(int CId)
        {
            return _ent.Countries.SingleOrDefault(u => u.CountryId == CId);
        }

        public List<Countries> GetCountry()
        {
            return _ent.Countries.ToList();
        }

        public Agents GetAgentInfo(int ID)
        {
            return _ent.Agents.SingleOrDefault(u => u.AgentId == ID);
        }

        public Core_AgentsDeals GetMasterDeal(int ID, int ProductId)
        {
            return _ent.Core_AgentsDeals.SingleOrDefault(u => u.AgentId == ID && u.ProductId == ProductId);
        }

        public string UpdateAgentCode(int AgentId)
        {
            Agents agcode = _ent.Agents.Where(u => u.AgentId == AgentId).FirstOrDefault();
            agcode.AgentCode = "AH-000" + AgentId;
            _ent.ApplyCurrentValues(agcode.EntityKey.EntitySetName, agcode);
            _ent.SaveChanges();
            return agcode.AgentCode;

        }
        public void UpdateDeal(AgentModel model, int ProductID)
        {
            Core_AgentsDeals tu = _ent.Core_AgentsDeals.Where(u => u.AgentId == model.AgentId && u.ProductId == ProductID).FirstOrDefault();
            if (tu != null)
            {
                tu.MasterDealId = model.MasterDealIdOfAirlines;
                _ent.ApplyCurrentValues(tu.EntityKey.EntitySetName, tu);
                _ent.SaveChanges();
            }

        }

        public void DeleteAgentDeal(int id, int productid)
        {
            if (_ent.Core_AgentsDeals.Where(x => x.AgentId == id && x.ProductId == productid).Count() > 0)
            {
                Core_AgentsDeals datatodelete = _ent.Core_AgentsDeals.First(m => m.AgentId == id && m.ProductId == productid);
                _ent.DeleteObject(datatodelete);
                _ent.SaveChanges();
            }
        }
        public bool CheckIFDealExistForAgent(int AgentID, int productid)
        {
            Core_AgentsDeals deal = _ent.Core_AgentsDeals.Where(u => u.AgentId == AgentID && u.ProductId == productid).FirstOrDefault();
            if (deal != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public ActionResponse SaveAgent(AgentModel modelTosave, out int _AgentId)
        {
            int AgentId = 0;
            if (IsAgentCodeExists(modelTosave.AgentId, modelTosave.AgentCode) == true)
            {
                _res.ErrNumber = 1001;
                _res.ActionMessage = string.Format(Resources.Message.AlreadyExist, "Agent Code");
                _res.ResponseStatus = true;
                goto End;
            }
            else if (IsAgentNameExists(modelTosave.AgentId, modelTosave.AgentName) == true)
            {
                _res.ErrNumber = 1001;
                _res.ActionMessage = string.Format(Resources.Message.AlreadyExist, "Agent Name");
                _res.ResponseStatus = true;
                goto End;
            }

            Agents datamodel = new Agents
           {
               AgentName = modelTosave.AgentName,
               NativeCountry = modelTosave.NativeCountryId,
               ZoneId = modelTosave.ZoneId,
               Address = modelTosave.Address,
               DistrictId = modelTosave.DistrictId,
               Phone = modelTosave.Phone,
               Email = modelTosave.Email,
               FaxNo = modelTosave.FaxNo,
               Web = modelTosave.Web,
               PanNo = modelTosave.PanNo,
               AgentStatus = Convert.ToBoolean(modelTosave.AgentStatusid),
               AgentTypeId = modelTosave.AgentTypeId,
               AgentCode = modelTosave.AgentCode,
               AgentClassId = null,
               AirlineGroupId = modelTosave.AirlineGroupId,
               MaxNumberOfAgentUser = modelTosave.MaxNumberOfAgentUser,
               AgentLogo = modelTosave.AgentLogo,
               CreatedBy = modelTosave.CreatedBy,
               CreatedDate = modelTosave.CreatedDate,
               TimeZoneId = modelTosave.TimeZoneId,
               BranchOfficeId = modelTosave.BranchOfficeId,
               DistributorId = modelTosave.DistributorId,
               ReferredBy = modelTosave.RefferedBy,
               MEsId=modelTosave.MEsId
           };
            _ent.AddToAgents(datamodel);
            _ent.SaveChanges();
            AgentId = datamodel.AgentId;
            _res.ErrNumber = 0;
            //update agentcode here
            string AgentCode = UpdateAgentCode(AgentId);
            _res.ActionMessage = "Agent Successfully Created.  AgentCode " + AgentCode;
            _res.ResponseStatus = true;
            goto End;

        End:
            _AgentId = AgentId;
            return _res;

        }
        /// <summary>
        /// //////
        /// </summary>
        /// <param name="model"></param>
        public void UpdateAgent(AgentModel model)
        {
            Agents tu = _ent.Agents.Where(u => u.AgentId == model.AgentId).FirstOrDefault();

            tu.AgentId = model.AgentId;
            tu.AgentName = model.AgentName;
            tu.NativeCountry = model.NativeCountryId;
            tu.ZoneId = model.ZoneId;
            tu.DistrictId = model.DistrictId;
            tu.ReferredBy = model.RefferedBy;
            tu.MEsId = model.MEsId;
            //if (model.AgentClassId == 0)
            //    tu.AgentClassId = null;
            //else
            //    tu.AgentClassId = model.AgentClassId;

            tu.AgentTypeId = model.AgentTypeId;
            tu.AgentCode = model.AgentCode;
            tu.Address = model.Address;
            tu.Phone = model.Phone;
            tu.Email = model.Email;
            tu.FaxNo = model.FaxNo;
            tu.PanNo = model.PanNo;
            tu.Web = model.Web;

            tu.TimeZoneId = model.TimeZoneId;

            tu.AgentStatus = Convert.ToBoolean(model.AgentStatusid);
            tu.AirlineGroupId = model.AirlineGroupId;
            tu.MaxNumberOfAgentUser = model.MaxNumberOfAgentUser;
            tu.UpdatedDate = model.UpdatedDate;
            tu.UpdatedBy = model.UpdatedBy;
            _ent.ApplyCurrentValues(tu.EntityKey.EntitySetName, tu);
            _ent.SaveChanges();

            GL_Ledgers led = _ent.GL_Ledgers.Where(x => x.Id == model.AgentId && x.AccTypeId == 2).FirstOrDefault();
            if (led != null)
            {
                led.LedgerName = "A/C " + model.AgentName;
                _ent.ApplyCurrentValues(led.EntityKey.EntitySetName, led);
                _ent.SaveChanges();
            }
        }
        public List<string> GetBankInfo(int agentid)
        {
            var result = _ent.AgentBanks.Where(u => u.AgentId == agentid).ToList();
            List<string> bankname = new List<string>();
            foreach (var item in result)
            {
                bankname.Add(item.Banks.BankName);
            }
            return bankname;
        }

        public AgentBankModel GetAgentBankInfo(int AgentBankId)
        {

            var result = _ent.AgentBanks.SingleOrDefault(u => u.AgentBankId == AgentBankId);
            AgentBankModel model = new AgentBankModel
            {
                AgentBankId = result.AgentBankId,
                AgentId = result.AgentId,
                BankId = result.BankId,
                BankName = result.Banks.BankName,
                BankBranchId = result.BankBranchId,
                BankBranchName = result.BankBranches.BranchName,
                BankAccountTypeId = result.BankBranchId,
                BankAccountTypeName = result.BankAccountTypes.AccountTypeName,
                AccountName = result.AccountName,
                AccountNumber = result.AccountNumber,

                BankType = result.BankType

            };
            return model;

        }
        public int SaveAgentBankInfo(AgentBankModel modelTosave, int agentid)
        {
            AgentBanks datamodel = new AgentBanks
            {
                AgentId = agentid,
                BankId = modelTosave.BankId,
                BankBranchId = modelTosave.BankBranchId,
                BankAccountTypeId = modelTosave.BankAccountTypeId,
                AccountName = modelTosave.AccountName,
                AccountNumber = modelTosave.AccountNumber,
                isDefault = false,

                BankType = modelTosave.BankType

            };
            _ent.AddToAgentBanks(datamodel);
            _ent.SaveChanges();
            int lastid = GetLastAgentBankId().ToList().Last().AgentBankId;
            return lastid;

        }



        public void SaveAgentDeal(AgentModel modelTosave, int agentid, int ProductId)
        {
            Core_AgentsDeals datamodel = new Core_AgentsDeals();
            //{
            //    AgentId = agentid,
            //    ProductId = ProductId,
            //    MasterDealId = modelTosave.MasterDealIdOfAirlines,
            //    CreatedBy = modelTosave.CreatedBy,
            //    CreatedDate = modelTosave.CreatedDate,
            //};

            datamodel.AgentId = agentid;
            datamodel.ProductId = ProductId;
            if (ProductId == 1)
                datamodel.MasterDealId = modelTosave.MasterDealIdOfAirlines;
            else if (ProductId == 2)
                datamodel.MasterDealId = modelTosave.MasterDealIdOfHotel;

            datamodel.CreatedBy = modelTosave.CreatedBy;
            datamodel.CreatedDate = modelTosave.CreatedDate;


            _ent.AddToCore_AgentsDeals(datamodel);
            _ent.SaveChanges();

        }

        public void SaveAgentGeneralLedger(int agentid, int ProductId, int CreatedBy)
        {
            var agentdetails = GetAgentInfo(agentid);
            GL_Ledgers datamodel = new GL_Ledgers
            {
                Id = agentid,
                ProductId = ProductId,
                AccGroupId = 1,
                AccSubGroupId = 1,
                AccTypeId = 2,
                LedgerName = "A/C  " + agentdetails.AgentName,
                CreatedBy = CreatedBy,
                CreatedDate = DateTime.Now,

            };
            _ent.AddToGL_Ledgers(datamodel);
            _ent.SaveChanges();

        }
        public void SaveAgentCoreConfiguration(int agentid, string EmaildId)
        {
            Core_AgentConfiguration datamodel = new Core_AgentConfiguration
            {
                AgentId = agentid,
                ShowFareOnETicket = true,
                ShowAllFare = true,
                HideAllFare = false,
                ShowOnlyPublishedFares = false,
                EmailEveryTimeBookingIsMade = false,
                EmailEveryTimePNRIsReleased = false,
                SendEmailTo = EmaildId != null ? EmaildId : "",
                ServiceChargeIncludeInTax = true,
                ShowasServiceCharge = false,
                isPercentDomesticServiceCharge = true,
                DomesticServiceChargeValue = 0,
                isPercentInternationalServiceCharge = true,
                InternationalServiceChargeValue = 0,

            };
            _ent.AddToCore_AgentConfiguration(datamodel);
            _ent.SaveChanges();

        }

        public IQueryable<AgentBanks> GetLastAgentBankId()
        {
            return _ent.AgentBanks.AsQueryable();
        }
        public void DeleteAgentBankInfo(int id)
        {
            AgentBanks datatodelete = _ent.AgentBanks.First(m => m.AgentBankId == id);
            // AgentBanks datatodelete = new AgentBanks();
            // datatodelete.AgentBankId = modeldata.AgentBankId
            _ent.DeleteObject(datatodelete);
            _ent.SaveChanges();
        }



        /// <summary>
        /// ///////
        /// </summary>
        /// <param name="model"></param>
        public void UpdateAgentBankInfo(AgentBankModel model)
        {
            AgentBanks ab = _ent.AgentBanks.Where(u => u.AgentBankId == model.AgentBankId).FirstOrDefault();
            ab.AgentBankId = model.AgentBankId;
            ab.BankId = model.BankId;
            ab.BankBranchId = model.BankBranchId;
            ab.BankAccountTypeId = model.BankAccountTypeId;
            ab.AccountName = model.AccountName;
            ab.AccountNumber = model.AccountNumber;

            ab.BankType = model.BankType;

            _ent.ApplyCurrentValues(ab.EntityKey.EntitySetName, ab);
            _ent.SaveChanges();

        }
        /// <summary>
        /// /
        /// </summary>
        /// <param name="AgentIPId"></param>
        /// <returns></returns>
        public AgentIPManagementModel GetAgentIPInfo(int AgentIPId)
        {

            var result = _ent.IPControlLists.SingleOrDefault(u => u.IPId == AgentIPId);
            AgentIPManagementModel model = new AgentIPManagementModel
            {
                AgentIPId = result.IPId,
                AgentId = result.AgentId,
                IPAddress = result.IPAddress,
                IsActive = result.isActive,
                IsAutoExpire = result.isAutoExpire,
                ActiveDate = Convert.ToDateTime(result.ActiveToDate),
                ExpiryDateTime = Convert.ToDateTime(result.ActiveFromDate),
            };
            return model;

        }

        public List<string> GetIPInfo(int agentid)
        {
            var result = _ent.IPControlLists.Where(u => u.AgentId == agentid).ToList();
            List<string> IPAddress = new List<string>();
            foreach (var item in result)
            {
                IPAddress.Add(item.IPAddress);
            }
            return IPAddress;
        }


        /// <summary>
        /// //
        /// </summary>
        /// <param name="modelTosave"></param>
        /// <param name="createdby"></param>
        /// <returns></returns>
        public int SaveAgentIPInfo(AgentIPManagementModel modelTosave, int createdby)
        {
            IPControlLists datamodel = new IPControlLists
            {
                AgentId = modelTosave.AgentId,
                IPAddress = modelTosave.IPAddress,
                isActive = modelTosave.IsActive,
                isAutoExpire = modelTosave.IsAutoExpire,
                ActiveFromDate = modelTosave.ActiveDate,
                ActiveToDate = modelTosave.ExpiryDateTime,
                CreatedBy = createdby,
                CreatedDate = DateTime.Now,

            };
            _ent.AddToIPControlLists(datamodel);
            _ent.SaveChanges();
            int lastSaveid = GetLastSaveAgentIPId().ToList().Last().IPId;
            return lastSaveid;

        }
        public IQueryable<IPControlLists> GetLastSaveAgentIPId()
        {
            return _ent.IPControlLists.AsQueryable();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        public void DeleteAgentIPInfo(int id)
        {
            IPControlLists datatodelete = _ent.IPControlLists.First(m => m.IPId == id);
            _ent.DeleteObject(datatodelete);
            _ent.SaveChanges();
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////
        public List<RoleBasedRoleModel> GetProductList()
        {
            var cc = (from aa in _ent.Core_Products.Where(tt => tt.isActive == true && (tt.ProductName != "Back Office"))

                      select new RoleBasedRoleModel
                      {
                          ProductId = aa.ProductId,
                          ProductName = aa.ProductName,

                      }).ToList();
            return cc;
        }
        ///////////////////////////////////////////////////////////////////////////////////////////////
        //public AgentBanks 
        public List<DefaultMarkupLevels> GetDefaultMarkUpLevel()
        {
            return _ent.DefaultMarkupLevels.ToList();
        }

        public List<AirlineGroups> GetAirlineGroup()
        {
            return _ent.AirlineGroups.ToList();
        }
        public List<AgentClasses> GetAgentClass()
        {
            return _ent.AgentClasses.ToList();
        }
        public List<AgentTypes> GetAgentType()
        {
            return _ent.AgentTypes.ToList();
        }
        public List<Zones> GetZoneList()
        {
            return _ent.Zones.ToList();
        }
        public List<Districts> GetDistrictList()
        {
            return _ent.Districts.ToList();
        }
        public List<BankAccountTypes> GetbankAccountType()
        {
            return _ent.BankAccountTypes.ToList();
        }
        public List<BankBranches> GetbankBranchInformation()
        {
            return _ent.BankBranches.ToList();
        }
        public List<Banks> GetbankInformation()
        {
            return _ent.Banks.ToList();
        }
        ////////// Begin of saving Agent Product here //////////////////////
        public void SaveAgentProduct(List<Core_AgentProducts> abinfo)
        {
            TravelPortalEntity.EntityModel ent = new TravelPortalEntity.EntityModel();
            foreach (var item in abinfo)
            {
                ent.Core_AgentProducts.AddObject(new Core_AgentProducts()
                {

                    AgentId = item.AgentId,
                    ProductId = item.ProductId,
                });
            }
            ent.SaveChanges();

        }
        public void SaveUserProduct(List<Core_UserProducts> abinfo)
        {
            TravelPortalEntity.EntityModel ent = new TravelPortalEntity.EntityModel();
            foreach (var item in abinfo)
            {
                ent.Core_UserProducts.AddObject(new Core_UserProducts()
                {
                    UserId = item.UserId,
                    ProductId = item.ProductId,
                });
            }
            ent.SaveChanges();
        }

        /// <summary>
        /// /Saving Agent Bank in List /////
        /// </summary>
        /// <param name="abinfo"></param>
        public void SaveAgentBankInformation(List<AgentBanks> abinfo)
        {
            TravelPortalEntity.EntityModel ent = new TravelPortalEntity.EntityModel();
            foreach (var item in abinfo)
            {
                ent.AgentBanks.AddObject(new AgentBanks()
                {

                    AgentId = item.AgentId,
                    BankId = item.BankId,
                    BankBranchId = item.BankBranchId,
                    BankAccountTypeId = item.BankAccountTypeId,
                    AccountName = item.AccountName,
                    AccountNumber = item.AccountNumber,

                    ///////////new added //////////////////////
                    BankType = item.BankType,
                    ////////////////////////////////////////////

                    isDefault = item.isDefault,

                });
            }
            ent.SaveChanges();

        }


        public List<string> GetAllSettingList(int agentid)
        {
            var result = _ent.AgentSettings.Where(u => u.AgentId == agentid).ToList();
            List<string> SettingName = new List<string>();
            foreach (var item in result)
            {
                SettingName.Add(item.Settings.SettingName);
            }
            return SettingName;
        }

        public void DeleteAgentProduct(int agentid)
        {
            TravelPortalEntity.EntityModel ent = new TravelPortalEntity.EntityModel();
            try
            {
                ent.DeleteAgentProduct(agentid);
                ent.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void DeleteAgentSetting(int agentid)
        {
            TravelPortalEntity.EntityModel ent = new TravelPortalEntity.EntityModel();
            try
            {
                ent.DeleteAgentSetting(agentid);
                ent.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// ///////////////////////  Agent Setting information begin from here /////////////
        /// </summary>
        public List<AgentSettingsModel> GetAllActiveSettingForAgent(int agentid)
        {
            TravelPortalEntity.EntityModel ent = new TravelPortalEntity.EntityModel();
            var cc = (from aa in ent.Settings
                      join bb in ent.AgentSettings
                      on aa.SettingId equals bb.SettingId
                      where bb.AgentId == agentid
                      select new AgentSettingsModel
                      {
                          SettingName = aa.SettingName,
                          SettingId = aa.SettingId,
                      }).ToList();
            return cc;
        }
        /// <summary>
        /// //////////////////
        /// </summary>
        /// <returns></returns>
        public List<AgentSettingsModel> GetAllSettingList()
        {
            TravelPortalEntity.EntityModel ent = new TravelPortalEntity.EntityModel();
            var cc = (from aa in ent.Settings.Where(ii => ii.isActive == true)
                      select new AgentSettingsModel
                      {
                          SettingName = aa.SettingName,
                          SettingId = aa.SettingId,
                      }).ToList();
            return cc;
        }
        ////////////////////////////  Associated Agent Product List  ////////////////////////////////////////////////////
        public List<AgentProductViewModel> GetAllAssociatedProductofAgent(int agentid)
        {
            TravelPortalEntity.EntityModel ent = new TravelPortalEntity.EntityModel();
            var cc = (from aa in ent.Core_Products
                      join bb in ent.Core_AgentProducts
                      on aa.ProductId equals bb.ProductId
                      where bb.AgentId == agentid
                      select new AgentProductViewModel
                      {
                          ProductName = aa.ProductName,
                          ProductId = aa.ProductId,
                      }).ToList();
            return cc;
        }

        public List<Core_Products> ProductList()
        {
            return _ent.Core_Products.Where(pp => (pp.isActive == true) && (pp.ProductName != "Back Office")).ToList();
        }
        ///////////////////// End of agent Product here////////////////////////////////////
        /// ///////////////
        ////////////////////////
        //////////////////////
        public IEnumerable<Districts> GetDistrictListbyZoneId(int? id)
        {
            TravelPortalEntity.EntityModel ent = new TravelPortalEntity.EntityModel();
            return ent.Districts.Where(dd => dd.ZoneId == id).ToList().Select(x =>
            new Districts { DistrictId = x.DistrictId, DistrictName = x.DistrictName }
            );
        }
        public IEnumerable<BankBranches> GetBranchListbyBankId(int id)
        {
            TravelPortalEntity.EntityModel ent = new TravelPortalEntity.EntityModel();
            return ent.BankBranches.Where(dd => dd.BankId == id).ToList().Select(x =>
            new BankBranches { BankBranchId = x.BankBranchId, BranchName = x.BranchName }
            );
        }


        public List<UsersDetails> GetSalesAgentList()
        {
            return _ent.UsersDetails.Where(x => (x.UserTypeId == 4 && x.aspnet_Users.aspnet_Membership.IsLockedOut == false)).ToList();
        }

        public IEnumerable<SelectListItem> GetAllGetSalesAgentList()
        {
            List<UsersDetails> all = GetSalesAgentList().ToList();
            var GetAllGetSalesAgentListList = new List<SelectListItem>();
            foreach (var item in all)
            {
                var teml = new SelectListItem
                {
                    Text = item.FullName,
                    Value = item.AppUserId.ToString()
                };
                GetAllGetSalesAgentListList.Add(teml);
            }
            return GetAllGetSalesAgentListList.OrderBy(x => x.Text).AsEnumerable();
        }



        public bool CheckDuplicateUsername(string userName)
        {
            aspnet_Users tu = _ent.aspnet_Users.Where(ii => ii.UserName == userName).FirstOrDefault();
            if (tu != null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public bool CheckDuplicateAgentname(string AgentName)
        {
            Agents agent = _ent.Agents.Where(ii => ii.AgentName == AgentName).FirstOrDefault();
            if (agent != null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public bool CheckDuplicateAgentCode(string AgentCode)
        {
            Agents agent = _ent.Agents.Where(ii => ii.AgentCode == AgentCode).FirstOrDefault();
            if (agent != null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public void DeleteAgent(Agents table)
        {
            Agents datatodelete = _ent.Agents.First(m => m.AgentId == table.AgentId);
            _ent.DeleteObject(datatodelete);
            _ent.SaveChanges();
        }

        public List<RoleBasedRoleModel> GetAllRolesListonProductWise(int ProductId)
        {
            TravelPortalEntity.EntityModel ent = new TravelPortalEntity.EntityModel();
            var cc = (from aa in ent.aspnet_Roles
                      join bb in ent.Core_ProductRoles
                      on aa.RoleId equals bb.RoleId
                      where bb.ProductId == ProductId && bb.Core_SubProduct.SubProductName == "Agent"
                      select new RoleBasedRoleModel
                      {
                          RoleId = aa.RoleId,
                          RoleName = aa.RoleName,
                          ProductId = bb.ProductId,
                      }).ToList();
            return cc;

        }
        public List<RoleBasedRoleModel> GetAllRolesBasedonProduct(int ProductId)
        {
            TravelPortalEntity.EntityModel ent = new TravelPortalEntity.EntityModel();
            var cc = (from aa in ent.aspnet_Roles
                      join bb in ent.Core_ProductRoles
                      on aa.RoleId equals bb.RoleId
                      where bb.ProductId == ProductId
                      select new RoleBasedRoleModel
                      {
                          RoleId = aa.RoleId,
                          RoleName = aa.RoleName,
                      }).ToList();
            return cc;

        }
        public void SaveAirlineRight(AgentAirlineMappings minfo)
        {
            _ent.AddToAgentAirlineMappings(minfo);
            _ent.SaveChanges();
        }
        public void SaveUpdatedAirlineRight(List<AgentAirlineMappings> mapinfo)
        {
            TravelPortalEntity.EntityModel ent = new TravelPortalEntity.EntityModel();
            foreach (var item in mapinfo)
            {
                //item.MappingId = ent.AgentAirlineMappings.Where(u => u.AirlineId == item.AirlineId).FirstOrDefault();
                //ent.AgentAirlineMappings.AddObject(new AgentAirlineMappings()
                //{
                //    AgentId = item.AgentId,
                //    AirlineId = item.AirlineId,
                //    CanView = item.CanView,
                //    CanSell = item.CanSell

                //});
                //ent.ApplyCurrentValues(item.EntityKey.EntitySetName, mapinfo);
                //ent.AgentAirlineMappings.ApplyCurrentValues(item);
                AgentAirlineMappings amap = _ent.AgentAirlineMappings.Where(u => (u.AirlineId == item.AirlineId) && (u.AgentId == item.AgentId)).FirstOrDefault();
                amap.MappingId = item.MappingId;
                _ent.ApplyCurrentValues(amap.EntityKey.EntitySetName, item);
                _ent.SaveChanges();
            }

        }

        public void DeleteAgentRightForAirline(AgentAirlineMappings model)
        {
            AgentAirlineMappings datatodelete = _ent.AgentAirlineMappings.FirstOrDefault(m => m.MappingId == model.MappingId);
            _ent.DeleteObject(datatodelete);
            _ent.SaveChanges();
        }

        public bool CheckDuplicateAirline(int AirlineId, int agentid)
        {
            AgentAirlineMappings ainfo = _ent.AgentAirlineMappings.Where(ii => (ii.AirlineId == AirlineId) && (ii.AgentId == agentid)).FirstOrDefault();
            if (ainfo != null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// /////////   GetAllDeal list
        /// </summary>
        /// <returns></returns>
        /// 
        public string GetAgentDeal(int agentid)
        {
            var result = _ent.Core_AgentsDeals.SingleOrDefault(u => u.AgentId == agentid);

            return result.Tkt_DealMasters.DealName;
        }

        public IEnumerable<SelectListItem> GetAllDealListOfAirlines()
        {
            List<Tkt_DealMasters> all = MasterDealListOfAirlines().ToList();
            var GetAllDealList = new List<SelectListItem>();
            foreach (var item in all)
            {
                var teml = new SelectListItem
                {
                    Text = item.DealName,
                    Value = item.DealMasterId.ToString()
                };
                GetAllDealList.Add(teml);
            }
            return GetAllDealList.AsEnumerable();
        }

        private IQueryable<Tkt_DealMasters> MasterDealListOfAirlines()
        {
            return _ent.Tkt_DealMasters.OrderBy(xx => xx.DealMasterId).Where(x => x.DealTypeId == 2 && x.ProductId == 1).AsQueryable();
        }

        public IEnumerable<SelectListItem> GetAllDealListOfHotel()
        {
            List<Tkt_DealMasters> all = MasterDealListOfHotel().ToList();
            var GetAllDealList = new List<SelectListItem>();
            foreach (var item in all)
            {
                var teml = new SelectListItem
                {
                    Text = item.DealName,
                    Value = item.DealMasterId.ToString()
                };
                GetAllDealList.Add(teml);
            }
            return GetAllDealList.AsEnumerable();
        }

        private IQueryable<Tkt_DealMasters> MasterDealListOfHotel()
        {
            return _ent.Tkt_DealMasters.OrderBy(xx => xx.DealMasterId).Where(x => x.DealTypeId == 2 && x.ProductId == 2).AsQueryable();
        }

        /// <summary>
        /// //////
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        /// <param name="dbContext"></param>
        #endregion
        public void AddUserProduct(List<int> Productidlist, int userid)
        {
            try
            {
                int count = Productidlist.Count;
                List<Core_UserProducts> Lists = new List<Core_UserProducts>();
                for (int i = 0; i < count; i++)
                {

                    Core_UserProducts Productlist = new Core_UserProducts();
                    Productlist.UserId = userid;
                    Productlist.ProductId = Productidlist[i];
                    Lists.Add(Productlist);

                }
                SaveUserProduct(Lists);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void AddAgentProduct(List<int> Productidlist, int agentid)
        {
            try
            {
                int count = Productidlist.Count;
                List<Core_AgentProducts> Lists = new List<Core_AgentProducts>();
                for (int i = 0; i < count; i++)
                {

                    Core_AgentProducts Productlist = new Core_AgentProducts();
                    Productlist.AgentId = agentid;

                    Productlist.ProductId = Productidlist[i];
                    Lists.Add(Productlist);

                }
                SaveAgentProduct(Lists);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void SaveAgentBankInfo(List<AgentBankModel> uInfo, int AgentId)
        {
            try
            {
                int count = uInfo.Count;
                List<AgentBanks> agLists = new List<AgentBanks>();
                for (int i = 0; i < count; i++)
                {
                    AgentBanks bankinfo = new AgentBanks();
                    bankinfo.BankId = uInfo[i].BankId;
                    bankinfo.BankBranchId = uInfo[i].BankBranchId;
                    bankinfo.AccountNumber = uInfo[i].AccountNumber;
                    bankinfo.AccountName = uInfo[i].AccountName;
                    bankinfo.BankAccountTypeId = uInfo[i].BankAccountTypeId;
                    bankinfo.AgentId = AgentId;
                    bankinfo.isDefault = uInfo[i].IsDefault;
                    ///////////new added /////////////////
                    bankinfo.BankType = uInfo[i].BankType;
                    /////////////////////////////////////
                    agLists.Add(bankinfo);
                }
                SaveAgentBankInformation(agLists);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void GenericUpdateEntityCollection<T>(EntityCollection<T> collection, ObjectContext dbContext) where T : EntityObject, new()
        {
            int count = collection.Count();
            int current = 0;
            List<T> collectionItemList = collection.ToList();
            bool isAdded = false;
            while (current < count)
            {
                Object obj = null;
                dbContext.TryGetObjectByKey(collectionItemList[current].EntityKey, out obj);
                if (obj == null)
                {
                    obj = new AgentAirlineMappings();
                    ((T)obj).EntityKey = collectionItemList[current].EntityKey;
                    dbContext.AddObject(((T)obj).EntityKey.EntitySetName, obj);
                    dbContext.TryGetObjectByKey(collectionItemList[current].EntityKey, out obj);
                    dbContext.ObjectStateManager.ChangeObjectState(obj, System.Data.EntityState.Modified);
                    collection.CreateSourceQuery().Context.ObjectStateManager.ChangeObjectState(collectionItemList[current], System.Data.EntityState.Modified);
                    isAdded = true;
                }
                if (obj != null)
                {
                    dbContext.ApplyCurrentValues<T>(((T)obj).EntityKey.EntitySetName, collectionItemList[current]);
                    if (isAdded)
                    {
                        dbContext.ObjectStateManager.ChangeObjectState(obj, System.Data.EntityState.Added);
                        collection.CreateSourceQuery().Context.ObjectStateManager.ChangeObjectState(collectionItemList[current], System.Data.EntityState.Added);
                    }
                }
                current++;
            }
        }

        private UsersDetails GetDefaultUserDetailsByAgentId(Int64 agentId)
        {
            aspnet_UsersAgentRelation UsersAgentRelation = _ent.aspnet_UsersAgentRelation.Where(x => x.AgentId == agentId).FirstOrDefault();
            if (UsersAgentRelation != null)
            {
                return _ent.UsersDetails.Where(x => x.UserId == UsersAgentRelation.UserId).FirstOrDefault();
            }
            return null;
        }

        public ActionResponse Delete(int? id)
        {
            if (id == null)
            {
                _res.ActionMessage = String.Format(Resources.Message.InvalidOperation, "Agent");
                _res.ErrNumber = 1005;
                _res.ErrSource = "DataBase";
                _res.ErrType = "App";
                _res.ResponseStatus = true;
                goto End;
            }
            var obj = _ent.Agents.Where(x => x.AgentId == id).FirstOrDefault();
            if (obj == null)
            {
                _res.ActionMessage = String.Format(Resources.Message.InvalidOperation, "Agent");
                _res.ErrNumber = 1005;
                _res.ErrSource = "DataBase";
                _res.ErrType = "App";
                _res.ResponseStatus = true;
                goto End;
            }
            _ent.Core_DeleteAgent(id);
            _res.ActionMessage = String.Format(Resources.Message.SuccessfullyDeleted, "Agent");
            _res.ErrNumber = 0;
            _res.ErrSource = "DataBase";
            _res.ErrType = "App";
            _res.ResponseStatus = true;
            goto End;
        End:
            return _res;
        }
        public List<ATLTravelPortal.Areas.Administrator.Models.Status> GetStatus()
        {
            List<ATLTravelPortal.Areas.Administrator.Models.Status> nn = new List<ATLTravelPortal.Areas.Administrator.Models.Status>();

            ATLTravelPortal.Areas.Administrator.Models.Status n1 = new ATLTravelPortal.Areas.Administrator.Models.Status();
            ATLTravelPortal.Areas.Administrator.Models.Status n2 = new ATLTravelPortal.Areas.Administrator.Models.Status();

            n1.id = 0;
            n1.Name = "Deactive";

            n2.id = 1;
            n2.Name = "Active";

            nn.Add(n1);
            nn.Add(n2);

            return nn;
        }


        //       SELECT *
        //FROM Agents
        //WHERE AgentName LIKE '%' +'Test' + '%'
        // where p.Tags.All(tag => filterTags.Contains(tag))


        public List<Agents> GetAgentSearchResult(string AgentName)
        {

            var result = _ent.Agents.Where(x => (x.AgentName.Contains(AgentName)) || (x.AgentCode.Contains(AgentName)));

            return result.ToList();

        }

        //        select * from Agents
        //select * from aspnet_UsersAgentRelation where AgentId=1
        //select MobileNumber from UsersDetails where UserId='1D97A22E-36EE-401D-9715-174C51A0B34C'
        public string AgentMobileNumber(int Agentid)
        {
            var UserId = _ent.aspnet_UsersAgentRelation.Where(x => x.AgentId == Agentid).Select(x => x.UserId).FirstOrDefault();
            string mobilenumber = _ent.UsersDetails.Where(x => x.UserId == UserId).Select(x => x.MobileNumber).FirstOrDefault();
            return mobilenumber;
        }

        public IEnumerable<AgentModel> FindAgentByNameOrCode(string name)
        {
            return _ent.Agents.Where(x => (x.AgentName.ToLower().Contains(name.ToUpper()) || x.AgentCode.ToLower().Contains(name.ToUpper()))).Take(10).ToList().Select(x =>
                                  new AgentModel { AgentName = x.AgentName, AgentCode = x.AgentCode, AgentId = x.AgentId }
                                  );
        }

        public IEnumerable<AgentModel> FindAgentByNameOrCodeByDistributorId(string name, int distributorId)
        {
            return _ent.Agents.Where(x => (x.AgentName.ToLower().Contains(name.ToUpper()) || x.AgentCode.ToLower().Contains(name.ToUpper())) && x.DistributorId == distributorId).Take(10).ToList().Select(x =>
                                  new AgentModel { AgentName = x.AgentName, AgentCode = x.AgentCode, AgentId = x.AgentId }
                                  );
        }
        public bool CheckDuplicateEmail(string email)
        {
            Agents agent = _ent.Agents.Where(ii => ii.Email == email).FirstOrDefault();
            if (agent != null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool CheckEditDuplicateEmail(string email, int agentId)
        {
            Agents agent = _ent.Agents.Where(ii => ii.Email == email && ii.AgentId != agentId).FirstOrDefault();
            if (agent == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool CheckDuplicateMobileNumber(string MobileNumber)
        {
            UsersDetails usersDetails = _ent.UsersDetails.Where(ii => ii.MobileNumber == MobileNumber).FirstOrDefault();
            if (usersDetails != null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

       // _rep.GetAgentSearchResult(model.AgentSearch.TrimStart(' ').TrimEnd(' ')).Where(x=>x.DistributorId==obj.AgentId);
        public List<Agents> GetAgentSearchResultbydistributorid(string AgentName, int distributorid)
        {

            var result = _ent.Agents.Where(x => (x.AgentName.Contains(AgentName)) || (x.AgentCode.Contains(AgentName)));

            return result.Where(x=>x.DistributorId==distributorid).ToList();

        }


        public bool CheckEditDuplicateMobileNumber(string MobileNumber, int agentId)
        {
            aspnet_UsersAgentRelation aspnet_UsersAgentRelation = _ent.aspnet_UsersAgentRelation.Where(ii => ii.AgentId == agentId).FirstOrDefault();
            if (aspnet_UsersAgentRelation != null)
            {
                UsersDetails usersDetails = _ent.UsersDetails.Where(ii => ii.MobileNumber == MobileNumber && ii.UserId != aspnet_UsersAgentRelation.UserId).FirstOrDefault();

                if (usersDetails != null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            return false;
        }
    }
}

