using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JobCircle.Models
{

    public class StClass
    {
        public int sid { set; get; }
        public string sname { set; get; }
    }
    public class checkboxlistHelper
    {
        public string value { set; get; }
        public string text { set; get; }
        public bool IsChecked { set; get; }
    }
    public class UserReg
    {
        public int sid { get; set; }
        public string sname { get; set; }
        public List<checkboxlistHelper> MyFavQual { get; set; }
        public string[] selectedQual { get; set; }


        public int id { set; get; }

       [Required(ErrorMessage = "Enter the name")]
        public string na { set; get; }

        [Range(18, 60, ErrorMessage = "Enter a valid age")]
        public int ag { set; get; }
       
        public string gen { set; get; }
        [Required(ErrorMessage = "Enter the Address")]
        public string add { set; get; }
        [Required(ErrorMessage = "Enter the Address")]
        public string dist { set; get; }
        
        //public string st { set; get; }

        [Required(ErrorMessage = "Enter the Address")]
        public long pin { set; get; }

        [Required(ErrorMessage = "Enter the Address")]
        public long ph { set; get; }

        [Required(ErrorMessage = "Enter the Address")]
        public string em { set; get; }
        
        public string pto { set; get; }
      
        public string qua { set; get; }
        [Required(ErrorMessage = "Enter the Address")]
        public string exp { set; get; }
        [Required(ErrorMessage = "Enter the Address")]
        public string skl { set; get; }
       
        public string rs { set; get; }

        //[Required(ErrorMessage = "Enter the Address")]
        //public string us { set; get; }

        [Required(ErrorMessage = "Enter the Address")]
        public string una { set; get; }
        [Required(ErrorMessage = "Enter the Address")]
        public string pwd { set; get; }

        [Required(ErrorMessage = "Enter the Address")]
        public string cpwd { set; get; }
        public string msg { set; get; }
    }
}