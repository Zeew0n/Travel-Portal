using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TravelPortalEntity;
using ATLTravelPortal.Areas.Administrator.Models;
using System.Web.Security;

namespace ATLTravelPortal.Areas.Administrator.Repository
{
    public class BranchOfficeManagementProvider
    {
        EntityModel ent = new EntityModel();
        AdminUserManagementRepository pro = new AdminUserManagementRepository();
        AgentdetailsProvider _agentdetailsprovider = new AgentdetailsProvider();


        public View_BranchDetails GetBranchOfficeByUserId(Guid userId)
        {
            return ent.View_BranchDetails.Where(x => x.UserId == userId).FirstOrDefault();
        }


        public List<BranchOfficeManagementModel> ListBranchOfficeManagement()
        {
            var result = ent.BranchOffices.Where(x => x.isSystem == false);
            List<BranchOfficeManagementModel> model = new List<BranchOfficeManagementModel>();
            foreach (var item in result)
            {
                BranchOfficeManagementModel obj = new BranchOfficeManagementModel
                {
                    BranchOfficeId = item.BranchOfficeId,
                    BranchOfficeCode = item.BranchOfficeCode,
                    BranchOffice = item.BranchOfficeName,
                    NativeCountry = item.NativeCountryId,
                    NativeCountryName = item.Countries.CountryName,
                    Zone = item.ZoneId,
                    ZoneName = item.Zones.ZoneName,
                    District = item.DistrictId,
                    DistrictName = item.Districts.DistrictName,
                    Address = item.Address,
                    Phone = item.Phone,
                    Email = item.Email,
                    Fax = item.FaxNo,
                    PanNo = item.PanNo,
                    Web = item.Web,
                    status = Convert.ToInt32(item.Status),
                    TimeZone = item.TimeZoneId,
                    isSystem = item.isSystem,
                    CreatedBy = item.CreatedBy,
                    CreatedDate = item.CreatedDate,
                    UpdatedBy = item.UpdatedBy,
                    UpdatedDate = item.UpdatedDate

                };
                model.Add(obj);
            }
            return model.OrderBy(x => x.CreatedDate).ToList();
        }

        public List<BranchOfficeManagementModel> GetBranchOfficeSearchResult(string BranchOfficeName)
        {

            var result = ent.BranchOffices.Where(x => (x.BranchOfficeName.Contains(BranchOfficeName)) || (x.BranchOfficeCode.Contains(BranchOfficeName)));
            List<BranchOfficeManagementModel> model = new List<BranchOfficeManagementModel>();
            foreach (var item in result)
            {
                BranchOfficeManagementModel obj = new BranchOfficeManagementModel
                {
                    BranchOfficeId = item.BranchOfficeId,
                    BranchOfficeCode = item.BranchOfficeCode,
                    BranchOffice = item.BranchOfficeName,
                    NativeCountry = item.NativeCountryId,
                    NativeCountryName = item.Countries.CountryName,
                    Zone = item.ZoneId,
                    ZoneName = item.Zones.ZoneName,
                    District = item.DistrictId,
                    DistrictName = item.Districts.DistrictName,
                    Address = item.Address,
                    Phone = item.Phone,
                    Email = item.Email,
                    Fax = item.FaxNo,
                    PanNo = item.PanNo,
                    Web = item.Web,
                    status = Convert.ToInt32(item.Status),
                    TimeZone = item.TimeZoneId,
                    isSystem = item.isSystem,
                    CreatedBy = item.CreatedBy,
                    CreatedDate = item.CreatedDate,
                    UpdatedBy = item.UpdatedBy,
                    UpdatedDate = item.UpdatedDate
                };
                model.Add(obj);
            }
            return model;
        }



        public BranchOfficeManagementModel BranchOfficeManagementDetail(int BranchOfficeId)
        {
            BranchOffices result = ent.BranchOffices.Where(x => x.BranchOfficeId == BranchOfficeId).FirstOrDefault();
            View_AgentDetails Agentadmindetails = _agentdetailsprovider.GetAgentAdminUser(BranchOfficeId);

            BranchOfficeManagementModel model = new BranchOfficeManagementModel();

            model.BranchOfficeId = result.BranchOfficeId;
            model.BranchOfficeId = result.BranchOfficeId;
            model.BranchOfficeCode = result.BranchOfficeCode;
            model.BranchOffice = result.BranchOfficeName;
            model.NativeCountry = result.NativeCountryId;
            model.NativeCountryName = result.Countries.CountryName;
            model.Zone = result.ZoneId;
            model.ZoneName = result.Zones.ZoneName;
            model.District = result.DistrictId;
            model.DistrictName = result.Districts.DistrictName;
            model.Address = result.Address;
            model.Phone = result.Phone;
            model.Email = result.Email;
            model.Fax = result.FaxNo;
            model.PanNo = result.PanNo;
            model.Web = result.Web;
            model.status = Convert.ToInt32(result.Status);
            model.TimeZone = result.TimeZoneId;
            model.isSystem = result.isSystem;
            model.CreatedBy = result.CreatedBy;
            model.CreatedDate = result.CreatedDate;
            model.UpdatedBy = result.UpdatedBy;
            model.UpdatedDate = result.UpdatedDate;


            View_BranchDetails BranchUserDetail = GetBranchUserDetails(BranchOfficeId);
            if (BranchUserDetail != null)
            {
                model.FullName = BranchUserDetail.FullName;
                model.UserName = BranchUserDetail.UserName;
                model.UserEmail = BranchUserDetail.Email;
                model.UserAddress = BranchUserDetail.UserAddress;
                model.UserPhone = BranchUserDetail.Phone;
                model.MobileNo = BranchUserDetail.MobileNumber;
                model.Password = BranchUserDetail.Password;
                model.ConfirmPassword = BranchUserDetail.Password;
            }

            return model;

        }

        public View_BranchDetails GetBranchUserDetails(int BranchOfficeId)
        {
            View_BranchDetails BranchUserDetails = ent.View_BranchDetails.Where(uu => (uu.BranchOfficeId == BranchOfficeId && uu.UserTypeId == 5)).FirstOrDefault();

            return BranchUserDetails;
        }



        public IQueryable<BranchOffices> GetAll()
        {
            return ent.BranchOffices.OrderByDescending(xx => xx.BranchOfficeId).AsQueryable();


        }



        public IQueryable<BranchOffices> GetAllAgentByPaging()
        {

            IQueryable<BranchOffices> pagingdata = GetAll().OrderBy(t => t.BranchOfficeName).AsQueryable();
            return pagingdata;
        }



        public int Create(BranchOfficeManagementModel model)
        {
            int BranchOfficeId = CreateBranchOfficeManagement(model);

            model.BranchOfficeId = BranchOfficeId;
            CreateBranchOfficeUser(model, (int)ATLTravelPortal.Helpers.UserTypes.User);
            MembershipUser mem = Membership.GetUser(model.UserName);
            Guid userGUId = new Guid(mem.ProviderUserKey.ToString());
            if (model.status == 0)
            {

                pro.LockUserNow(model.UserName);
                Membership.UpdateUser(mem);
            }
            int AppUserId = GetUserDetails(userGUId);

            SaveBranchOfficeLedger(model.BranchOfficeId, 1, model.CreatedBy);

            return BranchOfficeId;

        }

        public void SaveBranchOfficeLedger(int BranchOfficeId, int ProductId, int CreatedBy)
        {
            var BranchOfficeDetails = GetBranchOfficeInfo(BranchOfficeId);
            GL_Ledgers datamodel = new GL_Ledgers
            {
                Id = BranchOfficeId,
                ProductId = ProductId,
                AccGroupId = 1,
                AccSubGroupId = 1,
                AccTypeId = 8,
                LedgerName = BranchOfficeDetails.BranchOfficeName + " " + BranchOfficeDetails.BranchOfficeCode,
                CreatedBy = CreatedBy,
                CreatedDate = DateTime.Now,

            };
            ent.AddToGL_Ledgers(datamodel);
            ent.SaveChanges();

        }

        public BranchOffices GetBranchOfficeInfo(int ID)
        {
            return ent.BranchOffices.SingleOrDefault(u => u.BranchOfficeId == ID);
        }


        public int GetUserDetails(Guid ID)
        {
            UsersDetails udetails = ent.UsersDetails.SingleOrDefault(u => u.UserId == ID);
            return udetails.AppUserId;
        }



        private void CreateBranchOfficeUser(BranchOfficeManagementModel model, int p)
        {
            UserManagementProvider _usRep = new UserManagementProvider();
            UserManagementModel.CreateAspUser obj = new UserManagementModel.CreateAspUser();
            obj.UserName = model.UserName;
            obj.Password = model.Password;
            obj.Email = model.UserEmail;
            obj.FullName = model.FullName;
            obj.Address = model.UserAddress;
            obj.MobileNo = model.MobileNo;
            obj.PhoneNo = model.UserPhone;
            obj.AgentId = model.BranchOfficeId;
            obj.CreatedBy = model.CreatedBy;
            _usRep.CreateUser(obj, (int)ATLTravelPortal.Helpers.UserTypes.BranchUser);
        }



        public int CreateBranchOfficeManagement(BranchOfficeManagementModel model)
        {

            int BranchOfficeId = 0;
            BranchOffices obj = new BranchOffices();

            obj.BranchOfficeName = model.BranchOffice;
            obj.NativeCountryId = model.NativeCountry;
            obj.ZoneId = model.Zone;
            obj.DistrictId = model.District;
            obj.Address = model.Address;
            obj.Phone = model.Phone;
            obj.Email = model.Email;
            obj.FaxNo = model.Fax;
            obj.PanNo = model.PanNo;
            obj.Web = model.Web;
            obj.Status = Convert.ToBoolean(model.status);
            obj.TimeZoneId = model.TimeZone;
            obj.isSystem = model.isSystem;
            obj.CreatedBy = model.CreatedBy;
            obj.CreatedDate = DateTime.UtcNow;
            obj.BranchClassId = model.BranchClassId;
            ent.AddToBranchOffices(obj);
            ent.SaveChanges();

            BranchOfficeId = obj.BranchOfficeId;
            string BranchOfficeCode = UpdateBranchOfficeCode(BranchOfficeId);
            return BranchOfficeId;
        }


        public string UpdateBranchOfficeCode(int BranchOfficeId)
        {
            BranchOffices branchofficecode = ent.BranchOffices.Where(u => u.BranchOfficeId == BranchOfficeId).FirstOrDefault();
            string code = BranchOfficeId.ToString().PadLeft(4, '0');
            branchofficecode.BranchOfficeCode = "AHB-" + code;
            ent.ApplyCurrentValues(branchofficecode.EntityKey.EntitySetName, branchofficecode);
            ent.SaveChanges();
            return branchofficecode.BranchOfficeCode;



        }



        public void Edit(int? id, BranchOfficeManagementModel model)
        {
            if (model.status == 0)
            {
                MembershipUser muUser = Membership.GetUser(model.UserName);
                pro.LockUserNow(model.UserName);
                Membership.UpdateUser(muUser);
            }
            else
            {
                MembershipUser muUser = Membership.GetUser(model.UserName);
                Membership.GetUser(model.UserName).UnlockUser();
                muUser.Email = model.Email;

                Membership.UpdateUser(muUser);

                UsersDetails usersDetails = ent.UsersDetails.Where(x => x.UserId == (Guid)muUser.ProviderUserKey).FirstOrDefault();
                if (usersDetails != null)
                {
                    usersDetails.MobileNumber = model.MobileNo;
                    usersDetails.PhoneNumber = model.UserPhone;
                    usersDetails.UserAddress = model.UserAddress;

                    ent.ApplyCurrentValues(usersDetails.EntityKey.EntitySetName, usersDetails);
                    ent.SaveChanges();
                }
            }

            EditBranchOfficeManagement(model);
        }



        public void EditBranchOfficeManagement(BranchOfficeManagementModel model)
        {
            BranchOffices result = ent.BranchOffices.Where(x => x.BranchOfficeId == model.BranchOfficeId).FirstOrDefault();
            model.BranchOfficeCode = result.BranchOfficeCode;
            result.BranchOfficeId = model.BranchOfficeId;
            result.BranchOfficeName = model.BranchOffice;
            result.NativeCountryId = model.NativeCountry;
            result.ZoneId = model.Zone;
            result.DistrictId = model.District;
            result.Address = model.Address;
            result.Phone = model.Phone;
            result.Email = model.Email;
            result.FaxNo = model.Fax;
            result.PanNo = model.PanNo;
            result.Web = model.Web;
            result.Status = Convert.ToBoolean(model.status);
            result.TimeZoneId = model.TimeZone;
            result.isSystem = model.isSystem;
            result.UpdatedBy = model.UpdatedBy;
            result.UpdatedDate = DateTime.UtcNow;
            result.BranchClassId = model.BranchClassId;

            ent.ApplyCurrentValues(result.EntityKey.EntitySetName, result);
            ent.SaveChanges();

            UpdateGeneralLegder(model);
        }

        public void UpdateGeneralLegder(BranchOfficeManagementModel model)
        {
            GL_Ledgers led = ent.GL_Ledgers.Where(x => x.Id == model.BranchOfficeId && x.AccTypeId == 8).FirstOrDefault();
            led.LedgerName = model.BranchOffice + " " + model.BranchOfficeCode;
            ent.ApplyCurrentValues(led.EntityKey.EntitySetName, led);
            ent.SaveChanges();
        }

        public void DeleteBranchOfficeManagement(int BranchOfficeId)
        {
            ent.Core_DeleteBrachOffice(BranchOfficeId);
        }

        public bool CheckDuplicateEmail(string email)
        {
            BranchOffices BranchOffice = ent.BranchOffices.Where(ii => ii.Email == email).FirstOrDefault();
            if (BranchOffice != null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool CheckEditDuplicateEmail(string email, int branchofficeid)
        {
            BranchOffices branchoffice = ent.BranchOffices.Where(ii => ii.Email == email && ii.BranchOfficeId != branchofficeid).FirstOrDefault();
            if (branchoffice == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }




        public bool CheckEditDuplicateMobileNumber(string MobileNumber, int BranchUserId)
        {
            View_BranchDetails View_BranchDetails = ent.View_BranchDetails.Where(ii => ii.BranchOfficeId == BranchUserId).FirstOrDefault();
            if (View_BranchDetails != null)
            {
                UsersDetails usersDetails = ent.UsersDetails.Where(ii => ii.MobileNumber == MobileNumber && ii.UserId != View_BranchDetails.UserId).FirstOrDefault();

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



        public IEnumerable<BranchOffices> FindBranchOfficeNameOrCode(string name)
        {
            return ent.BranchOffices.Where(x => (x.BranchOfficeName.ToLower().Contains(name.ToUpper()) || x.BranchOfficeCode.ToLower().Contains(name.ToUpper()))).Take(10).ToList().Select(x =>
                                  new BranchOffices { BranchOfficeName = x.BranchOfficeName, BranchOfficeCode = x.BranchOfficeCode, BranchOfficeId = x.BranchOfficeId }
                                  );
        }




        public bool CheckDuplicateBranchUsername(string userName)
        {
            aspnet_Users Email = ent.aspnet_Users.Where(ii => ii.UserName == userName).FirstOrDefault();
            if (Email != null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }


        public List<BranchOffices> GetBranchOfficeName(string BranchOfficeName, int maxResult)
        {
            return GetAllBranchOfficeList(BranchOfficeName, maxResult).ToList();
        }

        public IEnumerable<BranchOffices> GetAllBranchOfficeList(string name, int maxResult)
        {
            return ent.BranchOffices.Where(x => (x.BranchOfficeName.ToLower().Contains(name.ToUpper()) || x.BranchOfficeCode.ToLower().Contains(name.ToUpper()))).Take(10).ToList().Select(x =>
                                 new BranchOffices { BranchOfficeName = x.BranchOfficeName, BranchOfficeCode = x.BranchOfficeCode, BranchOfficeId = x.BranchOfficeId }
                                 );
        }

        public List<BranchOffices> GetAllBranchOfficeSearchResult(string BranchOfficeName)
        {

            var result = ent.BranchOffices.Where(x => (x.BranchOfficeName.Contains(BranchOfficeName)) || (x.BranchOfficeCode.Contains(BranchOfficeName)));

            return result.ToList();

        }


        public bool CheckDuplicateBranchName(string BranchName)
        {
            BranchOffices Branch = ent.BranchOffices.Where(ii => ii.BranchOfficeName == BranchName).FirstOrDefault();
            if (Branch != null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }


        public IEnumerable<Agents> GetAllAgentsByBranchOfficeId(int branchOfficeId)
        {
            var distributors = ent.Distributors.Where(x => x.BranchOfficeId == branchOfficeId);
            List<Agents> agentList = new List<Agents>();

            foreach (Distributors distributor in distributors)
            {
                int appUserId = GetAppUserIdByDistributorId(distributor.DistributorId);
                var agents = ent.Agents.Where(x => x.CreatedBy == appUserId);
                agentList.AddRange(agents);
            }
            return agentList;
        }

        public int GetAppUserIdByDistributorId(int distributorId)
        {
            var aspnetUsersRelation = ent.aspnet_UsersRelation.Where(x => x.Id == distributorId && x.Type == 2).FirstOrDefault();
            if (aspnetUsersRelation != null)
            {
                var result = ent.UsersDetails.Where(x => x.UserId == aspnetUsersRelation.UserId).FirstOrDefault();
                if (result != null)
                {
                    return result.AppUserId;
                }
            }
            return 0;
        }
    }
}