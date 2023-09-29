using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitterClone.Core.Models;

namespace TwitterClone.Core.Repositories
{
    public interface IFollowRepository:IGenericRepository<Follow>
    {
        Task<List<User>> GetUsersFollowsAsync(User user);
        Task<List<User>> GetUsersFollowerAsync(User user);
    }
}
