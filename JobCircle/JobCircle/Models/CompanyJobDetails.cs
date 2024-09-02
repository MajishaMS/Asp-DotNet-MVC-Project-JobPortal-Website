using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobCircle.Models
{
    public class JobSearch
    {
        public CompanyJobDetails insetse { set; get; }
        public List<CompanyJobDetails> selectjob { set; get; }
        public JobSearch()
        {
            selectjob = new List<CompanyJobDetails>();
            insetse = new CompanyJobDetails();
        }
       
    }
    public class CompanyJobDetails
    {
        public int id { set; get; }
        public int jid { set; get; }
        public int cid { set; get; }

        public string cname { set; get; }

        public string cna { set; get; }

       
        public string jna { set; get; }

        

        public string jty { set; get; }


       
        public string jloc { set; get; }



        public int jvno { set; get; }

       
        public string jqua { set; get; }
       
        public string jexp { set; get; }

       
        public string jskl { set; get; }

       
        public long jpay { set; get; }

       
        public DateTime jopda { set; get; }
      
        public DateTime jclsda { set; get; }
        public string jst { set; get; }

        public string msg { set; get; }
    }
}