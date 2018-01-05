using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using ATLTravelPortal.Helpers.Pagination;

namespace ATLTravelPortal.Areas.Administrator.Models
{
    public class DistributorConfigurationModel
    {
        public int LayoutSettingId { get; set; }
        public int DistributorID { get; set; }
        [Required(ErrorMessage = "Title Is Required")]
        [DisplayName("Title")]
        public string Title { get; set; }
        public string ContactUs { get; set; }
        public bool IsContactUsActive { get; set; }
        public HttpPostedFileBase Logo{ get; set; }
        public byte[] Logoimage { get; set; }
        public bool IsLogoActive { get; set; }
        public string HeaderContact { get; set; }
        public bool IsHeaderContactActive { get; set; }
        public string DashboardContent { get; set; }
        public bool IsDashboardContentActive { get; set; }
        public string ScrollNews { get; set; }
        public bool IsScrollNewsActive { get; set; }
        public string BankInfo { get; set; }
        public bool IsBankInfoActive { get; set; }
        public bool IsPublished { get; set; }
        public int CreatedBy { get; set; }
        public string CreatedName { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public List<DistributorConfigurationModel> ListDistributorConfigurations { get; set; }
        public IPagedList<DistributorConfigurationModel> DistributorConfigurationList {get; set;}
    }
}