using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ATLTravelPortal.Helpers.Pagination;

namespace ATLTravelPortal.Areas.Administrator.Models
{
    public class DistributorAgentManagementModel
    {
        public int AgentId { get; set; }
        public string AgentName { get; set; }
        public string AgencyCode { get; set; }
        public string  AgencyEmail { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }
        public DateTime CreatedOn { get; set; }
        public string BranchOfficeName { get; set; }
        public int BranchOfficeId { get; set; }
        public int DistributorId { get; set; }
        public string DistributorName { get; set; }
        public bool AgentStatus { get; set; }
        public string RedirectedFrom { get; set; }

        public IPagedList<DistributorAgentManagementModel> AgentsList { get; set; }
    }
}