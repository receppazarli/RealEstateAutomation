using RealEstateAutomation.DataAccess.Abstract;
using RealEstateAutomation.Entities.Concrete;

namespace RealEstateAutomation.DataAccess.Concrete.EntityFramework
{
    public class EfOwnerDal : EfEntityRepositoryBase<Owner, RealEstateAutomationContext>, IOwnerDal
    {

    }
}