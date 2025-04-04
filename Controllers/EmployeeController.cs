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
        [ValidateAntiForgeryToken]
        public IActionResult SaveNew(Employee emp)
        {
            if (ModelState.IsValid)
            {
                companyCtx.Employees.Update(emp);
                companyCtx.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("Edit",emp);
        }

        public ActionResult Create()
        {
            ViewData["list"] = companyCtx.Departments.ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Employee emp)
        {
            if (ModelState.IsValid && emp.DeptId!=0)
            {
                companyCtx.Employees.Add(emp);
                companyCtx.SaveChanges();
                return RedirectToAction("Index");
            }
            else {
                ModelState.AddModelError("", "Please select dept");
                ViewData["list"] = companyCtx.Departments.ToList();
                return View(emp);
            }
        }

        public JsonResult MutipleThree(decimal Salary,string Name)
        {
            if (Salary % 3 == 0)
            {
                return Json(true);
            }
            return Json(false);
        }
    }
}
