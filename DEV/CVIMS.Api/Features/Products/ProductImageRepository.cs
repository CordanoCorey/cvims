using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CVIMS.Api.Infrastructure.Repositories;
using CVIMS.Entity.Context;
using CVIMS.Entity.Entities;

namespace CVIMS.Api.Features.Products
{
    public interface IProductImageRepository : IBaseRepository<ProductImage, ProductImageModel>
    {
    }
    public class ProductImageRepository : BaseRepository<ProductImage, ProductImageModel>, IProductImageRepository
    {
        public ProductImageRepository(CVIMSContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
