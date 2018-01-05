using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ATLTravelPortal.Areas.Bus.Models;
using TravelPortalEntity;


namespace ATLTravelPortal.Areas.Bus.Repository
{
    public class BusGeneralProvider
    {
        EntityModel ent = new EntityModel();
        public string GetCityName(int CityId)
        {
            return ent.Bus_Cities.Where(x => x.BusCityId == CityId).Select(x => x.BusCityName).FirstOrDefault();
        }
       
        public string GetBusMasterName(int MasterId)
        {
            return ent.Bus_Master.Where(x => x.BusMasterId == MasterId).Select(x => x.BusMasterName).FirstOrDefault();
        }
        public int GetBusMasterId(int ScheduleId)
        {
            return ent.Bus_Schedules.Where(x => x.ScheduleId == ScheduleId).Select(x => x.BusMasterId).FirstOrDefault();
        }
        public int GetBusMasterId(string MasterName)
        {
            return ent.Bus_Master.Where(x => x.BusMasterName == MasterName).Select(x => x.BusMasterId).FirstOrDefault();
        }
        public IEnumerable<Bus_Master> GetBusMaster()
        {
            return ent.Bus_Master.OrderBy(x => x.BusMasterName).AsEnumerable();
        }
        public IEnumerable<Currencies> GetCurriencies()
        {
            return ent.Currencies.AsEnumerable();
        }
        public IEnumerable<Bus_Cities> GetCities()
        {
            return ent.Bus_Cities.OrderBy(x => x.BusCityName).AsEnumerable();
        }
    //     <add key="ArihantBusApiCustomerCode" value="1001"/>
    //<add key="ArihantBusApiUserName" value="hem.api"/>
    //<add key="ArihantBusApiPassword" value="hem@bhatt"/>
        public static BusApi.ApiAuthentication AAuth
        {
            get
            {
                BusApi.ApiAuthentication _auth = new BusApi.ApiAuthentication
                {
                    CustomerCode = System.Configuration.ConfigurationManager.AppSettings["ArihantBusApiCustomerCode"],
                    UserName = System.Configuration.ConfigurationManager.AppSettings["ArihantBusApiUserName"],
                    Password = System.Configuration.ConfigurationManager.AppSettings["ArihantBusApiPassword"]
                };
                return _auth;
            }
        }


    }
}