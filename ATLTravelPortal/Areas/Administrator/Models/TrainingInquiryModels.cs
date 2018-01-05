using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ATLTravelPortal.Areas.Administrator.Models
{


    public class TrainingInquiryModel : FormPropertyModel<TrainingInquiryModel>
    {

        public int PId { get; set; }

        public string FullName { get; set; }
        
        public string CompanyName { get; set; }
        
        public string EmailAddress { get; set; }
        
        public string ContactNo { get; set; }
        
        public bool IsAgent { get; set; }
        
        public string ObjectiveOfTraning { get; set; }
        
        public string PreferredDay { get; set; }
        
        public string PrefferedTime { get; set; }
        
        public string Remarks { get; set; }

    }
}