using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using ATLTravelPortal.Areas.Airline.Models;
using TravelPortalEntity;
using ATLTravelPortal.Helpers;
using System.Web.Security;
using System.Text;
using System.IO;
using ATLTravelPortal.SecurityAttributes;
using AirLines.Provider.Admin;
using ATLTravelPortal.PdfConverter;
using ATLTravelPortal.Areas.Airline.Repository;
using Resources;

namespace ATLTravelPortal.Areas.Airline.Controllers
{

    [CheckSessionFilter(Order = 1)]

    public class TicketManagementController : PartialViewRendererController
    {
       


        readonly TicketManagementProvider ticketprovider = new TicketManagementProvider();

        [HttpGet]
        public ActionResult ETicket(string id)
        {
            try
            {
                long PNRid = Int64.Parse(id);

                int agentid = ticketprovider.GetAgentIdbyPNRId(PNRid);


                ETicketViewModel viewmodel = ticketprovider.GetAllInformationForeTicket(PNRid, agentid);
                viewmodel.PNRSectorList = ticketprovider.DeterminePNRSectorCount(PNRid);
                viewmodel.PassengerList = ticketprovider.GetPassengerListByPNRID(PNRid, agentid);
                viewmodel.PNRSegmentList = ticketprovider.GetPNRSegmentListByPNRSectorID(PNRid);
                viewmodel.ShowFareOnETicket = ticketprovider.ShowFareOnETicket(agentid);
                viewmodel.ShowAgentLogoOnETicket = ticketprovider.ShowAgentLogoOnETicket(agentid);
                viewmodel.AirlineVendorLocators = ticketprovider.GetAirlineVendorLocatorsById(PNRid);
                viewmodel.OperatingAirline = ticketprovider.GetAirlineCodeByMasterPnrId(PNRid);
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
            }
            catch (Exception ex)
            {
            }
            return new EmptyResult();
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
                            ATLTravelPortal.Utility.ErrorLogging.LogException(ex);
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
                    ATLTravelPortal.Utility.ErrorLogging.LogException(ex);
                    Response.Redirect("~/Error.aspx");
                }

            }
        }




        [HttpGet]
        public ActionResult ViewETicket(string id)
        {
            try
            {

                
                long PNRid = Int64.Parse(id);
                var ts = (TravelSession)Session["TravelPortalSessionInfo"];

                int agentid = ticketprovider.GetAgentIdbyPNRId(PNRid);

                //check for authorization

                ETicketViewModel viewmodel = ticketprovider.GetAllInformationForeTicket(PNRid, agentid);

                viewmodel.PNRSectorList = ticketprovider.DeterminePNRSectorCount(PNRid);
                viewmodel.PassengerList = ticketprovider.GetPassengerListByPNRID(PNRid, agentid);
                viewmodel.PNRSegmentList = ticketprovider.GetPNRSegmentListByPNRSectorID(PNRid);
                viewmodel.AirlineVendorLocators = ticketprovider.GetAirlineVendorLocatorsById(PNRid);
                viewmodel.OperatingAirline = ticketprovider.GetAirlineCodeByMasterPnrId(PNRid);

                viewmodel.ShowFareOnETicket = ticketprovider.ShowFareOnETicket(agentid);
                viewmodel.ShowAgentLogoOnETicket = ticketprovider.ShowAgentLogoOnETicket(agentid);


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


        [HttpPost]
        public ActionResult ViewETicket(string id, ETicketViewModel model1)
        {
            long PNRid = Int64.Parse(id);

            var ts = (TravelSession)Session["TravelPortalSessionInfo"];

            int agentid = ticketprovider.GetAgentIdbyPNRId(PNRid);

            ETicketViewModel viewmodel = ticketprovider.GetAllInformationForeTicket(PNRid, agentid);

            viewmodel.PNRSectorList = ticketprovider.DeterminePNRSectorCount(PNRid);
            viewmodel.PassengerList = ticketprovider.GetPassengerListByPNRID(PNRid, agentid);
            viewmodel.PNRSegmentList = ticketprovider.GetPNRSegmentListByPNRSectorID(PNRid);
            viewmodel.ShowFareOnETicket = ticketprovider.ShowFareOnETicket(agentid);
            viewmodel.ShowAgentLogoOnETicket = ticketprovider.ShowAgentLogoOnETicket(agentid);
            viewmodel.AirlineVendorLocators = ticketprovider.GetAirlineVendorLocatorsById(PNRid);

            viewmodel.OperatingAirline = ticketprovider.GetAirlineCodeByMasterPnrId(PNRid);

            string serverPath = Server.MapPath("~") + "Content\\AgentLogo";
            string resolved = Path.Combine(serverPath, viewmodel.AgentLogo);
            if (!System.IO.File.Exists(resolved))
            {
                string directoryName = Path.GetDirectoryName(resolved);
                resolved = Path.Combine(directoryName, "DefaultLogo.png");
                viewmodel.AgentLogo = "DefaultLogo.png";
                if (!System.IO.File.Exists(resolved))
                {
                   // Images.DefaultLogo.Save(resolved);

                }

            }
            if (!ModelState.IsValid) return View("eTicket", viewmodel);
            string body = RenderPartialViewToString("ETicket", viewmodel);
            try
            {
                GeneralProvider provider = new GeneralProvider();
                TravelSession travelSession = (TravelSession)Session["TravelPortalSessionInfo"];
                Agents agent = provider.GetAgentById(viewmodel.AgentId);
                EmailEngine.EmailSender.Send(body, agent.Email, model1.txtEmailTo);

                ViewData["isEmailSent"] = "Your email is right on the way, you'll get email in a minute.";
            }
            catch (Exception ex)
            {
                ATLTravelPortal.Utility.ErrorLogging.LogException(ex);
                ViewData["isEmailSent"] = "Unable to send email";

            }
            return View("eTicket", viewmodel);
        }




      









      



    }
}
