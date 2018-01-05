using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Web.Mvc;

namespace ATLTravelPortal.Areas.Airline.Models
{
    public class AirLinesModel
    {
        public int AirlineId { get; set; }

        public int LedgerId { get; set; }
        public string LedgerName { get; set; }


        [Required(ErrorMessage = "*")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [StringLength(3, ErrorMessage = "Please enter <= 3 characters")]
        [DisplayName("Code")]
        public string AirlineCode { get; set; }

        [Required(ErrorMessage = "*")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [StringLength(200, ErrorMessage = "Please enter <= 200 characters")]
        [DisplayName("Name")]
        public string AirlineName { get; set; }

        [Required(ErrorMessage = "*")]
        public string Photo { get; set; }


        public bool chkSettlement { get; set; }



        public string id { get; set; }

        public int LedId { get; set; }

        public Int64? SettlmentLedgerId { get; set; }

        public IEnumerable<SelectListItem> airlineList { get; set; }



        [Required(ErrorMessage = "*")]
        [DisplayName("Airline Type")]
        public int AirlineTypId { get; set; }
        public IEnumerable<SelectListItem> AirlineTypList { get; set; }


        [Required(ErrorMessage = "*")]
        [DisplayName("Country")]
        public string CountryId { get; set; }
        public string CountryName { get; set; }
        public IEnumerable<SelectListItem> CountryList { get; set; }

        [DisplayName("Account Type")]
        public int AccTypes { get; set; }
        public IEnumerable<SelectListItem> AccTypesList { get; set; }

        public int BSPorConsolidatorId { get; set; }
        public IEnumerable<SelectListItem> BSPorConsolidatorList { get; set; }
    }
}