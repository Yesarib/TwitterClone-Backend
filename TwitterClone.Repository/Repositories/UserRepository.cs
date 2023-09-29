using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitterClone.Core.Models;
using TwitterClone.Core.Repositories;

namespace TwitterClone.Repository.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            var user = await _appDbContext.Users.FirstOrDefaultAsync(x => x.Email == email);
            return user;
        }

        public async Task<User> GetUserByFirstNamelAsync(string firstName)
        {
            var user = await _appDbContext.Users.FirstOrDefaultAsync(x => x.FirstName == firstName);
            return user;
        }
    }
}
