using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Basic_Banking_System.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Customers()
        {
            return View();
        }

        public IActionResult History()
        {
            return View();
        }

        public IActionResult AboutUs()
        {
            return View();
        }
    }
}
