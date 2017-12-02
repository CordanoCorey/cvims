using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CVIMS.Api.Infrastructure.Controllers;
using CVIMS.Api.Infrastructure.Models;

namespace CVIMS.Api.Features.CartItems
{
    [Route("api/cartitems")]
    public class CartItemsController : BaseController
    {
        private readonly ICartItemsService _service;

        public CartItemsController(ICartItemsService service)
        {
            _service = service;
        }

        /**
         *  GET: api/cartitems
         */
        [HttpGet]
        public IActionResult GetCartItems()
        {
            return Get(_service.GetCartItems, UserId);
        }

        /**
         *  POST: api/cartitems
         */
        [HttpPost]
        public IActionResult AddCartItem([FromBody]CartItemModel model)
        {
            return Post(_service.AddCartItem, AuditNew(model));
        }

        /**
         *  PUT: api/cartitems/5
         */
        [HttpPut("{productId}")]
        public IActionResult UpdateCartItem(int productId, [FromBody]CartItemModel model)
        {
            return Put(_service.UpdateCartItem, AuditExisting(model));
        }

        // DELETE api/cartItems/5
        [HttpDelete("{id}")]
        public IActionResult DeleteCartItem(int id)
        {
            return Delete(_service.DeleteCartItem, id);
        }
    }
}
