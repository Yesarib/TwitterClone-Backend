using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitterClone.Core.Models
{
    public class User: BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public byte[] ProfileImage { get; set; }
        public int FollowerCount { get; set; }
        public int FollowingCount { get; set; }
        public string Bio { get; set; }
        public List<Tweet> Tweets { get; set; }

    }
}
