using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TravelPortalEntity;
using ATLTravelPortal.App_Class;
using ATLTravelPortal.Areas.Administrator.Models;
using System.Data.SqlClient;
using System.Transactions;
using System.Web.Mvc;
using ATLTravelPortal.Helpers;

namespace ATLTravelPortal.Areas.Administrator.Repository
{

    public class NewsProvider
    {
        
        EntityModel _ent = new EntityModel();
        DateTime currentDate = DateTime.Now;
        private ServiceResponse _response = null;
        TravelSession session = (TravelSession)System.Web.HttpContext.Current.Session["TravelPortalSessionInfo"];

        public ServiceResponse ActionSaveUpdate(NewsModel model, string tranMode)
        {

            try
            {
                bool isExist = IsTitleExist(model.PId, model.Title);
                if (isExist == true)
                {
                    _response = new ServiceResponse("Core_News with same title already exist!!", MessageType.Warning, false, "Add");
                    return _response;
                }
                if (tranMode == "N")
                {
                    return Save(model);
                }
                else if (tranMode == "U")
                {

                    return Edit(model);

                }


            }
            catch (SqlException ex)
            {
                _response = new ServiceResponse(ServiceResponsesProvider.SqlExceptionMessage(ex), MessageType.SqlException, false);
            }
            catch (Exception ex)
            {
                _response = new ServiceResponse(ex.Message, MessageType.Exception, false);
            }

            return _response;



        }

        public IEnumerable<NewsModel> GetList()
        {
            List<NewsModel> model = new List<NewsModel>();
            var result = _ent.Core_News.OrderBy(x => x.CreatedDate);
            foreach (var item in result)
            {
                NewsModel obj = new NewsModel
                {
                    PId = item.NewsId,
                    Title = item.Title,
                    Summary = item.Summary,
                    Description = item.Description,
                    CreatedDate = item.CreatedDate,
                    CreatedBy = item.CreatedBy,
                    IsPublish = item.IsPublish,
                };
                model.Add(obj);
            }

            return model.AsEnumerable();
        }

        public ServiceResponse Save(NewsModel model)
        {
            try
            {
                using (var ts = new TransactionScope(TransactionScopeOption.Required))
                {

                    Core_News obj = new Core_News
                    {
                        Title = model.Title.Trim(),
                        URL = model.URL.Trim(),
                        Summary = model.Summary,
                        Description = model.Description,                       
                        IsPublish = model.IsPublish,

                        CreatedBy = session.AppUserId,
                        CreatedDate = currentDate,
                    };
                    _ent.AddToCore_News(obj);
                    _ent.SaveChanges();
                    ts.Complete();
                    _response = new ServiceResponse("Record successfully created!!", MessageType.Success, true, "Edit");
                    return _response;
                }
            }
            catch (SqlException ex)
            {
                _response = new ServiceResponse(ServiceResponsesProvider.SqlExceptionMessage(ex), MessageType.SqlException, false);
            }
            catch (Exception ex)
            {
                _response = new ServiceResponse(ex.Message, MessageType.Exception, false, "Edit");
            }
            return _response;
        }

        public ServiceResponse Edit(NewsModel model)
        {
            try
            {
                using (var ts = new TransactionScope(TransactionScopeOption.Required))
                {
                    var result = _ent.Core_News.Where(x => x.NewsId == model.PId).FirstOrDefault();
                    if (result != null)
                    {

                        result.Title = model.Title.Trim();
                        result.URL = model.URL.Trim();
                        result.Summary = model.Summary;
                        result.Description = model.Description;
                        result.IsPublish = model.IsPublish;
                        result.ModifiedBy = session.AppUserId;
                        result.ModifiedDate = currentDate;
                        _ent.ApplyCurrentValues(result.EntityKey.EntitySetName, result);
                        _ent.SaveChanges();
                    }
                    ts.Complete();
                    _response = new ServiceResponse("Record successfully updated!!", MessageType.Success, true, "Edit");
                }


            }
            catch (SqlException ex)
            {
                _response = new ServiceResponse(ServiceResponsesProvider.SqlExceptionMessage(ex), MessageType.SqlException, false);
            }
            catch (Exception ex)
            {
                _response = new ServiceResponse(ex.Message, MessageType.Exception, false, "Edit");
            }
            return _response;

        }

        public NewsModel GetDetails(int PId)
        {
            var result = _ent.Core_News.Where(x => x.NewsId == PId).FirstOrDefault();
            NewsModel obj = new NewsModel
            {
                PId = result.NewsId,
                Title = result.Title,
                URL = result.URL,
                Summary = result.Summary,
                Description = result.Description,
                CreatedDate = result.CreatedDate,
                CreatedBy = result.CreatedBy,
                IsPublish = result.IsPublish,


            };
            return obj;
        }

        public App_Class.ServiceResponse Delete(int PId)
        {
            Core_News result = _ent.Core_News.Where(x => x.NewsId == PId).FirstOrDefault();

            try
            {
                _ent.DeleteObject(result);
                _ent.SaveChanges();
                _response = new ServiceResponse("Successfully deleted!!", MessageType.Success, true, "Delete");
                return _response;

            }
            catch (SqlException ex)
            {
                _response = new ServiceResponse(ServiceResponsesProvider.SqlExceptionMessage(ex), MessageType.SqlException, false);
            }
            catch (Exception ex)
            {
                _response = new ServiceResponse(ex.Message, MessageType.Exception, false, "Delete");
            }
            return _response;

        }

        
        public bool IsTitleExist(int PId, string Title)
        {
            var result = _ent.Core_News.Where(x => x.NewsId != PId && x.Title.Trim().ToLower() == Title.Trim().ToLower()).FirstOrDefault();
            if (result == null)
            {
                return false;
            }
            return true;


        }

    }
}