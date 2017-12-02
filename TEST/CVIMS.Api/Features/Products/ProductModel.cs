using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CVIMS.Api.Infrastructure.Models;
using CVIMS.Entity.Lookup;
using CVIMS.Api.Features.CartItems;
using CVIMS.Api.Features.Categories;
using CVIMS.Api.Features.Favorites;

namespace CVIMS.Api.Features.Products
{
    public class ProductModel : BaseEntity, IEntity
    {
        public int Id { get; set; }
        public string ProductTitle { get; set; }
        public string ProductDescription { get; set; }
        public string SKU { get; set; }
        public decimal Cost { get; set; }
        public decimal RetailPrice { get; set; }
        public decimal? SalePrice { get; set; }
        public decimal Sale { get; set; } = 0;
        public int QuantityAvailable { get; set; }
        public int QuantityInStock { get; set; }
        public string Attribute { get; set; }
        public int CategoryId { get; set; }
        public int DepartmentTypeId { get; set; }
        public int SizeId { get; set; }
        public bool IsActive { get; set; }
        public bool IsTaxable { get; set; }
        public bool SchoolStore { get; set; }
        public bool StaffStore { get; set; }
        public string UPC { get; set; }
        public string UPC2 { get; set; }
        public string VendorName { get; set; }
        public string WarehouseLocation { get; set; }
        public string WebKeywords { get; set; }
        public string AdditionalInfo { get; set; }

        public CategoryModel Category { get; set; }
        public ILookup DepartmentType { get; set; }
        public ILookup Size { get; set; }
        // public ICollection<CartItemModel> CartItems { get; set; }
        public ICollection<FavoriteModel> Favorites { get; set; }
        public ICollection<ProductImageModel> ProductImage { get; set; }
        public ICollection<ProductLookupValueModel> LookupValues { get; set; }
    }

    public class ProductsQueryModel : QueryModel<ProductModel>
    {
        public int CategoryId { get; set; } = 0;
    }
}
