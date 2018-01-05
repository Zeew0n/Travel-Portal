using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TravelPortalEntity;
using ATLTravelPortal.Areas.Administrator.Models;
using System.Web.Mvc;
using ATLTravelPortal.Areas.Airline.Models;
using ATLTravelPortal.Repository;

namespace ATLTravelPortal.Areas.Airline.Repository
{
    public class GeneralProvider
    {
        EntityModel ent = new EntityModel();

        public List<ServiceProviders> GetGDSInformationList()
        {
            return ent.ServiceProviders.Where(x => x.isActive == true).ToList();
            //return ent.ServiceProviders.Where(x => x.isActive == true).Where(x => x.ServiceProviderId < 5).ToList();
        }


        public Agents GetAgentById(int Id)
        {
            return ent.Agents.Where(x => x.AgentId == Id).FirstOrDefault();
        }


        public List<Distributors> GetDistributorList(int CreatedBy)
        {
            return ent.Distributors.Where(x => (x.isSystem == false && x.BranchOfficeId == CreatedBy)).OrderBy(x => x.DistributorName).ToList();
        }

        public List<Agents> GetAgentList()
        {
            return ent.Agents.Where(x => x.AgentStatus == true).OrderBy(x => x.AgentName).ToList();
        }

        public List<Agents> GetBranchAgentList(int branchID)
        {
            return ent.Agents.Where(x => x.AgentStatus == true && x.BranchOfficeId == branchID).OrderBy(x => x.AgentName).ToList();
        }

        public List<Agents> GetDistributorAgentList(int distributorID)
        {
            return ent.Agents.Where(x => x.AgentStatus == true && x.DistributorId == distributorID).OrderBy(x => x.AgentName).ToList();
        }

        public List<SelectListItem> GetAgentSelectOptionList()
        {
            var result = ent.Agents.Where(x => x.AgentStatus == true);
            List<SelectListItem> ddlList = new List<SelectListItem>();

            ddlList.Add(new SelectListItem { Text = "-- Select --", Value = "" });
            foreach (var item in result)
            {
                ddlList.Add(new SelectListItem { Text = item.AgentName, Value = item.AgentId.ToString() });
            }
            return ddlList;

        }


        public string GetCreatedUpdatedByinfo(int userappid)
        {
            var user = ent.UsersDetails.SingleOrDefault(u => u.AppUserId == userappid);
            var username = ent.aspnet_Users.SingleOrDefault(u => u.UserId == user.UserId);
            return username.UserName;
        }
        public List<Airlines> GetAgentAirlineList()
        {
            return ent.Airlines.OrderBy(x => x.AirlineName).ToList();
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
        public string GetCityCode(int cityId)
        {
            return ent.AirlineCities.Where(x => x.CityID == cityId).Select(x => x.CityCode).FirstOrDefault();
        }
        /// <summary>
        /// Gives list of Airlines According to type of flights i.e. Domestic or International cities
        /// </summary>
        /// <param name="AirlineTypeId"></param>
        /// <returns></returns>
        public IEnumerable<Airlines> GetAirlinesList(int AirlineTypeId)
        {
            return ent.Airlines.Where(x => x.AirlineTypeId == AirlineTypeId);
        }
        /// <summary>
        /// Give Cities Name According to type of flights i.e.Domestic or International cities
        /// </summary>
        /// <param name="AirlineTypeId"></param>
        /// <returns></returns>
        public IEnumerable<AirlineCities> CityListAsperFlightType(int AirlineTypeId)
        {
            return ent.AirlineCities.Where(x => x.AirlineCityTypeId == AirlineTypeId);
        }
        public IEnumerable<Tkt_DealMasters> GetTicketDeals()
        {
            return ent.Tkt_DealMasters.Where(x => x.DealTypeId == 2);
        }
        public string GetDealName(int DealId)
        {
            return ent.Tkt_DealMasters.Where(x => x.DealMasterId == DealId).Select(x => x.DealName).FirstOrDefault();
        }
        public string GetFlightClassName(int FlightClassId)
        {
            return ent.FlightClasses.Where(x => x.FlightClassId == FlightClassId).Select(x => x.FlightClassCode).FirstOrDefault();
        }
        public IEnumerable<AirlineTypes> GetAirlineType()
        {
            return ent.AirlineTypes.AsEnumerable();
        }
        public IEnumerable<Agents> GetAllAgentNameListForAutoComplete(string AgentName, int maxResult)
        {
            EntityModel ent = new EntityModel();
            return ent.Agents.Where(x => (x.AgentName.ToLower().Contains(AgentName.ToLower()) || x.AgentName.ToLower().Contains(AgentName.ToLower()))).Where(x => x.AgentStatus == true).Take(maxResult).ToList().Select(x =>
                                new Agents { AgentName = x.AgentName + "(" + x.AgentCode + ")", AgentId = x.AgentId }
                );
        }


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


        public IEnumerable<SelectListItem> GetAirlineCityList()
        {
            List<AirlineCities> all = GetAllCities().ToList();
            var AirlineCityList = new List<SelectListItem>();
            foreach (var item in all)
            {
                var teml = new SelectListItem
                {
                    Text = item.CityCode,
                    Value = item.CityID.ToString()
                };
                AirlineCityList.Add(teml);
            }
            return AirlineCityList.AsEnumerable();
        }

        public IQueryable<AirlineCities> GetAllCities()
        {
            return ent.AirlineCities.OrderBy(xx => xx.CityCode).AsQueryable();
        }



        public IEnumerable<SelectListItem> GetInternationAirlinesList(int airlineType)
        {
            List<Airlines> all = GetAirlinesList(1).OrderBy(model => model.AirlineCode).ToList();

            var AirlinesList = new List<SelectListItem>();
            foreach (var item in all)
            {
                var teml = new SelectListItem
                {
                    Text = item.AirlineCode,
                    Value = item.AirlineId.ToString()
                };
                AirlinesList.Add(teml);
            }
            return AirlinesList.AsEnumerable();
        }

        public IEnumerable<Air_GetAvailableBalance_Result> GetAvailableBalanceForAgent(int agentid)
        {
            return ent.Air_GetAvailableBalance(agentid);
        }

        public bool Air_isSufficientBalance(decimal totalFare, int agentId, int currencyId, int serviceProvider)
        {
            var tF = new Nullable<double>((double)totalFare);
            var aId = new Nullable<int>((int)agentId);
            var cId = new Nullable<int>(currencyId);
            System.Data.Objects.ObjectParameter isSufficientBalance = new System.Data.Objects.ObjectParameter("isSufficientBalance", false);
            ent.Air_isSufficientBalance(tF, aId, cId, serviceProvider, isSufficientBalance);
            return (bool)isSufficientBalance.Value;
        }


        public AvailableBalanceViewModel GetAccountInfoByAgentId(int agentId)
        {
            GeneralProvider _provider = new GeneralProvider();

            var AvailableBalanceResult = _provider.GetAvailableBalanceForAgent(agentId).ToList();
            var Balanceviewmodel = new AvailableBalanceViewModel();
            /// For NPR balance
            ///  //Currency
            Balanceviewmodel.CurrencyNPR = AvailableBalanceResult.ElementAtOrDefault(0).CurrencyCode;
            Balanceviewmodel.CreditLimitNPR = AvailableBalanceResult.ElementAtOrDefault(0).CreditLimit;
            Balanceviewmodel.CurrentBalanceNPR = AvailableBalanceResult.ElementAtOrDefault(0).Amount;
            Balanceviewmodel.LeadgerBalanceNPR = AvailableBalanceResult.ElementAtOrDefault(0).LedgerAmount;
            /// For USD balance
            Balanceviewmodel.CurrencyUSD = AvailableBalanceResult.ElementAtOrDefault(1).CurrencyCode == "USD" ? AvailableBalanceResult.ElementAtOrDefault(1).CurrencyCode : "";
            Balanceviewmodel.CreditLimitUSD = AvailableBalanceResult.ElementAtOrDefault(1).CurrencyCode == "USD" ? AvailableBalanceResult.ElementAtOrDefault(1).CreditLimit : double.Parse("");
            Balanceviewmodel.CurrentBalanceUSD = AvailableBalanceResult.ElementAtOrDefault(1).CurrencyCode == "USD" ? AvailableBalanceResult.ElementAtOrDefault(1).Amount : double.Parse("");

            Balanceviewmodel.LeadgerBalanceUSD = AvailableBalanceResult.ElementAtOrDefault(1).CurrencyCode == "USD" ? AvailableBalanceResult.ElementAtOrDefault(1).LedgerAmount : double.Parse("");

            /// For INR balance
            Balanceviewmodel.CurrencyINR = AvailableBalanceResult.ElementAtOrDefault(2).CurrencyCode == "INR" ? AvailableBalanceResult.ElementAtOrDefault(2).CurrencyCode : "";
            Balanceviewmodel.CreditLimitINR = AvailableBalanceResult.ElementAtOrDefault(2).CurrencyCode == "INR" ? AvailableBalanceResult.ElementAtOrDefault(2).CreditLimit : double.Parse("");
            Balanceviewmodel.CurrentBalanceINR = AvailableBalanceResult.ElementAtOrDefault(2).CurrencyCode == "INR" ? AvailableBalanceResult.ElementAtOrDefault(2).Amount : double.Parse("");


            if (Balanceviewmodel.CurrentBalanceNPR == null)
                Balanceviewmodel.CurrentBalanceNPR = 0;


            double minBalance = Balanceviewmodel.CreditLimitNPR.Value * 10 * 0.01;//10 % of Credit limit
            if (Balanceviewmodel.CurrentBalanceNPR <= minBalance)//|| Balanceviewmodel.Amount==0)
                Balanceviewmodel.isLowBalanceNPR = true;
            else
                Balanceviewmodel.isLowBalanceNPR = false;

            double minBalanceUSD = Balanceviewmodel.CreditLimitUSD.Value * 10 * 0.01;//10 % of Credit limit
            if (Balanceviewmodel.CurrentBalanceUSD <= minBalance)//|| Balanceviewmodel.Amount==0)
                Balanceviewmodel.isLowBalanceUSD = true;
            else
                Balanceviewmodel.isLowBalanceUSD = false;

            double minBalanceINR = Balanceviewmodel.CreditLimitINR.Value * 10 * 0.01;//10 % of Credit limit
            if (Balanceviewmodel.CurrentBalanceINR <= minBalanceINR)//|| Balanceviewmodel.Amount==0)
                Balanceviewmodel.isLowBalanceINR = true;
            else
                Balanceviewmodel.isLowBalanceINR = false;

            return Balanceviewmodel;
        }


        public AvailableBalanceViewModel GetBranchOfficeAccountInfoByBranchOfficeId(int agentId)
        {
            GeneralRepository _provider = new GeneralRepository();

            var AvailableBalanceResult = _provider.GetAvailableBalanceForBranchOffice(agentId).ToList();
            var Balanceviewmodel = new AvailableBalanceViewModel();
            /// For NPR balance
            ///  //Currency
            Balanceviewmodel.CurrencyNPR = AvailableBalanceResult.ElementAtOrDefault(0).CurrencyCode;
            Balanceviewmodel.CreditLimitNPR = AvailableBalanceResult.ElementAtOrDefault(0).CreditLimit;
            Balanceviewmodel.CurrentBalanceNPR = AvailableBalanceResult.ElementAtOrDefault(0).Amount;
            Balanceviewmodel.LeadgerBalanceNPR = AvailableBalanceResult.ElementAtOrDefault(0).LedgerAmount;
            /// For USD balance
            Balanceviewmodel.CurrencyUSD = AvailableBalanceResult.ElementAtOrDefault(1).CurrencyCode == "USD" ? AvailableBalanceResult.ElementAtOrDefault(1).CurrencyCode : "";
            Balanceviewmodel.CreditLimitUSD = AvailableBalanceResult.ElementAtOrDefault(1).CurrencyCode == "USD" ? AvailableBalanceResult.ElementAtOrDefault(1).CreditLimit : double.Parse("");
            Balanceviewmodel.CurrentBalanceUSD = AvailableBalanceResult.ElementAtOrDefault(1).CurrencyCode == "USD" ? AvailableBalanceResult.ElementAtOrDefault(1).Amount : double.Parse("");

            Balanceviewmodel.LeadgerBalanceUSD = AvailableBalanceResult.ElementAtOrDefault(1).CurrencyCode == "USD" ? AvailableBalanceResult.ElementAtOrDefault(1).LedgerAmount : double.Parse("");


            if (Balanceviewmodel.CurrentBalanceNPR == null)
                Balanceviewmodel.CurrentBalanceNPR = 0;


            double minBalance = Balanceviewmodel.CreditLimitNPR.Value * 10 * 0.01;//10 % of Credit limit
            if (Balanceviewmodel.CurrentBalanceNPR <= minBalance)//|| Balanceviewmodel.Amount==0)
                Balanceviewmodel.isLowBalanceNPR = true;
            else
                Balanceviewmodel.isLowBalanceNPR = false;

            double minBalanceUSD = Balanceviewmodel.CreditLimitUSD.Value * 10 * 0.01;//10 % of Credit limit
            if (Balanceviewmodel.CurrentBalanceUSD <= minBalance)//|| Balanceviewmodel.Amount==0)
                Balanceviewmodel.isLowBalanceUSD = true;
            else
                Balanceviewmodel.isLowBalanceUSD = false;

            return Balanceviewmodel;
        }



        public AvailableBalanceViewModel GetDistributorAccountInfoByDistributorId(int agentId)
        {
            GeneralRepository _provider = new GeneralRepository();

            var AvailableBalanceResult = _provider.GetAvailableBalanceForDistributor(agentId).ToList();
            var Balanceviewmodel = new AvailableBalanceViewModel();
            /// For NPR balance
            ///  //Currency
            Balanceviewmodel.CurrencyNPR = AvailableBalanceResult.ElementAtOrDefault(0).CurrencyCode;
            Balanceviewmodel.CreditLimitNPR = AvailableBalanceResult.ElementAtOrDefault(0).CreditLimit;
            Balanceviewmodel.CurrentBalanceNPR = AvailableBalanceResult.ElementAtOrDefault(0).Amount;
            Balanceviewmodel.LeadgerBalanceNPR = AvailableBalanceResult.ElementAtOrDefault(0).LedgerAmount;
            /// For USD balance
            Balanceviewmodel.CurrencyUSD = AvailableBalanceResult.ElementAtOrDefault(1).CurrencyCode == "USD" ? AvailableBalanceResult.ElementAtOrDefault(1).CurrencyCode : "";
            Balanceviewmodel.CreditLimitUSD = AvailableBalanceResult.ElementAtOrDefault(1).CurrencyCode == "USD" ? AvailableBalanceResult.ElementAtOrDefault(1).CreditLimit : double.Parse("");
            Balanceviewmodel.CurrentBalanceUSD = AvailableBalanceResult.ElementAtOrDefault(1).CurrencyCode == "USD" ? AvailableBalanceResult.ElementAtOrDefault(1).Amount : double.Parse("");

            Balanceviewmodel.LeadgerBalanceUSD = AvailableBalanceResult.ElementAtOrDefault(1).CurrencyCode == "USD" ? AvailableBalanceResult.ElementAtOrDefault(1).LedgerAmount : double.Parse("");


            if (Balanceviewmodel.CurrentBalanceNPR == null)
                Balanceviewmodel.CurrentBalanceNPR = 0;


            double minBalance = Balanceviewmodel.CreditLimitNPR.Value * 10 * 0.01;//10 % of Credit limit
            if (Balanceviewmodel.CurrentBalanceNPR <= minBalance)//|| Balanceviewmodel.Amount==0)
                Balanceviewmodel.isLowBalanceNPR = true;
            else
                Balanceviewmodel.isLowBalanceNPR = false;

            double minBalanceUSD = Balanceviewmodel.CreditLimitUSD.Value * 10 * 0.01;//10 % of Credit limit
            if (Balanceviewmodel.CurrentBalanceUSD <= minBalance)//|| Balanceviewmodel.Amount==0)
                Balanceviewmodel.isLowBalanceUSD = true;
            else
                Balanceviewmodel.isLowBalanceUSD = false;

            return Balanceviewmodel;
        }

        public AvailableBalanceViewModel GetAgentAccountInfoByAgentId(int agentId)
        {
            GeneralRepository _provider = new GeneralRepository();

            var AvailableBalanceResult = GetAvailableBalanceForAgent(agentId).ToList();
            var Balanceviewmodel = new AvailableBalanceViewModel();
            /// For NPR balance
            ///  //Currency
            Balanceviewmodel.CurrencyNPR = AvailableBalanceResult.ElementAtOrDefault(0).CurrencyCode;
            Balanceviewmodel.CreditLimitNPR = AvailableBalanceResult.ElementAtOrDefault(0).CreditLimit;
            Balanceviewmodel.CurrentBalanceNPR = AvailableBalanceResult.ElementAtOrDefault(0).Amount;
            Balanceviewmodel.LeadgerBalanceNPR = AvailableBalanceResult.ElementAtOrDefault(0).LedgerAmount;
            /// For USD balance
            Balanceviewmodel.CurrencyUSD = AvailableBalanceResult.ElementAtOrDefault(1).CurrencyCode == "USD" ? AvailableBalanceResult.ElementAtOrDefault(1).CurrencyCode : "";
            Balanceviewmodel.CreditLimitUSD = AvailableBalanceResult.ElementAtOrDefault(1).CurrencyCode == "USD" ? AvailableBalanceResult.ElementAtOrDefault(1).CreditLimit : double.Parse("");
            Balanceviewmodel.CurrentBalanceUSD = AvailableBalanceResult.ElementAtOrDefault(1).CurrencyCode == "USD" ? AvailableBalanceResult.ElementAtOrDefault(1).Amount : double.Parse("");

            Balanceviewmodel.LeadgerBalanceUSD = AvailableBalanceResult.ElementAtOrDefault(1).CurrencyCode == "USD" ? AvailableBalanceResult.ElementAtOrDefault(1).LedgerAmount : double.Parse("");


            if (Balanceviewmodel.CurrentBalanceNPR == null)
                Balanceviewmodel.CurrentBalanceNPR = 0;


            double minBalance = Balanceviewmodel.CreditLimitNPR.Value * 10 * 0.01;//10 % of Credit limit
            if (Balanceviewmodel.CurrentBalanceNPR <= minBalance)//|| Balanceviewmodel.Amount==0)
                Balanceviewmodel.isLowBalanceNPR = true;
            else
                Balanceviewmodel.isLowBalanceNPR = false;

            double minBalanceUSD = Balanceviewmodel.CreditLimitUSD.Value * 10 * 0.01;//10 % of Credit limit
            if (Balanceviewmodel.CurrentBalanceUSD <= minBalance)//|| Balanceviewmodel.Amount==0)
                Balanceviewmodel.isLowBalanceUSD = true;
            else
                Balanceviewmodel.isLowBalanceUSD = false;

            return Balanceviewmodel;
        }

        public bool GetBranchSettings(int branchID, int settingID)
        {

            var result = ent.BranchSettings.Where(x => x.BranchID == branchID && x.SettingId == settingID).FirstOrDefault();
            if (result != null)
                return true;
            else
                return false;
        }

        public bool GetDistributorSettings(int distributorID, int settingID)
        {

            var result = ent.DistributorSettings.Where(x => x.DistributorID == distributorID && x.SettingId == settingID).FirstOrDefault();
            if (result != null)
                return true;
            else
                return false;
        }

        public Agents GetAgents(int agentID)
        {
            var agent = ent.Agents.Where(x => x.AgentId == agentID).FirstOrDefault();
            return agent;
        }

        public Currencies GetCurrencyByCode(string code)
        {
            var currency = ent.Currencies.Where(x => x.CurrencyCode == code).FirstOrDefault();
            return currency;
        }

    }
}