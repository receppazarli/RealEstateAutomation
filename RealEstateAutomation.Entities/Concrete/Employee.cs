using RealEstateAutomation.Entities.Abstract;

namespace RealEstateAutomation.Entities.Concrete
{
    public class Employee : IEntity
    {
        public int Id { get; set; }

        public string NationalityId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string City { get; set; }
        public string County { get; set; }
        public string Address { get; set; }
        public bool DeleteFlag { get; set; }

    }
}