using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ATLTravelPortal.Areas.Airline.Models;
using ATLTravelPortal.Areas.Airline.Repository;
using ATLTravelPortal.App_Class;
using ATLTravelPortal.SecurityAttributes;
using ATLTravelPortal.CustomAttribute;
using ATLTravelPortal.Helpers.Pagination;

namespace ATLTravelPortal.Areas.Airline.Controllers
{
    [CheckSessionFilter(Order = 1)]
    [PermissionDetails(View = "Index", Edit = "Edit", Order = 2)]
    [ValidateInput(false)]
    public class TagsController : Controller
    {
        TagsModel _modObj = new TagsModel();
        TagsProvider _provider = new TagsProvider();
        private ServiceResponse _response = null;
           
        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {
            base.Initialize(requestContext);
            //here the routedata is available

            _modObj.formControllerName = ControllerContext.RouteData.Values["Controller"].ToString();
            _modObj.formActionName = ControllerContext.RouteData.Values["action"].ToString();
            _modObj.formArea = ControllerContext.RouteData.DataTokens["Area"].ToString();
            _modObj.formBaseUrl = "/" + _modObj.formArea + "/" + _modObj.formControllerName;
            _modObj.formCancelOnClick = "document.location.href='" + _modObj.formBaseUrl + "/Index'";
            //vucPagePath = _modObj.formActionName;
           
        }
      
        [NonAction]
        private TagsModel GetViewModelList(int? page, string sqlString = "1=1")
        {
            int currentPageIndex = page.HasValue ? page.Value - 1 : 1;
            _modObj.TablularRecordExportList = _provider.GetList();
            _modObj.TablularRecordList = _modObj.TablularRecordExportList.ToPagedList(currentPageIndex, App_Class.AppGeneral.DefaultPageSize); 
               
          
            return _modObj;

        }

        [NonAction]
        private TagsModel GetViewModel(int id, string tranMode, bool isPost = false)
        {

            ///tranMode = "N" , "U", "L", "V"

            if (id != 0 && isPost == false)
            {
                _modObj = _provider.GetDetails(id);
            }
            
            SetUpFormParams(tranMode);
            return _modObj;
        }

        private void SetUpFormParams(string tranMode)
        {
            _modObj.formControllerName = ControllerContext.RouteData.Values["Controller"].ToString();
            _modObj.formActionName = ControllerContext.RouteData.Values["action"].ToString();
            _modObj.formArea = ControllerContext.RouteData.DataTokens["Area"].ToString();
            _modObj.formBaseUrl = "/" + _modObj.formArea + "/" + _modObj.formControllerName;
            _modObj.formCancelOnClick = "document.location.href='" + _modObj.formBaseUrl + "/Index'";
            if (tranMode == "N")
            {
                _modObj.formOnSubmitAction = "";
                _modObj.formSubmitBttnName = "Save";
                _modObj.formSubmitOnClick = "return SaveConfirm(this.form,\'" + tranMode + "\')";
                _modObj.FormSubmitType = "add";

            }
            else if (tranMode == "U")
            {
                _modObj.formOnSubmitAction = "";
                _modObj.formSubmitBttnName = "Update";
                _modObj.formSubmitOnClick = "return SaveConfirm(this.form,\'" + tranMode + "\')";
                _modObj.FormSubmitType = "edit";

            }
            else if (tranMode == "V")
            {
                _modObj.formOnSubmitAction = "";
                _modObj.formSubmitBttnName = "Edit";
                _modObj.formSubmitOnClick = "document.location.href='" + _modObj.formBaseUrl + "/Edit/" + _modObj.PId + "'";
                _modObj.FormSubmitType = "detail";

            }


        }
        
        [NonAction]
        public ActionResult ActionSaveUpdate(TagsModel model, string tranMode)
        {
            int id = model.PId;           
            string saveMode = string.Empty;
         
            GetViewModel(id, tranMode, true);
            
            string viewPagePath = string.Empty;
            string vucPagePath = "VUC_Add";

            if (ModelState.IsValid)
            {
                try
                {
                    _response = _provider.ActionSaveUpdate(model, tranMode);
                    

                }
                catch (Exception ex)
                {
                    _response = new ServiceResponse(ex.Message, MessageType.Exception, false);
                }


            }
            else {

                _response = new ServiceResponse("Invalid Fields. Please fill mandatory fields!!", MessageType.Error, false);
            
            }
            TempData["ActionResponse"] = _response;
            if (Request.IsAjaxRequest()) return PartialView(vucPagePath, _modObj);
            else return View(viewPagePath, _modObj);
        }

        public ActionResult Index(int? page, string extraParams)
        {
            _modObj = GetViewModelList(page);
            return View(_modObj);

        }

        public ActionResult Page(int? page, string extraParams)
        {            
            _modObj = GetViewModelList(page);
            return View("Index", _modObj);

        }

        [HttpGet]
        public ActionResult Add()
        {
            GetViewModel(0, "N");            
            return View(_modObj);

        }

        [HttpPost]
        public ActionResult Add(TagsModel model)
        {            
            //return ActionSaveUpdate(model, "N");
            ActionSaveUpdate(model, "N");
            if (_response.ResponseStatus == true)
            {
                return RedirectToAction("Index");
            }
            else {
                return View("Add", _modObj);
            }
            
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {

            GetViewModel(id, "U");
            return View(_modObj);

        }

        [HttpPost]
        public ActionResult Edit(int id, TagsModel model)
        {
            model.PId = id;
            return ActionSaveUpdate(model, "U");

        }

        [HttpGet]
        public ActionResult Detail(int id)
        {
            var viewModel = GetViewModel(id, "V");
            return View(viewModel);

        }

     
        public ActionResult Delete(int id)
        {
            _response = _provider.Delete(id);
            TempData["ActionResponse"] = _response;
            return RedirectToAction("Index");

            //JsonResult jResult = new JsonResult();
            //try
            //{
            //    jResult.Data = _provider.Delete(id);
            //    return jResult;
            //}
            //catch (Exception ex)
            //{
            //    jResult.Data = ex;
            //    return jResult;

            //}
        }

        public string GetTagListAuto(string id, string callback, string term)
        {

            var ddlSelectOptionList = _provider.GetList().Where(x => x.Name.ToLower().IndexOf(term.ToLower()) >=0);
            string resResult = callback + "([";
            foreach (var item in ddlSelectOptionList)
            {
                resResult += "{\"name\":\"" + item.Name + "\"},";            
            }
            resResult += "])";
            return resResult;
            //var jsonData = new
            //{
               

            //    rows = (
            //        from result in ddlSelectOptionList
            //        select new
            //        {
            //            Name = result.Name                       

            //        }
            //    ).ToArray()
            //};

            //return Json(jsonData,JsonRequestBehavior.AllowGet);
            
        }


    }
}
