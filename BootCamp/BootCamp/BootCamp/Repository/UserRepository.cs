using BootCamp.Model;
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
    }
}
