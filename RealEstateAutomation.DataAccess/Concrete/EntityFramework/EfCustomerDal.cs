using RealEstateAutomation.DataAccess.Abstract;
using RealEstateAutomation.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateAutomation.DataAccess.Concrete.EntityFramework
{
    public class EfCustomerDal : EfEntityRepositoryBase<Customer, RealEstateAutomationContext>, ICustomerDal
    {

    }
}
