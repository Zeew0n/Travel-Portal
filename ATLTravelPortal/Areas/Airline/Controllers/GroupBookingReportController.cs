using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ATLTravelPortal.Areas.Airline.Repository;
using ATLTravelPortal.Areas.Airline.Models;
using TravelPortalEntity;
using ATLTravelPortal.SecurityAttributes;
using ATLTravelPortal.CustomAttribute;
using ATLTravelPortal.Helpers.Pagination;

namespace ATLTravelPortal.Areas.Airline.Controllers
{
    [CheckSessionFilter(Order=1)]
    [PermissionDetails(View = "Index", Details = "Detail", Order = 2)]
    public class GroupBookingReportController : Controller
    {
        //
        // GET: /Airline/GroupBookingReport/

        GroupBookingReportProvider ser = new GroupBookingReportProvider();
        int LogedUserId = ATLTravelPortal.Repository.GeneralRepository.LogedUserId();

        public ActionResult Index(int? page)
        {
            int currentPageIndex = page.HasValue ? page.Value : 1;
            int defaultPageSize = 30;
            GroupBookingReportModel model = new GroupBookingReportModel();
            model.GroupBookingList = ser.GetGroupBookingList().ToPagedList(currentPageIndex,defaultPageSize);
            return View(model);
        }


        public ActionResult Detail(int id)
        {
            Air_GroupBooking bookingmodel = ser.GetGroupBookingInfo(id);
            //Air_GroupBookingItinerary Itinerarymodel = ser.GetGroupBookingItineraryInfo(id);
            GroupBookingReportModel model = new GroupBookingReportModel();

           


            model.GroupName = bookingmodel.GroupName;
            model.CompanyName = bookingmodel.CompanyName;
            model.ContactName = bookingmodel.ContactName;
            model.MobilePhone = bookingmodel.MobileNo;
            model.ContactPhone = bookingmodel.PhoneNo;
            model.AddressLine1 = bookingmodel.Address1;
            model.AddressLine2 = bookingmodel.Address2;
            model.SuburbTownCity = bookingmodel.City;
            model.PostCode = bookingmodel.Postcode;
            model.State = bookingmodel.StateName;
            model.StatusId = (int)bookingmodel.GroupBookingStatusId;
           // model.CountryName = bookingmodel.Countries.CountryName == "" ? "" : bookingmodel.Countries.CountryName;
            if (model.CountryName == null)
            {
                model.CountryName = "";
            }
            else
            {
                model.CountryName = bookingmodel.Countries.CountryName;
            }

           // model.GroupTypeName = bookingmodel.Air_GroupTypes.GroupName;

            if (model.GroupTypeName == null)
            {
                model.GroupTypeName = "";
            }
            else
            {
                model.GroupTypeName = bookingmodel.Air_GroupTypes.GroupName;
            }

            model.isExcessBaggage = bookingmodel.isExxessBaggageRequest;
            
            if (model.Comments == null)
            {
                model.Comments = "";
            }
            else
            {
                model.Comments = bookingmodel.Comments;
            }
            

            ViewData["GroupBookingStatus"] = new SelectList(ser.GetGroupBookingStatusList(), "GroupBookingStatusId", "StatusName");

            model.GroupBookingCommtList = ser.GetGroupBookingCommtList(id);

            model.GroupBookingList = ser.GetGroupBookingItineraryListById(id).ToPagedList(1,int.MaxValue);

            string FromCityName = "";
            List<string> CityNameList = new List<string>();
            foreach (var item in model.GroupBookingList)
            {
                FromCityName = item.FromCityName;
                CityNameList.Add(FromCityName);
            }
            ViewData["FromCityName"] = CityNameList;

            string ToCityName = "";
            List<string> ToCityNameList = new List<string>();
            foreach (var item in model.GroupBookingList)
            {
                ToCityName = item.ToCityName;
                ToCityNameList.Add(ToCityName);
            }
            ViewData["ToCityName"] = ToCityNameList;

            string DepartureDate = "";
            List<string> DepartureDateList = new List<string>();
            foreach (var item in model.GroupBookingList)
            {
                DepartureDate = item.DepartDate.ToString();
                DepartureDateList.Add(DepartureDate);
            }
            ViewData["DepartureDate"] = DepartureDateList;

            int AdultId = 0;
            List<int> AdultList = new List<int>();
            foreach (var item in model.GroupBookingList)
            {
                AdultId = item.AdultsId;
                AdultList.Add(AdultId);
            }
            ViewData["AdultNo"] = AdultList;

            int ChildrenNo = 0;
            List<int> ChildrenList = new List<int>();
            foreach (var item in model.GroupBookingList)
            {
                ChildrenNo = item.ChildrenId;
                ChildrenList.Add(ChildrenNo);
            }
            ViewData["ChildNo"] = ChildrenList;

            int InfantNo = 0;
            List<int> InfantList = new List<int>();
            foreach (var item in model.GroupBookingList)
            {
                InfantNo = item.InfantsId;
                InfantList.Add(InfantNo);
            }
            ViewData["InfantNo"] =new SelectList( InfantList);

            string CabinClass = "";
            List<string> CabinClassList = new List<string>();
            foreach (var item in model.GroupBookingList)
            {
                CabinClass = item.CabinClass;
                CabinClassList.Add(CabinClass);
            }
            ViewData["CabinClass"] = CabinClassList;

            model.GroupBookingId = id;

            return View(model);


        }


        [HttpPost]
        public ActionResult Create(GroupBookingReportModel model)
        {
            model.CreatedBy = LogedUserId;

            try
            {

                ser.GroupBookingCommentsAdd(model);
            }
            catch
            {
                //do nothing
            }


            if (model.StatusId != null)
            {
                ser.Air_GroupBookingStatusUpdate(model);
            }

            return RedirectToAction("Detail", new { @id = model.GroupBookingId });


        }



        public ActionResult Delete(int groupbookingid, int commentid)
        {

            GroupBookingReportModel model = new GroupBookingReportModel();

            model.CreatedBy = LogedUserId;

            int groupbookingcommentid = ser.GetGroupBookingCommentCreatedBy(commentid);

            if (model.CreatedBy == groupbookingcommentid)
            {

                ser.DeleteGroupBookingComment(groupbookingid, commentid);
            }
            else
            {
                TempData["CommentCannotBeDeleted"] = "You are not the right user to delete the comment. ";
            }

            return RedirectToAction("Detail", new { @id = groupbookingid });
        }
    }
}
