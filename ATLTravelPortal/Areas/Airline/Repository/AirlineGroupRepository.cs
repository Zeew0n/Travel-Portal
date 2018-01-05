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
using ATLTravelPortal.Helpers;


namespace ATLTravelPortal.Areas.Airline.Repository
{
    public class AirlineGroupRepository
    {
        EntityModel ent = new EntityModel();
        public List<Airlines> GetAllAirLinesByAscendingOrder()
        {

            return ent.Airlines.OrderBy(aa => aa.AirlineName).ToList();

        }
        public IQueryable<AirlineGroups> GetAllAirlineGroupList()
        {
            return ent.AirlineGroups.OrderBy(x=>x.AirlineGroupName).AsQueryable();
        }
        public string GetAirlineGroupName(int id)
        {
            AirlineGroups group = ent.AirlineGroups.Where(ggb => ggb.AirlineGroupId == id).SingleOrDefault();
            return group.AirlineGroupName;
        }

        public List<AirlineModelForAirlineGroup> GetAddedAirlineGroupList(int AirlineGroupId)
        {
            EntityModel ent = new EntityModel();
            var cc = (from aa in ent.Airlines
                      join bb in ent.AirlineGroupMappings
                      on aa.AirlineId equals bb.AccessAirlineId
                      where (bb.AirlineGroupId == AirlineGroupId )
                      select new AirlineModelForAirlineGroup
                      {
                          AirlineId = aa.AirlineId,
                          AirlineName = aa.AirlineName,
                      }).ToList();
            return cc;

        }

        public List<Airlines> GetAllAddedAirlineGroupListForEdit(int AirlineGroupId)
        {
            var cc = (from aa in GetAddedAirlineGroupList(AirlineGroupId)
                      select new Airlines
                      {
                          AirlineId = aa.AirlineId,
                          AirlineName = aa.AirlineName,
                      }).ToList();
            return cc;
        }

        public IQueryable<AirlineGroups> GetLastId()
        {
            return ent.AirlineGroups.AsQueryable();
        }
        public void SaveAirlineGroup(AirlineGroupViewModel model)
        {
           
            var entitymodel = new AirlineGroups
            {
                AirlineGroupName = model.GroupName,
              
            };
            ent.AddToAirlineGroups(entitymodel);
            ent.SaveChanges();
           
        }

        public void SaveAirlineGroupMapping(List<AirlineGroupMappings> entitymodel)
        {
            EntityModel ent = new EntityModel();
            foreach (var item in entitymodel)
            {
                ent.AirlineGroupMappings.AddObject(new AirlineGroupMappings()
                {

                    AccessAirlineId =item.AccessAirlineId,
                    AirlineGroupId=item.AirlineGroupId
                });
            }
            ent.SaveChanges();
        }
        public void CollectMappingInfo(int[] SavedGroupAirline, int GroupId)
        {
            try
            {
                int count = SavedGroupAirline.Count();
                List<AirlineGroupMappings> agLists = new List<AirlineGroupMappings>();
                for (int i = 0; i < count; i++)
                {
                    AirlineGroupMappings mappinginfo = new AirlineGroupMappings();
                    mappinginfo.AccessAirlineId = Convert.ToInt32(SavedGroupAirline[i]);
                    mappinginfo.AirlineGroupId = GroupId;
                    agLists.Add(mappinginfo);
                }
                SaveAirlineGroupMapping(agLists);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
    
     
}