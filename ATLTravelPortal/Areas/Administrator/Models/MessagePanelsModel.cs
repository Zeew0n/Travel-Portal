using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Web.Mvc;

namespace ATLTravelPortal.Areas.Administrator.Models
{
    public class MessagePanelsModel
    {
        [Required]
        [DisplayName("Message Text:")]
        public string MessageText { get; set; }

        [DisplayName("Panel Name:")]
        public int PanNoId { get; set; }
        public IEnumerable<SelectListItem> PanNo { get; set; }

        public int MessagePanelId { get; set; }

        public IEnumerable<MessagePanelsModel> MessagePanelList { get; set; }
    }
}