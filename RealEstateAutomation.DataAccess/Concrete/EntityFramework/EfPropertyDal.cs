using RealEstateAutomation.DataAccess.Abstract;
using RealEstateAutomation.Entities.Concrete;

namespace RealEstateAutomation.DataAccess.Concrete.EntityFramework
{
    public class EfPropertyDal : EfEntityRepositoryBase<Property, RealEstateAutomationContext>, IPropertyDal
    {

    }
}