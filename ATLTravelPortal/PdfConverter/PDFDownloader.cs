using System.IO;
using System.Web;
using ATLTravelPortal.PdfConverter;

//Author:arjuns.sapkota@gmail.com
namespace ATLTravelPortal.PdfConverter
{

    public sealed class PDFDownloader
    {
        private readonly TempFile tempFile;

        public PDFDownloader(TempFile tempFile)
        {
            this.tempFile = tempFile;
        }

        public void Download()
        {

            HttpContext.Current.Response.ContentType = "Application/pdf";
            HttpContext.Current.Response.AppendHeader("Content-Disposition", GetContentValue());
            HttpContext.Current.Response.TransmitFile(tempFile.FileName);
            HttpContext.Current.Response.End();

        }

        private static string GetContentValue()
        {

            return string.Format("attachment; filename={0}", "Eticket.pdf");
        }
    }
}