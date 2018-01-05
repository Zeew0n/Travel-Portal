using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ATLTravelPortal.Areas.Train.Models
{
    public class TrainChargeModel
    {
        public int ChargeId { get; set; }
        public string ClassCode { get; set; }
        public double IrctcsCharge { get; set; }
        public double AgentCharge { get; set; }
        public double AhMarkUp { get; set; }
        public double AgentCommission { get; set; }
        public double  SupplierCommission { get; set; }
        public string TerminalId { get; set; }
        public string ClassName { get; set; }
        public List<SelectListItem> ClassList { get; set; }
        public List<TrainChargeModel> List { get; set; }
    }
}