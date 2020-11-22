using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BootCamp.ViewModel.Response
{
    public class UserResponse
    {
        public Guid Id { get; set; }
        public String  Name { get; set; }
        public String Email { get; set; }
        public String Photo { get; set; }
        /// <summary>
        /// Quando o usuário faz a autenticação, tenho que carregar a lista de 
        /// músicas que ele escolheu para ser a favorita. Criei a classe 
        /// FavoritMusicResponse. E aqui então eu carrego uma Lista do tipo FavoritMusicResponse. 
        /// </summary>
        public List<FavoritMusicResponse> FavoritMusics { get; set; }
    }
}
