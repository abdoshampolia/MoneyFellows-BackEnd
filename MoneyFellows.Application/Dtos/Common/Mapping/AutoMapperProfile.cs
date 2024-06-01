using AutoMapper;
using MoneyFellows.Application.Dtos.Orders;
using MoneyFellows.Application.Dtos.ProductOrders;
using MoneyFellows.Application.Dtos.Products;
using MoneyFellows.Core.Entities;

namespace MoneyFellows.Application.Dtos.Common.Mapping
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Product, ProductDto>();
            CreateMap<Order, OrderDto>();
            CreateMap<ProductOrder, ProductOrderDto>();
        }
    }
}
