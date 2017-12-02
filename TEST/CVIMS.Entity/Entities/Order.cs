using CVIMS.Entity.Auth;
using CVIMS.Entity.Lookup;
using System;
using System.Collections.Generic;
using System.Text;

namespace CVIMS.Entity.Entities
{
    public partial class Order
    {
        public Order()
        {
            CartItems = new HashSet<CartItem>();
            OrderStatusChanges = new HashSet<OrderStatus_xref>();
        }

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
        public string CreatedById { get; set; }
        public DateTime CreatedDate { get; set; }
        public string LastModifiedById { get; set; }
        public DateTime LastModifiedDate { get; set; }

        public virtual ApplicationUser User { get; set; }
        public virtual ApplicationUser CreatedBy { get; set; }
        public virtual ApplicationUser LastModifiedBy { get; set; }
        public virtual ApplicationUser DeniedBy { get; set; }
        public virtual ApplicationUser PickedBy { get; set; }
        public virtual ICollection<CartItem> CartItems { get; set; }
        public virtual OrderStatus_lkp OrderStatus { get; set; }
        public virtual ICollection<OrderStatus_xref> OrderStatusChanges { get; set; }
    }
}
