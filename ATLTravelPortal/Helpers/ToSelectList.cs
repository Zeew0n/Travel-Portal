using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TBO.BookingService;
using TBO.Passenger;
using TravelPortalEntity;

namespace ATLTravelPortal.Helpers
{
    public class ToSelectList
    {
        static readonly TravelPortalEntity.EntityModel _ent = new EntityModel();
        public enum BICType
        {
            A, B, C, D, E, F, G, H, I, J, K, L, M, N, O, P, Q, R, S, T, U, V, W, X, Y, Z
        }


        public static SelectList GetPrefixList()
        {
            return TBOEnumHelper.ToSelectList<Salutations>();
        }

        public static SelectList GetNationalityList()
        {
            return new SelectList(_ent.Countries, "CountryId", "Nationality");
        }

        public static SelectList GetCityList()
        {
         
            return new SelectList(_ent.AirlineCities, "CityID", "CityCode");
        }


        public static SelectList GetBookingSourceList()
        {
            var result = _ent.ServiceProviders.Where(x => (x.isActive == true && x.ServiceType == "FLT"));
            return new SelectList(result, "ServiceProviderId", "ServiceProviderName");
        }

        public static IEnumerable<ServiceProviders> BookingSourceList()
        {
            return _ent.ServiceProviders.Where(x => (x.isActive == true && x.ServiceType == "FLT"));            
        }

        public static SelectList GetAirlineList()
        {
            return new SelectList(_ent.Airlines, "AirlineId", "AirlineCode");
        }

        public static SelectList GetCountryList()
        {
            return new SelectList(_ent.Countries, "CountryId", "CountryName");
        }

        public static SelectList GetStateList()
        {
            return new SelectList(_ent.Zones, "ZoneId", "ZoneName");
        }

        public static SelectList GetMealList()
        {
            return TBOEnumHelper.ToSelectList<MealSSRCode>();
        }

        public static SelectList GetSeatList()
        {
            return TBOEnumHelper.ToSelectList<SeatSSRCode>();
        }

        public static SelectList GetPaxTypeList()
        {
            //return TBOEnumHelper.ToSelectList<PassengerType>();
            return new SelectList(_ent.PassengerTypes, "PassengerTypeId", "PassengerTypeName");
        }

        public static SelectList GetTicketStatusList()
        {
            return new SelectList(_ent.TicketStatus, "TicketStatusId", "TicketStatusName");
        }

        public static SelectList GetPassengerTypeList()
        {
           // return TBOEnumHelper.ToSelectList<PassengerType>();
            return new SelectList(_ent.PassengerTypes, "PassengerTypeId", "PassengerTypeName");
        }

        public static SelectList GetCurrencyList()
        {
            var result = _ent.Currencies.Where(x => x.CurrencyId == 1 || x.CurrencyId==2);
            return new SelectList(result, "CurrencyCode", "CurrencyName");
        }

        public static SelectList GetAgentList()
        {
            return new SelectList(_ent.Agents, "AgentName", "AgentId");
        }

        public static SelectList GetBICTypeList()
        {
            return TBOEnumHelper.ToSelectList<BICType>();
        }

        public static SelectList GetIndianLccBookingSourceList()
        {
            var result = _ent.ServiceProviders.Where(x => (x.isActive == true && x.ServiceType == "FLT"));
            return new SelectList(result, "ServiceProviderId", "ServiceProviderName");
        }

    }
}