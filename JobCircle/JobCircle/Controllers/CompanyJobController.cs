using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JobCircle.Models;
namespace JobCircle.Controllers
{
    public class CompanyJobController : Controller
    {
        JobSearch_DBEntities1 dob = new JobSearch_DBEntities1();
        // GET: CompanyReg
        public ActionResult CompanyJob_PageLoad()
        {

            return View();
        }
        public ActionResult CompanyJob_Click(CompanyJob ob)
        {
            if (ModelState.IsValid)
            {
                ObjectParameter op = new ObjectParameter("id", typeof(int));
                dob.Sp_jobid(op);

                //int val= Convert.ToInt32(op.Value);
                string val = op.Value.ToString();

                if (val == "")
                {
                    ob.id = 1001;
                }
                else
                {

                    int jid = Convert.ToInt32(val);
                    ob.id = jid + 1;
                }
                ob.cid = Convert.ToInt32(Session["uid"].ToString());

                dob.Sp_CompanyJob(ob.id,ob.cid,ob.cna, ob.jna, ob.jty, ob.jloc, ob.jvno,ob.jqua,ob.jexp,ob.jskl,ob.jpay,ob.jopda,ob.jclsda);

                
                ob.msg = "inserted";
                return View("CompanyJob_PageLoad", ob);
            }
            else
            {
                return View("CompanyJob_PageLoad", ob);
            }

        }
    }
}