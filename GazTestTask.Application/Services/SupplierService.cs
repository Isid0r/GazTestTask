using AutoMapper;
using GazTestTask.Application.DTOs.Suppliers;
using GazTestTask.Application.Interfaces.Services;
using GazTestTask.Domain.Interfaces.Repositories;

namespace GazTestTask.Application.Services
{
    public class SupplierService: ISupplierService
    {
        private readonly ISupplierRepository _supplierRepository;
        private readonly IMapper _mapper;

        public SupplierService(ISupplierRepository supplierRepository, IMapper mapper)
        {
            _supplierRepository = supplierRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PopularSupplierDto>> GetPopularSuppliersAsync()
        {
            var topSuppliers = await _supplierRepository.GetTopSuppliersAsync(3);

            return _mapper.Map<IEnumerable<PopularSupplierDto>>(topSuppliers);
        }
    }
}
