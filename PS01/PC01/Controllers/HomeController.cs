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
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Logging;

namespace PC01.Controllers
{
    public class HomeController : Controller
    {
        //private SessionObject _session;
        //privat token Authtoken _session;

        public HomeController()
        {
            /*check session if empty or not
            /if empty request to idp url then 
            save JWT to _session

            
            */



            //angular client will get _session value then append the value top the 
            //Controller/action
            //e .g. 


            /*
             * create token for WEB API consumption
             
             */
        }




        [Authorize (Roles = "admin")]
        //http:doma:port/Home/CreateDepartment
        public void CreateDepartment()
        {



            //http://pw01/api/department (httpPOST)
            //http://pw01/api/person (httpPOST)


        }

        private ILogger<HomeController> _logger;
        private string _webApiToken = "";

        public async Task<IActionResult> Index()
        {

            var user = "mahikero";

            var claims = new[]
            {
                 new Claim(ClaimTypes.Name, user),
                 new Claim(ClaimTypes.Actor, "CocoM")
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("03fb1760-a45f-4473-bed4-aab1e8d7e87a"));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: "http://localhost:60812",
                audience: "http://localhost:60822",
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(30),
                signingCredentials: creds
            );


            var myToken = new JwtSecurityTokenHandler().WriteToken(token);
            _webApiToken = myToken;
            //Session
            //redirect http:Pi01
            //var checkSession = HttpContext.Session.GetString("myToken");
            //if (checkSession == null)
            //{
            //    return Redirect("Home/About");
            //}

            //AppToken a = new AppToken();
            //a = checkSession;
            //System.Diagnostics.Debug.WriteLine(a.Token);
            //await accessToken(checkSession);
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
            //System.Diagnostics.Debug.WriteLine(HttpContext.User.IsInRole("admin"));
            var roles = ((ClaimsIdentity)User.Identity).Claims
                .Where(c => c.Type == ClaimTypes.Role)
                .Select(c => c.Value).First();


            return Ok("Api Acccess granted"+ roles);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("api/auth/contoken2")]
        public IActionResult ConsumeToken2()
        {
            return Ok("Api Acccess granted");
        }

        //[Authorizationrole= admin]
        public async Task<IActionResult> CreateSkill()
        {
            try
            {

                System.Diagnostics.Debug.WriteLine("\n\n" + _webApiToken + "\n\n");
                var client = new HttpClient();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _webApiToken);

                var requestToWebApi = await client.GetAsync("http://localhost:60822/api/skills");


                return Ok(requestToWebApi.Content.ReadAsStreamAsync().Result);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception thrown while creating JWT: {ex}");
            }


            return Ok();
        }
        [HttpGet("api/home/getSkills")]
        public async Task<IActionResult> CreateSkillApi()
        {
            try
            {

                System.Diagnostics.Debug.WriteLine("\n\n" + _webApiToken + "\n\n");
                var client = new HttpClient();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _webApiToken);

                var requestToWebApi = await client.GetAsync("http://localhost:60822/api/skills");


                return Ok(requestToWebApi.Content.ReadAsStreamAsync().Result);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception thrown while creating JWT: {ex}");
            }


            return Ok();
        }
    }
}
