using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TravelPortalEntity;
using ATLTravelPortal.App_Class;
using System.Data.SqlClient;
using ATLTravelPortal.Areas.Airline.Models;
using System.Web.Mvc;
using System.Transactions;
using ATLTravelPortal.Helpers;

namespace ATLTravelPortal.Areas.Airline.Repository
{
    public class TagsProvider
    {

        EntityModel _ent = new EntityModel();
        //AdminSession session = (AdminSession)System.Web.HttpContext.Current.Session["WorkFlowSession"];
        TravelSession session = (TravelSession)System.Web.HttpContext.Current.Session["TravelPortalSessionInfo"];
        DateTime currentDate = App_Class.AppGeneral.CurrentDateTime();
        private ServiceResponse _response = null;

        public ServiceResponse ActionSaveUpdate(TagsModel model, string tranMode)
        {

            try
            {
                bool isExist = IsTagExist(model.PId, model.Name);
                if (isExist == true)
                {
                    _response = new ServiceResponse("Package with same name already exist!!", MessageType.Warning, false, "Add");
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

        public IEnumerable<TagsModel> GetList()
        {
            List<TagsModel> model = new List<TagsModel>();
            var result = _ent.Core_Tags.OrderBy(x => x.Name);
            foreach (var item in result)
            {
                TagsModel obj = new TagsModel
                {
                    PId = item.TagId,
                    Name = item.Name,
                };
                model.Add(obj);
            }

            return model.AsEnumerable();
        }

        public ServiceResponse Save(TagsModel model)
        {
            try
            {
                using (var ts = new TransactionScope(TransactionScopeOption.Required))
                {

                    Core_Tags obj = new Core_Tags
                    {
                        Name = model.Name,

                    };
                    _ent.AddToCore_Tags(obj);
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

        public ServiceResponse Edit(TagsModel model)
        {
            try
            {
                using (var ts = new TransactionScope(TransactionScopeOption.Required))
                {
                    var result = _ent.Core_Tags.Where(x => x.TagId == model.PId).FirstOrDefault();
                    if (result != null)
                    {
                        result.Name = model.Name;

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

        public TagsModel GetDetails(int PId)
        {
            var result = _ent.Core_Tags.Where(x => x.TagId == PId).FirstOrDefault();
            TagsModel obj = new TagsModel
            {
                PId = result.TagId,
                Name = result.Name,
            };
            return obj;
        }

        public App_Class.ServiceResponse Delete(int PId)
        {
            Core_Tags result = _ent.Core_Tags.Where(x => x.TagId == PId).FirstOrDefault();

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

        //public List<SelectListItem> GetSelectListOptionContentType()
        //{
        //    try
        //    {
        //        List<SelectListItem> ddlList = new List<SelectListItem>();
        //        ddlList = App_Classes.EnumParser.GetEnumSelectOption(typeof(App_Classes.AppGeneral.ContentType));
        //        return ddlList;

        //    }
        //    catch
        //    {
        //        throw;

        //    }

        //}

        public bool IsTagExist(int PId, string TagName)
        {
            var result = _ent.Core_Tags.Where(x => x.TagId != PId && x.Name.Trim().ToLower() == TagName.Trim().ToLower()).FirstOrDefault();
            if (result == null)
            {
                return false;
            }
            return true;


        }



    }
}