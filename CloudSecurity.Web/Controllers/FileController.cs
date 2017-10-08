using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Authorization;

namespace CloudSecurity.Web.Controllers
{
    
    [Route("api/File")]
    public class FileController : Controller
    {
        CloudSecurityContext _context;
        IHostingEnvironment _appEnvironment;
        public FileController(CloudSecurityContext context, IHostingEnvironment appEnvironment)
        {
            _context = context;
            _appEnvironment = appEnvironment;
        }

        [HttpPost]
        [Authorize]
        [Route("upLoadFile")]
        public async Task<IActionResult> AddFile(IFormFile uploadedFile)
        {
            if(uploadedFile != null)
            {
                string path = "/";
            }
            throw new NotImplementedException();
        }

    }
}