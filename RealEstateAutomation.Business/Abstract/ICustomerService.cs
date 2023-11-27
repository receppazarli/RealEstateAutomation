using RealEstateAutomation.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateAutomation.Business.Abstract
{
    public interface ICustomerService
    {
        List<Customer> GetAll();
        void Add(Customer customer);
        void Update(Customer customer);
    }
}
