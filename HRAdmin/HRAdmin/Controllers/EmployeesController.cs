using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HRAdmin.Controllers
{
    public class EmployeesController : Controller
    {
        // GET: Employees
        public ActionResult Index()
        {
            var context = new HRModule.Data.HRModuleEntities();

            List<HRAdmin.Models.Employee> Employees = new List<Models.Employee>();

            List<HRModule.Data.Employee> employees = new List<HRModule.Data.Employee>();
            employees = context.Employees.ToList();

            foreach (var item in employees)
            {
                HRAdmin.Models.Employee employee = new Models.Employee();
                employee.Email = item.Email;
                employee.Id = Convert.ToInt32(item.Id);
                employee.Name = item.Name;
                employee.Phone = item.Phone;
                employee.PositionId = item.PositionId;
                employee.ProjectId = item.ProjectId;
                employee.Salary = item.Salary;
                employee.WorkPlace = item.WorkPlace;

                employee.Position = context.Positions.Where(x => x.Id == employee.PositionId).Select(x => x.Name).First();
                if(employee.ProjectId != null)
                { 
                employee.Project = context.Projects.Where(x => x.Id == employee.ProjectId).Select(x => x.Name).First();
                }
                Employees.Add(employee);
            }

            List<HRAdmin.Models.ProjectViewModel> Projects = new List<Models.ProjectViewModel>();
            List<HRModule.Data.Project> projects = context.Projects.ToList();
            foreach (var item in projects)
            {
                HRAdmin.Models.ProjectViewModel Project = new Models.ProjectViewModel();
                Project.Id = item.Id;
                Project.Name = item.Name;

                Projects.Add(Project);
            }

            HRAdmin.Models.EmployeesViewModel model = new Models.EmployeesViewModel();
            model.Employees = Employees;
            model.Projects = Projects;

            return View(model);
        }

        public ActionResult CreateEmployee(Models.Employee employee)
        {
            var context = new HRModule.Data.HRModuleEntities();

            var Employee = new HRModule.Data.Employee
            {
                Email = employee.Email,
                Name = employee.Name,
                Phone = employee.Phone,
                PositionId = employee.PositionId,
                ProjectId = employee.ProjectId,
                Salary = employee.Salary,
                WorkPlace = employee.WorkPlace,
            };

            try
            {
                var employeeId = context.Employees.Add(Employee);
                context.SaveChanges();
            }
            catch (Exception ex)
            {

            }
            return RedirectToAction("index");

        }
        
        }
}