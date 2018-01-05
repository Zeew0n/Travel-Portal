using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TravelPortalEntity;
using ATLTravelPortal.Areas.Administrator.Models;


namespace ATLTravelPortal.Areas.Administrator.Repository
{
    public class TodoTaskProvider
    {
        EntityModel ent = new EntityModel();

        public void SaveTask(TodoTaskModel model)
        {
            ToDoTasks obj = new ToDoTasks();
            obj.UserId = model.userId;
            obj.TaskName = model.taskName;
            obj.TaskDate = DateTime.Now;//model.taskDate;
            obj.TaskTime =model.taskTime;
            obj.CreatedDate = model.createdDate;
            obj.isComplete = model.isComplete;
            obj.TaskDescription = "Hello";//model.taskDescription;
            ent.AddToToDoTasks(obj);
            ent.SaveChanges();
        }

        public IEnumerable<TodoTaskModel> GetTaskList()
        {
            var result = ent.ToDoTasks;
            List<TodoTaskModel> model = new List<TodoTaskModel>();
            foreach (var item in result)
            {
                TodoTaskModel obj = new TodoTaskModel { 
                 createdDate = item.CreatedDate,
                 isComplete = item.isComplete,
                 taskDate = item.TaskDate,
                 taskName = item.TaskName,
                 taskDescription = item.TaskDescription,
                 taskTime = item.TaskTime,
                 userId = item.UserId,
                 taskId = item.TaskId
                };
                model.Add(obj);
            }
            return model.AsEnumerable();
        }

        public void ChangeStatus(long id, bool status)
        {
            
            var result = ent.ToDoTasks.Where(x => x.TaskId == id).FirstOrDefault();
            result.isComplete = status;
            ent.ApplyCurrentValues(result.EntityKey.EntitySetName, result);
            ent.SaveChanges();
        }
        public TodoTaskModel GetTask(long id)
        {
            var result = ent.ToDoTasks.Where(x => x.TaskId == id).FirstOrDefault();
            TodoTaskModel model = new TodoTaskModel {
                createdDate = result.CreatedDate,
                isComplete = result.isComplete,
                taskDate = result.TaskDate,
                taskName = result.TaskName,
                taskDescription = result.TaskDescription,
                taskTime = result.TaskTime,
                userId = result.UserId,
                taskId = result.TaskId
            };
            return model;
        }

        public void UpdateTask(TodoTaskModel model)
        {
         var result = ent.ToDoTasks.Where(x=>x.TaskId == model.taskId).FirstOrDefault();
            result.TaskName = model.taskName;
            result.TaskDate = model.taskDate;
            result.TaskDescription = model.taskDescription;
            ent.ApplyCurrentValues(result.EntityKey.EntitySetName,result);
            ent.SaveChanges();
            }
        public void DeleteTask(long id)
        {
            //var result = ent.ToDoTasks.Where(x => x.TaskId == id).FirstOrDefault();
            ToDoTasks result = ent.ToDoTasks.Where(x => x.TaskId == id).FirstOrDefault();
            ent.DeleteObject(result);
            ent.SaveChanges();

        }
        public string GetTaskName(long id)
        {
           string taskName = ent.ToDoTasks.Where(x => x.TaskId == id).Select(x => x.TaskName).FirstOrDefault();
           return taskName;
        }

        public long GetLastId()
        {
            long id = ent.ToDoTasks.Max(x => x.TaskId);
            return id;
        }
    }
}