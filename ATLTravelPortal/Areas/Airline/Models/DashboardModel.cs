using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ATLTravelPortal.Areas.Airline.Models
{
    public class DashboardModel
    {
        [Required(ErrorMessage = "*")]
        [DisplayName("From")]
        public DateTime FromDate { get; set; }

        [Required(ErrorMessage = "*")]
        [DisplayName("To")]
        public DateTime ToDate { get; set; }
    }
}