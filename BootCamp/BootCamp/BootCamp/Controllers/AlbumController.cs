using BootCamp.Repository;
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
        private AlbumRepository _ctx { get; init; }
        public AlbunsController(AlbumRepository ctx)
        {
            this._ctx = ctx;
        }
        [HttpGet]
        public async Task<IActionResult> GetAlbuns()
        {
            return Ok((await this._ctx.GetAllAsync()));
        }
    }
}
