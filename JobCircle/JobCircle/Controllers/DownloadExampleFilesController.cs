using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JobCircle.Models;
namespace JobCircle.Controllers
{
    public class DownloadExampleFilesController : Controller
    {
        // GET: DownloadExampleFiles
        public ActionResult Download_PageLoad(DownloadExampleFiles ob, string rs)
        {
            //string f = Path.GetFileName(rs);
            //ob.rs=f;
            string filename = string.Format("~/RFD/{0}", rs);
            ob.rs1 = filename.ToString();
            //TempData["f"] = ob.rs;
            //ob.rs1 = rs;
            ////ob.rs = filename;
            return View("Download_PageLoad", ob);




        }
        
    }
}