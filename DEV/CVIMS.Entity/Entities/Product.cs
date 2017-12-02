using CVIMS.Entity.Auth;
using CVIMS.Entity.Lookup;
using System;
using System.Collections.Generic;
using System.Text;

namespace CVIMS.Entity.Entities
{
    public partial class Product
    {
        public Product()
        {
            CartItems = new HashSet<CartItem>();
            Favorites = new HashSet<Favorite>();
            ProductImage = new HashSet<ProductImage>();
        }

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
        public string CreatedById { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public string LastModifiedById { get; set; }

        public virtual ApplicationUser CreatedBy { get; set; }
        public virtual ApplicationUser LastModifiedBy { get; set; }
        public virtual Category Category { get; set; }
        public virtual DepartmentType_lkp DepartmentType { get; set; }
        public virtual Size_lkp Size { get; set; }
        public virtual ICollection<CartItem> CartItems { get; set; }
        public virtual ICollection<Favorite> Favorites { get; set; }
        public virtual ICollection<ProductImage> ProductImage { get; set; }
        public virtual ICollection<ProductLookupValue_xref> LookupValues { get; set; }
    }
}
