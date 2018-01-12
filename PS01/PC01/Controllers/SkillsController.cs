using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PC01.Controllers
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/Skills")]
    public class SkillsController : Controller
    {
        public SkillsController()
        {

        }
        private HttpClient _client;
        // GET: api/Skills
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    //triggers api from webapi if authorized to use.
        //}

        // GET: api/Skills/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }
        
        // POST: api/Skills
        [HttpPost]
        public void Post([FromBody]string value)
        {
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
