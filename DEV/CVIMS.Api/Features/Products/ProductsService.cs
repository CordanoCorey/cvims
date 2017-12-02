using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CVIMS.Api.Infrastructure.Models;

namespace CVIMS.Api.Features.Products
{
    public interface IProductsService
    {
        SearchResults<ProductModel> GetProducts(ProductsQueryModel query);
        IEnumerable<ProductModel> GetProductsForCategory(int categoryId);
        IEnumerable<ProductModel> GetSchoolStoreProducts();
        IEnumerable<ProductModel> GetStaffStoreProducts();
        ProductModel GetProduct(int id);
        ProductModel AddProduct(ProductModel model);
        ProductModel UpdateProduct(ProductModel model);
        void DeleteProduct(int id);
    }

    public class ProductsService : IProductsService
    {
        private readonly IProductsRepository _repo;

        public ProductsService(IProductsRepository repo)
        {
            _repo = repo;
        }

        public ProductModel AddProduct(ProductModel model)
        {
            return _repo.Insert(model);
        }

        public void DeleteProduct(int id)
        {
            _repo.Delete(id);
        }

        public ProductModel GetProduct(int id)
        {
            return _repo.FindByKey(id);
        }

        public SearchResults<ProductModel> GetProducts(ProductsQueryModel query)
        {
            var products = query.CategoryId == 0 ? _repo.All().ToList() : GetProductsForCategory(query.CategoryId).ToList();
            query.Predicate = query.Term == null ? query.Predicate
                : x => x.ProductTitle.ToLower().Contains(query.Term.ToLower())
                    || x.ProductDescription.ToLower().Contains(query.Term.ToLower())
                    || x.SKU.ToLower().Contains(query.Term.ToLower());
            var results = _repo.Query(products, query).ToList();
            var total = _repo.Count();
            return new SearchResults<ProductModel>()
            {
                Results = results,
                Total = total
            };
        }

        public IEnumerable<ProductModel> GetProductsForCategory(int categoryId)
        {
            return _repo.FindByCategory(categoryId);
        }

        public IEnumerable<ProductModel> GetSchoolStoreProducts()
        {
            return _repo.AllSchoolStoreProducts();
        }

        public IEnumerable<ProductModel> GetStaffStoreProducts()
        {
            return _repo.AllStaffStoreProducts();
        }

        public ProductModel UpdateProduct(ProductModel model)
        {
            return _repo.Update(model);
        }
    }
}
