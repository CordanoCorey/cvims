using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CVIMS.Api.Infrastructure.Models;
using CVIMS.Entity.Lookup;

namespace CVIMS.Api.Features.Products
{
    public class ProductLookupValueModel : BaseEntity
    {
        public int ProductId { get; set; }
        public int LookupValueId { get; set; }

        public ProductModel Product { get; set; }
        public LookupValue LookupValue { get; set; }
    }
}
