using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TravelPortalEntity;
using ATLTravelPortal.Areas.Administrator.Models;

namespace ATLTravelPortal.Areas.Administrator.Repository
{
    public class AgentCallLogProvider
    {
        EntityModel ent = new EntityModel();

        public IEnumerable<ServiceProviders> GetServiceProviderType()
        {
            return ent.ServiceProviders.OrderBy(x => x.ServiceProviderName).Where(x => x.isActive == true).AsEnumerable();
        }

        public IEnumerable<Core_Products> GetProductType()
        {
            return ent.Core_Products.Where(x => (x.isActive == true && x.ProductId != 5)).AsEnumerable();
        }

        public List<Agents> GetAgentName(string AgentName, int maxResult)
        {
            return GetAllAgentNameList(AgentName, maxResult).ToList();
        }

        public IEnumerable<Agents> GetAllAgentNameList(string AgentName, int maxResult)
        {
            return ent.Agents.Where(x => (x.AgentName.ToLower().StartsWith(AgentName.ToLower()))).Take(maxResult).ToList().Select(x =>
                               new Agents { AgentName = x.AgentName, AgentId = x.AgentId }
               );
        }




        public IEnumerable<AgentCallLogModel>ListFollowUpPhoneCallLogs()
        {
            int sno = 0;
            var result = ent.Core_PhoneCallLogs;
            List<AgentCallLogModel> model = new List<AgentCallLogModel>();
            foreach (var item in result.Where(item=>item.isNeedFollowup==true).OrderByDescending(item=>item.LoggedDate))
            {
                sno++;
                AgentCallLogModel obj = new AgentCallLogModel();
                obj.SNO = sno;
                obj.PhoneCallLogId = item.PhoneCallLogId;
                obj.AgentId = item.AgentId;
                obj.AgentName = item.Agents.AgentName;
                obj.Purpose = item.Propose;
                obj.Followupthisagent = item.isNeedFollowup;
                obj.Duration = ProcessCallDuration(item.CallDuration);
                obj.Note = item.Notes;
                obj.For_ProductId = item.ProductId;
                obj.For_ProductName = item.Core_Products.ProductName;
                if (item.ServiceProviderId == null)
                {
                    obj.On_ServiceProviderName = "";
                }
                else
                {
                    obj.On_ServiceProviderName = item.ServiceProviders.ServiceProviderName;
                }
                obj.LoggedBy = item.LoggedBy;
                obj.LoggedByName = item.UsersDetails.FullName;
                obj.LoggedDate = item.LoggedDate;
                obj.CategoryName = item.Category;
                obj.SubCategoryName = item.SubCategory;

                model.Add(obj);
            }
            //return model.Where(x => x.Followupthisagent == true).OrderByDescending(x => x.LoggedDate);
              return model;
        }

        private string ProcessCallDuration(double duration)
        {
            TimeSpan ts = new TimeSpan((long)(duration * 60 * Math.Pow(10, 7)));
            return (ts.Hours.ToString() + ":" + ts.Minutes.ToString() + ":" + ts.Seconds.ToString());

        }
        //        select *from tableName
        //where ColumnName  between fromDate and toDate
        // return queryable.Where(e => e.FromDate <= queryDate && e.ToDate >= queryDate);

        public IEnumerable<AgentCallLogModel> ListPhoneCallLogs(DateTime? FromDate, DateTime? ToDate)
        {
            var result = ent.Core_PhoneCallLogs.Where(x => x.LoggedDate >= FromDate && x.LoggedDate <= ToDate).ToList();
            if (result.Count > 0)
            {
                List<AgentCallLogModel> model = new List<AgentCallLogModel>();
                foreach (var item in result)
                {
                    AgentCallLogModel obj = new AgentCallLogModel();
                    obj.PhoneCallLogId = item.PhoneCallLogId;
                    obj.AgentId = item.AgentId;
                    obj.AgentName = item.Agents.AgentName;
                    obj.Purpose = item.Propose;
                    obj.Followupthisagent = item.isNeedFollowup;
                    obj.Duration = ProcessCallDuration(item.CallDuration);
                    obj.Note = item.Notes;
                    obj.For_ProductId = item.ProductId;
                    obj.For_ProductName = item.Core_Products.ProductName;
                    if (item.ServiceProviderId == null)
                    {
                        obj.On_ServiceProviderName = "";
                    }
                    else
                    {
                        obj.On_ServiceProviderName = item.ServiceProviders.ServiceProviderName;
                    }
                    obj.LoggedBy = item.LoggedBy;
                    obj.LoggedByName = item.UsersDetails.FullName;
                    obj.LoggedDate = item.LoggedDate;
                    obj.CategoryName = item.Category;
                    obj.SubCategoryName = item.SubCategory;
                    model.Add(obj);
                }
                return model.OrderByDescending(x => x.LoggedDate);
            }
            else if( FromDate == null || ToDate == null)
            {
                 result = ent.Core_PhoneCallLogs.ToList();
                List<AgentCallLogModel> model = new List<AgentCallLogModel>();
                foreach (var item in result)
                {
                    AgentCallLogModel obj = new AgentCallLogModel();
                    obj.PhoneCallLogId = item.PhoneCallLogId;
                    obj.AgentId = item.AgentId;
                    obj.AgentName = item.Agents.AgentName;
                    obj.Purpose = item.Propose;
                    obj.Followupthisagent = item.isNeedFollowup;
                    obj.Duration = ProcessCallDuration(item.CallDuration);
                    obj.Note = item.Notes;
                    obj.For_ProductId = item.ProductId;
                    obj.For_ProductName = item.Core_Products.ProductName;
                    if (item.ServiceProviderId == null)
                    {
                        obj.On_ServiceProviderName = "";
                    }
                    else
                    {
                        obj.On_ServiceProviderName = item.ServiceProviders.ServiceProviderName;
                    }
                    obj.LoggedBy = item.LoggedBy;
                    obj.LoggedByName = item.UsersDetails.FullName;
                    obj.LoggedDate = item.LoggedDate;
                    obj.CategoryName = item.Category;
                    obj.SubCategoryName = item.SubCategory;
                    model.Add(obj);
                }
                return model.OrderByDescending(x => x.LoggedDate);

            }
            return null;
        }


        public void CreatePhoneCallLogs(AgentCallLogModel model)
        {
            Core_PhoneCallLogs obj = new Core_PhoneCallLogs();

            obj.AgentId = (int)model.hdfAgentId;
            obj.Propose = model.Purpose;
            obj.isNeedFollowup = model.Followupthisagent;
            obj.CallDuration = (double)model.CallDuration;
            obj.Notes = model.Note;
            obj.ProductId = model.For_ProductId;
            obj.ServiceProviderId = model.On_ServiceProviderId;
            obj.LoggedBy = model.LoggedBy;
            obj.LoggedDate = DateTime.Now;
            obj.Category = model.CategortId;
            obj.SubCategory = model.SubCategortId;
            if (model.rdbCallType == CallType.Incoming)
            {
                obj.CallType = "In-Coming";
            }
            else
            {
                obj.CallType = "Out-Going";
            }



            ent.AddToCore_PhoneCallLogs(obj);
            ent.SaveChanges();
        }
       
        public void EditPhoneCallLogs(AgentCallLogModel model)
        {
            Core_PhoneCallLogs result = ent.Core_PhoneCallLogs.Where(x => x.PhoneCallLogId == model.PhoneCallLogId).FirstOrDefault();

            result.PhoneCallLogId = model.PhoneCallLogId;
            result.AgentId = (int)model.AgentId;
            result.Propose = model.Purpose;
            result.isNeedFollowup = model.Followupthisagent;
            result.CallDuration = (double)model.CallDuration;
            result.Notes = model.Note;
            result.ProductId = model.For_ProductId;
            result.ServiceProviderId = model.On_ServiceProviderId;
            result.LoggedBy = model.LoggedBy;
            result.LoggedDate = DateTime.Now;
            result.Category = model.CategortId;
            result.SubCategory = model.SubCategortId;
            if (model.rdbCallType == CallType.Incoming)
            {
                result.CallType = "In-Coming";
            }
            else
            {
                result.CallType = "Out-Going";
            }


            ent.ApplyCurrentValues(result.EntityKey.EntitySetName, result);
            ent.SaveChanges();
        }

        public AgentCallLogModel DetailPhoneCallLogs(int PhoneCallLogId)
        {
            Core_PhoneCallLogs result = ent.Core_PhoneCallLogs.Where(x => x.PhoneCallLogId == PhoneCallLogId).FirstOrDefault();
            AgentCallLogModel model = new AgentCallLogModel();

            model.AgentId = result.AgentId;
            model.AgentName = result.Agents.AgentName;
            model.Purpose = result.Propose;
            model.Followupthisagent = result.isNeedFollowup;
            model.CallDuration = result.CallDuration;
            model.Note = result.Notes;
            model.For_ProductId = result.ProductId;
            model.For_ProductName = result.Core_Products.ProductName;
            if (model.On_ServiceProviderId == null)
            {
                model.On_ServiceProviderName = "";
            }
            else
            {
                model.On_ServiceProviderName = result.ServiceProviders.ServiceProviderName;
            }

            if (result.CallType == "In-Coming")
            {

                model.rdbCallType = CallType.Incoming;
            }
            else
            {
                model.rdbCallType = CallType.Outgoing;
            }


            model.LoggedBy = result.LoggedBy;
            model.LoggedByName = result.UsersDetails.FullName;
            model.CategortId = result.Category;
            model.SubCategortId = result.SubCategory;

            return model;

        }

        public void DeletePhoneCallLogs(int PhoneCallLogId)
        {
            Core_PhoneCallLogs result = ent.Core_PhoneCallLogs.Where(x => x.PhoneCallLogId == PhoneCallLogId).FirstOrDefault();
            ent.DeleteObject(result);
            ent.SaveChanges();
        }

        public int GetAgentId(string agentname)
        {
            return ent.Agents.Where(x => x.AgentName == agentname).Select(x => x.AgentId).FirstOrDefault();
        }

        public List<Core_PhoneCallLogComments> GeCommentByID(int ID)
        {
            return ent.Core_PhoneCallLogComments.Where(x => x.PhoneCallLogCommentId == ID).ToList();
        }


        public IEnumerable<AgentCallLogModel> GetGroupBookingCommtList(int id)
        {
            List<AgentCallLogModel> model = new List<AgentCallLogModel>();
            var result = ent.Core_PhoneCallLogComments;
            foreach (var item in result.Select(x => x))
            {
                AgentCallLogModel obj = new AgentCallLogModel();

                obj.commentid = item.PhoneCallLogCommentId;
                obj.PhoneCallLogId = item.PhoneCallLogId;
                obj.Comment = item.Comment;
                obj.isDelete = item.isDelete;
                obj.CreatedBy = item.CreatedBy;
                obj.CreatedName = item.UsersDetails.FullName;
                obj.CreatedDate = item.CreatedDate;

                model.Add(obj);
            }
            return model.Where(x => x.PhoneCallLogId == id && x.isDelete == false).AsEnumerable();
        }

        public void CommentsAdd(AgentCallLogModel modelToSave)
        {
            Core_PhoneCallLogComments datamodel = new Core_PhoneCallLogComments
            {
                PhoneCallLogId = modelToSave.PhoneCallLogId,
                Comment = modelToSave.Comment,
                isDelete = modelToSave.isDelete,
                CreatedBy = modelToSave.CreatedBy,
                CreatedDate = DateTime.Now

            };
            ent.AddToCore_PhoneCallLogComments(datamodel);
            ent.SaveChanges();
        }

        public int GetCommentCreatedBy(int id)
        {
            int createdby = ent.Core_PhoneCallLogComments.Where(x => x.PhoneCallLogCommentId == id).Select(x => x.CreatedBy).FirstOrDefault();
            return createdby;
        }

        public void DeleteComment(int id, int commentid)
        {
            Core_PhoneCallLogComments result = ent.Core_PhoneCallLogComments.Where(x => x.PhoneCallLogId == id && x.PhoneCallLogCommentId == commentid).FirstOrDefault();
            var comment = result.Comment;
            result.isDelete = true;

            ent.ApplyCurrentValues(result.EntityKey.EntitySetName, result);
            ent.SaveChanges();
        }




    }
}