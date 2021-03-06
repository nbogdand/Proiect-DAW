﻿using System;
using System.Text.Json.Serialization;
using BasketballSeason.Models.Base;

namespace BasketballSeason.Models
{
    public class User : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string FcmToken { get; set; }
        [JsonIgnore]
        public string Password { get; set; }
    }
}
