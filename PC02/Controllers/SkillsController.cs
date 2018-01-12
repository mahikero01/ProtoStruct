using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PC02.Controllers
{
    [Produces("application/json")]
    [Route("api/Skills")]
    public class SkillsController : HomeController
    {
        private HttpClient _client;
        private string _apiToken;

        public void construct()
        {
            _client = new HttpClient();
            _apiToken = HttpContext.Session.GetString("apiToken");
            var a = HttpContext.Session.GetString("authToken");
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _apiToken);
        }



        // GET: api/Skills
        [HttpGet]
        [Authorize]
        public async Task<string> Get()
        {
            construct();
            //triggers api from webapi if authorized to use.
            var a = await _client.GetAsync("http://localhost:60822/api/skills");
            return a.Content.ReadAsStringAsync().Result;
            //return new string[] { "value1", "value2" };
        }

        // GET: api/Skills/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Skills

        [Authorize]
        [HttpPost]
        public string Post(int id)
        {
            return "you are admin that is why you are authorized to use this method";
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
