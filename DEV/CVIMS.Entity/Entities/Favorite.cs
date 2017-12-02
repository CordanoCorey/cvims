using CVIMS.Entity.Auth;
using System;
using System.Collections.Generic;
using System.Text;

namespace CVIMS.Entity.Entities
{
    public partial class Favorite
    {
        public string UserId { get; set; }
        public int ProductId { get; set; }

        public virtual ApplicationUser User { get; set; }
        public virtual Product Product { get; set; }
    }
}
