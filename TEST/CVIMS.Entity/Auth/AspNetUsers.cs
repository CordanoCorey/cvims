using CVIMS.Entity.Entities;
using CVIMS.Entity.Lookup;
using System;
using System.Collections.Generic;

namespace CVIMS.Entity.Auth
{
    public partial class ApplicationUser
    {
        public ApplicationUser()
        {
            CartItems = new HashSet<CartItem>();
            Favorites = new HashSet<Favorite>();
            AttachmentCreatedBy = new HashSet<Attachment>();
            AttachmentLastModifiedBy = new HashSet<Attachment>();
            EmailCreatedBy = new HashSet<Email>();
            Orders = new HashSet<Order>();
            OrderStatusChanges = new HashSet<OrderStatus_xref>();
            Products = new HashSet<Product>();
            ProductImage = new HashSet<ProductImage>();
            OrderCreatedBy = new HashSet<Order>();
            OrderDeniedBy = new HashSet<Order>();
            OrderPickedBy = new HashSet<Order>();
            OrderLastModifiedBy = new HashSet<Order>();
            OrderStatusCreatedBy = new HashSet<OrderStatus_xref>();
            ProductCreatedBy = new HashSet<Product>();
            ProductLastModifiedBy = new HashSet<Product>();
            ProductImageCreatedBy = new HashSet<ProductImage>();
        }

        public virtual ICollection<CartItem> CartItems { get; set; }
        public virtual ICollection<Favorite> Favorites { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<OrderStatus_xref> OrderStatusChanges { get; set; }
        public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<ProductImage> ProductImage { get; set; }
        public virtual ICollection<Attachment> AttachmentCreatedBy { get; set; }
        public virtual ICollection<Attachment> AttachmentLastModifiedBy { get; set; }
        public virtual ICollection<Email> EmailCreatedBy { get; set; }
        public virtual ICollection<Order> OrderCreatedBy { get; set; }
        public virtual ICollection<Order> OrderDeniedBy { get; set; }
        public virtual ICollection<Order> OrderPickedBy { get; set; }
        public virtual ICollection<Order> OrderLastModifiedBy { get; set; }
        public virtual ICollection<OrderStatus_xref> OrderStatusCreatedBy { get; set; }
        public virtual ICollection<Product> ProductCreatedBy { get; set; }
        public virtual ICollection<Product> ProductLastModifiedBy { get; set; }
        public virtual ICollection<ProductImage> ProductImageCreatedBy { get; set; }

        // public virtual ICollection<AspNetUserRoles> UserRoles { get; set; }
    }
}
