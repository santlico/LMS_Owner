using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Owners
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string OrgName { get; set; }
        public string Email { get; set; }
 

        public ICollection<Branches> Branch { get; set; }


    }
}