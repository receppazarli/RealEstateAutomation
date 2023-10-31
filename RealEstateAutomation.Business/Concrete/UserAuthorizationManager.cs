using RealEstateAutomation.Business.Abstract;
using RealEstateAutomation.DataAccess.Abstract;

namespace RealEstateAutomation.Business.Concrete
{
    public class UserAuthorizationManager :IUserAuthorizationService
    {
        private IUserAuthorizationDal _userAuthorizationDal;

        public UserAuthorizationManager(IUserAuthorizationDal userAuthorizationDal)
        {
            _userAuthorizationDal = userAuthorizationDal;
        }
    }
}