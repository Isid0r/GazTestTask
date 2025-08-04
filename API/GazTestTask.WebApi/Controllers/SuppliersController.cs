using Microsoft.AspNetCore.Mvc;
using GazTestTask.Application.DTOs.Suppliers;
using GazTestTask.Application.Interfaces.Services;

namespace GazTestTask.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SuppliersController : ControllerBase
    {
        private readonly ISupplierService _supplierService;
        private readonly ILogger<SuppliersController> _logger;

        public SuppliersController(ISupplierService supplierService, ILogger<SuppliersController> logger)
        {
            _supplierService = supplierService;
            _logger = logger;
        }

        [HttpGet("popular")]
        public async Task<ActionResult<IEnumerable<PopularSupplierDto>>> GetPopularSuppliers()
        {
            try
            {
                var result = await _supplierService.GetPopularSuppliersAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка при получении популярных поставщиков");
                return StatusCode(500);
            }
        }
    }
} 