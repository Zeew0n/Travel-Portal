using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using ATLTravelPortal.Helpers.Pagination;

namespace ATLTravelPortal.Areas.Administrator.Models
{
    public class LoginHistoriesModel
    {
        public Int64 HistoryId { get; set; }
        public string AgentName { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public DateTime? LogInDateTime { get; set; }
        public DateTime? LogOutDateTime { get; set; }

        [Required]
        [DisplayName("From")]
        public DateTime FromDate { get; set; }

        [Required]
        [DisplayName("To")]
        public DateTime ToDate { get; set; }

        public IPagedList<LoginHistoriesModel> LoginHistoriesList { get; set; }

    }
}