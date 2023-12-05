using RealEstateAutomation.Entities.Concrete;

namespace RealEstateAutomation.Business.Abstract
{
    public interface IHouseService
    {
        void Add(House house);
        void Update(House house);
    }
}