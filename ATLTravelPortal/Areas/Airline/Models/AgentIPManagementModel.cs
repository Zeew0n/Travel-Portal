using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ATLTravelPortal.Areas.Airline.Models
{
    public class AgentIPManagementModel
    {
        public int AgentIPId { get; set; }

        public string IPAddress { get; set; }

        public int AgentId { get; set; }
        public bool IsActive { get; set; }
        public bool IsAutoExpire { get; set; }
        public DateTime ActiveDate { get; set; }

        public DateTime ExpiryDateTime { get; set; }


        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }

        public int Updatedby  { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}