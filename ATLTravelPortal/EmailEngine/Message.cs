using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Net.Mail;
using System.IO;
namespace ATLTravelPortal.EmailEngine
{
    /// <summary>
    /// Mail message
    /// </summary>
    public class Message
    {

        /// <summary>
        /// Send a text/plain message to a list of recipients
        /// </summary>
        /// <param name="from">Sender's address</param>
        /// <param name="replyto">Reply-to address</param>
        /// <param name="subject">Message subject</param>
        /// <param name="body">Message body</param>
        /// <param name="recipients">Recipient e-mail addresses</param>
        /// <returns>Number of sent messages</returns>w
        public static int Send(string from, string replyto, string subject, string body, params string[] recipients)
        {

            return Send(from, replyto, subject, body, null,false, recipients);
        }


        public static int Send(string from, string replyto, string subject, string body,bool isAttachmentSameData , params string[] recipients)
        {

            return Send(from, replyto, subject, body, null,isAttachmentSameData, recipients);
        }

        /// <summary>
        /// Send a text/plain message to a list of recipients
        /// </summary>
        /// <param name="from">Sender's address</param>
        /// <param name="replyto">Reply-to address</param>
        /// <param name="subject">Message subject</param>
        /// <param name="body">Message body</param>
        /// <param name="recipients">Recipient e-mail addresses</param>
        /// <returns>Number of sent messages</returns>
        public static int Send(string from, string replyto, string subject, string body, string directorypath,params string[] recipients)
        {
            // sent message counter
            int messagesok = 0;

            // create a new SMTP client with settings from AppSettings

            string smtpClientName = System.Configuration.ConfigurationManager.AppSettings["smtpserver"];
            Int32 smtpPort = Int32.Parse(System.Configuration.ConfigurationManager.AppSettings["smtpport"]);
            System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient(smtpClientName, smtpPort);
            client.EnableSsl = false;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Timeout = 20000;
            //if (smtpPort != 0)
            //{
            //    client.Host = smtpClientName;
            //    client.Port=  smtpPort;
            //}
            //else
            //{
            //    client.Host = smtpClientName;
            //}
            string smtpUsername = System.Configuration.ConfigurationManager.AppSettings["smtpusername"] as string;
            if (smtpUsername != null && smtpUsername.Trim().Length > 0)
                client.Credentials = new System.Net.NetworkCredential(smtpUsername, System.Configuration.ConfigurationManager.AppSettings["smtppassword"] as string);



            // create the message
            System.Net.Mail.MailMessage message = new System.Net.Mail.MailMessage();

            //perpare plain view
            AlternateView plainView = AlternateView.CreateAlternateViewFromString(StripHTML(body), null, "text/plain");


            // handle images
            List<LinkedResource> linkedresources = new List<LinkedResource>();
            if (directorypath != null)
            {
                MatchCollection images = Regex.Matches(body, @"<img[^>]+>");
                for (int i = 0; i < images.Count; i++)
                {
                    Match img = images[i];

                    Match m = Regex.Match(img.Value, @"(.*?src=\s*[""'])([^""']+)(.*)");

                    if (m.Success)
                    {
                        string filePath = System.IO.Path.Combine(directorypath, m.Groups[2].Value);
                        if (System.IO.File.Exists(filePath))
                        {
                            LinkedResource resource = new LinkedResource(filePath, ATLTravelPortal.EmailEngine.MIME.GetMimeType(System.IO.Path.GetExtension(filePath)));
                            linkedresources.Add(resource);

                            body = body.Replace(img.Value, string.Format("{0}cid:{1}{2}", m.Groups[1].Value, resource.ContentId, m.Groups[3].Value));
                        }
                    }
                }
            }
           

            //perpare html view
            AlternateView htmlView = AlternateView.CreateAlternateViewFromString(body, null, "text/html");
            for (int i = 0; i < linkedresources.Count; i++)
                htmlView.LinkedResources.Add(linkedresources[i]);


            //attach views
            message.AlternateViews.Add(plainView);
            message.AlternateViews.Add(htmlView);

            // sender
            message.From = new System.Net.Mail.MailAddress(from);

            // if reply-to address is defined
            if (replyto != null && replyto != "") message.ReplyTo = new System.Net.Mail.MailAddress(replyto);

            message.Subject = subject;
            message.IsBodyHtml = true;
            //message.Body = body;
            message.SubjectEncoding = System.Text.Encoding.UTF8;


            foreach (string recipient in recipients)
            {
                // clear recipients
                message.To.Clear();
                // add current recipient
                message.To.Add(recipient);

                // send message
                //try
                //{
                client.Send(message);
                messagesok++;
                //}
                //catch (System.Net.Mail.SmtpException smtpexc)
                //{

                //}
                //catch (System.Net.Mail.SmtpFailedRecipientsException recexp)
                //{

                //}
            }

            // return number of sent messages
            return messagesok;
        }


        public static int Send(string from, string replyto, string subject, string body, string directorypath, bool isAttachmentSameData, params string[] recipients)
        {
            // sent message counter
            int messagesok = 0;

            // create a new SMTP client with settings from AppSettings

            string smtpClientName = System.Configuration.ConfigurationManager.AppSettings["smtpserver"];
            Int32 smtpPort = Int32.Parse(System.Configuration.ConfigurationManager.AppSettings["smtpport"]);
            System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient(smtpClientName, smtpPort);
            client.EnableSsl = false;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Timeout = 20000;
            //if (smtpPort != 0)
            //{
            //    client.Host = smtpClientName;
            //    client.Port=  smtpPort;
            //}
            //else
            //{
            //    client.Host = smtpClientName;
            //}
            string smtpUsername = System.Configuration.ConfigurationManager.AppSettings["smtpusername"] as string;
            if (smtpUsername != null && smtpUsername.Trim().Length > 0)
                client.Credentials = new System.Net.NetworkCredential(smtpUsername, System.Configuration.ConfigurationManager.AppSettings["smtppassword"] as string);



            // create the message
            System.Net.Mail.MailMessage message = new System.Net.Mail.MailMessage();

            //perpare plain view
            AlternateView plainView = AlternateView.CreateAlternateViewFromString(StripHTML(body), null, "text/plain");


            // handle images
            List<LinkedResource> linkedresources = new List<LinkedResource>();
            if (directorypath != null)
            {
                MatchCollection images = Regex.Matches(body, @"<img[^>]+>");
                for (int i = 0; i < images.Count; i++)
                {
                    Match img = images[i];

                    Match m = Regex.Match(img.Value, @"(.*?src=\s*[""'])([^""']+)(.*)");

                    if (m.Success)
                    {
                        string filePath = System.IO.Path.Combine(directorypath, m.Groups[2].Value);
                        if (System.IO.File.Exists(filePath))
                        {
                            LinkedResource resource = new LinkedResource(filePath, ATLTravelPortal.EmailEngine.MIME.GetMimeType(System.IO.Path.GetExtension(filePath)));
                            linkedresources.Add(resource);

                            body = body.Replace(img.Value, string.Format("{0}cid:{1}{2}", m.Groups[1].Value, resource.ContentId, m.Groups[3].Value));
                        }
                    }
                }
            }

            //attachment link
            if (isAttachmentSameData == true)
            {
                //LinkedResource resourceAtt = new LinkedResource(strFilePath, AT.Core.Mail.MIME.GetMimeType(System.IO.Path.GetExtension(strFilePath)));                       
                //linkedresources.Add(resourceAtt); 

                byte[] byteArray = Encoding.ASCII.GetBytes(body);
                MemoryStream stream = new MemoryStream(byteArray);
                Attachment attach = new Attachment(stream, subject + ".html", ATLTravelPortal.EmailEngine.MIME.GetMimeType(".html"));
                message.Attachments.Add(attach);                

            }

            //perpare html view
            AlternateView htmlView = AlternateView.CreateAlternateViewFromString(body, null, "text/html");
            for (int i = 0; i < linkedresources.Count; i++)
                htmlView.LinkedResources.Add(linkedresources[i]);


            //attach views
            message.AlternateViews.Add(plainView);
            message.AlternateViews.Add(htmlView);

            // sender
            message.From = new System.Net.Mail.MailAddress(from);

            // if reply-to address is defined
            if (replyto != null && replyto != "") message.ReplyTo = new System.Net.Mail.MailAddress(replyto);

            message.Subject = subject;
            message.IsBodyHtml = true;
            //message.Body = body;
            message.SubjectEncoding = System.Text.Encoding.UTF8;


            foreach (string recipient in recipients)
            {
                // clear recipients
                message.To.Clear();
                // add current recipient
                message.To.Add(recipient);

                // send message
                //try
                //{
                client.Send(message);
                messagesok++;
                //}
                //catch (System.Net.Mail.SmtpException smtpexc)
                //{

                //}
                //catch (System.Net.Mail.SmtpFailedRecipientsException recexp)
                //{

                //}
            }

            // return number of sent messages
            return messagesok;
        }




        /// <summary>
        /// Send a text/plain message to a list of recipients
        /// </summary>
        /// <param name="from">Sender's address</param>
        /// <param name="replyto">Reply-to address</param>
        /// <param name="subject">Message subject</param>
        /// <param name="body">Message body</param>
        /// <param name="recipients">Recipient e-mail addresses</param>
        /// <returns>Number of sent messages</returns>
        public static int SendTemplate(string from, string replyto, string subject, string content, string templatepath, params string[] recipients)
        {
            string msg;
            System.IO.StreamReader sr = null;
            try
            {
                sr = System.IO.File.OpenText(templatepath);
                msg = sr.ReadToEnd();
            }
            finally
            {
                if (sr != null)
                    sr.Close();
            }

            msg = msg.Replace("<!-- SUBJECT -->", subject);
            msg = msg.Replace("<!-- CONTENT -->", content);

            return Send(from, replyto, subject, msg, System.IO.Path.GetDirectoryName(templatepath),false, recipients);
        }

        public static string StripHTML(string source)
        {
            if (source == null)
                return null;

            string result;

            // Remove HTML Development formatting
            // Replace line breaks with space
            // because browsers inserts space
            result = source.Replace("\r", " ");
            // Replace line breaks with space
            // because browsers inserts space
            result = result.Replace("\n", " ");
            // Remove step-formatting
            result = result.Replace("\t", string.Empty);
            // Remove repeating speces becuase browsers ignore them
            result = System.Text.RegularExpressions.Regex.Replace(result,
                                                                  @"( )+", " ");

            // Remove the header (prepare first by clearing attributes)
            result = System.Text.RegularExpressions.Regex.Replace(result,
                     @"<( )*head([^>])*>", "<head>",
                     System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            result = System.Text.RegularExpressions.Regex.Replace(result,
                     @"(<( )*(/)( )*head( )*>)", "</head>",
                     System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            result = System.Text.RegularExpressions.Regex.Replace(result,
                     "(<head>).*(</head>)", string.Empty,
                     System.Text.RegularExpressions.RegexOptions.IgnoreCase);

            // remove all scripts (prepare first by clearing attributes)
            result = System.Text.RegularExpressions.Regex.Replace(result,
                     @"<( )*script([^>])*>", "<script>",
                     System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            result = System.Text.RegularExpressions.Regex.Replace(result,
                     @"(<( )*(/)( )*script( )*>)", "</script>",
                     System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            //result = System.Text.RegularExpressions.Regex.Replace(result, 
            //         @"(<script>)([^(<script>\.</script>)])*(</script>)",
            //         string.Empty, 
            //         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            result = System.Text.RegularExpressions.Regex.Replace(result,
                     @"(<script>).*(</script>)", string.Empty,
                     System.Text.RegularExpressions.RegexOptions.IgnoreCase);

            // remove all styles (prepare first by clearing attributes)
            result = System.Text.RegularExpressions.Regex.Replace(result,
                     @"<( )*style([^>])*>", "<style>",
                     System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            result = System.Text.RegularExpressions.Regex.Replace(result,
                     @"(<( )*(/)( )*style( )*>)", "</style>",
                     System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            result = System.Text.RegularExpressions.Regex.Replace(result,
                     "(<style>).*(</style>)", string.Empty,
                     System.Text.RegularExpressions.RegexOptions.IgnoreCase);

            // insert tabs in spaces of <td> tags
            result = System.Text.RegularExpressions.Regex.Replace(result,
                     @"<( )*td([^>])*>", "\t",
                     System.Text.RegularExpressions.RegexOptions.IgnoreCase);

            // insert line breaks in places of <BR> and <LI> tags
            result = System.Text.RegularExpressions.Regex.Replace(result,
                     @"<( )*br( )*>", "\r",
                     System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            result = System.Text.RegularExpressions.Regex.Replace(result,
                     @"<( )*li( )*>", "\r",
                     System.Text.RegularExpressions.RegexOptions.IgnoreCase);

            // insert line paragraphs (double line breaks) in place
            // if <P>, <DIV> and <TR> tags
            result = System.Text.RegularExpressions.Regex.Replace(result,
                     @"<( )*div([^>])*>", "\r\r",
                     System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            result = System.Text.RegularExpressions.Regex.Replace(result,
                     @"<( )*tr([^>])*>", "\r\r",
                     System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            result = System.Text.RegularExpressions.Regex.Replace(result,
                     @"<( )*p([^>])*>", "\r\r",
                     System.Text.RegularExpressions.RegexOptions.IgnoreCase);

            // Remove remaining tags like <a>, links, images,
            // comments etc - anything thats enclosed inside < >
            result = System.Text.RegularExpressions.Regex.Replace(result,
                     @"<[^>]*>", string.Empty,
                     System.Text.RegularExpressions.RegexOptions.IgnoreCase);

            // replace special characters:
            result = System.Text.RegularExpressions.Regex.Replace(result,
                     @"&nbsp;", " ",
                     System.Text.RegularExpressions.RegexOptions.IgnoreCase);

            result = System.Text.RegularExpressions.Regex.Replace(result,
                     @"&bull;", " * ",
                     System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            result = System.Text.RegularExpressions.Regex.Replace(result,
                     @"&lsaquo;", "<",
                     System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            result = System.Text.RegularExpressions.Regex.Replace(result,
                     @"&rsaquo;", ">",
                     System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            result = System.Text.RegularExpressions.Regex.Replace(result,
                     @"&trade;", "(tm)",
                     System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            result = System.Text.RegularExpressions.Regex.Replace(result,
                     @"&frasl;", "/",
                     System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            result = System.Text.RegularExpressions.Regex.Replace(result,
                     @"<", "<",
                     System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            result = System.Text.RegularExpressions.Regex.Replace(result,
                     @">", ">",
                     System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            result = System.Text.RegularExpressions.Regex.Replace(result,
                     @"&copy;", "(c)",
                     System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            result = System.Text.RegularExpressions.Regex.Replace(result,
                     @"&reg;", "(r)",
                     System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            // Remove all others. More can be added, see
            // http://hotwired.lycos.com/webmonkey/reference/special_characters/
            result = System.Text.RegularExpressions.Regex.Replace(result,
                     @"&(.{2,6});", string.Empty,
                     System.Text.RegularExpressions.RegexOptions.IgnoreCase);

            // for testng
            //System.Text.RegularExpressions.Regex.Replace(result, 
            //       this.txtRegex.Text,string.Empty, 
            //       System.Text.RegularExpressions.RegexOptions.IgnoreCase);

            // make line breaking consistent
            result = result.Replace("\n", "\r");

            // Remove extra line breaks and tabs:
            // replace over 2 breaks with 2 and over 4 tabs with 4. 
            // Prepare first to remove any whitespaces inbetween
            // the escaped characters and remove redundant tabs inbetween linebreaks
            result = System.Text.RegularExpressions.Regex.Replace(result,
                     "(\r)( )+(\r)", "\r\r",
                     System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            result = System.Text.RegularExpressions.Regex.Replace(result,
                     "(\t)( )+(\t)", "\t\t",
                     System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            result = System.Text.RegularExpressions.Regex.Replace(result,
                     "(\t)( )+(\r)", "\t\r",
                     System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            result = System.Text.RegularExpressions.Regex.Replace(result,
                     "(\r)( )+(\t)", "\r\t",
                     System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            // Remove redundant tabs
            result = System.Text.RegularExpressions.Regex.Replace(result,
                     "(\r)(\t)+(\r)", "\r\r",
                     System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            // Remove multible tabs followind a linebreak with just one tab
            result = System.Text.RegularExpressions.Regex.Replace(result,
                     "(\r)(\t)+", "\r\t",
                     System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            // Initial replacement target string for linebreaks
            string breaks = "\r\r\r";
            // Initial replacement target string for tabs
            string tabs = "\t\t\t\t\t";
            for (int index = 0; index < result.Length; index++)
            {
                result = result.Replace(breaks, "\r\r");
                result = result.Replace(tabs, "\t\t\t\t");
                breaks = breaks + "\r";
                tabs = tabs + "\t";
            }

            // Thats it.
            return result;
        }
    }
}