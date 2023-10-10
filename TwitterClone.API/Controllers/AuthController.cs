using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using TwitterClone.Core.DTOs;
using TwitterClone.Core.Models;
using TwitterClone.Core.Services;
using TwitterClone.Repository;

namespace TwitterClone.API.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IService<User> _service;
        private readonly AppDbContext _context;
        private readonly IConfiguration _configuration;

       
        public AuthController(IService<User> service, IMapper mapper, AppDbContext context, IConfiguration configuration)
        {
            _service = service;
            _mapper = mapper;
            _context = context;
            _configuration = configuration; 
        }


        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO loginDTO)
        {
            User user = await _context.Users.SingleOrDefaultAsync(u => u.Email == loginDTO.Email);

            if (user == null)
            {
                return NotFound("There is no user with this email address.");
            }

            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(loginDTO.PasswordHash));
                StringBuilder stringBuilder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    stringBuilder.Append(bytes[i].ToString("x2"));
                }
                string hashedPassword = stringBuilder.ToString();

                if (hashedPassword != user.PasswordHash)
                {
                    return Conflict("Password is wrong.");
                }
            }

            string token = CreateToken(user);
            return Ok(token);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] User user)
        {
            if (await _context.Users.AnyAsync(u => u.Email == user.Email))
            {
                return Conflict("This email is already registered.");
            }

            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(user.PasswordHash));
                StringBuilder stringBuilder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    stringBuilder.Append(bytes[i].ToString("x2"));
                }
                string hashedPassword = stringBuilder.ToString();

                user.PasswordHash = hashedPassword;
            }

            var newUser = await _service.AddAsync(_mapper.Map<User>(user));
            return Ok(CustomResponseDTO<User>.Success(200, newUser));
        }

        private string CreateToken(User user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim("UserId", user.Id.ToString())
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value));

            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: cred
                );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
        }
                
    }
}
