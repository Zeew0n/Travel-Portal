using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TravelPortalEntity;
using ATLTravelPortal.Areas.Administrator.Models;

namespace ATLTravelPortal.Areas.Administrator.Repository
{
    public class DashboardContentProvider
    {
        EntityModel ent = new EntityModel();

        public List<DashboardContentsModel> GetDashBoardContentsList()
        {
            var result = ent.Core_DashboardContentsB2C;
            List<DashboardContentsModel> model = new List<DashboardContentsModel>();
            foreach (var item in result)
            {
                DashboardContentsModel obj = new DashboardContentsModel();
                obj.DasbBoardContentId = item.DashboardContentId;
                obj.Title = item.Title;
                obj.Body = item.Body;
                obj.CreatedBy = item.CreatedBy;
                obj.CreatedName = item.UsersDetails.FullName;
                obj.CreatedDate = item.CreatedDate;
                obj.UpdatedBy = item.UpdatedBy;
                obj.UpdatedName = item.UsersDetails.FullName;
                obj.UpdatedDate = item.UpdatedDate;
                obj.IsPublished = item.isPublished;
                model.Add(obj);
            }
            return model.ToList();
        }

        public int CreateDashBoardContents(DashboardContentsModel model)
        {
            Core_DashboardContentsB2C obj = new Core_DashboardContentsB2C();

            obj.Title = model.Title;
            obj.Body = model.Body;
            obj.isPublished = model.IsPublished;
            obj.CreatedBy = model.CreatedBy;
            obj.CreatedDate = DateTime.Now;

            ent.AddToCore_DashboardContentsB2C(obj);
            ent.SaveChanges();
            return obj.DashboardContentId;
        }

        public void EditDashBoardContents(DashboardContentsModel model)
        {
            Core_DashboardContentsB2C result = ent.Core_DashboardContentsB2C.Where(u => u.DashboardContentId == model.DasbBoardContentId).FirstOrDefault();

            if (result != null)
            {
                result.Title = model.Title;
                result.Body = model.Body;
                result.isPublished = model.IsPublished;
                result.UpdatedBy = model.UpdatedBy;
                result.UpdatedDate = model.UpdatedDate;

                ent.ApplyCurrentValues(result.EntityKey.EntitySetName, result);
                ent.SaveChanges();
            }
        }

        public void UpdateIsPublished(int Id, DashboardContentsModel model)
        {
            List<Core_DashboardContentsB2C> result = ent.Core_DashboardContentsB2C.Where(u => u.DashboardContentId != Id).ToList();
            if (result != null)
            {
                foreach (var item in result)
                {
                    item.isPublished = model.IsPublished;
                    ent.ApplyCurrentValues(item.EntityKey.EntitySetName, item);
                    ent.SaveChanges();
                }
            }
        }


        public DashboardContentsModel GetDashboardContentsDetail(int id)
        {
            Core_DashboardContentsB2C result = ent.Core_DashboardContentsB2C.Where(x => x.DashboardContentId == id).FirstOrDefault();
            if (result != null)
            {
                DashboardContentsModel model = new DashboardContentsModel();

                model.DasbBoardContentId = result.DashboardContentId;
                model.Title = result.Title;
                model.Body = result.Body;
                model.CreatedBy = result.CreatedBy;
                model.CreatedName = result.UsersDetails.FullName;
                model.CreatedDate = result.CreatedDate;
                model.UpdatedBy = result.UpdatedBy;
                model.UpdatedName = result.UsersDetails.FullName;
                model.UpdatedDate = result.UpdatedDate;
                model.IsPublished = result.isPublished;

                return model;
            }
            return null;
        }

        public DashboardContentsModel GetCMSContent(int id)
        {
            Core_DashboardContentsB2C result = ent.Core_DashboardContentsB2C.Where(x => x.DashboardContentId == id).FirstOrDefault();
            string Contents = string.Empty;
            if (result != null)
            {
                DashboardContentsModel model = new DashboardContentsModel();
                model.Body = ATLTravelPortal.Helpers.CMSContents.GetCMSContents(result.Body);
                return model;
            }
            return null;
        }

        public DashboardContentsModel GetDashboardContentsDetailByUserId(int Userid)
        {
            Core_DashboardContentsB2C result = ent.Core_DashboardContentsB2C.Where(x => x.CreatedBy == Userid).FirstOrDefault();
            if (result != null)
            {
                DashboardContentsModel model = new DashboardContentsModel();

                model.DasbBoardContentId = result.DashboardContentId;
                model.Title = result.Title;
                model.Body = result.Body;
                model.CreatedBy = result.CreatedBy;
                model.CreatedName = result.UsersDetails.FullName;
                model.CreatedDate = result.CreatedDate;
                model.UpdatedBy = result.UpdatedBy;
                model.UpdatedName = result.UsersDetails.FullName;
                model.UpdatedDate = result.UpdatedDate;

                return model;
            }
            return null;
        }


        public void Delete(int id)
        {
            Core_DashboardContentsB2C result = ent.Core_DashboardContentsB2C.Where(x => x.DashboardContentId == id).FirstOrDefault();
            ent.DeleteObject(result);
            ent.SaveChanges();
        }


    }
}