using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JobCircle.Models
{
    public class UserLogin
    {

        [Required(ErrorMessage = "enter user name")]
        public string una { set; get; }
        [Required(ErrorMessage = "enter password")]
        public string pass { set; get; }
       
        public string msg { set; get; }
    }
}