using Microsoft.AspNetCore.Mvc;
using GazTestTask.Application.Services;
using GazTestTask.Domain.DTOs.Offers;
using GazTestTask.Domain.DTOs.Common;

namespace GazTestTask.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OffersController : ControllerBase
    {
        private readonly OfferService _offerService;

        public OffersController(OfferService offerService)
        {
            _offerService = offerService;
        }

        [HttpPost]
        public async Task<ActionResult<OfferDto>> CreateOffer([FromBody] CreateOfferDto createOfferDto)
        {
            try
            {
                var result = await _offerService.CreateOfferAsync(createOfferDto);
                return CreatedAtAction(nameof(CreateOffer), result);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("search")]
        public async Task<ActionResult<SearchResultDto<OfferDto>>> SearchOffers([FromQuery] string? search = null)
        {
            var result = await _offerService.SearchOffersAsync(search);
            return Ok(result);
        }
    }
} 