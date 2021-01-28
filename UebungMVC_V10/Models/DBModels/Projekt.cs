using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace UebungMVC_V10.Models.DBModels
{
    public class Projekt
    {
        public int ProjektNUM { get; set; }

        public string ProjektTitle { get; set; }

        //[ForeignKey("ApplicationUsers")]
        //public int Id { get; set; }
        //public virtual ICollection<ApplicationUser> ApplicationUsers { get; set; }
    }
}