using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ATLTravelPortal.Areas.Administrator.Models
{
    public class AgentSettingModel
    {
        public List<AgentServiceProviderNames> ServiceProviders { get; set; }


        public int AgentDealId { get; set; }
        public string AgentDealName { get; set; }
        public int MasterDealIdOfAirlines { get; set; }
        public int MasterDealIdOfHotel { get; set; }
        public int MasterDealIdOfBus { get; set; }
        public int MasterDealIdOfMobile { get; set; }

        public string MasterDealName { get; set; }
        public IEnumerable<SelectListItem> MasterDealNameListOfAirlines { get; set; }
        public IEnumerable<SelectListItem> MasterDealNameListOfHotels { get; set; }
        public IEnumerable<SelectListItem> MasterDealNameListOfBus { get; set; }
        public IEnumerable<SelectListItem> MasterDealNameListOfMobile { get; set; }
        public List<AgentSettingsModel> agentsettinglist { get; set; }
        public List<AgentSettingsModel> Activeagentsettinglist { get; set; }
        
        
        [Required(ErrorMessage = "*")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public int? AgentClassId { get; set; }

        public string AgentName { get; set; }
        
        public int MaxNumberOfAgentUser { get; set; }

        public int? branchofficeid { get; set; }
        public int? DistributorId { get; set; }

        public int AirlineGroupId { get; set; }
        public int[] ChkSettingId { get; set; }
    }
    public enum AgentBalanceCheckOn
    {
        [Description("Credit Limit")]
        CreditLimit = 1,
        [Description("Ledger Balance")]
        LedgerBalance = 2
    }
    public class AgentServiceProviderNames
    {
        public int ServiceProviderId { get; set; }
        public string ServiceProviderName { get; set; }
        public IEnumerable<AgentAccountSettingBasedOnServiceProvider> AgentAccountSettingBasedOnServiceProvider { get; set; }
        public bool ServiceProviderExistance { get; set; }
       
    }

    public class AgentAccountSettingBasedOnServiceProvider
    {
        public int AgentId { get; set; }
        public int CurrencyId { get; set; }
        public string Currency { get; set; }
        public BalanceCheckOn BalanceCheckOnType { get; set; }
        public IEnumerable<SelectListItem> balancecheckon { get; set; }
        public bool IsTransOnLocalCurrency { get; set; }
    }
}