using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
            var checkSession = HttpContext.Session.Get("myToken");
            if (checkSession == null)
            {
                return Redirect("Home/About");
            }


            return View();

            //return Redirect("http://localhost:62587/");
        }

        public async Task<IActionResult> About()
        {
            ViewData["Message"] = "Redirecting...";


            var client = new HttpClient();


            //var b = await client.postasync()
            var a = await client.GetAsync("http://localhost:62497/api/Redirect");
            // var a = RedirectResult("http://localhost:62497/api/Redirect");

            if (a.IsSuccessStatusCode)
            {
                //Storing the response details recieved from web api   
                var EmpResponse = a.Content.ReadAsStringAsync().Result;

                System.Diagnostics.Debug.WriteLine(EmpResponse);
                HttpContext.Session.SetString("myToken", EmpResponse);

                return Redirect("Index");
            }



            return View();

            //return View();
            //return Redirect("http://localhost:62587/");
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
