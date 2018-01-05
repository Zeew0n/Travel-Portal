using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TravelPortalEntity;
using ATLTravelPortal.Areas.Administrator.Models;

namespace ATLTravelPortal.Areas.Administrator.Repository
{
    public class AgentTeleLogsProvider
    {
        EntityModel ent = new EntityModel();

        public List<AgentTeleLogsModel> ListAgentTeleLogs(DateTime? FromDate, DateTime? ToDate)
        {
            var result = ent.Core_AgentTeleLogs.Where(x => x.CreatedDate >= FromDate && x.CreatedDate <= ToDate).ToList();
            List<AgentTeleLogsModel> model = new List<AgentTeleLogsModel>();
            if (result.Count > 0)
            {
                foreach (var item in result)
                {
                    AgentTeleLogsModel obj = new AgentTeleLogsModel();

                    obj.AgentTeleLogId = item.AgentTeleLogId;
                    obj.AgentId = item.AgentId;
                    obj.AgentName = item.Agents.AgentName;
                    obj.Title = item.Title == "" ? "" : item.Title;
                    obj.ContactPerson = item.ContactPerson;
                    obj.ContactNumber = item.ContactNumber == "" ? "" : item.ContactNumber;
                    obj.ProblemCategoryName = item.ProblemCategory == "" ? "" : item.ProblemCategory;
                    obj.Remarks = item.Remarks == "" ? "" : item.Remarks;
                    obj.CompetitorInformation = item.CompetitorInformation == "" ? "" : item.CompetitorInformation;
                    obj.isNeededFollowUp = item.isNeedFollowUp;
                    obj.CreatedBy = item.CreatedBy;
                    obj.CreatedName = item.UsersDetails.FullName;
                    obj.CreatedDate = item.CreatedDate;

                    model.Add(obj);
                }
                return model.OrderByDescending(x => x.CreatedDate).ToList();
            }
            else if (FromDate == null || ToDate == null)
            {
                result = ent.Core_AgentTeleLogs.ToList();
                foreach (var item in result)
                {
                    AgentTeleLogsModel obj = new AgentTeleLogsModel();
                    obj.AgentTeleLogId = item.AgentTeleLogId;
                    obj.AgentId = item.AgentId;
                    obj.AgentName = item.Agents.AgentName;
                    obj.Title = item.Title == "" ? "" : item.Title;
                    obj.ContactPerson = item.ContactPerson;
                    obj.ContactNumber = item.ContactNumber == "" ? "" : item.ContactNumber;
                    obj.ProblemCategoryName = item.ProblemCategory == "" ? "" : item.ProblemCategory;
                    obj.Remarks = item.Remarks == "" ? "" : item.Remarks;
                    obj.CompetitorInformation = item.CompetitorInformation == "" ? "" : item.CompetitorInformation;
                    obj.isNeededFollowUp = item.isNeedFollowUp;
                    obj.CreatedBy = item.CreatedBy;
                    obj.CreatedName = item.UsersDetails.FullName;
                    obj.CreatedDate = item.CreatedDate;

                    model.Add(obj);

                }
                return model.OrderByDescending(x => x.CreatedDate).ToList();
            }
            return null;
        }

        public List<AgentTeleLogsModel> ListFollowupAgentTeleLogs()
        {
            int sno = 0;
            var result = ent.Core_AgentTeleLogs.Where(x=>x.isNeedFollowUp == true).OrderByDescending(x => x.CreatedDate).ToList();;
            List<AgentTeleLogsModel> model = new List<AgentTeleLogsModel>();
            foreach (var item in result)
            {   sno++;
                AgentTeleLogsModel obj = new AgentTeleLogsModel();
                obj.SNO=sno;
                obj.AgentTeleLogId = item.AgentTeleLogId;
                obj.AgentId = item.AgentId;
                obj.AgentName = item.Agents.AgentName;
                obj.Title = item.Title == "" ? "" : item.Title;
                obj.ContactPerson = item.ContactPerson;
                obj.ContactNumber = item.ContactNumber == "" ? "" : item.ContactNumber;
                obj.ProblemCategoryName = item.ProblemCategory == "" ? "" : item.ProblemCategory;
                obj.Remarks = item.Remarks == "" ? "" : item.Remarks;
                obj.CompetitorInformation = item.CompetitorInformation == "" ? "" : item.CompetitorInformation;
                obj.isNeededFollowUp = item.isNeedFollowUp;
                obj.CreatedBy = item.CreatedBy;
                obj.CreatedName = item.UsersDetails.FullName;
                obj.CreatedDate = item.CreatedDate;

                model.Add(obj);
            }
            return model;
        }


        public void CreateAgentTeleLogs(AgentTeleLogsModel model)
        {
            Core_AgentTeleLogs obj = new Core_AgentTeleLogs();

            obj.AgentId = (int)model.hdfAgentId;
            obj.Title = model.Title == "" ? "" : model.Title;
            obj.ContactPerson = model.ContactPerson;
            obj.ContactNumber = model.ContactNumber == "" ? "" : model.ContactNumber;
            obj.ProblemCategory = model.ProblemCategoryId == "" ? "" : model.ProblemCategoryId;
            obj.Remarks = model.Remarks == "" ? "" : model.Remarks;
            obj.CompetitorInformation = model.CompetitorInformation == "" ? "" : model.CompetitorInformation;
            obj.isNeedFollowUp = model.isNeededFollowUp == true ? true : false;
            obj.CreatedBy = model.CreatedBy;
            obj.CreatedDate = DateTime.Now;

            ent.AddToCore_AgentTeleLogs(obj);
            ent.SaveChanges();
        }

        public void EditAgentTeleLogs(AgentTeleLogsModel model)
        {
            Core_AgentTeleLogs result = ent.Core_AgentTeleLogs.Where(x => x.AgentTeleLogId == model.AgentTeleLogId).FirstOrDefault();

            result.AgentId = (int)model.hdfAgentId;
            result.Title = model.Title == "" ? "" : model.Title;
            result.ContactPerson = model.ContactPerson;
            result.ContactNumber = model.ContactNumber == "" ? "" : model.ContactNumber;
            result.ProblemCategory = model.ProblemCategoryId == "" ? "" : model.ProblemCategoryId;
            result.Remarks = model.Remarks == "" ? "" : model.Remarks;
            result.CompetitorInformation = model.CompetitorInformation == "" ? "" : model.CompetitorInformation;
            result.isNeedFollowUp = model.isNeededFollowUp == true ? true : false;
            result.CreatedBy = model.CreatedBy;
            result.CreatedDate = DateTime.Now;

            ent.ApplyCurrentValues(result.EntityKey.EntitySetName, result);
            ent.SaveChanges();
        }

        public AgentTeleLogsModel DetailAgentTeleLogs(int AgentTeleLogId)
        {
            Core_AgentTeleLogs result = ent.Core_AgentTeleLogs.Where(x => x.AgentTeleLogId == AgentTeleLogId).FirstOrDefault();
            AgentTeleLogsModel model = new AgentTeleLogsModel();
            model.AgentTeleLogId = result.AgentTeleLogId;
            model.hdfAgentId = result.AgentId;
            model.AgentName = result.Agents.AgentName;
            model.Title = result.Title == "" ? "" : result.Title;
            model.ContactPerson = result.ContactPerson;
            model.ContactNumber = result.ContactNumber == "" ? "" : result.ContactNumber;
            model.ProblemCategoryId = result.ProblemCategory == "" ? "" : result.ProblemCategory;
            model.Remarks = result.Remarks == "" ? "" : result.Remarks;
            model.CompetitorInformation = result.CompetitorInformation == "" ? "" : result.CompetitorInformation;
            model.isNeededFollowUp = result.isNeedFollowUp == true ? true : false;
            model.CreatedBy = result.CreatedBy;
            model.CreatedDate = result.CreatedDate;

            return model;

        }

        public void DeleteAgentTeleLogs(int AgentTeleLogId)
        {
            Core_AgentTeleLogs result = ent.Core_AgentTeleLogs.Where(x => x.AgentTeleLogId == AgentTeleLogId).FirstOrDefault();
            ent.DeleteObject(result);
            ent.SaveChanges();
        }

        public int GetAgentId(string agentname)
        {
            return ent.Agents.Where(x => x.AgentName == agentname).Select(x => x.AgentId).FirstOrDefault();
        }

        public List<Core_AgentTeleLogComments> GeCommentByID(int ID)
        {
            return ent.Core_AgentTeleLogComments.Where(x => x.AgentTeleLogCommentId == ID).ToList();
        }

        public void CommentsAdd(AgentTeleLogsModel modelToSave)
        {
            Core_AgentTeleLogComments datamodel = new Core_AgentTeleLogComments
            {
                AgentTeleLogId = modelToSave.AgentTeleLogId,
                Comment = modelToSave.Comment,
                isDelete = modelToSave.isDelete,
                CreatedBy = modelToSave.CreatedBy,
                CreatedDate = DateTime.Now

            };
            ent.AddToCore_AgentTeleLogComments(datamodel);
            ent.SaveChanges();
        }
        public int GetCommentCreatedBy(int id)
        {
            int createdby = ent.Core_AgentTeleLogComments.Where(x => x.AgentTeleLogCommentId == id).Select(x => x.CreatedBy).FirstOrDefault();
            return createdby;
        }

        public void DeleteComment(int id, int commentid)
        {
            Core_AgentTeleLogComments result = ent.Core_AgentTeleLogComments.Where(x => x.AgentTeleLogId == id && x.AgentTeleLogCommentId == commentid).FirstOrDefault();
            var comment = result.Comment;
            result.isDelete = true;

            ent.ApplyCurrentValues(result.EntityKey.EntitySetName, result);
            ent.SaveChanges();
        }

        public List<AgentTeleLogsModel> GetAgentTeleLogsList(int id)
        {
            List<AgentTeleLogsModel> model = new List<AgentTeleLogsModel>();
            var result = ent.Core_AgentTeleLogComments;
            foreach (var item in result)
            {
                AgentTeleLogsModel obj = new AgentTeleLogsModel();

                obj.commentid = item.AgentTeleLogCommentId;
                obj.AgentTeleLogId = item.AgentTeleLogId;
                obj.Comment = item.Comment;
                obj.isDelete = item.isDelete;
                obj.CreatedBy = item.CreatedBy;
                obj.CreatedName = item.UsersDetails.FullName;
                obj.CreatedDate = item.CreatedDate;

                model.Add(obj);
            }
            return model.Where(x => x.AgentTeleLogId == id && x.isDelete == false).ToList();
        }






    }
}