using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TravelPortalEntity;
using System.ComponentModel;
using System.Web.Mvc;

namespace ATLTravelPortal.Areas.Administrator.Models
{
    public class ServiceProviderAccountSettingModel
    {
        public IEnumerable<ServiceProviderNames> ServiceProviders { get; set; }
    }

    public enum BalanceCheckOn
    {
        [Description("Credit Limit")]
        CreditLimit = 1,
        [Description("Ledger Balance")]
        LedgerBalance = 2
    }
    public class ServiceProviderNames
    {
        public int CountIndex { get; set; }
        public int ServiceProviderId { get; set; }
        public string ServiceProviderName { get; set; }
        public IEnumerable<AccountSettingBasedOnServiceProvider> AccountSettingBasedOnServiceProvider { get; set; }
    }

    public class AccountSettingBasedOnServiceProvider
    {
        public int CurrencyId { get; set; }
        public string Currency { get; set; }
        public BalanceCheckOn BalanceCheckOnType { get; set; }
        public IEnumerable<SelectListItem> balancecheckon { get; set; }
        public bool IsTransOnLocalCurrency { get; set; }
    }
}