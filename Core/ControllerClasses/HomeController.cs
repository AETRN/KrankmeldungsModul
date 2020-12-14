using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KrankmeldungsModul.Core.ControllerClasses
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult BTN_Click(Object sender, EventArgs e)
        {
            return View();
        }
    }
}
