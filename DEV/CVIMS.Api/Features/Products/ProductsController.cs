using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CVIMS.Api.Infrastructure.Controllers;
using CVIMS.Api.Infrastructure.Models;

namespace CVIMS.Api.Features.Products
{
    [Route("api/products")]
    public class ProductsController : BaseController
    {
        private readonly IProductsService _service;

        public ProductsController(IProductsService service)
        {
            _service = service;
        }

        /**
         *  GET: api/products
         */
        [HttpGet]
        public IActionResult GetProducts([FromQuery] ProductsQueryModel query)
        {
            var result = _service.GetProducts(query);
            return Ok(result);
        }

        // GET api/products/5
        [HttpGet("{id}")]
        public IActionResult GetProduct(int id)
        {
            return Get(_service.GetProduct, id);
        }

        // POST api/products
        [HttpPost]
        public IActionResult AddProduct([FromBody]ProductModel model)
        {
            return Post(_service.AddProduct, Audit(model), "GetProduct");
        }

        // PUT api/products/5
        [HttpPut("{id}")]
        public IActionResult UpdateProduct(int id, [FromBody]ProductModel model)
        {
            return Put(_service.UpdateProduct, AuditExisting(model));
        }

        // DELETE api/products/5
        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            return Delete(_service.DeleteProduct, id);
        }

        /**
         *  GET: api/products/schoolstore
         */
        [HttpGet("schoolstore")]
        public IActionResult GetSchoolStoreProducts()
        {
            return Get(_service.GetSchoolStoreProducts);
        }

        /**
         *  GET: api/products/staffstore
         */
        [HttpGet("staffstore")]
        public IActionResult GetStaffStoreProducts()
        {
            return Get(_service.GetStaffStoreProducts);
        }

        /**
         *  GET: api/categories/5/products
         */
        [HttpGet("~/api/categories/{categoryId}/products")]
        public IActionResult GetProductsForCategory(int categoryId)
        {
            return Get(_service.GetProductsForCategory, categoryId);
        }
    }
}