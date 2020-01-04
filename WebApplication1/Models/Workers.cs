using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Workers
    {
        public int ID { get; set; }
        public string FullName { get; set; }
        public int Salary { get; set; }
        public string JobTitle { get; set; }
        public string Email { get; set; }

       // public int BrancheID { get; set; }
        public virtual Branches Branche { get; set; }


    }
}