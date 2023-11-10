using System.Collections.Generic;
using RealEstateAutomation.Entities.Concrete;

namespace RealEstateAutomation.Business.Abstract
{
    public interface ICountyService
    {
        List<County> GetAll(int key);
    }
}