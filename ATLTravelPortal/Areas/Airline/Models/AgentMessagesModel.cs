using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Web.Mvc;

namespace ATLTravelPortal.Areas.Airline.Models
{
    public class AgentMessagesModel
    {
        public int AgentMessageId { get; set; }

        [Required]
        [DisplayName("Agent")]
        public int AgentId { get; set; }
        public string AgentName { get; set; }
        public IEnumerable<SelectListItem> AgentList { get; set; }

        [Required]
        [DisplayName("Product")]
        public int Productid { get; set; }
        public string ProductName { get; set; }
        public IEnumerable<SelectListItem> ProductList { get; set; }


        [Required]
        [DisplayName("Message")]
        public string MessageText { get; set; }

        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }




        public IEnumerable<AgentMessagesModel> AgentMessageList { get; set; }
    }
}