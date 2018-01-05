using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Web.Mvc;

namespace ATLTravelPortal.Areas.Airline.Models
{
    public class AirlineFlightTaxesModel
    {
        [Required(ErrorMessage = "*")]
        [DisplayName("Fare Tax")]
        public string FareTaxName { get; set; }

        [DisplayName("Is Active")]
        public bool isActive { get; set; }

        public int FareTaxId { get; set; }

        public IEnumerable<AirlineFlightTaxesModel> AirlineFlightTaxesList { get; set; }

    }
}