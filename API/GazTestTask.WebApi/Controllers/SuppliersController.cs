using Microsoft.AspNetCore.Mvc;
using GazTestTask.Application.DTOs.Suppliers;
using GazTestTask.Application.Interfaces.Services;

namespace GazTestTask.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SuppliersController(ISupplierService supplierService) : ControllerBase
    {
        private readonly ISupplierService _supplierService = supplierService;

        [HttpGet("popular")]
        public async Task<ActionResult<IEnumerable<PopularSupplierDto>>> GetPopularSuppliers()
        {
            var result = await _supplierService.GetPopularSuppliersAsync();
            return Ok(result);
        }
    }
}