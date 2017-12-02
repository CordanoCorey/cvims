using System;
using System.Collections.Generic;
using System.Text;

namespace CVIMS.Entity.Lookup
{
    public partial class ShippingOptions_lkp : ILookup
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; } = true;
        public int Sort { get; set; } = 0;
        public string Label { get; set; }
    }
}
