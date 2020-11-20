using AutoMapper;
using BootCamp.Model;
using BootCamp.Repository;
using BootCamp.ViewModel.Request;
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
        private IMapper _mapper { get; init; }
        public AlbunsController(AlbumRepository ctx, IMapper mapper)
        {
            this._ctx = ctx;
            this._mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAlbuns()
        {
            return Ok((await this._ctx.GetAllAsync()));
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetAlbum(Guid id)
        {
            var result = await this._ctx.GetAlbumByIdAsync(id);
            if(result == null) return NotFound();

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> SaveAlbuns(AlbumRequest request) 
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            //Usar o AutoMapper aqui
            //Album album = new Album()
            //{
            //    Backdrop = request.Backdrop,
            //    Band = request.Band,
            //    Description = request.Description,
            //    Name = request.Name
            //};
            //await this._ctx.CreateAsync(album);
            //return Created($"/{album.Id}", album);

            Album album = this._mapper.Map<Album>(request);
            await this._ctx.CreateAsync(album);
            return Created($"/{album.Id}", album);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAlbun(Guid id)
        {
            var result = await this._ctx.GetAlbumByIdAsync(id);

            if (result == null)
                return NotFound();
            await this._ctx.DeleteAsync(result);
            return NoContent();
        }
    }
}
