using Microsoft.AspNetCore.Mvc;
using GazTestTask.Domain.DTOs.Offers;
using GazTestTask.Domain.DTOs.Common;
using GazTestTask.Domain.Interfaces.Services;

namespace GazTestTask.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OffersController : ControllerBase
    {
        private readonly IOfferService _offerService;

        public OffersController(IOfferService offerService)
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