using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ParrotFrankData.Products;
using ParrotFrankData.Tokens;
using ParrotFrankEntities.parrot_frank;

namespace ParrotFrankAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : MainController<Users, UsersRepository>
    {
        private readonly UsersRepository _repository;
        private readonly IConfiguration _configuration;
        public TokenController(IConfiguration config, UsersRepository repository) : base(repository)
        {
            _repository = repository;
            _configuration = config;
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
                    new Claim("issuer", _configuration["Jwt:Subject"]),
                    new Claim("audience", _configuration["Jwt:Subject"]),
                    new Claim("Id", user.Id.ToString()),
                    new Claim("FirstName", user.Name),
                    new Claim("LastName", user.LastName),
                    new Claim("Nick", user.Nick),
                   };
                    ;
                    var tokenHelper = new Helpers.TokenService();
                    tokenHelper.Key = _configuration["Jwt:Key"].ToString();
                    var accessToken = tokenHelper.GenerateAccessToken(claims);
                    var refreshToken = tokenHelper.GenerateRefreshToken();

                    user.Token = accessToken;
                    user.RefreshToken = refreshToken;
                    user.RefreshTime = DateTime.Now.AddMinutes(25);
                    await _repository.Update(user);

                    return Ok(new
                    {
                        Token = accessToken,
                        RefreshToken = refreshToken,
                        RefreshTime = user.RefreshTime
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

            var user = await _repository.GetByNick(requestUser.Nick);
            if (user == null || user.RefreshToken != refreshToken || user.RefreshTime <= DateTime.Now)
            {
                return BadRequest("Invalid client request");
            }

            var newAccessToken = helper.GenerateAccessToken(principal.Claims);
            var newRefreshToken = helper.GenerateRefreshToken();
            user.RefreshToken = newRefreshToken;
            await _repository.Update(user);
            return new ObjectResult(new
            {
                accessToken = newAccessToken,
                refreshToken = newRefreshToken
            });
        }

        private async Task<Users> GetUser(string nick, string secret)
        {            
            return await _repository.GetUser(nick, secret);
        }
    }
}
