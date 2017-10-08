using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace CloudSecurity.Web.Controllers
{
    [Route("api/value")]
    public class ValuesController : Controller
    {
        [Authorize]
        [Route("getLogin")]
        public IActionResult GetLogin()
        {
            return Ok($"Your Login: {User.Identity.Name}");
        }

        [Authorize]
        [Route("getRole")]
        public IActionResult GetRole()
        {
            return Ok("Your role: administrator");
        }
    }
}
