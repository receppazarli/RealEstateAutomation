using RealEstateAutomation.Entities.Abstract;

namespace RealEstateAutomation.Entities.Concrete
{
    public class UserAuthorization : IEntity
    {
        public int Id { get; set; }

        public string UserAuthorizationName { get; set; }

        public bool DeleteFlag { get; set; }

    }
}