using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitterClone.Core.Models;

namespace TwitterClone.Core.Repositories
{
    public interface ILikeRepository:IGenericRepository<Like> 
    {
        Task<List<Tweet>> GetLikedTweetsByUserAsync(User user);
    }
}
