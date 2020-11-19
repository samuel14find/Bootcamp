using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BootCamp.Model
{
    public class Album
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public String Description { get; set; }
        public String Backdrop { get; set; }
        public String Band { get; set; }
        public IList<Music> Musics { get; set; }

    }
}
