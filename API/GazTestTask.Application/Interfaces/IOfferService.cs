using GazTestTask.Application.DTOs.Common;
using GazTestTask.Application.DTOs.Offers;

namespace GazTestTask.Application.Interfaces.Services
{
    public interface IOfferService
    {
        public Task<OfferDto> CreateOfferAsync(CreateOfferDto createOfferDto);

        public Task<SearchResultDto<OfferDto>> SearchOffersAsync(string? search = null);
    }
}
