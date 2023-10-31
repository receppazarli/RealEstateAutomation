using RealEstateAutomation.Business.Abstract;
using RealEstateAutomation.DataAccess.Abstract;

namespace RealEstateAutomation.Business.Concrete
{
    public class IncomeManager :IIncomeService
    {
        private IIncomeDal _incomeDal;

        public IncomeManager(IIncomeDal incomeDal)
        {
            _incomeDal = incomeDal;
        }
    }
}