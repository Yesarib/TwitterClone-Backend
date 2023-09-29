using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitterClone.Core.Models;

namespace TwitterClone.Core.Repositories
{
    public interface IUserRepository:IGenericRepository<User>
    {
        Task<User> GetUserByEmailAsync(string email);
        Task<User> GetUserByFirstNamelAsync(string firstName);
    }
}
