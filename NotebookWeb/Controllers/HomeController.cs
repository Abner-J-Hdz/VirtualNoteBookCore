using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotebookWeb.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        // GET: api/Notes
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return Ok(new { title = "Virtual Notebook API 1.0.0.0 " });
        }
    }
}
