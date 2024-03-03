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
        }
    }
}
