using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ATLTravelPortal.Areas.Administrator.Controllers
{
    public class ImagePreviewController : Controller
    {
        #region Ajax Submit
        [HttpPost]
        public ActionResult AjaxSubmit(int? id)
        {
            Session["ContentLength"] = Request.Files[0].ContentLength;
            Session["ContentType"] = Request.Files[0].ContentType;
            byte[] b = new byte[Request.Files[0].ContentLength];
            Request.Files[0].InputStream.Read(b, 0, Request.Files[0].ContentLength);
            Session["ContentStream"] = b;
            return Content(Request.Files[0].ContentType + ";" + Request.Files[0].ContentLength);
        }
        #endregion

        #region ImageLoad
        public ActionResult ImageLoad(int? id)
        {
            byte[] b = (byte[])Session["ContentStream"];
            int length = (int)Session["ContentLength"];
            string type = (string)Session["ContentType"];
            Response.Buffer = true;
            Response.Charset = "";
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = type;
            Response.BinaryWrite(b);
            Response.Flush();
            Response.End();
            Session["ContentLength"] = null;
            Session["ContentType"] = null;
            Session["ContentStream"] = null;
            return Content("");
        }
        #endregion

    }
}
