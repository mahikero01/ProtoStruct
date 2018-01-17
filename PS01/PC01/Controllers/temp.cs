using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PC01.Controllers
{
    public class temp
    {
        //SecurityToken validatedToken;
        //var tokenHandler = new JwtSecurityTokenHandler();
        //var key = new SymmetricSecurityKey(
        //    Encoding.UTF8.GetBytes(Startup.Configuration["IDPServer:IssuerSigningKey"]));
        //var tokenValidationParameters = new TokenValidationParameters()
        //{
        //    ValidAudiences = new string[]
        //    {   Startup.Configuration["IDPServer:ValidAudience"]
        //    },
        //    ValidIssuers = new string[]
        //    {
        //        Startup.Configuration["IDPServer:ValidIssuer"]
        //    },
        //    IssuerSigningKey = key

        //};
        //var claimsPrincipal = tokenHandler.ValidateToken(token, tokenValidationParameters, out validatedToken);
        //var claimsIdentity = claimsPrincipal.Identity as ClaimsIdentity;



        //// test only
        //var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("jjshfkhfkghbvcviutlnvunnksjknvkfjbkrtygbdfg545678566jdkhiufh"));
        //SecurityToken validatedToken;
        //var tokenHandler = new JwtSecurityTokenHandler();

        //var tokenValidationParameters = new TokenValidationParameters()
        //{
        //    ValidAudiences = new string[]
        //    {   "http://mycodecamp.orf"
        //    },
        //    ValidIssuers = new string[]
        //    {
        //        "http://mycodecamp.orf"
        //    },
        //    IssuerSigningKey = key

        //};
        //var claimsPrincipal = tokenHandler.ValidateToken(_authToken, tokenValidationParameters, out validatedToken);
        //var asd = claimsPrincipal.Identity as ClaimsIdentity;
        ////identity.AddClaim(new Claim);
        //System.Diagnostics.Debug.WriteLine(validatedToken.ToString());
        //System.Diagnostics.Debug.WriteLine(asd);
        //System.Diagnostics.Debug.WriteLine(validatedToken.Id);
        //var jwtToken = new JwtSecurityToken(_authToken);
        //System.Diagnostics.Debug.WriteLine(jwtToken.ToString());
        ////var identity = new ClaimsIdentity(HttpContext.User.Identity);
        //System.Diagnostics.Debug.WriteLine(jwtToken.Claims.ToString());
        //var name = jwtToken.Claims
        //    .Where(x => x.Type == ClaimTypes.Role 
        //        || x.Type == ClaimTypes.Name
        //        || x.Type == ClaimTypes.Actor).Select(x=>x.Value);

        //foreach(var xz in name)
        //{
        //    System.Diagnostics.Debug.WriteLine(xz);
        //}

        ////foreach(var xz in name)
        ////    System.Diagnostics.Debug.WriteLine(xz.type + " " + xz.value );


    }
}
