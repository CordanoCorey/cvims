using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CVIMS.Api.Features.CartItems;
using CVIMS.Entity.Entities;
using AutoMapper;

namespace CVIMS.Api.Infrastructure.Mapper
{
    public class CartItemMapProfile : Profile
    {
        public CartItemMapProfile()
        {
            CreateMap<CartItem, CartItemModel>();

            CreateMap<CartItemModel, CartItem>()
                .ForMember(d => d.Order, opt => opt.Ignore())
                .ForMember(d => d.Product, opt => opt.Ignore());
        }
    }
}