using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ATLTravelPortal.Models
{
    public class ActionResponse
    {
        public int ErrNumber{get;set;}
        public string ActionMessage { get; set; }
        public string ErrSource { get; set; }
        public string ErrType { get; set; }
        public bool ResponseStatus { get; set; }
    }
}