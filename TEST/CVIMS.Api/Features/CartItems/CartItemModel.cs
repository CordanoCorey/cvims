using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CVIMS.Api.Infrastructure.Models;
using CVIMS.Api.Features.Orders;
using CVIMS.Api.Features.Products;

namespace CVIMS.Api.Features.CartItems
{
    public class CartItemModel : BaseEntity
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public int? OrderId { get; set; }

        public ProductModel Product { get; set; }
        public OrderModel Order { get; set; }
    }
}
