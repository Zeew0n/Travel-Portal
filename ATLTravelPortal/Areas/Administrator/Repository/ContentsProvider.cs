using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TravelPortalEntity;
using ATLTravelPortal.Areas.Administrator.Models;

namespace ATLTravelPortal.Areas.Administrator.Repository
{
    public class ContentsProvider
    {
        EntityModel ent = new EntityModel();

        public void CreateContents(ContentsModel model)
        {
            Core_Contents obj = new Core_Contents();

            obj.Title = model.Title;
            obj.Value = model.URL;
            obj.URL =  model.URL;
            obj.Body = model.Body;
            obj.isPublished = model.isPublish;
            obj.CreatedBy = model.CreatedBy;
            obj.CreatedDate = DateTime.Now;

            ent.AddToCore_Contents(obj);
            ent.SaveChanges();

        }

        public void EditContents(ContentsModel model)
        {

            Core_Contents result = ent.Core_Contents.Where(u => u.ContantId == model.ContentId).FirstOrDefault();

            if (result != null)
            {
              
                result.Title = model.Title;
                result.Value = model.URL;
                result.URL =  model.URL;
                result.Body = model.Body;
                result.isPublished = model.isPublish;
                result.UpdatedBy = model.UpdatedBy;
                result.UpdatedDate = DateTime.Now;


                ent.ApplyCurrentValues(result.EntityKey.EntitySetName, result);
                ent.SaveChanges();
            }
        }

        public List<ContentsModel> GetContentsList()
        {
            var result = ent.Core_Contents;
            List<ContentsModel> model = new List<ContentsModel>();
            foreach (var item in result)
            {
                ContentsModel obj = new ContentsModel();

                obj.ContentId = item.ContantId;
                obj.Title = item.Title;
                obj.Value = item.Value;
                obj.URL = item.URL;
                obj.Body = item.Body;
                obj.isPublish = item.isPublished;
                obj.CreatedName = item.UsersDetails.FullName;
                obj.CreatedDate = item.CreatedDate;


                model.Add(obj);
            }
            return model.ToList();
        }

        public ContentsModel GetContentsDetail(int id)
        {
            Core_Contents result = ent.Core_Contents.Where(x => x.ContantId == id).FirstOrDefault();
            if (result != null)
            {
                ContentsModel model = new ContentsModel();
              
                model.ContentId = result.ContantId;
                model.Title = result.Title;
                model.Value = result.Value;
                model.URL = result.URL;
                model.Body = result.Body;
                model.isPublish = result.isPublished;

                return model;
            }
            return null;
        }

        public ContentsModel GetPreview(int id)
        {
            Core_Contents result = ent.Core_Contents.Where(x => x.ContantId == id).FirstOrDefault();
            if (result != null)
            {
                ContentsModel model = new ContentsModel();
                model.Body = ATLTravelPortal.Helpers.CMSContents.GetCMSContents(result.Body);
                return model;
            }
            return null;
        }

        public void Delete(int id)
        {
            Core_Contents result = ent.Core_Contents.Where(x => x.ContantId == id).FirstOrDefault();
            ent.DeleteObject(result);
            ent.SaveChanges();
        }

      
    }
}