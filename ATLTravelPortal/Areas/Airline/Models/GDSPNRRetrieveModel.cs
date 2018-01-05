using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Galileo.PnrService;
using TravelPortalEntity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ATLTravelPortal.Areas.Airline.Models
{
    public class PNRRetrieveResult
    {

        private int agent_id = 1;
        [DisplayName("Agent:")]
        public int AgentId
        {
            get
            {
                return agent_id;
            }
            set
            {
                agent_id = value;
            }
        }


        [Required(ErrorMessage = "*")]
        [DisplayName("Record Locator")]
        public string RecordLocator { get; set; }

        public List<AirSegment> segList;
        public List<PassengerDetail> passengerList;
        public List<VendorRemark> vndRemark;
        public List<VendorRecordLocator> vendorRecordLocatorList;
        public List<SeatSell> seatSellList;
        public List<PhoneDetail> phoneInfo;


        public string CodeCheck { get; set; }
        public string CreatingAgncyIATANum { get; set; }
        public string CreatingAgntSignOn { get; set; }
        public DateTime CreationDt { get; set; }
        public string CurAgncyPCC { get; set; }
        public string CurAgntSONID { get; set; }
        public DateTime CurDtStamp { get; set; }
        public string CurTmStamp { get; set; }
        public string ETkDataExistInd { get; set; }
        public string FareDataExistsInd { get; set; }
        public string FileAddr { get; set; }
        public string HeaderLine { get; set; }
        public string IMUdataexists { get; set; }
        public string MCODataExists { get; set; }
        public string OrigBkLocn { get; set; }
        public string OrigRcvd { get; set; }
        public string PNRAutoNotifyInd { get; set; }
        public string PNRAutoServiceInd { get; set; }
        public string PNRBFChangeInd { get; set; }
        public DateTime PNRBFPurgeDt { get; set; }
        public string PNRBFTicketedInd { get; set; }
        public string QInd { get; set; }
        public string RecLoc { get; set; }
        public string TkArrangement { get; set; }
        public string TkNumExistInd { get; set; }

        public long PNRId { get; set; }
        public string GDSReferenceNumber { get; set; }
        public string PassengerName { get; set; }
        public string Sector { get; set; }

        public IEnumerable<Air_GetToRetrivePNRs_Result> VendorLocatorToRetrive { get; set; }
        public IEnumerable<PNRRetrieveResult> VendorLocatorList { get; set; }


    }
}