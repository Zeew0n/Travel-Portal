using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ATLTravelPortal.Areas.Airline.Models;
using TravelPortalEntity;

namespace ATLTravelPortal.Areas.Airline.Repository
{
    public class GroupBookingReportProvider
    {
        TravelPortalEntity.EntityModel ent = new TravelPortalEntity.EntityModel();

        //for listing Air_GroupBooking

        public IEnumerable<GroupBookingReportModel> GetGroupBookingList()
        {
            int sno = 0;
            List<GroupBookingReportModel> model = new List<GroupBookingReportModel>();
            var result = ent.Air_GroupBooking;
            foreach (var item in result.Select(x => x))
            {
                sno++;
                GroupBookingReportModel obj = new GroupBookingReportModel();
                obj.SN0 = sno;
                obj.GroupBookingId = (int)item.GroupBookingId;
                obj.GroupName = item.GroupName;
                obj.CompanyName = item.CompanyName;
                obj.ContactName = item.ContactName;
                obj.MobilePhone = item.MobileNo;
                obj.ContactPhone = item.PhoneNo;
                obj.AddressLine1 = item.Address1;
                obj.AddressLine2 = item.Address2;
                obj.SuburbTownCity = item.City;
                obj.PostCode = item.Postcode;
                obj.State = item.StateName;
                obj.Status = item.Air_GroupBookingStatus.StatusName;
                obj.CountryId = item.CountryId;
                if (obj.CountryId == null)
                {
                    obj.CountryName = "";
                }
                else
                {
                    obj.CountryName = item.Countries.CountryName;
                }
                //obj.GroupTypeId = item.GroupTypeId;
               // obj.GroupTypeName = item.Air_GroupTypes.GroupName;
                obj.isExcessBaggage = item.isExxessBaggageRequest;
                obj.Comments = item.Comments;
                model.Add(obj);
            }
            return model.AsEnumerable();
        }

        public GroupBookingReportModel GetGroupBookingDetail(int id)
        {
            Air_GroupBooking result = ent.Air_GroupBooking.Where(x => x.GroupBookingId == id).FirstOrDefault();
            GroupBookingReportModel model = new GroupBookingReportModel();
            model.GroupBookingId = (int)result.GroupBookingId;
            model.GroupName = result.GroupName;
            model.CompanyName = result.CompanyName;
            model.ContactName = result.ContactName;
            model.MobilePhone = result.MobileNo;
            model.ContactPhone = result.PhoneNo;
            model.AddressLine1 = result.Address1;
            model.AddressLine2 = result.Address2;
            model.SuburbTownCity = result.City;
            model.PostCode = result.Postcode;
            model.State = result.StateName;
            model.CountryId = result.CountryId;
            model.GroupTypeId = result.GroupTypeId;
            //model.ExcessBaggage    = result.isExxessBaggageRequest;
            model.rdbExcessBaggage = result.isExxessBaggageRequest == true ? Baggage.Yes : Baggage.No;
            model.Comments = result.Comments;

            return model;

        }


        //for listing Air_GroupBookingItinerary
        public IEnumerable<GroupBookingReportModel> GetGroupBookingItineraryList()
        {
            List<GroupBookingReportModel> model = new List<GroupBookingReportModel>();
            var result = ent.Air_GroupBookingItinerary;
            foreach (var item in result.Select(x => x))
            {

                GroupBookingReportModel obj = new GroupBookingReportModel();
                obj.GroupBookingItineraryId = (int)item.GroupBookingItineraryId;
                obj.GroupBookingId = (int)item.GroupBookingId;
                obj.GroupName = item.Air_GroupBooking.GroupName;
                obj.FromCityId = item.FromCityId;
                obj.ToCityId = item.ToCityId;
                obj.DepartDate = item.DepartsDate;
                obj.AdultsId = item.AdultNo;
                obj.ChildrenId = item.ChildNo;
                obj.InfantsId = item.InfantNo;
                obj.CabinClass = item.CabinClass;

                model.Add(obj);
            }
            return model.AsEnumerable();
        }

        public GroupBookingReportModel GetGroupBookingItineraryDetail(int id)
        {
            Air_GroupBookingItinerary result = ent.Air_GroupBookingItinerary.Where(x => x.GroupBookingItineraryId == id).FirstOrDefault();
            GroupBookingReportModel model = new GroupBookingReportModel();
            model.GroupBookingItineraryId = (int)result.GroupBookingItineraryId;
            model.GroupBookingId = (int)result.GroupBookingId;
            model.FromCityId = result.FromCityId;
            model.ToCityId = result.ToCityId;
            model.DepartDate = result.DepartsDate;
            model.AdultsId = result.AdultNo;
            model.ChildrenId = result.ChildNo;
            model.InfantsId = result.InfantNo;
            model.CabinClass = result.CabinClass;

            return model;

        }

        public Air_GroupBooking GetGroupBookingInfo(int ID)
        {
            return ent.Air_GroupBooking.SingleOrDefault(x => x.GroupBookingId == ID);
        }

        public Air_GroupBookingItinerary GetGroupBookingItineraryInfo(int ID)
        {
            return ent.Air_GroupBookingItinerary.SingleOrDefault(x => x.GroupBookingId == ID);
        }



        public IEnumerable<GroupBookingReportModel> GetGroupBookingItineraryListById(int Id)
        {
            var result = ent.Air_GroupBookingItinerary.Where(ab => ab.GroupBookingId == Id).ToList();
            List<GroupBookingReportModel> Search = new List<GroupBookingReportModel>();
            foreach (var item in result)
            {
                GroupBookingReportModel obj = new GroupBookingReportModel
                {
                    GroupBookingId = (int)item.GroupBookingId,
                    FromCityId = item.FromCityId,
                    FromCityName = item.AirlineCities.CityName,
                    ToCityId = item.ToCityId,
                    ToCityName = item.AirlineCities1.CityName,
                    DepartDate = item.DepartsDate,
                    AdultsId = item.AdultNo,
                    ChildrenId = item.ChildNo,
                    InfantsId = item.InfantNo,
                    CabinClass = item.CabinClass,

                };
                Search.Add(obj);
            }
            return Search.AsEnumerable();
        }

        public List<Air_GroupBookingStatus> GetGroupBookingStatusList()
        {
            return ent.Air_GroupBookingStatus.ToList();
        }

        public void GroupBookingCommentsAdd(GroupBookingReportModel modelToSave)
        {
            Air_GroupBookingComments datamodel = new Air_GroupBookingComments
            {


                GroupBookingId = (Int64)modelToSave.GroupBookingId,
                Comment = modelToSave.PostComment,
                isDelete = modelToSave.isDelete,
                CreatedBy = modelToSave.CreatedBy,
                CreatedDate = DateTime.Now

            };
            ent.AddToAir_GroupBookingComments(datamodel);
            ent.SaveChanges();



        }

        public void Air_GroupBookingStatusUpdate(GroupBookingReportModel model)
        {
            Air_GroupBooking result = ent.Air_GroupBooking.Where(x => x.GroupBookingId == model.GroupBookingId).FirstOrDefault();

            result.GroupBookingStatusId = model.StatusId;

            ent.ApplyCurrentValues(result.EntityKey.EntitySetName, result);
            ent.SaveChanges();
        }

        public int GetGroupBookingCommentCreatedBy(int id)
        {
            int createdby = ent.Air_GroupBookingComments.Where(x => x.GroupBookingCommentsId == id).Select(x => x.CreatedBy).FirstOrDefault();

            return createdby;




        }

        public void DeleteGroupBookingComment(int id, int commentid)
        {
            Air_GroupBookingComments result = ent.Air_GroupBookingComments.Where(x => x.GroupBookingId == id && x.GroupBookingCommentsId == commentid).FirstOrDefault();

            result.isDelete = true;

            ent.ApplyCurrentValues(result.EntityKey.EntitySetName, result);
            ent.SaveChanges();
        }

        public IEnumerable<GroupBookingReportModel> GetGroupBookingCommtList(int id)
        {
            List<GroupBookingReportModel> model = new List<GroupBookingReportModel>();
            var result = ent.Air_GroupBookingComments;
            foreach (var item in result.Select(x => x))
            {

                GroupBookingReportModel obj = new GroupBookingReportModel();
                obj.GroupBookingId = (int)item.GroupBookingId;
                obj.groupbookingcommentid = (int)item.GroupBookingCommentsId;
                obj.PostComment = item.Comment;
                obj.CreatedName = item.UsersDetails.FullName;
                obj.CreatedDate = item.CreatedDate;
                obj.isDelete = item.isDelete;
                obj.CreatedBy = item.CreatedBy;


                model.Add(obj);
            }
            return model.Where(x => x.GroupBookingId == id && x.isDelete == false).AsEnumerable();
        }


    }
}