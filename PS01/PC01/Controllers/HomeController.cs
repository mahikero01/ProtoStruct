using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PC01.Models;

namespace PC01.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            //Session
            //redirect http:Pi01
            return View();
            //return Redirect("http://localhost:62587/");
        }

        public IActionResult About()
        {
            //ViewData["Message"] = "Your application description page.";

            //return View();
            return Redirect("http://localhost:62587/");
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [Authorize]
        [HttpPost("api/auth/contoken")]
        public async Task<IActionResult> ConsumeToken()
        {
            return Ok("Api Acccess granted");
        }
    }
}
