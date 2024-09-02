using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JobCircle.Models;
namespace JobCircle.Controllers
{
    public class UserJobApplicationController : Controller
    {
        // GET: UserJobApplication
        JobSearch_DBEntities1 dob = new JobSearch_DBEntities1();
     
        public ActionResult UserJobApplication_PageLoad(UserJobApplication ob)
        {
            ob.uid = Convert.ToInt32(Session["Uid"].ToString());
            //var getdata = dob.Sp_UserJobApplication1(ob.uid).FirstOrDefault();
            //return View(new UserJobApplication
            //{
            //    cname = getdata.Category_Name,
            //    jname = getdata.Job_Name,

            //    //rs=getdata.Resume
            //}
            //);


            
            //var data = dob.Sp_UserJobApplication1(ob.uid).ToList();
            var data = dob.Sp_UserJobApp(ob.uid).ToList();
            ViewBag.JobAPPdetails = data;
            return View();
        }
        
    }
}