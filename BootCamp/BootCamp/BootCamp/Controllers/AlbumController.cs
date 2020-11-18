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
    public class AlbunsController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAlbuns()
        {
            return Ok(new
            {
                Message = "Primeira Api Criada"
            });
        }
    }
}
