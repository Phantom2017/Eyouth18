﻿using Eyouth1.Models;
using Microsoft.AspNetCore.Mvc;

namespace Eyouth1.Controllers
{
    public class DepartmentController : Controller
    {
        CompanyCtx companyCtx;
        public DepartmentController(CompanyCtx _companyCtx)
        {
            companyCtx = _companyCtx;
        }
        public IActionResult Index()
        {
            return View(companyCtx.Departments.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SaveDept(Department dept)
        {
            if (dept.Name!=null)
            {
                companyCtx.Departments.Add(dept);
                companyCtx.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("Create",dept);
        }

        public IActionResult Details(int id)
        {
            string compName = "ABC";
            int NoOfEmp = 10;
            DateTime today = DateTime.Now;
            //ViewData
            ViewData["Com"] = compName;
            ViewData["num"] = NoOfEmp;
            ViewData["date"]=today;
            //ViewData["list"] = new List<int> { 2, 4, 6, 8, 10 };
            ViewBag.list= new List<int> { 2, 4, 6, 8, 10 };
            TempData["id"] = id;

            //ViewModel

            return View(companyCtx.Departments.Find(id));
        }

        public IActionResult SetCookies()
        {
            CookieOptions options= new CookieOptions();
            options.Expires= DateTime.Now.AddDays(3);

            Response.Cookies.Append("c1", "Hello",options);
            return Content("Data is saved");
        }

        public IActionResult GetCookies()
        {
            string val= Request.Cookies["c1"];

            return Content("Value= "+val);
        }

        public IActionResult SetSession()
        {
            HttpContext.Session.SetString("s1", "Hello session");
            HttpContext.Session.SetInt32("s2", 200);

            return Content("Data is saved in session");
        }

        public IActionResult GetSession()
        {
            string name = HttpContext.Session.GetString("s1");
            int num = HttpContext.Session.GetInt32("s2").Value;

            return Content("name= " + name + " num= " + num);
        }

        public IActionResult Edit(int id)
        {
            var dept=companyCtx.Departments.Find(id);
            return View(dept);
        }

        public IActionResult DispalyPartial(int deptId)
        {
            var emps=companyCtx.Employees.Where(e=>e.DeptId==deptId).ToList();
            return PartialView("_MyPartial",emps);
        }
    }
}
