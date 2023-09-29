using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitterClone.Core.Models
{
    public class Comment:BaseEntity
    {
        public string Text { get; set; }
        public User CommentedBy { get; set; }
        public Tweet CommentedOnTweet { get; set; }
    }
}
