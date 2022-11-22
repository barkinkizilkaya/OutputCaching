using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;

namespace OutputCaching.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [OutputCache(PolicyName = "ByQuery")]
    public class CacheController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get(string Culture)
        {
            return Ok(DateTime.Now.ToString());
        }

       
    }
}
