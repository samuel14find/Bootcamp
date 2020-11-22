using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BootCamp.ViewModel.Request
{
    public class SignInRequest
    {
        /// Como vamos lidar com o usuário entrando no sistema basicamente vamos ter 
        /// os campos email e password
        [Required]
        [EmailAddress]
        public String Email { get; set; }
        [Required]
        public String Password { get; set; }


    }
}
