using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitterClone.Core.Models
{
    public class Like:BaseEntity
    {
        public User LikedBy { get; set; }
        public Tweet LikedTweet { get; set; }
    }
}
