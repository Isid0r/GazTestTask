using GazTestTask.Domain.Entities;
using GazTestTask.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using GazTestTask.Infrastructure.Data;

namespace GazTestTask.Infrastructure.Repositories
{
    public class OfferRepository : BaseRepository<Offer>, IOfferRepository
    {
        public OfferRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Offer>> SearchAsync(string query)
        {
            return await _dbSet
                .Include(o => o.Supplier)
                .Where(o => o.Brand.Contains(query) || 
                           o.Model.Contains(query) || 
                           o.Supplier.Name.Contains(query))
                .ToListAsync();
        }
    }
}
