using AutoMapper;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitterClone.Core.Models;
using TwitterClone.Core.Repositories;
using TwitterClone.Core.Services;
using TwitterClone.Core.UnitOfWorks;

namespace TwitterClone.Service.Services
{
    public class UserService: Service<User>, IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UserService(IGenericRepository<User> repository, IUnitOfWorks unitOfWorks, IMapper mapper, IUserRepository userRepository) : base(repository, unitOfWorks)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public string GetUserInfo(string token)
        {
            var handler = new JwtSecurityTokenHandler();
            var tokenSliced = handler.ReadToken(token) as JwtSecurityToken;

            var userIdClaim = tokenSliced.Claims.FirstOrDefault(claim => claim.Type == "UserId");

            return userIdClaim == null ? throw new Exception("UserId claim not found in the token.") : userIdClaim.Value;
        }
    }
}
