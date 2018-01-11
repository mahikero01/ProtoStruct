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
        private ISession _session;
        private string _authToken;
        private string _userToken;

        public HomeController()
        {
            _authToken = _session.GetString("authToken");
            _userToken = _session.GetString("userToken");

            if (_authToken == null)
            {
                //get token for authentication
                //change route to signIn
            }
        }

        public IActionResult Index()
        {
            

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
