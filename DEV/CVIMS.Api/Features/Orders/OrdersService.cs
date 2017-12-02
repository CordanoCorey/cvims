using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CVIMS.Api.Infrastructure.Models;

namespace CVIMS.Api.Features.Orders
{
    public interface IOrdersService
    {
        SearchResults<OrderModel> GetOrders(QueryModel<OrderModel> query);
        OrderModel GetOrder(int id);
        OrderModel SaveOrder(OrderModel model);
    }

    public class OrderStatusService : IOrdersService
    {
        private readonly IOrdersRepository _repo;

        public OrderStatusService(IOrdersRepository repo)
        {
            _repo = repo;
        }

        public OrderModel GetOrder(int id)
        {
            return _repo.FindByKey(id);
        }

        public SearchResults<OrderModel> GetOrders(QueryModel<OrderModel> query)
        {
            throw new NotImplementedException();
        }

        public OrderModel SaveOrder(OrderModel model)
        {
            return _repo.Insert(model);
        }
    }
}
