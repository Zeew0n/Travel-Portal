using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ATLTravelPortal.Areas.Airline.Models;
using TravelPortalEntity;
using ATLTravelPortal.Helpers;
namespace ATLTravelPortal.Areas.Airline.Repository
{
    public class TicketAirlineSearchProvider
    {
        EntityModel ent = new EntityModel();
        GeneralProvider _provider = new GeneralProvider();
        public IEnumerable<TicketAirlineSearchOrderModel> GetTicketAirlineSearchOrder(int TypeId)
        {
            List<TicketAirlineSearchOrderModel> model = new List<TicketAirlineSearchOrderModel>();
            var result = ent.Tkt_AirlineSearchOrder.OrderBy(x => x.Sno).Where(x => x.AirlineTypeId == TypeId);
            foreach (var item in result)
            {
                TicketAirlineSearchOrderModel obj = new TicketAirlineSearchOrderModel 
                { 
                 AirlineId = item.AirlineId,
                 AirlineSearchOrderId = item.AirlineSearchOrderId,
                 SerialNo = item.Sno,
                 AirlineName = _provider.GetAirlineName(Convert.ToInt32(item.AirlineId))

                };
                model.Add(obj);
            }
            return model.AsEnumerable();
        }

        public void AddAirlineSearchOrder(TicketAirlineSearchOrderModel model)
        {
            Tkt_AirlineSearchOrder obj = new Tkt_AirlineSearchOrder();
            obj.AirlineId = model.AirlineId;
            obj.AirlineTypeId = model.AirlineTypeId;
            obj.Sno = model.SerialNo+1;
            ent.AddToTkt_AirlineSearchOrder(obj);
            ent.SaveChanges();
        }
        
        public void UpdateOrder(int AirlineSearchOrderId, int Order)
        {
            Tkt_AirlineSearchOrder result  = ent.Tkt_AirlineSearchOrder.Where(x => x.AirlineSearchOrderId == AirlineSearchOrderId).FirstOrDefault();
            
            result.Sno = Order;
            ent.ApplyCurrentValues(result.EntityKey.EntitySetName,result);
            ent.SaveChanges();

        }
        public void DeleteTicketAirlineSearch(int Id)
        {
            Tkt_AirlineSearchOrder result = ent.Tkt_AirlineSearchOrder.Where(x => x.AirlineSearchOrderId == Id).FirstOrDefault();
            ent.DeleteObject(result);
            ent.SaveChanges();
        }

        public IEnumerable<Airlines> GetAllDomesticAirlineNameList(string AirlineNameCode, int maxResult)
        {
            EntityModel ent = new EntityModel();
            return ent.Airlines.Where(x => x.AirlineTypeId == 2 && x.isActive == true).Where(x => (x.AirlineName.ToLower().Contains(AirlineNameCode.ToLower()) || x.AirlineCode.ToLower().Contains(AirlineNameCode.ToLower()))).Take(maxResult).ToList().Select(x =>
                                new Airlines { AirlineName = x.AirlineName, AirlineId = x.AirlineId, AirlineCode = x.AirlineCode }
                );
        }

        public IEnumerable<Airlines> GetAllInternationalAirlineNameList(string AirlineNameCode, int maxResult)
        {
            EntityModel ent = new EntityModel();
            return ent.Airlines.Where(x => x.AirlineTypeId == 1 && x.isActive == true).Where(x => (x.AirlineName.ToLower().Contains(AirlineNameCode.ToLower()) || x.AirlineCode.ToLower().Contains(AirlineNameCode.ToLower()))).Take(maxResult).ToList().Select(x =>
                                new Airlines { AirlineName = x.AirlineName, AirlineId = x.AirlineId, AirlineCode = x.AirlineCode }
                );
        }
        public IEnumerable<Airlines> GetAllLccAirlineNameList(string AirlineNameCode, int maxResult)
        {
           
            return ent.Airlines.Where(x => x.AirlineTypeId == 3 && x.isActive==true).Where(x => (x.AirlineName.ToLower().Contains(AirlineNameCode.ToLower()) || x.AirlineCode.ToLower().Contains(AirlineNameCode.ToLower()))).Take(maxResult).ToList().Select(x =>
                                new Airlines { AirlineName = x.AirlineName, AirlineId = x.AirlineId, AirlineCode = x.AirlineCode }
                );
        }
        public bool CheckIfAirlineExist(int AirlineId)
        {
            Tkt_AirlineSearchOrder result = ent.Tkt_AirlineSearchOrder.Where(x => x.AirlineId == AirlineId).FirstOrDefault();
            if (result == null)
            {
                return true;
            }
            return false;
        }
        public int GetAirlineId(string AirlineName)
        {
            return ent.Airlines.Where(x=>x.AirlineName.ToLower() == AirlineName.ToLower()).Select(x=>x.AirlineId).FirstOrDefault();
        }
        public int GetMaxAirlineSearchId(int TypeId)
        {
           
            var x = ent.Tkt_AirlineSearchOrder.Where(y => y.AirlineTypeId == TypeId).Select(y => y.Sno).Max();
            if (x== null)
            { 
                return 0;
            }
            return Convert.ToInt32(x);

        }
        public bool CheckOrder(string Order)
        {
            if (Order == "System.Collections.Generic.List`1[System.Int32]" || Order==",System.Collections.Generic.List`1[System.Int32]")
            {
                return false;
            }
            return true;
        }
    }
}