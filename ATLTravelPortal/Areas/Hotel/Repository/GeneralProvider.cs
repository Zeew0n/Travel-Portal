using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using ATLTravelPortal.Helpers;
using TravelPortalEntity;
using ATLTravelPortal.Areas.Hotel.Models;

namespace ATLTravelPortal.Repository
{
    public class GeneralProvider
    {
        EntityModel ent = new EntityModel();

        //public List<ServiceProvider> GetGDSInformationList()
        //{
        //    return ent.ServiceProviders.Where(x => x.isActive == true).ToList();
        //    //return ent.ServiceProviders.Where(x => x.isActive == true).Where(x => x.ServiceProviderId < 5).ToList();
        //}


        //must added this 





        public List<Agents> GetAgentList()
        {
            return ent.Agents.Where(x => x.AgentStatus == true).ToList();
        }


        public string GetCreatedUpdatedByinfo(int userappid)
        {
            var user = ent.UsersDetails.SingleOrDefault(u => u.AppUserId == userappid);
            var username = ent.aspnet_Users.SingleOrDefault(u => u.UserId == user.UserId);
            return username.UserName;
        }
        public List<Airlines> GetAgentAirlineList()
        {
            return ent.Airlines.ToList();
        }

        public List<Airlines> GetAirlineList()
        {
            return ent.Airlines.ToList();
        }

        public List<Banks> GetBankList()
        {
            return ent.Banks.ToList();
        }

        public List<PaymentModes> GetPaymentModeList()
        {
            return ent.PaymentModes.ToList();
        }

        //public IEnumerable<AgentSegmentCommissionModel> GetListByAgentId(int AgentId)
        //{
        //    List<AgentSegmentCommissionModel> model = new List<AgentSegmentCommissionModel>();
        //    var obj = ent.AgentSegmentCommissions.Where(x => x.AgentId == AgentId).ToList();
        //    foreach (var item in obj)
        //    {
        //        var temp = new AgentSegmentCommissionModel
        //        {
        //            SegmentCommissionId = item.SegmentCommissionId,
        //            ServiceProviderName = item.ServiceProviders.ServiceProviderName,
        //            AgentName = item.Agents.AgentName,
        //            FromSegmentNumber = item.FromSegmentNumber,
        //            ToSegmentNumber = item.ToSegmentNumber,
        //            EffectiveFrom = item.EffectiveFrom,
        //            ExpireOn = item.ExpireOn,
        //            isPercent = item.isPercent
        //        };
        //        model.Add(temp);
        //    }
        //    return model.AsEnumerable();
        //}

        public List<AirlineCities> GetCityList()
        {
            return ent.AirlineCities.ToList();
        }
        public bool CheckDuplicateUsername(string userName)
        {
            aspnet_Users tu = ent.aspnet_Users.Where(ii => ii.UserName == userName).FirstOrDefault();
            if (tu != null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public List<MessageTypes> GetMessageType()
        {
            var result = ent.MessageTypes;
            return result.ToList();
        }
        public List<MessagePriorities> GetMessagePriority()
        {
            var result = ent.MessagePriorities;
            return result.ToList();
        }
        public List<Countries> GetCountryList()
        {
            var result = ent.Countries;
            return result.ToList();
        }
        public string GetCityName(int cityId)
        {
            string cityName = ent.AirlineCities.Where(x => x.CityID == cityId).Select(x => x.CityName).FirstOrDefault();
            return cityName;
        }
        public string GetAgentName(int AgentId)
        {
            string AgentName = ent.Agents.Where(x => x.AgentId == AgentId).Select(x => x.AgentName).FirstOrDefault();
            return AgentName;
        }
        public string GetAirlineName(int AirlineId)
        {
            return ent.Airlines.Where(x => x.AirlineId == AirlineId).Select(x => x.AirlineName).FirstOrDefault();
        }
        public string TicketStatus(int TicketStatusId)
        {
            return ent.TicketStatus.Where(x => x.ticketStatusId == TicketStatusId).Select(x => x.ticketStatusName).FirstOrDefault();
        }
        public string PassengerType(int PassengerTypeId)
        {
            return ent.PassengerTypes.Where(x => x.PassengerTypeId == PassengerTypeId).Select(x => x.PassengerTypeName).FirstOrDefault();
        }
        public string GetCountryName(int? countryId)
        {
            return ent.Countries.Where(x => x.CountryId == countryId).Select(x => x.CountryName).FirstOrDefault();
        }
        public string GetCustomerType(int TypeId)
        {
            return ent.Core_CustomerTypes.Where(x => x.CustomerTypeId == TypeId).Select(x => x.CustomerTypeName).FirstOrDefault();
        }
    }

}