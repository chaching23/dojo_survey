using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using dojo_survey.Models;


namespace dojo_survey.Controllers
{
    public class HomeController : Controller
    {
        private List<Dictionary<string, object>> AllUsers
        {
            get
            {
                return DbConnector.Query("SELECT * FROM users;");
            }
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("create")]
        public IActionResult Create(string name, string quote)
        {
            string insert = $"INSERT INTO users (name, quote) VALUES ('{name}', '{quote}');";
            DbConnector.Execute(insert);
            return RedirectToAction("Users");
        }

        [HttpGet("users")]
        public IActionResult Users()
        {
            return PartialView("UserPartial", AllUsers);       
        }




        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
