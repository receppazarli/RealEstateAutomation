using RealEstateAutomation.Business.Abstract;
using RealEstateAutomation.DataAccess.Abstract;

namespace RealEstateAutomation.Business.Concrete
{
    public class FieldManager :IFieldService
    {
        private IFieldDal _fieldDal;

        public FieldManager(IFieldDal fieldDal)
        {
            _fieldDal = fieldDal;
        }
    }
}