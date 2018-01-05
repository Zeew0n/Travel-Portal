using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ATLTravelPortal.Areas.Bus.Models
{
    public class MasterDealviewModel
    {
        /// From Tkt_DealMasters
        /// 
        public int DealMasterId { get; set; }

        [DisplayName("Deal Name")]
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

        /// from Tkt_DealAppliedOn
        /// 
        [Required(ErrorMessage = "*")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public int DealAppliedOnId { get; set; }

        public string DealAppliedOnName { get; set; }

        public string DealAppliedOnType { get; set; }


        ///// From Tkt_DealCalculateOn
        [Required(ErrorMessage = "*")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public int DealCalculateOnId { get; set; }

        public string DealCalculateOnName { get; set; }

        public string DealCalculateOnType { get; set; }

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

        /// <summary>
        /// NPR
        /// </summary>
        [Required(ErrorMessage = "*")]
        public double AdultMarkup { get; set; }

        [Required(ErrorMessage = "*")]
        public double ChildMarkup { get; set; }

        [Required(ErrorMessage = "*")]
        public double InfantMarkup { get; set; }
        public bool isMarkupPercentage { get; set; }

        [Required(ErrorMessage = "*")]
        public double AdultCommission { get; set; }

        [Required(ErrorMessage = "*")]
        public double ChildCommission { get; set; }

        [Required(ErrorMessage = "*")]
        public double InfantCommission { get; set; }

        public bool isCommissionPercentage { get; set; }

        //DOLLOR
        [Required(ErrorMessage = "*")]
        public double USDAdultMarkup { get; set; }

        [Required(ErrorMessage = "*")]
        public double USDChildMarkup { get; set; }

        [Required(ErrorMessage = "*")]
        public double USDInfantMarkup { get; set; }

        public bool isUSDMarkupPercentage { get; set; }

        [Required(ErrorMessage = "*")]
        public double USDAdultCommission { get; set; }

        [Required(ErrorMessage = "*")]
        public double USDChildCommission { get; set; }

        [Required(ErrorMessage = "*")]
        public double USDInfantCommission { get; set; }

        public bool isUSDCommissionPercentage { get; set; }
        //
       

        public bool? isSectorWise { get; set; }
        public bool IsDefault { get; set; }
        public bool IsMaster { get; set; }

      //  public int DealAppliedOnId { get; set; }
        public IEnumerable<SelectListItem> DealAppliedOnList { get; set; }

     //   public int DealCalculateOnId { get; set; }
        public IEnumerable<SelectListItem> DealCalculateOnList { get; set; }


        public int CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public bool isDelete { get; set; }

        //////////////////////////////////
        public IQueryable<MasterDealviewModel> DealDetailsList { get; set; }
        public IQueryable<MasterDealviewModel> AirlineWiseDealDetailsList { get; set; }

        public MasterDealviewModel MasterDealDetails { get; set; }

        [DisplayName("Copy Deal")]
        public bool CopyDeal { get; set; }


        public int AgentId { get; set; }
        public string AgentName { get; set; }
        public IEnumerable<MasterDealviewModel> AssociatedAgentList { get; set; }

    }
}