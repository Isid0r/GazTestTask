using GazTestTask.Domain.DTOs.Common;
using GazTestTask.Domain.DTOs.Offers;

namespace GazTestTask.Domain.Interfaces.Services
{
    public interface IOfferService
    {
        public Task<OfferDto> CreateOfferAsync(CreateOfferDto createOfferDto);

        public Task<SearchResultDto<OfferDto>> SearchOffersAsync(string? search = null);
    }
}
