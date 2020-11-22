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
            => await this._ctx.Albums.Include(x=>x.Musics).ToListAsync();

        public async Task<Album> GetAlbumByIdAsync(Guid id)
            => await this._ctx.Albums.Include(x=> x.Musics).Where(x => x.Id == id).FirstOrDefaultAsync();

        public async  Task DeleteAsync(Album model)
        {
            this._ctx.Remove(model);
            await this._ctx.SaveChangesAsync();
        }

        public async Task CreateAsync(Album album)
        {
            await this._ctx.Albums.AddAsync(album);
            await this._ctx.SaveChangesAsync();
        }

        public async Task<Music> GetMusicAsync(Guid musicId) 
        => await this._ctx.Musics.Where(x => x.Id == musicId).FirstOrDefaultAsync();

        
    }
}
