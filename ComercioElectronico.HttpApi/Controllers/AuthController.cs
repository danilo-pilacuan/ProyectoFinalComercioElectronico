using ComercioElectronico.Application;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Authentication;
using System.Security.Claims;
using System.Text;

namespace ComercioElectronico.HttpApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase {

        private readonly JwtConfiguration jwtConfiguration;

        private readonly IUserAppService userAppService;

        public AuthController(IOptions<JwtConfiguration> options,IUserAppService userAppService) {
            this.jwtConfiguration = options.Value;
            this.userAppService=userAppService;
        }
        
        [HttpPost("/api/resgistrarUser")]
        [AllowAnonymous]
        
        public async Task<UserDto> registrar([FromForm] UserCreateUpdateDto userCreateUpdateDto)
        {
            return await userAppService.CreateAsync(userCreateUpdateDto);
        }

        [HttpPost("/api/login")]
        [AllowAnonymous]
        public async Task<string> TokenAsync([FromForm] UserCreateUpdateDto userCreateUpdateDto)
        {

            UserDto userDto = await userAppService.GetByUserNameAsync(userCreateUpdateDto.UserName);
            
            if(userDto.Contrasenia==userCreateUpdateDto.Contrasenia)
            {
                var claims = new List<Claim>();


                claims.Add(new Claim(JwtRegisteredClaimNames.Sub, userDto.UserName));
                claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
                claims.Add(new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()));
                claims.Add(new Claim("UserName", userDto.UserName));


                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtConfiguration.Key));
                var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                var tokenDescriptor = new JwtSecurityToken(
                    jwtConfiguration.Issuer,
                    jwtConfiguration.Audience,
                    claims,
                    expires: DateTime.UtcNow.Add(jwtConfiguration.Expires),
                    signingCredentials: signIn);


                var jwt = new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);


                return jwt;
            }
            else
            {
                throw new AuthenticationException("User or Passowrd incorrect!");
            }

            var usuarios = new [] {
                new { Usr= "danilo"},
                new { Usr= "bar"},
                new { Usr= "user"},
            };
            
        }




        
    }

    public class UserInput
    {

        public string? UserName { get; set; }
        public string? Contrasenia { get; set; }
    }
}