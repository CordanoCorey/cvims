using CVIMS.Api.Features.Products;
using CVIMS.Api.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CVIMS.Api.Infrastructure.Services
{
    public interface ISearchService
    {
        ISearchResults<object> Search(IQueryModel model);
        ISearchResults<object> SearchProducts(IQueryModel model);
    }

    public class SearchService : ISearchService
    {
        private readonly IProductsService _products;

        public SearchService(IProductsService products)
        {
            _products = products;
        }

        public ISearchResults<object> Search(IQueryModel model)
        {
            return SearchProducts(model);
        }

        public ISearchResults<object> SearchProducts(IQueryModel model)
        {
            var query = (ProductsQueryModel)ProductsQueryModel.Build(model);
            var results = _products.GetProducts(query);
            return SearchResults<ProductModel>.BuildGeneric(results);

        }
    }
}
