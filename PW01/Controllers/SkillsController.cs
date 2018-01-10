using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PW01.Controllers
{
    [Authorize]
    //[Produces("application/json")]
    [Route("api/[controller]")]
    public class SkillsController : Controller
    {
        // GET api/Skills
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "Skill1", "skill2" };
        }
    }
}