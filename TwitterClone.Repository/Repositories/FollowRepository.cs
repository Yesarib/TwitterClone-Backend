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
    public class FollowRepository : GenericRepository<Follow>, IFollowRepository
    {
        public FollowRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }

        public async Task<List<User>> GetUsersFollowerAsync(User user)
        {
            var followerIds = await _appDbContext.Follows
                .Where(follow => follow.FollowingId == user.Id)
                .Select(follow => follow.FollowerId)
                .ToListAsync();

            var followers = await _appDbContext.Users
                .Where(u => followerIds.Contains(u.Id))
                .ToListAsync();

            return followers;
        }

        public async Task<List<User>> GetUsersFollowsAsync(User user)
        {
            var followingIds = await _appDbContext.Follows
                .Where(follow => follow.FollowerId == user.Id)
                .Select(follow => follow.FollowingId)
                .ToListAsync();

            var follows = await _appDbContext.Users
                .Where(u => followingIds.Contains(u.Id))
                .ToListAsync();

            return follows;
        }
    }
}
