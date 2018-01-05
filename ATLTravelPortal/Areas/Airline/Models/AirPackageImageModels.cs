using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Configuration;

namespace ATLTravelPortal.Areas.Airline.Models
{
    public class AirPackageImageModel : FormPropertyModel<AirPackageImageModel>
    {       
        public int PackageImageId { get; set; }

        public int PackageId { get; set; }
        
        public string PackageName { get; set; }
        public string PackageImageFolder { get; set; }
        public string PackageDefaultImageId { get; set; }
        public string ImageCaption { get; set; }
        public string ImageName { get; set; }
          
        public string PackageImageRootPath
        {
            get { return (ConfigurationManager.AppSettings["PackageImageRootPath"]); }
        }

        public List<PackageImageUploader> ImageUploader { get; set; }
    }

    public class PackageImageUploader 
    {
        [Required(ErrorMessage = "Caption Required")]
        [DisplayName("Image Caption: ")]
        public string UploadedImageCaption { get; set; }

        [Required(ErrorMessage = "File Required")]
        public HttpPostedFileBase UploadedFile { get; set; }
    
    }

}