using Microsoft.AspNetCore.Mvc;

namespace Eyouth1.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ViewStudent()
        {
            return View();
        }

        public IActionResult AddStudent()
        {
            return View();
        }
    }
}
