using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ATLTravelPortal.Models
{
    public class FormPropertyModel<T>
    {
        
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public IEnumerable<T> TabularRecordList { get; set; }

        public int ErrorNo { get; set; }
        public string ActionMessage { get; set; }
       

    }
}