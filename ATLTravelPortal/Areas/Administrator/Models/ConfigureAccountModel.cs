using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ATLTravelPortal.Areas.Administrator.Models
{
    public class ConfigureAccountModel
    {
        public int AccountConfId { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string AccountConfName { get; set; }
        public int? MappedLedgerId { get; set; }
        public long? LedgerId { get; set; }
        public Dictionary<string, int> KeyValue { get; set; }
        public string AccountValue { get; set; }
        public IEnumerable<ConfigureAccountModel> ConfigureAccountList { get; set; }
        public IEnumerable<GeneralLedgerModel> GeneralLedgerModelList { get; set; }

    }
    public class GeneralLedgerModel
    {
        public long LedgerId { get; set; }
        public string LedgerName { get; set; }
        public int AccGroupId { get; set; }
        public int AccSubGroupId { get; set; }
        public int AccTypeId { get; set; }
        public int Id { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime UpdateDate { get; set; }
        public IEnumerable<GeneralLedgerModel> LedgerList { get; set; }
    }
    public class LedgerModel
    {
        public long LedgerId { get; set; }
        public string LedgerName { get; set; }
        public IEnumerable<LedgerModel> LedgerModelList { get; set; }
    }
}