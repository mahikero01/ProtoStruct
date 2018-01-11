using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PC02.Models;

namespace PC02.Controllers
{
    public class HomeController : Controller
    {
        private string _authToken;
        private string _userToken;
        private HttpClient _client;

        public IActionResult Index()
        {
            _authToken = HttpContext.Session.GetString("authToken");
            _userToken = HttpContext.Session.GetString("userToken");

            if (_authToken == null)
            {
                //get token for authentication
                //change route to signIn
                return Redirect("Home/SignIn");
            }
            return View();
        }

        public async Task<IActionResult> SignIn()
        {
            //request a post to IDP server to gain an AuthToken
            var idpToken = await _client.PostAsync("http://localhost:60818/api/auth/token", null);

            if (idpToken.IsSuccessStatusCode)
            {
                //Storing the response details recieved from web api   
                var authToken = JsonConvert.DeserializeObject<AppToken>(idpToken.Content.ReadAsStringAsync().Result);
                HttpContext.Session.SetString("authToken", authToken.Token.ToString());
            }

            return View();
        }

        public IActionResult SignOut()
        {
            HttpContext.Session.Clear();
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
