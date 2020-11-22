using BootCamp.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BootCamp.Repository
{
    public class UserRepository
    {
        private MusicContext _ctx { get; init; }

        public UserRepository(MusicContext ctx)
        {
            this._ctx = ctx;
        }

        public async Task CreateAsync(User user)
        {
            await this._ctx.Users.AddAsync(user);
            await this._ctx.SaveChangesAsync(); 
        }

        public async Task<User> AuthenticateAsync(string email, string password)
        {
            /// Primeiro estamos incluindo as favoritas do usuário. Dentro das musicas 
            /// favoritas tem uma propriedade chamada Music. E dentro de Music tenho a 
            /// propriedade Album. Ai eu informa o Entity Framework para carregar elas 
            /// para mim. 
            return await this._ctx.Users
                .Include(x => x.FavoritMusics)
                .ThenInclude(x => x.Music)
                .ThenInclude(x => x.Album)
                .Where(x => x.Email == email && x.Password == password)
                .FirstOrDefaultAsync();

        }

        public async Task<IList<User>> GetAllAsync()
        => await this._ctx.Users
                .Include(x => x.FavoritMusics)
                .ThenInclude(x => x.Music)
                .ThenInclude(x => x.Album).ToListAsync();

        public async Task UpdateAsync(User user)
        {
            this._ctx.Users.Update(user);
            await this._ctx.SaveChangesAsync();
        }

        public async Task<User> GetUserAsync(Guid id)
        => await this._ctx.Users
            .Include(x=>x.FavoritMusics)
            .ThenInclude(x => x.Music)
            .ThenInclude(x => x.Album)
            .Where(x => x.Id == id).FirstOrDefaultAsync();

        public async Task RemoveAsync(User user)
        {
            this._ctx.Users.Remove(user);
            await this._ctx.SaveChangesAsync();

        }
    }
}
