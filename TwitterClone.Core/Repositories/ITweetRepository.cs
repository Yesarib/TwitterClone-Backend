using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitterClone.Core.Models;

namespace TwitterClone.Core.Repositories
{
    public interface ITweetRepository:IGenericRepository<Tweet>
    {
        Task<List<Tweet>> GetTweetByUserId(int userId);
        Task<List<Tweet>> GetTweetByHashTags(string[] hashTags);
    }
}
