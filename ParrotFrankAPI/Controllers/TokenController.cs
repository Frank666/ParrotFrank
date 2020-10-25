using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ParrotFrankEntities.parrot_frank;

namespace ParrotFrankAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        public IConfiguration _configuration;
        private readonly parrot_frankContext _context;
        public TokenController(IConfiguration config, parrot_frankContext context)
        {
            _configuration = config;
            _context = context;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(Users requestUser)
        {
            if (requestUser != null && requestUser.Nick != null && requestUser.Secret != null)
            {
                var user = await GetUser(requestUser.Nick, requestUser.Secret);

                if (user != null)
                {
                    var claims = new[] {
                    new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                    new Claim("Id", user.UserId.ToString()),
                    new Claim("FirstName", user.Name),
                    new Claim("LastName", user.LastName),
                    new Claim("Nick", user.Nick),
                   };
;
                    var tokenHelper = new Helpers.TokenService();
                    var accessToken = tokenHelper.GenerateAccessToken(claims);
                    var refreshToken = tokenHelper.GenerateRefreshToken();

                    user.Token = accessToken;
                    user.RefreshToken = refreshToken;
                    user.RefreshTime = DateTime.Now.AddMinutes(25);
                    _context.SaveChanges();

                    return Ok(new
                    {
                        Token = accessToken,
                        RefreshToken =  refreshToken
                    }
                    );
                }
                else
                {
                    return BadRequest("Invalid credentials");
                }
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("refresh")]
        public async Task<IActionResult> Refresh(Users requestUser)
        {
            var helper = new Helpers.TokenService();
            if (requestUser is null)
            {
                return BadRequest("Invalid client request");
            }
            string accessToken = requestUser.Token;
            string refreshToken = requestUser.RefreshToken;
            var principal = helper.GetPrincipalFromExpiredToken(accessToken);

            var user = await _context.Users.SingleOrDefaultAsync(u => u.Nick == requestUser.Nick);
            if (user == null || user.RefreshToken != refreshToken || user.RefreshTime <= DateTime.Now)
            {
                return BadRequest("Invalid client request");
            }

            var newAccessToken = helper.GenerateAccessToken(principal.Claims);
            var newRefreshToken = helper.GenerateRefreshToken();
            user.RefreshToken = newRefreshToken;
            _context.SaveChanges();
            return new ObjectResult(new
            {
                accessToken = newAccessToken,
                refreshToken = newRefreshToken
            });
        }

        private async Task<Users> GetUser(string nick, string secret)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Nick == nick && u.Secret == secret);
        }
    }
}
