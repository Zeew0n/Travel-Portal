using System.Collections.Generic;
using System.IO;
using System.Net.Mail;
using System.Web;
using ATLTravelPortal.Configuration;
using HtmlAgilityPack;
using ATLTravelPortal.Areas.Airline.Repository;
using ATLTravelPortal.Helpers;

namespace ATLTravelPortal.EmailEngine
{
    public class EmailSender
    {


        public static void Send(string bodyHtml, string senderEmail, string recepient)
        {

            IEmailConfiguration config = EmailConfiguration.Default;
            string body = RemoveSendEmailFields(bodyHtml);

            using (SmtpClient client = new SmtpClient(config.SmtpServer, config.Port))
            {

                MailMessage message = new MailMessage(senderEmail, recepient);
                message.Subject = "eTicket";
                AlternateView htmlView = GetHtmlView(body);
                message.AlternateViews.Add(htmlView);
                client.Send(message);

            }

        }

        private static AlternateView GetHtmlView(string bodyHtml)
        {
            HtmlDocument document = new HtmlDocument();
            document.LoadHtml(bodyHtml);
            List<LinkedResource> resources = new List<LinkedResource>();
            HtmlNodeCollection htmlNodeCollection = document.DocumentNode.SelectNodes("//img");
            int i = 0;
            if (htmlNodeCollection != null)
            {
                foreach (HtmlNode htmlNode in htmlNodeCollection)
                {
                    HtmlAttribute htmlAttribute = htmlNode.Attributes["src"];
                    string value = htmlAttribute.Value;
                    //NOTE: Possible Bug
                    value = value.Replace("../../../../", "");
                    string rootFolder = HttpContext.Current.Server.MapPath("~");
                    string rawPath = Path.Combine(rootFolder, value);
                    htmlAttribute.Value = "cid:" + i.ToString();
                    LinkedResource res = new LinkedResource(rawPath);
                    res.ContentId = i.ToString();
                    resources.Add(res);
                    i++;
                }
            }
            AlternateView htmlView = AlternateView.CreateAlternateViewFromString(document.DocumentNode.OuterHtml, null,
                                                                                 "text/html");
            foreach (LinkedResource resource in resources)
            {
                htmlView.LinkedResources.Add(resource);
            }
            return htmlView;

        }

        public static string RemoveSendEmailFields(string bodyHtml)
        {
            HtmlDocument htmDocument = new HtmlDocument();
            htmDocument.LoadHtml(bodyHtml);
            ImagePathFixer pathFixer = new ImagePathFixer();
            pathFixer.RemoveSendEmailFields(htmDocument);
            return htmDocument.DocumentNode.OuterHtml;
        }

        public static void SendInvoice(string bodyHtml, string senderEmail, string recepient)
        {
            IEmailConfiguration config = EmailConfiguration.Default;
            string body = RemoveSendEmailFields(bodyHtml);

            using (SmtpClient client = new SmtpClient(config.SmtpServer, config.Port))
            {
                MailMessage message = new MailMessage(senderEmail, recepient);
                message.Subject = "Invoice";
                AlternateView htmlView = GetHtmlView(body);
                message.AlternateViews.Add(htmlView);
                client.Send(message);
            }
        }


       
    }
}


