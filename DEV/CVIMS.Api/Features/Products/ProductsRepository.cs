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
    public interface IProductsRepository : IBaseRepository<Product, ProductModel>
    {
        IEnumerable<ProductModel> AllSchoolStoreProducts();
        IEnumerable<ProductModel> AllStaffStoreProducts();
        IEnumerable<ProductModel> FindByCategory(int categoryId);
    }
    public class ProductsRepository : BaseRepository<Product, ProductModel>, IProductsRepository
    {
        public ProductsRepository(CVIMSContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public IEnumerable<ProductModel> AllSchoolStoreProducts()
        {
            return FindBy(x => x.SchoolStore == true);
        }

        public IEnumerable<ProductModel> AllStaffStoreProducts()
        {
            return FindBy(x => x.StaffStore == true);
        }

        public IEnumerable<ProductModel> FindByCategory(int categoryId)
        {
            return FindBy(x => x.CategoryId == categoryId);
        }
    }
}
