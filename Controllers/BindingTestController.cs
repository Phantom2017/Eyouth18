using Microsoft.AspNetCore.Mvc;

namespace Eyouth1.Controllers
{
    public class BindingTestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult testPr(string str,int v1) 
        {
            //From action to view ===>ViewData, ViewBag, ViewModel, Model

            //From view to action ====> primitive types
            /*
             1) Request.Form
             2) Request.RouteValues
             3) Request.QueryString
             4) Default value
             
             */

            return Content("OK");
        }
    }
}
