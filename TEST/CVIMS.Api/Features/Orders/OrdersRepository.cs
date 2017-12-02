using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CVIMS.Api.Infrastructure.Repositories;
using CVIMS.Entity.Context;
using CVIMS.Entity.Entities;

namespace CVIMS.Api.Features.Orders
{
    public interface IOrdersRepository : IBaseRepository<Order, OrderModel>
    {
    }
    public class OrdersRepository : BaseRepository<Order, OrderModel>, IOrdersRepository
    {
        public OrdersRepository(CVIMSContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
