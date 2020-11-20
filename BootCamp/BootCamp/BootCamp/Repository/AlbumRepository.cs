using BootCamp.Model;
using BootCamp.Repository.Mapping;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BootCamp.Repository
{
    public class AlbumRepository
    {
        private MusicContext _ctx { get; init; }
        public AlbumRepository(MusicContext context)
        {
            this._ctx = context;
        }

        public async Task<IList<Album>> GetAllAsync()
            => await this._ctx.Albums.ToListAsync();

        public async Task<Album> GetAlbumByIdAsync(Guid id)
            => await this._ctx.Albums.Where(x => x.Id == id).FirstOrDefaultAsync();

        public async  Task DeleteAsync(Album model)
        {
            this._ctx.Remove(model);
            await this._ctx.SaveChangesAsync();
        }
    }
}
