using RealEstateAutomation.Entities.Abstract;

namespace RealEstateAutomation.Entities.Concrete
{
    public class Owner : IEntity
    {
        public int Id { get; set; }
        public string NationalityId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public bool DeleteFlag { get; set; }
    }
}