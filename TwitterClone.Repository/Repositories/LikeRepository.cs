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
    public class LikeRepository : GenericRepository<Like>, ILikeRepository
    {
        public LikeRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }

        public async Task<List<Tweet>> GetLikedTweetsByUserAsync(User user)
        {
            var tweets = await _appDbContext.Likes
                .Where(x => x.LikedBy == user)
                .Select(x => x.LikedTweet)
                .ToListAsync();

            return tweets;
        }
    }
}
