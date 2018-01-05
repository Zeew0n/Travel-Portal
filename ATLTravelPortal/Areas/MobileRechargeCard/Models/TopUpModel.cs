using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ATLTravelPortal.Areas.MobileRechargeCard.Models
{
    public class TopUpModel
    {
        [DisplayName("Service Provider")]
        public int? ServiceProviderId { get; set; }
        public List<SelectListItem> ddlServiceProviderList { get; set; }

        [Required(ErrorMessage = " ")]
        [DisplayName("Report Type")]
        public string sType { get; set; }
        public List<SelectListItem> ddlTypeList { get; set; }

        [DisplayName("Mobile No")]
        public string sMobileNo { get; set; }

        [DisplayName("Amount")]
        public Double? sAmount { get; set; }

        [DisplayName("From Date")]
        public DateTime? sFromdate { get; set; }

        [DisplayName("To Date")]
        public DateTime? sTodate { get; set; }

        [DisplayName("Success")]
        public int? sStatusId { get; set; }
        public List<SelectListItem> ddlStatusList { get; set; }

        public List<TopUpModel> ListTopUp { get; set; }

        [DisplayName("Customer Name")]
        public String CustomerName { get; set; }

        [DisplayName("Mobile No")]
        [Required(ErrorMessage = "Oops! The mobile number seems incorrect.")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "Oops! The mobile number seems incorrect.")]
        [RegularExpression(@"^(1\s*[-\/\.]?)?(\((\d{3})\)|(\d{3}))\s*([\s-./\\])?([0-9]*)([\s-./\\])?([0-9]*)$")]
        public string MobileNo { get; set; }

        [DisplayName("Amount")]
        [Required(ErrorMessage = "Select the amount to recharge.")]
        public double RechargeAmount { get; set; }

        [DisplayName("Reference No")]
        public string ReferenceNo { get; set; }

        [DisplayName("Date")]
        public DateTime SalesDate { get; set; }

        [DisplayName("Tran ID")]
        public long SalesTranId { get; set; }

        [DisplayName("Agent")]
        public int? AgentId { get; set; }



    }
}