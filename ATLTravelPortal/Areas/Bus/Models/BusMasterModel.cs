using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using ATLTravelPortal.Helpers.Pagination;
using System.ComponentModel;

namespace ATLTravelPortal.Areas.Bus.Models
{
    public class BusMasterModel
    {
        [DisplayName("Bus Operator")]
        public int BusMasterId { get; set; }
        [DisplayName("Bus Operator")]
        [Required(ErrorMessage = "Bus Operator Name required.")]
        public string BusMasterName { get; set; }
        [DisplayName("Contact Person")]
        [Required(ErrorMessage = "Contact Person Name required.")]
        public string ContactPerson { get; set; }
        [DisplayName("Address Name")]
        [Required(ErrorMessage = "Address Name required.")]
        public string ContactAddress { get; set; }
        [DisplayName("Phone No")]
        [Required(ErrorMessage = "Phone  required.")]
        public string Phone { get; set; }
        [DisplayName("Mobile ")]
        [Required(ErrorMessage = "Mobile required.")]
        public string Mobile { get; set; }
        [DisplayName("Email")]
        [Required(ErrorMessage = "Email required.")]
        public string Email { get; set; }
        [DisplayName("Logo")]
        public HttpPostedFileBase LogoImage { get; set; }
        public string LogoUrl { get; set; }
        public BusMessageModel Message { get; set; }
        public int Sno { get; set; }
        public IPagedList<BusMasterModel> TabularList { get; set; }
    }
}