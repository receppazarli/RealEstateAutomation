using RealEstateAutomation.Entities.Abstract;

namespace RealEstateAutomation.Entities.Concrete
{
    public class Plot : IEntity
    {
        public int Id { get; set; }
        public int PropertyId { get; set; }
        public int OwnerId { get; set; }
        public decimal Area { get; set; }
        public string Ada { get; set; }
        public string Pafta { get; set; }
        public int City { get; set; }
        public int County { get; set; }
        public string Address { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public bool DeleteFlag { get; set; }

    }
}