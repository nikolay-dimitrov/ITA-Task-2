using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HRAdmin.Models
{
    public class ProjectViewModel 
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class ProjectHierarchyViewModel
    {
        public int Id { get; set; }
        public List<Employee> AvailableEmployeePool { get; set; }
        public List<Employee> Employees { get; set; }
        public Employee TeamLead { get; set; }
        public Employee ProjectManager { get; set; }
        public Employee DeliveryDirector { get; set; }
        public Employee CEO { get; set; }
        public int ProjectId { get; set; }
    }
}
