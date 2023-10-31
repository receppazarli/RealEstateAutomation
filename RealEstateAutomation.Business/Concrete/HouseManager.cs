using RealEstateAutomation.Business.Abstract;
using RealEstateAutomation.DataAccess.Abstract;

namespace RealEstateAutomation.Business.Concrete
{
    public class HouseManager :IHouseService
    {
        private IHouseDal _houseDal;

        public HouseManager(IHouseDal houseDal)
        {
            _houseDal = houseDal;
        }
    }
}