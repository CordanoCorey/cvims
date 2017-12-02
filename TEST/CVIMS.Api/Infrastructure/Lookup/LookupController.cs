using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CVIMS.Api.Infrastructure.Lookup
{
    [Route("api/[controller]")]
    public class LookupController : Controller
    {
        private readonly ILookupRepository _lookupRepository;
        public LookupController(ILookupRepository lookupRepository)
        {
            _lookupRepository = lookupRepository;
        }
        
        [HttpGet]
        public IEnumerable<LookupModel> Get()
        {
            var values = _lookupRepository.GetLookups();

            return values;
        }
    }
}
