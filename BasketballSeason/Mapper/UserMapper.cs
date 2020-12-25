using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BasketballSeason.Models;
using BasketballSeason.Models.DTOs;
using BasketballSeason.Models.DTOs.UserDTOs;

namespace BasketballSeason.Mapper
{
    public static class UserMapper
    {
        public static User ToUser(this LoginUserRequestDTO request)
        {
            return new User
            {
                Email = request.Email,
                Password = request.Password
            };
        }

        public static User ToUser(this CreateUserRequestDTO request)
        {
            return new User
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Username = request.Username,
                Email = request.Email,
                Password = request.Password
            };
        }

    }
}
