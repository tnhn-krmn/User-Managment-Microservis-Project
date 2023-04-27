using Authentication.Microservice.Dto;
using Authentication.Microservice.Service.Abstract;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Authentication.Microservice.Service.Concrete
{
    public class AuthenticationManager : IAuthenticationService
    {
        IConfiguration _configuration;

        public AuthenticationManager(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<string> UserAuthentication(LoginDto user)
        {
            using var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7024");
      

            HttpContent body = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");
            var response = client.PostAsync("/api/Users/GetUserAuthentication", body).Result;

            if(response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                if(data != null)
                {
                    var token = TokenCreate(user);
                    return token;
                }
            }
            return null;
        }

        private string TokenCreate(LoginDto login)
        {

            var signinKey = _configuration.GetSection("JwtConfig:Security").Value;
            var issuer = _configuration.GetSection("JwtConfig:Issuer").Value;
            var audience = _configuration.GetSection("JwtConfig:Audience").Value;

            var claims = new[] {
            new Claim(ClaimTypes.Email,login.Email),
            };
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(signinKey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var jwtSecurityToken = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: credentials
                );
            var token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
            return token;
        }
    }
}
