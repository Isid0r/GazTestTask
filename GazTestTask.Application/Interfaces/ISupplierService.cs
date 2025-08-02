using GazTestTask.Application.DTOs.Suppliers;

namespace GazTestTask.Domain.Interfaces.Services
{
    public interface ISupplierService
    {
        public Task<IEnumerable<PopularSupplierDto>> GetPopularSuppliersAsync();
    }
}
