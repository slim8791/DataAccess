using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebServices.Models
{
    public class Employe
    {
        public int EmployeId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        [ForeignKey("Departement")]
        public int DepartementId { get; set; }

        public virtual Departement Departement { get; set; }
    }
}