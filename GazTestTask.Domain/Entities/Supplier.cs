namespace GazTestTask.Domain.Entities
{
    public class Supplier: BaseEntity
    {
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public virtual ICollection<Offer> Offers { get; set; } = new List<Offer>();
    }
}
