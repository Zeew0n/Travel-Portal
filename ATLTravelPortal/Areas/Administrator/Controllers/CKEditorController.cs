using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

using ATLTravelPortal.Areas.Administrator.Models;
using CKEditor;

namespace ATLTravelPortal.Areas.Administrator.Controllers
{
    public class CKEditorController : Controller
    {
        public CKEditorModel _modObj = new CKEditorModel();
      
        //
        // GET: /Admin/CKEditor/

        [NonAction]
        private CKEditorModel GetViewModel(CKEditorModel model)
        {

            ///tranMode = "N" , "U", "L", "V"

            _modObj.ddlDirectoryList = BindDirectoryList();
            _modObj.ddlImageList = BindImageList();
            _modObj.SearchTerms = model.SearchTerms;

            return _modObj;
        }

        [HttpGet]
        public ActionResult ImageBrowser()
        {
            if (TempData["ViewResultForRedirect"] == null)
            {
                CKEditorModel model = new CKEditorModel();
                GetViewModel(model);
                return View(_modObj);
            }
            else {
               _modObj = (CKEditorModel) TempData["ViewResultForRedirect"];
                return View(_modObj);
            }
        }

        [HttpGet]
        public ActionResult LinkBrowser()
        {
            return View(_modObj);
        }

        [HttpPost]
        public ActionResult GetSelectListImage(string id)
        {
            _modObj.DirectoryList = id;
            _modObj.ImageFolder = (id == "Root" ? "" : "\\"+id) ;
            var ddlSelectOptionList = BindImageList();
            JsonResult jResult = new JsonResult();
            jResult.Data = ddlSelectOptionList;
            return jResult;
        }

        #region Folder

        [HttpPost]
        public ActionResult CreateFolder(CKEditorModel model)
        {            
            _modObj = model;
            string name = UniqueDirectory(_modObj.NewDirectoryName);
            Directory.CreateDirectory(_modObj.FileImageFolderRoot+"\\" + name);
            var ddlSelectOptionList = BindDirectoryList(name);
            JsonResult jResult = new JsonResult();
            jResult.Data = ddlSelectOptionList;
            return jResult;
        }
          
        [HttpPost]
        public string DeleteFolder(CKEditorModel model)
        {
            _modObj = model;
            if (model.DirectoryList != "Root")
            {
                _modObj.ImageFolder = model.DirectoryList;
                Directory.Delete(_modObj.FileImageFolder, true);
            }
            return "true";
        }

        #endregion

        #region Image

        [HttpPost]
        public ActionResult SearchImage(CKEditorModel model)
        {
            _modObj = model;
            var ddlSelectOptionList = BindImageList(model.SearchTerms);
            JsonResult jResult = new JsonResult();
            jResult.Data = ddlSelectOptionList;
            return jResult;
        }

        [HttpPost]
        public ActionResult GetImageDetail(string id, string ImageList)
        {
            _modObj.DirectoryList = id;
            _modObj.ImageFolder = (id == "Root" ? "" : "\\"+id );
            _modObj.ImageURL = _modObj.ImageFolder + "\\" + ImageList;
            _modObj.ImageHttpPath = _modObj.ImageContentURL + (id == "Root" ? "" : id + "/") + ImageList;

            ImageMedia img = ImageMedia.Create(System.IO.File.ReadAllBytes(_modObj.ImageURL));

            _modObj.ResizeWidth = img.Width.ToString();
            _modObj.ResizeHeight = img.Height.ToString();
            _modObj.ImageAspectRatio = "" + img.Width / (float)img.Height;


            JsonResult jResult = new JsonResult();
            jResult.Data = _modObj;
            return jResult;
        }

        [HttpPost]
        public ActionResult RenameImage(CKEditorModel model)
          {
              _modObj = model;

              _modObj.ImageFolder = (model.DirectoryList == "Root" ? "" : "\\" + model.DirectoryList);
              _modObj.ImageURL = _modObj.ImageFolder + "\\" + _modObj.ImageList;
              string filename = UniqueFilename(_modObj.NewImageName);
              System.IO.File.Move(_modObj.ImageURL, _modObj.ImageFolder +"\\"+ filename);

              var ddlSelectOptionList = BindImageList(filename);
              JsonResult jResult = new JsonResult();
              jResult.Data = ddlSelectOptionList;
              return jResult;

          }

        [HttpPost]
        public string ResizeImage(CKEditorModel model)
        {
            _modObj = model;

            _modObj.ImageFolder = (model.DirectoryList == "Root" ? "" : "\\" + model.DirectoryList);
            _modObj.ImageURL = _modObj.ImageFolder + "\\" + _modObj.ImageList;

            int width = Util.Parse<int>(_modObj.ResizeWidth);
            int height = Util.Parse<int>(_modObj.ResizeHeight);

            ImageMedia img = ImageMedia.Create(System.IO.File.ReadAllBytes(_modObj.ImageURL));
            img.Resize(width, height);
            System.IO.File.Delete(_modObj.ImageURL);
            System.IO.File.WriteAllBytes(_modObj.ImageURL, img.ToByteArray());

            return "true";
        }
           
        [HttpPost]
        public string DeleteImage(CKEditorModel model)
        {
            _modObj = model;
            System.IO.File.Delete(_modObj.FileImageFolder + _modObj.ImageList);
            return "true";        
        }

        [HttpPost]
        public ActionResult ImageBrowser(CKEditorModel model, HttpPostedFileBase UploadedImageFile)
        {
            _modObj = model;
            _modObj.ImageFolder = (model.DirectoryList == "Root" ? "" : "\\" + model.DirectoryList);
                          
            
            if (IsImage(UploadedImageFile.FileName))
            {
                string filename = UniqueFilename(UploadedImageFile.FileName);
                UploadedImageFile.SaveAs(_modObj.FileImageFolder + "\\" + filename);

                //byte[] data = ImageMedia.Create(UploadedImageFile.ContentLength).Resize(960, null).ToByteArray();
                //FileStream file = System.IO.File.Create(_modObj.FileImageFolder + filename);
                //file.Write(data, 0, data.Length);
                //file.Close();

               
                _modObj.ImageList = filename;
                

            }
            _modObj.ddlImageList = BindImageList();
            _modObj.ddlDirectoryList = BindDirectoryList();
            TempData["ViewResultForRedirect"] = _modObj;
            return RedirectToAction("ImageBrowser");
        }
        
        private ActionResult UploadImageRedirect()
        {
            return View("~/Areas/Admin/Views/CKEditor/ImageBrowser.cshtml", _modObj);
        }

          #endregion

        #region Private


        private List<SelectListItem> BindDirectoryList(string selectedValue = "")
        {
            List<SelectListItem> ddlList = new List<SelectListItem>();
            ddlList.Add(new SelectListItem { Text = "Root", Value = "Root" });
            _modObj.ImageFolder = "";
            string[] directories = Directory.GetDirectories(_modObj.FileImageFolder);
            directories = Array.ConvertAll<string, string>(directories, delegate(string directory) { return directory.Substring(directory.LastIndexOf('\\') + 1); });
            foreach (var x in directories)
            {
                ddlList.Add(new SelectListItem { Selected = (selectedValue == x.ToString() ? true : false), Text = x.ToString(), Value = x.ToString() });
            }
            return ddlList;         
        }

        private List<SelectListItem> BindImageList(string selectedValue="")
        {
            List<SelectListItem> ddlList = new List<SelectListItem>();
            _modObj.SearchTerms = _modObj.SearchTerms == null ? "" : _modObj.SearchTerms;
           // _modObj.ImageFolder = _modObj.ImageFolder == "Root" ? "" : _modObj.ImageFolder;
            string[] files = Directory.GetFiles(_modObj.FileImageFolder, "*" + _modObj.SearchTerms.Replace(" ", "*") + "*");
            files = Array.FindAll(files, delegate(string f) { return IsImage(f); });

            foreach (string file in files)
            {
                if (IsImage(file))
                {
                    string options = file.Substring(file.LastIndexOf('\\') + 1);
                    ddlList.Add(new SelectListItem { Selected = (selectedValue == options ? true : false), Text = options, Value = options });
                }
            }

            return ddlList;
        }

        //util methods
        private bool IsImage(string file)
        {
            return file.EndsWith(".jpg", StringComparison.CurrentCultureIgnoreCase) ||
                file.EndsWith(".gif", StringComparison.CurrentCultureIgnoreCase) ||
                file.EndsWith(".png", StringComparison.CurrentCultureIgnoreCase);
        }

        private string UniqueFilename(string filename)
        {
            string newfilename = filename;

            for (int i = 1; System.IO.File.Exists(_modObj.FileImageFolder + newfilename); i++)
            {
                newfilename = filename.Insert(filename.LastIndexOf('.'), "(" + i + ")");
            }

            return newfilename;
        }

        private string UniqueDirectory(string directoryname)
        {
            string newdirectoryname = directoryname;

            for (int i = 1; Directory.Exists(_modObj.FileImageFolderRoot + newdirectoryname); i++)
            {
                newdirectoryname = directoryname + "(" + i + ")";
            }

            return newdirectoryname;
        }
        #endregion
       
    }
}
