using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JobCircle.Models;

namespace JobCircle.Controllers
{
    public class UserJobApplicatDetailsController : Controller
    {
        JobSearch_DBEntities1 dob = new JobSearch_DBEntities1();
        // GET: UserJobApplicatDetails
        public ActionResult UserJobApplicatDetails_PageLoad(int uid)
        {

            //var getdata = dob.Sp_UserProfile(Convert.ToInt32(Session["Uid"].ToString())).FirstOrDefault();
            //int id = Convert.ToInt32(Session["Uid"].ToString());
            var getdata = dob.Sp_UserJobApplicatDetails(uid).FirstOrDefault();
            return View(new UserJobApplicatDetails
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
            ); ;
        }
        public ActionResult UserProfile_Data(UserProfile ob)
        {
            //dob.Sp_UserProfileUpdate(Convert.ToInt32(Session["Uid"].ToString()), ob.na, ob.ag, ob.gen, ob.add, ob.dist, ob.st, ob.pin, ob.ph, ob.em, ob.qua, ob.exp, ob.skl);
            //ob.msg = "Successfully Updated";
            var getdata = dob.Sp_UserJobApplicatDetails(Convert.ToInt32(Session["Uid"].ToString())).FirstOrDefault();

            return View("Sp_UserJobApplicatDetails_PageLoad", new UserJobApplicatDetails
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
       

       





        //public FileStreamResult GetPDF()
        //{
        //    FileStream fs = new FileStream("C:\\HT_2_hallticket", FileMode.Open, FileAccess.Read);
        //    return File(fs, "application/pdf");
        //}




        //public FileStreamResult GetPDF(string rs)
        //{
        //    FileStream fs = new FileStream(Server.MapPath(@"rs"), FileMode.Open, FileAccess.Read);
        //    return File(fs, "application/pdf");
        //}

        //public FilePathResult DownloadExampleFiles(string rs)
        //{
        //    //return new FilePathResult(string.Format(@"~\RHS\{0}", rs + ".pdf"), "text/plain");
        //     return new FilePathResult(string.Format(@"~\RHS\{0}", rs + ".pdf"), "PDF/plain");
            
        //}



        //public ActionResult Index()
        //{
        //    //Fetch all files in the Folder (Directory).
        //    string[] filePaths = Directory.GetFiles(Server.MapPath("~/RHS/"));

        //    //Copy File names to Model collection.
        //    List<FileModel> files = new List<FileModel>();
        //    foreach (string filePath in filePaths)
        //    {
        //        files.Add(new FileModel { FileName = Path.GetFileName(filePath) });
        //    }

        //    return View(files);
        //}

        //public FileResult DownloadFile(string rs)
        //{
        //    //Build the File Path.
        //    string path = Server.MapPath("~/RFD/") + rs;

        //    //Read the File data into Byte Array.
        //    byte[] bytes = System.IO.File.ReadAllBytes(path);

        //    //Send the File to Download.
        //    return File(bytes, "application/octet-stream", rs);
        //}
    }
}


