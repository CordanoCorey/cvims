using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CVIMS.Api.Infrastructure.Controllers;
using CVIMS.Api.Infrastructure.Models;

namespace CVIMS.Api.Features.Categories
{
    [Route("api/categories")]
    public class CategoriesController : BaseController
    {
        private readonly ICategoriesService _service;

        public CategoriesController(ICategoriesService service)
        {
            _service = service;
        }

        /**
         *  GET: api/categories
         */
        [HttpGet]
        public IActionResult GetCategories()
        {
            return Get(_service.GetCategories);
        }


        /**
         *  GET: api/categories/schoolstore
         */
        [HttpGet("schoolstore")]
        public IActionResult GetSchoolStoreCategories()
        {
            return Get(_service.GetSchoolStoreCategories);
        }

        /**
         *  GET: api/categories/staffstore
         */
        [HttpGet("staffstore")]
        public IActionResult GetStaffStoreCategories()
        {
            return Get(_service.GetStaffStoreCategories);
        }
    }
}
