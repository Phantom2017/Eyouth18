using System.Diagnostics;
using Eyouth1.Models;
using Microsoft.AspNetCore.Mvc;

namespace Eyouth1.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;

        public HomeController()
        {
            //_logger = logger;
        }

        //Action
        //1) public
        //2) Can't be static
        //3) Can't be overloaded
        public IActionResult Index()
        {
            ViewData["par"] = 50;
            return View("Index",new List<Employee>());
        }

        public ContentResult Hello()
        {
            //prepare
            ContentResult content = new ContentResult();

            //Set
            content.Content = "Hello MVC";
            return content;
        }

        public ViewResult MyView()
        {
            ViewResult view = new ViewResult();

            view.ViewName = "view1";
            return view;
        }

        public IActionResult myView2(int myId)
        {
            if (myId == 1)
            {
                return View("view1");
            }
            else
            {
                //prepare
                return Content("Hellow MVC");
            }
        }

        //Content ContentResult
        //View    ViewResult
        //Json JsonResult
        //File
        //NotFound
        //NotAuthorized

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult ChatRoom()
        {
            return View();
        }
    }
}
