using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;

namespace ATLTravelPortal.Areas.Administrator.Models
{
    public class B2CHitCountModel
    {
        [DisplayName("From")]
        public DateTime? FromDate { get; set; }

        [DisplayName("To")]
        public DateTime? ToDate { get; set; }

        [DisplayName("Count")]
        public int CountB2CHitCount { get; set; }

    }
}