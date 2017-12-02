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
    public interface IOrderStatusRepository : IBaseRepository<OrderStatus_xref, OrderStatusModel>
    {
    }
    public class OrderStatusRepository : BaseRepository<OrderStatus_xref, OrderStatusModel>, IOrderStatusRepository
    {
        public OrderStatusRepository(CVIMSContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
