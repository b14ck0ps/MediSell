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

            CreateMap<Company, CompanyDto>();
            CreateMap<CompanyDto, Company>();

            CreateMap<Order, OrderDto>();
            CreateMap<OrderDto, Order>();

            CreateMap<ProductsOrder, ProductsOrderDto>();
            CreateMap<ProductsOrderDto, ProductsOrder>();

            CreateMap<Category, CategoryDto>();
            CreateMap<CategoryDto, Category>();
            CreateMap<Profit, ProfitDto>();
            CreateMap<ProfitDto, Profit>();

            CreateMap<AccountCashIn, AccountCashInDto>();
            CreateMap<AccountCashInDto, AccountCashIn>();

            CreateMap<AccountCashOut, AccountCashOutDto>();
            CreateMap<AccountCashOutDto, AccountCashOut>();
        }
    }
}