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
using TravelPortalEntity;
using System.Web.Mvc;
using ATLTravelPortal.Helpers;
using ATLTravelPortal.Areas.Airline.Models;
using AirLines.Provider.Admin;

namespace ATLTravelPortal.Areas.Airline.Repository
{
    public class AgentManagement
    {
        /// <summary>
        /// ////////Listing Agent management by Admin
        /// </summary>

        #region Agent Management Service

        EntityModel db = new EntityModel();

        CountryProvider _countryPro=new CountryProvider();
       
        public IQueryable<Agents> GetAll()
        {
            return db.Agents/*.Include("tbl_AgentType")*/.OrderByDescending(xx => xx.AgentId).AsQueryable();
        }
        public IQueryable<Agents> GetLastId()
        {
            return db.Agents.AsQueryable();
        }
        public IQueryable<View_AgentDetails> ListAllAgentSuperUser(int AgentId)
        {

            return db.View_AgentDetails.Where(uu => uu.AgentId == AgentId).AsQueryable();
        }
        public IQueryable<Agents> GetAllAgentByPaging(int pageNo, out int currentPageNo, out int numberOfPages, int? flag)
        {
            int pageSize = (int)PageSize.JePageSize;
            int rowCount = GetAll().Count();
            numberOfPages = (int)Math.Ceiling((decimal)rowCount / (decimal)pageSize);
            if (flag != null)//Checking for next/Previous
            {
                if (flag == 1)
                    if (pageNo != 1) //represents previous
                        pageNo -= 1;
                if (flag == 2)
                    if (pageNo != numberOfPages)//represents next
                        pageNo += 1;

            }
            currentPageNo = pageNo;
            int rowsToSkip = (pageSize * currentPageNo) - pageSize;
            IQueryable<Agents> pagingdata = GetAll().OrderByDescending(t => t.AgentId).Skip(rowsToSkip).Take(pageSize).AsQueryable();
            return pagingdata;
        }

        public List<AgentTypes> GetAllAgent()
        {
            return db.AgentTypes.ToList();
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

        public aspnet_UsersAgentRelation GetRelationInfo(Guid userid)
        {
            return db.aspnet_UsersAgentRelation.SingleOrDefault(u => u.UserId == userid);
        }

        public Countries GetCountryInfo(int CId)
        {
            return db.Countries.SingleOrDefault(u => u.CountryId == CId);
        }
        
        public List<Countries> GetCountry()
        {
            return db.Countries.ToList();
        }

        public Agents GetAgentInfo(int ID)
        {
            return db.Agents.SingleOrDefault(u => u.AgentId == ID);
        }

       
        public void SaveAgent(AgentModel modelTosave)
        {
             Agents datamodel = new Agents
            {
            AgentName = modelTosave.AgentName,
            NativeCountry=modelTosave.NativeCountryId,
            ZoneId=modelTosave.ZoneId,
            Address=modelTosave.Address,
            DistrictId=modelTosave.DistrictId,
            Phone=modelTosave.Phone,
            Email=modelTosave.Email,
            FaxNo = modelTosave.FaxNo,
            Web = modelTosave.Web,
            PanNo = modelTosave.PanNo,
            AgentStatus =Convert.ToBoolean( modelTosave.AgentStatusid),
            isApplyMarkup = modelTosave.isApplyMarkup,
            TotalMarkup = modelTosave.TotalMarkup,
            AgentTypeId = modelTosave.AgentTypeId,
            AgentCode = modelTosave.AgentCode,
            AgentClassId = modelTosave.AgentClassId,
            AirlineGroupId = modelTosave.AirlineGroupId,
            MaxNumberOfAgentUser = modelTosave.MaxNumberOfAgentUser,
            AgentLogo = modelTosave.AgentLogo,
            CreatedBy = modelTosave.CreatedBy,
            CreatedDate = modelTosave.CreatedDate
            };
            db.AddToAgents(datamodel);
            db.SaveChanges();
            
        }
        /// <summary>
        /// //////
        /// </summary>
        /// <param name="model"></param>
        public void UpdateAgent(AgentModel model)
        {
            Agents tu = db.Agents.Where(u => u.AgentId == model.AgentId).FirstOrDefault();

            tu.AgentId = model.AgentId;
            tu.AgentName = model.AgentName;
            tu.NativeCountry = model.NativeCountryId;
            tu.ZoneId = model.ZoneId;
            tu.DistrictId = model.DistrictId;
            tu.AgentClassId = model.AgentClassId;
            tu.AgentTypeId = model.AgentTypeId;
            tu.AgentCode = model.AgentCode;
            tu.Address = model.Address;
            tu.Phone = model.Phone;
            tu.Email = model.Email;
            tu.FaxNo = model.FaxNo;
            tu.PanNo = model.PanNo;
            tu.Web = model.Web;
            tu.AgentStatus = Convert.ToBoolean(model.AgentStatusid);
            tu.isApplyMarkup = model.isApplyMarkup;
            tu.TotalMarkup = model.TotalMarkup;
            tu.AirlineGroupId = model.AirlineGroupId;
            tu.MaxNumberOfAgentUser = model.MaxNumberOfAgentUser;
            tu.UpdatedDate = model.UpdatedDate;
            tu.UpdatedBy = model.UpdatedBy;

            db.ApplyCurrentValues(tu.EntityKey.EntitySetName, tu);
            db.SaveChanges();

        }
        public AgentBankModel GetAgentBankInfo(int AgentBankId)
        {

            var result = db.AgentBanks.SingleOrDefault(u => u.AgentBankId == AgentBankId);
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
                AccountNumber = result.AccountNumber
            };
            return model;

        }
        public int SaveAgentBankInfo(AgentBankModel modelTosave,int agentid)
        {
            AgentBanks datamodel = new AgentBanks
            {
                AgentId = agentid,
                BankId = modelTosave.BankId,
                BankBranchId = modelTosave.BankBranchId,
                BankAccountTypeId = modelTosave.BankAccountTypeId,
                AccountName = modelTosave.AccountName,
                AccountNumber = modelTosave.AccountNumber,
                isDefault =false,
             
            };
            db.AddToAgentBanks(datamodel);
            db.SaveChanges();
            int lastid = GetLastAgentBankId().ToList().Last().AgentBankId;
            return lastid;

        }
        public IQueryable<AgentBanks> GetLastAgentBankId()
        {
            return db.AgentBanks.AsQueryable();
        }
        public void DeleteAgentBankInfo(int id)
        {
            AgentBanks datatodelete = db.AgentBanks.First(m => m.AgentBankId == id);
            // AgentBanks datatodelete = new AgentBanks();
            // datatodelete.AgentBankId = modeldata.AgentBankId
            db.DeleteObject(datatodelete);
            db.SaveChanges();
        }
        /// <summary>
        /// ///////
        /// </summary>
        /// <param name="model"></param>
         public void UpdateAgentBankInfo(AgentBankModel model)
        {
            AgentBanks ab = db.AgentBanks.Where(u => u.AgentBankId == model.AgentBankId).FirstOrDefault();
            ab.AgentBankId = model.AgentBankId;
            ab.BankId = model.BankId;
            ab.BankBranchId = model.BankBranchId;
            ab.BankAccountTypeId = model.BankAccountTypeId;
            ab.AccountName = model.AccountName;
            ab.AccountNumber = model.AccountNumber;
            db.ApplyCurrentValues(ab.EntityKey.EntitySetName, ab);
            db.SaveChanges();

        }
        /// <summary>
        /// /
        /// </summary>
        /// <param name="AgentIPId"></param>
        /// <returns></returns>
         public AgentIPManagementModel GetAgentIPInfo(int AgentIPId)
         {

             var result = db.IPControlLists.SingleOrDefault(u => u.IPId == AgentIPId);
             AgentIPManagementModel model = new AgentIPManagementModel
             {
                 AgentIPId=result.IPId,
                 AgentId = result.AgentId,
                 IPAddress = result.IPAddress,
                 IsActive = result.isActive,
                 IsAutoExpire = result.isAutoExpire,
                 ActiveDate =Convert.ToDateTime( result.ActiveToDate),
                 ExpiryDateTime = Convert.ToDateTime( result.ActiveFromDate),
             };
             return model;

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
                CreatedDate=DateTime.Now,

            };
            db.AddToIPControlLists(datamodel);
            db.SaveChanges();
            int lastSaveid = GetLastSaveAgentIPId().ToList().Last().IPId;
            return lastSaveid;

        }
        public IQueryable<IPControlLists> GetLastSaveAgentIPId()
        {
            return db.IPControlLists.AsQueryable();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        public void DeleteAgentIPInfo(int id)
        {
            IPControlLists datatodelete = db.IPControlLists.First(m => m.IPId == id);
            db.DeleteObject(datatodelete);
            db.SaveChanges();
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////////
        //public AgentBanks 
        public List<DefaultMarkupLevels> GetDefaultMarkUpLevel()
        {
            return db.DefaultMarkupLevels.ToList();
        }

        public List<AirlineGroups> GetAirlineGroup()
        {
            return db.AirlineGroups.ToList();
        }
        public List<AgentClasses> GetAgentClass()
        {
            return db.AgentClasses.ToList();
        }
        public List<AgentTypes> GetAgentType()
        {
            return db.AgentTypes.ToList();
        }
        public List<Zones> GetZoneList()
        {
            return db.Zones.ToList();
        }
        public List<Districts> GetDistrictList()
        {
            return db.Districts.ToList();
        }
        public List<BankAccountTypes> GetbankAccountType()
        {
            return db.BankAccountTypes.ToList();
        }
        public List<BankBranches> GetbankBranchInformation()
        {
            return db.BankBranches.ToList();
        }
        public List<Banks> GetbankInformation()
        {
            return db.Banks.ToList();
        }
        /// <summary>
        /// /Saving Agent Bank in List /////
        /// </summary>
        /// <param name="abinfo"></param>
        public void SaveAgentBankInformation(List<AgentBanks> abinfo)
        {
            EntityModel ent = new EntityModel();
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
                    isDefault = item.isDefault,
                    
                });
            }
            ent.SaveChanges();
        }
        public void SaveAgentSetting(List<AgentSettings> obj)
        {
            EntityModel ent = new EntityModel();
            foreach (var item in obj)
            {
                ent.AgentSettings.AddObject(new AgentSettings()
                {

                    AgentId = item.AgentId,
                    SettingId = item.SettingId,
                });
            }
            ent.SaveChanges();
        }

        public void DeleteAgentSetting(int agentid)
        {
            EntityModel ent = new EntityModel();
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
        /// /Saving Agent IP in List /////
        /// </summary>
        /// <param name="abinfo"></param>
        public void SaveAgentIPInfo(List<IPControlLists> AgentIpinfo)
        {
            EntityModel ent = new EntityModel();
            foreach (var item in AgentIpinfo)
            {
                ent.IPControlLists.AddObject(new IPControlLists()
                {

                    AgentId = item.AgentId,
                    IPAddress = item.IPAddress,
                    isActive = item.isActive,
                    isAutoExpire = item.isAutoExpire,
                    ActiveFromDate = item.ActiveFromDate,
                    ActiveToDate = item.ActiveToDate,
                    CreatedBy = item.CreatedBy,
                    CreatedDate=DateTime.Now

                });
            }
            ent.SaveChanges();
        }
        //public List<district> GetDistrictListbyZoneId(int id)
        //{
        //    return db.Districts.Where(dd=> dd.ZoneId==id).Select(dd =>new{ID=di).ToList();
        //}


        /// <summary>
        /// ///////////////////////  Agent Setting information begin from here /////////////
        /// </summary>
        public List<AgentSettingsModel> GetAllActiveSettingForAgent(int agentid)
        {
            EntityModel ent = new EntityModel();
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
        public List<AgentSettingsModel> GetAllSettingList()
        {
            EntityModel ent = new EntityModel();
            var cc = (from aa in ent.Settings
                      select new AgentSettingsModel
                      {
                          SettingName = aa.SettingName,
                          SettingId = aa.SettingId,
                      }).ToList();
            return cc;
        }
        ///////////////////// End of agent setting here////////////////////////////////////
        public IEnumerable<Districts> GetDistrictListbyZoneId(int id)
         {
             EntityModel ent = new EntityModel();
           return ent.Districts.Where(dd=> dd.ZoneId==id).ToList().Select(x =>
           new Districts { DistrictId = x.DistrictId, DistrictName = x.DistrictName}
           );
           }
        public IEnumerable<BankBranches> GetBranchListbyBankId(int id)
        {
            EntityModel ent = new EntityModel();
            return ent.BankBranches.Where(dd => dd.BankId == id).ToList().Select(x =>
            new BankBranches { BankBranchId = x.BankBranchId, BranchName = x.BranchName }
            );
        }


        public bool CheckDuplicateUsername(string userName)
        {
            aspnet_Users tu = db.aspnet_Users.Where(ii => ii.UserName == userName).FirstOrDefault();
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
            Agents agent = db.Agents.Where(ii => ii.AgentName == AgentName).FirstOrDefault();
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
            Agents datatodelete = db.Agents.First(m => m.AgentId == table.AgentId);
            db.DeleteObject(datatodelete);
            db.SaveChanges();
        }

        public List<UserTypeRoleModel> GetAllRolesListForAgentCreation()
        {
            EntityModel ent = new EntityModel();
            var cc = (from aa in ent.aspnet_Roles
                      join bb in ent.RoleUserTypeMappings
                      on aa.RoleId equals bb.RoleId
                      where (bb.UserTypeId == 2 && bb.CreatedBy == 0)
                      select new UserTypeRoleModel
                      {
                          RoleId = aa.RoleId,
                          RoleName = aa.RoleName,
                      }).ToList();
            return cc;

        }

        public List<AgentAirlineRightModel> GetAirlinesRightForAgent(long AgentId)
        {
            var cc = (from aa in db.AgentAirlineMappings
                      join bb in db.Airlines
                      on aa.AirlineId equals bb.AirlineId
                      where aa.AgentId == AgentId
                      select new AgentAirlineRightModel
                      {
                          MappingId=aa.MappingId,
                          AirlineId = aa.AirlineId,
                          AirlineName = aa.Airlines.AirlineName,
                          CanSell=aa.CanSell,
                          Canview=aa.CanView

                      }).ToList();
            return cc.OrderByDescending(xx => xx.MappingId).ToList ();
        }

        public void SaveAirlineRight(AgentAirlineMappings minfo)
        {
            db.AddToAgentAirlineMappings(minfo);
            db.SaveChanges();
        }
        public void SaveUpdatedAirlineRight(List<AgentAirlineMappings> mapinfo)
        {
            EntityModel ent = new EntityModel();
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
                AgentAirlineMappings amap = db.AgentAirlineMappings.Where(u =>( u.AirlineId == item.AirlineId) && (u.AgentId==item.AgentId)).FirstOrDefault();
                amap.MappingId = item.MappingId;
                db.ApplyCurrentValues(amap.EntityKey.EntitySetName, item);
                db.SaveChanges();
            }
            
        }

        public void DeleteAgentRightForAirline(AgentAirlineMappings model)
        {
            AgentAirlineMappings datatodelete = db.AgentAirlineMappings.FirstOrDefault(m => m.MappingId == model.MappingId);
            db.DeleteObject(datatodelete);
            db.SaveChanges();
        }

        public bool CheckDuplicateAirline(int AirlineId,int agentid)
        {
            AgentAirlineMappings ainfo = db.AgentAirlineMappings.Where(ii => (ii.AirlineId == AirlineId) && (ii.AgentId == agentid )).FirstOrDefault();
            if (ainfo != null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        #endregion
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
    }
}