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
        /// <summary>
        /// displays the home page
        /// </summary>
        /// <returns>a view of the Index.cshtml page</returns>
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// redirects to the Results method
        /// </summary>
        /// <param name="begYear">the beginning year that the user typed</param>
        /// <param name="endYear">the end year that the user typed</param>
        /// <returns>a redirect to the Results method</returns>
        [HttpPost]
        public IActionResult Index(int begYear, int endYear)
        {
            return RedirectToAction("Results", new { begYear, endYear });
        }

        /// <summary>
        /// displays list with filters
        /// </summary>
        /// <param name="begYear">the beginning year that the user typed</param>
        /// <param name="endYear">the end year that the user typed</param>
        /// <returns>a view of the Results.cshtml page</returns>
        public IActionResult Results(int begYear, int endYear)
        {
            TimePerson datPerson = new TimePerson();
            return View(datPerson.GetPeople(begYear, endYear));
        }
    }
}
