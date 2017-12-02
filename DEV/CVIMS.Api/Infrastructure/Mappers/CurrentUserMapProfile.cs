using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CVIMS.Api.Infrastructure.Models;
using CVIMS.Entity.Entities;
using CVIMS.Entity.Auth;
using AutoMapper;

namespace CVIMS.Api.Infrastructure.Mapper
{
    public class CurrentUserMapProfile : Profile
    {
        public CurrentUserMapProfile()
        {
            CreateMap<ApplicationUser, CurrentUserModel>()
                .IncludeBase<ApplicationUser, UserModel>();

            CreateMap<CurrentUserModel, ApplicationUser>()
                .IncludeBase<UserModel, ApplicationUser>();
        }
    }
}
