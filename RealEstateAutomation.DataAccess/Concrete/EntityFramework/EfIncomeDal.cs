using RealEstateAutomation.DataAccess.Abstract;
using RealEstateAutomation.Entities.Concrete;

namespace RealEstateAutomation.DataAccess.Concrete.EntityFramework
{
    public class EfIncomeDal : EfEntityRepositoryBase<Income, RealEstateAutomationContext>, IIncomeDal
    {

    }
}