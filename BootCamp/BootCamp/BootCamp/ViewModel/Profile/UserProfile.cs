using BootCamp.Model;
using BootCamp.ViewModel.Request;
 using BootCamp.ViewModel.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BootCamp.ViewModel.Profile
{
    public class UserProfile: AutoMapper.Profile
    {
        public UserProfile()
        {
            CreateMap<RegisterRequest, User>();
            CreateMap<User, UserResponse>();
        }
        
    }
}
