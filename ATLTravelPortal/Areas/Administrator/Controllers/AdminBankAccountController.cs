using ATLTravelPortal.Areas.Administrator.Models;
using ATLTravelPortal.Areas.Administrator.Repository;
using ATLTravelPortal.Models;
using System;
using System.Data.SqlClient;
using System.Web.Mvc;

namespace ATLTravelPortal.Areas.Administrator.Controllers
{
    //[CheckSessionFilter(Order = 1)]
    //[PermissionDetails(View = "Index", Add = "Create", Edit = "Edit", Details = "Detail", Delete = "Delete", Order = 2)]

    public class AdminBankAccountController : Controller
    {
        //
        // GET: /Administrator/AdminBankAccount/
        AdminBankAccountProvider _pro = new AdminBankAccountProvider();
        AdminBankAccountModel _model = new AdminBankAccountModel();
        ActionResponse _res = new ATLTravelPortal.Models.ActionResponse();
        public ActionResult Index()
        {
            try
            {
                _model.AdminBankAccountList = _pro.List();
            }
            catch
            {
                _res.ActionMessage = String.Format(Resources.SQLErrorMessage.Error);
                _res.ErrNumber = 2000;
                _res.ErrType = "App";
                _res.ResponseStatus = true;
                Session["ActionResponse"] = _res;
            }

            return View(_model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            try
            {
                _model = _pro.FillDdl(_model);
            }
            catch
            {
                _res.ActionMessage = String.Format(Resources.SQLErrorMessage.Error);
                _res.ErrNumber = 2000;
                _res.ErrType = "App";
                _res.ResponseStatus = true;
                Session["ActionResponse"] = _res;
            }

            return View(_model);
        }

        [HttpPost]
        public ActionResult Create(AdminBankAccountModel model)
        {
            try
            {
                model = _pro.FillDdl(model);
                _pro.Create(model, out _res);
                TempData["SuccessMessage"] = "Successfully created the bank.";
                //Session["ActionResponse"] = _res;
                return RedirectToAction("Index");
            }
            catch (SqlException ex)
            {
                model = _pro.FillDdl(model);
                _res.ActionMessage = ATLTravelPortal.Repository.SqlErrorHandle.Message(ex);
                _res.ErrNumber = ex.Number;
                _res.ErrType = "App";
                _res.ResponseStatus = true;
                // Session["ActionResponse"] = _res;
                TempData["ActionResponse"] = "Unable to create a bank.";
                return View(model);

            }
            catch
            {
                model = _pro.FillDdl(model);
                _res.ActionMessage = String.Format(Resources.SQLErrorMessage.Error);
                _res.ErrNumber = 2000;
                _res.ErrType = "App";
                _res.ResponseStatus = true;
                // Session["ActionResponse"] = _res;
                TempData["ActionResponse"] = "Unable to create a bank.";
                return View(model);

            }

        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            _model = _pro.Detail(id, out _res);
            _model = _pro.FillDdl(_model);
            Session["ActionResponse"] = _res;
            if (_res.ErrNumber > 0)
                return RedirectToAction("Index");
            else
                return View(_model);
        }

        [HttpPost]
        public ActionResult Edit(AdminBankAccountModel model)
        {

            try
            {
                _res = _pro.Edit(model);
                Session["ActionResponse"] = _res;

                if (_res.ErrNumber == 0)
                    return RedirectToAction("Index");
                else
                    return View(_model);
            }
            catch (SqlException ex)
            {
                model = _pro.FillDdl(model);
                _res.ActionMessage = ATLTravelPortal.Repository.SqlErrorHandle.Message(ex);
                _res.ErrNumber = ex.Number;
                _res.ErrType = "App";
                _res.ResponseStatus = true;
                Session["ActionResponse"] = _res;
                return View(model);

            }
            catch
            {
                model = _pro.FillDdl(model);
                _res.ActionMessage = String.Format(Resources.SQLErrorMessage.Error);
                _res.ErrNumber = 2000;
                _res.ErrType = "App";
                _res.ResponseStatus = true;
                Session["ActionResponse"] = _res;
                return View(model);

            }
        }

        public ActionResult Detail(int? id)
        {
            try
            {
                _model = _pro.Detail(id, out _res);
                Session["ActionResponse"] = _res;
                if (_res.ErrNumber > 0)
                    return RedirectToAction("Index");
                else
                    return View(_model);
            }
            catch (SqlException ex)
            {
                _res.ActionMessage = ATLTravelPortal.Repository.SqlErrorHandle.Message(ex);
                _res.ErrNumber = ex.Number;
                _res.ErrType = "App";
                _res.ResponseStatus = true;
                Session["ActionResponse"] = _res;
                return RedirectToAction("Index");
            }
            catch
            {
                _res.ActionMessage = String.Format(Resources.SQLErrorMessage.Error);
                _res.ErrNumber = 2000;
                _res.ErrType = "App";
                _res.ResponseStatus = true;
                Session["ActionResponse"] = _res;
                return RedirectToAction("Index");
            }
        }

        public ActionResult Delete(int Id)
        {
            try
            {
                _pro.Delete(Id);
                Session["ActionResponse"] = _res;
                return RedirectToAction("Index");
            }
            catch (SqlException ex)
            {
                _res.ActionMessage = ATLTravelPortal.Repository.SqlErrorHandle.Message(ex);
                _res.ErrNumber = ex.Number;
                _res.ErrType = "App";
                _res.ResponseStatus = true;
                Session["ActionResponse"] = _res;
                return RedirectToAction("Index");
            }
            catch
            {
                _res.ActionMessage = String.Format(Resources.SQLErrorMessage.Error);
                _res.ErrNumber = 2000;
                _res.ErrType = "App";
                _res.ResponseStatus = true;
                Session["ActionResponse"] = _res;
                return RedirectToAction("Index");
            }
        }


    }
}
