using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BootCamp.ViewModel.Request
{
    public class AlbumRequest
    {
        [Required]
        public String Name { get; set; }
        [Required]
        public String Band { get; set; }
        [Required]
        public String Description { get; set; }
        [Required]
        public String Backdrop { get; set; }
        [Required]
        public List<MusicRequest> Musics { get; set; }

    }
}
