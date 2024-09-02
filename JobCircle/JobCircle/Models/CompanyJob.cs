using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JobCircle.Models
{
    public class CompanyJob
    {

        public int id { set; get; }
        public int cid { set; get; }

        [Required(ErrorMessage = "Enter the name")]

        public string cna { set; get; }

        [Required(ErrorMessage = "Enter the Address")]
        public string jna { set; get; }

        [Required(ErrorMessage = "Enter the Address")]

        public string jty { set; get; }


        [Required(ErrorMessage = "Enter the Address")]
        public string jloc { set; get; }



        [Required(ErrorMessage = "Enter the Address")]
        public int jvno { set; get; }

        [Required(ErrorMessage = "Enter the Address")]
        public string jqua { set; get; }
        [Required(ErrorMessage = "Enter the Address")]
        public string jexp { set; get; }

        [Required(ErrorMessage = "Enter the Address")]
        public string jskl { set; get; }

        [Required(ErrorMessage = "Enter the Address")]
        public long jpay { set; get; }

        [Required(ErrorMessage = "Enter the Address")]
        public DateTime jopda { set; get; }
        [Required(ErrorMessage = "Enter the Address")]
        public DateTime jclsda { set; get; }

        public string msg { set; get; }
    }
}