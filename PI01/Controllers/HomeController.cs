using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using PI01.Models;

namespace PI01.Controllers
{
    public class HomeController : Controller
    {
        private ILogger<HomeController> _logger;

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
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

        [HttpPost("api/auth/token")]
        public async Task<IActionResult> CreateToken()
        {
            try
            {
                var user = "mahikero";

                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub, user),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("verulonfdlsjflsfksfjsjkfsjkfjkshflsflsjfl;ksjfioshfohslflkskflgkey"));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    issuer: "http://mycodecamp.orf",
                    audience: "http://mycodecamp.orf",
                    claims: claims,
                    expires: DateTime.UtcNow.AddMinutes(15),
                    signingCredentials:  creds
                    );

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiration = token.ValidTo
                });
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception thrown while creating JWT: {ex}");
            }

            return BadRequest ("failed");
        }
    }
}
