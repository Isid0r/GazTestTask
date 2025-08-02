using Microsoft.AspNetCore.Mvc;
using GazTestTask.Domain.DTOs.Suppliers;
using GazTestTask.Domain.Interfaces.Services;

namespace GazTestTask.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SuppliersController : ControllerBase
    {
        private readonly ISupplierService _supplierService;

        public SuppliersController(ISupplierService supplierService)
        {
            _supplierService = supplierService;
        }

        [HttpGet("popular")]
        public async Task<ActionResult<IEnumerable<PopularSupplierDto>>> GetPopularSuppliers()
        {
            var result = await _supplierService.GetPopularSuppliersAsync();
            return Ok(result);
        }
    }
} 