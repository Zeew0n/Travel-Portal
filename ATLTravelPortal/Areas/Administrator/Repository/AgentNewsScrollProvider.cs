using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ATLTravelPortal.Areas.Administrator.Models;
using TravelPortalEntity;

namespace ATLTravelPortal.Areas.Administrator.Repository
{
    public class AgentNewsScrollProvider
    {
        EntityModel ent = new EntityModel();

        //for listing 
        public IEnumerable<AgentNewsScrollModel> GetNewsScrollList()
        {
            List<AgentNewsScrollModel> model = new List<AgentNewsScrollModel>();

            var result = ent.ScrollNews;
            foreach (var item in result)
            {
                AgentNewsScrollModel obj = new AgentNewsScrollModel
                {
                   
                   ScrollNewsId = item.ScrollNewsId,
                   NewsText = item.NewsText,
                   IsActive = item.isActive,
                };
                model.Add(obj);
            }
            return model.AsEnumerable();
        }

        //for adding into ScrollNews Table
        public void ScrollNewsAdd(AgentNewsScrollModel modelToSave)
        {
            ScrollNews datamodel = new ScrollNews
            {
                NewsText = modelToSave.NewsText,
                isActive = modelToSave.IsActive,
                CreatedBy = 1,
                CreatedDate = DateTime.Now
            };
            ent.AddToScrollNews(datamodel);
            ent.SaveChanges();
        }

        //for edit
        public void ScrollNewsEdit(AgentNewsScrollModel model)
        {
            ScrollNews result = ent.ScrollNews.Where(x => x.ScrollNewsId == model.ScrollNewsId).FirstOrDefault();

          
            result.ScrollNewsId = model.ScrollNewsId;
            result.NewsText = model.NewsText;
            result.isActive = model.IsActive;
            result.CreatedBy = 1;
            result.CreatedDate = DateTime.Now;
            ent.ApplyCurrentValues(result.EntityKey.EntitySetName, result);
            ent.SaveChanges();
        }

        public AgentNewsScrollModel GetScrollNewsDetail(int ScrollNewsId)
        {
            ScrollNews result = ent.ScrollNews.Where(x => x.ScrollNewsId == ScrollNewsId).FirstOrDefault();
            AgentNewsScrollModel model = new AgentNewsScrollModel();

            model.ScrollNewsId = result.ScrollNewsId;
            model.NewsText = result.NewsText;
            model.IsActive = result.isActive;
            model.CreatedBy = result.CreatedBy;
            model.CreatedDate = result.CreatedDate;

            return model;

        }

        //for delete
        public void ScrollNewsDelete(int ScrollNewsId)
        {
            ScrollNews result = ent.ScrollNews.Where(x => x.ScrollNewsId == ScrollNewsId).FirstOrDefault();
            ent.DeleteObject(result);
            ent.SaveChanges();
        }



    }
}