using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ATLTravelPortal.Areas.Hotel.Models
{
    public class CardViewModel
    {
    
        
        public  int CardId {get;set;}

        [Required(ErrorMessage = "*")]
        [DisplayName("Card Number")]
        public string CardNumber { get; set; }

        [Required(ErrorMessage = "*")]
        [DisplayName("Card Type")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public int CardTypeId { get; set; }
        public string CardType { get; set; }
        public IEnumerable<SelectListItem> CardTypeList { get; set; }

        [Required(ErrorMessage = "*")]
        [DisplayName("Card value")]
        public decimal CardValue { get; set; }

        [Required(ErrorMessage = "*")]
        [DisplayName("Valid Till")]
        public DateTime ValidTill { get; set; }

        [Required(ErrorMessage = "*")]
        [DisplayName("Card Status")]
        public Int32 CardStatusId { get; set; }
        public string CardStatus { get; set; }
        public IEnumerable<SelectListItem> CardStatusList { get; set; }

        [Required(ErrorMessage = "*")]
        [DisplayName("Card Rule")]
        public string CardRule { get; set; }

        [Required(ErrorMessage = "*")]
        [DisplayName("Is Active")]
        public bool isActive { get; set; }

       
        [DisplayName("Created By")]
        public Int32 CreatedBy { get; set; }

        
        [DisplayName("CreateDate")]
        public DateTime CreateDate { get; set; }

       
        [DisplayName("Updated By")]
        public Int32 UpdatedBy { get; set; }

       
        [DisplayName("Updated Date")]
        public DateTime UpdatedDate { get; set; }
        public Int32 HFCardId { get; set; }

        public Int32 Damage { get; set; }
        public Int32 Block { get; set; }
        public Int32 Lost { get; set; }

        public IEnumerable<CardViewModel> cardviewmodel { get; set; }
        public IEnumerable<AgentCardViewModel> Agentviewmodel { get; set; }
        public IEnumerable<CustomerCardViewModel> Customerviewmodel { get; set; }
        public CardViewModel detailscardviewmodel { get; set; }
        
    }
}