using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ATLTravelPortal.Areas.Airline.Models
{
    public enum Fare
    {
        ShowFare,
        HideFare
    }
    public enum AllFares
    {
        showallfares,
        hideallfares,
        showonlypublishedfares
    }
    public enum ServiceCharge
    {
        includeintax,
        showasservicecharge
    }

    public class AgentConfigurationsModel
    {
        public int AgentConfugrationId { get; set; }
        public int AgentId { get; set; }


        public Fare rdbgroupFare { get; set; }

        //[DisplayName("Hide Fare")]
        //public bool rdbHideFare { get; set; }


        public AllFares rdbAllFares { get; set; }

        
        public bool chkEmailBooking { get; set; }

      
        public bool chkEmailPNR { get; set; }

       
        public bool chkMailTo { get; set; }

        [DisplayName("Send Mail to.")]
        public string txtSendMailTo { get; set; }

        public string txtEnterAlternativeEmail { get; set; }

        [DisplayName("Include in Tax")]
        public ServiceCharge rdbServiceCharge { get; set; }

       

        [DisplayName("Type")]
        public int ddlDomesticType { get; set; }

        [DisplayName("Value")]
        public Double txtDomesticValue { get; set; }

        [DisplayName("Type")]
        public int ddlInternationType { get; set; }

        [DisplayName("Value")]
        public Double txtInternationalValue { get; set; }

      


    }
}