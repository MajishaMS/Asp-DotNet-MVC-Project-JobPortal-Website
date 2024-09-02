using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JobCircle.Models;
namespace JobCircle.Controllers
{
    public class UserLoginController : Controller
    {
        JobSearch_DBEntities1 dob = new JobSearch_DBEntities1();
        // GET: UserLogin
        public ActionResult UserLogin_Pageload()
        {
            return View();
        }
        public ActionResult UserLogin_Click(UserLogin ob)
        {


            if (ModelState.IsValid)
            {
                ObjectParameter op = new ObjectParameter("id", typeof(int));
                ObjectParameter op1 = new ObjectParameter("status", typeof(int));

                dob.Sp_UserLogin(ob.una,ob.pass,op,op1);
                int val = Convert.ToInt32(op1.Value);
                if (val == 1)
                {
                    Session["uname"] = ob.una;
                    Session["Uid"] = Convert.ToInt32(op.Value);
                    return RedirectToAction("UserHome");


                }
                else if (val == 2)
                {
                    Session["uname"] = ob.una;
                    Session["Uid"] = Convert.ToInt32(op.Value);
                    return RedirectToAction("CompanyHome");
                }
                else
                {
                    ModelState.Clear();
                    //ob.msg = op.Value.ToString();
                    ob.msg = "Invalid login";
                    return View("UserLogin_Pageload", ob);
                }



            }
            return View("userLogin_Pageload", ob);
        }
        public ActionResult UserHome()
        {
            return View();
        }
        public ActionResult CompanyHome()
        {
            return View();
        }
    }
}
