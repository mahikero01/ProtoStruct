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
using Newtonsoft.Json;

namespace PC01.Controllers
{
    public class HomeController : Controller
    {
        public async Task<IActionResult> Index()
        {
            //Session
            //redirect http:Pi01
            var checkSession = HttpContext.Session.GetString("myToken");
            if (checkSession == null)
            {
                return Redirect("Home/About");
            }

            //AppToken a = new AppToken();
            //a = checkSession;
            //System.Diagnostics.Debug.WriteLine(a.Token);
            await accessToken(checkSession);
            return View();

            //return Redirect("http://localhost:62587/");
        }


        public async Task<IActionResult> accessToken(string token)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var a = await client.PostAsync("http://localhost:62477/api/auth/contoken", null);
            var b = await client.PostAsync("http://localhost:62477/api/auth/contoken2", null);

            verify(a);
            verify(b);


            return Ok();
        }

        public void verify(HttpResponseMessage x)
        {
            if (x.IsSuccessStatusCode)
            {
                System.Diagnostics.Debug.WriteLine(x.Content.ReadAsStringAsync().Result);
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("not authenticated");
            }
            
        }


        public async Task<IActionResult> About()
        {
            ViewData["Message"] = "Redirecting...";


            var client = new HttpClient();


            //var b = await client.postasync()
            var a = await client.PostAsync("http://localhost:56638/api/auth/token", null);
            // var a = RedirectResult("http://localhost:62497/api/Redirect");

            if (a.IsSuccessStatusCode)
            {
                //Storing the response details recieved from web api   
                var EmpResponse = JsonConvert.DeserializeObject<AppToken>(a.Content.ReadAsStringAsync().Result);



                System.Diagnostics.Debug.WriteLine(EmpResponse);
                HttpContext.Session.SetString("myToken", EmpResponse.Token.ToString());

                //return Redirect("Index");
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
        public IActionResult ConsumeToken()
        {
            return Ok("Api Acccess granted");
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("api/auth/contoken2")]
        public IActionResult ConsumeToken2()
        {
            return Ok("Api Acccess granted");
        }

    }
}
