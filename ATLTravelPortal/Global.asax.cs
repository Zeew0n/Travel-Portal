using System;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using System.Web.Routing;

namespace ATLTravelPortal
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //routes.MapRoute(
            //               "Default",                                              // Route name
            //               "{controller}/{action}/{id}",                           // URL with parameters
            //               new { controller = "Account", action = "LogOn", id = "" },  // Parameter defaults
            //               new[] { "ATLTravelPortal.Controllers" }
            //           );

            //Jeewan le change gareko
            // Change Gareko Global.asax.cs ra HomeController ma
            routes.MapRoute(
                "Default",                                              // Route name
                "{controller}/{action}/{id}",                           // URL with parameters
                new { controller = "Home", action = "Index", id = "" },  // Parameter defaults
                new[] { "ATLTravelPortal.Controllers" }
            );






            //routes.MapRoute(
            //             "Catchall",
            //             "{*catchall}",
            //             new { controller = "Errors", action = "PageNotFound" }
            //             );


        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RegisterRoutes(RouteTable.Routes);
            ControllerBuilder.Current.DefaultNamespaces.Add("ATLTravelPortal.Controllers");


            /* register validation */
            ATLTravelPortal.App_Class.Validation.ATLValidation.RegisterValidation();

            // Code that runs on application startup
            BackgroundWorker worker = new BackgroundWorker();
            worker.DoWork += new DoWorkEventHandler(SendSMS);
            worker.WorkerReportsProgress = false;
            worker.WorkerSupportsCancellation = true;
            worker.RunWorkerCompleted +=
                   new RunWorkerCompletedEventHandler(SendSMSWorkerCompleted);

            // Calling the DoWork Method Asynchronously
            worker.RunWorkerAsync(); //we can also pass parameters to the async method....

        }

        private static void SendSMS(object sender, DoWorkEventArgs e)
        {
            TravelPortalEntity.EntityModel ent = new TravelPortalEntity.EntityModel();

            var unSentSMSList = ent.Core_SMSOutboxPool.Where(x => x.StatusMessage != "SENT" & x.SentAttempt <= 3 & x.MobileNumbers.Length > 0 & x.SMSBody.Length > 0).ToList();
            string MobileNo = "", _Message = "", AppName = "ArihantHolidays", AppPrimaryId = "", MessageType = "SMS Notification";


            foreach (var item in unSentSMSList)
            {
                MobileNo = item.MobileNumbers.Trim();
                _Message = item.SMSBody.Trim();
                AppPrimaryId = item.SMSOutBoxPoolId.ToString();
                try
                {
                    string pushUrl = System.Configuration.ConfigurationManager.AppSettings["SMSURL"] + "?MobileNo=" + MobileNo + "&Message=" + _Message + "&AppName=" + AppName + "&AppPrimaryId=" + AppPrimaryId + "&MessageType=" + MessageType;
                    WebClient client = new WebClient();
                    var x = client.DownloadString(pushUrl);
                    UpdateStatus(item.SMSOutBoxPoolId, "SENT");
                }
                catch (Exception ex)
                {
                    UpdateStatus(item.SMSOutBoxPoolId, ex.Message);
                }
            }
        }

        private static void SendSMSWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            if (worker != null)
            {
                // sleep for 5 min and again call DoWork to send new unsend sms
                TimeSpan SleepTime = new TimeSpan(0, 3, 0);
                System.Threading.Thread.Sleep(SleepTime);
                worker.RunWorkerAsync();
            }
        }

        private static void UpdateStatus(int id, string StatusMessage)
        {
            TravelPortalEntity.EntityModel ent = new TravelPortalEntity.EntityModel();
            TravelPortalEntity.Core_SMSOutboxPool result = ent.Core_SMSOutboxPool.Where(x => x.SMSOutBoxPoolId == id).FirstOrDefault();
            result.StatusMessage = StatusMessage;
            result.SentTime = DateTime.UtcNow;
            result.SentAttempt = result.SentAttempt + 1;
            ent.ApplyCurrentValues(result.EntityKey.EntitySetName, result);
            ent.SaveChanges();
        }


    }
}