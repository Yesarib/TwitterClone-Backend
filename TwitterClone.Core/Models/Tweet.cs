using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitterClone.Core.Models
{
    public class Tweet:BaseEntity
    {
        public string Text { get; set; }
        public int UserId { get; set; }
        public int LikeCount { get; set; }
        public int RetweetCount { get; set; }
        public List<byte[]> Media { get; set; }
        public List<string> Hashtags { get; set; }

    }
}
