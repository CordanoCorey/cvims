using CVIMS.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CVIMS.Entity.Lookup
{
    public partial class LookupValue
    {
        public LookupValue()
        {
            Products = new HashSet<ProductLookupValue_xref>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public int Sort { get; set; }
        public int LookupId { get; set; }

        public virtual ICollection<ProductLookupValue_xref> Products { get; set; }
        public Lookup Lookup { get; set; }
    }
}
