using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ATLTravelPortal.Helpers.Pagination;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ATLTravelPortal.Areas.Administrator.Models
{
    public class ErrorLogModel
    {

        public DateTime time_stamp { get; set; }
        public string source { get; set; }
        public string message { get; set; }
        public string logger { get; set; }

        [DisplayName("From")]
        [Required]
        public DateTime? FromDate { get; set; }

        [Required]
        [DisplayName("To")]
        public DateTime? ToDate { get; set; }

        //public IEnumerable<ErrorLogModel> ErrorLogList { get; set; }

        public IPagedList<ErrorLogModel> ErrorLogList { get; set; }


       
    }
}