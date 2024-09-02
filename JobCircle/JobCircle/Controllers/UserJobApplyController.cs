using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JobCircle.Models;

namespace JobCircle.Controllers
{
    public class UserJobApplyController : Controller
    {
        JobSearch_DBEntities1 dob = new JobSearch_DBEntities1();

        // GET: UserJobApply
        public ActionResult UserJobApply_PageLoad(UserJobApply ob, int jid,int cid,string jname)
        {
            //var getdata = dob.Sp_UserJobApplication1(1).FirstOrDefault();
            //return View(new UserJobApplication
            //{
            //    cname = getdata.Category_Name,
            //    jname = getdata.Job_Name,

            //    //rs=getdata.Resume
            //}
            //);


            ob.uid = Convert.ToInt32(Session["Uid"].ToString());
            //int uid = ob.uid;
            ob.jid = jid;
            ob.cid = cid;
            //ob.uid = uid;
            ob.jname = jname;
           
            var data = dob.Sp_UserJobApply(ob.jid,ob.cid,ob.uid,ob.jname);
            //var data = dob.Sp_UserJobApply(ob.jid, ob.cid, ob.uid, ob.jname).ToList();
            ViewBag.userdetails = data;
            return View();
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}