using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;




namespace ATLTravelPortal.Areas.Hotel.Models
{
    public class AgentCardViewModel
    {
        public Int32 AgentCardsId { get; set; }

        

        [Required(ErrorMessage = "*")]
        [DisplayName("Agent")]
       
        public Int32 AgentId { get; set; }
        public string AgentName { get; set; }
        public List<SelectListItem> AgentList { get; set; }
       


        public Int32 HFCardId { get; set; }

        [Required(ErrorMessage = "Select")]
        public List<SelectListItem> CardId { get; set; }

        [Required(ErrorMessage = "*")]
         [DisplayName("Card Number")]
        public string CardNumber { get; set; }
      
        [DisplayName("Issue Date")]
        public DateTime IssueDate { get; set; }

        
        [DisplayName("Created By")]
        public Int32 CreatedBy { get; set; }

       
        [DisplayName("Create Date")]
        public DateTime CreateDate { get; set; }

       
        [DisplayName("Updated By")]
        public Int32 UpdatedBy { get; set; }

       
        [DisplayName("Updated Date")]
        public DateTime UpdatedDate { get; set; }

        public string CardType { get; set; }
        public decimal CardValue { get; set; }
        public DateTime ValidTill { get; set; }

        public List<AgentCardViewModel> agentcardmodel { get; set; }
       

    }
}