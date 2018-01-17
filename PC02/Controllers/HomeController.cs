using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using PC02.Models;

namespace PC02.Controllers
{
    public class HomeController : Controller 
    {
        private string _authToken;
        private string _apiToken;
        private HttpClient _client;

        public HomeController()
        {
            _client = new HttpClient();
        }


        #region "BackEnd Communication"

        public IActionResult Index()
        {
            _authToken = HttpContext.Session.GetString("authToken");
            var a = HttpContext.Session.Get("authToken");
            if (_authToken == null)
            {
                //get token for authentication
                //change route to signIn
                //this will create a token that can communicate to web api
                //save to session
                return Redirect("Home/SignIn");
            }


            return View();
        }

        //this code is for backend to backend communication
        public async Task<IActionResult> SignIn()
        {
            //request a post to IDP server to gain an AuthToken
            await getAuthentication();
            GetAuthorization();

            return View();
        }

        public IActionResult SignOut()
        {
            HttpContext.Session.Clear();
            return View();
        }

        //this method is communicating to IDP server to gain an authentication token
        public async Task<IActionResult> getAuthentication()
        {
            var idpToken = await _client.PostAsync("http://localhost:60818/api/auth/token", null);

            if (idpToken.IsSuccessStatusCode)
            {
                //Storing the response details recieved from web api   
                var authToken = JsonConvert.DeserializeObject<AppToken>(idpToken.Content.ReadAsStringAsync().Result);
                HttpContext.Session.SetString("authToken", authToken.Token.ToString());
            }

            return Ok();
        }

        //this method generates its authorization token that will consumed by web api server only
        public void GetAuthorization()
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
            
            HttpContext.Session.SetString("apiToken", myToken);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        #endregion

        #region "FrontEnd Communication"

        //this method will consumed by an angular application
        //this tokens will be saved either in sessionstorage or localstorage
        [Produces("application/json")]
        [Route("api/myToken")]
        public IEnumerable<AppToken> GetToken()
        {
            _authToken = HttpContext.Session.GetString("authToken");
            _apiToken = HttpContext.Session.GetString("apiToken");

            List<AppToken> appTokens = new List<AppToken>();
            appTokens.Add(new AppToken { Token = _authToken, TokenName = "AuthToken" });
            appTokens.Add(new AppToken { Token = _apiToken, TokenName = "ApiToken" });

            return appTokens;
        }

        #endregion

        #region "DummyRegion"

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
        #endregion
    }
}
