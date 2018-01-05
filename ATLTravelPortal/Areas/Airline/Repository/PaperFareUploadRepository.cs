using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using ATLTravelPortal.Areas.Airline.Models;

namespace ATLTravelPortal.Areas.Airline.Repository
{
    public class PaperFareUploadRepository
    {
        public List<FileUploadModel> GetAllFileDescription()
        {
            string uploadFolder = System.Web.Configuration.WebConfigurationManager.AppSettings["PaperFareUpPath"]; //HttpContext.Current.Server.MapPath("/PaperFareUploads");
            if (!Directory.Exists(uploadFolder))
            {
                Directory.CreateDirectory(uploadFolder);
            }
            string[] files = Directory.GetFiles(uploadFolder);
            List<FileUploadModel> fileDescriptions = new List<FileUploadModel>();

            foreach (string file in files)
            {
                FileInfo fileinfo = new FileInfo(file);
                fileDescriptions.Add(
                    new FileUploadModel
                    {
                        Name = fileinfo.Name,
                        Size = fileinfo.Length / 1024,
                        WebPath = fileinfo.Name,
                        DateCreated = fileinfo.CreationTime
                    });
            }

            return fileDescriptions;
        }
    }
}