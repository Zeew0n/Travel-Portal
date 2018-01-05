using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ATLTravelPortal.Areas.Airline.Models
{
    public class ExportModel
    {

        public string ExportTypeExcel { get; set; }
        public string ExportTypeWord { get; set; }
        public string ExportTypeCSV { get; set; }
        public string ExportTypePdf { get; set; }

        public IEnumerable<ExportModel> BookedTicketListExport { get; set; }


    }
}