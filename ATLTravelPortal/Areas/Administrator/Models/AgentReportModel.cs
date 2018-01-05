using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ATLTravelPortal.Helpers.Pagination;

namespace ATLTravelPortal.Areas.Administrator.Models
{
    public class AgentReportModel
    {
        public string AgentName { get; set; }
        public string AgentCode { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public bool IATANumber { get; set; }
        public string ContactPerson { get; set; }
        public string Designation { get; set; }
        public DateTime SignupDate { get; set; }
        public string CreatedBy { get; set; }
        public string Username { get; set; }
        public string mobile { get; set; }
        public string zonename { get; set; }
        public string districtname { get; set; }
        public string signupby { get; set; }
        public int Type { get; set; }
        public string  BranchName { get; set; }
        public string DistributorName { get; set; }
        public int SNO { get; set; }
        public string MEsName { get; set; }
        public IPagedList<AgentReportModel> AgentDetailList { get; set; }



    }
}