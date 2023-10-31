using RealEstateAutomation.DataAccess.Abstract;
using RealEstateAutomation.Entities.Concrete;

namespace RealEstateAutomation.DataAccess.Concrete.EntityFramework
{
    public class EfUserAuthorizationDal : EfEntityRepositoryBase<UserAuthorization, RealEstateAutomationContext>, IUserAuthorizationDal
    {

    }
}