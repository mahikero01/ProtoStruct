using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PC02.Models;

namespace PC02.Controllers
{
    public class HomeController : Controller
    {
        private string _authToken;
        private string _userToken;

        public HomeController()
        {

            _authToken = HttpContext.Session.GetString("authToken");
            _userToken = HttpContext.Session.GetString("userToken");
        }

        public IActionResult Index()
        {
            _authToken = HttpContext.Session.GetString("authToken");
            _userToken = HttpContext.Session.GetString("userToken");

            if (_authToken == null)
            {
                //get token for authentication
                //change route to signIn
            }

            return View();
        }

        public IActionResult SignIn()
        {
            return View();
        }


        //public IActionResult About()
        //{
        //    ViewData["Message"] = "Your application description page.";

        //    return View();
        //}

        //public IActionResult Contact()
        //{
        //    ViewData["Message"] = "Your contact page.";

        //    return View();
        //}

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
