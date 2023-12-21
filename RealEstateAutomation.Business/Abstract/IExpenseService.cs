using System.Collections.Generic;
using RealEstateAutomation.Entities.Concrete;

namespace RealEstateAutomation.Business.Abstract
{
    public interface IExpenseService
    {
        List<Expense> GetAll();
        void Add(Expense expense);
        void Update(Expense expense);
    }
}