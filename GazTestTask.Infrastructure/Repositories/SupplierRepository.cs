using GazTestTask.Domain.Entities;
using GazTestTask.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using GazTestTask.Infrastructure.Data;
using Microsoft.Extensions.Logging;

namespace GazTestTask.Infrastructure.Repositories
{
    public class SupplierRepository : BaseRepository<Supplier>, ISupplierRepository
    {
        private readonly ILogger<SupplierRepository> _logger;

        public SupplierRepository(AppDbContext context, ILogger<SupplierRepository> logger) : base(context)
        {
            _logger = logger;
        }

        public async Task<IEnumerable<Supplier>> GetTopSuppliersAsync(int count)
        {
            _logger.LogInformation("Получение топ {Count} поставщиков по количеству предложений", count);
            
            var result = await _dbSet
                .Include(s => s.Offers)
                .OrderByDescending(s => s.Offers.Count)
                .Take(count)
                .ToListAsync();
            
            _logger.LogInformation("Получено {Count} популярных поставщиков", result.Count);
            
            return result;
        }
    }
}
