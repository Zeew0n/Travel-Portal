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
using ATLTravelPortal.Areas.Airline.Models;
using TravelPortalEntity;


namespace ATLTravelPortal.Areas.Airline.Repository
{
    public class UserRolePrevilageProvider
    {
        EntityModel ent = new EntityModel();

        public void SaveUserTypeMapping(List<UserTypeControllerMappings> obj)
        {

            foreach (var item in obj)
            {
                ent.UserTypeControllerMappings.AddObject(new UserTypeControllerMappings()
                {
                    
                    UserTypeId = item.UserTypeId,
                    ControllerId = item.ControllerId,
                });
            }
            ent.SaveChanges();
        }

        public IEnumerable<UserTypeControllerMappings> UserTypeMappingList()
        {
            return ent.UserTypeControllerMappings.AsEnumerable();
        }

        public List<UserTypes> GetUserTypeList()
        {
           return ent.UserTypes.Where(tt => tt.UserTypeId != 1).ToList();
        }
       

        public List<UserTypeControllerMappings> GetUserTypeControllerMappingControllerId(int controllerId)
        {
            var mappingDetail = ent.UserTypeControllerMappings.Where(p => p.ControllerId == controllerId).ToList();
            return mappingDetail;
        }

        public IEnumerable<UserTypeModel> GetUserTypemappingList()
        {
            var cc = (from aa in ent.ControllerLists
                      join bb in ent.ControllerGroups
                      on aa.ControllerGroupId equals bb.ControllerGroupId
                      select new UserTypeModel
                      {
                          ControllerGroupId=aa.ControllerGroupId,
                          ControllerGroupName =bb.ControllerGroupName,
                          ControllerId = aa.ControllerId,
                          ControllerLabel = aa.ControllerLabel
                      }).ToList();
            return cc;
//=======
//            List<UserTypeModel> list = new List<UserTypeModel>();
//            foreach (var item in ent.ControllerLists)
//            {
//                var tempModel = new UserTypeModel
//                {
//                    ControllerId = item.ControllerId,
//                    ControllerLabel =item.ControllerLabel,
//                    //ControllerName=item.ControllerName
//                };
//                list.Add(tempModel);
//            }
//            return list.AsEnumerable();
//            //return ent.UserTypeControllerMappings;
//>>>>>>> .r1558
        }


        public List<UserTypeModel> GetControllerListByUserType(int UserTypes)
        {
            var cc = (from aa in ent.ControllerLists
                      join bb in ent.UserTypeControllerMappings
                      on aa.ControllerId equals bb.ControllerId
                      where bb.UserTypeId == UserTypes  
                      select new UserTypeModel
                      {
                          ControllerId = aa.ControllerId,
                          ControllerLabel=aa.ControllerLabel
                      }).ToList();
            return cc;
        }

       
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// 
       
        public List<UserTypeRoleModel> GetAllRolesListForAdmin()
        {
            EntityModel ent = new EntityModel();
            var cc = (from aa in ent.aspnet_Roles
                      join bb in ent.RoleUserTypeMappings
                      on aa.RoleId equals bb.RoleId
                      where bb.CreatedBy == 0
                      select new UserTypeRoleModel
                      {
                          RoleId = aa.RoleId,
                          RoleName = aa.RoleName,
                      }).ToList();
            return cc;
           
        }
        public List<UserTypeRoleModel> GetAllRolesListForAgent(int agentid)
         {
             EntityModel ent = new EntityModel();
             var cc = (from aa in ent.aspnet_Roles
                       join bb in ent.RoleUserTypeMappings
                       on aa.RoleId equals bb.RoleId
                       where (bb.CreatedBy == agentid || (bb.UserTypeId==2 && bb.CreatedBy==0))
                       select new UserTypeRoleModel
                       {
                           RoleId = aa.RoleId,
                           RoleName = aa.RoleName,
                       }).ToList();
             return cc;

         }

         public aspnet_Roles GetRoleInfoByName(string roelname)
         {
             return ent.aspnet_Roles.SingleOrDefault(u => u.RoleName == roelname);

         }
         public aspnet_Roles GetRoleInfo(Guid roleid)
         {
             return ent.aspnet_Roles.SingleOrDefault(u => u.RoleId == roleid);
             
         }

         public string Rolename(Guid roleid)
         {
             aspnet_Roles roles = GetRoleInfo(roleid);
             return roles.RoleName;
         }

         public Guid GetIdbyRolename(string rolename)
         {
             aspnet_Roles roles = GetRoleInfoByName(rolename);
             return roles.RoleId;
         }

        public List<GetControllerList_Result> GetAllControllerList(int usertypeid)
        {
            return ent.GetControllerList(usertypeid).ToList();
        }

        public List<ControllerActionMappings> GetControllerActionMapping()
        {
            return ent.ControllerActionMappings.ToList();
        }
        public void SaveRolePrivilageMapping(List<RolePrivilegeMappings> roleinfo)
        {
            EntityModel ent = new EntityModel();
            foreach (var item in roleinfo)
            {
                ent.RolePrivilegeMappings.AddObject(new RolePrivilegeMappings()
                {

                    RoleId = item.RoleId,
                    PrivilegeId = item.PrivilegeId,
                });
            }
            ent.SaveChanges();
        }


        public List<RolePrivilageModel> GetRolePrivilageBaseonUser(int AppuserId, int Product)
        {
            var cc = (from aa in ent.GetPrivilageOfUser(AppuserId, Product).OrderBy(pp => pp.ActionTypeId)
                      select new RolePrivilageModel
                      {
                          ActionTypeName = aa.ActionTypeName,
                          ControllerLabel = aa.ControllerLabel,
                          ControllerId = aa.ControlerId,
                          PrivilegeId = aa.PrivilegeId,
                          PrivilageIdChecked = Convert.ToBoolean(aa.Exist),
                          ControllerName = aa.ControllerName
                      }).ToList();
            return cc.ToList();
        }

        public List<RolePrivilageModel> GetRolePrivilageBaseonRole(Guid Roleid,int SubProductId)
        {
            var cc = (from aa in ent.GetPrivilageOfRole(Roleid, SubProductId)
                      select new RolePrivilageModel
                      {
                          ActionTypeName = aa.ActionTypeName,
                          //ControllerName=aa.
                          ControllerLabel = aa.ControllerLabel,
                          ControllerId = aa.ControlerId,
                          PrivilegeId = aa.PrivilegeId,
                          PrivilageIdChecked = Convert.ToBoolean(aa.Exist),
                          ControllerName = aa.ControllerName
                      }).ToList();
            return cc.ToList();
        }


        
        public void DeleteAlreadyAddedPrivilageBaseonRole(Guid RoleId)
        {
            try
            {
                ent.DeleteRolePrivilege(RoleId);
                ent.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
         }
            public void DeleteAlreadUserTypePrivilage(int UserTypeId)
            {
            try
            {
                ent.DeleteUserTypePrivilege(UserTypeId);
                ent.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            }
      
            
        }

    }