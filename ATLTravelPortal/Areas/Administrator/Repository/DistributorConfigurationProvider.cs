using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ATLTravelPortal.Areas.Administrator.Models;
using TravelPortalEntity;
using ATLTravelPortal.Utility;
using ATLTravelPortal.Areas.Airline;
using System.Web.Mvc;
namespace ATLTravelPortal.Areas.Administrator.Repository
{
    public class DistributorConfigurationProvider
    {
        EntityModel entity = new EntityModel();

        public IEnumerable<DistributorConfigurationModel> GetDistributorConfigurationContentsList()
        {
            var Data = entity.LayoutSetting;
            var ts = SessionStore.GetTravelSession();
            List<DistributorConfigurationModel> model = new List<DistributorConfigurationModel>();
            foreach (var item in Data)
            {
                DistributorConfigurationModel obj = new DistributorConfigurationModel(){
                LayoutSettingId = item.LayoutSettingId,
                DistributorID = ts.LoginTypeId,
                Title = item.Title,
                ContactUs = item.ContactUs,
                IsContactUsActive = item.IsContactUsActive,
                DashboardContent = item.DashboardContent,
                IsDashboardContentActive = item.IsDashboardContentActive,
                BankInfo = item.BankInfo,
                IsBankInfoActive = item.IsBankInfoActive,
                ScrollNews = item.ScrollNews,
                IsScrollNewsActive = item.IsScrollNewsActive,
                Logoimage = item.Logo,
                IsLogoActive = item.IsLogoActive,
                IsPublished = item.IsPublished,
                HeaderContact = item.HeaderContact,
                IsHeaderContactActive = item.IsHeaderContactActive,
                CreatedBy = item.CreatedBy,
                CreatedDate = item.CreatedDate,
                UpdatedBy = Convert.ToInt16(item.UpdatedBy),
                UpdatedDate = item.UpdatedDate,
                CreatedName = item.UsersDetails.FullName
            };
                

                model.Add(obj);
            }
            return model;
        }
        public bool SaveCreateDistributorConfigurationContents(DistributorConfigurationModel model)
        {
            LogoResizer logoResizer = new LogoResizer();
            var ts = SessionStore.GetTravelSession();
            LayoutSetting distributorConfigurationModelToSave = new LayoutSetting()
            {
                DistributorId = ts.LoginTypeId,
                Title = model.Title,
                ContactUs = model.ContactUs,
                IsContactUsActive = model.IsContactUsActive,
                DashboardContent = model.DashboardContent,
                IsDashboardContentActive = model.IsDashboardContentActive,
                IsLogoActive = model.IsLogoActive,
                HeaderContact = model.HeaderContact,
                IsHeaderContactActive = model.IsHeaderContactActive,
                ScrollNews = model.ScrollNews,
                IsScrollNewsActive = model.IsScrollNewsActive,
                BankInfo = model.BankInfo,
                IsBankInfoActive = model.IsBankInfoActive,
                CreatedBy = ts.AppUserId,
                CreatedDate = DateTime.UtcNow
            };

            if (model.Logo.ContentLength > 0)
            {
                switch (model.Logo.ContentType)
                {
                    case "image/jpeg":
                    case "image/pjpeg":
                    case "image/gif":
                    case "image/png":

                        distributorConfigurationModelToSave.ImageType = model.Logo.ContentType;
                        Int32 length = model.Logo.ContentLength;
                        byte[] tempFile = new byte[length];
                        model.Logo.InputStream.Read(tempFile, 0, model.Logo.ContentLength);
                        tempFile = logoResizer.ValidatePicture(tempFile, model.Logo.ContentType);
                        distributorConfigurationModelToSave.Logo = tempFile;
                        break;
                }
            }
            entity.AddToLayoutSetting(distributorConfigurationModelToSave);
            entity.SaveChanges();
            return true;
        }
        public DistributorConfigurationModel GetDistributorConfigurationEdit(int Id)
        {
           
            var Data = entity.LayoutSetting.Where(x=>x.LayoutSettingId==Id).FirstOrDefault();
            DistributorConfigurationModel model = new DistributorConfigurationModel()
            {

               LayoutSettingId = Data.LayoutSettingId,
                Title = Data.Title,
                ContactUs = Data.ContactUs,
                IsContactUsActive = Data.IsContactUsActive,
                DashboardContent = Data.DashboardContent,
                IsDashboardContentActive = Data.IsDashboardContentActive,
                Logoimage = Data.Logo,
                IsLogoActive = Data.IsLogoActive,
                HeaderContact = Data.HeaderContact,
                IsHeaderContactActive = Data.IsHeaderContactActive,
                ScrollNews = Data.ScrollNews,
                IsScrollNewsActive = Data.IsScrollNewsActive,
                IsPublished = Data.IsPublished,
                BankInfo = Data.BankInfo,
                IsBankInfoActive = Data.IsBankInfoActive
                
                  };
            return model;
        }



      


        public void UpdateIsPublished(int Id)
        {
            var Data = entity.LayoutSetting.Where(x => x.DistributorId == Id);
            if (Data != null)
            {
                foreach (var item in Data)
                {
                    if(item.IsPublished==true)
                    item.IsPublished = false;
                    entity.ApplyCurrentValues(item.EntityKey.EntitySetName, item);
                    entity.SaveChanges();
                }
            }
        }


        public void SaveEditDistributorConfigurationContents(DistributorConfigurationModel model)
        {
            LogoResizer logoResizer = new LogoResizer();
            var ts = SessionStore.GetTravelSession();
            var Data = entity.LayoutSetting.Where(x => x.LayoutSettingId == model.LayoutSettingId).FirstOrDefault();
            Data.DistributorId= ts.LoginTypeId;
            Data.Title = model.Title;
            Data.ContactUs = model.ContactUs;
            Data.IsContactUsActive = model.IsContactUsActive;
            Data.DashboardContent = model.DashboardContent;
            Data.IsDashboardContentActive = model.IsDashboardContentActive;
            Data.HeaderContact = model.HeaderContact;
            Data.IsHeaderContactActive = model.IsHeaderContactActive;
            Data.ScrollNews = model.ScrollNews;
            Data.BankInfo = model.BankInfo;
            Data.IsBankInfoActive = model.IsBankInfoActive;
            Data.IsLogoActive = model.IsLogoActive;
            Data.IsPublished = model.IsPublished;
            Data.CreatedBy = ts.AppUserId;
            Data.CreatedDate = DateTime.UtcNow;

            if (model.Logo != null)
            {
                if (model.Logo.ContentLength > 0)
                {
                    switch (model.Logo.ContentType)
                    {
                        case "image/jpeg":
                        case "image/pjpeg":
                        case "image/gif":
                        case "image/png":

                            Data.ImageType = model.Logo.ContentType;
                            Int32 length = model.Logo.ContentLength;
                            byte[] tempFile = new byte[length];
                            model.Logo.InputStream.Read(tempFile, 0, model.Logo.ContentLength);
                            tempFile = logoResizer.ValidatePicture(tempFile, model.Logo.ContentType);
                            Data.Logo = tempFile;
                            break;
                    }
                }
            }

            entity.ApplyCurrentValues(Data.EntityKey.EntitySetName, Data);
            entity.SaveChanges();

        }
        public void Delete(int id)
        {
            LayoutSetting result = entity.LayoutSetting.Where(x => x.LayoutSettingId == id).FirstOrDefault();
            entity.DeleteObject(result);
            entity.SaveChanges();
        }

       

    }
}