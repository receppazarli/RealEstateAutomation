using System.Collections.Generic;
using System.Linq;
using RealEstateAutomation.Business.Abstract;
using RealEstateAutomation.DataAccess.Abstract;
using RealEstateAutomation.Entities.Concrete;

namespace RealEstateAutomation.Business.Concrete
{
    public class CountyManager : ICountyService
    {
        private ICountyDal _countyDal;

        public CountyManager(ICountyDal countyDal)
        {
            _countyDal = countyDal;
        }

        public List<County> GetAll(int key)
        {
            return _countyDal.GetAll(x => x.CityId == key).ToList();
        }
    }
}