using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TravelPortalEntity;
using ATLTravelPortal.Areas.Administrator.Models;

namespace ATLTravelPortal.Areas.Administrator.Repository
{
    public class B2CUserManagementProvider
    {
        EntityModel ent = new EntityModel();

        public IQueryable<vw_aspnet_MembershipUsers> ListAllB2CUser()
        {

            return ent.vw_aspnet_MembershipUsers.Where(x => x.UserTypeId == 3).AsQueryable();
        }
        public List<B2CUserManagementModel> GetAllB2CUserList()
        {
            var cc = (from aa in ListAllB2CUser()
                      select new B2CUserManagementModel
                      {
                          AgentName = aa.AgentName,
                          UserName = aa.UserName,
                          Email = aa.Email,
                          IsApproved = aa.IsApproved,
                          UserId = aa.UserId,
                          IsLockedOut = aa.IsLockedOut,
                          Mobile = aa.MobileNumber,
                          Phone = aa.PhoneNumber,
                          Address = aa.UserAddress,
                          FullName = aa.FullName,
                          CreatedDate = aa.CreateDate,
                          

                      }).ToList();
            return cc.OrderByDescending(x=>x.CreatedDate).ToList();
        }

        public void LockUserNow(String UserName)
        {
            var obj = ent.aspnet_Membership.Where(x => x.aspnet_Users.UserName == UserName).ToList().LastOrDefault();
            obj.IsLockedOut = true;
            ent.ApplyCurrentValues(obj.EntityKey.EntitySetName, obj);
            ent.SaveChanges();
        }

        //public UsersDetails GetUserDetails(Guid ID)
        //{
        //    return ent.UsersDetails.SingleOrDefault(u => u.UserId == ID);
        //}


        public B2CUserManagementModel GetUserDetails(Guid ID)
        {
            var result = ent.UsersDetails.SingleOrDefault(u => u.UserId == ID);
            var emailresult = ent.aspnet_Membership.SingleOrDefault(u => u.UserId == ID);
            B2CUserManagementModel model = new B2CUserManagementModel();
            model.FullName = result.FullName;
            model.Address = result.UserAddress;
            model.Mobile = result.MobileNumber;
            model.Phone = result.PhoneNumber;
            model.Email = emailresult.Email;

            return model;

        }

        public B2CUserManagementModel GetEmail(Guid ID)
        {
            var result = ent.aspnet_Membership.SingleOrDefault(u => u.UserId == ID);
            B2CUserManagementModel model = new B2CUserManagementModel();
            model.Email = result.Email;
           
            return model;

        }



        public aspnet_Users GetUserinfo(Guid ID)
        {
            return ent.aspnet_Users.SingleOrDefault(u => u.UserId == ID);
        }
        //public aspnet_Membership GetEmail(Guid id)
        //{
        //    return ent.aspnet_Membership.SingleOrDefault(u => u.UserId == id);
        //}
        public void UpdateEmail(B2CUserManagementModel model)
        {
            aspnet_Membership tu = ent.aspnet_Membership.Where(u => u.UserId == model.UserId).FirstOrDefault();
            tu.UserId = model.UserId;
            tu.Email = model.GetEmail.Email;
            tu.LoweredEmail = model.GetEmail.Email;
            ent.ApplyCurrentValues(tu.EntityKey.EntitySetName, tu);
            ent.SaveChanges();
        }
        public void EditUserInfo(B2CUserManagementModel model)
        {
            UsersDetails result = ent.UsersDetails.Where(x => x.UserId == model.UserId).FirstOrDefault();
            result.UserAddress = model.Address;
            result.PhoneNumber = model.Phone;
            result.MobileNumber = model.Mobile;
            result.FullName = model.FullName;

            ent.ApplyCurrentValues(result.EntityKey.EntitySetName, result);
            ent.SaveChanges();
        }

        public UsersDetails Details(Guid ID)
        {
            return ent.UsersDetails.SingleOrDefault(u => u.UserId == ID);
        }


    }
}