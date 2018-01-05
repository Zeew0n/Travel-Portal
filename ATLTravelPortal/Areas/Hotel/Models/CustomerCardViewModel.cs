using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ATLTravelPortal.Areas.Hotel.Models
{
    public class CustomerCardViewModel
    {
        public bool cardnumber { get; set; }

        [Required(ErrorMessage = "*")]
        [DisplayName("Customer Cards")]
        public Int32 CustomerCardsId { get; set; }

        [Required(ErrorMessage = "*")]
        [DisplayName("Agent")]
        public Int32 AgentId { get; set; }

        [Required(ErrorMessage = "Select")]
        public List<SelectListItem> CardId { get; set; }

        [Required(ErrorMessage = "*")]
        [DisplayName("Customer ")]
        public Int32 CustomerId { get; set; }

       
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


    }
}