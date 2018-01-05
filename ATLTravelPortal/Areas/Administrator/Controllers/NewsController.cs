using System;
using System.Web.Mvc;
using ATLTravelPortal.CustomAttribute;
using ATLTravelPortal.SecurityAttributes;
using ATLTravelPortal.Areas.Administrator.Models;
using ATLTravelPortal.App_Class;
using ATLTravelPortal.Areas.Administrator.Repository;
using ATLTravelPortal.Helpers.Pagination;

namespace ATLTravelPortal.Areas.Administrator.Controllers
{

    [CheckSessionFilter(Order = 1)]
    [PermissionDetails(View = "Index", Edit = "Edit", Add = "Add", Delete = "Delete",Details="Detail", Order = 2)]    
    [ValidateInput(false)]
    public class NewsController : Controller
    {

        NewsModel _modObj = new NewsModel();
        NewsProvider _provider = new NewsProvider();
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

        }


        [NonAction]
        private NewsModel GetViewModelList(int? page, string sqlString = "1=1")
        {
            int currentPageIndex = page.HasValue ? page.Value - 1 : 1;
            _modObj.TablularRecordExportList = _provider.GetList();
            _modObj.TablularRecordList = _modObj.TablularRecordExportList.ToPagedList(currentPageIndex, App_Class.AppGeneral.DefaultPageSize); ;

            return _modObj;

        }

        [NonAction]
        private NewsModel GetViewModel(int id, string tranMode)
        {

            ///tranMode = "N" , "U", "L", "V"

            if (id != 0)
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
            _modObj.ShowMask = false;

            if (tranMode == "N")
            {
                _modObj.formOnSubmitAction = "return false;";
                _modObj.formSubmitBttnName = "Save";
                _modObj.formSubmitOnClick = "return SaveConfirm(this.form,\'" + tranMode + "\')";
                _modObj.FormSubmitType = "add";

            }
            else if (tranMode == "U")
            {
                _modObj.formOnSubmitAction = "return false";
                _modObj.formSubmitBttnName = "Update";
                _modObj.formSubmitOnClick = "return SaveConfirm(this.form,\'" + tranMode + "\')";
                _modObj.FormSubmitType = "edit";

            }
            else if (tranMode == "V")
            {
                _modObj.formOnSubmitAction = "return false";
                _modObj.formSubmitBttnName = "Edit";
                _modObj.formSubmitOnClick = "document.location.href='" + _modObj.formBaseUrl + "/Edit/" + _modObj.PId + "'";
                _modObj.FormSubmitType = "detail";

            }


        }

        [NonAction]
        public ActionResult ActionSaveUpdate(NewsModel model, string tranMode)
        {
            int id = model.PId;
            string saveMode = string.Empty;
            var viewModel = GetViewModel(id, tranMode);
            string viewPagePath = string.Empty;
            string vucPagePath = "VUC_Add";

            if (ModelState.IsValid)
            {
                try
                {
                    _response = _provider.ActionSaveUpdate(model, tranMode);
                    TempData["ActionResponse"] = _response;

                }
                catch (Exception ex)
                {
                    TempData["ActionResponse"] = new ServiceResponse(ex.Message, MessageType.Exception, false);
                }


            }

            if (Request.IsAjaxRequest()) return PartialView(vucPagePath, viewModel);
            else return View(viewPagePath, viewModel);
        }

        public ActionResult Index(int? page, string extraParams)
        {
            _modObj = GetViewModelList(page);
            return View(_modObj);

        }
      
        [HttpGet]
        public ActionResult Add()
        {
            GetViewModel(0, "N");          
            return View(_modObj);

        }

        [HttpPost]
        public ActionResult Add(NewsModel model)
        {           
            return ActionSaveUpdate(model, "N");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {

            GetViewModel(id, "U");
            return View(_modObj);

        }

        [HttpPost]
        public ActionResult Edit(int id, NewsModel model)
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

        [HttpPost]
        public ActionResult Delete(int id)
        {
            JsonResult jResult = new JsonResult();
            try
            {
                jResult.Data = _provider.Delete(id);
                return jResult;
            }
            catch (Exception ex)
            {
                jResult.Data = ex;
                return jResult;

            }
        }


    }

}
