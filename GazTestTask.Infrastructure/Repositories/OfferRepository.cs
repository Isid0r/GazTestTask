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

        public async Task<IEnumerable<Offer>> SearchAsync(string? search = null)
        {
            var query = _dbSet.Include(o => o.Supplier).AsQueryable();

            if (!string.IsNullOrWhiteSpace(search))
            {
                query = query.Where(o => o.Brand.Contains(search) || 
                                       o.Model.Contains(search) || 
                                       o.Supplier.Name.Contains(search));
            }

            return await query.ToListAsync();
        }
    }
}
