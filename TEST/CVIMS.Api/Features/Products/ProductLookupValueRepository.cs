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
    public interface IProductLookupValueRepository : IBaseRepository<ProductLookupValue_xref, ProductLookupValueModel>
    {
    }
    public class ProductLookupValueRepository : BaseRepository<ProductLookupValue_xref, ProductLookupValueModel>, IProductLookupValueRepository
    {
        public ProductLookupValueRepository(CVIMSContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
