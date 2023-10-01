using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitterClone.Core.DTOs;
using TwitterClone.Core.Models;

namespace TwitterClone.Service.Mapping
{
    public class MapProfile:Profile
    {
        public MapProfile()
        {
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<Tweet, TweetDTO>().ReverseMap();
        }
    }
}
