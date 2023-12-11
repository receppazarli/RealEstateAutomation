using RealEstateAutomation.Entities.Concrete;

namespace RealEstateAutomation.Business.Abstract
{
    public interface IShopService
    {
        void Update(Shop shop);
        void Add(Shop shop);
        Shop GetLastAddedShop();
    }
}