using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CVIMS.Api.Infrastructure.Models;
using CVIMS.Api.Features.Products;

namespace CVIMS.Api.Features.Favorites
{
    public class FavoriteModel : BaseEntity
    {
        public string UserId { get; set; }
        public int ProductId { get; set; }
        
        public virtual ProductModel Product { get; set; }
    }
}
