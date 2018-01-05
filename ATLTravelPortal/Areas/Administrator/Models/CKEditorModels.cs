using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Configuration;
using System.Web.Security;
using System.ComponentModel;

namespace ATLTravelPortal.Areas.Administrator.Models
{
    public class CKEditorModel
    {
        public string DirectoryList { get; set; }
        public string ImageList { get; set; }
        public string NewDirectoryName { get; set; }
        public string SearchTerms { get; set; }
        public string NewImageName { get; set; }

        public string ImageURL { get; set; }
        [DisplayName("x")]
        public string ResizeWidth { get; set; }
        [DisplayName("y")]
        public string ResizeHeight { get; set; }
        public string ImageAspectRatio { get; set; }

        public HttpPostedFileBase UploadedImageFile { get; set; }

        public List<SelectListItem> ddlDirectoryList { get; set; }
        public List<SelectListItem> ddlImageList { get; set; }
        public string ImageHttpPath { get; set; }

        #region main ppt

        public string viewstate { get; set; }
        public string ImageFolderRoot
        {
            get { return (ConfigurationManager.AppSettings["ImageRoot"]); }
        }

        public string ImageContentURL
        {
            get { return (ConfigurationManager.AppSettings["ContentImageURL"]); }
        }

        public string FileImageFolderRoot
        {
            get { return ImageFolderRoot; }
        }

        public string ImageFolder
        {
          
            get { return ImageFolderRoot + viewstate; }
            set { viewstate = value; }
        }

        public string FileImageFolder
        {
            get { return ImageFolder; }

        }

        #endregion

    }
}