using Eyouth1.Models;
using Microsoft.AspNetCore.Mvc;

namespace Eyouth1.Controllers
{
    public class StudentController : Controller
    {
        StudentBL studentBL;
        public StudentController()
        {
           studentBL = new StudentBL();
        }
        public IActionResult Index()
        {
            return View(studentBL.GetAll());
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            return View(studentBL.GetById(id));
        }

       
    }
}
