using CVIMS.Api.Infrastructure.Models;
using CVIMS.Api.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CVIMS.Api.Infrastructure.Controllers
{
    [Route("api/search")]
    public class SearchController : BaseController
    {
        private readonly ISearchService _service;

        public SearchController(ISearchService service)
        {
            _service = service;
        }

        /**
         *  GET: api/search
         */
        [HttpGet]
        public IActionResult Search([FromQuery] IQueryModel query)
        {
            return Ok(_service.Search(query));
        }
    }
}
