using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ATLTravelPortal.Helpers.Pagination;

namespace ATLTravelPortal.Areas.Administrator.Models
{
    public class B2CVisitorInfoModel
    {
        public int VisitorId { get; set; }
        public int SN0 { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string ContactNo { get; set; }
        public string SRC { get; set; }
        public string Type { get; set; }
        public string Profession { get; set; }
        public DateTime? CreatedDate { get; set; }

        public IPagedList<B2CVisitorInfoModel> ListB2CVisitorInfo { get; set; }
        public List<B2CVisitorInfoModel> ListB2CVisitorInfoExport { get; set; }
    }
}