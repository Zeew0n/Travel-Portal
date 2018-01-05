using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using ATLTravelPortal.Areas.Airline.Controllers;
using ATLTravelPortal.PdfConverter;
using HtmlAgilityPack;
using Resources;
using ATLTravelPortalt.Helpers;


namespace ATLTravelPortal.Helpers
{
    internal class ImagePathFixer : IDisposable
    {
        readonly List<TempFile> tempFiles = new List<TempFile>();
        public string FixImagePath(string htmContent)
        {
            HtmlDocument htmDocument = new HtmlDocument();
            htmDocument.LoadHtml(htmContent);
            Fix(htmDocument, "agentLogo");
            // Fix(htmDocument, "poweredByLogo");
            RemoveSendEmailFields(htmDocument);
            return htmDocument.DocumentNode.OuterHtml;
        }

        public void RemoveSendEmailFields(HtmlDocument document)
        {
            var emailTextBoxNode = document.GetElementbyId("emailTextBox");
            if (emailTextBoxNode != null)
                emailTextBoxNode.Remove();
            var emailbtnSendNode = document.GetElementbyId("btnSendEmail");
            if (emailbtnSendNode != null)
                emailbtnSendNode.Remove();
        }

        private TempFile CreateTempFile()
        {
            TempFile tempFile = new TempFile();
            this.tempFiles.Add(tempFile);
            return tempFile;
        }

        private void Fix(HtmlDocument document, string elementId)
        {
            HtmlNodeCollection htmlNodeCollection = document.DocumentNode.SelectNodes(string.Format("//img[@id='{0}']", elementId));
            TempFile tempImage =null;
            foreach (var elementbyId in htmlNodeCollection)
            {
                string image = elementbyId.Attributes["src"].Value;

                //remove ellipses if any
                if (image.StartsWith("../"))
                {
                    image = image.Replace("../", string.Empty);

                }
                string serverPath = HttpContext.Current.Server.MapPath("~");
                string resolved = Path.Combine(serverPath, image);
                if (!File.Exists(resolved))
                {
                    string directoryName = Path.GetDirectoryName(resolved);
                    resolved = Path.Combine(directoryName, "DefaultLogo.png");
                    if(!File.Exists(resolved))
                    {
                      
                        Images.DefaultLogo.Save(resolved);
                    }
                    
                }
                if (tempImage == null)
                {
                    tempImage = CreateTempFile();
                    ImageResizer.ResizeImage(resolved, tempImage.FileName, 180, 75, true);

                }
                elementbyId.Attributes["src"].Value = tempImage.FileName;
            }
            //Do not dispose temp file here, file will later be used by other element
        }


        public void Dispose()
        {
            foreach (TempFile tempFile in tempFiles)
            {
                //Clean all the temp files
                tempFile.Dispose();

            }
            tempFiles.Clear();
        }
    }
}