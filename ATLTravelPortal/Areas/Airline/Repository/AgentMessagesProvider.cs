using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TravelPortalEntity;
using ATLTravelPortal.Areas.Airline.Models;
using System.Web.Mvc;

namespace ATLTravelPortal.Areas.Airline.Repository
{
    public class AgentMessagesProvider
    {
        EntityModel ent = new EntityModel();

        //for listing 
        public IEnumerable<AgentMessagesModel> GetAgentMessageList()
        {
            List<AgentMessagesModel> model = new List<AgentMessagesModel>();

            var result = ent.Core_AgentMessages;
            foreach (var item in result)
            {
                AgentMessagesModel obj = new AgentMessagesModel
                {

                    AgentMessageId = item.AgentMessageId,
                    AgentId = item.AgentId,
                    Productid = item.ProductId,
                    MessageText = item.MessageText,
                    CreatedBy = item.CreatedBy,
                    CreatedDate = item.CreatedDate,
                    AgentName = item.Agents.AgentName,
                    ProductName = item.Core_Products.ProductName

                };
                model.Add(obj);
            }
            return model.AsEnumerable();
        }

        //for adding into AgentMessage Table
        public void AgentMessageAdd(AgentMessagesModel modelToSave)
        {

            Core_AgentMessages datamodel = new Core_AgentMessages()
            {
                AgentId = modelToSave.AgentId,
                ProductId = modelToSave.Productid,
                MessageText = modelToSave.MessageText,
                CreatedBy = 1,
                CreatedDate = DateTime.Now
            };

            ent.AddToCore_AgentMessages(datamodel);
            ent.SaveChanges();
        }

        //for edit
        public void AgentMessageEdit(AgentMessagesModel model)
        {
            Core_AgentMessages result = ent.Core_AgentMessages.Where(x => x.AgentMessageId == model.AgentMessageId).FirstOrDefault();


            result.AgentMessageId = model.AgentMessageId;
            result.AgentId = model.AgentId;
            result.ProductId = model.Productid;
            result.MessageText = model.MessageText;
            result.UpdatedBy = 1;
            result.UpdatedDate = DateTime.Now;

            ent.ApplyCurrentValues(result.EntityKey.EntitySetName, result);
            ent.SaveChanges();
        }

        public AgentMessagesModel GetAgentMessageDetail(int AgentMessageId)
        {
            Core_AgentMessages result = ent.Core_AgentMessages.Where(x => x.AgentMessageId == AgentMessageId).FirstOrDefault();
            AgentMessagesModel model = new AgentMessagesModel();

            model.AgentMessageId = result.AgentMessageId;
            model.AgentId = result.AgentId;
            model.Productid = result.ProductId;
            model.MessageText = result.MessageText;
            model.CreatedDate = result.CreatedDate;
            model.CreatedBy = result.CreatedBy;
            model.AgentName = result.Agents.AgentName;
            model.ProductName = result.Core_Products.ProductName;


            return model;

        }

        //for delete
        public void AgentMessageDelete(int AgentMessageId)
        {
            Core_AgentMessages result = ent.Core_AgentMessages.Where(x => x.AgentMessageId == AgentMessageId).FirstOrDefault();
            ent.DeleteObject(result);
            ent.SaveChanges();
        }



        public List<Core_Products> GetProductList()
        {
            return ent.Core_Products.Where(tt => tt.isActive == true).ToList();
        }

        public IEnumerable<SelectListItem> GetAllProductList()
        {
            List<Core_Products> all = GetProductList().ToList();
            var GetAllProductList = new List<SelectListItem>();
            foreach (var item in all)
            {
                var teml = new SelectListItem
                {
                    Text = item.ProductName,
                    Value = item.ProductId.ToString()
                };
                GetAllProductList.Add(teml);
            }
            return GetAllProductList.AsEnumerable();
        }

    }
}