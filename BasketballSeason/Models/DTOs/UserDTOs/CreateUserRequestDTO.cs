using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BasketballSeason.Models.DTOs.UserDTOs
{
    public class CreateUserRequestDTO
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        [StringLength(16, MinimumLength = 4, ErrorMessage = "Password's lenght must be between 4 and 16 characters")]
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
