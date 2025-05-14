using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using School.Api.DAL;
using School.Api.DMOs;
using School.Api.DTOs;
using School.Api.Interfaces;

namespace School.Api.BLL
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration _configuration;
        private readonly AppDbContext _dbcontext;

        public AuthService(IConfiguration configuration, AppDbContext dbcontext)
        {
            _configuration = configuration;
            _dbcontext = dbcontext;
        }

        public async Task<UserDto?> RegisterAsync(User request)
        {
            if (await _dbcontext.Users.AnyAsync(u => u.Name == request.Name))
                return null;
            var user = new User();
            user.Name = request.Name;
            user.Email = request.Email;
            user.Role = request.Role;
            user.PasswordHash = new PasswordHasher<User>()
                .HashPassword(user, request.PasswordHash);
            await _dbcontext.Users.AddAsync(user);
            await _dbcontext.SaveChangesAsync();

            return new UserDto { FullName = request.Name, Email = request.Email };
        }

        public async Task<string?> LoginAsync(RequestDto request)
        {
            User? user = await _dbcontext.Users.FirstOrDefaultAsync(u => u.Name == request.name);
            if (user == null)
                return null;
            if (new PasswordHasher<User>().VerifyHashedPassword(user, user.PasswordHash, request.password) ==
                PasswordVerificationResult.Failed)
            {
                return null;
            }
            string token = CreateToken(user);
            return token;
        }

        private string CreateToken(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.Role, user.Role),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
            };
            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_configuration.GetValue<string>("Appsettings:Token")!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512);
            var tokenDesriptor = new JwtSecurityToken(
                issuer: _configuration.GetValue<string>("Appsettings:Issuer"),
                audience: _configuration.GetValue<string>("Appsettings:Audience"),
                claims: claims,
                expires: DateTime.UtcNow.AddDays(1),
                signingCredentials: creds
                );
            return new JwtSecurityTokenHandler().WriteToken(tokenDesriptor);

        }
    }
}
