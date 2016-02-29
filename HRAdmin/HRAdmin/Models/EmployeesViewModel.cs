using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HRAdmin.Models
{
    public class EmployeesViewModel
    {
        public List<HRAdmin.Models.Employee> Employees { get; set; }
        public List<HRAdmin.Models.ProjectViewModel> Projects { get; set; }
    }
}