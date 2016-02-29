using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HRAdmin.Models;

namespace HRAdmin.Controllers
{
    public class ManageEmployeeController : Controller
    {
        // GET: ManageEmployee
        public PartialViewResult Index(string employeeId)
        {
           
            int eId = Convert.ToInt32(employeeId);
            var context = new HRModule.Data.HRModuleEntities();
            ViewBag.Positions = context.Positions.ToList();
            ViewBag.Projects = context.Projects.ToList();

            Employee Employee = new Employee();
            if (eId != 0)
            {
                var employee = context.Employees.Where(x => x.Id == eId).FirstOrDefault();
                Employee = Employee.ToModel(employee);
                Employee.Position = context.Positions.Where(x => x.Id == Employee.PositionId).Select(x => x.Name).FirstOrDefault();
                Employee.Project = context.Projects.Where(x => x.Id == Employee.ProjectId).Select(x => x.Name).FirstOrDefault();

                Employee.Positions = context.Positions.ToList();
            }
            return PartialView("~/Views/Shared/ManageEmployee.cshtml", Employee);
        }

        public PartialViewResult RenderCreateProject()
        {
            ProjectViewModel model = new ProjectViewModel();

            return PartialView("~/Views/Shared/CreateProject.cshtml", model);
        }

        public ActionResult CreateProject(ProjectViewModel project)
        {
            var context = new HRModule.Data.HRModuleEntities();

            var Project = new HRModule.Data.Project
            {
                Name = project.Name
            };

            try
            {
                var projectId = context.Projects.Add(Project);
                context.SaveChanges();
            }
            catch (Exception ex)
            {

            }

            return RedirectToAction("Index", "Employees");
        }
    }
}