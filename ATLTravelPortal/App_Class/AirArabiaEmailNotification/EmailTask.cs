using System;
using System.Reflection;
using Microsoft.Win32.TaskScheduler;
using System.Linq;
using System.Collections.Generic;
using System.Collections;
using ATLTravelPortal.Areas.Airline;
using System.Configuration;

namespace ATLTravelPortal.AirArabiaEmailNotification
{
    public class EmailTask
    {
        public string Origin { get; private set; }
        public string Destination { get; set; }
        public DateTime[] DepartureDates { get; set; }
        public TimeSpan Time { get; set; }
        public DateTime TaskStartDate { get; set; }
        public String TaskID { get; private set; }
        public string[] EmailReceiver { get; set; }

        public EmailTask(string origin, string destination, DateTime[] departureDates)
        {
            this.Origin = origin;
            this.Destination = destination;
            this.DepartureDates = departureDates;
            TaskID = Guid.NewGuid().ToString();
        }
        public virtual string GetDescriptionText()
        {
            return String.Format("Get Fare details of [{0}] to [{1}] on various date, Every day at {2}", Origin, Destination, Time);
        }
        public ExecAction CreateAction()
        {
            string emails = "";
            string dates = "";
            if (this.EmailReceiver != null && this.EmailReceiver.Length > 0)
            {
                emails = String.Join(";", EmailReceiver);
            }
            else
            {
                throw new Exception("Choose at least one receiver email address");
            }
            if (this.DepartureDates != null && this.DepartureDates.Length > 0)
            {
                dates = String.Join(";", DepartureDates.Select(x => x.ToShortDateString()));
            }
            else
            {
                throw new Exception("Choose at least one date");
            }
            string args = String.Format("--from {0} --to {1} --d {2} --id {3} --email {4}", Origin, Destination, dates, TaskID, emails);
            //string path = Assembly.GetExecutingAssembly().Location;
            string path = (ConfigurationManager.AppSettings["AirArabiaExeLocation"]);
            return new ExecAction(path, args);
        }

    }

    public class TaskLibrary : IEnumerable<EmailTask>, IDisposable
    {

        readonly List<EmailTask> tasks = new List<EmailTask>();
        public void AddTask(EmailTask task)
        {
            using (var taskService = new TaskService())
            {
                tasks.Add(task);
                TaskDefinition newTask = taskService.NewTask();
                newTask.RegistrationInfo.Date = DateTime.Now;
                newTask.RegistrationInfo.Author = SessionStore.GetTravelSession().LoginName;
                newTask.RegistrationInfo.Description = task.GetDescriptionText();

                DailyTrigger dailyTrigger = new DailyTrigger();
                dailyTrigger.DaysInterval = 1;
                dailyTrigger.EndBoundary = task.DepartureDates.Max();
                dailyTrigger.StartBoundary =
                    new DateTime(task.TaskStartDate.Year, task.TaskStartDate.Month, task.TaskStartDate.Day) + task.Time;
                newTask.Triggers.Add(dailyTrigger);
                newTask.Actions.Add(task.CreateAction());
                string taskLocation = String.Format("\\{0}\\{1}-{2}\\{3}", "Arihant", task.Origin, task.Destination, task.TaskID);
                //http://taskscheduler.codeplex.com/discussions/256611

                var taskShedulerAuth = ATLTravelPortal.Configuration.TaskShedulerConfigurationProvider.GetAuthDetail();

                //taskService.RootFolder.RegisterTaskDefinition(taskLocation, newTask, TaskCreation.CreateOrUpdate, "SYSTEM", null, TaskLogonType.S4U, null);
                taskService.RootFolder.RegisterTaskDefinition(taskLocation, newTask, TaskCreation.CreateOrUpdate, taskShedulerAuth.UserName, taskShedulerAuth.Password, TaskLogonType.S4U, null);

                //taskService.RootFolder.RegisterTaskDefinition(taskLocation, newTask);
            }
        }


        public IEnumerator<EmailTask> GetEnumerator()
        {
            return tasks.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Dispose()
        {

        }
    }
}