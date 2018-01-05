using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ATLTravelPortal.Areas.Administrator.Models
{
    public class UserTypeModel
    {
        [DisplayName(" Select User Type")]
        public int UserTypeId { get; set; }

        [DisplayName("User Type")]
        public string TypeName { get; set; }

        public int ControllerId { get; set; }
        public int ControllerGroupId { get; set; }

        [DisplayName("Controller Label")]
        public string ControllerLabel { get; set; }

        [DisplayName("Controller Group")]
        public string ControllerGroupName { get; set; }

        public int ControllerSequence { get; set; }
        public int GroupSequence { get; set; }

        public bool ControllerIdChecked { get; set; }

        public IEnumerable<UserTypeModel> userTypelist { get; set; }
    }
    public class ModelExtension
    {
        //////
        public static bool IsActiveController(int ControllerId, List<UserTypeModel> ControllerIdHelper)
        {
            bool flag = false;
            List<int> conrollerIds = ControllerIdHelper.Select(ii => ii.ControllerId).ToList();
            foreach (int cCid in conrollerIds)
            {
                if (ControllerId == cCid)
                {
                    flag = true;
                    break;
                }
            }
            return flag;
        }
    }
}