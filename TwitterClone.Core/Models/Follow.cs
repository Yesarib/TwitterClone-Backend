using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitterClone.Core.Models
{
    public class Follow:BaseEntity
    {
        public int FollowerId { get; set; }
        public int FollowingId { get; set; }
        public User Follower { get; set; }
        public User Following { get; set; }
    }
}
