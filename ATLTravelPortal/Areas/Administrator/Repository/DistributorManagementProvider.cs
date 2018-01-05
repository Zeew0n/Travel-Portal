using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ATLTravelPortal.Areas.Administrator.Models;
using TravelPortalEntity;
using System.Web.Mvc;
using ATLTravelPortal.Models;
using System.Web.Security;

namespace ATLTravelPortal.Areas.Administrator.Repository
{
    public class DistributorManagementProvider
    {
        private EntityModel entity = new EntityModel();
        private AgentManagementRepository agentManagementProvider = new AgentManagementRepository();
        private ActionResponse _res = new ATLTravelPortal.Models.ActionResponse();
        private UserManagementProvider _usRep = new UserManagementProvider();
        private AdminUserManagementRepository pro = new AdminUserManagementRepository();

        public DistributorManagementModel GetDistributorsList()
        {
            DistributorManagementModel returnViewModel = new DistributorManagementModel();

            List<DistributorManagementModel> viewModel = new List<DistributorManagementModel>();

            var distributors = entity.Distributors.Where(x => x.isSystem != true);
            foreach (var distributor in distributors)
            {
                DistributorManagementModel model = new DistributorManagementModel()
                {
                    DistributorId = distributor.DistributorId,
                    BranchOfficeId = distributor.BranchOfficeId,
                    BranchOfficeName = distributor.BranchOffices != null ? distributor.BranchOffices.BranchOfficeName + "(" + distributor.BranchOffices.BranchOfficeCode + ")" : string.Empty,
                    DistributorCode = distributor.DistributorCode,
                    DistributorName = distributor.DistributorName,
                    NativeCountryId = distributor.NativeCountryId,
                    NativeCountryName = string.Empty,
                    ZoneId = distributor.ZoneId,
                    ZoneName = distributor.Zones != null ? distributor.Zones.ZoneName : string.Empty,
                    DistrictId = distributor.DistrictId,
                    DistrictName = distributor.Districts != null ? distributor.Districts.DistrictName : string.Empty,
                    Address = distributor.Address,
                    Phone = distributor.Phone,
                    Email = distributor.Email,
                    FaxNo = distributor.FaxNo,
                    PanNo = distributor.PanNo,
                    Web = distributor.Web,                    
                    Status =Convert.ToInt32( distributor.Status),
                    TimeZoneId = distributor.TimeZoneId,
                    TimeZoneName = string.Empty,
                    isSystem = distributor.isSystem,
                    CreatedBy = distributor.CreatedBy,
                    CreatedDate = distributor.CreatedDate,
                };
                viewModel.Add(model);
            }

            returnViewModel.Distributors = viewModel;
            returnViewModel.StatusOption = new SelectList(agentManagementProvider.GetStatus(), "id", "Name", 1);

            return returnViewModel;
        }

        public DistributorManagementModel GetDistributorsModel(int distributorId)
        {

            var distributor = entity.Distributors.Where(x => x.DistributorId == distributorId).FirstOrDefault();

            DistributorManagementModel model = new DistributorManagementModel()
            {
                DistributorId = distributor.DistributorId,
                BranchOfficeId = distributor.BranchOfficeId,
                BranchOfficeName = distributor.BranchOffices != null ? distributor.BranchOffices.BranchOfficeName + "(" + distributor.BranchOffices.BranchOfficeCode + ")" : string.Empty,
                DistributorCode = distributor.DistributorCode,
                DistributorName = distributor.DistributorName,
                NativeCountryId = distributor.NativeCountryId,
                NativeCountryName = string.Empty,
                ZoneId = distributor.ZoneId,
                ZoneName = distributor.Zones != null ? distributor.Zones.ZoneName : string.Empty,
                DistrictId = distributor.DistrictId,
                DistrictName = distributor.Districts != null ? distributor.Districts.DistrictName : string.Empty,
                Address = distributor.Address,
                Phone = distributor.Phone,
                Email = distributor.Email,
                FaxNo = distributor.FaxNo,
                PanNo = distributor.PanNo,
                Web = distributor.Web,
                Status = Convert.ToInt32(distributor.Status),                
                TimeZoneId = distributor.TimeZoneId,
                TimeZoneName = string.Empty,
                isSystem = distributor.isSystem,
                CreatedBy = distributor.CreatedBy,
                CreatedDate = distributor.CreatedDate,


            };

            #region UserDetails

            View_DistributorDetails userDetails = GetDefaultUsersDetails(distributorId);
            if (userDetails != null)
            {
                model.FullName = userDetails.FullName;
                model.UserName = userDetails.UserName;
                model.Password = userDetails.Password;
                model.ConfirmPassword = userDetails.Password;
                model.UserEmail = userDetails.Email;
                model.UserAddress = userDetails.Address;
                model.UserMobileNo = userDetails.MobileNumber;
                model.UserPhoneNo = userDetails.Phone;
            }
            #endregion


            model.Countries = new SelectList(agentManagementProvider.GetCountry(), "CountryId", "CountryName", distributor.NativeCountryId);
            model.StatusOption = new SelectList(agentManagementProvider.GetStatus(), "id", "Name", distributor.Status);
            model.Zones = new SelectList(agentManagementProvider.GetZoneList(), "ZoneId", "ZoneName", distributor.ZoneId);
            model.Districts = new SelectList(agentManagementProvider.GetDistrictListbyZoneId(1), "DistrictId", "DistrictName", distributor.DistrictId);
            model.TimeZones = new SelectList(agentManagementProvider.GetTimeZoneList(), "RecordID", "StandardName", distributor.TimeZoneId);
            model.BranchOffices = new SelectList(GetBranchOffices(), "BranchOfficeId", "BranchOfficeName", distributor.BranchOfficeId);

            return model;
        }

        public DistributorManagementModel GetDistributorsDetailsModel(int distributorId)
        {
            var distributor = entity.Distributors.Where(x => x.DistributorId == distributorId).FirstOrDefault();

            DistributorManagementModel model = new DistributorManagementModel()
            {
                DistributorId = distributor.DistributorId,
                BranchOfficeId = distributor.BranchOfficeId,
                BranchOfficeName = distributor.BranchOffices != null ? distributor.BranchOffices.BranchOfficeName + "(" + distributor.BranchOffices.BranchOfficeCode + ")" : string.Empty,
                DistributorCode = distributor.DistributorCode,
                DistributorName = distributor.DistributorName,
                NativeCountryId = distributor.NativeCountryId,
                NativeCountryName = distributor.Countries != null ? distributor.Countries.CountryName + "(" + distributor.Countries.CountryCode + ")" : string.Empty,
                ZoneId = distributor.ZoneId,
                ZoneName = distributor.Zones != null ? distributor.Zones.ZoneName : string.Empty,
                DistrictId = distributor.DistrictId,
                DistrictName = distributor.Districts != null ? distributor.Districts.DistrictName : string.Empty,
                Address = distributor.Address,
                Phone = distributor.Phone,
                Email = distributor.Email,
                FaxNo = distributor.FaxNo,
                PanNo = distributor.PanNo,
                Web = distributor.Web,
                Status = Convert.ToInt32(distributor.Status),               
                TimeZoneId = distributor.TimeZoneId,
                TimeZoneName = distributor.TimeZones != null ? distributor.TimeZones.TimeZoneID : string.Empty,
                isSystem = distributor.isSystem,
                CreatedBy = distributor.CreatedBy,
                CreatedDate = distributor.CreatedDate,
            };


            #region UserDetails

            View_DistributorDetails userDetails = GetDefaultUsersDetails(distributorId);

            model.FullName = userDetails.FullName;
            model.UserName = userDetails.UserName;
            model.Password = userDetails.Password;
            model.ConfirmPassword = userDetails.Password;
            model.UserEmail = userDetails.Email;
            model.UserAddress = userDetails.Address;
            model.UserMobileNo = userDetails.MobileNumber;
            model.UserPhoneNo = userDetails.Phone;

            #endregion

            return model;
        }
      
        public View_DistributorDetails GetDefaultUsersDetails(int distributorId)
        {
            View_DistributorDetails result = entity.View_DistributorDetails.Where(x => x.DistributorId == distributorId).FirstOrDefault();
            return result;
        }

        public int SaveDistributorManagementModel(DistributorManagementModel model)
        {
            if (model.Password != model.ConfirmPassword)
            {
                _res.ActionMessage = "Registration failed! Either Enter Username or Your passwords must match, please re-enter and try again";
                _res.ErrNumber = 1011;
                _res.ResponseStatus = true;
            }

            int DistributerId = 0;
            _res = SaveDistributor(model, out DistributerId);

            /*------------ Begin of Saving Agent Authorize User  --------------------------------------------------------*/
            model.DistributorId = DistributerId;
            _res = CreateAgentUser(model, (int)ATLTravelPortal.Helpers.UserTypes.DistributorUser);
           
            /*Create User*/

            MembershipUser mem = Membership.GetUser(model.UserName);   // Call membership API for Getting UserId in GUID
            Guid userGUId = new Guid(mem.ProviderUserKey.ToString());
            if (model.Status == 0) ///If select status is deactive then Lockuser
            {
                pro.LockUserNow(model.UserName);
                Membership.UpdateUser(mem);
            }

            //Ledger Entry
            SaveDistributorLedger(model);
            return DistributerId;
        }

        public ActionResponse EditDistributedManagement(DistributorManagementModel model)
        {
            if (model.DistributorId == 0)
            {
                _res.ActionMessage = String.Format(Resources.Message.InvalidOperation, "Distributor");
                _res.ErrNumber = 1005;
                _res.ErrSource = "DataBase";
                _res.ErrType = "App";
                _res.ResponseStatus = true;
                goto End;
            }
            var obj = entity.Distributors.Where(x => x.DistributorId == model.DistributorId).FirstOrDefault();
            if (obj == null)
            {
                _res.ActionMessage = String.Format(Resources.Message.InvalidOperation, "Distributor");
                _res.ErrNumber = 1005;
                _res.ErrSource = "DataBase";
                _res.ErrType = "App";
                _res.ResponseStatus = true;
                goto End;
            }

            if (model.Status == 0) ///If select status is deactive then Lockuser
            {
                MembershipUser muUser = Membership.GetUser(model.UserName);
                pro.LockUserNow(model.UserName);
                Membership.UpdateUser(muUser);
            }
            else
            {
                MembershipUser muUser = Membership.GetUser(model.UserName);
                Membership.GetUser(model.UserName).UnlockUser();
                muUser.Email = model.UserEmail;

                Membership.UpdateUser(muUser);

                UsersDetails usersDetails = entity.UsersDetails.Where(x => x.UserId == (Guid)muUser.ProviderUserKey).FirstOrDefault();
                if (usersDetails != null)
                {
                    usersDetails.MobileNumber = model.UserMobileNo;
                    usersDetails.PhoneNumber = model.UserPhoneNo;
                    usersDetails.UserAddress = model.UserAddress;

                    entity.ApplyCurrentValues(usersDetails.EntityKey.EntitySetName, usersDetails);
                    entity.SaveChanges();
                }
            }
            UpdateDistributor(model);
            UpdateGeneralLegder(model);//Ledger Entry

            _res.ActionMessage = String.Format(Resources.Message.SuccessfullyUpdated, "Distributor");
            _res.ErrNumber = 0;
            _res.ResponseStatus = true;
            goto End;

        End:
            return _res;
        }

        public void UpdateDistributor(DistributorManagementModel model)
        {
            Distributors distributor = entity.Distributors.Where(u => u.DistributorId == model.DistributorId).FirstOrDefault();
            
            model.DistributorCode = distributor.DistributorCode;

            distributor.DistributorName = model.DistributorName;
            distributor.NativeCountryId = model.NativeCountryId;
            distributor.BranchOfficeId = model.BranchOfficeId;
            distributor.ZoneId = model.ZoneId;
            distributor.Address = model.Address;
            distributor.DistrictId = model.DistrictId;
            distributor.Phone = model.Phone;
            distributor.Email = model.Email;
            distributor.FaxNo = model.FaxNo;
            distributor.Web = model.Web;
            distributor.PanNo = model.PanNo;
            distributor.Status = Convert.ToBoolean(model.Status);
            distributor.TimeZoneId = model.TimeZoneId;
            distributor.UpdatedBy = model.UpdatedBy;
            distributor.UpdatedDate = DateTime.UtcNow;
            distributor.DistributorClassId = model.DistributorClassId;


            entity.ApplyCurrentValues(distributor.EntityKey.EntitySetName, distributor);
            entity.SaveChanges();
        }

        public List<BranchOffices> GetBranchOffices()
        {
            //return entity.BranchOffices.Where(x => x.isSystem != true).ToList();
            return entity.BranchOffices.ToList();
        }

        public ActionResponse SaveDistributor(DistributorManagementModel modelTosave, out int _AgentId)
        {
            int DistributorId = 0;
            if (IsDistributorCodeExists(modelTosave.DistributorId, modelTosave.DistributorCode) == true)
            {
                _res.ErrNumber = 1001;
                _res.ActionMessage = string.Format(Resources.Message.AlreadyExist, "Distributor Code");
                _res.ResponseStatus = true;
                goto End;
            }
            else if (IsDistributorNameExists(modelTosave.DistributorId, modelTosave.DistributorName) == true)
            {
                _res.ErrNumber = 1001;
                _res.ActionMessage = string.Format(Resources.Message.AlreadyExist, "Distributor Name");
                _res.ResponseStatus = true;
                goto End;
            }

            Distributors datamodel = new Distributors
            {
                DistributorName = modelTosave.DistributorName,
                NativeCountryId = modelTosave.NativeCountryId,
                BranchOfficeId = modelTosave.BranchOfficeId,
                ZoneId = modelTosave.ZoneId,
                Address = modelTosave.Address,
                DistrictId = modelTosave.DistrictId,
                Phone = modelTosave.Phone,
                Email = modelTosave.Email,
                FaxNo = modelTosave.FaxNo,
                Web = modelTosave.Web,
                PanNo = modelTosave.PanNo,
                Status = Convert.ToBoolean(modelTosave.Status),
                DistributorCode = modelTosave.DistributorCode,
                CreatedBy = modelTosave.CreatedBy,
                CreatedDate = DateTime.UtcNow,
                TimeZoneId = modelTosave.TimeZoneId,
                DistributorClassId = modelTosave.DistributorClassId,
            };
            entity.AddToDistributors(datamodel);
            entity.SaveChanges();
            DistributorId = datamodel.DistributorId;
            _res.ErrNumber = 0;
            //update agentcode here
            string AgentCode = UpdateDistributorCodeCode(DistributorId);
            _res.ActionMessage = "Distributor Successfully Created.  Distributor Code " + AgentCode;
            _res.ResponseStatus = true;
            goto End;

        End:
            _AgentId = DistributorId;
            return _res;

        }

        private bool IsDistributorCodeExists(int? Pid, string distributorCode)
        {
            var result = entity.Distributors.Where(x => x.DistributorCode == distributorCode.Trim().ToLower() && x.DistributorId != Pid).FirstOrDefault();
            if (result == null)
                return false;
            else
                return true;
        }

        private bool IsDistributorNameExists(int? Pid, string distributorName)
        {
            var result = entity.Distributors.Where(x => x.DistributorName == distributorName.Trim().ToLower() && x.DistributorId != Pid).FirstOrDefault();
            if (result == null)
                return false;
            else
                return true;
        }

        public string UpdateDistributorCodeCode(int AgentId)
        {
            Distributors agcode = entity.Distributors.Where(u => u.DistributorId == AgentId).FirstOrDefault();
            string code = AgentId.ToString().PadLeft(4, '0');

            agcode.DistributorCode = "AHD-" + code;
            entity.ApplyCurrentValues(agcode.EntityKey.EntitySetName, agcode);
            entity.SaveChanges();
            return agcode.DistributorCode;
        }

        private ActionResponse CreateAgentUser(DistributorManagementModel model, int p)
        {
            UserManagementModel.CreateAspUser obj = new UserManagementModel.CreateAspUser();
            obj.UserName = model.UserName;
            obj.Password = model.Password;
            obj.Email = model.UserEmail;
            obj.FullName = model.FullName;
            obj.Address = model.UserAddress;
            obj.MobileNo = model.UserMobileNo;
            obj.PhoneNo = model.UserPhoneNo;
            obj.AgentId = model.DistributorId;
            obj.CreatedBy = model.CreatedBy;
            _usRep.CreateUser(obj, (int)ATLTravelPortal.Helpers.UserTypes.DistributorUser);
            return _res;
        }

        public void SaveDistributorLedger(DistributorManagementModel model)
        {
            DistributorManagementModel distributorsDetails = GetDistributorsDetailsModel(model.DistributorId);

            GL_Ledgers datamodel = new GL_Ledgers
            {
                Id = model.DistributorId,
                ProductId = 1,
                AccGroupId = 1,
                AccSubGroupId = 1,
                AccTypeId = 9,
                LedgerName = distributorsDetails.DistributorName + " " + distributorsDetails.DistributorCode,
                CreatedBy = model.CreatedBy,
                CreatedDate = DateTime.UtcNow,

            };
            entity.AddToGL_Ledgers(datamodel);
            entity.SaveChanges();
        }

        public void UpdateGeneralLegder(DistributorManagementModel model)
        {
            GL_Ledgers led = entity.GL_Ledgers.Where(x => x.Id == model.DistributorId && x.AccTypeId == 9).FirstOrDefault();
            led.LedgerName = model.DistributorName + " " + model.DistributorCode;
            entity.ApplyCurrentValues(led.EntityKey.EntitySetName, led);
            entity.SaveChanges();
        }

        public View_DistributorDetails GetDistributorByUserId(Guid userId)
        {
            return entity.View_DistributorDetails.Where(x => x.UserId == userId).FirstOrDefault();
        }

        public DistributorManagementModel GetBranchDistributorsList(int BranchOfficeId)
        {
            DistributorManagementModel returnViewModel = new DistributorManagementModel();

            List<DistributorManagementModel> viewModel = new List<DistributorManagementModel>();

            var distributors = entity.Distributors.Where(x => (x.BranchOfficeId == BranchOfficeId));
            foreach (var distributor in distributors)
            {
                DistributorManagementModel model = new DistributorManagementModel()
                {
                    DistributorId = distributor.DistributorId,
                    BranchOfficeId = distributor.BranchOfficeId,
                    BranchOfficeName = distributor.BranchOffices != null ? distributor.BranchOffices.BranchOfficeName + "(" + distributor.BranchOffices.BranchOfficeCode + ")" : string.Empty,
                    DistributorCode = distributor.DistributorCode,
                    DistributorName = distributor.DistributorName,
                    NativeCountryId = distributor.NativeCountryId,
                    NativeCountryName = string.Empty,
                    ZoneId = distributor.ZoneId,
                    ZoneName = distributor.Zones != null ? distributor.Zones.ZoneName : string.Empty,
                    DistrictId = distributor.DistrictId,
                    DistrictName = distributor.Districts != null ? distributor.Districts.DistrictName : string.Empty,
                    Address = distributor.Address,
                    Phone = distributor.Phone,
                    Email = distributor.Email,
                    FaxNo = distributor.FaxNo,
                    PanNo = distributor.PanNo,
                    Web = distributor.Web,
                    Status = Convert.ToInt32(distributor.Status),
                    TimeZoneId = distributor.TimeZoneId,
                    TimeZoneName = string.Empty,
                    isSystem = distributor.isSystem,
                    CreatedBy = distributor.CreatedBy,
                    CreatedDate = distributor.CreatedDate,
                };
                viewModel.Add(model);
            }

            returnViewModel.Distributors = viewModel;
            returnViewModel.StatusOption = new SelectList(agentManagementProvider.GetStatus(), "id", "Name", 1);

            return returnViewModel;
        }

        public IEnumerable<Agents> GetAllAgentsByDistributorId(int distributorId)
        {
            return entity.Agents.Where(x => x.CreatedBy == distributorId);
        }

        public Distributors GetDistributorByDistributorId(int distributorId)
        {
            return entity.Distributors.Where(x => x.DistributorId == distributorId).FirstOrDefault();
        }

        public DistributorManagementModel GetBranchDistributorsByBranchOfficeId(int branchOfficeId)
        {
            DistributorManagementModel returnViewModel = new DistributorManagementModel();

            List<DistributorManagementModel> viewModel = new List<DistributorManagementModel>();

            var distributors = entity.Distributors.Where(x => (x.isSystem != true && x.BranchOfficeId == branchOfficeId));

            foreach (var distributor in distributors)
            {
                DistributorManagementModel model = new DistributorManagementModel()
                {
                    DistributorId = distributor.DistributorId,
                    BranchOfficeId = distributor.BranchOfficeId,
                    BranchOfficeName = distributor.BranchOffices != null ? distributor.BranchOffices.BranchOfficeName + "(" + distributor.BranchOffices.BranchOfficeCode + ")" : string.Empty,
                    DistributorCode = distributor.DistributorCode,
                    DistributorName = distributor.DistributorName,
                    NativeCountryId = distributor.NativeCountryId,
                    NativeCountryName = string.Empty,
                    ZoneId = distributor.ZoneId,
                    ZoneName = distributor.Zones != null ? distributor.Zones.ZoneName : string.Empty,
                    DistrictId = distributor.DistrictId,
                    DistrictName = distributor.Districts != null ? distributor.Districts.DistrictName : string.Empty,
                    Address = distributor.Address,
                    Phone = distributor.Phone,
                    Email = distributor.Email,
                    FaxNo = distributor.FaxNo,
                    PanNo = distributor.PanNo,
                    Web = distributor.Web,
                    Status = Convert.ToInt32(distributor.Status),
                    TimeZoneId = distributor.TimeZoneId,
                    TimeZoneName = string.Empty,
                    isSystem = distributor.isSystem,
                    CreatedBy = distributor.CreatedBy,
                    CreatedDate = distributor.CreatedDate,
                };
                viewModel.Add(model);
            }

            returnViewModel.Distributors = viewModel;
           
            return returnViewModel;
        }



        public List<DistributorManagementModel> BranchDistributorsByBranchOfficeId(int branchOfficeId)
        {
            var result = entity.Distributors.Where(x => (x.isSystem != true && x.BranchOfficeId == branchOfficeId));
            List<DistributorManagementModel> model = new List<DistributorManagementModel>();
            foreach (var item in result)
            {
                DistributorManagementModel obj = new DistributorManagementModel
                {
                    DistributorId = item.DistributorId,
                    BranchOfficeId = item.BranchOfficeId,
                    BranchOfficeName = item.BranchOffices != null ? item.BranchOffices.BranchOfficeName + "(" + item.BranchOffices.BranchOfficeCode + ")" : string.Empty,
                    DistributorCode = item.DistributorCode,
                    DistributorName = item.DistributorName,
                    NativeCountryId = item.NativeCountryId,
                    NativeCountryName = string.Empty,
                    ZoneId = item.ZoneId,
                    ZoneName = item.Zones != null ? item.Zones.ZoneName : string.Empty,
                    DistrictId = item.DistrictId,
                    DistrictName = item.Districts != null ? item.Districts.DistrictName : string.Empty,
                    Address = item.Address,
                    Phone = item.Phone,
                    Email = item.Email,
                    FaxNo = item.FaxNo,
                    PanNo = item.PanNo,
                    Web = item.Web,
                    Status = Convert.ToInt32(item.Status),
                    TimeZoneId = item.TimeZoneId,
                    TimeZoneName = string.Empty,
                    isSystem = item.isSystem,
                    CreatedBy = item.CreatedBy,
                    CreatedDate = item.CreatedDate,

                };
                model.Add(obj);
            }
            return model.OrderBy(x => x.DistributorName).ToList();
        }


        public List<DistributorAgentManagementModel> AgentsListByBranchOfficeId()
        {
            var result = entity.Agents;
            List<DistributorAgentManagementModel> model = new List<DistributorAgentManagementModel>();
            foreach (var item in result)
            {
                DistributorAgentManagementModel obj = new DistributorAgentManagementModel
                {
                    AgentId = item.AgentId,
                    AgentName = item.AgentName,
                    AgencyCode = item.AgentCode,
                    BranchOfficeId = item.BranchOffices.BranchOfficeId != 0? item.BranchOffices.BranchOfficeId : 0,
                    DistributorId = item.Distributors.DistributorId != 0 ? item.Distributors.DistributorId : 0,
                    BranchOfficeName = item.BranchOffices != null ? item.BranchOffices.BranchOfficeName + "(" + item.BranchOffices.BranchOfficeCode + ")" : string.Empty,
                   DistributorName = item.Distributors != null ? item.Distributors.DistributorName + "(" + item.Distributors.DistributorCode + ")" : string.Empty,
                    Phone = item.Phone,
                    CreatedOn = item.CreatedDate
                };
                model.Add(obj);
            }
            return model.OrderBy(x => x.AgentName).ToList();
        }



        public ActionResponse Delete(int? id)
        {
            if (id == null)
            {
                _res.ActionMessage = String.Format(Resources.Message.InvalidOperation, "Distributor Management");
                _res.ErrNumber = 1005;
                _res.ErrSource = "DataBase";
                _res.ErrType = "App";
                _res.ResponseStatus = true;
                goto End;
            }
            var obj = entity.Distributors.Where(x => x.DistributorId == id).FirstOrDefault();
            if (obj == null)
            {
                _res.ActionMessage = String.Format(Resources.Message.InvalidOperation, "Distributor Management");
                _res.ErrNumber = 1005;
                _res.ErrSource = "DataBase";
                _res.ErrType = "App";
                _res.ResponseStatus = true;
                goto End;
            }
            entity.Core_DeleteDistributor(id);
            _res.ActionMessage = String.Format(Resources.Message.SuccessfullyDeleted, "DistributorManagement");
            _res.ErrNumber = 0;
            _res.ErrSource = "DataBase";
            _res.ErrType = "App";
            _res.ResponseStatus = true;
            goto End;
        End:
            return _res;
        }
    }
}
