using GazTestTask.Domain.Entities;
using GazTestTask.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using GazTestTask.Infrastructure.Data;
using Microsoft.Extensions.Logging;

namespace GazTestTask.Infrastructure.Repositories
{
    public class OfferRepository : BaseRepository<Offer>, IOfferRepository
    {
        private readonly ILogger<OfferRepository> _logger;

        public OfferRepository(AppDbContext context, ILogger<OfferRepository> logger) : base(context)
        {
            _logger = logger;
        }

        public async Task<IEnumerable<Offer>> SearchAsync(string? search = null)
        {
            _logger.LogInformation("Поиск предложений с фильтром: {Search}", search);
            
            var query = _dbSet.Include(o => o.Supplier).AsQueryable();

            if (!string.IsNullOrWhiteSpace(search))
            {
                query = query.Where(o => o.Brand.Contains(search) || 
                                       o.Model.Contains(search) || 
                                       o.Supplier.Name.Contains(search));
            }

            var result = await query.ToListAsync();
            _logger.LogInformation("Найдено предложений: {Count}", result.Count);
            
            return result;
        }
    }
}
