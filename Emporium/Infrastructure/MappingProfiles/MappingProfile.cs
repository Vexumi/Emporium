using AutoMapper;
using Emporium.Models;
using Emporium.Models.Dto;

namespace Emporium.Infrastructure.MappingProfiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductDto>()
                .ForMember(dest => dest.Seller, opt => opt.MapFrom(src => src.Seller.User.FullName));
            CreateMap<Order, OrderDto>()
                .ForMember(dest => dest.Customer, opt => opt.MapFrom(src => src.Customer.User.FullName))
                .ForMember(dest => dest.Employee, opt => opt.MapFrom(src => src.Employee.User.FullName))
                .ForMember(dest => dest.TotalProductsCount, opt => opt.MapFrom(src => src.OrderDetails.Count));
        }
    }
}
