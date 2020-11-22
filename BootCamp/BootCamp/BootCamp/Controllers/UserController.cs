﻿using AutoMapper;
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
        public async Task<IActionResult> SignIn() 
        {
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
    }
}