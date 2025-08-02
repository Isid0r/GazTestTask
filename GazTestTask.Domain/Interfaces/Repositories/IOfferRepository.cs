using GazTestTask.Domain.Entities;

namespace GazTestTask.Domain.Interfaces.Repositories
{
    public interface IOfferRepository: IRepository<Offer>
    {
        Task<IEnumerable<Offer>> SearchAsync(string query);
    }
}
