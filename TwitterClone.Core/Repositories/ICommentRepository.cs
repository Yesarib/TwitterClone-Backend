using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitterClone.Core.Models;

namespace TwitterClone.Core.Repositories
{
    public interface ICommentRepository: IGenericRepository<Comment>
    {
        Task<List<Tweet>> GetCommentsTweetsByUserAsync(User user);
    }
}
