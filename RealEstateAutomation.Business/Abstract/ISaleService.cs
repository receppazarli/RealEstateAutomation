using System.Collections.Generic;
using RealEstateAutomation.Entities.Concrete;

namespace RealEstateAutomation.Business.Abstract
{
    public interface ISaleService
    {
        void Add(Sale sale);
        List<Sale> GetAll();

    }
}