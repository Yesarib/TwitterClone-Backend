using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitterClone.Core.Models
{
    public class Retweet:BaseEntity
    {
        public User RetweetedBy { get; set; }
        public Tweet RetweetedTweet { get; set; }
    }
}
