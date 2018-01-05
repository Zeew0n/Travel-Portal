using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using System.IO;
using ATLTravelPortal.Areas.Airline.Repository;
using System.Text;

namespace ATLTravelPortal.Areas.Airline.Controllers
{
    public class PaperFareUploadController : Controller
    {
        //
        // GET: /Administrator/PaperFareUpload/

        //
        // GET: /Upload/
        PaperFareUploadRepository fileRepository = new PaperFareUploadRepository();

        public ActionResult Index()
        {
            return View(fileRepository.GetAllFileDescription());
        }

        [HttpPost]
        public ActionResult Upload(string AirlineName)
        {

            foreach (string inputTagName in Request.Files)
            {
                HttpPostedFileBase file = Request.Files[inputTagName];
                string fileType = System.IO.Path.GetExtension(file.FileName);
                if (file.ContentLength > 0)
                {
                    string filePath = System.Web.Configuration.WebConfigurationManager.AppSettings["PaperFareUpPath"] + AirlineName + fileType;
                    //string filePath = Path.Combine(HttpContext.Server.MapPath( @"D:\PaperFareUpload\")
                    //    , Path.GetFileName(AirlineName + fileType));
                    file.SaveAs(filePath);
                }
            }

            return RedirectToAction("Index");
        }
         [HttpGet]
        public ActionResult GetFile(string FileName)
        {
            string ext = Path.GetExtension(FileName);
            string type = "";
            // set known types based on file extension  
            if (ext != null)
            {
                switch (ext.ToLower())
                {
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
            Response.ContentType = type;
            Response.AddHeader("content-disposition", "attachment; filename=" +FileName);
            string filePath = System.Web.Configuration.WebConfigurationManager.AppSettings["PaperFareUpPath"];// Path.Combine(HttpContext.Server.MapPath("/PaperFareUploads"));
            FileStream sourceFile = new FileStream(@filePath + FileName, FileMode.Open);
            long FileSize;
            FileSize = sourceFile.Length;
            byte[] getContent = new byte[(int)FileSize];
            sourceFile.Read(getContent, 0, (int)sourceFile.Length);
            sourceFile.Close();

            Response.BinaryWrite(getContent);

            return new EmptyResult();

        }

            [HttpGet]
         public ActionResult DownloadFile(string id)
        {
            string fname = id;
            bool forceDownload = true;
            string path = System.Web.Configuration.WebConfigurationManager.AppSettings["PaperFareUpPath"] + fname;// MapPath(fname);
            string name = Path.GetFileName(path);
            string ext = Path.GetExtension(path);
            name = name.Contains(" ") == true ? name.Replace(" ", "_") : name;
            string type = "";
            // set known types based on file extension  
            if (ext != null)
            {
                switch (ext.ToLower())
                {
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

           return new EmptyResult(); //Require No ActionExecutingContext  ActionFilterAttribute
        }


        [HttpGet]
        public ActionResult DeleteFile(string id)
        {
            try
            {
                string path = System.Web.Configuration.WebConfigurationManager.AppSettings["PaperFareUpPath"] + id;
                System.IO.File.Delete(path);
            }
            catch(Exception ex)
            {
                throw new NotSupportedException(ex.Message);
            }
            return RedirectToAction("Index");
        }

    }
}
