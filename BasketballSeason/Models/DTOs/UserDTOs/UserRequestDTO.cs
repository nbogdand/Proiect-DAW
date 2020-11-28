﻿using System;
using System.ComponentModel.DataAnnotations;

namespace BasketballSeason.Models.DTOs.UserDTOs
{
    public class UserRequestDTO
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
