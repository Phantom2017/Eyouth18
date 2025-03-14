using Eyouth1.Models;
using Microsoft.AspNetCore.Mvc;

namespace Eyouth1.Controllers
{
    public class EmployeeController : Controller
    {
        CompanyCtx companyCtx;
        public EmployeeController()
        {
            companyCtx = new CompanyCtx(); 
        }

        public IActionResult Index()
        {
            return View(companyCtx.Employees.ToList());
        }

        public IActionResult Edit(int Id)
        {
            var emp=companyCtx.Employees.Find(Id);
            ViewData["list"]=companyCtx.Departments.ToList();
            return View(emp);
        }

        [HttpPost]
        public IActionResult SaveNew(Employee emp)
        {
            if (emp.Name!=null)
            {
                companyCtx.Employees.Update(emp);
                companyCtx.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("Edit",emp);
        }
    }
}
