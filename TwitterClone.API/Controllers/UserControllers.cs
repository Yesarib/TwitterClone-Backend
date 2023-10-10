using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TwitterClone.Core.DTOs;
using TwitterClone.Core.Models;
using TwitterClone.Core.Services;

namespace TwitterClone.API.Controllers
{
    [Route("api/User")]
    [ApiController]
    public class UserControllers : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUserService _service;

        public UserControllers(IMapper mapper, IUserService service)
        {
            _mapper = mapper;
            _service = service;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var users = await _service.GetAll();
            var usersDtos = _mapper.Map<List<User>>(users.ToList());
            return Ok(CustomResponseDTO<List<User>>.Success(200, usersDtos));
        }

        [HttpGet("GetUserById")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _service.GetByIdAsync(id);
            return Ok(CustomResponseDTO<User>.Success(200, user));
        }

        [HttpGet("userinfo")]
        [Authorize]
        public async Task<IActionResult> GetUserInfoAsync()
        {
            try
            {
                var token = HttpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

                if (string.IsNullOrEmpty(token)) { return Unauthorized("Token not provided or invalid."); }

                var userId = _service.GetUserInfo(token);

                return userId == null ? Unauthorized("UserId claim not found in the token.") : Ok($"Current user's ID: {userId}");
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
