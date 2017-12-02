using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CVIMS.Api.Infrastructure.Models;
using CVIMS.Entity.Lookup;

namespace CVIMS.Api.Features.Categories
{
    public class CategoryModel : BaseEntity
    {
        private string _label;
        public int Id { get; set; }
        public string Label
        {
            get
            {
                return _label == null ? Description : _label;
            }
            set
            {
                _label = value;
            }
        }
        public string Description { get; set; }
        public int LocationId { get; set; }

        public ILookup Location { get; set; }
    }
}
