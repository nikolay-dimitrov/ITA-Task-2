using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HRAdmin.Models;

namespace HRAdmin.Controllers
{
    public class ProjectController : Controller
    {
        // GET: Project
        public PartialViewResult ProjectHierarchy(string projectId)
        {
            var model = LoadModel(projectId);
            

            return PartialView("~/Views/Shared/Heirarchy.cshtml", model); 
        }

        public PartialViewResult DeleteFromHierarchy(string employeeId, string projectId)
        {
            int employeeID = Convert.ToInt32(employeeId);

            var context = new HRModule.Data.HRModuleEntities();

            var employee = context.Employees.Where(x => x.Id == employeeID).FirstOrDefault();
            employee.ProjectId = null;
            context.SaveChanges();

            var model = LoadModel(projectId);

            return PartialView("~/Views/Shared/Heirarchy.cshtml", model); 

        }

        public PartialViewResult AddToHierarchy(string personId, string projectId)
        {
            int employeeID = Convert.ToInt32(personId);
            var context = new HRModule.Data.HRModuleEntities();

            var employee = context.Employees.Where(x => x.Id == employeeID).FirstOrDefault();
            employee.ProjectId = Convert.ToInt32(projectId);
            context.SaveChanges();

            var model = LoadModel(projectId);

            return PartialView("~/Views/Shared/Heirarchy.cshtml", model);
        }

        public ProjectHierarchyViewModel LoadModel(string projectId)
        {
            int projectID = Convert.ToInt32(projectId);

            var context = new HRModule.Data.HRModuleEntities();
            List<HRAdmin.Models.Employee> Employees = new List<Models.Employee>();
            List<HRModule.Data.Employee> employees = context.Employees.Where(x => x.PositionId > 0 && x.PositionId < 5 && x.ProjectId == null).ToList();

            Employees = EmployeeHelper(employees);

            ViewBag.AvailableEmployeePool = new SelectList(Employees, "Id", "NamePositions");

            HRAdmin.Models.ProjectHierarchyViewModel model = new Models.ProjectHierarchyViewModel();
            model.AvailableEmployeePool = Employees;


            employees = context.Employees.Where(x => x.PositionId > 0 && x.PositionId < 5 && x.ProjectId == projectID).ToList();

            Employees = EmployeeHelper(employees);
            model.Employees = Employees;

            model.TeamLead = GetEmployee(projectID, 5);
            if (model.TeamLead.Id == 0)
            {
                employees = context.Employees.Where(x => x.PositionId == 5 && x.ProjectId == null).ToList();
                Employees = EmployeeHelper(employees);
                ViewBag.AvailableTLs = new SelectList(Employees, "Id", "NamePositions");
            }
            model.ProjectManager = GetEmployee(projectID, 6);
            if (model.ProjectManager.Id == 0)
            {
                employees = context.Employees.Where(x => x.PositionId == 6).ToList();
                Employees = EmployeeHelper(employees);
                ViewBag.PMS = new SelectList(Employees, "Id", "NamePositions");

            }
            model.DeliveryDirector = GetEmployee(projectID, 7);
            if (model.DeliveryDirector.Id == 0)
            {
                employees = context.Employees.Where(x => x.PositionId == 7).ToList();
                Employees = EmployeeHelper(employees);
                ViewBag.DDS = new SelectList(Employees, "Id", "NamePositions");

            }
            model.CEO = GetEmployee(projectID, 8);

            model.ProjectId = projectID;

            return model;
        }

        public Employee GetEmployee(int projectId, int positionId)
        {
            var context = new HRModule.Data.HRModuleEntities();
            Employee Employee = new Employee();

            if (positionId == 8)
            {
                var employeee = context.Employees.Where(x => x.PositionId == positionId).FirstOrDefault();
                Employee = Employee.ToModel(employeee ?? new HRModule.Data.Employee());
                return Employee;

            }
            var employee = context.Employees.Where(x => x.PositionId == positionId && x.ProjectId == projectId).FirstOrDefault();
            Employee = Employee.ToModel(employee ?? new HRModule.Data.Employee());
            return Employee;
        }
        public List<HRAdmin.Models.Employee> EmployeeHelper(List<HRModule.Data.Employee> employees)
        {
            var context = new HRModule.Data.HRModuleEntities();
            List<HRAdmin.Models.Employee> Employees = new List<Models.Employee>();

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
                if (employee.ProjectId != null)
                {
                    employee.Project = context.Projects.Where(x => x.Id == employee.ProjectId).Select(x => x.Name).First();
                }
                employee.NamePositions = item.Name + ", " + item.Position.Name;

                Employees.Add(employee);
            }

            return Employees;
        }
    }
}