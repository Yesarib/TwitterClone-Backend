using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitterClone.Core.Models
{
    public class Notification:BaseEntity
    {
        public User Receiver { get; set; }
        public User Sender { get; set; }
        public NotificationType Type { get; set; }
        public Tweet RelatedTweet { get; set; }
        public DateTime CreationDate { get; set; }
    }
    public enum NotificationType
    {
        NewFollower,
        NewLike,
        NewRetweet,
        NewComment
    }
}
