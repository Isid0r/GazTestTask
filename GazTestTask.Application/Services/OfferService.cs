using AutoMapper;
using GazTestTask.Application.DTOs.Common;
using GazTestTask.Application.DTOs.Offers;
using GazTestTask.Application.Interfaces.Services;
using GazTestTask.Domain.Entities;
using GazTestTask.Domain.Interfaces.Repositories;


namespace GazTestTask.Application.Services
{
    public class OfferService: IOfferService
    {
        private readonly IOfferRepository _offerRepository;
        private readonly ISupplierRepository _supplierRepository;
        private readonly IMapper _mapper;

        public OfferService(IOfferRepository offerRepository, ISupplierRepository supplierRepository, IMapper mapper)
        {
            _offerRepository = offerRepository;
            _supplierRepository = supplierRepository;
            _mapper = mapper;
        }

        public async Task<OfferDto> CreateOfferAsync(CreateOfferDto createOfferDto)
        {
            var supplier = await _supplierRepository.GetByIdAsync(createOfferDto.SupplierId);
            if (supplier == null)
            {
                throw new ArgumentException("Поставщик с указанным ID не найден");
            }

            var offer = _mapper.Map<Offer>(createOfferDto);
            offer.SupplierId = createOfferDto.SupplierId;

            await _offerRepository.AddAsync(offer);

            return _mapper.Map<OfferDto>(offer);
        }

        public async Task<SearchResultDto<OfferDto>> SearchOffersAsync(string? search = null)
        {
            var offers = await _offerRepository.SearchAsync(search);
            var totalCount = await _offerRepository.GetTotalCountAsync();

            var offerDtos = _mapper.Map<IEnumerable<OfferDto>>(offers);

            return new SearchResultDto<OfferDto>
            {
                Items = offerDtos,
                TotalCount = totalCount
            };
        }
    }
}
