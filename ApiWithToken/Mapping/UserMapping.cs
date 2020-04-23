using ApiWithToken.Domain;
using ApiWithToken.Resources;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiWithToken.Mapping
{
    public class UserMapping:Profile
    {
        public UserMapping()
        {
            CreateMap<UserResource, User>();
            CreateMap<User, UserResource>();
        }
    }
}
