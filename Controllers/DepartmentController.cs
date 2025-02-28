using Eyouth1.Models;
using Microsoft.AspNetCore.Mvc;

namespace Eyouth1.Controllers
{
    public class DepartmentController : Controller
    {
        CompanyCtx companyCtx;
        public DepartmentController()
        {
            companyCtx = new CompanyCtx();
        }
        public IActionResult Index()
        {
            return View(companyCtx.Departments.ToList());
        }

        public IActionResult Details(int id)
        {
            return View(companyCtx.Departments.Find(id));
        }
    }
}
