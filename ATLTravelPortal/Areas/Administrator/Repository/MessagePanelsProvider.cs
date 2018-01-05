using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TravelPortalEntity;
using ATLTravelPortal.Areas.Administrator.Models;

namespace ATLTravelPortal.Areas.Administrator.Repository
{
    public class MessagePanelsProvider
    {

        EntityModel ent = new EntityModel();

        //for listing 
        public IEnumerable<MessagePanelsModel> GetMessagePanelList()
        {
            List<MessagePanelsModel> model = new List<MessagePanelsModel>();

            var result = ent.MessagePanels;
            foreach (var item in result)
            {
                MessagePanelsModel obj = new MessagePanelsModel
                {
                    MessagePanelId = item.MessagePanelId,
                    MessageText = System.Web.HttpUtility.HtmlDecode( item.MessageText),
                    PanNoId = item.PanelNo
                };
                model.Add(obj);
            }
            return model.AsEnumerable();
        }


        //for adding into MessagePanels Table
        public void MessagePanelAdd(MessagePanelsModel modelToSave)
        {
            MessagePanels datamodel = new MessagePanels
            {
              
                MessageText = modelToSave.MessageText,
                PanelNo = modelToSave.PanNoId

            };
            ent.AddToMessagePanels(datamodel);
            ent.SaveChanges();
        }

        //for edit
        public void MessagePanelEdit(MessagePanelsModel model)
        {
            MessagePanels result = ent.MessagePanels.Where(x => x.MessagePanelId == model.MessagePanelId).FirstOrDefault();

            result.MessagePanelId = model.MessagePanelId;
            result.MessageText = model.MessageText;
            result.PanelNo = model.PanNoId;

           
            ent.ApplyCurrentValues(result.EntityKey.EntitySetName, result);
            ent.SaveChanges();
        }

        public MessagePanelsModel GetMessagePanelsDetail(int MessagePanelsId)
        {
            MessagePanels result = ent.MessagePanels.Where(x => x.MessagePanelId == MessagePanelsId).FirstOrDefault();
            MessagePanelsModel model = new MessagePanelsModel();

           
            model.MessagePanelId = result.MessagePanelId;
            model.MessageText = result.MessageText;
            model.PanNoId = result.PanelNo;

            

            return model;

        }

        //for delete
        public void MessagePanelsDelete(int MessagePanelsId)
        {
            MessagePanels result = ent.MessagePanels.Where(x => x.MessagePanelId == MessagePanelsId).FirstOrDefault();
            ent.DeleteObject(result);
            ent.SaveChanges();
        }


    }
}