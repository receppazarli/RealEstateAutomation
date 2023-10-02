using RealEstateAutomation.Entities.Abstract;

namespace RealEstateAutomation.Entities.Concrete
{
    public class User : IEntity
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public int UserAuthorization { get; set; }
        public bool DeleteFlag { get; set; }


    }
}