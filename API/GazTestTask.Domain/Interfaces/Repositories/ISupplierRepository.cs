using GazTestTask.Domain.Entities;

namespace GazTestTask.Domain.Interfaces.Repositories
{
    public interface ISupplierRepository : IRepository<Supplier>
    {
        Task<IEnumerable<Supplier>> GetTopSuppliersAsync(int count);
    }
}
