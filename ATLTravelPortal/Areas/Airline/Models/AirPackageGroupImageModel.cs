using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Configuration;


namespace ATLTravelPortal.Areas.Airline.Models
{
    public class AirPackageGroupImageModel : FormPropertyModel<AirPackageGroupImageModel>
    {
        public int PackageGroupImageId { get; set; }
        public int PackageGroupId { get; set; }

        public string PackageGroupName { get; set; }
        public string PackageGroupImageFolder { get; set; }
        public string PackageDefaultGroupImageId { get; set; }
        public string ImageCaption { get; set; }
        public string ImageName { get; set; }
        public IEnumerable<AirPackageGroupImageModel> ImageList { get; set; }

     
     public string PackageImageRootPath
        {
            get { return (ConfigurationManager.AppSettings["PackageImageRootPath"]); }
        }

        public List<PackageGroupImageUploader> ImageUploader { get; set; }
    }

    public class PackageGroupImageUploader 
    {
        [Required(ErrorMessage = "Caption Required")]
        [Display(Name = "Image Caption:")]
        public string UploadedImageCaption { get; set; }

        [Required(ErrorMessage = "File Required")]
        public HttpPostedFileBase UploadedFile { get; set; }
    
    }
}