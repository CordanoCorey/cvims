using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CVIMS.Api.Infrastructure.Models;
using CVIMS.Entity.Lookup;

namespace CVIMS.Api.Features.Orders
{
    public class OrderStatusModel
    {
        public int OrderId { get; set; }
        public int OrderStatusId { get; set; }
        public string CreatedById { get; set; }
        public DateTime CreatedDate { get; set; }
        
        public virtual OrderModel Order { get; set; }
        public virtual ILookup OrderStatus { get; set; }
    }
}
