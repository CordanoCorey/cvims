using CVIMS.Entity.Lookup;
using System;
using System.Collections.Generic;
using System.Text;

namespace CVIMS.Entity.Entities
{
    public partial class ProductLookupValue_xref
    {
        public int ProductId { get; set; }
        public int LookupValueId { get; set; }

        public virtual Product Product { get; set; }
        public virtual LookupValue LookupValue { get; set; }
    }
}
