using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ATLTravelPortal.Areas.Airline.Models;
using TravelPortalEntity;
using ATLTravelPortal.Helpers;
using AirLines.Provider.Admin;

namespace ATLTravelPortal.Areas.Airline.Repository
{
    public class FAQContentProvider
    {
        EntityModel ent = new EntityModel();
        FAQHeadingProvider _provider = new FAQHeadingProvider();

        public IEnumerable<FAQContentModel> GetList()
        {
            int sno = 0;
            List<FAQContentModel> ddlList = new List<FAQContentModel>();
            var result = ent.FaqContent;
            foreach (var item in result)
            {
                sno++;
                FAQContentModel obj = new FAQContentModel 
                {
                 SNO=sno,
                 FaqId = item.FaqId,
                 Question = item.Question,
                 HeadingTitle = _provider.GetHeadingTitle(item.HeadingId),
                 HeadingId = item.HeadingId,
                 Answer = item.Answer
                };
                ddlList.Add(obj);
            }
            return ddlList.AsEnumerable();
        }

        public void Save(FAQContentModel model)
        {
            FaqContent result = new FaqContent();
            result.HeadingId = model.HeadingId;
            result.Question = model.Question;
            result.Answer = model.Answer;
            result.StatusId = true;
            result.CreatedBy = model.CreatedBy;
            result.CreatedDate = DateTime.Now;
            ent.AddToFaqContent(result);
            ent.SaveChanges();
           
        }

        public void Edit(FAQContentModel model)
        {
            var result = ent.FaqContent.Where(x => x.FaqId == model.FaqId).FirstOrDefault();
            result.HeadingId = model.HeadingId;
            result.Question = model.Question;
            result.Answer = model.Answer;
            result.UpdatedBy = model.UpdatedBy;
            result.UpdatedDate = DateTime.Now;
            ent.ApplyCurrentValues(result.EntityKey.EntitySetName, result);
            ent.SaveChanges();
        }

        public FAQContentModel Details(int FaqId)
        {
            FAQContentModel model = new FAQContentModel();
            var result = ent.FaqContent.Where(x => x.FaqId == FaqId).FirstOrDefault();
            if (result != null)
            {
                model.FaqId = result.FaqId;
                model.HeadingId = result.HeadingId;
                model.HeadingTitle = _provider.GetHeadingTitle(result.HeadingId);
                model.Question = result.Question;
                model.Answer = result.Answer;
                model.statusId = result.StatusId;
                model.CreatedBy = result.CreatedBy;
                model.CreatedDate = result.CreatedDate;
                model.CreatorName = ent.UsersDetails.Where(x => x.AppUserId == result.CreatedBy).Select(x => x.FullName).FirstOrDefault();
                model.UpdatedBy = result.UpdatedBy;
                model.UpdatedDate = result.UpdatedDate;
                model.UpdatorName = ent.UsersDetails.Where(x => x.AppUserId == result.UpdatedBy).Select(x => x.FullName).FirstOrDefault();
            }
            return model;
        }

        public void Delete(int FaqId)
        {
            var result = ent.FaqContent.Where(x => x.FaqId == FaqId).FirstOrDefault();
            ent.DeleteObject(result);
            ent.SaveChanges();
        }
    }
}