using BootCamp.Model;
using BootCamp.ViewModel.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BootCamp.ViewModel.Profile
{
    public class AlbumProfile: AutoMapper.Profile
    {
        public AlbumProfile()
        {
            CreateMap<MusicRequest, Music>();
            CreateMap<AlbumRequest, Album>();
        }
    }
}
