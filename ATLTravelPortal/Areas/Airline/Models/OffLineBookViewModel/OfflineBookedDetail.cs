using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ATLTravelPortal.Areas.Airline.Models.OffLineBookViewModel
{
    public class OfflineBookedDetail
    {
        public string AgentName { get; set; }
        public int AgentId { get; set; }

        public long MPNRId { get; set; }        

        public OfflineBookedPNRDetail OfflinePNRDetail { get; set; }

        //public List<OfflineSegmentDetail> OfflineSegment { get; set; }
    }

    public class OfflineBookedPNRDetail 
    {
        public int MyProperty { get; set; }
    }
}