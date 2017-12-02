﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CVIMS.Api.Infrastructure.Models
{
    public interface IAuditable
    {
        int CreatedBy { get; set; }
        DateTime CreatedDate { get; set; }
        int? UpdateBy { get; set; }
        DateTime? UpdateDate { get; set; }
    }
}
