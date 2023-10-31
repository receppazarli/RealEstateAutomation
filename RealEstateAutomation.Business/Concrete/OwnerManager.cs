using RealEstateAutomation.Business.Abstract;
using RealEstateAutomation.DataAccess.Abstract;

namespace RealEstateAutomation.Business.Concrete
{
    public class OwnerManager :IOwnerService
    {
        private IOwnerDal _ownerDal;

        public OwnerManager(IOwnerDal ownerDal)
        {
            _ownerDal = ownerDal;
        }
    }
}