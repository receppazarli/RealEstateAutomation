using RealEstateAutomation.DataAccess.Abstract;
using RealEstateAutomation.Entities.Concrete;

namespace RealEstateAutomation.DataAccess.Concrete.EntityFramework
{
    public class EfFieldDal : EfEntityRepositoryBase<Field, RealEstateAutomationContext>, IFieldDal
    {

    }
}