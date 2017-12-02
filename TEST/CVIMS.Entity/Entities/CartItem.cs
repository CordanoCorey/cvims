using CVIMS.Entity.Auth;
using System;
using System.Collections.Generic;
using System.Text;

namespace CVIMS.Entity.Entities
{
    public partial class CartItem
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public int? OrderId { get; set; }
        
        public virtual Product Product { get; set; }
        public virtual Order Order { get; set; }
    }
}
