using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using TravelPortalEntity;
using ATLTravelPortal.Helpers.Pagination;
namespace ATLTravelPortal.Areas.Airline.Models
{
    public class AgentClassesModel
    {
        [Required(ErrorMessage="*")]
        public string AgentTypeClasses { get; set; }
        public string Description { get; set; }
        public int AgentTypes { get; set; }
        public string AgentTypeName { get; set; }
        public string DealName { get; set; }
        public int AgentClassId { get; set; }
        public IPagedList<AgentClassesModel> AgentClassList { get; set; }
        public int SNO { get; set; }
        
    }
}