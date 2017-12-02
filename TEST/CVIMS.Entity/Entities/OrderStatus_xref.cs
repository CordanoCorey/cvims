using CVIMS.Entity.Auth;
using CVIMS.Entity.Lookup;
using System;
using System.Collections.Generic;
using System.Text;

namespace CVIMS.Entity.Entities
{
    public partial class OrderStatus_xref
    {
        public int OrderId { get; set; }
        public int OrderStatusId { get; set; }
        public string CreatedById { get; set; }
        public DateTime CreatedDate { get; set; }

        public virtual ApplicationUser CreatedBy { get; set; }
        public virtual Order Order { get; set; }
        public virtual OrderStatus_lkp OrderStatus { get; set; }
    }
}
