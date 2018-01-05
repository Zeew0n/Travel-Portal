using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ATLTravelPortal.Areas.Airline.Models;
using TravelPortalEntity;
using System.Web.Mvc;

namespace ATLTravelPortal.Areas.Airline.Models
{
    public class PNRManagementModel
    {
        public string GDSPNR { get; set; }
        public IEnumerable<SelectListItem> TicketStatusList { get; set; }
        public PNRsModel PNRsModel { get; set; }
        public IEnumerable<PNRSegmentsModel> PNRSegmentsList { get; set; }
        public IEnumerable<PNRSectorModel> PNRSectorList { get; set; }
        public IEnumerable<PassengersModel> PassengerList { get; set; }

    }
}