using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TravelPortalEntity;
using ATLTravelPortal.Areas.Administrator.Models;
using System.Web.Mvc;

namespace ATLTravelPortal.Areas.Administrator.Repository
{
    public class GeneralProvider
    {
        TravelPortalEntity.EntityModel ent = new TravelPortalEntity.EntityModel();

        public List<SelectListItem> GetCurrencyList()
        {
            List<SelectListItem> currencylist = new List<SelectListItem>();
            var result = ent.Core_GetCurrencyFilter("FLT");

            foreach (var item in result)
            {
                currencylist.Add(new SelectListItem { Text = item.CurrencyCode, Value = item.CurrencyId.ToString() });
            }
            return currencylist;
        }

        public List<ServiceProviders> GetGDSInformationList()
        {
            return ent.ServiceProviders.Where(x => x.isActive == true).ToList();
            //return ent.ServiceProviders.Where(x => x.isActive == true).Where(x => x.ServiceProviderId < 5).ToList();
        }

        public List<Agents> GetAgentList()
        {
            return ent.Agents.Where(x => x.AgentStatus == true).OrderBy(x => x.AgentName).ToList();
        }

        public List<UsersDetails> GetUserList()
        {
            return ent.UsersDetails.Where(x => x.UserTypeId == 8 || x.UserTypeId == 4 || x.UserTypeId == 1 || x.UserTypeId == 7).OrderBy(x => x.FullName).ToList();
        }

        public List<Core_Products> GetProductList()
        {
            return ent.Core_Products.ToList();
        }


        public string GetCreatedUpdatedByinfo(int userappid)
        {
            var user = ent.UsersDetails.SingleOrDefault(u => u.AppUserId == userappid);
            var username = ent.aspnet_Users.SingleOrDefault(u => u.UserId == user.UserId);
            return username.UserName;
        }

        //public List<Airlines> GetAgentAirlineList()
        //{
        //    return ent.Airlines.ToList();
        //}

        //public List<Airlines> GetAirlineList()
        //{
        //    return ent.Airlines.ToList();
        //}

        public List<Banks> GetBankList()
        {
            return ent.Banks.ToList();
        }

        public List<PaymentModes> GetPaymentModeList()
        {
            return ent.PaymentModes.ToList();
        }

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
        public IEnumerable<Core_Products> GetProducts(int AgentId)
        {
            var result = ent.Core_AgentProducts.Where(x => x.AgentId == AgentId);
            List<Core_Products> model = new List<Core_Products>();
            foreach (var item in result)
            {
                Core_Products obj = new Core_Products
                {
                    ProductName = ent.Core_Products.Where(x => x.ProductId == item.ProductId).Where(x => x.isActive == true).Select(x => x.ProductName).FirstOrDefault(),
                    ProductId = item.ProductId
                };
                model.Add(obj);
            }
            return model.AsEnumerable();
        }
        public IEnumerable<Core_Products> GetProductsList()
        {
            List<Core_Products> model = new List<Core_Products>();
            model = ent.Core_Products.ToList();
            //foreach (var item in result)
            //{
            //    Core_Products obj = new Core_Products
            //    {

            //    };
            //    model.Add(obj);
            //}
            return model.AsEnumerable();
        }
              



    }
}