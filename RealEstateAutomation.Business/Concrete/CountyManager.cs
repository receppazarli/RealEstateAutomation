using RealEstateAutomation.Business.Abstract;
using RealEstateAutomation.DataAccess.Abstract;

namespace RealEstateAutomation.Business.Concrete
{
    public class CountyManager :ICountyService
    {
        private ICountyDal _countyDal;

        public CountyManager(ICountyDal countyDal)
        {
            _countyDal = countyDal;
        }
    }
}