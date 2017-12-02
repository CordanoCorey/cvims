using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CVIMS.Api.Infrastructure.Controllers;
using CVIMS.Api.Infrastructure.Models;

namespace CVIMS.Api.Features.Orders
{
    [Route("api/orders")]
    public class OrdersController : BaseController
    {
        private readonly IOrdersService _service;

        public OrdersController(IOrdersService service)
        {
            _service = service;
        }

        /**
         *  GET: api/orders
         */
        [HttpGet]
        public IActionResult GetOrders([FromQuery] QueryModel<OrderModel> query)
        {
            return Get(_service.GetOrders, query);
        }

        /**
         *  GET: api/orders
         */
        [HttpGet("{id}")]
        public IActionResult GetOrder(int orderId)
        {
            return Get(_service.GetOrder, orderId);
        }
    }
}
