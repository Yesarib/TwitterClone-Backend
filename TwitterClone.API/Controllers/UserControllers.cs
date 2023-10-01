using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        private readonly IService<User> _service;

        public UserControllers(IMapper mapper, IService<User> service)
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

    }
}
