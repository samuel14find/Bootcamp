using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BootCamp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlbumController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAlguns()
        {
            return Ok(new
            {
                Message = "Primeira Api Criada"
            });
        }
    }
}
