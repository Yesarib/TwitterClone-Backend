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
    public class CommentRepository : GenericRepository<Comment>, ICommentRepository
    {
        public CommentRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }

        public async Task<List<Tweet>> GetCommentsTweetsByUserAsync(User user)
        {
            var tweets = await _appDbContext.Comments
                .Where(x => x.CommentedBy == user)
                .Select(x => x.CommentedOnTweet)
                .ToListAsync();
            return tweets;
        }
    }
}
