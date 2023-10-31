using RealEstateAutomation.Business.Abstract;
using RealEstateAutomation.DataAccess.Abstract;

namespace RealEstateAutomation.Business.Concrete
{
    public class ExpenseManager :IExpenseService
    {
        private IExpensesDal _expensesDal;

        public ExpenseManager(IExpensesDal expensesDal)
        {
            _expensesDal = expensesDal;
        }
    }
}