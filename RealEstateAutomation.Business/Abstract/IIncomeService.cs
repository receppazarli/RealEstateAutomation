using System.Collections.Generic;
using RealEstateAutomation.Entities.Concrete;

namespace RealEstateAutomation.Business.Abstract
{
    public interface IIncomeService
    {
        List<Income> GetAll();
        void Add(Income income);
        void Update(Income income);
    }
}