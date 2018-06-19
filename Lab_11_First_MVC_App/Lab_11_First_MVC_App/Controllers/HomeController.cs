using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab_11_First_MVC_App.Models;
namespace Lab_11_First_MVC_App.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(int begYear, int endYear)
        {
            return RedirectToAction("Results", new { begYear, endYear });
        }

        public IActionResult Results(int begYear, int endYear)
        {
            TimePerson datPerson = new TimePerson();
            return View(datPerson.GetPeople(begYear, endYear));
        }
    }
}
