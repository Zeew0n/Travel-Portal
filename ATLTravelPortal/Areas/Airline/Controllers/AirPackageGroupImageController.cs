using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ATLTravelPortal.Areas.Airline.Models;
using ATLTravelPortal.Areas.Airline.Repository;
using ATLTravelPortal.App_Class;
using ATLTravelPortal.Helpers.Pagination;


namespace ATLTravelPortal.Areas.Airline.Controllers
{
    public class AirPackageGroupImageController : Controller
    {
        AirPackageGroupImageModel _modObj= new AirPackageGroupImageModel();
        AirPackageGroupImageProvider _provider = new AirPackageGroupImageProvider();
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
        private AirPackageGroupImageModel GetViewModelList(int packageGroupId, int? page, string sqlString = "1=1")
        {
            int currentPageIndex = page.HasValue ? page.Value - 1 : 1;
            _modObj.TablularRecordExportList = _provider.GetList(packageGroupId);
            _modObj.TablularRecordList = _modObj.TablularRecordExportList.ToPagedList(currentPageIndex, App_Class.AppGeneral.DefaultPageSize);


            return _modObj;

        }

        [NonAction]
        private AirPackageGroupImageModel GetViewModel(int id, string tranMode)
        {

            ///tranMode = "N" , "U", "L", "V"

            if (id != 0)
            {
                //_modObj = _provider.GetDetails(id);
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
                _modObj.formSubmitOnClick = "document.location.href='" + _modObj.formBaseUrl + "/Edit/" + _modObj.PackageGroupId + "'";
                _modObj.FormSubmitType = "detail";

            }


        }

        [NonAction]
        public ActionResult ActionSaveUpdate(AirPackageGroupImageModel model, string tranMode)
        {
            int id = model.PackageGroupId;
            string saveMode = string.Empty;
            GetViewModel(id, tranMode);
            string viewPagePath = string.Empty;
            string vucPagePath = "VUC_Create";

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
            else
            {

                _response = new ServiceResponse("Invalid Fields. Please fill mandatory fields!!", MessageType.Error, false);

            }
            TempData["ActionResponse"] = _response;
            if (Request.IsAjaxRequest()) return PartialView(vucPagePath, _modObj);
            else return View(viewPagePath, _modObj);
        }

        [HttpGet]
        public ActionResult Index(int id, int? page, string extraParams)
        {
            _modObj = GetViewModelList(id, page);
            _modObj.PackageGroupId = id;
            return View(_modObj);

        }

        [HttpPost]
        public ActionResult Index(int id, AirPackageGroupImageModel model)
        {
            //return ActionSaveUpdate(model, "N");
            ActionSaveUpdate(model, "N");
            if (_response.ResponseStatus == true)
            {
                return RedirectToAction("Index", id);
            }
            else
            {
                return View(_modObj);
            }

        }

        [HttpPost]
        public string SetDefaultGroupImage(int id)
        {
            //return ActionSaveUpdate(model, "N");
            _response = _provider.SetDefaultGroupImage(id);
            if (_response.ResponseStatus == true)
            {
                return "true";
            }
            else
            {
                return "false";
            }

        }

        [HttpGet]
        public ActionResult Detail(int id)
        {
            var viewModel = GetViewModel(id, "V");
            return View(viewModel);

        }

        public ActionResult Delete(int id, int PID)
        {   
            _response = _provider.Delete(id);
            TempData["ActionResponse"] = _response;
            return RedirectToAction("Index", new { @id = PID });
        }

    }
}
 