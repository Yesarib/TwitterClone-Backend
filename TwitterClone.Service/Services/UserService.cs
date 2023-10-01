using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitterClone.Core.Models;
using TwitterClone.Core.Repositories;
using TwitterClone.Core.Services;
using TwitterClone.Core.UnitOfWorks;

namespace TwitterClone.Service.Services
{
    public class UserService : Service<User>, IUserService
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        public UserService(IGenericRepository<User> repository, IUnitOfWorks unitOfWorks, IMapper mapper, IUserService userService) : base(repository, unitOfWorks)
        {
            _mapper = mapper;
            _userService = userService;
        }

    }
}
