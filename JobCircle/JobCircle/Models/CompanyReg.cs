using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JobCircle.Models
{
    public class CompanyReg
    {
        public int id { set; get; }

        [Required(ErrorMessage = "Enter the name")]
        public string na { set; get; }

        [Required(ErrorMessage = "Enter the Address")]
        public string add { set; get; }

        [Required(ErrorMessage = "Enter the Address")]
      
        public long ph { set; get; }


        [Required(ErrorMessage = "Enter the Address")]
        public string em { set; get; }



        [Required(ErrorMessage = "Enter the Address")]
        public string wb { set; get; }

        [Required(ErrorMessage = "Enter the Address")]
        public string una { set; get; }
        [Required(ErrorMessage = "Enter the Address")]
        public string pwd { set; get; }

        [Required(ErrorMessage = "Enter the Address")]
        public string cpwd { set; get; }
        public string msg { set; get; }
    }
}