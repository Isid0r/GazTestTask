using Microsoft.AspNetCore.Mvc;
using GazTestTask.Application.DTOs.Common;
using GazTestTask.Application.DTOs.Offers;
using GazTestTask.Application.Interfaces.Services;

namespace GazTestTask.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OffersController(IOfferService offerService) : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<OfferDto>> CreateOffer([FromBody] CreateOfferDto createOfferDto)
        {
            var result = await offerService.CreateOfferAsync(createOfferDto);
            return CreatedAtAction(nameof(CreateOffer), result);
        }

        [HttpGet("search")]
        public async Task<ActionResult<SearchResultDto<OfferDto>>> SearchOffers([FromQuery] string? search = null)
        {
            var result = await offerService.SearchOffersAsync(search);
            return Ok(result);
        }
    }
}