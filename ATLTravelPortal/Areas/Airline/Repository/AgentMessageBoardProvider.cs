using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AirLines.Provider;
using ATLTravelPortal.Areas.Airline.Models;
using TravelPortalEntity;
 using ATLTravelPortal.Helpers;



namespace ATLTravelPortal.Areas.Airline.Repository
{
    public class AgentMessageBoardProvider
    {
        EntityModel ent = new EntityModel();
        /// <summary>
        /// For saving the Messages
        /// </summary>
        /// <param name="model"></param>
        public void  SaveMessage(AgentMessageBoardModel model)
      {
         
              model.AgentIdList.Remove(model.AgentIdList.Length - 1);
              AgentMessageBoards obj = new AgentMessageBoards
              {
                  MessageTypeId = model.MessageTypeId,
                  MessagePriorityId = model.PriorityId,
                  isforAllAgent = model.IsForAllAgent,
                  HeadingContent = model.HeadContains,
                  MessageContent = model.MessageContains,
                  EffectiveFrom = model.EffectiveFrom,
                  ExpireOn = model.ExpiredOn,
                  AgentIdList = model.AgentIdList,
                  isActive = true,
                  CreatedBy = model.CreatedBy,
                  CreatedDate = DateTime.Now,
              };
              ent.AddToAgentMessageBoards(obj);
              ent.SaveChanges();
          
        }

        /// <summary>
        /// For viewing all the messages 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<AgentMessageBoardModel> GetMessageList()
        {
            var result = ent.AgentMessageBoards;
            List<AgentMessageBoardModel> _response = new List<AgentMessageBoardModel>();
            foreach (var item in result)
            {
                AgentMessageBoardModel model = new AgentMessageBoardModel 
                {
                 MessageTypes = item.MessageTypes.MessageTypeName,
                 HeadContains = item.HeadingContent,
                 Priority = item.MessagePriorities.MessagePriorityType,
                 EffectiveFrom = item.EffectiveFrom,
                 ExpiredOn = item.ExpireOn,
                 MessageBoardId = item.MessageBoardId,
                };
                _response.Add(model);
            }
            return _response.AsEnumerable();
        }

        /// <summary>
        /// For Viewing the details supply MessageBoardId
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public AgentMessageBoardModel GetMessageDetail(int Id)
        {
            var result =  ent.AgentMessageBoards.Where(x => x.MessageBoardId == Id).FirstOrDefault();
            AgentMessageBoardModel model = new AgentMessageBoardModel 
            {
                CreatedBy = result.CreatedBy,
                CreatedDate = result.CreatedDate,
                EffectiveFrom = result.EffectiveFrom,
                ExpiredOn = result.ExpireOn,
                MessageContains = result.MessageContent,
                PriorityId = result.MessagePriorityId,
                MessageTypeId = result.MessageTypeId,
                Priority = result.MessagePriorities.MessagePriorityType,
                HeadContains = result.HeadingContent, 
                MessageTypes = result.MessageTypes.MessageTypeName,
                UpdatedBy = result.UpdatedBy,
                UpdatedDate = result.UpdatedDate,
                AgentIdList = result.AgentIdList,
                IsForAllAgent = result.isforAllAgent,
                MessageBoardId = result.MessageBoardId
            };
            return model;
        }

        /// <summary>
        /// For Deleting Message supply the MessageBoardId
        /// </summary>
        /// <param name="Id"></param>
        public void DeleteMessage(int id)
        {

            AgentMessageBoards deleteMessage = ent.AgentMessageBoards.First(m => m.MessageBoardId == id);
            ent.DeleteObject(deleteMessage);
            ent.SaveChanges();
    

        }
       

        /// <summary>
        /// For Editing Message supply the MessageBoardId
        /// </summary>
        /// <param name="model"></param>
        public void EditMessage(AgentMessageBoardModel model)
        {
            //AgentMessageBoards comm = ent.AgentMessageBoards.Where(x => x.MessageBoardId == model.MessageBoardId).FirstOrDefault();
            //model.UpdatedBy= comm.UpdatedBy;
            //model.UpdatedDate=comm.UpdatedDate;
            //model.MessageBoardId = comm.MessageBoardId;
            EntityModel ent = new EntityModel();
            var result = ent.AgentMessageBoards.Where(x => x.MessageBoardId == model.MessageBoardId).FirstOrDefault();
           result.UpdatedBy = model.UpdatedBy ;
           result.UpdatedDate =  model.UpdatedDate ;
           result.AgentIdList = model.AgentIdList;
           result.HeadingContent = model.HeadContains;
           result.MessageContent = model.MessageContains;
           result.MessagePriorityId = model.PriorityId;
           result.MessageTypeId = model.MessageTypeId;
           result.ExpireOn = model.ExpiredOn;
           result.EffectiveFrom = model.EffectiveFrom;
            if (result != null)
            {
                ent.ApplyCurrentValues(result.EntityKey.EntitySetName, result);
                ent.SaveChanges();
            }
        }
    }
}