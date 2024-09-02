using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JobCircle.Models;
namespace JobCircle.Controllers
{

    public class CompanyJobDetailsController : Controller
    {
        JobSearch_DBEntities1 dob = new JobSearch_DBEntities1();
        // GET: CompanyJobDetails
        public ActionResult CompanyJobDetails_PageLoad()
        {

            //var data = dob.Sp_CompanyJobDetails().ToList();
            //ViewBag.userdetails = data;
            //return View();


            return View(GetData());
        }
        private JobSearch GetData()
        {
            var joblist = new JobSearch();
            List<string> list = new List<string>();
            var job = dob.JobTBs.ToList();
            foreach(var e in job)
            {
                var jobcls = new CompanyJobDetails();
                jobcls.jid = e.Job_Id;
                jobcls.cid = e.Company_RegId;
                jobcls.cname = e.Company_Name;
                jobcls.cna = e.Category_Name;
               
                jobcls.jna = e.Job_Name;
                jobcls.jty = e.Job_Type;
                jobcls.jloc = e.Job_Location;
                jobcls.jvno = e.Job_VacancyNo;
                jobcls.jqua = e.Job_Qualification;
                jobcls.jexp = e.Job_Experiance;
                jobcls.jskl = e.Job_Skills;
                jobcls.jpay = e.Job_PayScale;
                jobcls.jopda = e.Job_OpenDate;
                jobcls.jclsda = e.Job_CloseDate;
                joblist.selectjob.Add(jobcls);
                var s = jobcls.jskl;
                list.Add(s);
                TempData["ski"] = string.Join("", list);
               
            }
            return joblist;
        }
        public ActionResult CompanyJobDetails_Click(JobSearch ob)
        {
            string qry = "";
            if(!string.IsNullOrWhiteSpace(ob.insetse.jexp))
            {
                qry += " and Job_Experiance like '%" + ob.insetse.jexp + "%'";
            }
            if(!string.IsNullOrWhiteSpace(ob.insetse.jskl))
            {
                qry += " and Job_Skills like '%" + ob.insetse.jskl + "%'";
            }
            if (!string.IsNullOrWhiteSpace(ob.insetse.jloc))
            {
                qry += " and Job_Location like '%" + ob.insetse.jloc + "%'";
            }
            return View("CompanyJobDetails_PageLoad", getdata1(ob, qry));
        }
        private JobSearch getdata1(JobSearch ob,string qry)
        {
            using(var con= new SqlConnection(ConfigurationManager.ConnectionStrings["test"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("Sp_JobSearch", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@qry", qry);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                var joblist = new JobSearch();
                while(dr.Read())
                {
                    var jobcls = new CompanyJobDetails();
                   
                    jobcls.jid = Convert.ToInt32(dr["Job_Id"].ToString());
                    jobcls.cid = Convert.ToInt32(dr["Company_RegId"].ToString());
                    jobcls.cname = dr["Company_Name"].ToString();
                    jobcls.cna = dr["Category_Name"].ToString();
               
                    jobcls.jna = dr["Job_Name"].ToString();
                    jobcls.jty = dr["Job_Type"].ToString();
                    jobcls.jloc = dr["Job_Location"].ToString();
                    jobcls.jvno = Convert.ToInt32(dr["Job_VacancyNo"].ToString());
                    jobcls.jqua = dr["Job_Qualification"].ToString();
                    jobcls.jexp = dr["Job_Experiance"].ToString();
                    jobcls.jskl = dr["Job_Skills"].ToString();
                    jobcls.jpay = Convert.ToInt32(dr["Job_PayScale"].ToString());
                    jobcls.jopda = Convert.ToDateTime(dr["Job_OpenDate"].ToString());
                    jobcls.jclsda = Convert.ToDateTime(dr["Job_CloseDate"].ToString());
                    jobcls.jst = dr["Job_Status"].ToString();
                    joblist.selectjob.Add(jobcls);

                }
                con.Close();
                return joblist;
            }
        }
    }
}