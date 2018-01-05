using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ATLTravelPortal.Areas.Airline.Models
{
    public class MasterBranchDealviewModel
    {
        public int DealMasterId { get; set; }

        [Required]
        [DisplayName("Deal Name :")]
        public string DealName { get; set; }

        [DisplayName("Deal Type")]
        [Required(ErrorMessage = "*")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public int DealTypeId { get; set; }
        public string DealTypeName { get; set; }
        public IEnumerable<SelectListItem> DealTypeList { get; set; }


        [DisplayName("Effective From")]
        public DateTime? EffectiveFrom { get; set; }

        [DisplayName("Expire On")]
        public DateTime? ExpireOn { get; set; }
        ///// From Tkt_DealDetails ////////////

        public int DealDetailsId { get; set; }


        //   public int DealMasterId { get; set; }
        public IEnumerable<SelectListItem> DealMasterList { get; set; }


        public int AirlineId { get; set; }
        public int AirlineDealId { get; set; }
        [Required(ErrorMessage = "*")]
        public string AirlineName { get; set; }
        public IEnumerable<SelectListItem> AirlineNameList { get; set; }

        public string FromCity { get; set; }
        [HiddenInput]
        public int? FromCityId { get; set; }

        public string ToCity { get; set; }
        [HiddenInput]
        public int? ToCityId { get; set; }

        public int CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public bool isDelete { get; set; }

        //////////////////////////////////
        public IQueryable<MasterBranchDealviewModel> DealDetailsList { get; set; }
        public IQueryable<MasterBranchDealviewModel> AirlineWiseDealDetailsList { get; set; }

        public MasterBranchDealviewModel MasterDealDetails { get; set; }

        [DisplayName("Copy Deal")]
        public bool CopyDeal { get; set; }


        public int AgentId { get; set; }
        public string AgentName { get; set; }
        public IEnumerable<MasterBranchDealviewModel> AssociatedAgentList { get; set; }

        [Required(ErrorMessage = "*")]
        [DisplayName("Branch Office")]
        public int BranchOfficeId { get; set; }
        public string BranchOfficeName { get; set; }

        public string BranchOfficeCode { get; set; }
        public string DistributorCode { get; set; }
        public int distributorId { get; set; }
        public IEnumerable<SelectListItem> BranchOffices { get; set; }

        public int ProductID { get; set; }
    }
}