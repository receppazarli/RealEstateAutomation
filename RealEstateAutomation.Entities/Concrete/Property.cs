using RealEstateAutomation.Entities.Abstract;

namespace RealEstateAutomation.Entities.Concrete
{
    public class Property : IEntity
    {
        public int Id { get; set; }
        public string PropertyType { get; set; }
        public bool DeleteFlag { get; set; }
    }
}