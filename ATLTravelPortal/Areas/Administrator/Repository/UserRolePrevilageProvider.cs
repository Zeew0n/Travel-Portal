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

namespace ATLTravelPortal.Areas.Administrator.Repository
{
    public class UserRolePrevilageProvider
    {
        TravelPortalEntity.EntityModel ent = new TravelPortalEntity.EntityModel();

        public int CheckUserProductId(string AreaName,List<int> productid)
        {
            int id = 0;
            switch (AreaName)
            {
                case "Airline":
                    id = 1;
                    break;
                case "Administrator":
                    id = 5;
                    break;
                case "Hotel":
                    id = 2;
                    break;
            }
            if (productid.Contains(id))
            {
                return id;

            }
            else
                return 0;

        }
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


        /// <summary>
        ///  Get All Product list 
        /// </summary>
        /// <param name="controllerId"></param>
        /// <returns></returns>
       
        public IEnumerable<SelectListItem> GetAllProductList()
        {
            List<Core_Products> all = GetProductList().ToList();
            var GetAllProductList = new List<SelectListItem>();
            foreach (var item in all)
            {
                var teml = new SelectListItem
                {
                    Text = item.ProductName,
                    Value = item.ProductId.ToString()
                };
                GetAllProductList.Add(teml);
            }
            return GetAllProductList.AsEnumerable();
        }

        public IEnumerable<SelectListItem> GetSubProductList(int ProductId)
        {
            List<Core_SubProduct> all = ent.Core_SubProduct.Where(X=>X.ProductId==ProductId).ToList();
            var GetAllSubProductList = new List<SelectListItem>();
            foreach (var item in all)
            {
                var teml = new SelectListItem
                {
                    Text = item.SubProductName,
                    Value = item.SubProductId.ToString()
                };
                GetAllSubProductList.Add(teml);
            }
            return GetAllSubProductList.AsEnumerable();
        }

        public List<Core_Products> GetProductList()
        {
            return ent.Core_Products.Where(tt => tt.isActive==true).ToList();
        }

        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="controllerId"></param>
        /// <returns></returns>
      
        public List<UserTypeControllerMappings> GetUserTypeControllerMappingControllerId(int controllerId)
        {
            var mappingDetail = ent.UserTypeControllerMappings.Where(p => p.ControllerId == controllerId).ToList();
            return mappingDetail;
        }
        /// <summary>
        /// /
        /// </summary>
        /// <returns></returns>

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

        public List<RoleBasedRoleModel> GetAllRolesListForAdmin()
        {
            TravelPortalEntity.EntityModel ent = new TravelPortalEntity.EntityModel();
            var cc = (from aa in ent.aspnet_Roles
                     // join bb in ent.asp
                      //on aa.RoleId equals bb.RoleId
                     // where bb.CreatedBy == 0
                      select new RoleBasedRoleModel
                      {
                          RoleId = aa.RoleId,
                          RoleName = aa.RoleName,
                      }).ToList();
            return cc;
           
        }
        public List<RoleBasedRoleModel> GetAllRolesListForAgent(int agentid)
         {
             TravelPortalEntity.EntityModel ent = new TravelPortalEntity.EntityModel();
             var cc = (from aa in ent.aspnet_Roles
                       join bb in ent.RoleUserTypeMappings
                       on aa.RoleId equals bb.RoleId
                       where (bb.CreatedBy == agentid || (bb.UserTypeId==2 && bb.CreatedBy==0))
                       select new RoleBasedRoleModel
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
            TravelPortalEntity.EntityModel ent = new TravelPortalEntity.EntityModel();
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

        
        public List<RolePrivilageModel> GetRolePrivilageBaseonUser(int AppuserId,int Product)
        {
            var cc = (from aa in ent.Core_GetPrivilageOfUser(AppuserId, "ADMIN").OrderBy(pp=>pp.ActionTypeId)
                      select new RolePrivilageModel
                      {
                          ActionTypeName = aa.ActionTypeName,
                          ControllerLabel = aa.ControllerLabel,
                          ControllerId = aa.ControlerId,
                          PrivilegeId = aa.PrivilegeId,
                          PrivilageIdChecked=Convert.ToBoolean(aa.Exist),
                          ControllerName=aa.ControllerName,
                          isExist=aa.Exist
                      }).ToList();
            return cc.ToList();
        }

        public List<RolePrivilageModel> GetRolePrivilageBaseonRole(Guid Roleid,int SubProductId)
        {
            var cc = (from aa in ent.GetPrivilageOfRole(Roleid, SubProductId)
                      select new RolePrivilageModel
                      {
                          ActionTypeName = aa.ActionTypeName,
                          ControllerGroupId =aa.ControllerGroupId,
                          ControllerGroupName =aa.ControllerGroupName,
                          ControllerLabel = aa.ControllerLabel,
                          ControllerId = aa.ControlerId,
                          PrivilegeId = aa.PrivilegeId,
                          PrivilageIdChecked = Convert.ToBoolean(aa.Exist),
                          ControllerName = aa.ControllerName
                      }).ToList();
            return cc.ToList();
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

        public List<RoleBasedRoleModel> GetAllRolesBasedonProductAndSubProduct(int ProductId, int SubProductId)
        {
            TravelPortalEntity.EntityModel ent = new TravelPortalEntity.EntityModel();
            var cc = (from aa in ent.aspnet_Roles
                      join bb in ent.Core_ProductRoles
                      on aa.RoleId equals bb.RoleId
                      where (bb.ProductId == ProductId && bb.Core_SubProduct.SubProductName=="Agent")
                      select new RoleBasedRoleModel
                      {
                          RoleId = aa.RoleId,
                          RoleName = aa.RoleName,
                      }).ToList();
            return cc;

        }

        public List<RoleBasedRoleModel> GetAllAdminRolesBasedonProductAndSubProduct(int ProductId)
        {
            TravelPortalEntity.EntityModel ent = new TravelPortalEntity.EntityModel();
            var cc = (from aa in ent.aspnet_Roles
                      join bb in ent.Core_ProductRoles
                      on aa.RoleId equals bb.RoleId
                      where (bb.ProductId == ProductId && bb.Core_SubProduct.SubProductName == "Administrator")
                      select new RoleBasedRoleModel
                      {
                          RoleId = aa.RoleId,
                          RoleName = aa.RoleName,
                      }).ToList();
            return cc;

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


        //select * from ControllerActionMappings
        //select * from ControllerGroups
        //select * from ControllerLists

       
        /////////////////////////////////////   Methods for Role Priviledge Setup   /////////////////////////////////////////////////////////////////////////////////////////////////
        // public IEnumerable<RolePrivilageModel> GetPriviledgeSetupList()
        //{
        //    List<RolePrivilageModel> model = new List<RolePrivilageModel>();
        //    var result = ent.ControllerLists;
        //    foreach (var item in result)
        //    {
        //        RolePrivilageModel obj = new RolePrivilageModel
        //        {
        //            ControllerId = item.ControllerId,
        //            ControllerName = item.ControllerName,
        //            ControllerLabel = item.ControllerLabel
        //        };
        //        model.Add(obj);
        //    }
        //    return model.AsEnumerable();
        //}          }




        //for checking duplicate insertion of actionname by comparing controllerid
            public bool GetControllerNameList(int id, string actionname)
            {

                bool result = ent.ControllerActionMappings.Where(x => x.ControlerId == id).Select(x => x.ActionName == actionname).FirstOrDefault();
                return result;

                //if (result.ActionName.Contains(actionname))
                //    return true;
                //else
                //    return false;
            }


        // for checking duplicate insertion of GroupName
            public bool CheckDuplicateGroupName(string GroupName)
            {
                ControllerGroups result = ent.ControllerGroups.Where(x => x.ControllerGroupName == GroupName).FirstOrDefault();

                if (result != null)
                {
                    return false;
                } 
                else
                {
                    return true;
                }

            }



           



            public IEnumerable<RolePrivilageModel> GetControllerActionMappingsList()
            {
                List<RolePrivilageModel> model = new List<RolePrivilageModel>();
                var result = ent.ControllerActionMappings;
                foreach (var item in result)
                {
                    RolePrivilageModel obj = new RolePrivilageModel
                    {
                        ControllerId = item.ControlerId,
                        ActionTypeName = item.ActionName
                    };
                    model.Add(obj);
                }
                return model.AsEnumerable();
            }



          
        public List<ActionTypes> GetActionTypeList()
            {
                return ent.ActionTypes.ToList();
            }
        public IEnumerable<SelectListItem> GetAllActionTypeList()
        {
            List<ActionTypes> all = GetActionTypeList().ToList();
            var GetAllActionTypeList = new List<SelectListItem>();
            foreach (var item in all)
            {
                var teml = new SelectListItem
                {
                    Text = item.ActionTypeName,
                    Value = item.ActionTypeId.ToString()
                };
                GetAllActionTypeList.Add(teml);
            }
            return GetAllActionTypeList.AsEnumerable();
        }


        public List<ControllerGroups> GetControllerGroupList()
        {
            return ent.ControllerGroups.ToList();
        }

        public IEnumerable<SelectListItem> GetAllControllerGroupList()
        {
            List<ControllerGroups> AllGroupName = GetControllerGroupList().ToList();
            var GetAllControllerList = new List<SelectListItem>();
            foreach (var item in AllGroupName)
            {
                var tem = new SelectListItem
                {
                    Text = item.ControllerGroupName,
                    Value = item.ControllerGroupId.ToString()
                };
                GetAllControllerList.Add(tem);
            }
            return GetAllControllerList.AsEnumerable();
        }

        public IEnumerable<SelectListItem> GetAllSubProductGroupList()
        {
            List<Core_SubProduct> AllGroupName = ent.Core_SubProduct.ToList();
            var GetAllControllerList = new List<SelectListItem>();
            foreach (var item in AllGroupName)
            {
                var tem = new SelectListItem
                {
                    Text = item.SubProductName,
                    Value = item.SubProductId.ToString()
                };
                GetAllControllerList.Add(tem);
            }
            return GetAllControllerList.AsEnumerable();
        }

        public List<ControllerLists> GetControllerList()
        {
            return ent.ControllerLists.ToList();
        }

        public IEnumerable<SelectListItem> GetAllControllerList()
        {
            List<ControllerLists> AllControllerName = GetControllerList().ToList();
            var GetAllControllerList = new List<SelectListItem>();
            foreach (var item in AllControllerName)
            {
                var tem = new SelectListItem
                {
                    Text = item.ControllerName,
                    Value = item.ControllerId.ToString()
                };
                GetAllControllerList.Add(tem);
            }
            return GetAllControllerList.AsEnumerable();
        }


        public int ControllerActionMappingsAdd(RolePrivilageModel modelTosave)
            {
                ControllerActionMappings datamodel = new ControllerActionMappings
                {
                    PrivilegeId = modelTosave.PrivilegeId,
                    ControlerId = modelTosave.ControllerId,
                    ActionTypeId = modelTosave.ActionTypeId,
                    ActionName = modelTosave.ActionTypeName
                
                };
                ent.AddToControllerActionMappings(datamodel);
                ent.SaveChanges();
                return datamodel.ActionTypeId;
            }

        public int ControllerGroupAdd(RolePrivilageModel modelTosave)
            {
                ControllerGroups datamodel = new ControllerGroups
                {
                   
                    ControllerGroupName = modelTosave.GroupName,
                    SeqNumber = modelTosave.SeqNumber,
                    ProductId = modelTosave.ProductId

                };
                ent.AddToControllerGroups(datamodel);
                ent.SaveChanges();
                return datamodel.ControllerGroupId;
            }


        public int ControllerGroup(RolePrivilageModel modelTosave)
        {
            ControllerGroups datamodel = new ControllerGroups
            {

                ControllerGroupName = modelTosave.GroupId.ToString(),
                SeqNumber = modelTosave.SeqNumber,
                ProductId = modelTosave.ProductId

            };
            ent.AddToControllerGroups(datamodel);
            ent.SaveChanges();
            return datamodel.ControllerGroupId;
        }


        public int ControllerListAdd(RolePrivilageModel modelTosave)
            {
                ControllerLists datamodel = new ControllerLists
                {
                    ControllerName = modelTosave.ControllerName,
                    ControllerLabel = modelTosave.ControllerLabel,
                    ControllerGroupId = modelTosave.GroupId,
                    SeqNumber = modelTosave.SeqNumber,
                    ProductId = modelTosave.ProductId,
                    SubProductId = modelTosave.SubProductId
                };
                ent.AddToControllerLists(datamodel);
                ent.SaveChanges();
            return datamodel.ControllerId;
            
            }

        public List<RolePrivilageModel> GetAllControllerGroupNameBasedonProduct(int ProductId)
        {
            TravelPortalEntity.EntityModel ent = new TravelPortalEntity.EntityModel();
            var cc = (from aa in ent.ControllerGroups
                      where aa.ProductId == ProductId
                      select new RolePrivilageModel
                      {
                          ControllerGroupId = aa.ControllerGroupId,
                          ControllerGroupName = aa.ControllerGroupName
                      }).ToList();
            return cc;

        }



        public List<RolePrivilageModel> GetAllControllerNameBasedonProductandSubProduct(int ProductId, int SubProductId)
        {
            TravelPortalEntity.EntityModel ent = new TravelPortalEntity.EntityModel();
            var cc = (from aa in ent.ControllerLists
                      where aa.ProductId == ProductId && aa.SubProductId==SubProductId 
                      select new RolePrivilageModel
                      {
                          ControllerId = aa.ControllerId,
                          ControllerName = aa.ControllerName
                      }).ToList();
            return cc;

        }



        public int GetAllSequenceNoFromControllerGroup()
        {
            TravelPortalEntity.EntityModel ent = new TravelPortalEntity.EntityModel();
            var cc = (from aa in ent.ControllerGroups
                      select new RolePrivilageModel
                      {
                          SeqNumber = aa.SeqNumber
                      }).Count();

            return cc ;

        }

        public int GetAllControllerName()
        {
            TravelPortalEntity.EntityModel ent = new TravelPortalEntity.EntityModel();
            var cc = (from aa in ent.ControllerGroups
                      select new RolePrivilageModel
                      {
                          SeqNumber = aa.SeqNumber
                      }).Count();

            return cc;

        }

        public int GetAllSequenceNoFromControllerList(string ControllerName)
        {
            TravelPortalEntity.EntityModel ent = new TravelPortalEntity.EntityModel();
            var cc = (from aa in ent.ControllerLists.Where(b => b.ControllerName == ControllerName)
                      select new RolePrivilageModel
                      {

                          SeqNumber = aa.SeqNumber
                      }).Count();

            return cc;

        }

        
        

        public IEnumerable<RolePrivilageModel> GetPriviledgeSetupList()
        {
            List<RolePrivilageModel> model = new List<RolePrivilageModel>();
            var result = ent.ControllerLists;
            foreach (var item in result)
            {
                RolePrivilageModel obj = new RolePrivilageModel
                {
                    ControllerId = item.ControllerId,
                    ControllerName = item.ControllerName,
                    ControllerLabel = item.ControllerLabel
                };
                model.Add(obj);
            }
            return model.AsEnumerable();
        }



        public IEnumerable<RolePrivilageModel> GetControllerGroupingListByProductId(int ProductId,int SubProductId)
        {
            var result = (from a in ent.ControllerLists
                          join b in ent.ControllerActionMappings on a.ControllerId equals b.ControlerId
                          join c in ent.ControllerGroups on a.ControllerGroupId equals c.ControllerGroupId
                          join d in ent.ActionTypes on b.ActionTypeId equals d.ActionTypeId
                          where a.ProductId == ProductId && a.SubProductId==SubProductId
                          orderby a.ControllerGroupId ascending , a.ControllerName ascending 
                          select new RolePrivilageModel
                          {
                              ControllerGroupName = c.ControllerGroupName,
                              ControllerGroupId = a.ControllerGroupId,
                              ControllerId = a.ControllerId,
                              ControllerName = a.ControllerName,
                              ControllerLabel = a.ControllerLabel,
                              ActionTypeId = b.ActionTypeId,
                              ActionTypeName = b.ActionName,
                          
                          
                          }).ToList();

            return result;

          
        }

        public IEnumerable<RolePrivilageModel> GetControllerGroupingListByProductId(int ProductId)
        {
            var result = (from a in ent.ControllerLists
                          join b in ent.ControllerActionMappings on a.ControllerId equals b.ControlerId
                          join c in ent.ControllerGroups on a.ControllerGroupId equals c.ControllerGroupId
                          join d in ent.ActionTypes on b.ActionTypeId equals d.ActionTypeId
                          where a.ProductId == ProductId
                          orderby a.ControllerGroupId ascending, a.ControllerName ascending
                          select new RolePrivilageModel
                          {
                              ControllerGroupName = c.ControllerGroupName,
                              ControllerGroupId = a.ControllerGroupId,
                              ControllerId = a.ControllerId,
                              ControllerName = a.ControllerName,
                              ControllerLabel = a.ControllerLabel,
                              ActionTypeId = b.ActionTypeId,
                              ActionTypeName = b.ActionName,


                          }).ToList();

            return result;


        }



        public IEnumerable<RolePrivilageModel> GetControllerGroupingList()
        {
            var cc = (from aa in ent.ControllerActionMappings
                      join bb in ent.ControllerLists  on aa.ControlerId equals bb.ControllerId
                      select new RolePrivilageModel
                      {
                          ControllerId = aa.ControlerId,
                          ControllerName = bb.ControllerName,
                          ActionTypeId = aa.ActionTypeId,
                          ActionTypeName = aa.ActionName
                      }).ToList();
            return cc;
        }



        public void DeleteControllerAction(int ControllerId, int? ActionTypeId)
        {

            ent.Bk_DeleteControllerAction(ControllerId, ActionTypeId);
        }







        //public int DeleteRolePrivilegeMapping(int ControllerId)
        //{
        //    RolePrivilegeMappings result = ent.RolePrivilegeMappings.Where(x => x.PrivilegeId == ControllerId).FirstOrDefault();
        //    ent.DeleteObject(result);
        //    ent.SaveChanges();
        //   return result.PrivilegeId;

        //}

        //public int DeleteControllerActionMappings(int PrivilegeId)
        //{
        //    ControllerActionMappings result = ent.ControllerActionMappings.Where(x => x.PrivilegeId == PrivilegeId).FirstOrDefault();
        //    ent.DeleteObject(result);
        //    ent.SaveChanges();
        //    return result.ControlerId;

        //}

        //public int DeleteControllerLists(int ControllerId)
        //{
        //    ControllerLists result = ent.ControllerLists.Where(x => x.ControllerId == ControllerId).FirstOrDefault();
        //    ent.DeleteObject(result);
        //    ent.SaveChanges();
        //    return result.ControllerId;

        //}



        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


      
            
        }

    }