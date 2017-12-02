using System;
using System.Collections.Generic;
using System.Text;

namespace CVIMS.Entity.Lookup
{
    public partial class Lookup
    {
        public Lookup()
        {
            LookupValues = new HashSet<LookupValue>();
        }

        public int Id { get; set; }
        public string Label { get; set; }
        public string Description { get; set; }

        public virtual ICollection<LookupValue> LookupValues { get; set; }
    }
}
