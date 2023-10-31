using RealEstateAutomation.Entities.Abstract;

namespace RealEstateAutomation.Entities.Concrete
{
    public class Customer : IEntity
    {
        public int Id { get; set; }
        public string NationalityId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public int? County { get; set; }
        public int? City { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public bool DeleteFlag { get; set; }
    }
}