using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PW01.Controllers
{
    //[Authorize]
    [Produces("application/json")]
    
    [Route("api/[controller]")]
    public class SkillsController : Controller
    {
        // GET api/Skills
        [HttpGet]
        public IEnumerable<SS_Skillsets> Get()
        {
            return new SS_Skillsets[] {
                new SS_Skillsets
                {
                    IsActive=true,
                    SkillsetDescr="1",
                    SkillsetID=1
                },
                new SS_Skillsets
                {
                    IsActive=true,
                    SkillsetDescr="2",
                    SkillsetID=2
                }
            };
        }
        
        [HttpPost]
        public void Post([FromBody]SS_Skillsets skillset)
        {
            System.Diagnostics.Debug.WriteLine(skillset);
        }
    }
    public class SS_Skillsets
    {
        public int SkillsetID { get; set; }
        public string SkillsetDescr { get; set; }
        public bool IsActive { get; set; }
    }

}
