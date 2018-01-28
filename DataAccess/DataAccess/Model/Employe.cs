using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Model
{
    public class Employe
    {
        public int EmployeId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int DepartementId { get; set; }

        public virtual RestfullServices.Departement Departement { get; set; }
    }
}
