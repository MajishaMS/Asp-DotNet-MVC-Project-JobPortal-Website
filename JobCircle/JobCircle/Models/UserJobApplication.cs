using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobCircle.Models
{
    public class UserJobApplication
    { 
        public int uid { set; get; }
        public int jid { set; get; }
       public int cid { set; get; }
        public string jname { set; get; }

        public string msg { set; get; }

    }
}