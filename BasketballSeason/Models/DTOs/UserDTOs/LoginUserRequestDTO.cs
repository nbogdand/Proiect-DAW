using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketballSeason.Models.DTOs.UserDTOs
{
    public class LoginUserRequestDTO
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
