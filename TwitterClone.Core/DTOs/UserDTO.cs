using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitterClone.Core.Models;

namespace TwitterClone.Core.DTOs
{
    public class UserDTO:BaseDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public byte[] ProfileImage { get; set; }
        public int FollowerCount { get; set; }
        public int FollowingCount { get; set; }
        public string Bio { get; set; }
    }
}
