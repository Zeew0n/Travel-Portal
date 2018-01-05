using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ATLTravelPortal.Areas.Airline.Models;
using TravelPortalEntity;
namespace ATLTravelPortal.Areas.Airline.Repository
{
    public class AgentClassesProvider
    {
        EntityModel ent = new EntityModel();
        public int SaveAgentClass(string AgentClassName, string Description)
        {
            AgentClasses obj = new AgentClasses();
            obj.AgentClassName = AgentClassName;
            obj.ClassDescription = Description;
            //obj.ProductId = 1;
            try
            {
                ent.AddToAgentClasses(obj);
                ent.SaveChanges();
                return obj.AgentClassId;
            }
            catch (Exception ex)
            {
                return 0;
            }


        }
        public int DeleteAgentClasses(int AgentClassId)
        {
            try
            {
                AgentClasses obj = ent.AgentClasses.Where(x => x.AgentClassId == AgentClassId).FirstOrDefault();
                ent.DeleteObject(obj);
                ent.SaveChanges();
            }
            catch (Exception ex)
            {
                return -1;
            }
            return 0;
        }
        public void EditAgentClass(string AgentName, string Description, int AgentClassId)
        {
            AgentClasses obj = ent.AgentClasses.Where(x => x.AgentClassId == AgentClassId).FirstOrDefault();
            obj.AgentClassName = AgentName;
            obj.ClassDescription = Description;
            ent.ApplyCurrentValues(obj.EntityKey.EntitySetName, obj);
            ent.SaveChanges();
        }
       

        public void DeleteTicketDeals(int AgentTypeId)
        {
            //AgentTypeDeals obj = ent.AgentTypeDeals.Where(x => x.AgentTypeId == AgentTypeDealsId);
            var obj = from a in ent.AgentClassDeals where a.AgentClassId == AgentTypeId select a;
            foreach (var item in obj)
            {
                ent.DeleteObject(item);

            }
            ent.SaveChanges();
        }
        //public void EditTicketDeals(int AgentTypeDealsId,int AgentTypeId,int AgentDealMasterId)
        //{
        //    AgentTypeDeals obj = ent.AgentTypeDeals.Where(x => x.AgentTypeDealsId == AgentTypeDealsId).FirstOrDefault();
        //    obj.AgentTypeId = AgentTypeId;
        //    obj.DealMasterId = AgentDealMasterId;
        //    ent.ApplyCurrentValues(obj.EntityKey.EntitySetName, obj);
        //    ent.SaveChanges();
        //}
        public IEnumerable<AgentClassesModel> GetAgentClassList()
        {
            int sno = 0;
            var result = ent.AgentClasses;
            List<AgentClassesModel> model = new List<AgentClassesModel>();
            foreach (var item in result)
            {
                sno++;
                AgentClassesModel obj = new AgentClassesModel
                {
                    SNO=sno,
                    AgentTypeClasses = item.AgentClassName,
                    AgentClassId = item.AgentClassId,
                    Description = item.ClassDescription,
                };
                model.Add(obj);
            }
            return model.AsEnumerable();
        }
        public AgentClassesModel GetAgentClass(int AgentTypeId)
        {
            var result = ent.AgentClasses.Where(x => x.AgentClassId == AgentTypeId).FirstOrDefault();
            AgentClassesModel model = new AgentClassesModel();
            model.AgentTypeClasses = result.AgentClassName;
            model.AgentClassId = result.AgentClassId;
            model.Description = result.ClassDescription;
            return model;
        }

        public IEnumerable<Tkt_DealMasters> GetTicketDeals()
        {
            return ent.Tkt_DealMasters;
        }
        public IEnumerable<AgentClassDeals> GetAgentDeals(int AgentId)
        {
            return ent.AgentClassDeals.Where(x => x.AgentClassId == AgentId);
        }
        public bool CheckAgentClassName(string AgentClassName)
        {
            AgentClassName = ent.AgentClasses.Where(x => x.AgentClassName == AgentClassName.ToLower() || x.AgentClassName == AgentClassName.ToUpper()).Select(x => x.AgentClassName).FirstOrDefault();
            if (AgentClassName == null)
            {
                return true;
            }
            return false;
        }
        //public bool CheckToAddDeal(int AgentTypeId, int DealId)
        //{
        //    var result = ent.AgentClassDeals.Where(x => x.AgentTypeId == AgentTypeId && x.DealMasterId == DealId).FirstOrDefault();
        //    if (result == null)
        //    {
        //        return true;
        //    }
        //    else
        //        return false;
        //}
        
    }
}