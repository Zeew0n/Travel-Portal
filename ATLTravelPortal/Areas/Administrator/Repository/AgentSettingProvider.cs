using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TravelPortalEntity;
using ATLTravelPortal.Areas.Administrator.Models;
using System.Web.Mvc;
using ATLTravelPortal.Helpers;

namespace ATLTravelPortal.Areas.Administrator.Repository
{
    public class AgentSettingProvider
    {
        EntityModel entityModel = new EntityModel();


        public IEnumerable<AgentServiceProviderNames> GetAllActiveServiceProviders(int AgentId)
        {
            var data = entityModel.ServiceProviders.Where(z => z.isActive.Value);
            List<AgentServiceProviderNames> model = new List<AgentServiceProviderNames>();

            foreach (var item in data)
            {
                AgentServiceProviderNames temp = new AgentServiceProviderNames
                {
                    ServiceProviderId = item.ServiceProviderId,
                    ServiceProviderName = item.ServiceProviderName,
                    AgentAccountSettingBasedOnServiceProvider = GetCurrencyOnServiceProvider(item.ServiceProviderId, AgentId),

                };
                var ServiceProviderExistancelist = temp.AgentAccountSettingBasedOnServiceProvider.Where(xx => xx.BalanceCheckOnType != 0);
                temp.ServiceProviderExistance = ServiceProviderExistancelist.Count() == 0 ? false : true;
                model.Add(temp);
            }
            return model.ToList();
        }


        public IEnumerable<AgentAccountSettingBasedOnServiceProvider> GetCurrencyOnServiceProvider(int ServiceProviderId, int AgentId)
        {

            var data = entityModel.Core_GetServiceProviderCurrencies(ServiceProviderId);
            List<AgentAccountSettingBasedOnServiceProvider> model = new List<AgentAccountSettingBasedOnServiceProvider>();

            foreach (var item in data)
            {
                AgentAccountSettingBasedOnServiceProvider temp = new AgentAccountSettingBasedOnServiceProvider
                {
                    CurrencyId = item.CurrencyId,
                    Currency = item.CurrencyCode,
                    BalanceCheckOnType = DetermineAgencyBalanceTypeUsed(ServiceProviderId, item.CurrencyId, AgentId),
                    balancecheckon = new SelectList(EnumHelper.GetEnumDescription(typeof(BalanceCheckOn)), "Name", "Description", DetermineAgencyBalanceTypeUsed(ServiceProviderId, item.CurrencyId, AgentId)),
                    IsTransOnLocalCurrency = DetermineLocalCurrencyUsed(ServiceProviderId, item.CurrencyId),

                };
                model.Add(temp);
            }
            return model.ToList();
        }

        public bool DetermineLocalCurrencyUsed(int ServiceProviderId, int CurrencyId)
        {
            try
            {
                bool flag = entityModel.Core_AgentServiceProviderAccountSetting.Where(z => z.CurrencyId == CurrencyId && z.ServiceProviderId == ServiceProviderId).SingleOrDefault().isUseLocalCurrency;
                return flag;
            }
            catch
            {
                return false;
            }
        }

        public BalanceCheckOn DetermineAgencyBalanceTypeUsed(int ServiceProviderId, int CurrencyId, int Agentid)
        {
            try
            {
                int BalanceType = entityModel.Core_AgentServiceProviderAccountSetting.Where(z => z.CurrencyId == CurrencyId && z.ServiceProviderId == ServiceProviderId && z.AgentId == Agentid).SingleOrDefault().CheckAgencyBalanceOn;
                if (BalanceType == 1)
                    return BalanceCheckOn.CreditLimit;
                else
                    return BalanceCheckOn.LedgerBalance;

            }
            catch
            {
                return 0;
            }
        }

        public void SaveServiceProviderAccountSetting(List<AgentServiceProviderNames> modeldata, int CreatedBy, int AgentId)
        {
            List<Core_AgentServiceProviderAccountSetting> datatosave = new List<Core_AgentServiceProviderAccountSetting>();
            foreach (var individualdata in modeldata)
            {
                foreach (var result in individualdata.AgentAccountSettingBasedOnServiceProvider)
                {
                    Core_AgentServiceProviderAccountSetting obj = new Core_AgentServiceProviderAccountSetting();
                    obj.AgentId = AgentId;
                    obj.ServiceProviderId = individualdata.ServiceProviderId;
                    obj.CurrencyId = result.CurrencyId;
                    obj.CheckAgencyBalanceOn = (int)result.BalanceCheckOnType;
                    obj.isUseLocalCurrency = result.IsTransOnLocalCurrency;
                    obj.CreatedBy = CreatedBy;
                    obj.CreatedDate = DateTime.Now;
                    if (obj.CheckAgencyBalanceOn != 0)
                    {
                        datatosave.Add(obj);
                    }
                }

            }
            foreach (var item in datatosave)
            {
                entityModel.Core_AgentServiceProviderAccountSetting.AddObject(new Core_AgentServiceProviderAccountSetting()
                {

                    AgentId = item.AgentId,
                    ServiceProviderId = item.ServiceProviderId,
                    CurrencyId = item.CurrencyId,
                    CheckAgencyBalanceOn = item.CheckAgencyBalanceOn,
                    isUseLocalCurrency = item.isUseLocalCurrency,
                    CreatedBy = item.CreatedBy,
                    CreatedDate = item.CreatedDate,
                });
            }
            entityModel.SaveChanges();

        }

        public void DeleteServiceProviderAccountSetting(int AgentId)
        {
            List<Core_AgentServiceProviderAccountSetting> result = entityModel.Core_AgentServiceProviderAccountSetting.Where(x => x.AgentId == AgentId).ToList();
            if (result.Count() != 0)
            {
                foreach (Core_AgentServiceProviderAccountSetting item in result)
                {
                    entityModel.DeleteObject(item);
                    entityModel.SaveChanges();
                }
            }
        }

        public Air_AdminBranchDealAssociations GetBranchOfficeMasterDeal(int ID, int ProductId)
        {
            return entityModel.Air_AdminBranchDealAssociations.SingleOrDefault(u => u.BranchOfficeId == ID && u.ProductId == ProductId);
        }

        public Air_BranchDistributorDealAssociations GetBranchOfficeMasterDealforDistributors(int ID, int ProductId)
        {
            return entityModel.Air_BranchDistributorDealAssociations.SingleOrDefault(u => u.DistributorId == ID && u.ProductId == ProductId);
        }


        public Air_DistributorAgentDealAssociations GetDistributorsAgentMasterDeal(int ID, int ProductId)
        {
            return entityModel.Air_DistributorAgentDealAssociations.SingleOrDefault(u => u.AgentId == ID && u.ProductId == ProductId);
        }





        public Core_AgentsDeals GetMasterDeal(int ID, int ProductId)
        {
            return entityModel.Core_AgentsDeals.SingleOrDefault(u => u.AgentId == ID && u.ProductId == ProductId);
        }

        public Air_BranchDistributorDealAssociations GetDistributorMasterDeal(int ID, int ProductId)
        {
            return entityModel.Air_BranchDistributorDealAssociations.SingleOrDefault(u => u.DistributorId == ID && u.ProductId == ProductId);
        }


        public IEnumerable<SelectListItem> GetBranchAllDealListOfAirlines()
        {
            List<Tkt_DealMasters> all = BranchMasterDealListOfAirlines().ToList();
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
        private IQueryable<Tkt_DealMasters> BranchMasterDealListOfAirlines()
        {
            //return entityModel.Tkt_DealMasters.OrderBy(xx => xx.DealMasterId).Where(x => (x.DealTypeId == 2 || x.DealTypeId == 6) && x.ProductId == 1).AsQueryable();
            return entityModel.Tkt_DealMasters.OrderBy(xx => xx.DealMasterId).Where(x => x.DealTypeId == 6 && x.ProductId == 1).AsQueryable();
        }

        public IEnumerable<SelectListItem> GetAgentDealListOfAirlines()
        {
            List<Tkt_DealMasters> all = AgentMasterDealListOfAirlines().ToList();
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
        private IQueryable<Tkt_DealMasters> AgentMasterDealListOfAirlines()
        {
            //return entityModel.Tkt_DealMasters.OrderBy(xx => xx.DealMasterId).Where(x => (x.DealTypeId == 2 || x.DealTypeId == 6) && x.ProductId == 1).AsQueryable();
            return entityModel.Tkt_DealMasters.OrderBy(xx => xx.DealMasterId).Where(x => x.DealTypeId == 2 && x.ProductId == 1).AsQueryable();
        }

        public IEnumerable<SelectListItem> GetDistrubutorDealListOfAirlines()
        {
            List<Tkt_DealMasters> all = DistrubutorMasterDealListOfAirlines().ToList();
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
        private IQueryable<Tkt_DealMasters> DistrubutorMasterDealListOfAirlines()
        {
            //return entityModel.Tkt_DealMasters.OrderBy(xx => xx.DealMasterId).Where(x => (x.DealTypeId == 2 || x.DealTypeId == 6) && x.ProductId == 1).AsQueryable();
            return entityModel.Tkt_DealMasters.OrderBy(xx => xx.DealMasterId).Where(x => x.DealTypeId == 7 && x.ProductId == 1).AsQueryable();
        }





        public IEnumerable<SelectListItem> GetAllDistributorAgentDealListOfAirlines(int DistributorId)
        {
            List<Core_DistributorDealMasters> all = MasterDistributorAgentDealListOfAirlines(DistributorId, 1).ToList();
            var GetAllDealList = new List<SelectListItem>();
            foreach (var item in all)
            {
                var teml = new SelectListItem
                {
                    Text = item.DistributorDealName,
                    Value = item.DistributorDealMasterId.ToString()
                };
                GetAllDealList.Add(teml);
            }
            return GetAllDealList.AsEnumerable();
        }


        public IEnumerable<SelectListItem> GetAllDistributorAgentDealListOfHotels(int DistributorId)
        {
            List<Core_DistributorDealMasters> all = MasterDistributorAgentDealListOfAirlines(DistributorId, 2).ToList();
            var GetAllDealList = new List<SelectListItem>();
            foreach (var item in all)
            {
                var teml = new SelectListItem
                {
                    Text = item.DistributorDealName,
                    Value = item.DistributorDealMasterId.ToString()
                };
                GetAllDealList.Add(teml);
            }
            return GetAllDealList.AsEnumerable();
        }

        public IEnumerable<SelectListItem> GetAllDistributorAgentDealListOfBus(int DistributorId)
        {
            List<Core_DistributorDealMasters> all = MasterDistributorAgentDealListOfAirlines(DistributorId, 4).ToList();
            var GetAllDealList = new List<SelectListItem>();
            foreach (var item in all)
            {
                var teml = new SelectListItem
                {
                    Text = item.DistributorDealName,
                    Value = item.DistributorDealMasterId.ToString()
                };
                GetAllDealList.Add(teml);
            }
            return GetAllDealList.AsEnumerable();
        }

        public IEnumerable<SelectListItem> GetAllDistributorAgentDealListOfMobile(int DistributorId)
        {
            List<Core_DistributorDealMasters> all = MasterDistributorAgentDealListOfAirlines(DistributorId, 3).ToList();
            var GetAllDealList = new List<SelectListItem>();
            foreach (var item in all)
            {
                var teml = new SelectListItem
                {
                    Text = item.DistributorDealName,
                    Value = item.DistributorDealMasterId.ToString()
                };
                GetAllDealList.Add(teml);
            }
            return GetAllDealList.AsEnumerable();
        }

        private IQueryable<Core_DistributorDealMasters> MasterDistributorAgentDealListOfAirlines(int distributorID, int productID)
        {
            return entityModel.Core_DistributorDealMasters.Where(x => x.DistributorId == distributorID && x.ProductId == productID).OrderBy(xx => xx.DistributorDealMasterId).AsQueryable();
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

        public IEnumerable<SelectListItem> GetAllDealListOfBus()
        {
            List<Tkt_DealMasters> all = MasterDealListOfBus().ToList();
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

        public IEnumerable<SelectListItem> GetAllDealListOfMobile()
        {
            List<Tkt_DealMasters> all = MasterDealListOfMobile().ToList();
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
            return entityModel.Tkt_DealMasters.OrderBy(xx => xx.DealMasterId).Where(x => x.DealTypeId == 6 && x.ProductId == 2).AsQueryable();
        }

        private IQueryable<Tkt_DealMasters> MasterDealListOfBus()
        {
            return entityModel.Tkt_DealMasters.OrderBy(xx => xx.DealMasterId).Where(x => x.DealTypeId == 6 && x.ProductId == 4).AsQueryable();
        }

        private IQueryable<Tkt_DealMasters> MasterDealListOfMobile()
        {
            return entityModel.Tkt_DealMasters.OrderBy(xx => xx.DealMasterId).Where(x => x.DealTypeId == 6 && x.ProductId == 3).AsQueryable();
        }

        public List<AgentSettingsModel> GetAllSettingList()
        {
            TravelPortalEntity.EntityModel ent = new TravelPortalEntity.EntityModel();
            var cc = (from aa in ent.Settings.Where(ii => (ii.isActive == true && (ii.SettingId == 5 || ii.SettingId == 6)))
                      select new AgentSettingsModel
                      {
                          SettingName = aa.SettingName,
                          SettingId = aa.SettingId,
                      }).ToList();
            return cc;
        }


        public List<AgentSettingsModel> GetAllAdminSettingList()
        {
            TravelPortalEntity.EntityModel ent = new TravelPortalEntity.EntityModel();
            var cc = (from aa in ent.Settings.Where(ii => (ii.isActive == true && ii.SettingFor == "AGENT"))
                      select new AgentSettingsModel
                      {
                          SettingName = aa.SettingName,
                          SettingId = aa.SettingId,
                      }).ToList();
            return cc;
        }


        public string GetAgentName(int agentid)
        {
            string agentname = entityModel.Agents.Where(x => x.AgentId == agentid).Select(x => x.AgentName).FirstOrDefault();
            return agentname;
        }



        private IQueryable<Core_BranchDealMasters> GetBranchDistributorMasterDeal(int branchOfficeID, int productID)
        {
            return entityModel.Core_BranchDealMasters.Where(x => x.BranchOfficeId == branchOfficeID && x.ProductId == productID).OrderBy(xx => xx.BranchDealMasterId).AsQueryable();
        }
        public IEnumerable<SelectListItem> GetAllBranchDistributorDealListOfAirlines(int brachOfficeID)
        {
            List<Core_BranchDealMasters> all = GetBranchDistributorMasterDeal(brachOfficeID, 1).ToList();
            var GetAllDealList = new List<SelectListItem>();
            foreach (var item in all)
            {
                var teml = new SelectListItem
                {
                    Text = item.BranchDealName,
                    Value = item.BranchDealMasterId.ToString()
                };
                GetAllDealList.Add(teml);
            }
            return GetAllDealList.AsEnumerable();
        }

        public IEnumerable<SelectListItem> GetAllBranchDistributorDealListOfHotels(int branchOfficeID)
        {
            List<Core_BranchDealMasters> all = GetBranchDistributorMasterDeal(branchOfficeID, 2).ToList();
            var GetAllDealList = new List<SelectListItem>();
            foreach (var item in all)
            {
                var teml = new SelectListItem
                {
                    Text = item.BranchDealName,
                    Value = item.BranchDealMasterId.ToString()
                };
                GetAllDealList.Add(teml);
            }
            return GetAllDealList.AsEnumerable();
        }

        public IEnumerable<SelectListItem> GetAllBranchDistributorDealListOfBus(int branchOfficeID)
        {
            List<Core_BranchDealMasters> all = GetBranchDistributorMasterDeal(branchOfficeID, 4).ToList();
            var GetAllDealList = new List<SelectListItem>();
            foreach (var item in all)
            {
                var teml = new SelectListItem
                {
                    Text = item.BranchDealName,
                    Value = item.BranchDealMasterId.ToString()
                };
                GetAllDealList.Add(teml);
            }
            return GetAllDealList.AsEnumerable();
        }

        public IEnumerable<SelectListItem> GetAllBranchDistributorDealListOfMobile(int branchOfficeID)
        {
            List<Core_BranchDealMasters> all = GetBranchDistributorMasterDeal(branchOfficeID, 3).ToList();
            var GetAllDealList = new List<SelectListItem>();
            foreach (var item in all)
            {
                var teml = new SelectListItem
                {
                    Text = item.BranchDealName,
                    Value = item.BranchDealMasterId.ToString()
                };
                GetAllDealList.Add(teml);
            }
            return GetAllDealList.AsEnumerable();
        }
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


        public int? GeBranchClass(int BranchOfficeId)
        {

            return (from a in entityModel.BranchOffices
                    where a.BranchOfficeId == BranchOfficeId
                    select a.BranchClassId).FirstOrDefault() ?? null;
        }

        public int? GeDistributorClass(int DistributorId)
        {

            return (from a in entityModel.Distributors
                    where a.DistributorId == DistributorId
                    select a.DistributorClassId).FirstOrDefault() ?? null;
        }


        public List<BranchClasses> GetBranchClass()
        {
            return entityModel.BranchClasses.ToList();
        }

        public List<DistributorClasses> GetDistributorClass()
        {
            return entityModel.DistributorClasses.ToList();
        }


        public List<AgentClasses> GetAgentClass()
        {
            return entityModel.AgentClasses.ToList();
        }

        public int? GetAgentClass(int AgentId)
        {
            // return entityModel.Agents.Where(x => x.AgentId == AgentId).FirstOrDefault().AgentClasses.AgentClassId;
            return (from a in entityModel.Agents
                    where a.AgentId == AgentId
                    select a.AgentClassId).FirstOrDefault() ?? null;
        }
        public void UpdateAgentwithAgentClass(int? AgentClassId, int UpdatedBy, int AgentId)
        {
            Agents tu = entityModel.Agents.Where(u => u.AgentId == AgentId).FirstOrDefault();
            if (AgentClassId == null)
                tu.AgentClassId = null;
            else
                tu.AgentClassId = AgentClassId;
            tu.UpdatedDate = DateTime.Now;
            tu.UpdatedBy = UpdatedBy;
            entityModel.ApplyCurrentValues(tu.EntityKey.EntitySetName, tu);
            entityModel.SaveChanges();

        }
        public bool CheckIFDealExistForAgent(int AgentID, int productid)
        {
            Core_AgentsDeals deal = entityModel.Core_AgentsDeals.Where(u => u.AgentId == AgentID && u.ProductId == productid).FirstOrDefault();
            if (deal != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool CheckIFDealExistForBranchDistributorDealAssociations(int AgentID, int productid)
        {
            Air_BranchDistributorDealAssociations deal = entityModel.Air_BranchDistributorDealAssociations.Where(u => u.DistributorId == AgentID && u.ProductId == productid).FirstOrDefault();
            if (deal != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public bool CheckIFDealExistForBranchsDistributor(int AgentID, int productid)
        {
            Air_DistributorAgentDealAssociations deal = entityModel.Air_DistributorAgentDealAssociations.Where(u => u.AgentId == AgentID && u.ProductId == productid).FirstOrDefault();
            if (deal != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public bool CheckIFDealExistForBranch(int BranchOfficeId, int productid)
        {
            Air_AdminBranchDealAssociations deal = entityModel.Air_AdminBranchDealAssociations.Where(u => u.BranchOfficeId == BranchOfficeId && u.ProductId == productid).FirstOrDefault();
            if (deal != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public bool CheckIFDealExistForBranchDistributor(int DistributorId, int productid)
        {
            Air_BranchDistributorDealAssociations deal = entityModel.Air_BranchDistributorDealAssociations.Where(u => u.DistributorId == DistributorId && u.ProductId == productid).FirstOrDefault();
            if (deal != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public void UpdateDeal(AgentSettingModel model, int ProductID, int AgentId)
        {
            Core_AgentsDeals tu = entityModel.Core_AgentsDeals.Where(u => u.AgentId == AgentId && u.ProductId == ProductID).FirstOrDefault();
            if (tu != null)
            {
                if (ProductID == 1)
                    tu.MasterDealId = model.MasterDealIdOfAirlines;
                else if (ProductID == 2)
                    tu.MasterDealId = model.MasterDealIdOfHotel;
                else if (ProductID == 3)
                    tu.MasterDealId = model.MasterDealIdOfMobile;
                else if (ProductID == 4)
                    tu.MasterDealId = model.MasterDealIdOfBus;

                entityModel.ApplyCurrentValues(tu.EntityKey.EntitySetName, tu);
                entityModel.SaveChanges();
            }

        }


        public void UpdateBranchDistributorAgent(AgentSettingModel model, int ProductID, int AgentId)
        {
            Air_BranchDistributorDealAssociations tu = entityModel.Air_BranchDistributorDealAssociations.Where(u => u.DistributorId == AgentId && u.ProductId == ProductID).FirstOrDefault();
            if (tu != null)
            {
                if (ProductID == 1)
                    tu.BranchDealMasterId = model.MasterDealIdOfAirlines;
                else if (ProductID == 2)
                    tu.BranchDealMasterId = model.MasterDealIdOfHotel;

                entityModel.ApplyCurrentValues(tu.EntityKey.EntitySetName, tu);
                entityModel.SaveChanges();
            }

        }


        public void UpdateBranchDistributorAgentSettingDeal(AgentSettingModel model, int ProductID, int AgentId)
        {
            Air_AdminBranchDealAssociations tu = entityModel.Air_AdminBranchDealAssociations.Where(u => u.BranchOfficeId == AgentId && u.ProductId == ProductID).FirstOrDefault();
            if (tu != null)
            {
                if (ProductID == 1)
                    tu.DealMasterId = model.MasterDealIdOfAirlines;
                else if (ProductID == 2)
                    tu.DealMasterId = model.MasterDealIdOfHotel;

                entityModel.ApplyCurrentValues(tu.EntityKey.EntitySetName, tu);
                entityModel.SaveChanges();
            }

        }



        public void UpdateBranchDeal(BranchOfficeManagementModel model, int ProductID, int BranchOfficeId)
        {
            Air_AdminBranchDealAssociations tu = entityModel.Air_AdminBranchDealAssociations.Where(u => u.BranchOfficeId == BranchOfficeId && u.ProductId == ProductID).FirstOrDefault();
            if (tu != null)
            {
                if (ProductID == 1)
                    tu.DealMasterId = model.MasterDealIdOfAirlines;
                else if (ProductID == 2)
                    tu.DealMasterId = model.MasterDealIdOfHotel;
                else if (ProductID == 3)
                    tu.DealMasterId = model.MasterDealIdOfMobile;
                else if (ProductID == 4)
                    tu.DealMasterId = model.MasterDealIdOfBus;


                entityModel.ApplyCurrentValues(tu.EntityKey.EntitySetName, tu);
                entityModel.SaveChanges();
            }

        }


        public void UpdateBranchDistributorDeal(AgentSettingModel model, int ProductID, int AgentId)
        {
            Air_DistributorAgentDealAssociations tu = entityModel.Air_DistributorAgentDealAssociations.Where(u => u.AgentId == AgentId && u.ProductId == ProductID).FirstOrDefault();
            if (tu != null)
            {
                if (ProductID == 1)
                    tu.DistributorDealMasterId = model.MasterDealIdOfAirlines;
                else if (ProductID == 2)
                    tu.DistributorDealMasterId = model.MasterDealIdOfHotel;
                else if (ProductID == 3)
                    tu.DistributorDealMasterId = model.MasterDealIdOfMobile;
                else if (ProductID == 4)
                    tu.DistributorDealMasterId = model.MasterDealIdOfBus;

                entityModel.ApplyCurrentValues(tu.EntityKey.EntitySetName, tu);
                entityModel.SaveChanges();
            }

        }

        public void UpdateDistributorDeal(DistributorManagementModel model, int ProductID, int DistributorID)
        {
            Air_BranchDistributorDealAssociations tu = entityModel.Air_BranchDistributorDealAssociations.Where(u => u.DistributorId == DistributorID && u.ProductId == ProductID).FirstOrDefault();
            if (tu != null)
            {
                if (ProductID == 1)
                    tu.BranchDealMasterId = model.MasterDealIdOfAirlines;
                else if (ProductID == 2)
                    tu.BranchDealMasterId = model.MasterDealIdOfHotel;
                else if (ProductID == 3)
                    tu.BranchDealMasterId = model.MasterDealIdOfMobile;
                else if (ProductID == 4)
                    tu.BranchDealMasterId = model.MasterDealIdOfBus;


                entityModel.ApplyCurrentValues(tu.EntityKey.EntitySetName, tu);
                entityModel.SaveChanges();
            }

        }

        public void SaveDistributorDeal(DistributorManagementModel modelTosave, int DistributorId, int ProductId, int CreatedBy)
        {
            Air_BranchDistributorDealAssociations datamodel = new Air_BranchDistributorDealAssociations();
            datamodel.DistributorId = DistributorId;
            datamodel.ProductId = ProductId;
            if (ProductId == 1)
                datamodel.BranchDealMasterId = modelTosave.MasterDealIdOfAirlines;
            else if (ProductId == 2)
                datamodel.BranchDealMasterId = modelTosave.MasterDealIdOfHotel;
            else if (ProductId == 3)
                datamodel.BranchDealMasterId = modelTosave.MasterDealIdOfMobile;
            else if (ProductId == 4)
                datamodel.BranchDealMasterId = modelTosave.MasterDealIdOfBus;

            datamodel.CreatedBy = CreatedBy;
            datamodel.CreatedDate = DateTime.Now;
            entityModel.AddToAir_BranchDistributorDealAssociations(datamodel);
            entityModel.SaveChanges();
        }


        public void SaveBranchDeal(BranchOfficeManagementModel modelTosave, int BranchOfficeId, int ProductId, int CreatedBy)
        {
            Air_AdminBranchDealAssociations datamodel = new Air_AdminBranchDealAssociations();
            datamodel.BranchOfficeId = BranchOfficeId;
            datamodel.ProductId = ProductId;
            if (ProductId == 1)
                datamodel.DealMasterId = modelTosave.MasterDealIdOfAirlines;
            else if (ProductId == 2)
                datamodel.DealMasterId = modelTosave.MasterDealIdOfHotel;
            else if (ProductId == 3)
                datamodel.DealMasterId = modelTosave.MasterDealIdOfMobile;
            else if (ProductId == 4)
                datamodel.DealMasterId = modelTosave.MasterDealIdOfBus;

            datamodel.CreatedBy = CreatedBy;
            datamodel.CreatedDate = DateTime.Now;
            entityModel.AddToAir_AdminBranchDealAssociations(datamodel);
            entityModel.SaveChanges();

        }

        public void SaveBranchDistributorAgentDeal(AgentSettingModel modelTosave, int agentid, int ProductId, int CreatedBy)
        {
            Air_DistributorAgentDealAssociations datamodel = new Air_DistributorAgentDealAssociations();
            datamodel.AgentId = agentid;
            datamodel.ProductId = ProductId;
            if (ProductId == 1)
                datamodel.DistributorDealMasterId = modelTosave.MasterDealIdOfAirlines;
            else if (ProductId == 2)
                datamodel.DistributorDealMasterId = modelTosave.MasterDealIdOfHotel;
            else if (ProductId == 3)
                datamodel.DistributorDealMasterId = modelTosave.MasterDealIdOfMobile;
            else if (ProductId == 4)
                datamodel.DistributorDealMasterId = modelTosave.MasterDealIdOfBus;

            datamodel.CreatedBy = CreatedBy;
            datamodel.CreatedDate = DateTime.Now;
            entityModel.AddToAir_DistributorAgentDealAssociations(datamodel);
            entityModel.SaveChanges();

        }


        public void SaveAgentDeal(AgentSettingModel modelTosave, int agentid, int ProductId, int CreatedBy)
        {
            Core_AgentsDeals datamodel = new Core_AgentsDeals();
            datamodel.AgentId = agentid;
            datamodel.ProductId = ProductId;
            if (ProductId == 1)
                datamodel.MasterDealId = modelTosave.MasterDealIdOfAirlines;
            else if (ProductId == 2)
                datamodel.MasterDealId = modelTosave.MasterDealIdOfHotel;
            else if (ProductId == 3)
                datamodel.MasterDealId = modelTosave.MasterDealIdOfMobile;
            else if (ProductId == 4)
                datamodel.MasterDealId = modelTosave.MasterDealIdOfBus;

            datamodel.CreatedBy = CreatedBy;
            datamodel.CreatedDate = DateTime.Now;
            entityModel.AddToCore_AgentsDeals(datamodel);
            entityModel.SaveChanges();

        }

        public void SaveBranchDistributorAgent(AgentSettingModel modelTosave, int agentid, int ProductId, int CreatedBy)
        {
            Air_BranchDistributorDealAssociations datamodel = new Air_BranchDistributorDealAssociations();
            datamodel.DistributorId = modelTosave.DistributorId ?? 0;
            datamodel.ProductId = ProductId;
            if (ProductId == 1)
                datamodel.BranchDealMasterId = modelTosave.MasterDealIdOfAirlines;
            else if (ProductId == 2)
                datamodel.BranchDealMasterId = modelTosave.MasterDealIdOfHotel;
            datamodel.CreatedBy = CreatedBy;
            datamodel.CreatedDate = DateTime.Now;
            entityModel.AddToAir_BranchDistributorDealAssociations(datamodel);
            entityModel.SaveChanges();

        }


        public void SaveBranchDistributorAgentSettingDeal(AgentSettingModel modelTosave, int agentid, int ProductId, int CreatedBy)
        {
            Air_AdminBranchDealAssociations datamodel = new Air_AdminBranchDealAssociations();
            datamodel.BranchOfficeId = agentid;
            datamodel.ProductId = ProductId;
            if (ProductId == 1)
                datamodel.DealMasterId = modelTosave.MasterDealIdOfAirlines;
            else if (ProductId == 2)
                datamodel.DealMasterId = modelTosave.MasterDealIdOfHotel;
            datamodel.CreatedBy = CreatedBy;
            datamodel.CreatedDate = DateTime.Now;
            entityModel.AddToAir_AdminBranchDealAssociations(datamodel);
            entityModel.SaveChanges();

        }

        public void DeleteDistributorDeal(int id, int productid)
        {
            if (entityModel.Air_BranchDistributorDealAssociations.Where(x => x.DistributorId == id && x.ProductId == productid).Count() > 0)
            {
                Air_BranchDistributorDealAssociations datatodelete = entityModel.Air_BranchDistributorDealAssociations.First(m => m.DistributorId == id && m.ProductId == productid);
                entityModel.DeleteObject(datatodelete);
                entityModel.SaveChanges();
            }
        }

        public void DeleteBranchDeal(int id, int productid)
        {
            if (entityModel.Air_AdminBranchDealAssociations.Where(x => x.BranchOfficeId == id && x.ProductId == productid).Count() > 0)
            {
                Air_AdminBranchDealAssociations datatodelete = entityModel.Air_AdminBranchDealAssociations.First(m => m.BranchOfficeId == id && m.ProductId == productid);
                entityModel.DeleteObject(datatodelete);
                entityModel.SaveChanges();
            }
        }
        public void DeleteAgentDeal(int id, int productid)
        {
            if (entityModel.Core_AgentsDeals.Where(x => x.AgentId == id && x.ProductId == productid).Count() > 0)
            {
                Core_AgentsDeals datatodelete = entityModel.Core_AgentsDeals.First(m => m.AgentId == id && m.ProductId == productid);
                entityModel.DeleteObject(datatodelete);
                entityModel.SaveChanges();
            }
        }

        public void DeleteBranchDistributorAgent(int id, int productid)
        {
            if (entityModel.Air_BranchDistributorDealAssociations.Where(x => x.DistributorId == id && x.ProductId == productid).Count() > 0)
            {
                Air_BranchDistributorDealAssociations datatodelete = entityModel.Air_BranchDistributorDealAssociations.First(m => m.DistributorId == id && m.ProductId == productid);
                entityModel.DeleteObject(datatodelete);
                entityModel.SaveChanges();
            }
        }

        public void DeleteBranchDistributorAgentSettingDeal(int id, int productid)
        {
            if (entityModel.Air_AdminBranchDealAssociations.Where(x => x.BranchOfficeId == id && x.ProductId == productid).Count() > 0)
            {
                Air_AdminBranchDealAssociations datatodelete = entityModel.Air_AdminBranchDealAssociations.First(m => m.BranchOfficeId == id && m.ProductId == productid);
                entityModel.DeleteObject(datatodelete);
                entityModel.SaveChanges();
            }
        }



        public void DeleteAir_DistributorAgentDealAssociations(int id, int productid)
        {
            if (entityModel.Air_DistributorAgentDealAssociations.Where(x => x.AgentId == id && x.ProductId == productid).Count() > 0)
            {
                Air_DistributorAgentDealAssociations datatodelete = entityModel.Air_DistributorAgentDealAssociations.First(m => m.AgentId == id && m.ProductId == productid);
                entityModel.DeleteObject(datatodelete);
                entityModel.SaveChanges();
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

        public void DeleteDistributorAgentSetting(int agentid)
        {
            TravelPortalEntity.EntityModel ent = new TravelPortalEntity.EntityModel();
            try
            {
                var filteredSettings = ent.AgentSettings.Where(x => x.AgentId == agentid && (x.AgentSettingId == 5 || x.AgentSettingId == 6));

                foreach (AgentSettings agentSetting in filteredSettings)
                {
                    ent.DeleteObject(agentSetting);
                }

                ent.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void SaveAgentSetting(List<int> abinfo, int AgentId)
        {
            TravelPortalEntity.EntityModel ent = new TravelPortalEntity.EntityModel();
            foreach (var item in abinfo)
            {
                ent.AgentSettings.AddObject(new AgentSettings()
                {

                    AgentId = AgentId,
                    SettingId = item,
                });
            }
            ent.SaveChanges();

        }
    }
}