using AutoMapper;
using DAL.Models;

namespace BLL.DTOs
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();

            CreateMap<Order, OrderDto>();
            CreateMap<OrderDto, Order>();

            CreateMap<ProductsOrder, ProductsOrderDto>();
            CreateMap<ProductsOrderDto, ProductsOrder>();

            CreateMap<DeliveryMan, DeliveryManDto>();
            CreateMap<DeliveryManDto, DeliveryMan>();

            CreateMap<DeliveryStatus, DeliveryStatusDto>();
            CreateMap<DeliveryStatusDto, DeliveryStatus>();

            CreateMap<PaymentMethod, PaymentMethodDto>();
            CreateMap<PaymentMethodDto, PaymentMethod>();
        }
    }
}