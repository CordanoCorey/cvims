using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CVIMS.Api.Infrastructure.Models;
using CVIMS.Api.Features.CartItems;
using CVIMS.Entity.Lookup;

namespace CVIMS.Api.Features.Orders
{
    public class OrderModel : BaseEntity
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public int OrderNumber { get; set; }
        public DateTime? OrderProcessDate { get; set; }
        public int OrderStatusId { get; set; }
        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Location { get; set; }
        public int? PhoneExtension { get; set; }
        public string Comments { get; set; }
        public string InternalComments { get; set; }
        public string DeniedById { get; set; }
        public string DeniedReason { get; set; }
        public string PickedById { get; set; }
        public DateTime PickedDate { get; set; }

        public UserModel DeniedBy { get; set; }
        public UserModel PickedBy { get; set; }
        public ICollection<CartItemModel> CartItems { get; set; }
        public ILookup OrderStatus { get; set; }
        public ICollection<OrderStatusModel> OrderStatusChanges { get; set; }
    }
}
