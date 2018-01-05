using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ATLTravelPortal.Areas.Administrator.Repository;
using ATLTravelPortal.Areas.Administrator.Models;
using ATLTravelPortal.Helpers;
using System.Web.Security;
using TravelPortalEntity;
using ATLTravelPortal.Areas.Airline.Models;
using ATLTravelPortal.Areas.Airline.Controllers;
using ATLTravelPortal.Helpers.Pagination;

namespace ATLTravelPortal.Areas.Administrator.Controllers
{
    public class B2CUserManagementController : Controller
    {
        //
        // GET: /Administrator/B2CUserManagement/
        B2CUserManagementProvider ser = new B2CUserManagementProvider();
        BookedTicketReportController bktctrl = new BookedTicketReportController();
        public ActionResult Index(int? page)
        {
            int currentPageIndex = page.HasValue ? page.Value : 1;
            int defaultPageSize = 30;
            B2CUserManagementModel model = new B2CUserManagementModel();
            model.ListB2CUsers = ser.GetAllB2CUserList().ToPagedList(currentPageIndex,defaultPageSize);
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(ExportModel Expmodel, B2CUserManagementModel model, FormCollection frm)
        {
            model.ListB2CUsers = ser.GetAllB2CUserList().ToPagedList(1,int.MaxValue);
            //export
            bktctrl.GetExportTypeClicked(Expmodel, frm);
            if (Expmodel != null && (Expmodel.ExportTypeExcel != null || Expmodel.ExportTypeWord != null || Expmodel.ExportTypeCSV != null || Expmodel.ExportTypePdf != null))
            {
                try
                {
                    if (Expmodel.ExportTypeExcel != null)
                        Expmodel.ExportTypeExcel = Expmodel.ExportTypeExcel;
                    else if (Expmodel.ExportTypeWord != null)
                        Expmodel.ExportTypeWord = Expmodel.ExportTypeWord;
                    else if (Expmodel.ExportTypePdf != null)
                        Expmodel.ExportTypePdf = Expmodel.ExportTypePdf;

                    var exportData = model.ListB2CUsers.Select(m => new
                    {
                        Name = m.FullName,
                        User_Name = m.UserName,
                        Email = m.Email,
                        Address = m.Address,
                        Mobile = m.Mobile,
                        Phone = m.Phone,
                        Created_Date = TimeFormat.DateFormat(m.CreatedDate.ToString())
                    });
                    App_Class.AppCollection.Export(Expmodel, exportData, "User_List");
                }
                catch
                {
                }
            }

            return View(model);
        }


        [HttpGet]
        public ActionResult LockUnlockUser(string id)
        {
            var session = (TravelSession)Session["TravelSessionInfo"];

            MembershipUser muUser = Membership.GetUser(id);
            if (muUser.IsLockedOut)
            {
                Membership.GetUser(id).UnlockUser();
                muUser.IsApproved = true;
                Membership.UpdateUser(muUser);
            }
            else
            {
                muUser.IsApproved = false;
                ser.LockUserNow(id);
                Membership.UpdateUser(muUser);
            }
            return RedirectToAction("Index");
        }

        public ActionResult ResetPassword(string id)
        {
            UserManagementProvider _UserManagementRepo = new UserManagementProvider();
            try
            {

                MembershipUser mbruser = Membership.GetUser(id);
                Guid userId = new Guid(mbruser.ProviderUserKey.ToString());
                string UserFullName = _UserManagementRepo.GetAgentUserFullNameByUserID(userId);
                string password = mbruser.ResetPassword();
                TempData["TemoResetPassword"] = password;
                mbruser.Comment = "MustChangePassword";
                Membership.UpdateUser(mbruser);
            }

            catch (Exception ex)
            {
                TempData["ResponseMsg"] = "Password can not reset due to-  " + ex.Message;
            }
            return RedirectToAction("Index");

        }



        public ActionResult Delete(Guid id)
        {
            try
            {
                TravelPortalEntity.EntityModel ent = new EntityModel();
                UsersDetails userDetails = ent.UsersDetails.Where(x => x.UserId == id).FirstOrDefault();

                if (userDetails != null)
                {
                    ent.DeleteObject(userDetails);
                    ent.SaveChanges();
                }

                aspnet_Users user = ent.aspnet_Users.Where(x => x.UserId == id).FirstOrDefault();
                Membership.DeleteUser(user.UserName, true);
            }
            catch
            {
                TempData["InfoMessage"] = "Cannot delete the user.";
            }
            return RedirectToAction("Index");

        }


        public ActionResult Details(Guid id)
        {
            var user = Membership.GetUser(id);
            ViewData["Title"] = "User Details :" + user.UserName + "";
            var data = new UserManagementModel.MembershipUserAndRolesViewData
            {
                User = user,
                UsersRoles = Roles.GetRolesForUser(user.UserName).OrderBy(x => x).ToList(),
                UserDetails = ser.Details(id),
            };
            if (Request != null && Request.IsAjaxRequest())
                return PartialView("Details", data);
            return View(data);
        }




        public ActionResult Edit(Guid id)
        {
            B2CUserManagementModel model = new B2CUserManagementModel();
            try
            {
                model = ser.GetUserDetails(id);
                model.GetUserName = ser.GetUserinfo(id);
                ser.GetEmail(id);
            }
            catch
            {
                return RedirectToAction("Index");
            }

            return View(model);

        }

        [HttpPost]
        public ActionResult Edit(B2CUserManagementModel model, Guid id, int[] ChkProductId, FormCollection fc)
        {
            try
            {
                model.UserId = id;
                MembershipUser user;
                user = Membership.GetUser(model.UserId);

                Membership.UpdateUser(user);
                ser.UpdateEmail(model);
                ser.EditUserInfo(model);
            }
            catch
            {
                TempData["InfoMessage"] = "Error occured while processing your request.";
            }
            return RedirectToAction("Index");

        }

    }
}


