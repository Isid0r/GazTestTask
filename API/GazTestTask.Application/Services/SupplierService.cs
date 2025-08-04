using AutoMapper;
using GazTestTask.Application.DTOs.Suppliers;
using GazTestTask.Application.Interfaces.Services;
using GazTestTask.Domain.Interfaces.Repositories;
using Microsoft.Extensions.Logging;

namespace GazTestTask.Application.Services
{
    public class SupplierService: ISupplierService
    {
        private readonly ISupplierRepository _supplierRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<SupplierService> _logger;

        public SupplierService(ISupplierRepository supplierRepository, IMapper mapper, ILogger<SupplierService> logger)
        {
            _supplierRepository = supplierRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<IEnumerable<PopularSupplierDto>> GetPopularSuppliersAsync()
        {
            _logger.LogInformation("Запрос популярных поставщиков");
            
            var topSuppliers = await _supplierRepository.GetTopSuppliersAsync(3);
            
            _logger.LogInformation("Найдено популярных поставщиков: {Count}", topSuppliers.Count());

            return _mapper.Map<IEnumerable<PopularSupplierDto>>(topSuppliers);
        }
    }
}
