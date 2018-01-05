using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
 using ATLTravelPortal.Helpers;

namespace  ATLTravelPortal.Areas.Airline.Models
{
    public class AirLineLedgerTransactionModel
    {
        [Required(ErrorMessage = "*")]
        [DisplayName("Transaction Date")]
        public DateTime TranDate { get; set; }

        //[Required(ErrorMessage = "*")]
        //[Helpers.Min(MinValue = 1, IsMandatory = true, ErrorMessage = "Please select Agentname!!")]
        //[Range(1, 1000)]
        //[DisplayName("Agent Name")]
        //[Range(1, 1000)]
        [Helpers.Min(MinValue=1,IsMandatory=true,ErrorMessage="Please Select AgentName")]
        [Required(ErrorMessage="*")]
        [Range(1,int.MaxValue,ErrorMessage="*")]
        [DisplayName("Agent Name")]
        public int AgentId { get; set; }
        public string AgentName { get; set; }

        [DisplayName("PNR Group")]
        public Int64 PNRGroupId { get; set; }

        [DisplayName("Transaction Mode")]
        public string TranMode { get; set; }

        //[Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(Resources.ValidationStrings))]
        //[StringLength(1000, ErrorMessage = "Must be under 1000 Characters")]
        //[DisplayName("City Name")]
        //public string Name { get; set; }


        [Required(ErrorMessage = "*")]
        [DisplayName("Amount")]
        public decimal TranAmount { get; set; }

        [DisplayName("Reference No.")]
        public string RefrenceNo { get; set; }

        [Required(ErrorMessage = "*")]
        [DisplayName("Narration1")]
        public string Narration1 { get; set; }

        [DisplayName("Narration2")]
        public string Narration2 { get; set; }

        [DisplayName("Maker")]
        public int MakerID { get; set; }

        [DisplayName("Maker Date")]
        public DateTime MakerDate { get; set; }

        [DisplayName("Checker")]
        public int CheckerID { get; set; }

        [DisplayName("Checker Date")]
        public DateTime CheckerDate { get; set; }

        [DisplayName("Amount In Words")]
        public string TranAmtInWords { get; set; }

        [DisplayName("Deleted")]
        public int DeletedBy { get; set; }

        [DisplayName("Deleted Date")]
        public DateTime DeleteDate { get; set; }
        public IEnumerable<AirLineLedgerTransactionModel> AirLineLedgerTransaction { get; set; }
    }
}