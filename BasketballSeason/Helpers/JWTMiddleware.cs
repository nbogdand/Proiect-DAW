using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BasketballSeason.Services.UserS;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace BasketballSeason.Helpers
{
    public class JWTMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly AppSettings _appSettings;

        public JWTMiddleware(IOptions<AppSettings> appSettings, RequestDelegate next)
        {
            _appSettings = appSettings.Value;
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext, IUserService userService)
        {
            var token = httpContext.Request.Headers["Autorization"].FirstOrDefault()?.Split("").Last();
            if (token != null)
            {
                AttachUserToHttpContext(httpContext, userService, token);
            }

            await _next(httpContext);
        }

        private void AttachUserToHttpContext(HttpContext httpContext, IUserService userService, string token)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validateToken);


                var jwtToken = (JwtSecurityToken)validateToken;
                var userId = new Guid(jwtToken.Claims.First(x => x.Type == "id").Value);

                // attach user to the httpContext
                httpContext.Items["User"] = userService.GetById(userId);
            }
            catch
            {

            }
        }
    }
}
