using System;
using System.IO;
using System.Web;


namespace ATLTravelPortal.PdfConverter
{

    public class TempFile : IDisposable
    {

        public TempFile()
        {
            string mapPath = HttpContext.Current.Server.MapPath("~/Temp");
            if (!Directory.Exists(mapPath))
            {
                Directory.CreateDirectory(mapPath);
            }

            FileName = Path.GetTempFileName(); //It gets full path, and we don't need full path, we'll be 
            //creating file in Temp folder of the Project directory
            string extension = GetExtension();
            if (String.IsNullOrEmpty(extension))
            {
                extension = "";
            }
            FileName = Path.Combine(mapPath, Path.GetFileNameWithoutExtension(FileName) + extension);

        }

        protected virtual string GetExtension()
        {
            return "";
        }

        public void Write(string content)
        {
            File.WriteAllText(FileName, content);
        }

        public string FileName { get; private set; }

        #region IDisposable Members

        public void Dispose()
        {
            if (File.Exists(FileName))
            {
                try
                {
                    File.Delete(FileName);
                }
                catch
                {
                    //writeLog
                }
            }
        }

        #endregion
    }

    public sealed class TempPdfFile : TempFile
    {
        protected override string GetExtension()
        {
            return ".pdf";
        }
    }

    public sealed class TempHtmlFile : TempFile
    {
        protected override string GetExtension()
        {
            return ".htm";
        }
    }


}