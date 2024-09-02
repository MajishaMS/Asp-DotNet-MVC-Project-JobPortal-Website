using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JobCircle.Models;
namespace JobCircle.Controllers
{
    public class CompanyRegController : Controller
    {
        JobSearch_DBEntities1 dob = new JobSearch_DBEntities1();
        // GET: CompanyReg
        public ActionResult CompanyReg_PageLoad()
        {
            
                return View();
        }
        public ActionResult Companylogin_pageload()
        {
            return View();
        }
        public ActionResult CompanyReg_Click(CompanyReg ob)
        {
            if (ModelState.IsValid)
            {
                ObjectParameter op = new ObjectParameter("id", typeof(int));
                dob.Sp_id(op);

                //int val= Convert.ToInt32(op.Value);
                string val = op.Value.ToString();

                if (val == "")
                {
                    ob.id = 1;
                }
                else
                {
                    int uid = Convert.ToInt32(val);
                    ob.id = uid + 1;
                }

                dob.Sp_CompanyReg(ob.id, ob.na, ob.add, ob.ph, ob.em, ob.wb);

                dob.Sp_Logincom(ob.id, ob.una, ob.pwd);
                ob.msg = "inserted";
                return View("Companylogin_pageload", ob);
            }
            else
            { 
                return View("Companylogin_pageload", ob); 
            }
               
        }
    }
}