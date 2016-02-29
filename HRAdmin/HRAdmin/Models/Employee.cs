using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HRAdmin.Models
{
    
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string NamePositions { get; set; }
        public int PositionId { get; set; }
        public decimal Salary { get; set; }
        public string WorkPlace { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int? ProjectId { get; set; }
        public string Position { get; set; }
        public string Project { get; set; }
        public List<HRModule.Data.Position> Positions { get; set; }

        public Employee ToModel(HRModule.Data.Employee employee)
        {

            Employee emp = new Employee();

            emp.Email = employee.Email;
            emp.Id = Convert.ToInt32(employee.Id);
            emp.Name = employee.Name;
            emp.Phone = employee.Phone;
            emp.PositionId = employee.PositionId;
            emp.ProjectId = employee.ProjectId;
            emp.Salary = employee.Salary;
            emp.WorkPlace = employee.WorkPlace;
            return emp;
        }
    }
}