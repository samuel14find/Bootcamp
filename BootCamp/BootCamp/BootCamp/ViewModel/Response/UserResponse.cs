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
    }
}
