using System;
using System.IO;
using System.Web;
using System.Linq;
using System.Web.Mvc;
using ATLTravelPortal.PdfConverter;
using ATLTravelPortal.Helpers;
using HtmlAgilityPack;
using ATLTravelPortal.SecurityAttributes;
using TravelPortalEntity;
using Resources;
using ATLTravelPortal.Areas.Airline.Repository;
using ATLTravelPortal.Areas.Airline.Models;

namespace ATLTravelPortal.Areas.Airline.Controllers
{
    [CheckSessionFilter(Order = 1)]
    public class LccTicketManagementController : ATLTravelPortal.Areas.Airline.Controllers.PartialViewRendererController
    {
        readonly TicketManagementProvider ticketprovider = new TicketManagementProvider();

        [HttpGet]
        public ActionResult ETicket(long id)
        {
            long PNRid = id;

            int agentid = ticketprovider.GetAgentIdbyPNRIdLcc(PNRid);
            var masterpnrsresult = ticketprovider.GetTicketStatusIdByMPNRId(id);

            ETicketViewModel viewmodel;

            if (masterpnrsresult.TicketStatusId == 29)
            {
                viewmodel = ticketprovider.GetB2CMasterInformationForeTicket(id, masterpnrsresult.CreatedBy);

            }
            else
            {

                viewmodel = ticketprovider.GetLccMasterInformationForeTicket(id, agentid);
            }



           

            viewmodel.PNRList = ticketprovider.GetLccPNRInformationForeTicket(viewmodel.MasterPNRId);
            viewmodel.PNRSectorList = ticketprovider.GetAllLccPNRSector(viewmodel.MasterPNRId);
            viewmodel.PNRSegmentList = ticketprovider.GetAllLccPNRSegment(viewmodel.MasterPNRId);
            viewmodel.PassengerList = ticketprovider.GetAllLccPNRPassenger(id);
            viewmodel.ShowFareOnETicket = ticketprovider.ShowFareOnETicket(agentid);
            viewmodel.ShowAgentLogoOnETicket = ticketprovider.ShowAgentLogoOnETicket(agentid);

            viewmodel.ShowServiceChargeOnETicket = ticketprovider.isLccServiceChargeIncludeInTax(agentid);

            string htmlContent = RenderPartialViewToString(viewmodel);
            using (ImagePathFixer pathFixer = new ImagePathFixer())
            {
                htmlContent = pathFixer.FixImagePath(htmlContent);

                using (TempHtmlFile file = new TempHtmlFile())
                {

                    file.Write(htmlContent);
                    DownloadPdf(file);
                }
            }

            return new EmptyResult(); //Require No ActionExecutingContext  ActionFilterAttribute
        }
        [HttpGet]
        public ActionResult ViewETicket(long id)
        {
            try
            {
                var ts = SessionStore.GetTravelSession(); 
                long PNRid = id;

                ETicketViewModel viewmodel;

                int agentid = ticketprovider.GetAgentIdbyPNRId(PNRid);
                var masterpnrsresult = ticketprovider.GetTicketStatusIdByMPNRId(id);

                if (masterpnrsresult.TicketStatusId == 29)
                {
                    viewmodel = ticketprovider.GetB2CMasterInformationForeTicket(id, masterpnrsresult.CreatedBy);
                    
                }
                else
                {

                     viewmodel = ticketprovider.GetLccMasterInformationForeTicket(id, agentid);
                }
                
                viewmodel.PNRList = ticketprovider.GetLccPNRInformationForeTicket(viewmodel.MasterPNRId);
                viewmodel.PNRSectorList = ticketprovider.GetAllLccPNRSector(viewmodel.MasterPNRId);
                viewmodel.PNRSegmentList = ticketprovider.GetAllLccPNRSegment(viewmodel.MasterPNRId);
                viewmodel.PassengerList = ticketprovider.GetAllLccPNRPassenger(id);
                viewmodel.ShowFareOnETicket = ticketprovider.ShowFareOnETicket(agentid);
                viewmodel.ShowAgentLogoOnETicket = ticketprovider.ShowAgentLogoOnETicket(agentid);
                viewmodel.ShowServiceChargeOnETicket = ticketprovider.isLccServiceChargeIncludeInTax(agentid);

                string serverPath = Server.MapPath("~") + "Content\\AgentLogo";
                string resolved = Path.Combine(serverPath, viewmodel.AgentLogo);
                if (!System.IO.File.Exists(resolved))
                {
                    string directoryName = Path.GetDirectoryName(resolved);
                    resolved = Path.Combine(directoryName, "DefaultLogo.png");
                    viewmodel.AgentLogo = "DefaultLogo.png";
                    if (!System.IO.File.Exists(resolved))
                    {
                        Images.DefaultLogo.Save(resolved);

                    }
                }
                return View("eTicket", viewmodel);
            }
            catch (Exception ex)
            {
                ViewData["ErrorInfoMsg"] = "Access Denied / You are Unauthorized Agent to view this eTicket";
                return View("eTicket");
            }
        }

        private void DownloadPdf(TempFile sourceFile)
        {

            using (TempPdfFile targetTempFile = new TempPdfFile())
            {
                try
                {
                    var luncher = new PdfConverter.PdfConverter(sourceFile.FileName,
                        targetTempFile.FileName);
                    luncher.Run();
                    if (!luncher.HasError)
                    {
                        try
                        {
                            new PDFDownloader(targetTempFile).Download();
                        }
                        catch (Exception ex)
                        {
                            // ATLTravelPortalAgent.Utility.ErrorLogging.LogException(ex);
                            Response.Redirect("~/Error.aspx");
                            return;
                        }
                    }
                    else
                    {
                        Response.Redirect("~/Error.aspx");
                    }
                }
                catch (Exception ex)
                {
                    // ATLTravelPortalAgent.Utility.ErrorLogging.LogException(ex);
                    Response.Redirect("~/Error.aspx");
                }

            }
        }

        [HttpPost]
        public ActionResult ViewETicket(long id, ETicketViewModel model1)
        {
            long PNRid = id;

            int agentid = ticketprovider.GetAgentIdbyPNRId(PNRid);
            var masterpnrsresult = ticketprovider.GetTicketStatusIdByMPNRId(id);

            ETicketViewModel viewmodel;

            if (masterpnrsresult.TicketStatusId == 29)
            {
                viewmodel = ticketprovider.GetB2CMasterInformationForeTicket(id, masterpnrsresult.CreatedBy);

            }
            else
            {

                viewmodel = ticketprovider.GetLccMasterInformationForeTicket(id, agentid);
            }
            
            viewmodel.PNRList = ticketprovider.GetLccPNRInformationForeTicket(viewmodel.MasterPNRId);
            viewmodel.PNRSectorList = ticketprovider.GetAllLccPNRSector(viewmodel.MasterPNRId);
            viewmodel.PNRSegmentList = ticketprovider.GetAllLccPNRSegment(viewmodel.MasterPNRId);
            viewmodel.PassengerList = ticketprovider.GetAllLccPNRPassenger(id);
            viewmodel.ShowFareOnETicket = ticketprovider.ShowFareOnETicket(agentid);
            viewmodel.ShowAgentLogoOnETicket = ticketprovider.ShowAgentLogoOnETicket(agentid);
            viewmodel.ShowServiceChargeOnETicket = ticketprovider.isLccServiceChargeIncludeInTax(agentid);
            string serverPath = Server.MapPath("~") + "Content\\AgentLogo";
            string resolved = Path.Combine(serverPath, viewmodel.AgentLogo);
            if (!System.IO.File.Exists(resolved))
            {
                string directoryName = Path.GetDirectoryName(resolved);
                resolved = Path.Combine(directoryName, "DefaultLogo.png");
                viewmodel.AgentLogo = "DefaultLogo.png";
                if (!System.IO.File.Exists(resolved))
                {
                    Images.DefaultLogo.Save(resolved);

                }

            }
            if (!ModelState.IsValid) return View("eTicket", viewmodel);
            string body = RenderPartialViewToString("ETicket", viewmodel);
            try
            {
                ATLTravelPortal.Areas.Airline.Repository.GeneralProvider provider = new ATLTravelPortal.Areas.Airline.Repository.GeneralProvider();

                Agents agent = provider.GetAgentById(agentid);
                EmailEngine.EmailSender.Send(body, agent.Email, model1.txtEmailTo);

                ViewData["isEmailSent"] = "Your email is right on the way, you'll get email in a minute.";
            }
            catch (Exception ex)
            {
                //  ATLTravelPortalAgent.Utility.ErrorLogging.LogException(ex);
                ViewData["isEmailSent"] = "Unable to send email";
                //swallow everything

            }
            return View("eTicket", viewmodel);
        }

        private void DownloadDomesticETicket(long mPnrId)
        {
            try
            {
                string filePath = System.Web.Configuration.WebConfigurationManager.AppSettings["OfflineTicketsPath"] + "/" + mPnrId;
                DirectoryInfo directory = new DirectoryInfo(filePath);

                FileInfo[] filesInfo = null;
                if (Directory.Exists(filePath))
                    filesInfo = directory.GetFiles("*.zip");

                FileInfo fileInfo = null;
                if (filesInfo != null)
                {
                    fileInfo = filesInfo.OrderByDescending(f => f.LastWriteTime).FirstOrDefault();
                }                
                if (fileInfo != null)
                {
                    string fname = fileInfo.Name;
                    bool forceDownload = true;
                    string path = filePath + "/" + fname;
                    string name = Path.GetFileName(path);
                    string ext = Path.GetExtension(path);
                    name = name.Contains(" ") == true ? name.Replace(" ", "_") : name;
                    string type = "";
                    // set known types based on file extension  
                    if (ext != null)
                    {
                        switch (ext.ToLower())
                        {
                            case ".zip":
                                type = "application/x-zip-compressed";
                                break;
                            case ".pdf":
                                type = "Application/pdf";
                                break;

                            case ".xls":
                            case ".xlsx":
                                type = "Application/vnd.ms-excel";
                                break;

                            case ".doc":
                            case ".docx":
                            case ".rtf":
                                type = "Application/msword";
                                break;
                        }
                    }
                    if (forceDownload)
                    {
                        Response.AppendHeader("content-disposition",
                            "attachment; filename=" + name);
                    }
                    if (type != "")
                        Response.ContentType = type;
                    Response.WriteFile(path);
                    Response.End();
                }
            }
            catch (Exception ex)
            {
                Response.Redirect("~/Error.aspx");
            }
        }
    }
}
