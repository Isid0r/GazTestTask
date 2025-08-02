using GazTestTask.Domain.Entities;
using GazTestTask.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using GazTestTask.Infrastructure.Data;

namespace GazTestTask.Infrastructure.Repositories
{
    public class SupplierRepository : BaseRepository<Supplier>, ISupplierRepository
    {
        public SupplierRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Supplier>> GetTopSuppliersAsync(int count)
        {
            return await _dbSet
                .OrderByDescending(s => s.CreatedDate)
                .Take(count)
                .ToListAsync();
        }
    }
}
