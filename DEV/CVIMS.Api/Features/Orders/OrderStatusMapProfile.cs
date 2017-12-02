using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CVIMS.Api.Features.Orders;
using CVIMS.Entity.Entities;
using AutoMapper;

namespace CVIMS.Api.Infrastructure.Mapper
{
    public class OrderStatusMapProfile : Profile
    {
        public OrderStatusMapProfile()
        {
            CreateMap<OrderStatus_xref, OrderStatusModel>();

            CreateMap<OrderStatusModel, OrderStatus_xref>();

            CreateMap<OrderModel, Order>();
        }
    }
}
