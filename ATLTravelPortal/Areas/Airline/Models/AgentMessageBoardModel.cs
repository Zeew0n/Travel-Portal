using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ATLTravelPortal.Areas.Airline.Models;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.ComponentModel;
using TravelPortalEntity;

namespace ATLTravelPortal.Areas.Airline.Models
{
    public class AgentMessageBoardModel
    {
        public IEnumerable<Agents> AgentList { get; set; }
        public bool AgentName { get; set; }
        public string MessageTypes { get; set; }
        [Required(ErrorMessage="*")]
        public string HeadContains { get; set; }
        [Required(ErrorMessage="*")]
        public string MessageContains { get; set; }
        [Required(ErrorMessage="*")]
        [DisplayName("Effective From")]
        public DateTime EffectiveFrom { get; set ; }
        [Required(ErrorMessage="*")]
        [DisplayName("Expired On")]
        public DateTime  ExpiredOn { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        [Required(ErrorMessage="*")]
        public int MessageTypeId { get; set; }
        [Required(ErrorMessage="*")]
        public int PriorityId { get; set; }
        public bool IsForAllAgent { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string  AgentIdList { get; set; }
        public string Priority { get; set; }
        public int MessageBoardId { get; set; }
        public string CreatorName { get; set; }
        public string UpdatorName { get; set; }
        public IEnumerable<AgentMessageBoardModel> AgentMessageBoardList { get; set; }
    }
}