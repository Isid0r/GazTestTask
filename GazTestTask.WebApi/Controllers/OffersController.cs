using Microsoft.AspNetCore.Mvc;
using GazTestTask.Application.DTOs.Common;
using GazTestTask.Application.DTOs.Offers;
using GazTestTask.Application.Interfaces.Services;

namespace GazTestTask.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OffersController : ControllerBase
    {
        private readonly IOfferService _offerService;
        private readonly ILogger<OffersController> _logger;

        public OffersController(IOfferService offerService, ILogger<OffersController> logger)
        {
            _offerService = offerService;
            _logger = logger;
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
                _logger.LogWarning(ex, "Ошибка при создании предложения");
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Неожиданная ошибка при создании предложения");
                return StatusCode(500);
            }
        }

        [HttpGet("search")]
        public async Task<ActionResult<SearchResultDto<OfferDto>>> SearchOffers([FromQuery] string? search = null)
        {
            try
            {
                var result = await _offerService.SearchOffersAsync(search);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка при поиске предложений");
                return StatusCode(500);
            }
        }
    }
} 