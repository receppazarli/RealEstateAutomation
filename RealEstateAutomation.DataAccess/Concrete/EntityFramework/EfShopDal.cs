using RealEstateAutomation.DataAccess.Abstract;
using RealEstateAutomation.Entities.Concrete;

namespace RealEstateAutomation.DataAccess.Concrete.EntityFramework
{
    public class EfShopDal : EfEntityRepositoryBase<Shop, RealEstateAutomationContext>, IShopDal
    {

    }
}