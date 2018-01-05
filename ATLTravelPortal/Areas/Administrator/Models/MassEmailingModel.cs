using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ATLTravelPortal.Areas.Administrator.Models.Enums;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
//using ATLTravelPortal.App_Class.Validation;

namespace ATLTravelPortal.Areas.Administrator.Models
{
    public class MassEmailingModel
    {
        [DisplayName("Agent Class")]
        public int? AgentClassId { get; set; }
        public IEnumerable<SelectListItem> AgentClasses { get; set; }

        [DisplayName("Agent Deal")]
        public int? AgentDealId { get; set; }
        public IEnumerable<SelectListItem> AgentDeals { get; set; }

        [DisplayName("Zone")]
        public int? ZoneId { get; set; }
        public IEnumerable<SelectListItem> Zones { get; set; }

        [DisplayName("District")]
        public int? DistrictId { get; set; }
        public IEnumerable<SelectListItem> Districts { get; set; }

        [DisplayName("Agent Type")]
        public int? AgentTypeId { get; set; }
        public IEnumerable<SelectListItem> AgentTypes { get; set; }

        [Required(ErrorMessage=" ")]
        [DisplayName("Email Message")]
        public string EmailMessage { get; set; }

        [DisplayName("SMS Message")]
        public string SMSMessage { get; set; }

        [DisplayName("Message Type")]
        public MessageType MessageType { get; set; }

        [DisplayName("Only Specified Agents")]
        public string SpecifiedAgents { get; set; }

       
        //[App_Class.Validation.RegularExpression("MultipleEmail", IsMandatory = false)]
        [DisplayName("Only Specified Email")]
        [RegularExpression(@"^(\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*\b([,;]\s?)?)*$", ErrorMessage = "Not a valid Email")]
        public string FreeEmail { get; set; }


        [DisplayName("Only Specified Mobile No")]
        public string FreeMobileNo { get; set; }

        [DisplayName("Subject")]
        [Required(ErrorMessage=" ")]
        public string Subject { get; set; }

        public int MessageSenderUserId { get; set; }
    }
}