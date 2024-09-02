using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JobCircle.Models;
namespace JobCircle.Controllers
{
    public class UserRegController : Controller
    {
        JobSearch_DBEntities1 dob = new JobSearch_DBEntities1();
      
        // GET: UserReg
        public ActionResult UserReg_PageLoad()
        {
            List<StClass> slist = new List<StClass>
            {
                new StClass{ sid = 1,sname="kerala" },
                new StClass { sid = 2, sname = "karnadka" },
                new StClass { sid = 2, sname = "Thamilnadu" }
            };

            ViewBag.Selstates = new SelectList(slist, "sid", "sname");
            //CheckBox List
            UserReg user = new UserReg();
            user.MyFavQual = getQulData();

            return View(user);
           
        }
        public List<checkboxlistHelper> getQulData()
        {
            List<checkboxlistHelper> sts = new List<checkboxlistHelper>()
            {
                new checkboxlistHelper{value="SSLC",text="SSLC",IsChecked=true},
                new checkboxlistHelper{value="PLUS TWO",text="PLUS TWO",IsChecked=false},
                new checkboxlistHelper{value="BSC",text="BSC",IsChecked=false},
                new checkboxlistHelper{value="MSC",text="MSC",IsChecked=false},
                new checkboxlistHelper{value="BTEC",text="BTEC",IsChecked=false},
            };
            return sts;
        }
        public ActionResult UserReg_Click(UserReg ob, HttpPostedFileBase file, HttpPostedFileBase file1, FormCollection form)
        {
            if (ModelState.IsValid)
            {

                ObjectParameter op = new ObjectParameter("id", typeof(int));
                dob.Sp_id(op);

                //int val= Convert.ToInt32(op.Value);
                string val = op.Value.ToString();

                if(val=="")
                {
                    ob.id = 1;
                }
                else
                {
                    int uid = Convert.ToInt32(val);
                    ob.id=uid+1;
                }

                if (file.ContentLength > 0)
                {
                    
                    string fname = Path.GetFileName(file.FileName); //string p="~/PHS/"+FileUpload1.FileName
                    var s = Server.MapPath("~/PHS");
                    string p = Path.Combine(s, fname);
                    file.SaveAs(p);// the above steps are ual to FileUpload1.SaveAs(MapPath(p))


                    var fullpath = Path.Combine("~\\PHS", fname);
                    ob.pto = fullpath;
                }
                if (file1.ContentLength > 0)
                {
                    string rname = Path.GetFileName(file1.FileName); //string p="~/PHS/"+FileUpload1.FileName
                    var s = Server.MapPath("~/RFD");
                    string p = Path.Combine(s, rname);
                    file1.SaveAs(p);// the above steps are ual to FileUpload1.SaveAs(MapPath(p))


                    var fullpath = Path.Combine("~\\RFD", rname);
                    ob.rs = fullpath;
                }
                List<StClass> slist = new List<StClass>
                {
                new StClass{ sid = 1,sname="kerala" },
                new StClass { sid = 2, sname = "karnadka" },
                new StClass { sid = 2, sname = "Thamilnadu" }
                };

                ViewBag.Selstates = new SelectList(slist, "sid", "sname");
                int ids = Convert.ToInt32(form["ddlstates"]);
                StClass selectedItem = slist.FirstOrDefault(c => c.sid == ids);
                ob.sid = selectedItem.sid;
                ob.sname = selectedItem.sname;
                //ob.st = ob.sname;
                var qid = string.Join(",", ob.selectedQual);
                ob.qua = qid;

                ob.MyFavQual = getQulData();

                dob.Sp_UserReg(ob.id,ob.na, ob.ag, ob.gen, ob.add, ob.dist, ob.sname, ob.pin, ob.ph, ob.em, ob.pto, ob.qua, ob.exp, ob.skl, ob.rs);

                dob.Sp_LoginReg(ob.id,ob.una, ob.pwd);
                ob.msg = "inserted";
                return View("UserReg_PageLoad", ob);
            }
            else
            {
                List<StClass> slist = new List<StClass>
                {
                new StClass{ sid = 1,sname="kerala" },
                new StClass { sid = 2, sname = "karnadka" },
                new StClass { sid = 2, sname = "Thamilnadu" }
                };

                ViewBag.Selstates = new SelectList(slist, "sid", "sname");

                ob.MyFavQual = getQulData();
                return View("UserReg_PageLoad", ob);
            }
        }
    }
}