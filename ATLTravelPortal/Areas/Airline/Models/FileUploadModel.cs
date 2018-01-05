using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ATLTravelPortal.Areas.Airline.Models
{
    public class FileUploadModel
    {
        public string Name { get; set; }
        public string WebPath { get; set; }
        public long Size { get; set; }
        public DateTime DateCreated { get; set; }
    }
}