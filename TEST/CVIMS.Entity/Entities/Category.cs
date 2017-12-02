using CVIMS.Entity.Lookup;
using System;
using System.Collections.Generic;
using System.Text;

namespace CVIMS.Entity.Entities
{
    public partial class Category
    {
        public int Id { get; set; }
        public string Label { get; set; }
        public string Description { get; set; }
        public int LocationId { get; set; }

        public Location_lkp Location { get; set; }
    }
}
