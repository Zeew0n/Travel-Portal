using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Configuration;
using System.IO;

namespace ATLTravelPortal.Models
{
    public class PackageModel
    {
        public int PackageId { get; set; }

        [Required(ErrorMessage = "Country Required")]
        [DisplayName("Country Name:")]
        public int CountryId { get; set; }

        [Required(ErrorMessage = "City Required")]
        [DisplayName("City Name:")]
        public int CityId { get; set; }

        [Required(ErrorMessage = "Name Required")]
        [DisplayName("Name:")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Package Code Required")]
        [DisplayName("Package Code:")]
        public string PackageCode { get; set; }

        [Required(ErrorMessage = "URL Required")]
        [DisplayName("URL:")]
        public string URL { get; set; }

        [DisplayName("Tags:")]
        public List<string> Tags { get; set; }

        [Required(ErrorMessage = "Starting Price Required")]
        [DisplayName("Starting Price:")]
        public decimal StartingPrice { get; set; }

        public decimal B2CMarkup { get; set; }

        [DisplayName("Description:")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Overview Required")]
        [DisplayName("Overview:")]
        public string Overview { get; set; }

        [DisplayName("Itineary:")]
        public string Itineary { get; set; }

        [DisplayName("Destination:")]
        public string Destination { get; set; }

        [DisplayName("Term And Conditions:")]
        public string TermAndConditions { get; set; }

        [DisplayName("Inclusive And Exclusive:")]
        public string InclusiveAndExclusive { get; set; }

        [DisplayName("Rate:")]
        public string Rate { get; set; }

        [Required(ErrorMessage = "Effective From Required")]
        [DisplayName("Effective From:")]
        public DateTime EffectiveFrom { get; set; }

        [Required(ErrorMessage = "Expire On Required")]
        [DisplayName("Expire On:")]
        public DateTime ExpireOn { get; set; }

        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }

        [DisplayName("Is Publish:")]
        public bool IsPublish { get; set; }

        public List<string> ImageNameList { get; set; }

        public List<PackageModel> PackageModelList { get; set; }

        [DisplayName("Image Folder:")]
        public string ImageFolderName { get; set; }

        public string PackageImageRootURL
        {
            get { return (ConfigurationManager.AppSettings["PackageImageRootURL"]); }
        }

        public string PackageImageRootPath
        {
            get { return (ConfigurationManager.AppSettings["PackageImageRootPath"]); }
        }

        public string DefaultImageName { get; set; }

        public string ImageURL
        {
            get
            {
                string file = PackageImageRootPath + "\\" + ImageFolderName + "\\Thumbnail\\" + DefaultImageName;
                if (File.Exists(file))
                {
                    return PackageImageRootURL + "/" + ImageFolderName + "/Thumbnail/" + DefaultImageName;
                }
                else
                {
                    return PackageImageRootURL + "/noimage.jpg";
                }
            }
        }
    }
}