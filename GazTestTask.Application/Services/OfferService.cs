using AutoMapper;
using GazTestTask.Application.DTOs.Common;
using GazTestTask.Application.DTOs.Offers;
using GazTestTask.Application.Interfaces.Services;
using GazTestTask.Domain.Entities;
using GazTestTask.Domain.Interfaces.Repositories;
using Microsoft.Extensions.Logging;

namespace GazTestTask.Application.Services
{
    public class OfferService: IOfferService
    {
        private readonly IOfferRepository _offerRepository;
        private readonly ISupplierRepository _supplierRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<OfferService> _logger;

        public OfferService(IOfferRepository offerRepository, ISupplierRepository supplierRepository, IMapper mapper, ILogger<OfferService> logger)
        {
            _offerRepository = offerRepository;
            _supplierRepository = supplierRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<OfferDto> CreateOfferAsync(CreateOfferDto createOfferDto)
        {
            _logger.LogInformation("Начало создания предложения для поставщика с ID: {SupplierId}", createOfferDto.SupplierId);
            
            var supplier = await _supplierRepository.GetByIdAsync(createOfferDto.SupplierId);
            if (supplier == null)
            {
                _logger.LogWarning("Поставщик с ID {SupplierId} не найден", createOfferDto.SupplierId);
                throw new ArgumentException("Поставщик с указанным ID не найден");
            }

            _logger.LogInformation("Поставщик найден: {SupplierName}", supplier.Name);

            var offer = _mapper.Map<Offer>(createOfferDto);
            offer.SupplierId = createOfferDto.SupplierId;

            await _offerRepository.AddAsync(offer);
            _logger.LogInformation("Предложение успешно создано с ID: {OfferId}", offer.Id);

            return _mapper.Map<OfferDto>(offer);
        }

        public async Task<SearchResultDto<OfferDto>> SearchOffersAsync(string? search = null)
        {
            _logger.LogInformation("Начало поиска предложений. Поисковый запрос: {Search}", search);
            
            var offers = await _offerRepository.SearchAsync(search);
            var totalCount = await _offerRepository.GetTotalCountAsync();

            _logger.LogInformation("Найдено предложений: {Count}, общее количество: {TotalCount}", offers.Count(), totalCount);

            var offerDtos = _mapper.Map<IEnumerable<OfferDto>>(offers);

            return new SearchResultDto<OfferDto>
            {
                Items = offerDtos,
                TotalCount = totalCount
            };
        }
    }
}
