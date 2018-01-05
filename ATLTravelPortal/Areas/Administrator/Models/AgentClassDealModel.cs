using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ATLTravelPortal.Areas.Administrator.Models
{
    public class AgentClassDealModel
    {
        public string AgentClassName { get; set; }          
        public int MasterDealId { get; set; }
        public IEnumerable<SelectListItem> AirlineDealList { get; set; }
        public int HotelMasterDealId { get; set; }        
        public IEnumerable<SelectListItem> HotelDealList { get; set; }
        public int BusMasterDealId { get; set; }
        public IEnumerable<SelectListItem> BusDealList { get; set; }

        public int MobileMasterDealId { get; set; }
        public IEnumerable<SelectListItem> MobileDealList { get; set; }      

        public int DealMasterId { get; set; }
        public int AgentClassId { get; set; }
        public string ClassDescription { get; set; }
        public int CreatedBy { get; set; }    
        public IEnumerable<AgentClassDealModel> AgentClassList { get; set; }
    }
}