using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Branches
    {
        [Key]
        public int ID { get; set; }
        public string branch_name { get; set; }
        public string city { get; set; }

        //public int OwnerID { get; set; }
        public virtual Owners Owner { get; set; }

         public ICollection<Workers> Workers { get; set; }
 
    }
}