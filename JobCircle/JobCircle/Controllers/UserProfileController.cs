using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JobCircle.Models;
namespace JobCircle.Controllers
{
    public class UserProfileController : Controller
    {
        JobSearch_DBEntities1 dob = new JobSearch_DBEntities1();
        // GET: Profileviewedit
        public ActionResult UserProfile_PageLoad()
        {

            //var getdata = dob.Sp_UserProfile(Convert.ToInt32(Session["Uid"].ToString())).FirstOrDefault();
            int id = Convert.ToInt32(Session["Uid"].ToString());
            var getdata = dob.Sp_UserProfile(id).FirstOrDefault();
            return View(new UserProfile
            {
                na = getdata.Name,
                ag = getdata.Age,
                gen = getdata.Gender,
                add = getdata.Address,
                dist = getdata.District,
                st = getdata.State,
                pin = getdata.Pincode,
                ph = getdata.Phone,
                em = getdata.Email,
                pto = getdata.Photo,
                qua = getdata.Qualification,
                exp = getdata.Experience,
                skl = getdata.Skills,
                rs = getdata.Resume
            }
            );
        }
        public ActionResult UserProfile_Update(UserProfile ob)
        {
            dob.Sp_UserProfileUpdate(Convert.ToInt32(Session["Uid"].ToString()), ob.na, ob.ag, ob.gen, ob.add, ob.dist, ob.st, ob.pin, ob.ph, ob.em, ob.qua, ob.exp, ob.skl);
            ob.msg = "Successfully Updated";
            var getdata = dob.Sp_UserProfile(Convert.ToInt32(Session["Uid"].ToString())).FirstOrDefault();

            return View("UserProfile_PageLoad", new UserProfile
            {
                na = getdata.Name,
                ag = getdata.Age,
                gen = getdata.Gender,
                add = getdata.Address,
                dist = getdata.District,
                st = getdata.State,
                pin = getdata.Pincode,
                ph = getdata.Phone,
                em = getdata.Email,
                pto = getdata.Photo,
                qua = getdata.Qualification,
                exp = getdata.Experience,
                skl = getdata.Skills,
                //rs = getdata.Resume
            }
            );

        }
        public ActionResult Userfile_PageLoad(UserProfile ob)
        {
            return View();
        }
        public ActionResult Userfile_Update(UserProfile ob, HttpPostedFileBase file2, HttpPostedFileBase file3, FormCollection form)
        {
            if (ModelState.IsValid)
            {


                //var getdata = dob.Sp_UserProfile(Convert.ToInt32(Session["Uid"].ToString())).FirstOrDefault();

                //return View("Userfile_PageLoad", new UserProfile
                //{

                //    pto = getdata.Photo,

                //    rs = getdata.Resume
                //}
                //);

                if (file2.ContentLength > 0)
                {

                    string fname = Path.GetFileName(file2.FileName); //string p="~/PHS/"+FileUpload1.FileName
                    var s = Server.MapPath("~/PHS");
                    string p = Path.Combine(s, fname);
                    file2.SaveAs(p);// the above steps are ual to FileUpload1.SaveAs(MapPath(p))


                    var fullpath = Path.Combine("~\\PHS", fname);
                    ob.pto = fullpath;
                }
                if (file3.ContentLength > 0)
                {
                    string rname = Path.GetFileName(file3.FileName); //string p="~/PHS/"+FileUpload1.FileName
                    var s = Server.MapPath("~/RFD");
                    string p = Path.Combine(s, rname);
                    file3.SaveAs(p);// the above steps are ual to FileUpload1.SaveAs(MapPath(p))


                    var fullpath = Path.Combine("~\\RFD", rname);
                    ob.rs = fullpath;
                }
                dob.Sp_fileUpdate(Convert.ToInt32(Session["Uid"].ToString()), ob.pto, ob.rs);
                ob.msg = "Successfully Updated";
                return View("Userfile_PageLoad", ob);
            }

            return View("Userfile_PageLoad", ob);
        }
    }
}