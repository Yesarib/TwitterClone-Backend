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
    public class TweetRepository : GenericRepository<Tweet>, ITweetRepository
    {
        public TweetRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }

        public async Task<List<Tweet>> GetTweetByHashTags(string[] hashTags)
        {
            var tweets = await _appDbContext.Tweets
                .Where(tweet => hashTags.All(tag => tweet.Hashtags.Contains(tag)))
                .ToListAsync();

            return tweets;
        }

        public async Task<List<Tweet>> GetTweetByUserId(int userId)
        {
            var tweets = await _appDbContext.Tweets.Where(x=> x.UserId == userId).ToListAsync();
            return tweets;
        }
    }
}
