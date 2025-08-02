using GazTestTask.Domain.DTOs.Suppliers;

namespace GazTestTask.Domain.DTOs.Offers
{
    public class OfferDto
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public SupplierDto Supplier { get; set; }
        public DateTime RegistrationDate { get; set; }
    }
} 