using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CVIMS.Api.Features.Products;
using CVIMS.Entity.Entities;
using AutoMapper;

namespace CVIMS.Api.Infrastructure.Mapper
{
    public class ProductImageMapProfile : Profile
    {
        public ProductImageMapProfile()
        {
            CreateMap<ProductImage, ProductImageModel>();

            CreateMap<ProductImageModel, ProductImage>();
        }
    }
}
