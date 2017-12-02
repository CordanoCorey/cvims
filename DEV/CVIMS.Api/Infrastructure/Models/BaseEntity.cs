using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CVIMS.Api.Infrastructure.Models
{
    public abstract class BaseEntity
    {
        public string LastModifiedById { get; set; }
        public string LastModifiedByName { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public string CreatedById { get; set; }
        public string CreatedByName { get; set; }
        public DateTime? CreatedDate { get; set; }

        public UserModel CreatedBy { get; set; }
        public UserModel LastModifiedBy { get; set; }
    }
}