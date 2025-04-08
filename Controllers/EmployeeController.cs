using Eyouth1.Models;
using Eyouth1.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Eyouth1.Controllers
{
    public class EmployeeController : Controller
    {
        //private readonly IEmployeeRepository employeeRepository;
        //private readonly IDepartmentRepository departmentRepository;
        private readonly IUnitOfWork unitOfWork;

        //CompanyCtx companyCtx;
        public EmployeeController(IUnitOfWork unitOfWork)
        {
            //this.employeeRepository = employeeRepository;
            //this.departmentRepository = departmentRepository;
            this.unitOfWork = unitOfWork;
            //companyCtx = new CompanyCtx(); 
        }

        public IActionResult Index()
        {
            return View(unitOfWork.EmployeeRepository.GetAll());
        }

        public IActionResult Edit(int Id)
        {
            //var emp=companyCtx.Employees.Find(Id);
            var emp = unitOfWork.EmployeeRepository.GetById(Id);
            ViewData["list"] = unitOfWork.DepartmentRepository.GetAll();
            //ViewData["list"]=companyCtx.Departments.ToList();
            return View(emp);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SaveNew(Employee emp)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.EmployeeRepository.Update(emp);
                unitOfWork.Complete();
                //companyCtx.Employees.Update(emp);
                //companyCtx.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("Edit",emp);
        }

        public ActionResult Create()
        {
            ViewData["list"] = unitOfWork.DepartmentRepository.GetAll();
            //ViewData["list"] = companyCtx.Departments.ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Employee emp)
        {
            if (ModelState.IsValid && emp.DeptId!=0)
            {
                unitOfWork.EmployeeRepository.Add(emp);
                unitOfWork.Complete();
                //companyCtx.Employees.Add(emp);
                //companyCtx.SaveChanges();
                return RedirectToAction("Index");
            }
            else {
                ModelState.AddModelError("", "Please select dept");
                ViewData["list"] = unitOfWork.DepartmentRepository.GetAll();
                //ViewData["list"] = companyCtx.Departments.ToList();
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
