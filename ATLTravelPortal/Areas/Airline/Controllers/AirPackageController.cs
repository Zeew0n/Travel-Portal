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
    [PermissionDetails(View = "Index", Add = "Add", Details = "Detail", Delete = "Delete", Edit = "Edit", Order = 2)]
    [ValidateInput(false)]
    public class AirPackageController : Controller
    {
        AirPackageModel _modObj = new AirPackageModel();
        AirPackageProvider _provider = new AirPackageProvider();
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
        private AirPackageModel GetViewModelList(int? page, string sqlString = "1=1")
        {
            int currentPageIndex = page.HasValue ? page.Value: 1;
            _modObj.TablularRecordExportList = _provider.GetList();
            _modObj.TablularRecordList = _modObj.TablularRecordExportList.ToPagedList(currentPageIndex, App_Class.AppGeneral.DefaultPageSize); 
               
          
            return _modObj;

        }

        [NonAction]
        private AirPackageModel GetViewModel(int id, string tranMode, bool isPost = false)
        {

            ///tranMode = "N" , "U", "L", "V"

            if (id != 0 && isPost == false)
            {
                _modObj = _provider.GetDetails(id);
            }

            _modObj.EffectiveFrom = DateTime.Now;
            _modObj.ExpireOn = DateTime.Now.AddDays(1);


            _modObj.ddlCountryList = CountryProvider.GetSelectListOptions();
            _modObj.ddlCityList = CoreCityProvider.GetSelectListOptions(_modObj.CountryId);
            _modObj.ddlDuration = AirPackageProvider.GetSelectListOptionDuration();
            _modObj.ddlZoneList = new SelectList(_provider.GetZoneList(), "ZoneId", "ZoneValue");
            _provider.GetPackageGroupNameDdl(_modObj);
          
       
           
           
           
          //  _modObj.packageDetail = new ATLTravelPortal.Repository.PackageProvider().GetDetail(id.ToString());
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
                _modObj.formSubmitOnClick = "document.location.href='" + _modObj.formBaseUrl + "/Edit/" + _modObj.PackageId + "'";
                _modObj.FormSubmitType = "detail";

            }


        }
        
        [NonAction]
        public ActionResult ActionSaveUpdate(AirPackageModel model, string tranMode)
        {
            int id = model.PackageId;           
            string saveMode = string.Empty;
            _modObj.CountryId = model.CountryId;
            _modObj.CityId = model.CityId;
         
          
            

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
            if(_response.ResponseStatus==false)
            TempData["ActionResponse"] = _response.ResponseMessage;
            if(_response.ResponseStatus==true)
                TempData["SuccessMessage"] = _response.ResponseMessage;
            if (Request.IsAjaxRequest()) return PartialView(vucPagePath, _modObj);
            else return View(viewPagePath, _modObj);
        }

        public ActionResult Index(int? page, string extraParams)
        {
            _modObj = GetViewModelList(page);
            return View(_modObj);

        }

        //public ActionResult Page(int? page, string extraParams)
        //{            
        //    _modObj = GetViewModelList(page);
        //    return View("Index", _modObj);

        //}

        [HttpGet]
        public ActionResult Add()
        {
            GetViewModel(0, "N");            
            return View(_modObj);

        }

        [HttpPost]
        public ActionResult Add(AirPackageModel model)
        {
            //return ActionSaveUpdate(model, "N");

            if (model.StartingPrice == null && model.StartingINR == null && model.StartingUSD == null)
            {
                TempData["InfoMessage"] = "Enter atleast one price";
                GetViewModel(0, "N");    
                return View("Add", _modObj);
            }
            else
            {
                ActionSaveUpdate(model, "N");
                if (_response.ResponseStatus == true)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return View("Add", _modObj);
                }

            }
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {

            GetViewModel(id, "U");
            _provider.GetPackageGroupNameDdl(_modObj);
           
            return View(_modObj);

        }

        [HttpPost]
        public ActionResult Edit(int id, AirPackageModel model)
        {
            if (model.StartingPrice == null && model.StartingINR == null && model.StartingUSD == null)
            {
                TempData["InfoMessage"] = "Enter atleast one price";
                GetViewModel(id, "U");
                _provider.GetPackageGroupNameDdl(_modObj);

                return View(_modObj);

            }
            else
            {
                model.PackageId = id;
                return ActionSaveUpdate(model, "U");
            }

        }

        [HttpGet]
        public ActionResult Detail(int id)
        {
            GetViewModel(id, "V");
            return View(_modObj);

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


    }
}
