using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BootCamp.Model
{
    public class User
    {
        public Guid Id { get; set; }
        public String Name { get; set; }
        public String Email { get; set; }
        public String Password { get; set; }
        public String Photo { get; set; }

        public IList<UserFavoritMusic> FavoritMusic {get; set;}

        public void AddFavoritMusic(Music music)
        {
            this.FavoritMusic.Add(new UserFavoritMusic()
            {
                Music = music,
                MusicId = music.Id,
                User = this,
                UserId = this.Id
            });
        }

        public void RemoveFavoriteMusic(Music music)
        {
            var favMusic = this.FavoritMusic
                               .Where(x => x.MusicId == music.Id)
                               .FirstOrDefault();
            if (favMusic == null)
                throw new Exception("Música não localizada na lista de favoritos");
            this.FavoritMusic.Remove(favMusic);        }

    }
}
