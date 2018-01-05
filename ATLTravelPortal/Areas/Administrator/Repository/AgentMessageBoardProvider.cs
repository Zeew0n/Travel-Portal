using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelPortalEntity;
using ATLTravelPortal.Areas.Administrator.Models;
using ATLTravelPortal.Models;
using System.Text;

namespace ATLTravelPortal.Areas.Administrator.Repository
{
    public class AgentMessageBoardProvider
    {
        TravelPortalEntity.EntityModel _ent = new TravelPortalEntity.EntityModel();
        ActionResponse _res = new ATLTravelPortal.Models.ActionResponse();
        /// <summary>
        /// For saving the Messages
        /// </summary>
        /// <param name="model"></param>
        public AgentMessageBoardModel Create(AgentMessageBoardModel model, int[] ChkAgentId, int[] ChkProductId, out ActionResponse _ores)
        {
            _res = Validate(model, ChkAgentId, ChkProductId);
            if (_res.ErrNumber == 0)
            {
               
                AgentMessageBoards obj = new AgentMessageBoards
                {
                    MessageTypeId = model.MessageTypeId,
                    MessagePriorityId = model.PriorityId,
                    isforAllAgent = model.IsForAllAgent,
                    HeadingContent = model.HeadContains,
                    MessageContent = model.MessageContains,
                    EffectiveFrom = (DateTime)  model.EffectiveFrom,
                    ExpireOn = (DateTime) model.ExpiredOn,
                    AgentIdList = model.AgentIdList.TrimEnd(','),
                    //ProductIdList = "1",
                    ProductIdList = model.ProductIdList.TrimEnd(','),
                    isActive = true,
                    CreatedBy = model.CreatedBy,
                    CreatedDate = DateTime.Now,
                    MessageCategoryId = model.MessageCatagoriesId,
                };
                _ent.AddToAgentMessageBoards(obj);
                _ent.SaveChanges();
                _res.ActionMessage = String.Format(Resources.Message.SuccessfullySaved, "Message");
                _res.ErrNumber = 0;
                _res.ErrSource = "DataBase";
                _res.ErrType = "App";
                _res.ResponseStatus = true;

            }
            _ores = _res;
            return model;
        }

        /// <summary>
        /// For viewing all the messages 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<AgentMessageBoardModel> List()
        {
            var result = _ent.AgentMessageBoards;
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
        public AgentMessageBoardModel Detail(int? Id, out ActionResponse _ores)
        {
            AgentMessageBoardModel model = new AgentMessageBoardModel();
            if (Id != null)
            {
                var result = _ent.AgentMessageBoards.Where(x => x.MessageBoardId == Id).FirstOrDefault();
                if (result != null)
                {
                    model.CreatedBy = result.CreatedBy;
                    model.CreatedDate = result.CreatedDate;
                    model.EffectiveFrom = result.EffectiveFrom;
                    model.ExpiredOn = result.ExpireOn;
                    model.MessageContains = result.MessageContent;
                    model.PriorityId = result.MessagePriorityId;
                    model.MessageTypeId = result.MessageTypeId;
                    model.Priority = result.MessagePriorities.MessagePriorityType;
                    model.HeadContains = result.HeadingContent;
                    model.MessageTypes = result.MessageTypes.MessageTypeName;
                    model.UpdatedBy = result.UpdatedBy;
                    model.UpdatedDate = result.UpdatedDate;
                    model.AgentIdList = result.AgentIdList;
                    model.ProductIdList = result.ProductIdList;
                    model.IsForAllAgent = result.isforAllAgent;
                    model.IsForAllProduct = result.isforAllAgent;
                    model.MessageBoardId = result.MessageBoardId;
                    model.MessageCatagoriesId = result.MessageCategoryId;
                }
                else
                {
                    _res.ActionMessage = String.Format(Resources.Message.InvalidOperation, "Message");
                    _res.ErrNumber = 2000;
                    _res.ErrSource = "DataBase";
                    _res.ErrType = "App";
                    _res.ResponseStatus = true;
                }
            }
            else
            {
                _res.ActionMessage = String.Format(Resources.Message.InvalidOperation, "Message");
                _res.ErrNumber = 2000;
                _res.ErrSource = "DataBase";
                _res.ErrType = "App";
                _res.ResponseStatus = true;
            }
            _ores = _res;
            return model;
        }

        /// <summary>
        /// For Deleting Message supply the MessageBoardId
        /// </summary>
        /// <param name="Id"></param>
        public ActionResponse Delete(int? id)
        {
            if (id != null)
            {
                AgentMessageBoards obj = _ent.AgentMessageBoards.First(m => m.MessageBoardId == id);
                if (obj != null)
                {
                    _ent.DeleteObject(obj);
                    _ent.SaveChanges();
                    _res.ActionMessage = String.Format(Resources.Message.SuccessfullyDeleted, "Message");
                    _res.ErrNumber = 0;
                    _res.ErrSource = "DataBase";
                    _res.ErrType = "App";
                    _res.ResponseStatus = true;
                }
                else
                {
                    _res.ActionMessage = String.Format(Resources.Message.InvalidOperation, "Message");
                    _res.ErrNumber = 2000;
                    _res.ErrSource = "DataBase";
                    _res.ErrType = "App";
                    _res.ResponseStatus = true;
                }
            }
            else
            {
                _res.ActionMessage = String.Format(Resources.Message.InvalidOperation, "Message");
                _res.ErrNumber = 2000;
                _res.ErrSource = "DataBase";
                _res.ErrType = "App";
                _res.ResponseStatus = true;
            }

            return _res;
        }


        /// <summary>
        /// For Editing Message supply the MessageBoardId
        /// </summary>
        /// <param name="model"></param>
        public AgentMessageBoardModel Edit(AgentMessageBoardModel model, int[] ChkAgentId, int[] ChkProductId, out ActionResponse _ores)
        {
            _res = Validate(model, ChkAgentId, ChkProductId);
            if (_res.ErrNumber == 0)
            {
                var result = _ent.AgentMessageBoards.Where(x => x.MessageBoardId == model.MessageBoardId).FirstOrDefault();
                if (result != null)
                {
                    result.UpdatedBy = model.UpdatedBy;
                    result.UpdatedDate = model.UpdatedDate;
                    result.AgentIdList = model.AgentIdList.TrimEnd(',');
                    result.HeadingContent = model.HeadContains;
                    result.MessageContent = model.MessageContains;
                    result.MessagePriorityId = model.PriorityId;
                    result.MessageTypeId = model.MessageTypeId;
                    result.ExpireOn = (DateTime) model.ExpiredOn;
                    result.EffectiveFrom = (DateTime) model.EffectiveFrom;
                    result.MessageCategoryId = model.MessageCatagoriesId;
                    //result.ProductIdList = "1";
                    result.ProductIdList = model.ProductIdList.TrimEnd(',');

                    _ent.ApplyCurrentValues(result.EntityKey.EntitySetName, result);
                    _ent.SaveChanges();
                    _res.ActionMessage = String.Format(Resources.Message.SuccessfullyUpdated, "Message");
                    _res.ErrNumber = 0;
                    _res.ErrSource = "DataBase";
                    _res.ErrType = "App";
                    _res.ResponseStatus = true;
                }
                else
                {
                    _res.ActionMessage = String.Format(Resources.Message.InvalidOperation, "Message");
                    _res.ErrNumber = 2000;
                    _res.ErrSource = "DataBase";
                    _res.ErrType = "App";
                    _res.ResponseStatus = true;
                }
            }
            _ores = _res;
            return model;
        }
        private ActionResponse Validate(AgentMessageBoardModel model, int[] ChkAgentId, int[] ChkProductId)
        {
            int DateDiff = DateTime.Compare((DateTime)model.EffectiveFrom, (DateTime) model.ExpiredOn);
            if (DateDiff > 0)
            {
                _res.ActionMessage = "From Date is greater than Expired Date";
                _res.ErrNumber = 2000;
                _res.ErrSource = "DataBase";
                _res.ErrType = "App";
                _res.ResponseStatus = true;
                goto End;
            }
            StringBuilder _agetnList = new StringBuilder();
            if (ChkAgentId == null)
            {
                _res.ActionMessage = "Please select Agents";
                _res.ErrNumber = 2000;
                _res.ErrSource = "DataBase";
                _res.ErrType = "App";
                _res.ResponseStatus = true;
                goto End;
            }
            for (int i = 0; i <= ChkAgentId.Length - 1; i++)
            {
                _agetnList.Append(ChkAgentId[i].ToString() + ",");
            }
            model.AgentIdList = _agetnList.ToString();

            StringBuilder _productlist = new StringBuilder();
            if (ChkProductId == null)
            {
                _res.ActionMessage = "Please select Products";
                _res.ErrNumber = 2000;
                _res.ErrSource = "DataBase";
                _res.ErrType = "App";
                _res.ResponseStatus = true;
                goto End;
            }
            for (int i = 0; i <= ChkProductId.Length - 1; i++)
            {
                _productlist.Append(ChkProductId[i].ToString() + ",");
            }
            model.ProductIdList = _productlist.ToString();
        End:
            return _res;
        }
        public AgentMessageBoardModel FillDdl(AgentMessageBoardModel model)
        {
            GeneralProvider _generalprovider = new GeneralProvider();
            model.ddlMsgPriorities = new SelectList(_generalprovider.GetMessagePriority(), "MessagePriorityId", "MessagePriorityType");
            model.ddlMsgType = new SelectList(_generalprovider.GetMessageType(), "MessageTypeId", "MessageTypeName");
            model.AgentList = _generalprovider.GetAgentList();
            model.ProductList = _generalprovider.GetProductList();
            return model;
        }


        public List<MessageCategories> GetMessageCategories()
        {
            return _ent.MessageCategories.ToList();
        }

      


    }
}