using AutoMapper;
using BootCamp.Model;
using BootCamp.Repository;
using BootCamp.ViewModel.Request;
using BootCamp.ViewModel.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootCamp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private UserRepository _userRepository { get; init; }
        private IMapper _mapper { get; init; }
        private AlbumRepository _albumRepository { get; init; }

        public UserController(UserRepository ctx, IMapper mapper, AlbumRepository albumRepository)
        {
            this._userRepository = ctx;
            this._mapper = mapper;
            this._albumRepository = albumRepository;
        }

        /// Devemos criar API para:
        /// Autenticar, Registar, Favoritar a Musica, e Desfavoritar a Musica 
        
        [HttpPost("authenticate")]
        public async Task<IActionResult> SignIn([FromBody] SignInRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
           

            /// Nosso password está em base 64. A request vai vir com o password em string. 
            var password = Convert.ToBase64String(Encoding.UTF8.GetBytes(request.Password));
               
            var user = await this._userRepository.AuthenticateAsync(request.Email, password);
            if(user == null)
            {
                return Unauthorized(new
                {
                    Message = "Email/Senha inválidos"
                });
                ;
            }

            var result = this._mapper.Map<UserResponse>(user);
            return Ok(result);
        }
        
        

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var user = this._mapper.Map<User>(request);

            /// Aqui vamos fazer uma regra básica para setar o password. Lembrar que 
            /// la no RegisterRequest tem um field chamado password. Ou seja o password 
            /// tá vindo na requisição. Usaremos uma criptocrafia basicona, base 64, 
            /// para trabalhar. Mas poderiamos usar a autenticação pelo IdentityServer. 
            user.Password = Convert.ToBase64String(Encoding.UTF8.GetBytes(user.Password));

            /// Agora vamos trabalhar a foto do usuário. Vamos pegar a foto do usuário 
            /// de forma aleatória usando o serviço https://robohash.org/
            /// Essa não é a forma correta pois deveriamos estar usando WSBuket ou Azure
            /// BobStorage para fazer isso. 
            user.Photo = $"https://robohash.org/{Guid.NewGuid()}.png?bgset=any";
            await this._userRepository.CreateAsync(user);

            var result = this._mapper.Map<UserResponse>(user);

            return Created($"{result.Id}", result); //Porque não colocou o / como em return Created($"/{album.Id}", album)?
        }

        ///Agora devemos criar APIs para adicionar as músicas ao favorito
        
        [HttpPost("{id}/favorite-music/{musicId}")]
        public async Task<IActionResult> SaveUserFavoriteMusic(Guid id, Guid musicId)
        {
            var music = await this._albumRepository.GetMusicAsync(musicId);
            /// Aqui vou notar que quando eu busco meu User, essa busca também tem que 
            /// trazer as Musicas Favoritas dele
            var user = await this._userRepository.GetUserAsync(id);

            if (user == null)
                return UnprocessableEntity(new { Message = "User not Found" });
            if (music == null)
                return UnprocessableEntity(new { Message = "Music not Found" });

            user.AddFavoritMusic(music); 

            await this._userRepository.UpdateAsync(user);

            return Ok();
        }
    }
}
