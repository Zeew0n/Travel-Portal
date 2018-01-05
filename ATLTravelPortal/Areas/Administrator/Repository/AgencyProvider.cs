using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TravelPortalEntity;
using ATLTravelPortal.Areas.Administrator.Models;
using System.Text;
using ATLTravelPortal.Models;
using System.Web.Mvc;
using System.Web.Security;

namespace ATLTravelPortal.Areas.Administrator.Repository
{
    public class AgencyProvider
    {
        EntityModel ent = new EntityModel();
        ATLTravelPortal.Models.ActionResponse _res = new ATLTravelPortal.Models.ActionResponse();
        UserManagementProvider _usRep = new UserManagementProvider();
        AdminUserManagementRepository pro = new AdminUserManagementRepository();


        public bool SendEmail(string htmlTemplate, int agentId, string subject)
        {
            try
            {
                var agent = ent.SignUpAgents.Where(x => x.AgentId == agentId).FirstOrDefault().Email;
                var allagent = agent;
                if (agent != null)
                {
                    ent.CORE_SendEmails(allagent, "deepa.chakraborty@arihantholidays.com; jyotsna.khadka@arihantholidays.com ", string.Empty, subject, htmlTemplate, "HTML", "HIGH");
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        public List<AgencyModel> ListSignUpAgents()
        {
            var result = ent.SignUpAgents.Where(x => x.isMigrated == false);
            List<AgencyModel> model = new List<AgencyModel>();
            foreach (var item in result)
            {
                AgencyModel obj = new AgencyModel
                {
                    AgentId = item.AgentId,
                    AgencyCode = item.AgentCode,
                    AgencyName = item.AgentName,
                    NativeCountry = item.NativeCountry,
                    Zone = item.ZoneId,
                    District = item.DistrictId,
                    Mobile = item.Mobile == "" ? null : item.Mobile,
                    Phone = item.Phone == "" ? null : item.Phone,
                    Email = item.Email == "" ? null : item.Email,
                    AgentStatus = item.AgentStatus == true ? true : item.AgentStatus,
                    TimeZoneId = (int)item.TimeZoneId,
                    CreatedDate = item.CreatedDate,
                    CreatedBy = item.CreatedBy,
                    isApproved = item.isApproved,
                };
                model.Add(obj);
            }
            return model.OrderByDescending(x => x.CreatedDate).ToList();
        }


        public List<AgencyModel> GetSignUpAgentSearchResult(string AgentName)
        {

            var result = ent.SignUpAgents.Where(x => (x.AgentName.Contains(AgentName)) || (x.AgentCode.Contains(AgentName)));
            List<AgencyModel> model = new List<AgencyModel>();
            foreach (var item in result)
            {
                AgencyModel obj = new AgencyModel
                {
                    AgentId = item.AgentId,
                    AgencyCode = item.AgentCode,
                    AgencyName = item.AgentName,
                    NativeCountry = item.NativeCountry,
                    Zone = item.ZoneId,
                    District = item.DistrictId,
                    Mobile = item.Mobile == "" ? null : item.Mobile,
                    Phone = item.Phone == "" ? null : item.Phone,
                    Email = item.Email == "" ? null : item.Email,
                    AgentStatus = item.AgentStatus == true ? true : item.AgentStatus,
                    TimeZoneId = (int)item.TimeZoneId,
                    CreatedDate = item.CreatedDate,
                    CreatedBy = item.CreatedBy,
                    isApproved = item.isApproved
                };
                model.Add(obj);
            }
            return model;
        }

        public void DeleteSignUpAgents(int AgentId)
        {
            SignUpAgents result = ent.SignUpAgents.Where(x => x.AgentId == AgentId).FirstOrDefault();
            ent.DeleteObject(result);
            ent.SaveChanges();
        }

       

        public AgencyModel SignUpAgentsDetail(int AgentId)
        {
            SignUpAgents result = ent.SignUpAgents.Where(x => x.AgentId == AgentId).FirstOrDefault();
            AgencyModel model = new AgencyModel();

            model.AgentId = result.AgentId;
            model.AgencyCode = result.AgentCode;
            model.AgencyName = result.AgentName;
            model.ContactPerson = result.ContactPerson;
            model.NativeCountry = result.NativeCountry;
            model.Zone = result.ZoneId;
            model.District = result.DistrictId;
            model.Mobile = result.Mobile;
            model.Pincode = result.PinCode;
            model.Email = result.Email;
            model.FaxNo = result.FaxNo;
            model.PanCardNo = result.PanNo;
            model.Email = result.Email;
            model.FaxNo = result.FaxNo;
            model.PanCardNo = result.PanNo;
            model.PanHolderName = result.PanNoHolderName;
            model.Web = result.Web;
            model.AgentStatus = result.AgentStatus;
            model.TimeZoneId = (int)result.TimeZoneId;
            model.CreatedDate = result.CreatedDate;
            model.isApproved = result.isApproved;
            model.State = result.ZoneId;
            model.Phone = result.Phone;
            model.City = result.DistrictId;
            model.StateName = result.Zones.ZoneName;
            model.CityName = result.Districts.DistrictName;
            model.Password = result.Password;
            model.Address = result.Address;
            model.UserName = result.UserName;
            model.FullName = result.FullName;
            return model;

        }
        public void Approve(int id)
        {
            SignUpAgents result = ent.SignUpAgents.Where(x => x.AgentId == id).FirstOrDefault();

            result.isMigrated = true;

            ent.ApplyCurrentValues(result.EntityKey.EntitySetName, result);
            ent.SaveChanges();
        }

        public Agents CreateSignUpAgent(AgencyModel model)
        {
            int AgentId = 0;
            Agents obj = new Agents
            {
                AgentCode = "AH" + GenerateSixDigitnumeric(),
                AgentName = model.AgencyName,
                NativeCountry = 1,
                ZoneId = model.State,
                DistrictId = model.City,
                Address = model.Address,
                Phone = model.Phone,
                Email = model.Email,
                FaxNo = model.FaxNo == null ? "" : model.FaxNo,
                PanNo = model.PanCardNo == null ? "" : model.PanCardNo,
                Web = model.Web == null ? "" : model.Web,
                AgentStatus = false,
                MaxNumberOfAgentUser = model.MaxNoofAgentUsers == 0 ? 0 : model.MaxNoofAgentUsers,
                AgentLogo = model.AgentLogo == null ? "" : model.AgentLogo,
                TimeZoneId = 66,
                CreatedDate = DateTime.Now,
                CreatedBy = model.CreatedBy,
                UpdatedDate = DateTime.Now,
                AgentTypeId = 1,
                //isApproved = model.isApproved == false ? false : true,
                //ApprovedDate = DateTime.Now
            };
            ent.AddToAgents(obj);
            ent.SaveChanges();
            AgentId = obj.AgentId;
            return obj;



        }
        private string GenerateSixCharacterAlphanumeric()
        {
           
            string def = "ABCDEFGHIJKLMNOPQRSTUVWXYZ9802038020INDIRASAPKOTA0123456789";
            Random rnd = new Random();
            StringBuilder ret = new StringBuilder();
            for (int i = 0; i < 6; i++)
                ret.Append(def.Substring(rnd.Next(def.Length), 1));
            return ret.ToString();
        }
        private string GenerateSixDigitnumeric()
        {
            Random random = new Random();
            return (random.Next(99999, 999999)).ToString();
        }


     


        public void CreateUser(AgencyModel obj)
        {
            ent.CreateASPUser(obj.UserName, obj.Password, obj.Email,"AGENT", null, obj.FullName, obj.Address, obj.Mobile, obj.Phone, (int)ATLTravelPortal.Helpers.UserTypes.User, obj.CreatedbyUser, "Holidays");

        }
        public void SignUpAgentDelete(int AgentId)
        {
            SignUpAgents result = ent.SignUpAgents.Where(x => x.AgentId == AgentId).FirstOrDefault();
            ent.Core_DeleteAgent(AgentId);
           
        }

        public IEnumerable<AgencyModel> FindSignUpAgentByNameOrCode(string name)
        {
            return ent.SignUpAgents.Where(x => ((x.AgentName.ToLower().Contains(name.ToUpper()) || x.AgentCode.ToLower().Contains(name.ToUpper())) && (x.isMigrated == false))).Take(10).ToList().Select(x =>
                                  new AgencyModel { AgencyName = x.AgentName, AgencyCode = x.AgentCode, AgentId = x.AgentId }
                                  );
        }

        public void UpdateSignUpAgent(int agentId, int PKAgentID)
        {
            SignUpAgents agent = ent.SignUpAgents.Where(x => x.AgentId == agentId).FirstOrDefault();
            agent.PKAgentId = PKAgentID;
            ent.ApplyCurrentValues(agent.EntityKey.EntitySetName, agent);
            ent.SaveChanges();
        }


        public int Create(AgencyModel model, List<AgentBankModel> AgentBankModel, int[] ChkProductId, FormCollection fc)
        {

            int AgentId = 0;
            AgentId = SaveAgent(model);
           
         
            model.AgentId = AgentId;
           CreateAgentUser(model, (int)ATLTravelPortal.Helpers.UserTypes.User);
           
           
            List<int> ChkProductIdS = new List<int>();
           
            foreach (int pid in ChkProductId)
            {
                ChkProductIdS.Add(pid);
             
                model.AgentRole = "Ticketing Agent";

                Roles.AddUserToRole(model.UserName, model.AgentRole);
            }

            AddAgentProduct(ChkProductIdS, AgentId);
            MembershipUser mem = Membership.GetUser(model.UserName);   
            Guid userGUId = new Guid(mem.ProviderUserKey.ToString());
            if (model.AgentStatusid == 0) 
            {

                pro.LockUserNow(model.UserName);
                Membership.UpdateUser(mem);
            }
            int AppUserId = GetUserDetails(userGUId); 
            AddUserProduct(ChkProductIdS, AppUserId);  
           
            if (ChkProductIdS.Contains(1))  
            {
                SaveAgentGeneralLedger(AgentId, 1, model.CreatedBy);
            }

          
            SaveAgentCoreConfiguration(AgentId, model.Email);

           
            if (model.MasterDealIdOfAirlines != 0)
            {
                SaveAgentDeal(model, AgentId, 1);
            }
            return AgentId;
        }


        public void SaveAgentDeal(AgencyModel modelTosave, int agentid, int ProductId)
        {
            Core_AgentsDeals datamodel = new Core_AgentsDeals();
           
            datamodel.AgentId = agentid;
            datamodel.ProductId = ProductId;
            if (ProductId == 1)
                datamodel.MasterDealId = modelTosave.MasterDealIdOfAirlines;
            else if (ProductId == 2)
                datamodel.MasterDealId = modelTosave.MasterDealIdOfHotel;

            datamodel.CreatedBy = modelTosave.CreatedBy;
            datamodel.CreatedDate = modelTosave.CreatedDate;


            ent.AddToCore_AgentsDeals(datamodel);
            ent.SaveChanges();


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
            ent.AddToCore_AgentConfiguration(datamodel);
            ent.SaveChanges();

        }

        public Agents GetAgentInfo(int ID)
        {
            return ent.Agents.SingleOrDefault(u => u.AgentId == ID);
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
            ent.AddToGL_Ledgers(datamodel);
            ent.SaveChanges();

        }

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

        public int GetUserDetails(Guid ID)
        {
            UsersDetails udetails = ent.UsersDetails.SingleOrDefault(u => u.UserId == ID);
            return udetails.AppUserId;
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

        private ActionResponse CreateAgentUser(AgencyModel model, int p)
        {
            UserManagementModel.CreateAspUser obj = new UserManagementModel.CreateAspUser();
            obj.UserName = model.UserName;
            obj.Password = model.Password;
            obj.Email = model.Email;
            obj.FullName = model.FullName;
            obj.Address = model.Address;
            obj.MobileNo = model.Mobile;
            obj.PhoneNo = model.Phone;
            obj.AgentId = model.AgentId;
            obj.CreatedBy = model.CreatedBy;
            _usRep.CreateUser(obj, (int)ATLTravelPortal.Helpers.UserTypes.User);
            return _res;
        }


        public int SaveAgent(AgencyModel modelTosave)
        {
            int AgentId = 0;
          

            Agents datamodel = new Agents
            {
                AgentName = modelTosave.AgencyName,
                NativeCountry = 1,
                ZoneId = modelTosave.State,
                Address = modelTosave.Address,
                DistrictId = modelTosave.City,
                Phone = modelTosave.Phone,
                Email = modelTosave.Email,
                FaxNo = modelTosave.FaxNo,
                Web = modelTosave.Web,
                PanNo = modelTosave.PanCardNo,
                AgentStatus = false,
                AgentTypeId = 1,
               // AgentCode = modelTosave.AgentCode,
                AgentClassId = null,
                AirlineGroupId =1,
                MaxNumberOfAgentUser = -1,
                AgentLogo = modelTosave.AgentLogo,
                CreatedBy = modelTosave.CreatedBy,
                CreatedDate = modelTosave.CreatedDate,
                TimeZoneId = modelTosave.TimeZoneId,
                DistributorId = 1,
                BranchOfficeId=1
            
            };
            ent.AddToAgents(datamodel);
            ent.SaveChanges();
            AgentId = datamodel.AgentId;
            _res.ErrNumber = 0;
           
            string AgentCode = UpdateAgentCode(AgentId);

            return AgentId;

        }

        public string UpdateAgentCode(int AgentId)
        {
            Agents agcode = ent.Agents.Where(u => u.AgentId == AgentId).FirstOrDefault();
            agcode.AgentCode = "AH-000" + AgentId;
            ent.ApplyCurrentValues(agcode.EntityKey.EntitySetName, agcode);
            ent.SaveChanges();
            return agcode.AgentCode;

        }

      



    }
}