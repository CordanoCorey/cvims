using CVIMS.Entity.Lookup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CVIMS.Api.Infrastructure.Lookup
{
    public class LookupModel
    {
        public string Name { get; set; }
        public IEnumerable<ILookup> Values { get; set; }
    }
}
