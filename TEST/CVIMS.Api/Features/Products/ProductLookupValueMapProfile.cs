using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CVIMS.Api.Features.Products;
using CVIMS.Entity.Entities;
using AutoMapper;

namespace CVIMS.Api.Infrastructure.Mapper
{
    public class ProductLookupValueMapProfile : Profile
    {
        public ProductLookupValueMapProfile()
        {
            CreateMap<ProductLookupValue_xref, ProductLookupValueModel>();

            CreateMap<ProductLookupValueModel, ProductLookupValue_xref>();
        }
    }
}
