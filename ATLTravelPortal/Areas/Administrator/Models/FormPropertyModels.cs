using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ATLTravelPortal.Helpers.Pagination;

namespace ATLTravelPortal.Areas.Administrator.Models
{
    public class FormPropertyModel<T>
    {
        public string formArea { get; set; }
        public string formBaseUrl { get; set; }

        public string formActionName { get; set; }
        public string formControllerName { get; set; }
        public string formOnSubmitAction { get; set; }
        public string formSubmitBttnName { get; set; }
        public string formCancelOnClick { get; set; }
        public string formSubmitOnClick { get; set; }
        public string addMoreOnClick { get; set; }
        private string _formSubmitType = "add";
        public string FormSubmitType
        {
            get { return _formSubmitType; }
            set { _formSubmitType = value; }
        }
        private bool _showMask = true;
        public bool ShowMask
        {
            get { return _showMask; }
            set { _showMask = value; }
        }

        public IPagedList<T> TablularRecordList { get; set; }
        public IEnumerable<T> TablularRecordExportList { get; set; }


    }
}