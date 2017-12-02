using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CVIMS.Api.Features.Favorites;
using CVIMS.Entity.Entities;
using AutoMapper;

namespace CVIMS.Api.Infrastructure.Mapper
{
    public class FavoriteMapProfile : Profile
    {
        public FavoriteMapProfile()
        {
            CreateMap<Favorite, FavoriteModel>();

            CreateMap<FavoriteModel, Favorite>();
        }
    }
}
