using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PC02.Controllers
{
    [Produces("application/json")]
    [Route("api/Skills")]
    public class SkillsController : Controller
    {
        private HttpClient _client;
        // GET: api/Skills
        [HttpGet]
        [Authorize]
        public IEnumerable<string> Get()
        {
            //triggers api from webapi if authorized to use.

            return new string[] { "value1", "value2" };
        }

        // GET: api/Skills/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Skills

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Post([FromBody]string value)
        {
            return Ok("you are admin that is why you are authorized to use this method");
        }
        
        // PUT: api/Skills/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
