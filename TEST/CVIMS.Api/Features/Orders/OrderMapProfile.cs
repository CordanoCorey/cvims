using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CVIMS.Api.Features.Orders;
using CVIMS.Entity.Entities;
using AutoMapper;

namespace CVIMS.Api.Infrastructure.Mapper
{
    public class OrderMapProfile : Profile
    {
        public OrderMapProfile()
        {
            CreateMap<Order, OrderModel>();

            CreateMap<OrderModel, Order>();
        }
    }
}
