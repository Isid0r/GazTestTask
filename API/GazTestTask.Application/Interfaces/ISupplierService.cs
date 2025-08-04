using GazTestTask.Application.DTOs.Suppliers;

namespace GazTestTask.Application.Interfaces.Services
{
    public interface ISupplierService
    {
        public Task<IEnumerable<PopularSupplierDto>> GetPopularSuppliersAsync();
    }
}
