using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelPortalEntity;
using ATLTravelPortal.Helpers;
using ATLTravelPortal.SecurityAttributes;
using ATLTravelPortal.CustomAttribute;
using ATLTravelPortal.Areas.Administrator.Repository;
using ATLTravelPortal.Areas.Administrator.Models;
namespace ATLTravelPortal.Areas.Airline.Controllers
{

    [CheckSessionFilter(Order = 1)]
    [PermissionDetails(Edit = "Edit", Add = "AddTask", Details = "DetailTask", Delete = "DeleteTask", Order = 2)]
    public class TodoTaskController : Controller
    {
        //
        // GET: /TodoTask/
        TodoTaskProvider _ser = new TodoTaskProvider();
       // public JsonResult AddTask( string taskName, string taskDescription, DateTime taskDate)
        public JsonResult AddTask(string taskName)
        {
           TodoTaskModel model = new TodoTaskModel();
           var obj = (TravelSession)Session["TravelPortalSessionInfo"];
            model.userId = obj.AppUserId;
            model.taskName = taskName;
            //model.taskDescription = taskDescription;
            //model.taskDate = taskDate;
            model.taskTime = new TimeSpan(1);
            model.isComplete = false;
            model.createdDate = DateTime.Now;
            _ser.SaveTask(model);
            long id = _ser.GetLastId();
            model = _ser.GetTask(id);
            JsonResult result = new JsonResult();
            result.Data = model;
            return result;
        }

        public JsonResult ChangeStatus(long taskId,bool check)
        {
            TodoTaskModel model = new TodoTaskModel();
            model.taskId = taskId;
            model.isComplete = check;
            _ser.ChangeStatus(taskId, check);
            
            JsonResult result = new JsonResult();

             result.Data=taskId;
             if (check == true)
             {
                 model.TodoTaskList = _ser.GetTaskList().Where(x => x.taskId == taskId);
                 result.Data = taskId;
                 result.Data = _ser.GetTaskName(taskId);
             }
             else
             {
                 model.TodoTaskList = _ser.GetTaskList().Where(x => x.taskId == taskId);
                 result.Data = taskId;
                 result.Data = _ser.GetTaskName(taskId);
             }
             return result;
            
        }
        [HttpGet]
        public ActionResult Edit(long id)
        {
            TodoTaskModel model = new TodoTaskModel();
            _ser.GetTask(id);
            return PartialView("EditTask", model);
        }
        public JsonResult EditTask(long taskId, string taskName, string taskDescription, string taskDate)
        {
            TodoTaskModel model = new TodoTaskModel();
            model.taskId = taskId;
            model.taskName = taskName;
            model.taskDescription = taskDescription;
           // model.taskDate = Convert.ToDateTime(taskDate.Remove(24));
            model.taskDate = Convert.ToDateTime(taskDate);
            _ser.UpdateTask(model);
            model = _ser.GetTask(taskId);
            JsonResult result = new JsonResult();
            result.Data = model;
            return result;
        }

        public JsonResult DetailTask(string taskId)
        {
            TodoTaskModel model = new TodoTaskModel();
            string str = taskId.Remove(0, 2);
            model = _ser.GetTask(long.Parse(str));
            JsonResult result = new JsonResult();
            result.Data = model;
            return result;
        }
        //public JsonResult TaskDetail(long taskId)
        //{
        //    TodoTaskModel model = new TodoTaskModel();
        //    model = _ser.GetTask(taskId);
        //    JsonResult result = new JsonResult();
        //    result.Data = model;
        //    return result;
         
        //}

        public JsonResult DeleteTask(string taskId)
        {
            string str = taskId.Remove(0, 1);
            _ser.DeleteTask(long.Parse(str));
            JsonResult result = new JsonResult();
            result.Data = int.Parse(str);
            return result;
        }
    }
}
