using AutoMapper;
using Emporium.Models;
using Emporium.Models.Dto;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Linq;

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
            CreateMap<Employee, EmployeeDto>()
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.User.FullName))
                .ForMember(dest => dest.PickupPoint, opt => opt.MapFrom(src => src.PickupPoint.Address));
            CreateMap<PickupPoint, PickPointDto>()
                .ForMember(dest => dest.EmployeesCount, opt => opt.MapFrom(src => src.Employees.Count));
        }
    }
}
