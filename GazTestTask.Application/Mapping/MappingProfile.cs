using AutoMapper;
using GazTestTask.Domain.DTOs.Offers;
using GazTestTask.Domain.DTOs.Suppliers;
using GazTestTask.Domain.Entities;

namespace GazTestTask.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Offer, OfferDto>()
                .ForMember(dest => dest.Supplier, opt => opt.MapFrom(src => src.Supplier));

            CreateMap<CreateOfferDto, Offer>()
                .ForMember(dest => dest.RegistrationDate, opt => opt.MapFrom(src => DateTime.UtcNow));

            CreateMap<Supplier, SupplierDto>();

            CreateMap<Supplier, PopularSupplierDto>()
                .ForMember(dest => dest.OffersCount, opt => opt.MapFrom(src => src.Offers.Count));
        }
    }
} 